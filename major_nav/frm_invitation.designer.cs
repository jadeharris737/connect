namespace major_nav
{
    partial class frm_invitation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_invitation));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_return = new System.Windows.Forms.Label();
            this.btn_sendVote = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pb_user = new System.Windows.Forms.PictureBox();
            this.txt_eventName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_duration = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_owner = new System.Windows.Forms.TextBox();
            this.txt_noInvited = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgv_eventData = new System.Windows.Forms.DataGridView();
            this.dgv_userData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eventData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbl_name.Location = new System.Drawing.Point(66, 25);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(341, 39);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "YOU\'VE BEEN INVITED";
            // 
            // lbl_return
            // 
            this.lbl_return.AutoSize = true;
            this.lbl_return.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_return.ForeColor = System.Drawing.Color.Navy;
            this.lbl_return.Location = new System.Drawing.Point(200, 552);
            this.lbl_return.Name = "lbl_return";
            this.lbl_return.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_return.Size = new System.Drawing.Size(55, 16);
            this.lbl_return.TabIndex = 5;
            this.lbl_return.Text = "RETURN";
            this.lbl_return.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_return.Click += new System.EventHandler(this.lbl_return_Click);
            // 
            // btn_sendVote
            // 
            this.btn_sendVote.BackColor = System.Drawing.Color.Navy;
            this.btn_sendVote.BackgroundImage = global::major_nav.Properties.Resources.top1;
            this.btn_sendVote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sendVote.FlatAppearance.BorderSize = 0;
            this.btn_sendVote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sendVote.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sendVote.ForeColor = System.Drawing.Color.White;
            this.btn_sendVote.Location = new System.Drawing.Point(113, 507);
            this.btn_sendVote.Name = "btn_sendVote";
            this.btn_sendVote.Size = new System.Drawing.Size(236, 33);
            this.btn_sendVote.TabIndex = 4;
            this.btn_sendVote.Text = "VIEW VOTING OPTIONS";
            this.btn_sendVote.UseVisualStyleBackColor = false;
            this.btn_sendVote.Click += new System.EventHandler(this.btn_createEvent_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.DarkViolet;
            this.panel3.Location = new System.Drawing.Point(44, 218);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 1);
            this.panel3.TabIndex = 18;
            // 
            // pb_user
            // 
            this.pb_user.Image = global::major_nav.Properties.Resources.icons8_ball_point_pen_641;
            this.pb_user.Location = new System.Drawing.Point(46, 179);
            this.pb_user.Name = "pb_user";
            this.pb_user.Size = new System.Drawing.Size(28, 33);
            this.pb_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_user.TabIndex = 17;
            this.pb_user.TabStop = false;
            // 
            // txt_eventName
            // 
            this.txt_eventName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_eventName.Enabled = false;
            this.txt_eventName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_eventName.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_eventName.Location = new System.Drawing.Point(80, 191);
            this.txt_eventName.MaxLength = 20;
            this.txt_eventName.Multiline = true;
            this.txt_eventName.Name = "txt_eventName";
            this.txt_eventName.Size = new System.Drawing.Size(204, 24);
            this.txt_eventName.TabIndex = 19;
            this.txt_eventName.Text = "Event Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Location = new System.Drawing.Point(49, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 1);
            this.panel2.TabIndex = 22;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::major_nav.Properties.Resources.icons8_ball_point_pen_64;
            this.pictureBox2.Location = new System.Drawing.Point(51, 226);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // txt_cost
            // 
            this.txt_cost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cost.Enabled = false;
            this.txt_cost.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cost.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_cost.Location = new System.Drawing.Point(87, 393);
            this.txt_cost.MaxLength = 25;
            this.txt_cost.Multiline = true;
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.Size = new System.Drawing.Size(204, 24);
            this.txt_cost.TabIndex = 26;
            this.txt_cost.Text = "Cost";

            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.DarkViolet;
            this.panel4.Location = new System.Drawing.Point(53, 420);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 1);
            this.panel4.TabIndex = 25;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::major_nav.Properties.Resources.icons8_add_dollar_64;
            this.pictureBox3.Location = new System.Drawing.Point(53, 381);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.BackColor = System.Drawing.Color.DarkViolet;
            this.panel5.Location = new System.Drawing.Point(53, 476);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 1);
            this.panel5.TabIndex = 28;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::major_nav.Properties.Resources.icons8_future_64;
            this.pictureBox4.Location = new System.Drawing.Point(53, 437);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // txt_duration
            // 
            this.txt_duration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_duration.Enabled = false;
            this.txt_duration.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_duration.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_duration.Location = new System.Drawing.Point(87, 449);
            this.txt_duration.MaxLength = 6;
            this.txt_duration.Multiline = true;
            this.txt_duration.Name = "txt_duration";
            this.txt_duration.Size = new System.Drawing.Size(204, 24);
            this.txt_duration.TabIndex = 29;
            this.txt_duration.Text = "Duration";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::major_nav.Properties.Resources.icons8_future_64;
            this.pictureBox1.Location = new System.Drawing.Point(50, 278);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.BackColor = System.Drawing.Color.DarkViolet;
            this.panel6.Location = new System.Drawing.Point(50, 317);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(236, 1);
            this.panel6.TabIndex = 28;
            // 
            // txt_owner
            // 
            this.txt_owner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_owner.Enabled = false;
            this.txt_owner.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_owner.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_owner.Location = new System.Drawing.Point(84, 290);
            this.txt_owner.MaxLength = 6;
            this.txt_owner.Multiline = true;
            this.txt_owner.Name = "txt_owner";
            this.txt_owner.Size = new System.Drawing.Size(204, 24);
            this.txt_owner.TabIndex = 29;
            this.txt_owner.Text = "Owner";
            // 
            // txt_noInvited
            // 
            this.txt_noInvited.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_noInvited.Enabled = false;
            this.txt_noInvited.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noInvited.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_noInvited.Location = new System.Drawing.Point(84, 343);
            this.txt_noInvited.MaxLength = 6;
            this.txt_noInvited.Multiline = true;
            this.txt_noInvited.Name = "txt_noInvited";
            this.txt_noInvited.Size = new System.Drawing.Size(71, 24);
            this.txt_noInvited.TabIndex = 65;
            this.txt_noInvited.Text = "Number";
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.BackColor = System.Drawing.Color.DarkViolet;
            this.panel7.Location = new System.Drawing.Point(50, 370);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(236, 1);
            this.panel7.TabIndex = 64;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::major_nav.Properties.Resources.icons8_future_64;
            this.pictureBox6.Location = new System.Drawing.Point(50, 331);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(28, 33);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 63;
            this.pictureBox6.TabStop = false;
            // 
            // txt_description
            // 
            this.txt_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_description.Enabled = false;
            this.txt_description.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.ForeColor = System.Drawing.Color.DarkViolet;
            this.txt_description.Location = new System.Drawing.Point(84, 235);
            this.txt_description.MaxLength = 6;
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(251, 24);
            this.txt_description.TabIndex = 82;
            this.txt_description.Text = "Short Description";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::major_nav.Properties.Resources.icons8_letter_from_hospital_96;
            this.pictureBox5.Location = new System.Drawing.Point(177, 67);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(118, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 84;
            this.pictureBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(286, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 85;
            this.label4.Text = "Event Name";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(286, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 86;
            this.label5.Text = "Owner";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(286, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 15);
            this.label6.TabIndex = 87;
            this.label6.Text = "Number of Attendees";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(291, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 88;
            this.label7.Text = "Cost";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(291, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 89;
            this.label8.Text = "Duration";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(341, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 18);
            this.label9.TabIndex = 90;
            this.label9.Text = "Short Description";
            // 
            // dgv_eventData
            // 
            this.dgv_eventData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_eventData.Location = new System.Drawing.Point(363, 131);
            this.dgv_eventData.Name = "dgv_eventData";
            this.dgv_eventData.Size = new System.Drawing.Size(59, 43);
            this.dgv_eventData.TabIndex = 20;
            this.dgv_eventData.Visible = false;
            // 
            // dgv_userData
            // 
            this.dgv_userData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userData.Location = new System.Drawing.Point(363, 84);
            this.dgv_userData.Name = "dgv_userData";
            this.dgv_userData.Size = new System.Drawing.Size(59, 41);
            this.dgv_userData.TabIndex = 83;
            this.dgv_userData.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(189, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 91;
            this.label2.Text = "Event Details";
            // 
            // frm_invitation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::major_nav.Properties.Resources.loginbkGround1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(487, 604);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.dgv_userData);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_noInvited);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.txt_owner);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txt_duration);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txt_cost);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dgv_eventData);
            this.Controls.Add(this.txt_eventName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pb_user);
            this.Controls.Add(this.lbl_return);
            this.Controls.Add(this.btn_sendVote);
            this.Controls.Add(this.lbl_name);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_invitation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eventData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_sendVote;
        private System.Windows.Forms.Label lbl_return;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pb_user;
        private System.Windows.Forms.TextBox txt_eventName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txt_duration;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_owner;
        private System.Windows.Forms.TextBox txt_noInvited;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_eventData;
        private System.Windows.Forms.DataGridView dgv_userData;
        private System.Windows.Forms.Label label2;
    }
}

