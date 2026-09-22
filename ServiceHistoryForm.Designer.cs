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
            btnBackHome = new Button();
            grpbxServiceHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).BeginInit();
            SuspendLayout();
            // 
            // grpbxServiceHistory
            // 
            grpbxServiceHistory.Controls.Add(dgvServiceHistory);
            grpbxServiceHistory.Location = new Point(12, 12);
            grpbxServiceHistory.Name = "grpbxServiceHistory";
            grpbxServiceHistory.Size = new Size(1441, 499);
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
            dgvServiceHistory.Size = new Size(1435, 473);
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
            // btnBackHome
            // 
            btnBackHome.BackColor = Color.FromArgb(255, 128, 0);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(1201, 517);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(252, 50);
            btnBackHome.TabIndex = 9;
            btnBackHome.Text = "Back Home";
            btnBackHome.UseVisualStyleBackColor = false;
            btnBackHome.Click += btnBackHome_Click;
            // 
            // ServiceHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 601);
            Controls.Add(btnBackHome);
            Controls.Add(grpbxServiceHistory);
            Name = "ServiceHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServiceHistoryForm";
            grpbxServiceHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServiceHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpbxServiceHistory;
        private DataGridView dgvServiceHistory;
        private Button btnBackHome;
        private DataGridViewTextBoxColumn RequestId;
        private DataGridViewTextBoxColumn ServiceCategory;
        private DataGridViewTextBoxColumn CompletedDate;
        private DataGridViewTextBoxColumn TotalCost;
        private DataGridViewTextBoxColumn Status;
    }
}