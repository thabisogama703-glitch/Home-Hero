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
            pbxHomeHeroLogo = new PictureBox();
            btnServiceHistory = new Button();
            BtnActiceRequests = new Button();
            btnLogout = new Button();
            btnNewServiceRequest = new Button();
            btnTrackRequest = new Button();
            pnlDashBoard = new Panel();
            label9 = new Label();
            lblCustomerDashboardTitle = new Label();
            panel3 = new Panel();
            pictureBox10 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(73, 26);
            label1.Name = "label1";
            label1.Size = new Size(265, 60);
            label1.TabIndex = 0;
            label1.Text = "Home Hero";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(pbxHomeHeroLogo);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-5, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1922, 104);
            panel1.TabIndex = 3;
            // 
            // pbxHomeHeroLogo
            // 
            pbxHomeHeroLogo.Image = Home_Hero.Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(19, 39);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(48, 47);
            pbxHomeHeroLogo.TabIndex = 12;
            pbxHomeHeroLogo.TabStop = false;
            // 
            // btnServiceHistory
            // 
            btnServiceHistory.BackColor = Color.FromArgb(0, 0, 64);
            btnServiceHistory.FlatStyle = FlatStyle.Flat;
            btnServiceHistory.ForeColor = Color.White;
            btnServiceHistory.Location = new Point(12, 150);
            btnServiceHistory.Name = "btnServiceHistory";
            btnServiceHistory.Size = new Size(265, 51);
            btnServiceHistory.TabIndex = 1;
            btnServiceHistory.Text = "Service History";
            btnServiceHistory.UseVisualStyleBackColor = false;
            btnServiceHistory.Click += btnServiceHistory_Click;
            // 
            // BtnActiceRequests
            // 
            BtnActiceRequests.BackColor = Color.FromArgb(0, 0, 64);
            BtnActiceRequests.FlatStyle = FlatStyle.Flat;
            BtnActiceRequests.ForeColor = Color.White;
            BtnActiceRequests.Location = new Point(12, 59);
            BtnActiceRequests.Name = "BtnActiceRequests";
            BtnActiceRequests.Size = new Size(265, 51);
            BtnActiceRequests.TabIndex = 0;
            BtnActiceRequests.Text = "Active Requests";
            BtnActiceRequests.UseVisualStyleBackColor = false;
            BtnActiceRequests.Click += BtnActiceRequests_Click;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(12, 439);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(265, 51);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnBackToHome_Click;
            // 
            // btnNewServiceRequest
            // 
            btnNewServiceRequest.BackColor = Color.FromArgb(255, 128, 0);
            btnNewServiceRequest.FlatStyle = FlatStyle.Flat;
            btnNewServiceRequest.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewServiceRequest.ForeColor = Color.White;
            btnNewServiceRequest.Location = new Point(12, 335);
            btnNewServiceRequest.Name = "btnNewServiceRequest";
            btnNewServiceRequest.Size = new Size(265, 54);
            btnNewServiceRequest.TabIndex = 1;
            btnNewServiceRequest.Text = "+ New Service Request";
            btnNewServiceRequest.UseVisualStyleBackColor = false;
            btnNewServiceRequest.Click += btnNewServiceRequest_Click_1;
            // 
            // btnTrackRequest
            // 
            btnTrackRequest.BackColor = Color.FromArgb(0, 0, 64);
            btnTrackRequest.FlatStyle = FlatStyle.Flat;
            btnTrackRequest.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrackRequest.ForeColor = Color.White;
            btnTrackRequest.Location = new Point(12, 237);
            btnTrackRequest.Name = "btnTrackRequest";
            btnTrackRequest.Size = new Size(265, 57);
            btnTrackRequest.TabIndex = 2;
            btnTrackRequest.Text = "Track Request";
            btnTrackRequest.UseVisualStyleBackColor = false;
            btnTrackRequest.Click += btnTrackRequest_Click_1;
            // 
            // pnlDashBoard
            // 
            pnlDashBoard.BackColor = SystemColors.ButtonHighlight;
            pnlDashBoard.BorderStyle = BorderStyle.FixedSingle;
            pnlDashBoard.Location = new Point(305, 326);
            pnlDashBoard.Name = "pnlDashBoard";
            pnlDashBoard.Size = new Size(1582, 698);
            pnlDashBoard.TabIndex = 9;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(255, 128, 0);
            label9.Location = new Point(346, 142);
            label9.Name = "label9";
            label9.Size = new Size(420, 63);
            label9.TabIndex = 3;
            label9.Text = "Welcome Back!";
            // 
            // lblCustomerDashboardTitle
            // 
            lblCustomerDashboardTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerDashboardTitle.ForeColor = Color.FromArgb(0, 0, 64);
            lblCustomerDashboardTitle.Location = new Point(346, 194);
            lblCustomerDashboardTitle.Name = "lblCustomerDashboardTitle";
            lblCustomerDashboardTitle.Size = new Size(356, 46);
            lblCustomerDashboardTitle.TabIndex = 0;
            lblCustomerDashboardTitle.Text = "Customer Dashboard";
            lblCustomerDashboardTitle.Click += lblCustomerDashboardTitle_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel3.Controls.Add(pictureBox10);
            panel3.Controls.Add(pictureBox8);
            panel3.Controls.Add(pictureBox7);
            panel3.Controls.Add(pictureBox6);
            panel3.Controls.Add(btnLogout);
            panel3.Controls.Add(btnNewServiceRequest);
            panel3.Controls.Add(btnTrackRequest);
            panel3.Controls.Add(btnServiceHistory);
            panel3.Controls.Add(BtnActiceRequests);
            panel3.Location = new Point(0, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(299, 920);
            panel3.TabIndex = 4;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(25, 452);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(33, 27);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 7;
            pictureBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(25, 255);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(33, 27);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 5;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(25, 164);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(33, 27);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 4;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(25, 74);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(33, 27);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1505, 113);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(382, 214);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // frmCustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1915, 1055);
            Controls.Add(label9);
            Controls.Add(pictureBox5);
            Controls.Add(panel3);
            Controls.Add(pnlDashBoard);
            Controls.Add(lblCustomerDashboardTitle);
            Controls.Add(panel1);
            Name = "frmCustomerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmCustomerDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
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
        private PictureBox pictureBox6;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox10;
        private PictureBox pbxHomeHeroLogo;
    }
}
