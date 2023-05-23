using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.SqlClient;

namespace E_BOOK_LIBRARY_PROJECT
{
   
    public partial class BorrowUserControl : UserControl
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        public BorrowUserControl()
        {
            InitializeComponent();
        }

        #region Properties

        private string _ebookname;
        private string _dateebook;
        private Image _ebookpic;

        [Category("Custom Props")]
        public string ebookname
        {
            get { return _ebookname; }
            set { _ebookname = value; lblebookname.Text = value; }
        }


        [Category("Custom Props")]
        public string dateebook
        {
            get { return _dateebook; }
            set { _dateebook = value; /*lbldateebook.Text = value;*/ }
        }


        [Category("Custom Props")]
        public Image ebookpic
        {
            get { return _ebookpic; }
            set { _ebookpic = value; ebookpicture.Image = value; }
        }

        #endregion
        public static string userid;
        private void EbookUserControl_Load(object sender, EventArgs e)
        {
            if (LoginUserForm.userborrowcount <= 0)
            {
                btborrow.Enabled = false;
                btborrow.StateCommon.Content.ShortText.Color1 = Color.Red;
                btborrow.StateCommon.Content.ShortText.Color2 = Color.Red;
            }
            Con.Open();
            ebookpicture.SizeMode = PictureBoxSizeMode.StretchImage;
            string username;
            username = LoginUserForm.username;
            var cmd1 = new MySqlCommand("SELECT user_id FROM usertbl WHERE user_name = '" + username + "'", Con);
            MySqlDataReader reader;
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                userid = reader.GetString(0);
            }

            Con.Close();
        }


        private void btborrow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการยืมหนังสือหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime datetimenow = DateTime.Now;
                DateTime expireddate = datetimenow.AddDays(7);
                string expire = expireddate.Date.ToString("yyyy-MM-dd");

                Con.Open();
                //นับจำนวน borrowid
                string Bebookid;
                Bebookid = ebookid.ToString();
                MySqlCommand cmd = new MySqlCommand("insert into borrowtbl(user_id,ebook_id,expired_book) values(" + userid + " , " + Bebookid + ",'" + expire + "')", Con);
                cmd.ExecuteNonQuery();
                LoginUserForm.userborrowcount = LoginUserForm.userborrowcount - 1;
                MySqlCommand cmd2 = new MySqlCommand("update usertbl set user_borrowcount = " + LoginUserForm.userborrowcount + " where user_name = '" + LoginUserForm.username +"';", Con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("ยืมหนังสือสำเร็จ");
                Con.Close();
                Hide();
                BorrowUserForm buf = new BorrowUserForm();
                buf.Refresh();
                //do something if YES
            }
            else
            {
                //do something if NO
            }
        }

        //รายละเอียด

        public string ebookid { get; set; }
        public string ebookauthorBUC { get; set; }
        public string ebooktypeBUC { get; set; }
        public Image ebookImgBUC { get; set; }
        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            Borrowinfo binfo = new Borrowinfo();
            binfo.ebookImg = ebookImgBUC;
            binfo.ebookname = lblebookname.Text;
            binfo.ebookauthor = ebookauthorBUC;
            binfo.ebooktype = ebooktypeBUC;
            binfo.ShowDialog();
        }
    }
}
