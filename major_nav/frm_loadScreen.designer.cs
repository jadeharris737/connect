namespace major_nav
{
    partial class frm_loadScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_loadScreen));
            this.progBar_loading = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progBar_loading
            // 
            this.progBar_loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.progBar_loading.ForeColor = System.Drawing.Color.SteelBlue;
            this.progBar_loading.Location = new System.Drawing.Point(-5, -21);
            this.progBar_loading.Name = "progBar_loading";
            this.progBar_loading.Size = new System.Drawing.Size(205, 68);
            this.progBar_loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progBar_loading.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progBar_loading);
            this.panel1.Location = new System.Drawing.Point(221, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 5);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(272, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "ONNECT";
            // 
            // frm_loadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::major_nav.Properties.Resources.Loading_Screen37;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(621, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_loadScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splash_screen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_loadScreen_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progBar_loading;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}