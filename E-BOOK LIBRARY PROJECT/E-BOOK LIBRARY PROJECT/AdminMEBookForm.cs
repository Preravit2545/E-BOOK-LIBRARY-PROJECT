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
    public partial class AdminMEbookForm : KryptonForm
    {
       MySqlConnection Con = new MySqlConnection("host=localhost;user=root;password=;database=ebooklibrary");
        //ถ้าใช้ไม่ได้ให้ก็อบอันนี้ @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Preravit\Documents\ebooklibrary.mdf;Integrated Security=True;Connect Timeout=30"
        //"host=localhost;user=root;password=;database=ebooklibrary"
        public AdminMEbookForm()
        {
            InitializeComponent();
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
        private void kryptonButton4_Click_2(object sender, EventArgs e) //ลบแอดมิน Delete Admin
        {
            if (txtebookid.Text == "")
            {
                MessageBox.Show("กรุณาเลือกรหัสอีบุ๊ค");
            }
            else
            {
                Con.Open();
                string query = "delete from EbookTbl where EbookID = '" + txtebookid.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ลบอีบุ๊คสำเร็จ!");
                Con.Close();
                poppulate();
            }
        }
        public void poppulate() //Data Grid View
        {
            Con.Open();
            string query = "select * from EbookTbl";
            MySqlDataAdapter da = new MySqlDataAdapter(query, Con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds); 
            DGVAdmin.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            if (txtebookid.Text == "" || txtebookname.Text == "" || txtebookauthor.Text == "" || txtebooktype.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                Con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into EbookTbl values('"+ txtebookid.Text +"','"+ txtebookname.Text +"','"+ txtebookauthor.Text +"','" + txtebooktype.Text + "','" + Path.GetFileName(btadminpic.ImageLocation) + "')",Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                Con.Close();
                poppulate();
            }
            File.Copy(imagetext.Text, Application.StartupPath + @"\EbookImg\" + Path.GetFileName(btadminpic.ImageLocation)); //เก็บไฟล์รูปภาพไปตามที่อยู่ @\image\
        }

        private void AdminMAdminForm_Load(object sender, EventArgs e)
        {
            poppulate();
            lbladminname.Text = "ยินดีต้อนรับ\n" + LoginAdminForm.useradmin;

        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (txtebookid.Text == "" || txtebookname.Text == "" || txtebookauthor.Text == "" || txtebooktype.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                Con.Open();
                string query = "update ebooktbl set ebookname='" + txtebookname.Text + "',ebookauthor= '" + txtebookauthor.Text + "' ,ebooktype = '" + txtebooktype.Text + "' where ebookid='" + txtebookid.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("อัพเดตอีบุ๊คสำเร็จ");
                Con.Close();
                poppulate();
            }
        }
        private void DGVAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtebookid.Text = DGVAdmin.SelectedRows[0].Cells[0].Value.ToString();
            txtebookname.Text = DGVAdmin.SelectedRows[0].Cells[1].Value.ToString();
            txtebookauthor.Text = DGVAdmin.SelectedRows[0].Cells[2].Value.ToString();
            txtebooktype.Text = DGVAdmin.SelectedRows[0].Cells[3].Value.ToString();
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
