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
            btnDashboard = new Button();
            btnServiceHistory = new Button();
            BtnActiceRequests = new Button();
            dgvActiveRequests = new DataGridView();
            grpbxActiveRequests = new GroupBox();
            dgvServiceHistory = new DataGridView();
            grpbxServiceHistory = new GroupBox();
            btnNewServiceRequest = new Button();
            btnTrackRequest = new Button();
            panel2 = new Panel();
            lblWelcome = new Label();
            lblCustomer = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).BeginInit();
            grpbxActiveRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).BeginInit();
            grpbxServiceHistory.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(btnServiceHistory);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(BtnActiceRequests);
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
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderColor = Color.White;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(566, 24);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(178, 51);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // btnServiceHistory
            // 
            btnServiceHistory.BackColor = Color.FromArgb(0, 0, 64);
            btnServiceHistory.FlatStyle = FlatStyle.Flat;
            btnServiceHistory.ForeColor = Color.White;
            btnServiceHistory.Location = new Point(934, 24);
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
            BtnActiceRequests.Location = new Point(750, 24);
            BtnActiceRequests.Name = "BtnActiceRequests";
            BtnActiceRequests.Size = new Size(178, 51);
            BtnActiceRequests.TabIndex = 0;
            BtnActiceRequests.Text = "Active Requests";
            BtnActiceRequests.UseVisualStyleBackColor = false;
            BtnActiceRequests.Click += BtnActiceRequests_Click;
            // 
            // dgvActiveRequests
            // 
            dgvActiveRequests.AllowUserToAddRows = false;
            dgvActiveRequests.BackgroundColor = SystemColors.ControlLightLight;
            dgvActiveRequests.BorderStyle = BorderStyle.None;
            dgvActiveRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveRequests.Location = new Point(6, 26);
            dgvActiveRequests.Name = "dgvActiveRequests";
            dgvActiveRequests.ReadOnly = true;
            dgvActiveRequests.RowHeadersWidth = 51;
            dgvActiveRequests.Size = new Size(1850, 377);
            dgvActiveRequests.TabIndex = 5;
            // 
            // grpbxActiveRequests
            // 
            grpbxActiveRequests.Controls.Add(dgvActiveRequests);
            grpbxActiveRequests.Location = new Point(12, 303);
            grpbxActiveRequests.Name = "grpbxActiveRequests";
            grpbxActiveRequests.Size = new Size(1862, 365);
            grpbxActiveRequests.TabIndex = 6;
            grpbxActiveRequests.TabStop = false;
            grpbxActiveRequests.Text = "Active Requests";
            // 
            // dgvServiceHistory
            // 
            dgvServiceHistory.AllowUserToAddRows = false;
            dgvServiceHistory.BackgroundColor = SystemColors.ControlLightLight;
            dgvServiceHistory.BorderStyle = BorderStyle.None;
            dgvServiceHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServiceHistory.Location = new Point(6, 19);
            dgvServiceHistory.Name = "dgvServiceHistory";
            dgvServiceHistory.ReadOnly = true;
            dgvServiceHistory.RowHeadersWidth = 51;
            dgvServiceHistory.Size = new Size(1850, 284);
            dgvServiceHistory.TabIndex = 5;
            // 
            // grpbxServiceHistory
            // 
            grpbxServiceHistory.Controls.Add(dgvServiceHistory);
            grpbxServiceHistory.Location = new Point(12, 674);
            grpbxServiceHistory.Name = "grpbxServiceHistory";
            grpbxServiceHistory.Size = new Size(1862, 309);
            grpbxServiceHistory.TabIndex = 7;
            grpbxServiceHistory.TabStop = false;
            grpbxServiceHistory.Text = "Service History";
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
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblWelcome);
            panel2.Controls.Add(btnNewServiceRequest);
            panel2.Controls.Add(lblCustomer);
            panel2.Controls.Add(btnTrackRequest);
            panel2.Location = new Point(0, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(1892, 120);
            panel2.TabIndex = 8;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(44, 62);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(240, 31);
            lblWelcome.TabIndex = 14;
            lblWelcome.Text = "Customer DashBoard";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = Color.DimGray;
            lblCustomer.Location = new Point(50, 24);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(136, 25);
            lblCustomer.TabIndex = 13;
            lblCustomer.Text = "Welcome back";
            // 
            // frmCustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1886, 995);
            Controls.Add(panel2);
            Controls.Add(grpbxServiceHistory);
            Controls.Add(grpbxActiveRequests);
            Controls.Add(panel1);
            Name = "frmCustomerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmCustomerDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).EndInit();
            grpbxActiveRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).EndInit();
            grpbxServiceHistory.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BtnActiceRequests;
        private Button btnServiceHistory;
        private DataGridView dgvActiveRequests;
        private Button btnLogout;
        private GroupBox grpbxActiveRequests;
        private DataGridView dgvServiceHistory;
        private GroupBox grpbxServiceHistory;
        private Button btnDashboard;
        private Panel panel1;
        private Button btnNewServiceRequest;
        private Button btnTrackRequest;
        private Panel panel2;
        private Label lblWelcome;
        private Label lblCustomer;
    }
}
