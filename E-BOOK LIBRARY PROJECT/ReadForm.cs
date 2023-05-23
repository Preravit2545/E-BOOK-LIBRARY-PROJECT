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
    public partial class ReadForm : KryptonForm
    {
 
        public ReadForm()
        {
            InitializeComponent();
        }
        public string ePDF { get; set; }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            axAcroPDF1.LoadFile(Application.StartupPath + @"\EbookPDF\" + ePDF);
            //axAcroPDF1.LoadFile(Application.StartupPath + @"\EbookPDF\" + "AI-Government-Framework.pdf");

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}
