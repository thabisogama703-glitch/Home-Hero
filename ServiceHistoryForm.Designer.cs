namespace HomeHero
{
    partial class ServiceHistoryForm
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
            grpbxServiceHistory = new GroupBox();
            dgvServiceHistory = new DataGridView();
            RequestId = new DataGridViewTextBoxColumn();
            ServiceCategory = new DataGridViewTextBoxColumn();
            CompletedDate = new DataGridViewTextBoxColumn();
            TotalCost = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnBack = new Button();
            lblServicesHistory = new Label();
            btnLogout = new Button();
            label1 = new Label();
            grpbxServiceHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // grpbxServiceHistory
            // 
            grpbxServiceHistory.Controls.Add(dgvServiceHistory);
            grpbxServiceHistory.Location = new Point(12, 159);
            grpbxServiceHistory.Name = "grpbxServiceHistory";
            grpbxServiceHistory.Size = new Size(1441, 352);
            grpbxServiceHistory.TabIndex = 8;
            grpbxServiceHistory.TabStop = false;
            grpbxServiceHistory.Text = "Service History";
            // 
            // dgvServiceHistory
            // 
            dgvServiceHistory.BackgroundColor = SystemColors.ControlLightLight;
            dgvServiceHistory.BorderStyle = BorderStyle.None;
            dgvServiceHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServiceHistory.Columns.AddRange(new DataGridViewColumn[] { RequestId, ServiceCategory, CompletedDate, TotalCost, Status });
            dgvServiceHistory.Dock = DockStyle.Fill;
            dgvServiceHistory.Location = new Point(3, 23);
            dgvServiceHistory.Name = "dgvServiceHistory";
            dgvServiceHistory.ReadOnly = true;
            dgvServiceHistory.RowHeadersWidth = 51;
            dgvServiceHistory.Size = new Size(1435, 326);
            dgvServiceHistory.TabIndex = 5;
            // 
            // RequestId
            // 
            RequestId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RequestId.HeaderText = "Request ID ";
            RequestId.MinimumWidth = 6;
            RequestId.Name = "RequestId";
            RequestId.ReadOnly = true;
            // 
            // ServiceCategory
            // 
            ServiceCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ServiceCategory.HeaderText = "Service Category";
            ServiceCategory.MinimumWidth = 6;
            ServiceCategory.Name = "ServiceCategory";
            ServiceCategory.ReadOnly = true;
            // 
            // CompletedDate
            // 
            CompletedDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CompletedDate.HeaderText = "Completed Date";
            CompletedDate.MinimumWidth = 6;
            CompletedDate.Name = "CompletedDate";
            CompletedDate.ReadOnly = true;
            // 
            // TotalCost
            // 
            TotalCost.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalCost.HeaderText = "Total Cost";
            TotalCost.MinimumWidth = 6;
            TotalCost.Name = "TotalCost";
            TotalCost.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lblServicesHistory);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1475, 104);
            panel1.TabIndex = 10;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Orange;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1318, 33);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(135, 40);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblServicesHistory
            // 
            lblServicesHistory.AutoSize = true;
            lblServicesHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServicesHistory.ForeColor = Color.White;
            lblServicesHistory.Location = new Point(701, 45);
            lblServicesHistory.Name = "lblServicesHistory";
            lblServicesHistory.Size = new Size(166, 28);
            lblServicesHistory.TabIndex = 3;
            lblServicesHistory.Text = "Services History";
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
            // ServiceHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 601);
            Controls.Add(panel1);
            Controls.Add(grpbxServiceHistory);
            Name = "ServiceHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServiceHistoryForm";
            grpbxServiceHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpbxServiceHistory;
        private DataGridView dgvServiceHistory;
        private DataGridViewTextBoxColumn RequestId;
        private DataGridViewTextBoxColumn ServiceCategory;
        private DataGridViewTextBoxColumn CompletedDate;
        private DataGridViewTextBoxColumn TotalCost;
        private DataGridViewTextBoxColumn Status;
        private Panel panel1;
        private Button btnBack;
        private Label lblServicesHistory;
        private Button btnLogout;
        private Label label1;
    }
}