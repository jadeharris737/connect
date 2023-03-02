namespace major_nav
{
    partial class frm_inviteFriend
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_inviteFriend));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_return = new System.Windows.Forms.Label();
            this.btn_sendVote = new System.Windows.Forms.Button();
            this.dgv_eventData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_userData = new System.Windows.Forms.DataGridView();
            this.dgv_friends = new System.Windows.Forms.DataGridView();
            this.clm_users = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_friendData = new System.Windows.Forms.DataGridView();
            this.lbl_lastUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eventData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friendData)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.DarkViolet;
            this.lbl_name.Location = new System.Drawing.Point(12, 30);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(310, 39);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "SELECT NEW USER...";
            // 
            // lbl_return
            // 
            this.lbl_return.AutoSize = true;
            this.lbl_return.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_return.ForeColor = System.Drawing.Color.Navy;
            this.lbl_return.Location = new System.Drawing.Point(123, 429);
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
            this.btn_sendVote.Location = new System.Drawing.Point(41, 385);
            this.btn_sendVote.Name = "btn_sendVote";
            this.btn_sendVote.Size = new System.Drawing.Size(236, 33);
            this.btn_sendVote.TabIndex = 4;
            this.btn_sendVote.Text = "SEND/ADD";
            this.btn_sendVote.UseVisualStyleBackColor = false;
            this.btn_sendVote.Click += new System.EventHandler(this.btn_sendInvite_Click);
            // 
            // dgv_eventData
            // 
            this.dgv_eventData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_eventData.Location = new System.Drawing.Point(307, 30);
            this.dgv_eventData.Name = "dgv_eventData";
            this.dgv_eventData.Size = new System.Drawing.Size(59, 43);
            this.dgv_eventData.TabIndex = 20;
            this.dgv_eventData.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(62, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "Select friend to invite/attend";
            // 
            // dgv_userData
            // 
            this.dgv_userData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userData.Location = new System.Drawing.Point(307, 181);
            this.dgv_userData.Name = "dgv_userData";
            this.dgv_userData.Size = new System.Drawing.Size(59, 41);
            this.dgv_userData.TabIndex = 83;
            this.dgv_userData.Visible = false;
            // 
            // dgv_friends
            // 
            this.dgv_friends.AllowUserToAddRows = false;
            this.dgv_friends.AllowUserToDeleteRows = false;
            this.dgv_friends.AllowUserToResizeColumns = false;
            this.dgv_friends.AllowUserToResizeRows = false;
            this.dgv_friends.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_friends.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_friends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_friends.ColumnHeadersVisible = false;
            this.dgv_friends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_users});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_friends.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_friends.Location = new System.Drawing.Point(41, 100);
            this.dgv_friends.Name = "dgv_friends";
            this.dgv_friends.ReadOnly = true;
            this.dgv_friends.RowHeadersVisible = false;
            this.dgv_friends.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_friends.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_friends.Size = new System.Drawing.Size(243, 270);
            this.dgv_friends.TabIndex = 108;
            this.dgv_friends.Click += new System.EventHandler(this.dgv_invitees_Click);
            // 
            // clm_users
            // 
            this.clm_users.HeaderText = "";
            this.clm_users.Name = "clm_users";
            this.clm_users.ReadOnly = true;
            // 
            // dgv_friendData
            // 
            this.dgv_friendData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_friendData.Location = new System.Drawing.Point(307, 100);
            this.dgv_friendData.Name = "dgv_friendData";
            this.dgv_friendData.Size = new System.Drawing.Size(59, 41);
            this.dgv_friendData.TabIndex = 110;
            this.dgv_friendData.Visible = false;
            // 
            // lbl_lastUpdate
            // 
            this.lbl_lastUpdate.AutoSize = true;
            this.lbl_lastUpdate.Location = new System.Drawing.Point(242, 421);
            this.lbl_lastUpdate.Name = "lbl_lastUpdate";
            this.lbl_lastUpdate.Size = new System.Drawing.Size(35, 13);
            this.lbl_lastUpdate.TabIndex = 109;
            this.lbl_lastUpdate.Text = "label1";
            this.lbl_lastUpdate.Visible = false;
            // 
            // frm_inviteFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::major_nav.Properties.Resources.loginbkGround1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(331, 475);
            this.Controls.Add(this.dgv_friendData);
            this.Controls.Add(this.dgv_friends);
            this.Controls.Add(this.dgv_userData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_eventData);
            this.Controls.Add(this.lbl_return);
            this.Controls.Add(this.btn_sendVote);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_lastUpdate);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_inviteFriend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eventData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friendData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_sendVote;
        private System.Windows.Forms.Label lbl_return;
        private System.Windows.Forms.DataGridView dgv_eventData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_userData;
        private System.Windows.Forms.DataGridView dgv_friends;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_users;
        private System.Windows.Forms.DataGridView dgv_friendData;
        private System.Windows.Forms.Label lbl_lastUpdate;
    }
}

