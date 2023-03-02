namespace major_nav
{
    partial class frm_forgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_forgetPassword));
            this.lbl_name = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.lbl_forgotPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.pb_user = new System.Windows.Forms.PictureBox();
            this.dgv_userData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbl_name.Location = new System.Drawing.Point(13, 26);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(333, 39);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "FORGOT PASSWORD";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.DarkViolet;
            this.panel3.Location = new System.Drawing.Point(59, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 1);
            this.panel3.TabIndex = 3;
            // 
            // txt_user
            // 
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_user.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_user.Location = new System.Drawing.Point(93, 133);
            this.txt_user.MaxLength = 25;
            this.txt_user.Multiline = true;
            this.txt_user.Name = "txt_user";
            this.txt_user.ShortcutsEnabled = false;
            this.txt_user.Size = new System.Drawing.Size(204, 24);
            this.txt_user.TabIndex = 6;
            this.txt_user.Text = "Email/Username";
            this.txt_user.Click += new System.EventHandler(this.txt_user_Click);
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            this.txt_user.Leave += new System.EventHandler(this.txt_user_Leave);
            // 
            // lbl_forgotPassword
            // 
            this.lbl_forgotPassword.AutoSize = true;
            this.lbl_forgotPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_forgotPassword.ForeColor = System.Drawing.Color.Navy;
            this.lbl_forgotPassword.Location = new System.Drawing.Point(150, 224);
            this.lbl_forgotPassword.Name = "lbl_forgotPassword";
            this.lbl_forgotPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_forgotPassword.Size = new System.Drawing.Size(55, 16);
            this.lbl_forgotPassword.TabIndex = 5;
            this.lbl_forgotPassword.Text = "RETURN";
            this.lbl_forgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_forgotPassword.Click += new System.EventHandler(this.lbl_return_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(34, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 41);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter your username or email and a security code will be sent to the associated e" +
    "mail";
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Navy;
            this.btn_send.BackgroundImage = global::major_nav.Properties.Resources.top1;
            this.btn_send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_send.FlatAppearance.BorderSize = 0;
            this.btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.ForeColor = System.Drawing.Color.White;
            this.btn_send.Location = new System.Drawing.Point(59, 183);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(236, 33);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // pb_user
            // 
            this.pb_user.Image = global::major_nav.Properties.Resources.icons8_customer_64__1_;
            this.pb_user.Location = new System.Drawing.Point(59, 121);
            this.pb_user.Name = "pb_user";
            this.pb_user.Size = new System.Drawing.Size(28, 33);
            this.pb_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_user.TabIndex = 2;
            this.pb_user.TabStop = false;
            // 
            // dgv_userData
            // 
            this.dgv_userData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userData.Location = new System.Drawing.Point(301, 183);
            this.dgv_userData.Name = "dgv_userData";
            this.dgv_userData.Size = new System.Drawing.Size(240, 150);
            this.dgv_userData.TabIndex = 13;
            this.dgv_userData.Visible = false;
            // 
            // frm_forgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::major_nav.Properties.Resources.loginbkGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(358, 266);
            this.Controls.Add(this.dgv_userData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_forgotPassword);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.pb_user);
            this.Controls.Add(this.lbl_name);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_forgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox pb_user;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label lbl_forgotPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_userData;
    }
}

