using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

namespace E_BOOK_LIBRARY_PROJECT
{
    public partial class AdminMAdminForm : KryptonForm
    {
        MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        //ถ้าใช้ไม่ได้ให้ก็อบอันนี้ @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Preravit\Documents\ebooklibrary.mdf;Integrated Security=True;Connect Timeout=30"
        //"host=localhost;user=root;password=;database=ebooklibrary"
        public AdminMAdminForm()
        {
            InitializeComponent();
        }
        private void btmbook_Click(object sender, EventArgs e)
        {
            AdminMEbookForm adminmbook = new AdminMEbookForm();
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

        public void cleartext()
        {
            txtadminid.Text = null;
            txtadminuser.Text = null;
            txtadminpass.Text = null;
            btadminpic.Image = null;
            imagetext.Text = null;
            txtadminid.Focus();
        }

        //ลบแอดมิน
        private void kryptonButton4_Click_2(object sender, EventArgs e) //ลบแอดมิน Delete Admin
        {
            if (txtadminid.Text == "")
            {
                MessageBox.Show("กรุณาเลือกรหัสแอดมิน");
            }
            else
            {
                if (MessageBox.Show("คุณต้องการลบแอดมินหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    string query = "delete from AdminTbl where AdminID = '" + txtadminid.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ลบแอดมินสำเร็จ!");
                    Con.Close();
                    poppulate();
                    cleartext();
                }
                else
                {

                }
            }
        }

        public void poppulate() //Data Grid View
        {
            Con.Open();
            string query = "select adminid,adminuser,adminpicture from AdminTbl";
            MySqlDataAdapter da = new MySqlDataAdapter(query, Con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVAdmin.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            if (txtadminid.Text == "" || txtadminuser.Text == "" || txtadminpass.Text == "" || imagetext.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                if (MessageBox.Show("คุณต้องการเพิ่มแอดมินหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into AdminTbl values('" + txtadminid.Text + "','" + txtadminuser.Text + "','" + txtadminpass.Text + "','" + Path.GetFileName(btadminpic.ImageLocation) + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                    Con.Close();
                    File.Copy(imagetext.Text, Application.StartupPath + @"\AdminImg\" + Path.GetFileName(btadminpic.ImageLocation)); //เก็บไฟล์รูปภาพไปตามที่อยู่ @\image\
                    btadminpic.Image = null;
                    txtadminid.Clear();
                    txtadminuser.Clear();
                    txtadminpass.Clear();
                    poppulate();
                    cleartext();
                }
                else
                {

                }
            }
            
        }

        private void AdminMAdminForm_Load(object sender, EventArgs e)
        {
            poppulate();
            lbladminname.Text = "ยินดีต้อนรับ\n"  + LoginAdminForm.useradmin;
            pictureadmin.Image = Image.FromFile(Application.StartupPath + @"\AdminImg\" + LoginAdminForm.adminimg, true);
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (txtadminid.Text == "" || txtadminuser.Text == "" || txtadminpass.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                if (MessageBox.Show("คุณต้องการแก้ไขแอดมินหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    string query = "update admintbl set adminuser='" + txtadminuser.Text + "',adminpass= '" + txtadminpass.Text + "' where adminid='" + txtadminid.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("อัพเดตแอดมินสำเร็จ");
                    Con.Close();
                    poppulate();
                    cleartext();
                }
                else
                {

                }
            }
        }

        private void DGVAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //OpenFileDialog openfd = new OpenFileDialog();
            //openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            txtadminid.Text = DGVAdmin.SelectedRows[0].Cells[0].Value.ToString();
            txtadminuser.Text = DGVAdmin.SelectedRows[0].Cells[1].Value.ToString();
            txtadminpass.Text = DGVAdmin.SelectedRows[0].Cells[2].Value.ToString();
            imagetext.Text = DGVAdmin.SelectedRows[0].Cells[3].Value.ToString();
            btadminpic.Image = Image.FromFile(Application.StartupPath + @"\AdminImg\" + imagetext.Text, true);
        }

        private void DGVAdmin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btadminpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if(openfd.ShowDialog() == DialogResult.OK)
            {
                imagetext.Text = openfd.FileName;
                btadminpic.Image = new Bitmap(openfd.FileName);
                btadminpic.ImageLocation = openfd.FileName;
                btadminpic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btaddadminpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                imagetext.Text = openfd.FileName;
                btadminpic.Image = new Bitmap(openfd.FileName);
                btadminpic.ImageLocation = openfd.FileName;
                btadminpic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btlogout_Click(object sender, EventArgs e)
        {
            LoginAdminForm loginadminform = new LoginAdminForm();
            loginadminform.Show();
            Hide();
        }

        private void btmuser_Click(object sender, EventArgs e)
        {
            AdminMUserForm aus = new AdminMUserForm();
            aus.Show();
            Hide();
        }
    }
}
