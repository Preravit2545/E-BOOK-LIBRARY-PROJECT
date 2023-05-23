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

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class Borrowinfo : KryptonForm
    {
 
        public Borrowinfo()
        {
            InitializeComponent();
        }

        public string ebookname { get; set; }
        public string ebookauthor { get; set; }
        public string ebooktype { get; set; }
        public Image ebookImg { get; set; }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            ebookpicture.SizeMode = PictureBoxSizeMode.StretchImage;
            ebookpicture.Image = ebookImg;
            lblebookname.Text = ebookname;
            lblebookauthor.Text = ebookauthor;
            lblebooktype.Text = ebooktype;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
        }
    }
}
