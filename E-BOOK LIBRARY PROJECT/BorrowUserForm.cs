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
    public partial class BorrowUserForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        public BorrowUserForm()
        {
            InitializeComponent();
        }

        
        private void BorrowUserForm_Load(object sender, EventArgs e)
        {
            populateItems();
            combobox_ebooktype();
            lblname.Text = "ยินดีต้อนรับ\n" + LoginUserForm.username;
            lblcountborrow.Text = "จำนวนการยืม : " + LoginUserForm.userborrowcount;
            if(LoginUserForm.userimg == "")
            {

            }
            else
            {
                pictureuser.Image = Image.FromFile(Application.StartupPath + @"\UserImg\" + LoginUserForm.userimg, true);
            }
        }
        
        public static Int32[] ebookiduser { get; set; }

        public void populateItems()
        {
            if (ebookiduser.Length == 0)
            {
                Con.Open();
                flowLayoutPanel1.Controls.Clear();

                //นับจำนวน ebook
                MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl WHERE ebooktbl.Ebookname LIKE '" + search + "%'" + " AND ebooktype LIKE '" + pbcbebooktype + "%'", Con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                string d = dt.Rows[0][0].ToString();
                var countebook = Convert.ToInt32(d);

                BorrowUserControl[] Listitems = new BorrowUserControl[countebook];

                //แสดงชื่อของ ebook
                List<string> ebookidarry = new List<string>();
                List<string> ebooknamearry = new List<string>();
                List<string> ebookpicturearry = new List<string>();
                List<string> ebookauthorarry = new List<string>();
                List<string> ebooktypearry = new List<string>();
                MySqlDataReader reader;
                var cmd = new MySqlCommand("SELECT * FROM ebooktbl WHERE ebooktbl.Ebookname LIKE '" + search + "%'" + " AND ebooktype LIKE '" + pbcbebooktype + "%'", Con);
                //var cmd = new MySqlCommand("select * from ebookTbl WHERE EbookID NOT IN (" + String.Join(",", ebookiduser) + ")", Con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ebookid = reader.GetString(0);
                    var ebookname = reader.GetString(1);
                    var ebookauthor = reader.GetString(2);
                    var ebooktype = reader.GetString(3);
                    var ebookpicture = reader.GetString(4);
                    ebooknamearry.Add(ebookname);
                    ebookpicturearry.Add(ebookpicture);
                    ebookauthorarry.Add(ebookauthor);
                    ebooktypearry.Add(ebooktype);
                    ebookidarry.Add(ebookid);
                }

                for (int i = 0; i < Listitems.Length; i++)
                {
                    Graphics g = Graphics.FromHwnd(Handle);
                    Listitems[i] = new BorrowUserControl();
                    Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                    Listitems[i].ebookname = ebooknamearry[i];
                    Listitems[i].ebookauthorBUC = ebookauthorarry[i];
                    Listitems[i].ebooktypeBUC = ebooktypearry[i];
                    Listitems[i].ebookid = ebookidarry[i];
                    Listitems[i].ebookImgBUC = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                    Listitems[i].dateebook = "i";
                    flowLayoutPanel1.Controls.Add(Listitems[i]);
                }

                Con.Close();
            }
            else
            {
                Con.Open();
                flowLayoutPanel1.Controls.Clear();

                //นับจำนวน ebook
                //MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
                MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl WHERE EbookID NOT IN (" + String.Join(",", ebookiduser) + ")" + " AND ebooktbl.Ebookname LIKE '" + search + "%'" + " AND ebooktype LIKE '" + pbcbebooktype + "%'", Con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                string d = dt.Rows[0][0].ToString();
                var countebook = Convert.ToInt32(d);

                BorrowUserControl[] Listitems = new BorrowUserControl[countebook];

                //แสดงชื่อของ ebook
                List<string> ebookidarry = new List<string>();
                List<string> ebooknamearry = new List<string>();
                List<string> ebookpicturearry = new List<string>();
                List<string> ebookauthorarry = new List<string>();
                List<string> ebooktypearry = new List<string>();
                
                MySqlDataReader reader;
                //var cmd = new MySqlCommand("SELECT * FROM ebooktbl", Con);
                var cmd = new MySqlCommand("select * from ebookTbl WHERE EbookID NOT IN (" + String.Join(",", ebookiduser) + ")" + " AND ebooktbl.Ebookname LIKE '" + search + "%'" + " AND ebooktype LIKE '" + pbcbebooktype + "%'", Con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ebookid = reader.GetString(0);
                    var ebookname = reader.GetString(1);
                    var ebookauthor = reader.GetString(2);
                    var ebooktype = reader.GetString(3);
                    var ebookpicture = reader.GetString(4);
                    ebooknamearry.Add(ebookname);
                    ebookpicturearry.Add(ebookpicture);
                    ebookauthorarry.Add(ebookauthor);
                    ebooktypearry.Add(ebooktype);
                    ebookidarry.Add(ebookid);
                }

                

                for (int i = 0; i < Listitems.Length; i++)
                {
                    Graphics g = Graphics.FromHwnd(Handle);
                    Listitems[i] = new BorrowUserControl();
                    Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                    Listitems[i].ebookname = ebooknamearry[i];
                    Listitems[i].ebookauthorBUC = ebookauthorarry[i];
                    Listitems[i].ebooktypeBUC = ebooktypearry[i];
                    Listitems[i].ebookid = ebookidarry[i];
                    Listitems[i].ebookImgBUC = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                    Listitems[i].dateebook = "";
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
        }

            private void btblogin_Click(object sender, EventArgs e)
        {
            BookUserForm bookform = new BookUserForm();
            bookform.Show();
            Close();
        }

        private void btlogout_Click(object sender, EventArgs e)
        {
            LoginUserForm loginform = new LoginUserForm();
            loginform.Show();
            Close();
        }

        private void btbborrowpage_Click(object sender, EventArgs e)
        {
            
        }
        
        public string pbcbebooktype;
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
                if (ebookiduser.Length == 0)
                {
                    Con.Open();
                    flowLayoutPanel1.Controls.Clear();

                    //นับจำนวน ebook
                    MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl WHERE ebooktype = '" + pbcbebooktype + "'", Con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    string d = dt.Rows[0][0].ToString();
                    var countebook = Convert.ToInt32(d);

                    BorrowUserControl[] Listitems = new BorrowUserControl[countebook];

                    //แสดงชื่อของ ebook
                    List<string> ebookidarry = new List<string>();
                    List<string> ebooknamearry = new List<string>();
                    List<string> ebookpicturearry = new List<string>();
                    List<string> ebookauthorarry = new List<string>();
                    List<string> ebooktypearry = new List<string>();
                    MySqlDataReader reader;
                    var cmd = new MySqlCommand("SELECT * FROM ebooktbl WHERE EbookType = '" + pbcbebooktype + "'", Con);
                    //var cmd = new MySqlCommand("select * from ebookTbl WHERE EbookID NOT IN (" + String.Join(",", ebookiduser) + ")", Con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var ebookid = reader.GetString(0);
                        var ebookname = reader.GetString(1);
                        var ebookauthor = reader.GetString(2);
                        var ebooktype = reader.GetString(3);
                        var ebookpicture = reader.GetString(4);
                        ebooknamearry.Add(ebookname);
                        ebookpicturearry.Add(ebookpicture);
                        ebookauthorarry.Add(ebookauthor);
                        ebooktypearry.Add(ebooktype);
                        ebookidarry.Add(ebookid);
                    }

                    for (int i = 0; i < Listitems.Length; i++)
                    {
                        Graphics g = Graphics.FromHwnd(Handle);
                        Listitems[i] = new BorrowUserControl();
                        Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                        Listitems[i].ebookname = ebooknamearry[i];
                        Listitems[i].ebookauthorBUC = ebookauthorarry[i];
                        Listitems[i].ebooktypeBUC = ebooktypearry[i];
                        Listitems[i].ebookid = ebookidarry[i];
                        Listitems[i].ebookImgBUC = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                        Listitems[i].dateebook = "i";
                        flowLayoutPanel1.Controls.Add(Listitems[i]);
                    }

                    Con.Close();
                }
                else
                {
                    Con.Open();
                    flowLayoutPanel1.Controls.Clear();

                    //นับจำนวน ebook
                    //MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
                    MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl WHERE EbookID NOT IN (" + String.Join(",", ebookiduser) + ") AND EbookType = '" + pbcbebooktype + "'" + " AND ebooktbl.Ebookname LIKE '" + search + "%'", Con);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    string d = dt.Rows[0][0].ToString();
                    var countebook = Convert.ToInt32(d);

                    BorrowUserControl[] Listitems = new BorrowUserControl[countebook];

                    //แสดงชื่อของ ebook
                    List<string> ebookidarry = new List<string>();
                    List<string> ebooknamearry = new List<string>();
                    List<string> ebookpicturearry = new List<string>();
                    List<string> ebookauthorarry = new List<string>();
                    List<string> ebooktypearry = new List<string>();

                    MySqlDataReader reader;
                    //var cmd = new MySqlCommand("SELECT * FROM ebooktbl", Con);
                    var cmd = new MySqlCommand("select * from ebookTbl WHERE EbookID NOT IN (" + String.Join(",", ebookiduser) + ") AND EbookType = '" + pbcbebooktype + "'" + " AND ebooktbl.Ebookname LIKE '" + search + "%'", Con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var ebookid = reader.GetString(0);
                        var ebookname = reader.GetString(1);
                        var ebookauthor = reader.GetString(2);
                        var ebooktype = reader.GetString(3);
                        var ebookpicture = reader.GetString(4);
                        ebooknamearry.Add(ebookname);
                        ebookpicturearry.Add(ebookpicture);
                        ebookauthorarry.Add(ebookauthor);
                        ebooktypearry.Add(ebooktype);
                        ebookidarry.Add(ebookid);
                    }



                    for (int i = 0; i < Listitems.Length; i++)
                    {
                        Graphics g = Graphics.FromHwnd(Handle);
                        Listitems[i] = new BorrowUserControl();
                        Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                        Listitems[i].ebookname = ebooknamearry[i];
                        Listitems[i].ebookauthorBUC = ebookauthorarry[i];
                        Listitems[i].ebooktypeBUC = ebooktypearry[i];
                        Listitems[i].ebookid = ebookidarry[i];
                        Listitems[i].ebookImgBUC = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                        Listitems[i].dateebook = "";
                        flowLayoutPanel1.Controls.Add(Listitems[i]);
                    }

                    Con.Close();
                }

            }
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
