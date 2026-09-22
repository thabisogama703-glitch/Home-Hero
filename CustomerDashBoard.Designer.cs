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
            label1 = new Label();
            panel1 = new Panel();
            btnLogout = new Button();
            btnNewServiceRequest = new Button();
            btnTrackRequest = new Button();
            btnServiceHistory = new Button();
            BtnActiceRequests = new Button();
            panel2 = new Panel();
            pnlDashBoard = new Panel();
            label9 = new Label();
            pnlServiceHistoryCard = new Panel();
            lblJobsDoneNumber = new Label();
            lblJobsDone = new Label();
            pictureBox2 = new PictureBox();
            pnlTotalCostcCard = new Panel();
            lblTotalSpentNumber = new Label();
            lblTotalSpent = new Label();
            pictureBox3 = new PictureBox();
            pnlAverageRating = new Panel();
            lblProviderRatingNumber = new Label();
            lblProviderRating = new Label();
            pictureBox4 = new PictureBox();
            pnlActiveRequestsCard = new Panel();
            lblActiveJobsCount = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            lblCustomerDashboardTitle = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlDashBoard.SuspendLayout();
            pnlServiceHistoryCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlTotalCostcCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlAverageRating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlActiveRequestsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(17, 21);
            label1.Name = "label1";
            label1.Size = new Size(265, 60);
            label1.TabIndex = 0;
            label1.Text = "Home Hero";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(btnServiceHistory);
            panel1.Controls.Add(BtnActiceRequests);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-5, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1892, 104);
            panel1.TabIndex = 3;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1675, 35);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(135, 40);
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
            btnNewServiceRequest.Location = new Point(1617, 39);
            btnNewServiceRequest.Name = "btnNewServiceRequest";
            btnNewServiceRequest.Size = new Size(251, 54);
            btnNewServiceRequest.TabIndex = 1;
            btnNewServiceRequest.Text = "+ New Service Request";
            btnNewServiceRequest.UseVisualStyleBackColor = false;
            btnNewServiceRequest.Click += btnNewServiceRequest_Click_1;
            // 
            // btnTrackRequest
            // 
            btnTrackRequest.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrackRequest.Location = new Point(1420, 55);
            btnTrackRequest.Name = "btnTrackRequest";
            btnTrackRequest.Size = new Size(152, 38);
            btnTrackRequest.TabIndex = 2;
            btnTrackRequest.Text = "Track Request";
            btnTrackRequest.UseVisualStyleBackColor = true;
            btnTrackRequest.Click += btnTrackRequest_Click_1;
            // 
            // btnServiceHistory
            // 
            btnServiceHistory.BackColor = Color.FromArgb(0, 0, 64);
            btnServiceHistory.FlatStyle = FlatStyle.Flat;
            btnServiceHistory.ForeColor = Color.White;
            btnServiceHistory.Location = new Point(878, 24);
            btnServiceHistory.Name = "btnServiceHistory";
            btnServiceHistory.Size = new Size(178, 51);
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
            BtnActiceRequests.Location = new Point(658, 24);
            BtnActiceRequests.Name = "BtnActiceRequests";
            BtnActiceRequests.Size = new Size(178, 51);
            BtnActiceRequests.TabIndex = 0;
            BtnActiceRequests.Text = "Active Requests";
            BtnActiceRequests.UseVisualStyleBackColor = false;
            BtnActiceRequests.Click += BtnActiceRequests_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnTrackRequest);
            panel2.Controls.Add(btnNewServiceRequest);
            panel2.Location = new Point(0, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(1892, 107);
            panel2.TabIndex = 8;
            // 
            // pnlDashBoard
            // 
            pnlDashBoard.BackColor = SystemColors.ButtonHighlight;
            pnlDashBoard.BorderStyle = BorderStyle.FixedSingle;
            pnlDashBoard.Controls.Add(label9);
            pnlDashBoard.Controls.Add(pnlServiceHistoryCard);
            pnlDashBoard.Controls.Add(pnlTotalCostcCard);
            pnlDashBoard.Controls.Add(pnlAverageRating);
            pnlDashBoard.Controls.Add(pnlActiveRequestsCard);
            pnlDashBoard.Controls.Add(lblCustomerDashboardTitle);
            pnlDashBoard.Location = new Point(26, 237);
            pnlDashBoard.Name = "pnlDashBoard";
            pnlDashBoard.Size = new Size(1810, 746);
            pnlDashBoard.TabIndex = 9;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(255, 128, 0);
            label9.Location = new Point(715, 28);
            label9.Name = "label9";
            label9.Size = new Size(420, 72);
            label9.TabIndex = 3;
            label9.Text = "Welcome Back ";
            // 
            // pnlServiceHistoryCard
            // 
            pnlServiceHistoryCard.BackColor = SystemColors.ControlLightLight;
            pnlServiceHistoryCard.BorderStyle = BorderStyle.Fixed3D;
            pnlServiceHistoryCard.Controls.Add(lblJobsDoneNumber);
            pnlServiceHistoryCard.Controls.Add(lblJobsDone);
            pnlServiceHistoryCard.Controls.Add(pictureBox2);
            pnlServiceHistoryCard.Location = new Point(451, 318);
            pnlServiceHistoryCard.Name = "pnlServiceHistoryCard";
            pnlServiceHistoryCard.Size = new Size(274, 158);
            pnlServiceHistoryCard.TabIndex = 2;
            // 
            // lblJobsDoneNumber
            // 
            lblJobsDoneNumber.AutoSize = true;
            lblJobsDoneNumber.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJobsDoneNumber.Location = new Point(119, 73);
            lblJobsDoneNumber.Name = "lblJobsDoneNumber";
            lblJobsDoneNumber.Size = new Size(35, 41);
            lblJobsDoneNumber.TabIndex = 3;
            lblJobsDoneNumber.Text = "6";
            lblJobsDoneNumber.Click += lblJobsDoneNumber_Click;
            // 
            // lblJobsDone
            // 
            lblJobsDone.AutoSize = true;
            lblJobsDone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJobsDone.Location = new Point(93, 12);
            lblJobsDone.Name = "lblJobsDone";
            lblJobsDone.Size = new Size(103, 28);
            lblJobsDone.TabIndex = 2;
            lblJobsDone.Text = "Jobs Done";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Home_Hero.Properties.Resources.Jobs_Done;
            pictureBox2.Location = new Point(15, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(59, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pnlTotalCostcCard
            // 
            pnlTotalCostcCard.BackColor = SystemColors.ControlLightLight;
            pnlTotalCostcCard.BorderStyle = BorderStyle.Fixed3D;
            pnlTotalCostcCard.Controls.Add(lblTotalSpentNumber);
            pnlTotalCostcCard.Controls.Add(lblTotalSpent);
            pnlTotalCostcCard.Controls.Add(pictureBox3);
            pnlTotalCostcCard.Location = new Point(842, 318);
            pnlTotalCostcCard.Name = "pnlTotalCostcCard";
            pnlTotalCostcCard.Size = new Size(279, 158);
            pnlTotalCostcCard.TabIndex = 2;
            // 
            // lblTotalSpentNumber
            // 
            lblTotalSpentNumber.AutoSize = true;
            lblTotalSpentNumber.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalSpentNumber.Location = new Point(92, 73);
            lblTotalSpentNumber.Name = "lblTotalSpentNumber";
            lblTotalSpentNumber.Size = new Size(114, 41);
            lblTotalSpentNumber.TabIndex = 4;
            lblTotalSpentNumber.Text = "R2 000";
            // 
            // lblTotalSpent
            // 
            lblTotalSpent.AutoSize = true;
            lblTotalSpent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSpent.Location = new Point(96, 12);
            lblTotalSpent.Name = "lblTotalSpent";
            lblTotalSpent.Size = new Size(110, 28);
            lblTotalSpent.TabIndex = 2;
            lblTotalSpent.Text = "Total Spent";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Home_Hero.Properties.Resources.Total_Spent;
            pictureBox3.Location = new Point(3, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(59, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // pnlAverageRating
            // 
            pnlAverageRating.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAverageRating.BackColor = SystemColors.ControlLightLight;
            pnlAverageRating.BorderStyle = BorderStyle.Fixed3D;
            pnlAverageRating.Controls.Add(lblProviderRatingNumber);
            pnlAverageRating.Controls.Add(lblProviderRating);
            pnlAverageRating.Controls.Add(pictureBox4);
            pnlAverageRating.Location = new Point(1364, 318);
            pnlAverageRating.Name = "pnlAverageRating";
            pnlAverageRating.Size = new Size(311, 158);
            pnlAverageRating.TabIndex = 2;
            // 
            // lblProviderRatingNumber
            // 
            lblProviderRatingNumber.AutoSize = true;
            lblProviderRatingNumber.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProviderRatingNumber.Location = new Point(124, 73);
            lblProviderRatingNumber.Name = "lblProviderRatingNumber";
            lblProviderRatingNumber.Size = new Size(60, 41);
            lblProviderRatingNumber.TabIndex = 5;
            lblProviderRatingNumber.Text = "4.8";
            // 
            // lblProviderRating
            // 
            lblProviderRating.AutoSize = true;
            lblProviderRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProviderRating.Location = new Point(78, 15);
            lblProviderRating.Name = "lblProviderRating";
            lblProviderRating.Size = new Size(148, 28);
            lblProviderRating.TabIndex = 2;
            lblProviderRating.Text = "Provider Rating";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Home_Hero.Properties.Resources.Provider_Rating;
            pictureBox4.Location = new Point(3, 6);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(59, 37);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // pnlActiveRequestsCard
            // 
            pnlActiveRequestsCard.BackColor = SystemColors.ControlLightLight;
            pnlActiveRequestsCard.BorderStyle = BorderStyle.Fixed3D;
            pnlActiveRequestsCard.Controls.Add(lblActiveJobsCount);
            pnlActiveRequestsCard.Controls.Add(pictureBox1);
            pnlActiveRequestsCard.Controls.Add(label2);
            pnlActiveRequestsCard.Location = new Point(40, 318);
            pnlActiveRequestsCard.Name = "pnlActiveRequestsCard";
            pnlActiveRequestsCard.Size = new Size(277, 158);
            pnlActiveRequestsCard.TabIndex = 1;
            // 
            // lblActiveJobsCount
            // 
            lblActiveJobsCount.AutoSize = true;
            lblActiveJobsCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveJobsCount.Location = new Point(117, 73);
            lblActiveJobsCount.Name = "lblActiveJobsCount";
            lblActiveJobsCount.Size = new Size(35, 41);
            lblActiveJobsCount.TabIndex = 2;
            lblActiveJobsCount.Text = "3";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Home_Hero.Properties.Resources.Active_Jobs;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(17, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(59, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(82, 12);
            label2.Name = "label2";
            label2.Size = new Size(120, 28);
            label2.TabIndex = 0;
            label2.Text = " Active Jobs \r\n";
            // 
            // lblCustomerDashboardTitle
            // 
            lblCustomerDashboardTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerDashboardTitle.ForeColor = Color.FromArgb(0, 0, 64);
            lblCustomerDashboardTitle.Location = new Point(683, 100);
            lblCustomerDashboardTitle.Name = "lblCustomerDashboardTitle";
            lblCustomerDashboardTitle.Size = new Size(356, 46);
            lblCustomerDashboardTitle.TabIndex = 0;
            lblCustomerDashboardTitle.Text = "Customer Dashboard";
            lblCustomerDashboardTitle.Click += lblCustomerDashboardTitle_Click;
            // 
            // frmCustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1886, 995);
            Controls.Add(pnlDashBoard);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmCustomerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmCustomerDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            pnlDashBoard.ResumeLayout(false);
            pnlServiceHistoryCard.ResumeLayout(false);
            pnlServiceHistoryCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlTotalCostcCard.ResumeLayout(false);
            pnlTotalCostcCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlAverageRating.ResumeLayout(false);
            pnlAverageRating.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlActiveRequestsCard.ResumeLayout(false);
            pnlActiveRequestsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Panel panel2;
        private Panel pnlDashBoard;
        private Label label9;
        private Panel pnlServiceHistoryCard;
        private Label lblJobsDoneNumber;
        private Label lblJobsDone;
        private PictureBox pictureBox2;
        private Panel pnlTotalCostcCard;
        private Label lblTotalSpentNumber;
        private Label lblTotalSpent;
        private PictureBox pictureBox3;
        private Panel pnlActiveRequestsCard;
        private Label lblActiveJobsCount;
        private PictureBox pictureBox1;
        private Label label2;
        private Label lblCustomerDashboardTitle;
        private Panel pnlAverageRating;
        private Label lblProviderRatingNumber;
        private Label lblProviderRating;
        private PictureBox pictureBox4;
    }
}
