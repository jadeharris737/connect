namespace major_nav
{
    partial class frm_nav
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_nav));
            this.pnl_desktop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_shadowEffect = new System.Windows.Forms.Panel();
            this.pnl_titleBar = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_minimised = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_titleOfChildForm = new System.Windows.Forms.Label();
            this.pb_currentChildFormIcon = new FontAwesome.Sharp.IconPictureBox();
            this.pnl_menu = new System.Windows.Forms.Panel();
            this.btn_settings = new FontAwesome.Sharp.IconButton();
            this.btn_friends = new FontAwesome.Sharp.IconButton();
            this.btn_invitations = new FontAwesome.Sharp.IconButton();
            this.btn_myEvents = new FontAwesome.Sharp.IconButton();
            this.btn_events = new FontAwesome.Sharp.IconButton();
            this.btn_hub = new FontAwesome.Sharp.IconButton();
            this.pnl_spacer = new System.Windows.Forms.Panel();
            this.pnl_bottomShadow = new System.Windows.Forms.Panel();
            this.btn_help = new FontAwesome.Sharp.IconButton();
            this.btn_logOut = new FontAwesome.Sharp.IconButton();
            this.pnl_logo = new System.Windows.Forms.Panel();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.lbl_joined = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pnl_desktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_currentChildFormIcon)).BeginInit();
            this.pnl_menu.SuspendLayout();
            this.pnl_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_desktop
            // 
            this.pnl_desktop.BackColor = System.Drawing.Color.White;
            this.pnl_desktop.BackgroundImage = global::major_nav.Properties.Resources.bkground;
            this.pnl_desktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_desktop.Controls.Add(this.pictureBox1);
            this.pnl_desktop.Controls.Add(this.label1);
            this.pnl_desktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_desktop.ForeColor = System.Drawing.Color.Black;
            this.pnl_desktop.Location = new System.Drawing.Point(220, 52);
            this.pnl_desktop.Name = "pnl_desktop";
            this.pnl_desktop.Size = new System.Drawing.Size(980, 603);
            this.pnl_desktop.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::major_nav.Properties.Resources.C_icon_v1;
            this.pictureBox1.Location = new System.Drawing.Point(296, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(470, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 39);
            this.label1.TabIndex = 13;
            this.label1.Text = "TODAY\'S EVENTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // pnl_shadowEffect
            // 
            this.pnl_shadowEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.pnl_shadowEffect.BackgroundImage = global::major_nav.Properties.Resources.darker;
            this.pnl_shadowEffect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_shadowEffect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_shadowEffect.Location = new System.Drawing.Point(220, 43);
            this.pnl_shadowEffect.Name = "pnl_shadowEffect";
            this.pnl_shadowEffect.Size = new System.Drawing.Size(980, 9);
            this.pnl_shadowEffect.TabIndex = 2;
            // 
            // pnl_titleBar
            // 
            this.pnl_titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.pnl_titleBar.BackgroundImage = global::major_nav.Properties.Resources.top;
            this.pnl_titleBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_titleBar.Controls.Add(this.btn_home);
            this.pnl_titleBar.Controls.Add(this.btn_minimised);
            this.pnl_titleBar.Controls.Add(this.btn_exit);
            this.pnl_titleBar.Controls.Add(this.lbl_titleOfChildForm);
            this.pnl_titleBar.Controls.Add(this.pb_currentChildFormIcon);
            this.pnl_titleBar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnl_titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titleBar.Location = new System.Drawing.Point(220, 0);
            this.pnl_titleBar.Name = "pnl_titleBar";
            this.pnl_titleBar.Size = new System.Drawing.Size(980, 43);
            this.pnl_titleBar.TabIndex = 1;
            this.pnl_titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_titleBar_MouseDown);
            // 
            // btn_home
            // 
            this.btn_home.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_home.BackColor = System.Drawing.Color.Transparent;
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_home.FlatAppearance.BorderSize = 0;
            this.btn_home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(119)))), ((int)(((byte)(176)))));
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.Image = global::major_nav.Properties.Resources.home2;
            this.btn_home.Location = new System.Drawing.Point(852, 12);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(38, 17);
            this.btn_home.TabIndex = 2;
            this.btn_home.UseVisualStyleBackColor = false;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_minimised
            // 
            this.btn_minimised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimised.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimised.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_minimised.FlatAppearance.BorderSize = 0;
            this.btn_minimised.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(138)))), ((int)(((byte)(114)))));
            this.btn_minimised.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimised.Image = global::major_nav.Properties.Resources.minimise;
            this.btn_minimised.Location = new System.Drawing.Point(894, 12);
            this.btn_minimised.Name = "btn_minimised";
            this.btn_minimised.Size = new System.Drawing.Size(38, 17);
            this.btn_minimised.TabIndex = 2;
            this.btn_minimised.UseVisualStyleBackColor = false;
            this.btn_minimised.Click += new System.EventHandler(this.btn_minimised_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(126)))), ((int)(((byte)(241)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Image = global::major_nav.Properties.Resources.corss;
            this.btn_exit.Location = new System.Drawing.Point(938, 13);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(38, 17);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_titleOfChildForm
            // 
            this.lbl_titleOfChildForm.AutoSize = true;
            this.lbl_titleOfChildForm.BackColor = System.Drawing.Color.Transparent;
            this.lbl_titleOfChildForm.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titleOfChildForm.ForeColor = System.Drawing.Color.White;
            this.lbl_titleOfChildForm.Location = new System.Drawing.Point(59, 18);
            this.lbl_titleOfChildForm.Name = "lbl_titleOfChildForm";
            this.lbl_titleOfChildForm.Size = new System.Drawing.Size(47, 17);
            this.lbl_titleOfChildForm.TabIndex = 1;
            this.lbl_titleOfChildForm.Text = "Home";
            // 
            // pb_currentChildFormIcon
            // 
            this.pb_currentChildFormIcon.BackColor = System.Drawing.Color.Transparent;
            this.pb_currentChildFormIcon.ForeColor = System.Drawing.Color.GhostWhite;
            this.pb_currentChildFormIcon.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.pb_currentChildFormIcon.IconColor = System.Drawing.Color.GhostWhite;
            this.pb_currentChildFormIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pb_currentChildFormIcon.IconSize = 20;
            this.pb_currentChildFormIcon.Location = new System.Drawing.Point(36, 17);
            this.pb_currentChildFormIcon.Name = "pb_currentChildFormIcon";
            this.pb_currentChildFormIcon.Size = new System.Drawing.Size(32, 32);
            this.pb_currentChildFormIcon.TabIndex = 0;
            this.pb_currentChildFormIcon.TabStop = false;
            // 
            // pnl_menu
            // 
            this.pnl_menu.BackColor = System.Drawing.Color.White;
            this.pnl_menu.Controls.Add(this.btn_settings);
            this.pnl_menu.Controls.Add(this.btn_friends);
            this.pnl_menu.Controls.Add(this.btn_invitations);
            this.pnl_menu.Controls.Add(this.btn_myEvents);
            this.pnl_menu.Controls.Add(this.btn_events);
            this.pnl_menu.Controls.Add(this.btn_hub);
            this.pnl_menu.Controls.Add(this.pnl_spacer);
            this.pnl_menu.Controls.Add(this.pnl_bottomShadow);
            this.pnl_menu.Controls.Add(this.btn_help);
            this.pnl_menu.Controls.Add(this.btn_logOut);
            this.pnl_menu.Controls.Add(this.pnl_logo);
            this.pnl_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.Size = new System.Drawing.Size(220, 655);
            this.pnl_menu.TabIndex = 0;
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.Transparent;
            this.btn_settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_settings.FlatAppearance.BorderSize = 0;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settings.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_settings.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.btn_settings.IconColor = System.Drawing.Color.DimGray;
            this.btn_settings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_settings.IconSize = 20;
            this.btn_settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.Location = new System.Drawing.Point(0, 429);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_settings.Size = new System.Drawing.Size(220, 45);
            this.btn_settings.TabIndex = 7;
            this.btn_settings.Text = " Settings";
            this.btn_settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_friends
            // 
            this.btn_friends.BackColor = System.Drawing.Color.Transparent;
            this.btn_friends.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_friends.FlatAppearance.BorderSize = 0;
            this.btn_friends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_friends.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_friends.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_friends.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btn_friends.IconColor = System.Drawing.Color.DimGray;
            this.btn_friends.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_friends.IconSize = 20;
            this.btn_friends.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_friends.Location = new System.Drawing.Point(0, 384);
            this.btn_friends.Name = "btn_friends";
            this.btn_friends.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_friends.Size = new System.Drawing.Size(220, 45);
            this.btn_friends.TabIndex = 5;
            this.btn_friends.Text = " My Friends";
            this.btn_friends.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_friends.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_friends.UseVisualStyleBackColor = false;
            this.btn_friends.Click += new System.EventHandler(this.btn_budget_Click);
            // 
            // btn_invitations
            // 
            this.btn_invitations.BackColor = System.Drawing.Color.Transparent;
            this.btn_invitations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_invitations.FlatAppearance.BorderSize = 0;
            this.btn_invitations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_invitations.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invitations.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_invitations.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.btn_invitations.IconColor = System.Drawing.Color.DimGray;
            this.btn_invitations.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_invitations.IconSize = 20;
            this.btn_invitations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_invitations.Location = new System.Drawing.Point(0, 339);
            this.btn_invitations.Name = "btn_invitations";
            this.btn_invitations.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_invitations.Size = new System.Drawing.Size(220, 45);
            this.btn_invitations.TabIndex = 4;
            this.btn_invitations.Text = " My Invitations";
            this.btn_invitations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_invitations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_invitations.UseVisualStyleBackColor = false;
            this.btn_invitations.Click += new System.EventHandler(this.btn_friends_Click);
            // 
            // btn_myEvents
            // 
            this.btn_myEvents.BackColor = System.Drawing.Color.Transparent;
            this.btn_myEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_myEvents.FlatAppearance.BorderSize = 0;
            this.btn_myEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_myEvents.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_myEvents.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_myEvents.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btn_myEvents.IconColor = System.Drawing.Color.DimGray;
            this.btn_myEvents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_myEvents.IconSize = 20;
            this.btn_myEvents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_myEvents.Location = new System.Drawing.Point(0, 294);
            this.btn_myEvents.Name = "btn_myEvents";
            this.btn_myEvents.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_myEvents.Size = new System.Drawing.Size(220, 45);
            this.btn_myEvents.TabIndex = 3;
            this.btn_myEvents.Text = " My Events";
            this.btn_myEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_myEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_myEvents.UseVisualStyleBackColor = false;
            this.btn_myEvents.Click += new System.EventHandler(this.btn_myEvents_Click);
            // 
            // btn_events
            // 
            this.btn_events.BackColor = System.Drawing.Color.Transparent;
            this.btn_events.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_events.FlatAppearance.BorderSize = 0;
            this.btn_events.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_events.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_events.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_events.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btn_events.IconColor = System.Drawing.Color.DimGray;
            this.btn_events.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_events.IconSize = 20;
            this.btn_events.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_events.Location = new System.Drawing.Point(0, 249);
            this.btn_events.Name = "btn_events";
            this.btn_events.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_events.Size = new System.Drawing.Size(220, 45);
            this.btn_events.TabIndex = 2;
            this.btn_events.Text = " Events";
            this.btn_events.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_events.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_events.UseVisualStyleBackColor = false;
            this.btn_events.Click += new System.EventHandler(this.btn_events_Click);
            // 
            // btn_hub
            // 
            this.btn_hub.BackColor = System.Drawing.Color.Transparent;
            this.btn_hub.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_hub.FlatAppearance.BorderSize = 0;
            this.btn_hub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hub.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hub.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_hub.IconChar = FontAwesome.Sharp.IconChar.HouseUser;
            this.btn_hub.IconColor = System.Drawing.Color.DimGray;
            this.btn_hub.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_hub.IconSize = 20;
            this.btn_hub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hub.Location = new System.Drawing.Point(0, 204);
            this.btn_hub.Name = "btn_hub";
            this.btn_hub.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_hub.Size = new System.Drawing.Size(220, 45);
            this.btn_hub.TabIndex = 1;
            this.btn_hub.Text = " Home";
            this.btn_hub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_hub.UseVisualStyleBackColor = false;
            this.btn_hub.Click += new System.EventHandler(this.btn_hub_Click);
            // 
            // pnl_spacer
            // 
            this.pnl_spacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_spacer.Location = new System.Drawing.Point(0, 167);
            this.pnl_spacer.Name = "pnl_spacer";
            this.pnl_spacer.Size = new System.Drawing.Size(220, 37);
            this.pnl_spacer.TabIndex = 2;
            // 
            // pnl_bottomShadow
            // 
            this.pnl_bottomShadow.BackgroundImage = global::major_nav.Properties.Resources.newShadowNav2;
            this.pnl_bottomShadow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_bottomShadow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_bottomShadow.Location = new System.Drawing.Point(0, 529);
            this.pnl_bottomShadow.Name = "pnl_bottomShadow";
            this.pnl_bottomShadow.Size = new System.Drawing.Size(220, 36);
            this.pnl_bottomShadow.TabIndex = 2;
            // 
            // btn_help
            // 
            this.btn_help.BackColor = System.Drawing.Color.Transparent;
            this.btn_help.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_help.FlatAppearance.BorderSize = 0;
            this.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_help.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_help.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_help.IconChar = FontAwesome.Sharp.IconChar.QuestionCircle;
            this.btn_help.IconColor = System.Drawing.Color.DimGray;
            this.btn_help.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_help.IconSize = 20;
            this.btn_help.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_help.Location = new System.Drawing.Point(0, 565);
            this.btn_help.Name = "btn_help";
            this.btn_help.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_help.Size = new System.Drawing.Size(220, 45);
            this.btn_help.TabIndex = 8;
            this.btn_help.Text = "User Guide";
            this.btn_help.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_help.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_logOut
            // 
            this.btn_logOut.BackColor = System.Drawing.Color.Transparent;
            this.btn_logOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_logOut.FlatAppearance.BorderSize = 0;
            this.btn_logOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logOut.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logOut.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_logOut.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            this.btn_logOut.IconColor = System.Drawing.Color.DimGray;
            this.btn_logOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_logOut.IconSize = 20;
            this.btn_logOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logOut.Location = new System.Drawing.Point(0, 610);
            this.btn_logOut.Name = "btn_logOut";
            this.btn_logOut.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_logOut.Size = new System.Drawing.Size(220, 45);
            this.btn_logOut.TabIndex = 6;
            this.btn_logOut.Text = "Log out";
            this.btn_logOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_logOut.UseVisualStyleBackColor = false;
            this.btn_logOut.Click += new System.EventHandler(this.btn_logOut_Click);
            // 
            // pnl_logo
            // 
            this.pnl_logo.BackColor = System.Drawing.Color.White;
            this.pnl_logo.BackgroundImage = global::major_nav.Properties.Resources.toptop;
            this.pnl_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_logo.Controls.Add(this.pb_logo);
            this.pnl_logo.Controls.Add(this.lbl_joined);
            this.pnl_logo.Controls.Add(this.lbl_username);
            this.pnl_logo.Controls.Add(this.pictureBox5);
            this.pnl_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_logo.Name = "pnl_logo";
            this.pnl_logo.Size = new System.Drawing.Size(220, 167);
            this.pnl_logo.TabIndex = 0;
            // 
            // pb_logo
            // 
            this.pb_logo.Image = global::major_nav.Properties.Resources.logo2;
            this.pb_logo.Location = new System.Drawing.Point(116, 35);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(88, 36);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 1;
            this.pb_logo.TabStop = false;
            // 
            // lbl_joined
            // 
            this.lbl_joined.AutoSize = true;
            this.lbl_joined.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_joined.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_joined.Location = new System.Drawing.Point(121, 103);
            this.lbl_joined.Name = "lbl_joined";
            this.lbl_joined.Size = new System.Drawing.Size(75, 17);
            this.lbl_joined.TabIndex = 8;
            this.lbl_joined.Text = "Joined Aug";
            // 
            // lbl_username
            // 
            this.lbl_username.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_username.Location = new System.Drawing.Point(108, 82);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(102, 18);
            this.lbl_username.TabIndex = 7;
            this.lbl_username.Text = "username";
            this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::major_nav.Properties.Resources.user5;
            this.pictureBox5.Location = new System.Drawing.Point(-33, 17);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(185, 131);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // frm_nav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 655);
            this.Controls.Add(this.pnl_desktop);
            this.Controls.Add(this.pnl_shadowEffect);
            this.Controls.Add(this.pnl_titleBar);
            this.Controls.Add(this.pnl_menu);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 655);
            this.Name = "frm_nav";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONNECT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_nav_FormClosing);
            this.Shown += new System.EventHandler(this.frm_nav_Shown);
            this.pnl_desktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_titleBar.ResumeLayout(false);
            this.pnl_titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_currentChildFormIcon)).EndInit();
            this.pnl_menu.ResumeLayout(false);
            this.pnl_logo.ResumeLayout(false);
            this.pnl_logo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_menu;
        private System.Windows.Forms.Panel pnl_logo;
        private System.Windows.Forms.PictureBox pb_logo;
        private FontAwesome.Sharp.IconButton btn_logOut;
        private System.Windows.Forms.Panel pnl_titleBar;
        private System.Windows.Forms.Button btn_minimised;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel pnl_shadowEffect;
        private System.Windows.Forms.Label lbl_titleOfChildForm;
        private FontAwesome.Sharp.IconPictureBox pb_currentChildFormIcon;
        private FontAwesome.Sharp.IconButton btn_help;
        private System.Windows.Forms.Panel pnl_bottomShadow;
        private FontAwesome.Sharp.IconButton btn_settings;
        private FontAwesome.Sharp.IconButton btn_friends;
        private FontAwesome.Sharp.IconButton btn_invitations;
        private FontAwesome.Sharp.IconButton btn_hub;
        private System.Windows.Forms.Panel pnl_spacer;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Panel pnl_desktop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_joined;
        private System.Windows.Forms.Label label1;
        public FontAwesome.Sharp.IconButton btn_myEvents;
        private FontAwesome.Sharp.IconButton btn_events;
    }
}

