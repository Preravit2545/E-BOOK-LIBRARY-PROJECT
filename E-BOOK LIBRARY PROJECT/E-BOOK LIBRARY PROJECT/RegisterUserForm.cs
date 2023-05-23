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
using System.IO;
using MySql.Data.MySqlClient;

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class RegisterUserForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        public RegisterUserForm()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '•';
        }

        private void btblogin_Click(object sender, EventArgs e)
        {
            LoginUserForm LoginForm = new LoginUserForm();
            LoginForm.Show();
            Hide();
        }

        private void btbregister_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "" || txtrealname.Text == "" || txtusertype.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                Con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into userTbl (user_name,user_pass,user_type,user_realname,user_picture) values('" + txtusername.Text + "','" + txtpassword.Text + "','" + txtusertype.Text + "','" + txtrealname.Text + "','" + Path.GetFileName(btuserpic.ImageLocation) + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("สมัครสมาชิคสำเร็จ");
                LoginUserForm LoginForm = new LoginUserForm();
                LoginForm.Show();
                Hide();
                Con.Close();
            }
            File.Copy(imagetext.Text, Application.StartupPath + @"\UserImg\" + Path.GetFileName(btuserpic.ImageLocation));
        }

        private void btaddadminpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                imagetext.Text = openfd.FileName;
                btuserpic.Image = new Bitmap(openfd.FileName);
                btuserpic.ImageLocation = openfd.FileName;
                btuserpic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
