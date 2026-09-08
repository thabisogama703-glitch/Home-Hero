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
            btnNewServiceRequest = new Button();
            btnTrackRequest = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            btnBackToHome = new Button();
            btnServiceHistory = new Button();
            BtnActiceRequests = new Button();
            dgvActiveRequests = new DataGridView();
            grpbxActiveRequests = new GroupBox();
            dgvServiceHistory = new DataGridView();
            grpbxServiceHistory = new GroupBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).BeginInit();
            grpbxActiveRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).BeginInit();
            grpbxServiceHistory.SuspendLayout();
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
            // btnNewServiceRequest
            // 
            btnNewServiceRequest.BackColor = Color.FromArgb(255, 128, 0);
            btnNewServiceRequest.FlatStyle = FlatStyle.Flat;
            btnNewServiceRequest.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewServiceRequest.ForeColor = Color.White;
            btnNewServiceRequest.Location = new Point(994, 23);
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
            btnTrackRequest.Location = new Point(812, 39);
            btnTrackRequest.Name = "btnTrackRequest";
            btnTrackRequest.Size = new Size(152, 38);
            btnTrackRequest.TabIndex = 2;
            btnTrackRequest.Text = "Track Request";
            btnTrackRequest.UseVisualStyleBackColor = true;
            btnTrackRequest.Click += btnTrackRequest_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(btnNewServiceRequest);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnTrackRequest);
            panel1.Location = new Point(-5, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1252, 104);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Controls.Add(btnBackToHome);
            panel2.Controls.Add(btnServiceHistory);
            panel2.Controls.Add(BtnActiceRequests);
            panel2.Location = new Point(-5, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(1252, 82);
            panel2.TabIndex = 4;
            // 
            // btnBackToHome
            // 
            btnBackToHome.Location = new Point(1036, 25);
            btnBackToHome.Name = "btnBackToHome";
            btnBackToHome.Size = new Size(160, 29);
            btnBackToHome.TabIndex = 2;
            btnBackToHome.Text = "←      Back Home";
            btnBackToHome.UseVisualStyleBackColor = true;
            // 
            // btnServiceHistory
            // 
            btnServiceHistory.BackColor = Color.FromArgb(0, 0, 64);
            btnServiceHistory.FlatStyle = FlatStyle.Flat;
            btnServiceHistory.ForeColor = Color.White;
            btnServiceHistory.Location = new Point(282, 14);
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
            BtnActiceRequests.Location = new Point(34, 14);
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
            dgvActiveRequests.Size = new Size(1205, 222);
            dgvActiveRequests.TabIndex = 5;
            // 
            // grpbxActiveRequests
            // 
            grpbxActiveRequests.Controls.Add(dgvActiveRequests);
            grpbxActiveRequests.Location = new Point(12, 201);
            grpbxActiveRequests.Name = "grpbxActiveRequests";
            grpbxActiveRequests.Size = new Size(1228, 254);
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
            dgvServiceHistory.Location = new Point(6, 20);
            dgvServiceHistory.Name = "dgvServiceHistory";
            dgvServiceHistory.ReadOnly = true;
            dgvServiceHistory.RowHeadersWidth = 51;
            dgvServiceHistory.Size = new Size(1205, 203);
            dgvServiceHistory.TabIndex = 5;
            // 
            // grpbxServiceHistory
            // 
            grpbxServiceHistory.Controls.Add(dgvServiceHistory);
            grpbxServiceHistory.Location = new Point(12, 461);
            grpbxServiceHistory.Name = "grpbxServiceHistory";
            grpbxServiceHistory.Size = new Size(1228, 228);
            grpbxServiceHistory.TabIndex = 7;
            grpbxServiceHistory.TabStop = false;
            grpbxServiceHistory.Text = "Service History";
            // 
            // frmCustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1252, 696);
            Controls.Add(grpbxServiceHistory);
            Controls.Add(grpbxActiveRequests);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmCustomerDashboard";
            Text = "Customer Dashboard";
            Load += frmCustomerDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).EndInit();
            grpbxActiveRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).EndInit();
            grpbxServiceHistory.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnNewServiceRequest;
        private Button btnTrackRequest;
        private Panel panel1;
        private Panel panel2;
        private Button BtnActiceRequests;
        private Button btnServiceHistory;
        private DataGridView dgvActiveRequests;
        private Button btnBackToHome;
        private GroupBox grpbxActiveRequests;
        private DataGridView dgvServiceHistory;
        private GroupBox grpbxServiceHistory;
    }
}
