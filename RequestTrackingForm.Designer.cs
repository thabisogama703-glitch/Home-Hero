namespace Home_Hero
{
    partial class frmRequestTracking
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
            dgvRequests = new DataGridView();
            lblRequestNum = new Label();
            lblCategory = new Label();
            lblStatus = new Label();
            lblAssignedProvider = new Label();
            lblAppointment = new Label();
            lblEstimatedCost = new Label();
            lblFinalCost = new Label();
            btnRefresh = new Button();
            pnlDetails = new Panel();
            panel2 = new Panel();
            lblRequest = new Label();
            lblLog = new Label();
            lblWelcome = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            pnlDetails.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(49, 383);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(967, 188);
            dgvRequests.TabIndex = 0;
            // 
            // lblRequestNum
            // 
            lblRequestNum.AutoSize = true;
            lblRequestNum.Location = new Point(32, 143);
            lblRequestNum.Name = "lblRequestNum";
            lblRequestNum.Size = new Size(123, 20);
            lblRequestNum.TabIndex = 1;
            lblRequestNum.Text = "Request Number:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(287, 143);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(94, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Service Type:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(568, 143);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(116, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Assigned Status:";
            // 
            // lblAssignedProvider
            // 
            lblAssignedProvider.AutoSize = true;
            lblAssignedProvider.Location = new Point(32, 236);
            lblAssignedProvider.Name = "lblAssignedProvider";
            lblAssignedProvider.Size = new Size(131, 20);
            lblAssignedProvider.TabIndex = 4;
            lblAssignedProvider.Text = "Assigned Provider:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(287, 236);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(85, 20);
            lblAppointment.TabIndex = 5;
            lblAppointment.Text = "Date & Time:";
            // 
            // lblEstimatedCost
            // 
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Location = new Point(568, 236);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(111, 20);
            lblEstimatedCost.TabIndex = 6;
            lblEstimatedCost.Text = "Estimated Cost:";
            // 
            // lblFinalCost
            // 
            lblFinalCost.AutoSize = true;
            lblFinalCost.Location = new Point(49, 333);
            lblFinalCost.Name = "lblFinalCost";
            lblFinalCost.Size = new Size(76, 20);
            lblFinalCost.TabIndex = 7;
            lblFinalCost.Text = "Final Cost:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(255, 128, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(52, 632);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(111, 29);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = Color.White;
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(panel2);
            pnlDetails.Controls.Add(lblFinalCost);
            pnlDetails.Controls.Add(btnRefresh);
            pnlDetails.Controls.Add(lblEstimatedCost);
            pnlDetails.Controls.Add(lblAppointment);
            pnlDetails.Controls.Add(lblAssignedProvider);
            pnlDetails.Controls.Add(lblStatus);
            pnlDetails.Controls.Add(lblCategory);
            pnlDetails.Controls.Add(lblRequestNum);
            pnlDetails.Controls.Add(dgvRequests);
            pnlDetails.Location = new Point(200, 23);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(1393, 694);
            pnlDetails.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(btnBack);
            panel2.Controls.Add(lblRequest);
            panel2.Controls.Add(lblLog);
            panel2.Controls.Add(lblWelcome);
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1393, 93);
            panel2.TabIndex = 13;
            // 
            // lblRequest
            // 
            lblRequest.AutoSize = true;
            lblRequest.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRequest.ForeColor = Color.White;
            lblRequest.Location = new Point(99, 47);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new Size(596, 38);
            lblRequest.TabIndex = 14;
            lblRequest.Text = "Track and Follow your Maintenance Request";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.FlatStyle = FlatStyle.Flat;
            lblLog.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLog.ForeColor = Color.White;
            lblLog.Location = new Point(12, 54);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(0, 31);
            lblLog.TabIndex = 13;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.FlatStyle = FlatStyle.Flat;
            lblWelcome.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(255, 128, 0);
            lblWelcome.Location = new Point(12, 14);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(112, 23);
            lblWelcome.TabIndex = 11;
            lblWelcome.Text = "Job Progress";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 128, 0);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1113, 33);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(151, 29);
            btnBack.TabIndex = 15;
            btnBack.Text = " ← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // frmRequestTracking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1717, 738);
            Controls.Add(pnlDetails);
            Name = "frmRequestTracking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Request Tracking";
            Load += RequestTrackingForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRequests;
        private Label lblRequestNum;
        private Label lblCategory;
        private Label lblStatus;
        private Label lblAssignedProvider;
        private Label lblAppointment;
        private Label lblEstimatedCost;
        private Label lblFinalCost;
        private Button btnRefresh;
        private Panel pnlDetails;
        private Panel panel2;
        private Label lblRequest;
        private Label lblLog;
        private Label lblWelcome;
        private Button btnBack;
    }
}