namespace E_BOOK_LIBRARY_PROJECT
{
    partial class RegisterUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtusertype = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtrealname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btbregister = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtusername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btblogin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btaddadminpic = new System.Windows.Forms.Button();
            this.imagetext = new System.Windows.Forms.TextBox();
            this.btuserpic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusertype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btuserpic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.imagetext);
            this.panel1.Controls.Add(this.btaddadminpic);
            this.panel1.Controls.Add(this.btuserpic);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtusertype);
            this.panel1.Controls.Add(this.txtrealname);
            this.panel1.Controls.Add(this.btbregister);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtpassword);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(331, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 405);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(66, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "สถานะ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(97, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "ชื่อ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(33, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username";
            // 
            // txtusertype
            // 
            this.txtusertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtusertype.DropDownWidth = 226;
            this.txtusertype.Items.AddRange(new object[] {
            "นักศึกษา",
            "อาจารย์"});
            this.txtusertype.Location = new System.Drawing.Point(142, 273);
            this.txtusertype.Name = "txtusertype";
            this.txtusertype.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.txtusertype.Size = new System.Drawing.Size(242, 50);
            this.txtusertype.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtusertype.StateActive.ComboBox.Border.Rounding = 25;
            this.txtusertype.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtusertype.TabIndex = 4;
            this.txtusertype.Tag = "";
            // 
            // txtrealname
            // 
            this.txtrealname.Location = new System.Drawing.Point(142, 214);
            this.txtrealname.Name = "txtrealname";
            this.txtrealname.Size = new System.Drawing.Size(242, 52);
            this.txtrealname.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtrealname.StateCommon.Border.Rounding = 25;
            this.txtrealname.StateCommon.Content.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrealname.TabIndex = 6;
            // 
            // btbregister
            // 
            this.btbregister.Location = new System.Drawing.Point(217, 332);
            this.btbregister.Name = "btbregister";
            this.btbregister.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btbregister.Size = new System.Drawing.Size(92, 44);
            this.btbregister.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btbregister.StateCommon.Border.Rounding = 18;
            this.btbregister.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btbregister.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btbregister.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbregister.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateDisabled.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btbregister.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btbregister.StateNormal.Border.Rounding = 18;
            this.btbregister.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbregister.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btbregister.StatePressed.Border.Rounding = 18;
            this.btbregister.StatePressed.Border.Width = 1;
            this.btbregister.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbregister.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btbregister.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btbregister.StateTracking.Border.Rounding = 18;
            this.btbregister.TabIndex = 5;
            this.btbregister.Values.Text = "Register";
            this.btbregister.Click += new System.EventHandler(this.btbregister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(101, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "สมัครสมาชิก";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(142, 155);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(242, 52);
            this.txtpassword.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtpassword.StateCommon.Border.Rounding = 25;
            this.txtpassword.StateCommon.Content.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.TabIndex = 1;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(142, 96);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(242, 52);
            this.txtusername.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtusername.StateCommon.Border.Rounding = 25;
            this.txtusername.StateCommon.Content.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.TabIndex = 0;
            // 
            // btblogin
            // 
            this.btblogin.Location = new System.Drawing.Point(12, 9);
            this.btblogin.Name = "btblogin";
            this.btblogin.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btblogin.Size = new System.Drawing.Size(77, 42);
            this.btblogin.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btblogin.StateCommon.Border.Rounding = 18;
            this.btblogin.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btblogin.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btblogin.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btblogin.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateDisabled.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btblogin.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btblogin.StateNormal.Border.Rounding = 18;
            this.btblogin.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btblogin.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btblogin.StatePressed.Border.Rounding = 18;
            this.btblogin.StatePressed.Border.Width = 1;
            this.btblogin.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btblogin.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btblogin.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btblogin.StateTracking.Border.Rounding = 18;
            this.btblogin.TabIndex = 3;
            this.btblogin.Values.Text = "back";
            this.btblogin.Click += new System.EventHandler(this.btblogin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(16, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 46);
            this.label6.TabIndex = 12;
            this.label6.Text = "ระบบยืม-คืนหนังสืออีบุ๊ค";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::E_BOOK_LIBRARY_PROJECT.Properties.Resources.logo_atc;
            this.pictureBox1.Location = new System.Drawing.Point(63, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btaddadminpic
            // 
            this.btaddadminpic.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.btaddadminpic.Location = new System.Drawing.Point(435, 280);
            this.btaddadminpic.Name = "btaddadminpic";
            this.btaddadminpic.Size = new System.Drawing.Size(86, 32);
            this.btaddadminpic.TabIndex = 29;
            this.btaddadminpic.Text = "เลือกรูปภาพ";
            this.btaddadminpic.UseVisualStyleBackColor = true;
            this.btaddadminpic.Click += new System.EventHandler(this.btaddadminpic_Click);
            // 
            // imagetext
            // 
            this.imagetext.Location = new System.Drawing.Point(410, 64);
            this.imagetext.Name = "imagetext";
            this.imagetext.Size = new System.Drawing.Size(68, 20);
            this.imagetext.TabIndex = 30;
            this.imagetext.Visible = false;
            // 
            // btuserpic
            // 
            this.btuserpic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(85)))), ((int)(((byte)(186)))));
            this.btuserpic.Location = new System.Drawing.Point(410, 96);
            this.btuserpic.Name = "btuserpic";
            this.btuserpic.Size = new System.Drawing.Size(139, 178);
            this.btuserpic.TabIndex = 28;
            this.btuserpic.TabStop = false;
            // 
            // RegisterUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(909, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btblogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 18;
            this.Text = "LoginUserForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusertype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btuserpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtusername;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtpassword;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btblogin;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btbregister;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtrealname;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtusertype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btaddadminpic;
        private System.Windows.Forms.TextBox imagetext;
        private System.Windows.Forms.PictureBox btuserpic;
    }
}