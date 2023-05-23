using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System.IO;

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class BookUserForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        public BookUserForm()
        {
            InitializeComponent();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void BookUserForm_Load(object sender, EventArgs e)
        {
            
            populateItems();
            combobox_ebooktype();
            DateTime mydatetime = DateTime.Now;
            lbldatetime.Text = mydatetime.Date.ToString("yyyy-MM-dd");
            
            lblname.Text = "ยินดีต้อนรับ\n" + LoginUserForm.username;
            lblcountborrow.Text = "จำนวนการยืม : " + LoginUserForm.userborrowcount;
            if (LoginUserForm.userimg == "")
            {

            }
            else
            {
                pictureuser.Image = Image.FromFile(Application.StartupPath + @"\UserImg\" + LoginUserForm.userimg, true);
            }
        }

        public string username { get; set; }
        
        public static int userid;
        private void populateItems()
        {
            Con.Open();
            flowLayoutPanel1.Controls.Clear();

            //เรียกค่า userid
            MySqlDataAdapter sda2 = new MySqlDataAdapter("select user_id from usertbl where user_name ='" + LoginUserForm.username + "'", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            string d2 = dt2.Rows[0][0].ToString();
            userid = Convert.ToInt32(d2);

            count = 0;
            //นับจำนวน ebook
            MySqlDataAdapter sda1 = new MySqlDataAdapter("SELECT COUNT(*) FROM borrowtbl WHERE borrowtbl.user_id = " + BookUserForm.userid, Con);
            //MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            string d = dt.Rows[0][0].ToString();
            var countebook = Convert.ToInt32(d);
            //EbookUserControl[] Listitems = new EbookUserControl[countebook];

            
            //แสดงชื่อของ ebook
            List<string> ebooknamearry = new List<string>();
            List<string> ebookpicturearry = new List<string>();
            List<int> borrowidarry = new List<int>();
            List<int> ebookidarry = new List<int>();
            List<DateTime> borrowexpirearry = new List<DateTime>();
            //SELECT EbookID FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = 1 ORDER BY EbookID ASC;
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT ebooktbl.EbookName,ebooktbl.EbookPicture,borrowtbl.borrowid,borrowtbl.expired_book,ebooktbl.ebookid FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = " + BookUserForm.userid + " AND ebooktbl.Ebookname LIKE '" + search + "%'" + " AND ebooktype LIKE '" + pbcbebooktype + "%'" , Con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ebookname = reader.GetString(0);
                var ebookpicture = reader.GetString(1);
                var borrowid = reader.GetInt32(2);
                var borrowexpire = reader.GetDateTime(3);
                var ebookid = reader.GetInt32(4);
                ebooknamearry.Add(ebookname);
                ebookpicturearry.Add(ebookpicture);
                borrowidarry.Add(borrowid);
                borrowexpirearry.Add(borrowexpire);
                ebookidarry.Add(ebookid);
                count++;
            }

            EbookUserControl[] Listitems = new EbookUserControl[count];

            int[] ebookarray;
            ebookarray = ebookidarry.ToArray();
            BorrowUserForm.ebookiduser = ebookarray;

            for (int i = 0; i < Listitems.Length; i++)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Listitems[i] = new EbookUserControl();
                Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i],true);
                Listitems[i].ebookname = ebooknamearry[i];
                Listitems[i].ebookid = i;
                Listitems[i].borrowid = borrowidarry[i];
                Listitems[i].dateebook = borrowexpirearry[i];
                flowLayoutPanel1.Controls.Add(Listitems[i]);
            }
            Con.Close();
        }
    
        private void btblogin_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e) //หน้ายืมหนังสือ
        {
            BorrowUserForm BUF = new BorrowUserForm();
            BUF.Show();
            Close();
        }

        private void btlogout_Click(object sender, EventArgs e)
        {
            LoginUserForm loginform = new LoginUserForm();
            loginform.Show();
            Close();
        }

        private void pictureuser_Click(object sender, EventArgs e)
        {

        }

        public string pbcbebooktype;
        public int count;
        private void cbebooktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbebooktype.Text == "ไม่เลือกหมวดหมู่")
            {
                Con.Close();
                pbcbebooktype = "";
                populateItems();
            }
            else
            {
                Con.Close();
                pbcbebooktype = cbebooktype.Text;
                count = 0;
                Con.Open();
                flowLayoutPanel1.Controls.Clear();

                //เรียกค่า userid
                MySqlDataAdapter sda2 = new MySqlDataAdapter("select user_id from usertbl where user_name ='" + LoginUserForm.username + "'", Con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                string d2 = dt2.Rows[0][0].ToString();
                userid = Convert.ToInt32(d2);

                //นับจำนวน ebook
                MySqlDataAdapter sda1 = new MySqlDataAdapter("SELECT COUNT(*) FROM borrowtbl WHERE borrowtbl.user_id = " + BookUserForm.userid + "", Con);
                //MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                string d = dt.Rows[0][0].ToString();
                var countebook = Convert.ToInt32(d);
                //EbookUserControl[] Listitems = new EbookUserControl[countebook];


                //แสดงชื่อของ ebook
              
                List<string> ebooknamearry = new List<string>();
                List<string> ebookpicturearry = new List<string>();
                List<int> borrowidarry = new List<int>();
                List<int> ebookidarry = new List<int>();
                List<DateTime> borrowexpirearry = new List<DateTime>();
                //SELECT EbookID FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = 1 ORDER BY EbookID ASC;
                MySqlDataReader reader;
                var cmd = new MySqlCommand("SELECT ebooktbl.EbookName,ebooktbl.EbookPicture,borrowtbl.borrowid,borrowtbl.expired_book,ebooktbl.ebookid FROM ebooktbl INNER JOIN borrowtbl ON ebooktbl.ebookid = borrowtbl.ebook_id WHERE borrowtbl.user_id = " + BookUserForm.userid + " AND ebooktbl.EbookType = '" + pbcbebooktype + "'" + " AND ebooktbl.Ebookname LIKE '" + search + "%'", Con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ebookname = reader.GetString(0);
                    var ebookpicture = reader.GetString(1);
                    var borrowid = reader.GetInt32(2);
                    var borrowexpire = reader.GetDateTime(3);
                    var ebookid = reader.GetInt32(4);
                    ebooknamearry.Add(ebookname);
                    ebookpicturearry.Add(ebookpicture);
                    borrowidarry.Add(borrowid);
                    borrowexpirearry.Add(borrowexpire);
                    ebookidarry.Add(ebookid);
                    count++;
                }

                EbookUserControl[] Listitems = new EbookUserControl[count];

                int[] ebookarray;
                ebookarray = ebookidarry.ToArray();
                BorrowUserForm.ebookiduser = ebookarray;

                for (int i = 0; i < Listitems.Length; i++)
                {
                    Graphics g = Graphics.FromHwnd(Handle);
                    Listitems[i] = new EbookUserControl();
                    Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                    Listitems[i].ebookname = ebooknamearry[i];
                    Listitems[i].ebookid = i;
                    Listitems[i].borrowid = borrowidarry[i];
                    Listitems[i].dateebook = borrowexpirearry[i];
                    flowLayoutPanel1.Controls.Add(Listitems[i]);
                }
                Con.Close();
            }

        }
        private void combobox_ebooktype()
        {
            Con.Open();
            List<string> ebooktypearry = new List<string>();
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT DISTINCT EbookType FROM ebooktbl;", Con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ebooktype = reader.GetString(0);
                ebooktypearry.Add(ebooktype);
            }
            //combobox
            string[] ebooktypecb = ebooktypearry.ToArray();
            cbebooktype.Items.AddRange(ebooktypecb);
            Con.Close();
        }

        public string search;
        private void btsearch_Click(object sender, EventArgs e)
        {
            search = txtsearch.Text;
            Con.Close();
            populateItems();
        }
    }
}
