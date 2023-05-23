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
        


        private void kryptonButton4_Click_2(object sender, EventArgs e) //ลบแอดมิน Delete Admin
        {
            if (txtadminid.Text == "")
            {
                MessageBox.Show("กรุณาเลือกรหัสแอดมิน");
            }
            else
            {
                Con.Open();
                string query = "delete from AdminTbl where AdminID = '" + txtadminid.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ลบแอดมินสำเร็จ!");
                Con.Close();
                poppulate();
            }
        }
        public void poppulate() //Data Grid View
        {
            Con.Open();
            string query = "select * from AdminTbl";
            MySqlDataAdapter da = new MySqlDataAdapter(query, Con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVAdmin.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            if (txtadminid.Text == "" || txtadminuser.Text == "" || txtadminpass.Text == "" || txtadminname.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                Con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into AdminTbl values('" + txtadminid.Text + "','" + txtadminuser.Text + "','" + txtadminpass.Text + "','" + txtadminname.Text + "','" + Path.GetFileName(btadminpic.ImageLocation) + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                Con.Close();
                poppulate();
            }
            File.Copy(imagetext.Text, Application.StartupPath + @"\AdminImg\" + Path.GetFileName(btadminpic.ImageLocation)); //เก็บไฟล์รูปภาพไปตามที่อยู่ @\image\
        }

        private void AdminMAdminForm_Load(object sender, EventArgs e)
        {
            poppulate();
            lbladminname.Text = "ยินดีต้อนรับ\n"  + LoginAdminForm.useradmin;
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (txtadminid.Text == "" || txtadminuser.Text == "" || txtadminpass.Text == "" || txtadminname.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                Con.Open();
                string query = "update admintbl set adminuser='" + txtadminuser.Text + "',adminpass= '" + txtadminpass.Text + "' ,adminname = '" + txtadminname.Text + "' where adminid='" + txtadminid.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("อัพเดตแอดมินสำเร็จ");
                Con.Close();
                poppulate();
            }
        }

        private void DGVAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            txtadminid.Text = DGVAdmin.SelectedRows[0].Cells[0].Value.ToString();
            txtadminuser.Text = DGVAdmin.SelectedRows[0].Cells[1].Value.ToString();
            txtadminpass.Text = DGVAdmin.SelectedRows[0].Cells[2].Value.ToString();
            txtadminname.Text = DGVAdmin.SelectedRows[0].Cells[3].Value.ToString();
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
    }
}
