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
        public static string username;
       
        public void dataAdapterLogin(string query)
        {
            Con.Open();
            da = new MySqlDataAdapter(query, Con);
            table = new DataTable();
            da.Fill(table);

            //เก็บค่าdbรูป user
            MySqlDataReader reader;
            var cmd = new MySqlCommand("SELECT User_picture,user_borrowcount FROM usertbl WHERE user_name = '" + txtusername.Text + "'", Con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var userimage = reader.GetString(0);
                var userborrowcount1 = reader.GetInt32(1);
                userimg = userimage;
                userborrowcount = userborrowcount1;
            }


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

        public static Int32 userborrowcount;
        public static string userimg;
        private void btblogin_Click(object sender, EventArgs e)
        {
            string login = "SELECT * FROM usertbl WHERE user_name = '" + txtusername.Text + "' AND user_pass = '" + txtpassword.Text + "';";
            dataAdapterLogin(login);
        }

        
        private void LoginUserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btquit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
