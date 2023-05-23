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
            set { _dateebook = value; lbldateebook.Text = value; }
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
            Con.Close();
        }

        private void btread_Click(object sender, EventArgs e)
        {
            Con.Open();
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            string d = dt.Rows[0][0].ToString();
            var countebook = Convert.ToInt32(d);
            EbookUserControl[] Listitems = new EbookUserControl[countebook];

            List<string> ebooknamearry = new List<string>();
            List<string> ebookpdfarry = new List<string>();
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT * FROM ebooktbl", Con);
            reader = cmd.ExecuteReader();
            
            //เก็บค่าชื่อและชื่อไฟล์ pdf
            while (reader.Read())
            {
                var ebookname = reader.GetString(1);
                var ebookpdf = reader.GetString(5);
                ebooknamearry.Add(ebookname);
                ebookpdfarry.Add(ebookpdf);
            }

            //อ่านอีบุ๊ค
            for (int i = 0; i < Listitems.Length; i++)
            {
                if (lblebookname.Text == ebooknamearry[i])
                {
                    ReadForm rf = new ReadForm();
                    rf.ePDF = ebookpdfarry[i];
                    rf.ShowDialog();
                }
            }
            Con.Close();
        }

    }
}
