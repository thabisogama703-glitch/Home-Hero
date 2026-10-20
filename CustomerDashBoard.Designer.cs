namespace HomeHero
{
    partial class frmCustomerDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerDashboard));
            label1 = new Label();
            panel1 = new Panel();
            pnlHeaderAccent = new Panel();
            pbxHomeHeroLogo = new PictureBox();
            btnServiceHistory = new Button();
            BtnActiceRequests = new Button();
            btnLogout = new Button();
            btnNewServiceRequest = new Button();
            btnTrackRequest = new Button();
            pnlDashBoard = new Panel();
            lblDashboardOverview = new Label();
            lblDashboardHint = new Label();
            label9 = new Label();
            lblCustomerDashboardTitle = new Label();
            panel3 = new Panel();
            pnlWelcomeCard = new Panel();
            pnlWelcomeAccent = new Panel();
            pictureBox5 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            pnlDashBoard.SuspendLayout();
            panel3.SuspendLayout();
            pnlWelcomeCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(90, 25);
            label1.Name = "label1";
            label1.Size = new Size(223, 50);
            label1.TabIndex = 0;
            label1.Text = "Home Hero";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(22, 45, 92);
            panel1.Controls.Add(pnlHeaderAccent);
            panel1.Controls.Add(pbxHomeHeroLogo);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1915, 104);
            panel1.TabIndex = 3;
            // 
            // pnlHeaderAccent
            // 
            pnlHeaderAccent.BackColor = Color.FromArgb(255, 107, 53);
            pnlHeaderAccent.Dock = DockStyle.Bottom;
            pnlHeaderAccent.Location = new Point(0, 101);
            pnlHeaderAccent.Name = "pnlHeaderAccent";
            pnlHeaderAccent.Size = new Size(1915, 3);
            pnlHeaderAccent.TabIndex = 13;
            // 
            // pbxHomeHeroLogo
            // 
            pbxHomeHeroLogo.Image = Home_Hero.Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(28, 26);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(52, 52);
            pbxHomeHeroLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbxHomeHeroLogo.TabIndex = 12;
            pbxHomeHeroLogo.TabStop = false;
            // 
            // btnServiceHistory
            // 
            btnServiceHistory.BackColor = Color.FromArgb(30, 58, 108);
            btnServiceHistory.Cursor = Cursors.Hand;
            btnServiceHistory.FlatAppearance.BorderSize = 0;
            btnServiceHistory.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 45, 92);
            btnServiceHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 80, 140);
            btnServiceHistory.FlatStyle = FlatStyle.Flat;
            btnServiceHistory.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnServiceHistory.ForeColor = Color.White;
            btnServiceHistory.Image = (Image)resources.GetObject("btnServiceHistory.Image");
            btnServiceHistory.ImageAlign = ContentAlignment.MiddleLeft;
            btnServiceHistory.Location = new Point(20, 104);
            btnServiceHistory.Name = "btnServiceHistory";
            btnServiceHistory.Padding = new Padding(18, 0, 0, 0);
            btnServiceHistory.Size = new Size(259, 54);
            btnServiceHistory.TabIndex = 1;
            btnServiceHistory.Text = "Service History";
            btnServiceHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnServiceHistory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServiceHistory.UseVisualStyleBackColor = false;
            btnServiceHistory.Click += btnServiceHistory_Click;
            // 
            // BtnActiceRequests
            // 
            BtnActiceRequests.BackColor = Color.FromArgb(30, 58, 108);
            BtnActiceRequests.Cursor = Cursors.Hand;
            BtnActiceRequests.FlatAppearance.BorderSize = 0;
            BtnActiceRequests.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 45, 92);
            BtnActiceRequests.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 80, 140);
            BtnActiceRequests.FlatStyle = FlatStyle.Flat;
            BtnActiceRequests.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnActiceRequests.ForeColor = Color.White;
            BtnActiceRequests.Image = (Image)resources.GetObject("BtnActiceRequests.Image");
            BtnActiceRequests.ImageAlign = ContentAlignment.MiddleLeft;
            BtnActiceRequests.Location = new Point(20, 36);
            BtnActiceRequests.Name = "BtnActiceRequests";
            BtnActiceRequests.Padding = new Padding(18, 0, 0, 0);
            BtnActiceRequests.Size = new Size(259, 54);
            BtnActiceRequests.TabIndex = 0;
            BtnActiceRequests.Text = "Active Requests";
            BtnActiceRequests.TextAlign = ContentAlignment.MiddleLeft;
            BtnActiceRequests.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnActiceRequests.UseVisualStyleBackColor = false;
            BtnActiceRequests.Click += BtnActiceRequests_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.FromArgb(30, 58, 108);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 45, 92);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 80, 140);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(20, 873);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(18, 0, 0, 0);
            btnLogout.Size = new Size(259, 54);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnBackToHome_Click;
            // 
            // btnNewServiceRequest
            // 
            btnNewServiceRequest.BackColor = Color.FromArgb(255, 107, 53);
            btnNewServiceRequest.Cursor = Cursors.Hand;
            btnNewServiceRequest.FlatAppearance.BorderSize = 0;
            btnNewServiceRequest.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 90, 40);
            btnNewServiceRequest.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 132, 84);
            btnNewServiceRequest.FlatStyle = FlatStyle.Flat;
            btnNewServiceRequest.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewServiceRequest.ForeColor = Color.White;
            btnNewServiceRequest.Location = new Point(20, 266);
            btnNewServiceRequest.Name = "btnNewServiceRequest";
            btnNewServiceRequest.Size = new Size(259, 58);
            btnNewServiceRequest.TabIndex = 1;
            btnNewServiceRequest.Text = "+ New Service Request";
            btnNewServiceRequest.UseVisualStyleBackColor = false;
            btnNewServiceRequest.Click += btnNewServiceRequest_Click_1;
            // 
            // btnTrackRequest
            // 
            btnTrackRequest.BackColor = Color.FromArgb(30, 58, 108);
            btnTrackRequest.Cursor = Cursors.Hand;
            btnTrackRequest.FlatAppearance.BorderSize = 0;
            btnTrackRequest.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 45, 92);
            btnTrackRequest.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 80, 140);
            btnTrackRequest.FlatStyle = FlatStyle.Flat;
            btnTrackRequest.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTrackRequest.ForeColor = Color.White;
            btnTrackRequest.Image = (Image)resources.GetObject("btnTrackRequest.Image");
            btnTrackRequest.ImageAlign = ContentAlignment.MiddleLeft;
            btnTrackRequest.Location = new Point(20, 172);
            btnTrackRequest.Name = "btnTrackRequest";
            btnTrackRequest.Padding = new Padding(18, 0, 0, 0);
            btnTrackRequest.Size = new Size(259, 54);
            btnTrackRequest.TabIndex = 2;
            btnTrackRequest.Text = "Track Request";
            btnTrackRequest.TextAlign = ContentAlignment.MiddleLeft;
            btnTrackRequest.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTrackRequest.UseVisualStyleBackColor = false;
            btnTrackRequest.Click += btnTrackRequest_Click_1;
            // 
            // pnlDashBoard
            // 
            pnlDashBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDashBoard.BackColor = Color.White;
            pnlDashBoard.BorderStyle = BorderStyle.None;
            pnlDashBoard.Controls.Add(lblDashboardHint);
            pnlDashBoard.Controls.Add(lblDashboardOverview);
            pnlDashBoard.Location = new Point(331, 376);
            pnlDashBoard.Name = "pnlDashBoard";
            pnlDashBoard.Size = new Size(1552, 647);
            pnlDashBoard.TabIndex = 9;
            // 
            // lblDashboardOverview
            // 
            lblDashboardOverview.AutoSize = true;
            lblDashboardOverview.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardOverview.ForeColor = Color.FromArgb(22, 45, 92);
            lblDashboardOverview.Location = new Point(32, 28);
            lblDashboardOverview.Name = "lblDashboardOverview";
            lblDashboardOverview.Size = new Size(106, 32);
            lblDashboardOverview.TabIndex = 0;
            lblDashboardOverview.Text = "Overview";
            // 
            // lblDashboardHint
            // 
            lblDashboardHint.AutoSize = true;
            lblDashboardHint.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashboardHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblDashboardHint.Location = new Point(34, 68);
            lblDashboardHint.Name = "lblDashboardHint";
            lblDashboardHint.Size = new Size(437, 25);
            lblDashboardHint.TabIndex = 1;
            lblDashboardHint.Text = "Your active requests and recent activity will appear here.";
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(255, 107, 53);
            label9.Location = new Point(40, 50);
            label9.Name = "label9";
            label9.Size = new Size(600, 64);
            label9.TabIndex = 3;
            label9.Text = "Welcome Back!";
            // 
            // lblCustomerDashboardTitle
            // 
            lblCustomerDashboardTitle.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerDashboardTitle.ForeColor = Color.FromArgb(22, 45, 92);
            lblCustomerDashboardTitle.Location = new Point(40, 116);
            lblCustomerDashboardTitle.Name = "lblCustomerDashboardTitle";
            lblCustomerDashboardTitle.Size = new Size(500, 46);
            lblCustomerDashboardTitle.TabIndex = 0;
            lblCustomerDashboardTitle.Text = "Customer Dashboard";
            lblCustomerDashboardTitle.Click += lblCustomerDashboardTitle_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.BackColor = Color.FromArgb(17, 36, 74);
            panel3.Controls.Add(btnLogout);
            panel3.Controls.Add(btnNewServiceRequest);
            panel3.Controls.Add(btnTrackRequest);
            panel3.Controls.Add(btnServiceHistory);
            panel3.Controls.Add(BtnActiceRequests);
            panel3.Location = new Point(0, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(299, 951);
            panel3.TabIndex = 4;
            // 
            // pnlWelcomeCard
            // 
            pnlWelcomeCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlWelcomeCard.BackColor = Color.White;
            pnlWelcomeCard.Controls.Add(label9);
            pnlWelcomeCard.Controls.Add(lblCustomerDashboardTitle);
            pnlWelcomeCard.Controls.Add(pictureBox5);
            pnlWelcomeCard.Controls.Add(pnlWelcomeAccent);
            pnlWelcomeCard.Location = new Point(331, 132);
            pnlWelcomeCard.Name = "pnlWelcomeCard";
            pnlWelcomeCard.Size = new Size(1552, 220);
            pnlWelcomeCard.TabIndex = 10;
            // 
            // pnlWelcomeAccent
            // 
            pnlWelcomeAccent.BackColor = Color.FromArgb(255, 107, 53);
            pnlWelcomeAccent.Dock = DockStyle.Left;
            pnlWelcomeAccent.Location = new Point(0, 0);
            pnlWelcomeAccent.Name = "pnlWelcomeAccent";
            pnlWelcomeAccent.Size = new Size(6, 220);
            pnlWelcomeAccent.TabIndex = 4;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1184, 11);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(352, 198);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // frmCustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 242, 247);
            ClientSize = new Size(1915, 1055);
            Controls.Add(pnlWelcomeCard);
            Controls.Add(panel3);
            Controls.Add(pnlDashBoard);
            Controls.Add(panel1);
            Name = "frmCustomerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmCustomerDashboard_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            pnlDashBoard.ResumeLayout(false);
            pnlDashBoard.PerformLayout();
            panel3.ResumeLayout(false);
            pnlWelcomeCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BtnActiceRequests;
        private Button btnServiceHistory;
        private Button btnLogout;
        private Panel panel1;
        private Button btnNewServiceRequest;
        private Button btnTrackRequest;
        private Panel pnlDashBoard;
        private Label label9;
        private Label lblCustomerDashboardTitle;
        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox pbxHomeHeroLogo;
        private Panel pnlHeaderAccent;
        private Panel pnlWelcomeCard;
        private Panel pnlWelcomeAccent;
        private Label lblDashboardOverview;
        private Label lblDashboardHint;
    }
}
