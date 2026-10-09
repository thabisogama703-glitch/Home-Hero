namespace Home_Hero
{
    partial class frmServiceProviderDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblAssignedJob = new Label();
            dgvAssignedJobs = new DataGridView();
            colReq = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colService = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            dgvUpcomingJobs = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            lblUpcomingJobs = new Label();
            label1 = new Label();
            dgvCompletedJobs = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            btnViewJob = new Button();
            btnRefresh = new Button();
            pnlNavigationTab = new Panel();
            button2 = new Button();
            lblName = new Label();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            gbxJobs = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvAssignedJobs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingJobs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompletedJobs).BeginInit();
            pnlNavigationTab.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            gbxJobs.SuspendLayout();
            SuspendLayout();
            // 
            // lblAssignedJob
            // 
            lblAssignedJob.AutoSize = true;
            lblAssignedJob.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAssignedJob.ForeColor = Color.FromArgb(255, 128, 0);
            lblAssignedJob.Location = new Point(16, 38);
            lblAssignedJob.Name = "lblAssignedJob";
            lblAssignedJob.Size = new Size(134, 23);
            lblAssignedJob.TabIndex = 2;
            lblAssignedJob.Text = "ASSIGNED JOBS";
            // 
            // dgvAssignedJobs
            // 
            dataGridViewCellStyle1.BackColor = Color.Navy;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvAssignedJobs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAssignedJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssignedJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssignedJobs.Columns.AddRange(new DataGridViewColumn[] { colReq, colCustomer, colService, colDate, colTime, colStatus });
            dgvAssignedJobs.Location = new Point(16, 61);
            dgvAssignedJobs.Name = "dgvAssignedJobs";
            dgvAssignedJobs.RowHeadersWidth = 51;
            dgvAssignedJobs.Size = new Size(1413, 170);
            dgvAssignedJobs.TabIndex = 3;
            // 
            // colReq
            // 
            colReq.HeaderText = "Request Number";
            colReq.MinimumWidth = 6;
            colReq.Name = "colReq";
            // 
            // colCustomer
            // 
            colCustomer.HeaderText = "Customer";
            colCustomer.MinimumWidth = 6;
            colCustomer.Name = "colCustomer";
            // 
            // colService
            // 
            colService.HeaderText = "Service";
            colService.MinimumWidth = 6;
            colService.Name = "colService";
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            // 
            // colTime
            // 
            colTime.HeaderText = "Time";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            // 
            // dgvUpcomingJobs
            // 
            dgvUpcomingJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUpcomingJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpcomingJobs.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvUpcomingJobs.Location = new Point(16, 273);
            dgvUpcomingJobs.Name = "dgvUpcomingJobs";
            dgvUpcomingJobs.RowHeadersWidth = 51;
            dgvUpcomingJobs.Size = new Size(1413, 206);
            dgvUpcomingJobs.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Request Number";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Customer";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Service";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Date";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Time";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Status";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // lblUpcomingJobs
            // 
            lblUpcomingJobs.AutoSize = true;
            lblUpcomingJobs.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUpcomingJobs.ForeColor = Color.FromArgb(255, 128, 0);
            lblUpcomingJobs.Location = new Point(16, 247);
            lblUpcomingJobs.Name = "lblUpcomingJobs";
            lblUpcomingJobs.Size = new Size(146, 23);
            lblUpcomingJobs.TabIndex = 5;
            lblUpcomingJobs.Text = "UPCOMING JOBS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(6, 491);
            label1.Name = "label1";
            label1.Size = new Size(151, 23);
            label1.TabIndex = 6;
            label1.Text = "COMPLETED JOBS";
            // 
            // dgvCompletedJobs
            // 
            dgvCompletedJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompletedJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompletedJobs.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12 });
            dgvCompletedJobs.Location = new Point(11, 517);
            dgvCompletedJobs.Name = "dgvCompletedJobs";
            dgvCompletedJobs.RowHeadersWidth = 51;
            dgvCompletedJobs.Size = new Size(1418, 193);
            dgvCompletedJobs.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Request Number";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Customer";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Service";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "Date";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Time";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "Status";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // btnViewJob
            // 
            btnViewJob.BackColor = Color.FromArgb(255, 224, 192);
            btnViewJob.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewJob.ForeColor = Color.Navy;
            btnViewJob.Location = new Point(6, 727);
            btnViewJob.Name = "btnViewJob";
            btnViewJob.Size = new Size(354, 29);
            btnViewJob.TabIndex = 8;
            btnViewJob.Text = "View Jobs";
            btnViewJob.UseVisualStyleBackColor = false;
            btnViewJob.Click += btnViewJob_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(255, 224, 192);
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.Navy;
            btnRefresh.Location = new Point(1075, 734);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(354, 29);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlNavigationTab
            // 
            pnlNavigationTab.BackColor = Color.FromArgb(0, 0, 64);
            pnlNavigationTab.Controls.Add(button2);
            pnlNavigationTab.Controls.Add(lblName);
            pnlNavigationTab.Controls.Add(pnlHomeHeroLogo);
            pnlNavigationTab.Dock = DockStyle.Top;
            pnlNavigationTab.Location = new Point(0, 0);
            pnlNavigationTab.Name = "pnlNavigationTab";
            pnlNavigationTab.RightToLeft = RightToLeft.Yes;
            pnlNavigationTab.Size = new Size(1924, 108);
            pnlNavigationTab.TabIndex = 11;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(1656, 31);
            button2.Name = "button2";
            button2.Size = new Size(265, 51);
            button2.TabIndex = 12;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.None;
            lblName.AutoSize = true;
            lblName.FlatStyle = FlatStyle.Flat;
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(919, 42);
            lblName.Name = "lblName";
            lblName.Size = new Size(160, 38);
            lblName.TabIndex = 11;
            lblName.Text = "HomeHero";
            // 
            // pnlHomeHeroLogo
            // 
            pnlHomeHeroLogo.Controls.Add(lblHero);
            pnlHomeHeroLogo.Controls.Add(lblHome);
            pnlHomeHeroLogo.Controls.Add(pbxHomeHeroLogo);
            pnlHomeHeroLogo.Location = new Point(110, 3);
            pnlHomeHeroLogo.Name = "pnlHomeHeroLogo";
            pnlHomeHeroLogo.Size = new Size(351, 102);
            pnlHomeHeroLogo.TabIndex = 10;
            // 
            // lblHero
            // 
            lblHero.AutoSize = true;
            lblHero.FlatStyle = FlatStyle.Flat;
            lblHero.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHero.ForeColor = Color.FromArgb(255, 128, 0);
            lblHero.Location = new Point(165, 44);
            lblHero.Name = "lblHero";
            lblHero.Size = new Size(67, 31);
            lblHero.TabIndex = 10;
            lblHero.Text = "Hero";
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.FlatStyle = FlatStyle.Flat;
            lblHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.White;
            lblHome.Location = new Point(95, 43);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(79, 31);
            lblHome.TabIndex = 10;
            lblHome.Text = "Home";
            // 
            // pbxHomeHeroLogo
            // 
            pbxHomeHeroLogo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(36, 28);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(48, 47);
            pbxHomeHeroLogo.TabIndex = 10;
            pbxHomeHeroLogo.TabStop = false;
            // 
            // gbxJobs
            // 
            gbxJobs.Controls.Add(dgvUpcomingJobs);
            gbxJobs.Controls.Add(lblAssignedJob);
            gbxJobs.Controls.Add(btnRefresh);
            gbxJobs.Controls.Add(dgvAssignedJobs);
            gbxJobs.Controls.Add(btnViewJob);
            gbxJobs.Controls.Add(lblUpcomingJobs);
            gbxJobs.Controls.Add(dgvCompletedJobs);
            gbxJobs.Controls.Add(label1);
            gbxJobs.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxJobs.Location = new Point(155, 176);
            gbxJobs.Name = "gbxJobs";
            gbxJobs.Size = new Size(1612, 763);
            gbxJobs.TabIndex = 12;
            gbxJobs.TabStop = false;
            gbxJobs.Text = "Jobs";
            // 
            // frmServiceProviderDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1924, 995);
            Controls.Add(gbxJobs);
            Controls.Add(pnlNavigationTab);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 0, 64);
            Name = "frmServiceProviderDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Service Provider Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmServiceProviderDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAssignedJobs).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingJobs).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompletedJobs).EndInit();
            pnlNavigationTab.ResumeLayout(false);
            pnlNavigationTab.PerformLayout();
            pnlHomeHeroLogo.ResumeLayout(false);
            pnlHomeHeroLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            gbxJobs.ResumeLayout(false);
            gbxJobs.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblAssignedJob;
        private DataGridView dgvAssignedJobs;
        private DataGridViewTextBoxColumn colReq;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colService;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridView dgvUpcomingJobs;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Label lblUpcomingJobs;
        private Label label1;
        private DataGridView dgvCompletedJobs;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Button btnViewJob;
        private Button btnRefresh;
        private Panel pnlNavigationTab;
        private Label lblName;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Button button2;
        private GroupBox gbxJobs;
    }
}