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
using System.Reflection;

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class EbookUserControl : UserControl
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        public EbookUserControl()
        {
            InitializeComponent();
        }

        #region Properties

        private string _ebookname;
        private DateTime _dateebook;
        private Image _ebookpic;

        [Category("Custom Props")]
        public string ebookname
        {
            get { return _ebookname; }
            set { _ebookname = value; lblebookname.Text = value; }
        }


        [Category("Custom Props")]
        public DateTime dateebook
        {
            get { return _dateebook; }
            set { _dateebook = value; }
        }


        [Category("Custom Props")]
        public Image ebookpic
        {
            get { return _ebookpic; }
            set { _ebookpic = value; ebookpicture.Image = value; }
        }

        #endregion
        private void EbookUserControl_Load(object sender, EventArgs e)
        {
            Con.Open();
            ebookpicture.SizeMode = PictureBoxSizeMode.StretchImage;
            DateTime mydatetime = DateTime.Now;
            
            if (dateebook < mydatetime)
            {
                lbldateebook.Text = "อีบุ๊คหมดอายุแล้ว";
                lbldateebook.ForeColor = Color.Red;
                btread.Enabled = false;
                btread.StateCommon.Content.ShortText.Color1 = Color.Red;
                btread.StateCommon.Content.ShortText.Color2 = Color.Red;
            }
            else
            {
                lbldateebook.Text = dateebook.Date.ToString("yyyy-MM-dd");
            }

            Con.Close();
        }
        
        public Int32 ebookid { get; set; }
        private void btread_Click(object sender, EventArgs e)
        {
            Con.Open();
            MySqlDataAdapter sda1 = new MySqlDataAdapter("SELECT COUNT(*) FROM borrowtbl WHERE borrowtbl.user_id = " + BookUserForm.userid, Con);
            //MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            string d = dt.Rows[0][0].ToString();
            var countebook = Convert.ToInt32(d);
            EbookUserControl[] Listitems = new EbookUserControl[countebook];

            List<string> ebooknamearry = new List<string>();
            List<string> ebookpdfarry = new List<string>();
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT ebooktbl.EbookName,ebooktbl.EbookPDF FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = " + BookUserForm.userid, Con);
            reader = cmd.ExecuteReader();
            
            //เก็บค่าชื่อและชื่อไฟล์ pdf
            while (reader.Read())
            {
                var ebookname = reader.GetString(0);
                var ebookpdf = reader.GetString(1);
                ebooknamearry.Add(ebookname);
                ebookpdfarry.Add(ebookpdf);
            }

            //อ่านอีบุ๊ค
            ReadForm rf = new ReadForm();
            rf.ePDF = ebookpdfarry[ebookid];
            rf.ShowDialog();

            Con.Close();
        }

        //คืนหนังสือ
        public Int32 borrowid { get; set; }
        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการคืนหนังสือหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Con.Open();
                string query = "delete from borrowtbl where borrowid = '" + borrowid + "';";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("คืนหนังสือสำเร็จ");
                //เพิ่มการยืม
                LoginUserForm.userborrowcount = LoginUserForm.userborrowcount + 1;
                MySqlCommand cmd2 = new MySqlCommand("update usertbl set user_borrowcount = " + LoginUserForm.userborrowcount + " where user_name = '" + LoginUserForm.username + "';", Con);
                cmd2.ExecuteNonQuery();
                Con.Close();
                Hide();
                //do something if YES
            }
            else
            {
                //do something if NO
            }
            
        }
        //SELECT EbookPDF FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = 1;
        //SELECT borrowtbl.User_ID,ebooktbl.EbookPDF FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = 2;
        //SELECT COUNT(*) FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = 2;
    }
}
