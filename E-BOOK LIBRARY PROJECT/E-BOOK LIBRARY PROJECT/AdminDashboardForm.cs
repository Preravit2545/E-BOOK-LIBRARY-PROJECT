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
    public partial class AdminDashboardForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        public AdminDashboardForm()
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

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            Con.Open();
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from userTbl", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            lblcountuser.Text = dt.Rows[0][0].ToString();
            MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from ebookTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            lblcountbook.Text = dt2.Rows[0][0].ToString();
            MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from adminTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            lblcountadmin.Text = dt3.Rows[0][0].ToString();
            Con.Close();
        }
    }
}
