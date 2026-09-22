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
            panel1 = new Panel();
            button1 = new Button();
            lblRequest = new Label();
            label1 = new Label();
            gbxServiceDetails = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            pnlDetails.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRequests
            // 
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(363, 386);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(1003, 257);
            dgvRequests.TabIndex = 0;
            dgvRequests.CellContentClick += dgvRequests_CellContentClick;
            // 
            // lblRequestNum
            // 
            lblRequestNum.AutoSize = true;
            lblRequestNum.Location = new Point(490, 173);
            lblRequestNum.Name = "lblRequestNum";
            lblRequestNum.Size = new Size(123, 20);
            lblRequestNum.TabIndex = 1;
            lblRequestNum.Text = "Request Number:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(745, 173);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(94, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Service Type:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(1026, 173);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(116, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Assigned Status:";
            // 
            // lblAssignedProvider
            // 
            lblAssignedProvider.AutoSize = true;
            lblAssignedProvider.Location = new Point(490, 266);
            lblAssignedProvider.Name = "lblAssignedProvider";
            lblAssignedProvider.Size = new Size(131, 20);
            lblAssignedProvider.TabIndex = 4;
            lblAssignedProvider.Text = "Assigned Provider:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(745, 266);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(85, 20);
            lblAppointment.TabIndex = 5;
            lblAppointment.Text = "Date & Time:";
            // 
            // lblEstimatedCost
            // 
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Location = new Point(1026, 266);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(111, 20);
            lblEstimatedCost.TabIndex = 6;
            lblEstimatedCost.Text = "Estimated Cost:";
            // 
            // lblFinalCost
            // 
            lblFinalCost.AutoSize = true;
            lblFinalCost.Location = new Point(507, 363);
            lblFinalCost.Name = "lblFinalCost";
            lblFinalCost.Size = new Size(76, 20);
            lblFinalCost.TabIndex = 7;
            lblFinalCost.Text = "Final Cost:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(255, 128, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(562, 660);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(516, 46);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = Color.White;
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(panel1);
            pnlDetails.Controls.Add(lblFinalCost);
            pnlDetails.Controls.Add(btnRefresh);
            pnlDetails.Controls.Add(lblEstimatedCost);
            pnlDetails.Controls.Add(lblAppointment);
            pnlDetails.Controls.Add(lblAssignedProvider);
            pnlDetails.Controls.Add(lblStatus);
            pnlDetails.Controls.Add(lblCategory);
            pnlDetails.Controls.Add(lblRequestNum);
            pnlDetails.Controls.Add(dgvRequests);
            pnlDetails.Controls.Add(gbxServiceDetails);
            pnlDetails.Dock = DockStyle.Fill;
            pnlDetails.Location = new Point(0, 0);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(1717, 738);
            pnlDetails.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(lblRequest);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1715, 104);
            panel1.TabIndex = 15;
            // 
            // button1
            // 
            button1.BackColor = Color.Orange;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(1569, 36);
            button1.Name = "button1";
            button1.Size = new Size(135, 40);
            button1.TabIndex = 4;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblRequest
            // 
            lblRequest.AutoSize = true;
            lblRequest.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRequest.ForeColor = Color.White;
            lblRequest.Location = new Point(562, 38);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new Size(596, 38);
            lblRequest.TabIndex = 14;
            lblRequest.Text = "Track and Follow your Maintenance Request";
            lblRequest.Click += lblRequest_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 21);
            label1.Name = "label1";
            label1.Size = new Size(265, 60);
            label1.TabIndex = 0;
            label1.Text = "Home Hero";
            // 
            // gbxServiceDetails
            // 
            gbxServiceDetails.Location = new Point(363, 147);
            gbxServiceDetails.Name = "gbxServiceDetails";
            gbxServiceDetails.Size = new Size(1003, 245);
            gbxServiceDetails.TabIndex = 14;
            gbxServiceDetails.TabStop = false;
            gbxServiceDetails.Text = "Service Details";
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Label lblRequest;
        private GroupBox gbxServiceDetails;
        private Panel panel1;
        private Button button1;
        private Label label1;
    }
}