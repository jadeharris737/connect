namespace major_nav
{
    partial class frm_welcomeNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_welcomeNewUser));
            this.lbl_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_closeWelcome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbl_name.Location = new System.Drawing.Point(15, 29);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(396, 39);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "WELCOME TO CONNECT";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(56, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 57);
            this.label1.TabIndex = 12;
            this.label1.Text = "It is highly recommended you read this PDF of the application\'s overall documenta" +
    "tion and follow the brief tutorials to get started quickly!";
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
            this.btn_send.Location = new System.Drawing.Point(37, 155);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(352, 44);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "OPEN APPLICATION DOCUMENTATION PDF";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_closeWelcome
            // 
            this.btn_closeWelcome.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_closeWelcome.FlatAppearance.BorderSize = 0;
            this.btn_closeWelcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_closeWelcome.Font = new System.Drawing.Font("Lucida Sans", 9.75F);
            this.btn_closeWelcome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_closeWelcome.Location = new System.Drawing.Point(148, 217);
            this.btn_closeWelcome.Name = "btn_closeWelcome";
            this.btn_closeWelcome.Size = new System.Drawing.Size(120, 24);
            this.btn_closeWelcome.TabIndex = 38;
            this.btn_closeWelcome.Text = "OK";
            this.btn_closeWelcome.UseVisualStyleBackColor = false;
            this.btn_closeWelcome.Click += new System.EventHandler(this.btn_closeWelcome_Click);
            // 
            // frm_welcomeNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::major_nav.Properties.Resources.loginbkGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(439, 275);
            this.Controls.Add(this.btn_closeWelcome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_name);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_welcomeNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_closeWelcome;
    }
}

