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
    public partial class AdminMUserForm : KryptonForm
    {
       MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        //ถ้าใช้ไม่ได้ให้ก็อบอันนี้ @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Preravit\Documents\ebooklibrary.mdf;Integrated Security=True;Connect Timeout=30"
        //"host=localhost;user=root;password=;database=ebooklibrary"
        public AdminMUserForm()
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
            if (txtuserid.Text == "")
            {
                MessageBox.Show("กรุณาเลือกรหัสผู้ใช้");
            }
            else
            {
                if (MessageBox.Show("คุณต้องการลบผู้ใช้หรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    string query = "delete from userTbl where user_ID = '" + txtuserid.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ลบผู้ใช้สำเร็จ!");
                    Con.Close();
                    poppulate();
                    cleartext();
                }
                else { }
            }
        }
        public void cleartext()
        {
            txtuserid.Text = null;
            txtusername.Text = null;
            txtborrow.Text = null;
            txtusertype.Text = null;

            btadminpic.Image = null;
            imagetext.Text = null;
            txtuserid.Focus();
        }

        public void poppulate() //Data Grid View
        {
            Con.Open();
            string query = "select user_id,user_name,user_type,user_borrowcount,user_picture from Usertbl";
            MySqlDataAdapter da = new MySqlDataAdapter(query, Con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds); 
            DGVAdmin.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            if (txtuserid.Text == "" || txtusername.Text == "" || txtusertype.Text == "" || txtborrow.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                if (MessageBox.Show("คุณต้องการเพิ่มอีบุ๊คหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    /*Con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into EbookTbl values('" + txtebookid.Text + "','" + txtebookname.Text + "','" + txtebookauthor.Text + "','" + txtebooktype.Text + "','" + Path.GetFileName(btadminpic.ImageLocation) + "','" + Path.GetFileName(txtpdf.Text) + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                    Con.Close();
                    File.Copy(imagetext.Text, Application.StartupPath + @"\EbookImg\" + Path.GetFileName(btadminpic.ImageLocation)); //เก็บไฟล์รูปภาพไปตามที่อยู่ @\image\
                    File.Copy(txtpdf.Text, Application.StartupPath + @"\EbookPDF\" + Path.GetFileName(txtpdf.Text));
                    poppulate();
                    cleartext();*/
                }
                else { }
            }
            
        }

        private void AdminMAdminForm_Load(object sender, EventArgs e)
        {
            poppulate();
            lbladminname.Text = "ยินดีต้อนรับ\n" + LoginAdminForm.useradmin;
            pictureadmin.Image = Image.FromFile(Application.StartupPath + @"\AdminImg\" + LoginAdminForm.adminimg, true);

        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (txtuserid.Text == "" || txtusername.Text == "" || txtusertype.Text == "" || txtborrow.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                if (MessageBox.Show("คุณต้องการอัพเดตผู้ใช้หรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    string query = "update usertbl set user_name='" + txtusername.Text + "',user_type= '" + txtusertype.Text + "' ,user_borrowcount = '" + txtborrow.Text + "' where ebookid='" + txtuserid.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("อัพเดตผู้ใช้สำเร็จ");
                    Con.Close();
                    poppulate();
                    cleartext();
                }
                else { }
                }
            }
        private void DGVAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtuserid.Text = DGVAdmin.SelectedRows[0].Cells[0].Value.ToString();
            txtusername.Text = DGVAdmin.SelectedRows[0].Cells[1].Value.ToString();
            txtusertype.Text = DGVAdmin.SelectedRows[0].Cells[2].Value.ToString();
            txtborrow.Text = DGVAdmin.SelectedRows[0].Cells[3].Value.ToString();
            imagetext.Text = DGVAdmin.SelectedRows[0].Cells[4].Value.ToString();
            //txtpdf.Text = DGVAdmin.SelectedRows[0].Cells[5].Value.ToString();
            btadminpic.Image = Image.FromFile(Application.StartupPath + @"\userimg\" + imagetext.Text, true);
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

        private void btaddpdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Pdf Files|*.pdf";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                //txtpdf.Text = openfd.FileName;
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
