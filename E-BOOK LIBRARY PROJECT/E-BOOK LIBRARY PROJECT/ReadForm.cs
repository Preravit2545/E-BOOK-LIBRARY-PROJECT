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

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void btmadmin_Click(object sender, EventArgs e)
        {
            AdminMAdminForm AMAFORM = new AdminMAdminForm();
            AMAFORM.Show();
            Hide();
        }

        private void btmbook_Click(object sender, EventArgs e)
        {
            AdminMBookForm adminmbook = new AdminMBookForm();
            adminmbook.Show();
            Hide();
        }

        private void btdashboard_Click(object sender, EventArgs e)
        {
            AdminDashboardForm ADFFORM = new AdminDashboardForm();
            ADFFORM.Show();
            Hide();
        }
        public string ePDF { get; set; }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            axAcroPDF1.LoadFile(Application.StartupPath + @"\EbookPDF\" + ePDF);
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}
