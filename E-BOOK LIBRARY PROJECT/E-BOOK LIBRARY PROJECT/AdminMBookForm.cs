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

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class AdminMBookForm : KryptonForm
    {
        public AdminMBookForm()
        {
            InitializeComponent();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void btmbook_Click(object sender, EventArgs e)
        {
            AdminMBookForm adminmbook = new AdminMBookForm();
            adminmbook.Show();
            Hide();
        }

        private void btmadmin_Click(object sender, EventArgs e)
        {
            AdminMAdminForm AMAFORM = new AdminMAdminForm();
            AMAFORM.Show();
            Hide();
        }

        private void btdashboard_Click(object sender, EventArgs e)
        {
            AdminDashboardForm ADFFORM = new AdminDashboardForm();
            ADFFORM.Show();
            Hide();
        }
    }
}
