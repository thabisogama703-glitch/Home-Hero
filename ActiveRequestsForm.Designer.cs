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
            panel1 = new Panel();
            btnBack = new Button();
            lblActiveRequests = new Label();
            btnLogout = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).BeginInit();
            grpbxActiveRequests.SuspendLayout();
            panel1.SuspendLayout();
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
            dgvActiveRequests.Size = new Size(1471, 325);
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
            grpbxActiveRequests.Location = new Point(12, 221);
            grpbxActiveRequests.Name = "grpbxActiveRequests";
            grpbxActiveRequests.Size = new Size(1477, 355);
            grpbxActiveRequests.TabIndex = 7;
            grpbxActiveRequests.TabStop = false;
            grpbxActiveRequests.Text = "Active Requests";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lblActiveRequests);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1502, 104);
            panel1.TabIndex = 9;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Orange;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1351, 33);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(135, 40);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblActiveRequests
            // 
            lblActiveRequests.AutoSize = true;
            lblActiveRequests.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveRequests.ForeColor = Color.White;
            lblActiveRequests.Location = new Point(735, 45);
            lblActiveRequests.Name = "lblActiveRequests";
            lblActiveRequests.Size = new Size(163, 28);
            lblActiveRequests.TabIndex = 3;
            lblActiveRequests.Text = "Active Requests";
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
            // frmActiveRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1501, 644);
            Controls.Add(panel1);
            Controls.Add(grpbxActiveRequests);
            Name = "frmActiveRequest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acrtive Requests";
            ((System.ComponentModel.ISupportInitialize)dgvActiveRequests).EndInit();
            grpbxActiveRequests.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvActiveRequests;
        private GroupBox grpbxActiveRequests;
        private DataGridViewTextBoxColumn RequestID;
        private DataGridViewTextBoxColumn ServiceCategory;
        private DataGridViewTextBoxColumn ProblemDescription;
        private DataGridViewTextBoxColumn PrefferedDate;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn Status;
        private Panel panel1;
        private Label lblActiveRequests;
        private Button btnLogout;
        private Label label1;
        private Button btnBack;
    }
}