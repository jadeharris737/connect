namespace major_nav
{
    partial class frm_events
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_events));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_newEvent = new System.Windows.Forms.Button();
            this.dgv_events = new System.Windows.Forms.DataGridView();
            this.btnclm_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnclm_leave = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgv_currentEventSelection = new System.Windows.Forms.DataGridView();
            this.dgv_currentUserInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lbl_lastUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_events)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_currentEventSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_currentUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_newEvent
            // 
            this.btn_newEvent.BackColor = System.Drawing.Color.Navy;
            this.btn_newEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_newEvent.BackgroundImage")));
            this.btn_newEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_newEvent.FlatAppearance.BorderSize = 0;
            this.btn_newEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newEvent.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newEvent.ForeColor = System.Drawing.Color.White;
            this.btn_newEvent.Location = new System.Drawing.Point(701, 34);
            this.btn_newEvent.Name = "btn_newEvent";
            this.btn_newEvent.Size = new System.Drawing.Size(236, 29);
            this.btn_newEvent.TabIndex = 29;
            this.btn_newEvent.Text = "GO TO CREATE NEW EVENT";
            this.btn_newEvent.UseVisualStyleBackColor = false;
            this.btn_newEvent.Click += new System.EventHandler(this.btn_newEvent_Click_1);
            // 
            // dgv_events
            // 
            this.dgv_events.AllowUserToAddRows = false;
            this.dgv_events.AllowUserToDeleteRows = false;
            this.dgv_events.AllowUserToResizeColumns = false;
            this.dgv_events.AllowUserToResizeRows = false;
            this.dgv_events.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_events.BackgroundColor = System.Drawing.Color.White;
            this.dgv_events.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_events.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_events.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_events.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_events.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_events.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnclm_view,
            this.btnclm_leave});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_events.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_events.EnableHeadersVisualStyles = false;
            this.dgv_events.GridColor = System.Drawing.Color.White;
            this.dgv_events.Location = new System.Drawing.Point(39, 108);
            this.dgv_events.MultiSelect = false;
            this.dgv_events.Name = "dgv_events";
            this.dgv_events.ReadOnly = true;
            this.dgv_events.RowHeadersVisible = false;
            this.dgv_events.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_events.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_events.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_events.ShowEditingIcon = false;
            this.dgv_events.Size = new System.Drawing.Size(895, 420);
            this.dgv_events.TabIndex = 28;
            this.dgv_events.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_events_CellContentClick);
            this.dgv_events.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_events_CellFormatting);
            this.dgv_events.Click += new System.EventHandler(this.dgv_events_Click);
            // 
            // btnclm_view
            // 
            this.btnclm_view.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.btnclm_view.DefaultCellStyle = dataGridViewCellStyle6;
            this.btnclm_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclm_view.HeaderText = "";
            this.btnclm_view.Name = "btnclm_view";
            this.btnclm_view.ReadOnly = true;
            this.btnclm_view.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnclm_view.Text = "View Details";
            this.btnclm_view.UseColumnTextForButtonValue = true;
            // 
            // btnclm_leave
            // 
            this.btnclm_leave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(88)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(88)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.btnclm_leave.DefaultCellStyle = dataGridViewCellStyle7;
            this.btnclm_leave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclm_leave.HeaderText = "";
            this.btnclm_leave.Name = "btnclm_leave";
            this.btnclm_leave.ReadOnly = true;
            this.btnclm_leave.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnclm_leave.Text = "Leave";
            this.btnclm_leave.UseColumnTextForButtonValue = true;
            // 
            // dgv_currentEventSelection
            // 
            this.dgv_currentEventSelection.AllowUserToAddRows = false;
            this.dgv_currentEventSelection.AllowUserToDeleteRows = false;
            this.dgv_currentEventSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_currentEventSelection.Location = new System.Drawing.Point(873, 411);
            this.dgv_currentEventSelection.Name = "dgv_currentEventSelection";
            this.dgv_currentEventSelection.ReadOnly = true;
            this.dgv_currentEventSelection.Size = new System.Drawing.Size(240, 150);
            this.dgv_currentEventSelection.TabIndex = 36;
            this.dgv_currentEventSelection.Visible = false;
            // 
            // dgv_currentUserInfo
            // 
            this.dgv_currentUserInfo.AllowUserToAddRows = false;
            this.dgv_currentUserInfo.AllowUserToDeleteRows = false;
            this.dgv_currentUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_currentUserInfo.Location = new System.Drawing.Point(940, 255);
            this.dgv_currentUserInfo.Name = "dgv_currentUserInfo";
            this.dgv_currentUserInfo.ReadOnly = true;
            this.dgv_currentUserInfo.Size = new System.Drawing.Size(240, 150);
            this.dgv_currentUserInfo.TabIndex = 37;
            this.dgv_currentUserInfo.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(32, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 92;
            this.label1.Text = "REFRESH LIST";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(130, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 90;
            this.label4.Text = "Last Updated";
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_refresh.BackgroundImage = global::major_nav.Properties.Resources.icons8_refresh_641;
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_refresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_refresh.FlatAppearance.BorderSize = 0;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Location = new System.Drawing.Point(42, 18);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(63, 57);
            this.btn_refresh.TabIndex = 89;
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lbl_lastUpdate
            // 
            this.lbl_lastUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_lastUpdate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lastUpdate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_lastUpdate.Location = new System.Drawing.Point(222, 66);
            this.lbl_lastUpdate.Name = "lbl_lastUpdate";
            this.lbl_lastUpdate.Size = new System.Drawing.Size(233, 18);
            this.lbl_lastUpdate.TabIndex = 91;
            this.lbl_lastUpdate.Text = "Last Updated";
            // 
            // frm_events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(964, 564);
            this.Controls.Add(this.lbl_lastUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.dgv_currentUserInfo);
            this.Controls.Add(this.dgv_currentEventSelection);
            this.Controls.Add(this.btn_newEvent);
            this.Controls.Add(this.dgv_events);
            this.Controls.Add(this.label1);
            this.Name = "frm_events";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_events";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_events)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_currentEventSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_currentUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_newEvent;
        private System.Windows.Forms.DataGridView dgv_events;
        private System.Windows.Forms.DataGridView dgv_currentEventSelection;
        private System.Windows.Forms.DataGridView dgv_currentUserInfo;
        private System.Windows.Forms.DataGridViewButtonColumn btnclm_view;
        private System.Windows.Forms.DataGridViewButtonColumn btnclm_leave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lbl_lastUpdate;
    }
}