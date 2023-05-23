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
    public partial class LoginAdminForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        MySqlDataAdapter da;
        DataTable table;

        public LoginAdminForm()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '•';
        }

        private void txtpassword_Click(object sender, EventArgs e)
        {
        }

        private void txtusername_Click(object sender, EventArgs e)
        {
            txtusername.Focus();
        }

        private void btuserform_Click(object sender, EventArgs e)
        {
            LoginUserForm UserForm = new LoginUserForm();
            UserForm.Show();
            Hide();
        }

        public static string useradmin;
        public static string adminimg;
        public void dataAdapterLogin(string query)
        {
            Con.Open();
            da = new MySqlDataAdapter(query, Con);
            table = new DataTable();
            da.Fill(table);

            //เก็บค่าdbรูป admin
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT AdminPicture FROM admintbl WHERE adminuser = '" + txtusername.Text + "'", Con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var adminimage = reader.GetString(0);
                adminimg = adminimage;

            }



            if (table.Rows.Count > 0)
            {
                this.Hide();
                AdminMAdminForm ama = new AdminMAdminForm();
                AdminMUserForm amu = new AdminMUserForm();
                useradmin = txtusername.Text;
                amu.Show();
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน");
            }
            Con.Close();
        }

        

        private void btblogin_Click(object sender, EventArgs e)
        {
            string login = "SELECT * FROM admintbl WHERE adminuser = '" + txtusername.Text + "' AND adminpass = '" + txtpassword.Text + "';";
            dataAdapterLogin(login);
        }

        private void btquit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
