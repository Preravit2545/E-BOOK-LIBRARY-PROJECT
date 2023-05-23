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
        }
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
            BorrowUserControl[] Listitems = new BorrowUserControl[countebook];

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
                Listitems[i] = new BorrowUserControl();
                Listitems[i].ebookpic = Image.FromFile(Application.StartupPath + @"\EbookImg\" + ebookpicturearry[i], true);
                Listitems[i].ebookname = ebooknamearry[i];
                Listitems[i].dateebook = "i";
                flowLayoutPanel1.Controls.Add(Listitems[i]);
            }
            Con.Close();
        }
    }
}
