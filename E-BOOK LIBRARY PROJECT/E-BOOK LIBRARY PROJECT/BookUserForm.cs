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
            lblname.Text = "ยินดีต้อนรับ\n" + LoginUserForm.username;

        }
        public string username { get; set; }
        private void populateItems()
        {
            Con.Open();
            flowLayoutPanel1.Controls.Clear();
            
            //นับจำนวน ebook
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            string d = dt.Rows[0][0].ToString();
            var countebook = Convert.ToInt32(d);
            EbookUserControl[] Listitems = new EbookUserControl[countebook];

            //แสดงชื่อของ ebook
            List<string> ebooknamearry = new List<string>();
            List<string> ebookpicturearry = new List<string>();
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT * FROM ebooktbl", Con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ebookname = reader.GetString(1);
                var ebookpicture = reader.GetString(4);
                ebooknamearry.Add(ebookname);
                ebookpicturearry.Add(ebookpicture);
            }

            //แสดงรูปภาพ
            var cmd1 = new MySqlCommand("SELECT ebookpicture FROM ebooktbl", Con);

            for (int i = 0; i < Listitems.Length; i++)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Listitems[i] = new EbookUserControl();
                Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i],true);
                Listitems[i].ebookname = ebooknamearry[i];
                Listitems[i].dateebook = "i";
                flowLayoutPanel1.Controls.Add(Listitems[i]);
            }
            Con.Close();
        }

        private void btblogin_Click(object sender, EventArgs e)
        {

        }
    }
}
