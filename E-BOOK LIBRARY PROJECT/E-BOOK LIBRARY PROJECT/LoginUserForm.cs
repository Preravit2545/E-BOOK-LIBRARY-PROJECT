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
using ComponentFactory.Krypton.Toolkit;

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class LoginUserForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        MySqlDataAdapter da;
        DataTable table;

        public LoginUserForm()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '•';
        }
   
        private void txtusername_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void txtusername_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_Click(object sender, EventArgs e)
        {
            txtpassword.Focus();
        }

        private void txtusername_Click(object sender, EventArgs e)
        {
            txtusername.Focus();
        }

        private void btbregister_Click(object sender, EventArgs e)
        {
            RegisterUserForm RegForm = new RegisterUserForm();
            RegForm.Show();
            Hide();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            LoginAdminForm AdminForm = new LoginAdminForm();
            AdminForm.Show();
            Hide();
        }
        public void dataAdapterLogin(string query)
        {
            Con.Open();
            da = new MySqlDataAdapter(query, Con);
            table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                BookUserForm buf = new BookUserForm();
                username = txtusername.Text;
                buf.Show();
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน");
            }
            Con.Close();
        }

        private void btblogin_Click(object sender, EventArgs e)
        {
            string login = "SELECT * FROM usertbl WHERE user_name = '" + txtusername.Text + "' AND user_pass = '" + txtpassword.Text + "';";
            dataAdapterLogin(login);
        }

        public static string username;
        private void LoginUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
