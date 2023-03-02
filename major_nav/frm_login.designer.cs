namespace major_nav
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.lbl_name = new System.Windows.Forms.Label();
            this.pnl_line = new System.Windows.Forms.Panel();
            this.pnl_line2 = new System.Windows.Forms.Panel();
            this.btn_register = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.lbl_forgotPassword = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_signup_email = new System.Windows.Forms.TextBox();
            this.cb_EULA = new System.Windows.Forms.CheckBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_signup_username = new System.Windows.Forms.TextBox();
            this.txt_signup_password = new System.Windows.Forms.TextBox();
            this.pb_register_icon_Email = new System.Windows.Forms.PictureBox();
            this.pb_register_icon_Pass = new System.Windows.Forms.PictureBox();
            this.pb_register_icon_User = new System.Windows.Forms.PictureBox();
            this.pb_login_lock = new System.Windows.Forms.PictureBox();
            this.pb_login_user = new System.Windows.Forms.PictureBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.btn_register_passwordShow = new System.Windows.Forms.Button();
            this.btn_login_passwordShow = new System.Windows.Forms.Button();
            this.btn_logIn = new System.Windows.Forms.Button();
            this.btn_register_generatePass = new System.Windows.Forms.Button();
            this.dgv_user = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_help = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_Pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login_lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbl_name.Location = new System.Drawing.Point(108, 170);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(129, 39);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "LOG IN";
            // 
            // pnl_line
            // 
            this.pnl_line.BackColor = System.Drawing.Color.DarkViolet;
            this.pnl_line.Location = new System.Drawing.Point(68, 253);
            this.pnl_line.Name = "pnl_line";
            this.pnl_line.Size = new System.Drawing.Size(236, 1);
            this.pnl_line.TabIndex = 3;
            // 
            // pnl_line2
            // 
            this.pnl_line2.BackColor = System.Drawing.Color.Indigo;
            this.pnl_line2.Location = new System.Drawing.Point(68, 314);
            this.pnl_line2.Name = "pnl_line2";
            this.pnl_line2.Size = new System.Drawing.Size(236, 1);
            this.pnl_line2.TabIndex = 3;
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.Navy;
            this.btn_register.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_register.BackgroundImage")));
            this.btn_register.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_register.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_register.FlatAppearance.BorderSize = 0;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.Color.White;
            this.btn_register.Location = new System.Drawing.Point(427, 374);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(236, 33);
            this.btn_register.TabIndex = 7;
            this.btn_register.Text = "REGISTER";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // txt_username
            // 
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_username.Location = new System.Drawing.Point(102, 226);
            this.txt_username.MaxLength = 9;
            this.txt_username.Name = "txt_username";
            this.txt_username.ShortcutsEnabled = false;
            this.txt_username.Size = new System.Drawing.Size(204, 19);
            this.txt_username.TabIndex = 1;
            this.txt_username.Text = "Username";
            this.txt_username.Click += new System.EventHandler(this.txt_username_Click);
            this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_username_KeyPress);
            this.txt_username.Leave += new System.EventHandler(this.txt_username_Leave);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.SystemColors.Window;
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Indigo;
            this.txt_password.Location = new System.Drawing.Point(102, 285);
            this.txt_password.MaxLength = 12;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(204, 19);
            this.txt_password.TabIndex = 2;
            this.txt_password.Text = "Password";
            this.txt_password.Click += new System.EventHandler(this.txt_password_Click_1);
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave_1);
            // 
            // lbl_forgotPassword
            // 
            this.lbl_forgotPassword.AutoSize = true;
            this.lbl_forgotPassword.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_forgotPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_forgotPassword.ForeColor = System.Drawing.Color.Navy;
            this.lbl_forgotPassword.Location = new System.Drawing.Point(120, 378);
            this.lbl_forgotPassword.Name = "lbl_forgotPassword";
            this.lbl_forgotPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_forgotPassword.Size = new System.Drawing.Size(136, 16);
            this.lbl_forgotPassword.TabIndex = 5;
            this.lbl_forgotPassword.Text = "FORGOT PASSWORD";
            this.lbl_forgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_forgotPassword.Click += new System.EventHandler(this.lbl_forgotPassword_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.DarkViolet;
            this.panel3.Location = new System.Drawing.Point(427, 321);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 1);
            this.panel3.TabIndex = 3;
            // 
            // txt_signup_email
            // 
            this.txt_signup_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_signup_email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_signup_email.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_signup_email.Location = new System.Drawing.Point(461, 294);
            this.txt_signup_email.MaxLength = 25;
            this.txt_signup_email.Name = "txt_signup_email";
            this.txt_signup_email.ShortcutsEnabled = false;
            this.txt_signup_email.Size = new System.Drawing.Size(204, 19);
            this.txt_signup_email.TabIndex = 6;
            this.txt_signup_email.Text = "Email";
            this.txt_signup_email.Click += new System.EventHandler(this.txt_signup_email_Click);
            this.txt_signup_email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_signup_email_KeyPress);
            this.txt_signup_email.Leave += new System.EventHandler(this.txt_signup_email_Leave);
            // 
            // cb_EULA
            // 
            this.cb_EULA.AutoSize = true;
            this.cb_EULA.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cb_EULA.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_EULA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cb_EULA.Location = new System.Drawing.Point(497, 342);
            this.cb_EULA.Name = "cb_EULA";
            this.cb_EULA.Size = new System.Drawing.Size(130, 21);
            this.cb_EULA.TabIndex = 8;
            this.cb_EULA.TabStop = false;
            this.cb_EULA.Text = "I AGREE TO EULA";
            this.cb_EULA.UseVisualStyleBackColor = true;
            this.cb_EULA.Click += new System.EventHandler(this.cb_EULA_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_exit.Location = new System.Drawing.Point(699, 56);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(63, 23);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.TabStop = false;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(348, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "CREATE YOUR ACCOUNT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkViolet;
            this.panel1.Location = new System.Drawing.Point(431, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 1);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkViolet;
            this.panel2.Location = new System.Drawing.Point(429, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 1);
            this.panel2.TabIndex = 3;
            // 
            // txt_signup_username
            // 
            this.txt_signup_username.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_signup_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_signup_username.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_signup_username.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_signup_username.Location = new System.Drawing.Point(465, 162);
            this.txt_signup_username.MaxLength = 9;
            this.txt_signup_username.Name = "txt_signup_username";
            this.txt_signup_username.ShortcutsEnabled = false;
            this.txt_signup_username.Size = new System.Drawing.Size(204, 19);
            this.txt_signup_username.TabIndex = 4;
            this.txt_signup_username.Text = "Username";
            this.txt_signup_username.Click += new System.EventHandler(this.txt_signup_username_Click);
            this.txt_signup_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_signup_username_KeyPress);
            this.txt_signup_username.Leave += new System.EventHandler(this.text_signup_username_Leave);
            // 
            // txt_signup_password
            // 
            this.txt_signup_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_signup_password.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_signup_password.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_signup_password.Location = new System.Drawing.Point(463, 226);
            this.txt_signup_password.MaxLength = 12;
            this.txt_signup_password.Name = "txt_signup_password";
            this.txt_signup_password.Size = new System.Drawing.Size(204, 19);
            this.txt_signup_password.TabIndex = 5;
            this.txt_signup_password.Text = "Password";
            this.txt_signup_password.Click += new System.EventHandler(this.txt_signup_password_Click);
            this.txt_signup_password.TextChanged += new System.EventHandler(this.txt_signup_password_TextChanged);
            this.txt_signup_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_signup_password_KeyPress);
            this.txt_signup_password.Leave += new System.EventHandler(this.txt_signup_password_Leave);
            // 
            // pb_register_icon_Email
            // 
            this.pb_register_icon_Email.BackColor = System.Drawing.Color.Transparent;
            this.pb_register_icon_Email.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_register_icon_Email.Image = ((System.Drawing.Image)(resources.GetObject("pb_register_icon_Email.Image")));
            this.pb_register_icon_Email.Location = new System.Drawing.Point(429, 286);
            this.pb_register_icon_Email.Name = "pb_register_icon_Email";
            this.pb_register_icon_Email.Size = new System.Drawing.Size(28, 33);
            this.pb_register_icon_Email.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_register_icon_Email.TabIndex = 2;
            this.pb_register_icon_Email.TabStop = false;
            // 
            // pb_register_icon_Pass
            // 
            this.pb_register_icon_Pass.BackColor = System.Drawing.Color.Transparent;
            this.pb_register_icon_Pass.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_register_icon_Pass.Image = ((System.Drawing.Image)(resources.GetObject("pb_register_icon_Pass.Image")));
            this.pb_register_icon_Pass.Location = new System.Drawing.Point(431, 218);
            this.pb_register_icon_Pass.Name = "pb_register_icon_Pass";
            this.pb_register_icon_Pass.Size = new System.Drawing.Size(28, 33);
            this.pb_register_icon_Pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_register_icon_Pass.TabIndex = 2;
            this.pb_register_icon_Pass.TabStop = false;
            // 
            // pb_register_icon_User
            // 
            this.pb_register_icon_User.BackColor = System.Drawing.Color.Transparent;
            this.pb_register_icon_User.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_register_icon_User.Image = ((System.Drawing.Image)(resources.GetObject("pb_register_icon_User.Image")));
            this.pb_register_icon_User.Location = new System.Drawing.Point(433, 154);
            this.pb_register_icon_User.Name = "pb_register_icon_User";
            this.pb_register_icon_User.Size = new System.Drawing.Size(28, 33);
            this.pb_register_icon_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_register_icon_User.TabIndex = 2;
            this.pb_register_icon_User.TabStop = false;
            // 
            // pb_login_lock
            // 
            this.pb_login_lock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_login_lock.ErrorImage = null;
            this.pb_login_lock.Image = ((System.Drawing.Image)(resources.GetObject("pb_login_lock.Image")));
            this.pb_login_lock.Location = new System.Drawing.Point(72, 275);
            this.pb_login_lock.Name = "pb_login_lock";
            this.pb_login_lock.Size = new System.Drawing.Size(26, 37);
            this.pb_login_lock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_login_lock.TabIndex = 2;
            this.pb_login_lock.TabStop = false;
            // 
            // pb_login_user
            // 
            this.pb_login_user.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_login_user.Image = ((System.Drawing.Image)(resources.GetObject("pb_login_user.Image")));
            this.pb_login_user.Location = new System.Drawing.Point(70, 218);
            this.pb_login_user.Name = "pb_login_user";
            this.pb_login_user.Size = new System.Drawing.Size(28, 33);
            this.pb_login_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_login_user.TabIndex = 2;
            this.pb_login_user.TabStop = false;
            // 
            // pb_logo
            // 
            this.pb_logo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(125, 78);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(100, 87);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            // 
            // btn_register_passwordShow
            // 
            this.btn_register_passwordShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_register_passwordShow.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_register_passwordShow.FlatAppearance.BorderSize = 0;
            this.btn_register_passwordShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register_passwordShow.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_register_passwordShow.ForeColor = System.Drawing.Color.White;
            this.btn_register_passwordShow.Location = new System.Drawing.Point(679, 226);
            this.btn_register_passwordShow.Name = "btn_register_passwordShow";
            this.btn_register_passwordShow.Size = new System.Drawing.Size(63, 23);
            this.btn_register_passwordShow.TabIndex = 10;
            this.btn_register_passwordShow.TabStop = false;
            this.btn_register_passwordShow.Text = "SHOW";
            this.btn_register_passwordShow.UseVisualStyleBackColor = false;
            this.btn_register_passwordShow.MouseEnter += new System.EventHandler(this.btn_register_passwordShow_MouseEnter);
            this.btn_register_passwordShow.MouseLeave += new System.EventHandler(this.btn_register_passwordShow_MouseLeave);
            // 
            // btn_login_passwordShow
            // 
            this.btn_login_passwordShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_login_passwordShow.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_login_passwordShow.FlatAppearance.BorderSize = 0;
            this.btn_login_passwordShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login_passwordShow.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_login_passwordShow.ForeColor = System.Drawing.Color.White;
            this.btn_login_passwordShow.Location = new System.Drawing.Point(314, 289);
            this.btn_login_passwordShow.Name = "btn_login_passwordShow";
            this.btn_login_passwordShow.Size = new System.Drawing.Size(63, 23);
            this.btn_login_passwordShow.TabIndex = 11;
            this.btn_login_passwordShow.TabStop = false;
            this.btn_login_passwordShow.Text = "SHOW";
            this.btn_login_passwordShow.UseVisualStyleBackColor = false;
            this.btn_login_passwordShow.MouseEnter += new System.EventHandler(this.btn_login_passwordShow_MouseEnter);
            this.btn_login_passwordShow.MouseLeave += new System.EventHandler(this.btn_login_passwordShow_MouseLeave);
            // 
            // btn_logIn
            // 
            this.btn_logIn.BackColor = System.Drawing.Color.Navy;
            this.btn_logIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_logIn.BackgroundImage")));
            this.btn_logIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_logIn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_logIn.FlatAppearance.BorderSize = 0;
            this.btn_logIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logIn.ForeColor = System.Drawing.Color.White;
            this.btn_logIn.Location = new System.Drawing.Point(68, 333);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(236, 33);
            this.btn_logIn.TabIndex = 3;
            this.btn_logIn.Text = "LOG IN";
            this.btn_logIn.UseVisualStyleBackColor = false;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            // 
            // btn_register_generatePass
            // 
            this.btn_register_generatePass.BackColor = System.Drawing.Color.White;
            this.btn_register_generatePass.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_register_generatePass.FlatAppearance.BorderSize = 0;
            this.btn_register_generatePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register_generatePass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_register_generatePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_register_generatePass.Location = new System.Drawing.Point(592, 226);
            this.btn_register_generatePass.Name = "btn_register_generatePass";
            this.btn_register_generatePass.Size = new System.Drawing.Size(87, 23);
            this.btn_register_generatePass.TabIndex = 13;
            this.btn_register_generatePass.TabStop = false;
            this.btn_register_generatePass.Text = "GENERATE";
            this.btn_register_generatePass.UseVisualStyleBackColor = false;
            this.btn_register_generatePass.Click += new System.EventHandler(this.btn_register_generatePass_Click);
            // 
            // dgv_user
            // 
            this.dgv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_user.Location = new System.Drawing.Point(648, 425);
            this.dgv_user.Name = "dgv_user";
            this.dgv_user.Size = new System.Drawing.Size(240, 150);
            this.dgv_user.TabIndex = 14;
            this.dgv_user.VirtualMode = true;
            this.dgv_user.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btn_help);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel4.Location = new System.Drawing.Point(25, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(751, 390);
            this.panel4.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(70, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 20);
            this.button1.TabIndex = 16;
            this.button1.TabStop = false;
            this.button1.Text = "BETA TESTING: RESET LOGGED IN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_help
            // 
            this.btn_help.BackColor = System.Drawing.Color.White;
            this.btn_help.BackgroundImage = global::major_nav.Properties.Resources.icons8_help_64__1_1;
            this.btn_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_help.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_help.FlatAppearance.BorderSize = 0;
            this.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_help.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_help.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_help.Location = new System.Drawing.Point(3, 3);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(61, 49);
            this.btn_help.TabIndex = 16;
            this.btn_help.TabStop = false;
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(795, 464);
            this.Controls.Add(this.dgv_user);
            this.Controls.Add(this.btn_register_generatePass);
            this.Controls.Add(this.btn_logIn);
            this.Controls.Add(this.btn_login_passwordShow);
            this.Controls.Add(this.btn_register_passwordShow);
            this.Controls.Add(this.cb_EULA);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_signup_email);
            this.Controls.Add(this.txt_signup_password);
            this.Controls.Add(this.txt_signup_username);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_forgotPassword);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_register_icon_Email);
            this.Controls.Add(this.pnl_line2);
            this.Controls.Add(this.pb_register_icon_Pass);
            this.Controls.Add(this.pnl_line);
            this.Controls.Add(this.pb_register_icon_User);
            this.Controls.Add(this.pb_login_lock);
            this.Controls.Add(this.pb_login_user);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.panel4);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_Pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login_lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox pb_login_user;
        private System.Windows.Forms.Panel pnl_line;
        private System.Windows.Forms.PictureBox pb_login_lock;
        private System.Windows.Forms.Panel pnl_line2;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lbl_forgotPassword;
        private System.Windows.Forms.PictureBox pb_register_icon_Email;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_signup_email;
        private System.Windows.Forms.CheckBox cb_EULA;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_register_icon_User;
        private System.Windows.Forms.PictureBox pb_register_icon_Pass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_signup_username;
        private System.Windows.Forms.TextBox txt_signup_password;
        private System.Windows.Forms.Button btn_register_passwordShow;
        private System.Windows.Forms.Button btn_login_passwordShow;
        private System.Windows.Forms.Button btn_logIn;
        private System.Windows.Forms.Button btn_register_generatePass;
        private System.Windows.Forms.DataGridView dgv_user;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.Button button1;
    }
}

