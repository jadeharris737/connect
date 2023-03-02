namespace major_nav
{
    partial class frm_newPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_newPassword));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_return = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_line2 = new System.Windows.Forms.Panel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_showPass = new System.Windows.Forms.Button();
            this.btn_resetPassword = new System.Windows.Forms.Button();
            this.pb_lock = new System.Windows.Forms.PictureBox();
            this.txt_oneTimeCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_register_generatePass = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pb_user = new System.Windows.Forms.PictureBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.dgv_userReset = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userReset)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbl_name.Location = new System.Drawing.Point(38, 21);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(283, 39);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "RESET PASSWORD";
            // 
            // lbl_return
            // 
            this.lbl_return.AutoSize = true;
            this.lbl_return.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_return.ForeColor = System.Drawing.Color.Navy;
            this.lbl_return.Location = new System.Drawing.Point(147, 289);
            this.lbl_return.Name = "lbl_return";
            this.lbl_return.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_return.Size = new System.Drawing.Size(55, 16);
            this.lbl_return.TabIndex = 5;
            this.lbl_return.Text = "RETURN";
            this.lbl_return.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_return.Click += new System.EventHandler(this.lbl_return_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(23, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter a new password and one-time use code sent";
            // 
            // pnl_line2
            // 
            this.pnl_line2.BackColor = System.Drawing.Color.Indigo;
            this.pnl_line2.Location = new System.Drawing.Point(26, 228);
            this.pnl_line2.Name = "pnl_line2";
            this.pnl_line2.Size = new System.Drawing.Size(236, 1);
            this.pnl_line2.TabIndex = 3;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.SystemColors.Window;
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Indigo;
            this.txt_password.Location = new System.Drawing.Point(59, 199);
            this.txt_password.MaxLength = 12;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(204, 19);
            this.txt_password.TabIndex = 6;
            this.txt_password.Text = "New Password";
            this.txt_password.Click += new System.EventHandler(this.txt_password_Click_1);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave_1);
            // 
            // btn_showPass
            // 
            this.btn_showPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_showPass.FlatAppearance.BorderSize = 0;
            this.btn_showPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showPass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_showPass.ForeColor = System.Drawing.Color.White;
            this.btn_showPass.Location = new System.Drawing.Point(269, 203);
            this.btn_showPass.Name = "btn_showPass";
            this.btn_showPass.Size = new System.Drawing.Size(63, 23);
            this.btn_showPass.TabIndex = 11;
            this.btn_showPass.Text = "SHOW";
            this.btn_showPass.UseVisualStyleBackColor = false;
            this.btn_showPass.MouseEnter += new System.EventHandler(this.btn_showPass_MouseEnter);
            this.btn_showPass.MouseLeave += new System.EventHandler(this.btn_showPass_MouseLeave);
            // 
            // btn_resetPassword
            // 
            this.btn_resetPassword.BackColor = System.Drawing.Color.Navy;
            this.btn_resetPassword.BackgroundImage = global::major_nav.Properties.Resources.top1;
            this.btn_resetPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_resetPassword.FlatAppearance.BorderSize = 0;
            this.btn_resetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resetPassword.ForeColor = System.Drawing.Color.White;
            this.btn_resetPassword.Location = new System.Drawing.Point(59, 250);
            this.btn_resetPassword.Name = "btn_resetPassword";
            this.btn_resetPassword.Size = new System.Drawing.Size(236, 33);
            this.btn_resetPassword.TabIndex = 4;
            this.btn_resetPassword.Text = "RESET PASSWORD";
            this.btn_resetPassword.UseVisualStyleBackColor = false;
            this.btn_resetPassword.Click += new System.EventHandler(this.btn_resetPassword_Click);
            // 
            // pb_lock
            // 
            this.pb_lock.ErrorImage = null;
            this.pb_lock.Image = global::major_nav.Properties.Resources.icons8_lock_64;
            this.pb_lock.Location = new System.Drawing.Point(30, 189);
            this.pb_lock.Name = "pb_lock";
            this.pb_lock.Size = new System.Drawing.Size(26, 37);
            this.pb_lock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_lock.TabIndex = 2;
            this.pb_lock.TabStop = false;
            // 
            // txt_oneTimeCode
            // 
            this.txt_oneTimeCode.BackColor = System.Drawing.SystemColors.Window;
            this.txt_oneTimeCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_oneTimeCode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oneTimeCode.ForeColor = System.Drawing.Color.Indigo;
            this.txt_oneTimeCode.Location = new System.Drawing.Point(59, 149);
            this.txt_oneTimeCode.MaxLength = 4;
            this.txt_oneTimeCode.Multiline = true;
            this.txt_oneTimeCode.Name = "txt_oneTimeCode";
            this.txt_oneTimeCode.Size = new System.Drawing.Size(204, 24);
            this.txt_oneTimeCode.TabIndex = 15;
            this.txt_oneTimeCode.Text = "One-Time Code";
            this.txt_oneTimeCode.Click += new System.EventHandler(this.txt_oneTimeCode_Click);
            this.txt_oneTimeCode.Leave += new System.EventHandler(this.txt_oneTimeCode_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Location = new System.Drawing.Point(26, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 1);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::major_nav.Properties.Resources.icons8_lock_64;
            this.pictureBox1.Location = new System.Drawing.Point(30, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btn_register_generatePass
            // 
            this.btn_register_generatePass.BackColor = System.Drawing.Color.White;
            this.btn_register_generatePass.FlatAppearance.BorderSize = 0;
            this.btn_register_generatePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register_generatePass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_register_generatePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_register_generatePass.Location = new System.Drawing.Point(180, 203);
            this.btn_register_generatePass.Name = "btn_register_generatePass";
            this.btn_register_generatePass.Size = new System.Drawing.Size(87, 23);
            this.btn_register_generatePass.TabIndex = 16;
            this.btn_register_generatePass.Text = "GENERATE";
            this.btn_register_generatePass.UseVisualStyleBackColor = false;
            this.btn_register_generatePass.Click += new System.EventHandler(this.btn_register_generatePass_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.DarkViolet;
            this.panel3.Location = new System.Drawing.Point(27, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 1);
            this.panel3.TabIndex = 18;
            // 
            // pb_user
            // 
            this.pb_user.Image = global::major_nav.Properties.Resources.icons8_customer_64__1_;
            this.pb_user.Location = new System.Drawing.Point(27, 91);
            this.pb_user.Name = "pb_user";
            this.pb_user.Size = new System.Drawing.Size(28, 33);
            this.pb_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_user.TabIndex = 17;
            this.pb_user.TabStop = false;
            // 
            // txt_user
            // 
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_user.Enabled = false;
            this.txt_user.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_user.Location = new System.Drawing.Point(61, 103);
            this.txt_user.MaxLength = 25;
            this.txt_user.Multiline = true;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(204, 24);
            this.txt_user.TabIndex = 19;
            this.txt_user.Text = "Username";
            // 
            // dgv_userReset
            // 
            this.dgv_userReset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userReset.Location = new System.Drawing.Point(222, 289);
            this.dgv_userReset.Name = "dgv_userReset";
            this.dgv_userReset.Size = new System.Drawing.Size(240, 150);
            this.dgv_userReset.TabIndex = 20;
            this.dgv_userReset.Visible = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(269, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 46);
            this.label9.TabIndex = 91;
            this.label9.Text = "Username";
            // 
            // frm_newPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::major_nav.Properties.Resources.loginbkGround1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(360, 331);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgv_userReset);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pb_user);
            this.Controls.Add(this.btn_register_generatePass);
            this.Controls.Add(this.txt_oneTimeCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_showPass);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_return);
            this.Controls.Add(this.btn_resetPassword);
            this.Controls.Add(this.pnl_line2);
            this.Controls.Add(this.pb_lock);
            this.Controls.Add(this.lbl_name);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_newPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userReset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_resetPassword;
        private System.Windows.Forms.Label lbl_return;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_lock;
        private System.Windows.Forms.Panel pnl_line2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_showPass;
        private System.Windows.Forms.TextBox txt_oneTimeCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_register_generatePass;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pb_user;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.DataGridView dgv_userReset;
        private System.Windows.Forms.Label label9;
    }
}

