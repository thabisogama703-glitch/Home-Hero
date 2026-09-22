namespace HomeHero
{
    partial class frmActiveRequest
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
            dgvActiveRequests = new DataGridView();
            RequestID = new DataGridViewTextBoxColumn();
            ServiceCategory = new DataGridViewTextBoxColumn();
            ProblemDescription = new DataGridViewTextBoxColumn();
            PrefferedDate = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            grpbxActiveRequests = new GroupBox();
            btnBackHome = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).BeginInit();
            grpbxActiveRequests.SuspendLayout();
            SuspendLayout();
            // 
            // dgvActiveRequests
            // 
            dgvActiveRequests.BackgroundColor = SystemColors.ControlLightLight;
            dgvActiveRequests.BorderStyle = BorderStyle.None;
            dgvActiveRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveRequests.Columns.AddRange(new DataGridViewColumn[] { RequestID, ServiceCategory, ProblemDescription, PrefferedDate, Cost, Status });
            dgvActiveRequests.Dock = DockStyle.Fill;
            dgvActiveRequests.Location = new Point(3, 27);
            dgvActiveRequests.Name = "dgvActiveRequests";
            dgvActiveRequests.ReadOnly = true;
            dgvActiveRequests.RowHeadersWidth = 51;
            dgvActiveRequests.Size = new Size(1471, 524);
            dgvActiveRequests.TabIndex = 6;
            dgvActiveRequests.CellContentClick += dgvActiveRequests_CellContentClick;
            // 
            // RequestID
            // 
            RequestID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RequestID.HeaderText = "Request ID ";
            RequestID.MinimumWidth = 6;
            RequestID.Name = "RequestID";
            RequestID.ReadOnly = true;
            // 
            // ServiceCategory
            // 
            ServiceCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ServiceCategory.HeaderText = "Service Category";
            ServiceCategory.MinimumWidth = 6;
            ServiceCategory.Name = "ServiceCategory";
            ServiceCategory.ReadOnly = true;
            // 
            // ProblemDescription
            // 
            ProblemDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProblemDescription.HeaderText = "Problem Description ";
            ProblemDescription.MinimumWidth = 6;
            ProblemDescription.Name = "ProblemDescription";
            ProblemDescription.ReadOnly = true;
            // 
            // PrefferedDate
            // 
            PrefferedDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PrefferedDate.HeaderText = "Preffered Date";
            PrefferedDate.MinimumWidth = 6;
            PrefferedDate.Name = "PrefferedDate";
            PrefferedDate.ReadOnly = true;
            // 
            // Cost
            // 
            Cost.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cost.HeaderText = "Cost ";
            Cost.MinimumWidth = 6;
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // grpbxActiveRequests
            // 
            grpbxActiveRequests.Controls.Add(dgvActiveRequests);
            grpbxActiveRequests.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpbxActiveRequests.ForeColor = Color.Black;
            grpbxActiveRequests.Location = new Point(12, 22);
            grpbxActiveRequests.Name = "grpbxActiveRequests";
            grpbxActiveRequests.Size = new Size(1477, 554);
            grpbxActiveRequests.TabIndex = 7;
            grpbxActiveRequests.TabStop = false;
            grpbxActiveRequests.Text = "Active Requests";
            // 
            // btnBackHome
            // 
            btnBackHome.BackColor = Color.FromArgb(255, 128, 0);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(1234, 582);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(252, 50);
            btnBackHome.TabIndex = 8;
            btnBackHome.Text = "Back Home";
            btnBackHome.UseVisualStyleBackColor = false;
            btnBackHome.Click += btnBackHome_Click;
            // 
            // frmActiveRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1501, 644);
            Controls.Add(btnBackHome);
            Controls.Add(grpbxActiveRequests);
            Name = "frmActiveRequest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acrtive Requests";
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).EndInit();
            grpbxActiveRequests.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvActiveRequests;
        private GroupBox grpbxActiveRequests;
        private Button btnBackHome;
        private DataGridViewTextBoxColumn RequestID;
        private DataGridViewTextBoxColumn ServiceCategory;
        private DataGridViewTextBoxColumn ProblemDescription;
        private DataGridViewTextBoxColumn PrefferedDate;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn Status;
    }
}