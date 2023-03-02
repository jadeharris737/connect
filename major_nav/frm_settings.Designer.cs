namespace major_nav
{
    partial class frm_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.lbl_username = new System.Windows.Forms.Label();
            this.btn_deleteAccount = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_tempCode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pb_user = new System.Windows.Forms.PictureBox();
            this.btn_generatePass = new System.Windows.Forms.Button();
            this.btn_passwordShow = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_register_icon_Pass = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_changePassword = new System.Windows.Forms.Button();
            this.dgv_userData = new System.Windows.Forms.DataGridView();
            this.dgv_friendData = new System.Windows.Forms.DataGridView();
            this.dgv_eventData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_Pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friendData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eventData)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_username
            // 
            this.lbl_username.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_username.Location = new System.Drawing.Point(445, 147);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(202, 18);
            this.lbl_username.TabIndex = 13;
            this.lbl_username.Text = "Your Account Settings";
            this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_deleteAccount
            // 
            this.btn_deleteAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_deleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteAccount.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteAccount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_deleteAccount.Location = new System.Drawing.Point(602, 354);
            this.btn_deleteAccount.Name = "btn_deleteAccount";
            this.btn_deleteAccount.Size = new System.Drawing.Size(203, 34);
            this.btn_deleteAccount.TabIndex = 15;
            this.btn_deleteAccount.Text = "DELETE ACCOUNT";
            this.btn_deleteAccount.UseVisualStyleBackColor = false;
            this.btn_deleteAccount.Click += new System.EventHandler(this.btn_deleteAccount_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::major_nav.Properties.Resources.icons8_settings_512__1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(105, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 232);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btn_tempCode
            // 
            this.btn_tempCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_tempCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tempCode.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btn_tempCode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_tempCode.Location = new System.Drawing.Point(397, 354);
            this.btn_tempCode.Name = "btn_tempCode";
            this.btn_tempCode.Size = new System.Drawing.Size(199, 34);
            this.btn_tempCode.TabIndex = 26;
            this.btn_tempCode.Text = "REMOVE TEMPORARY CODE";
            this.btn_tempCode.UseVisualStyleBackColor = false;
            this.btn_tempCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(637, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 97;
            this.label4.Text = "Username";
            // 
            // txt_username
            // 
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Enabled = false;
            this.txt_username.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_username.Location = new System.Drawing.Point(431, 199);
            this.txt_username.MaxLength = 20;
            this.txt_username.Multiline = true;
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(204, 24);
            this.txt_username.TabIndex = 93;
            this.txt_username.Text = "Username";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.DarkViolet;
            this.panel3.Location = new System.Drawing.Point(395, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 1);
            this.panel3.TabIndex = 92;
            // 
            // pb_user
            // 
            this.pb_user.Image = ((System.Drawing.Image)(resources.GetObject("pb_user.Image")));
            this.pb_user.Location = new System.Drawing.Point(398, 187);
            this.pb_user.Name = "pb_user";
            this.pb_user.Size = new System.Drawing.Size(28, 33);
            this.pb_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_user.TabIndex = 91;
            this.pb_user.TabStop = false;
            // 
            // btn_generatePass
            // 
            this.btn_generatePass.BackColor = System.Drawing.Color.White;
            this.btn_generatePass.FlatAppearance.BorderSize = 0;
            this.btn_generatePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generatePass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_generatePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_generatePass.Location = new System.Drawing.Point(560, 300);
            this.btn_generatePass.Name = "btn_generatePass";
            this.btn_generatePass.Size = new System.Drawing.Size(87, 23);
            this.btn_generatePass.TabIndex = 103;
            this.btn_generatePass.Text = "GENERATE";
            this.btn_generatePass.UseVisualStyleBackColor = false;
            this.btn_generatePass.Click += new System.EventHandler(this.btn_generatePass_Click_1);
            // 
            // btn_passwordShow
            // 
            this.btn_passwordShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_passwordShow.FlatAppearance.BorderSize = 0;
            this.btn_passwordShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_passwordShow.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_passwordShow.ForeColor = System.Drawing.Color.White;
            this.btn_passwordShow.Location = new System.Drawing.Point(647, 300);
            this.btn_passwordShow.Name = "btn_passwordShow";
            this.btn_passwordShow.Size = new System.Drawing.Size(63, 23);
            this.btn_passwordShow.TabIndex = 102;
            this.btn_passwordShow.Text = "SHOW";
            this.btn_passwordShow.UseVisualStyleBackColor = false;
            this.btn_passwordShow.MouseEnter += new System.EventHandler(this.btn_passwordShow_MouseEnter);
            this.btn_passwordShow.MouseLeave += new System.EventHandler(this.btn_passwordShow_MouseLeave);
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_password.Location = new System.Drawing.Point(431, 300);
            this.txt_password.MaxLength = 12;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(204, 19);
            this.txt_password.TabIndex = 101;
            this.txt_password.Text = "Password";
            this.txt_password.Click += new System.EventHandler(this.txt_password_Click);
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkViolet;
            this.panel1.Location = new System.Drawing.Point(397, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 1);
            this.panel1.TabIndex = 100;
            // 
            // pb_register_icon_Pass
            // 
            this.pb_register_icon_Pass.BackColor = System.Drawing.Color.Transparent;
            this.pb_register_icon_Pass.Image = ((System.Drawing.Image)(resources.GetObject("pb_register_icon_Pass.Image")));
            this.pb_register_icon_Pass.Location = new System.Drawing.Point(399, 292);
            this.pb_register_icon_Pass.Name = "pb_register_icon_Pass";
            this.pb_register_icon_Pass.Size = new System.Drawing.Size(28, 33);
            this.pb_register_icon_Pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_register_icon_Pass.TabIndex = 99;
            this.pb_register_icon_Pass.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(637, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 107;
            this.label1.Text = "Email";
            // 
            // txt_email
            // 
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Enabled = false;
            this.txt_email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_email.Location = new System.Drawing.Point(431, 251);
            this.txt_email.MaxLength = 20;
            this.txt_email.Multiline = true;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(204, 24);
            this.txt_email.TabIndex = 106;
            this.txt_email.Text = "Email";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.DarkViolet;
            this.panel2.Location = new System.Drawing.Point(395, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 1);
            this.panel2.TabIndex = 105;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::major_nav.Properties.Resources.icons8_email_96;
            this.pictureBox2.Location = new System.Drawing.Point(398, 239);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 104;
            this.pictureBox2.TabStop = false;
            // 
            // btn_changePassword
            // 
            this.btn_changePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_changePassword.FlatAppearance.BorderSize = 0;
            this.btn_changePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_changePassword.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btn_changePassword.ForeColor = System.Drawing.Color.White;
            this.btn_changePassword.Location = new System.Drawing.Point(716, 300);
            this.btn_changePassword.Name = "btn_changePassword";
            this.btn_changePassword.Size = new System.Drawing.Size(152, 23);
            this.btn_changePassword.TabIndex = 108;
            this.btn_changePassword.Text = "CHANGE PASSWORD";
            this.btn_changePassword.UseVisualStyleBackColor = false;
            this.btn_changePassword.Click += new System.EventHandler(this.btn_changePassword_Click);
            // 
            // dgv_userData
            // 
            this.dgv_userData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userData.Location = new System.Drawing.Point(919, -57);
            this.dgv_userData.Name = "dgv_userData";
            this.dgv_userData.Size = new System.Drawing.Size(240, 150);
            this.dgv_userData.TabIndex = 109;
            this.dgv_userData.Visible = false;
            // 
            // dgv_friendData
            // 
            this.dgv_friendData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_friendData.Location = new System.Drawing.Point(664, -66);
            this.dgv_friendData.Name = "dgv_friendData";
            this.dgv_friendData.Size = new System.Drawing.Size(240, 150);
            this.dgv_friendData.TabIndex = 110;
            this.dgv_friendData.Visible = false;
            // 
            // dgv_eventData
            // 
            this.dgv_eventData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_eventData.Location = new System.Drawing.Point(407, -43);
            this.dgv_eventData.Name = "dgv_eventData";
            this.dgv_eventData.Size = new System.Drawing.Size(240, 150);
            this.dgv_eventData.TabIndex = 111;
            this.dgv_eventData.Visible = false;
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::major_nav.Properties.Resources.bkground_v3;
            this.ClientSize = new System.Drawing.Size(964, 564);
            this.Controls.Add(this.dgv_eventData);
            this.Controls.Add(this.dgv_friendData);
            this.Controls.Add(this.dgv_userData);
            this.Controls.Add(this.btn_changePassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_generatePass);
            this.Controls.Add(this.btn_passwordShow);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_register_icon_Pass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pb_user);
            this.Controls.Add(this.btn_tempCode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_deleteAccount);
            this.Controls.Add(this.lbl_username);
            this.Name = "frm_settings";
            this.Text = "frm_profile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_register_icon_Pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friendData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eventData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Button btn_deleteAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_tempCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pb_user;
        private System.Windows.Forms.Button btn_generatePass;
        private System.Windows.Forms.Button btn_passwordShow;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_register_icon_Pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_changePassword;
        private System.Windows.Forms.DataGridView dgv_userData;
        private System.Windows.Forms.DataGridView dgv_friendData;
        private System.Windows.Forms.DataGridView dgv_eventData;
    }
}