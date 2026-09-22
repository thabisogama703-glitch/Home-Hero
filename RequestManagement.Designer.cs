namespace Home_Hero
{
    partial class RequestManagement
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
            label1 = new Label();
            txtSearchRequests = new TextBox();
            btnApproveRequests = new Button();
            btnCancelRequests = new Button();
            cbxCategory = new ComboBox();
            dgvRequests = new DataGridView();
            btnSearch = new Button();
            cbxStatus = new ComboBox();
            btnReassign = new Button();
            pnlNavigationAdminPanl = new Panel();
            lblAdminPortal = new Label();
            btnExitAdmin = new Button();
            pictureBox1 = new PictureBox();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            lblAdminDashboard = new Label();
            label16 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lnklblReports = new LinkLabel();
            lnklblServices = new LinkLabel();
            lnklblProviders = new LinkLabel();
            lnklblRequests = new LinkLabel();
            lnklblOverView = new LinkLabel();
            flwLPSearchRequest = new FlowLayoutPanel();
            lblResults = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            pnlNavigationAdminPanl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flwLPSearchRequest.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 332);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Request";
            // 
            // txtSearchRequests
            // 
            txtSearchRequests.Location = new Point(433, 329);
            txtSearchRequests.Name = "txtSearchRequests";
            txtSearchRequests.Size = new Size(470, 27);
            txtSearchRequests.TabIndex = 1;
            txtSearchRequests.Text = "Search by ID, Customer ...";
            txtSearchRequests.TextChanged += txtSearchRequests_TextChanged;
            // 
            // btnApproveRequests
            // 
            btnApproveRequests.Location = new Point(1179, 987);
            btnApproveRequests.Name = "btnApproveRequests";
            btnApproveRequests.Size = new Size(445, 29);
            btnApproveRequests.TabIndex = 3;
            btnApproveRequests.Text = "Approve Request";
            btnApproveRequests.UseVisualStyleBackColor = true;
            btnApproveRequests.Click += btnApproveRequests_Click;
            // 
            // btnCancelRequests
            // 
            btnCancelRequests.Location = new Point(728, 987);
            btnCancelRequests.Name = "btnCancelRequests";
            btnCancelRequests.Size = new Size(445, 29);
            btnCancelRequests.TabIndex = 4;
            btnCancelRequests.Text = "Cancel Request";
            btnCancelRequests.UseVisualStyleBackColor = true;
            btnCancelRequests.Click += btnCancelRequests_Click;
            // 
            // cbxCategory
            // 
            cbxCategory.FormattingEnabled = true;
            cbxCategory.Items.AddRange(new object[] { "Category : All", "Category : Plumbing", "Category : Electrical", "Category : HVAC", "Category : Landscaping", "Category : Roofing", "Category : Painting" });
            cbxCategory.Location = new Point(1315, 330);
            cbxCategory.Name = "cbxCategory";
            cbxCategory.Size = new Size(211, 28);
            cbxCategory.TabIndex = 5;
            cbxCategory.SelectedIndexChanged += cbxCategory_SelectedIndexChanged;
            // 
            // dgvRequests
            // 
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(280, 384);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1336, 575);
            dgvRequests.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(921, 329);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(131, 29);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbxStatus
            // 
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Items.AddRange(new object[] { "Status : All", "Status : Submitted", "Status : Assigned", "Status : Scheduled", "Status : In Progress", "Status : Completed" });
            cbxStatus.Location = new Point(1082, 330);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(199, 28);
            cbxStatus.TabIndex = 9;
            cbxStatus.SelectedIndexChanged += cbxStatus_SelectedIndexChanged;
            // 
            // btnReassign
            // 
            btnReassign.Location = new Point(277, 987);
            btnReassign.Name = "btnReassign";
            btnReassign.Size = new Size(445, 29);
            btnReassign.TabIndex = 10;
            btnReassign.Text = "Reassign";
            btnReassign.UseVisualStyleBackColor = true;
            btnReassign.Click += btnReassign_Click;
            // 
            // pnlNavigationAdminPanl
            // 
            pnlNavigationAdminPanl.Anchor = AnchorStyles.None;
            pnlNavigationAdminPanl.BackColor = Color.FromArgb(0, 0, 64);
            pnlNavigationAdminPanl.Controls.Add(lblAdminPortal);
            pnlNavigationAdminPanl.Controls.Add(btnExitAdmin);
            pnlNavigationAdminPanl.Controls.Add(pictureBox1);
            pnlNavigationAdminPanl.Controls.Add(lblHero);
            pnlNavigationAdminPanl.Controls.Add(lblHome);
            pnlNavigationAdminPanl.Controls.Add(pbxHomeHeroLogo);
            pnlNavigationAdminPanl.Controls.Add(lblAdminDashboard);
            pnlNavigationAdminPanl.Controls.Add(label16);
            pnlNavigationAdminPanl.Location = new Point(0, 0);
            pnlNavigationAdminPanl.Name = "pnlNavigationAdminPanl";
            pnlNavigationAdminPanl.Size = new Size(1903, 174);
            pnlNavigationAdminPanl.TabIndex = 12;
            // 
            // lblAdminPortal
            // 
            lblAdminPortal.AutoSize = true;
            lblAdminPortal.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminPortal.ForeColor = Color.White;
            lblAdminPortal.Location = new Point(1467, 29);
            lblAdminPortal.Name = "lblAdminPortal";
            lblAdminPortal.Size = new Size(264, 38);
            lblAdminPortal.TabIndex = 16;
            lblAdminPortal.Text = "Administrator Portal";
            // 
            // btnExitAdmin
            // 
            btnExitAdmin.FlatAppearance.BorderSize = 0;
            btnExitAdmin.FlatStyle = FlatStyle.Flat;
            btnExitAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExitAdmin.ForeColor = SystemColors.ActiveBorder;
            btnExitAdmin.Location = new Point(1737, 20);
            btnExitAdmin.Name = "btnExitAdmin";
            btnExitAdmin.Size = new Size(159, 47);
            btnExitAdmin.TabIndex = 15;
            btnExitAdmin.Text = "← Exit Admin";
            btnExitAdmin.UseVisualStyleBackColor = true;
            btnExitAdmin.Click += btnExitAdmin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_2026_09_21_001251;
            pictureBox1.Location = new Point(192, 84);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(62, 63);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // lblHero
            // 
            lblHero.AutoSize = true;
            lblHero.FlatStyle = FlatStyle.Flat;
            lblHero.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHero.ForeColor = Color.FromArgb(255, 128, 0);
            lblHero.Location = new Point(407, 36);
            lblHero.Name = "lblHero";
            lblHero.Size = new Size(67, 31);
            lblHero.TabIndex = 12;
            lblHero.Text = "Hero";
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.FlatStyle = FlatStyle.Flat;
            lblHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.White;
            lblHome.Location = new Point(337, 36);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(79, 31);
            lblHome.TabIndex = 13;
            lblHome.Text = "Home";
            // 
            // pbxHomeHeroLogo
            // 
            pbxHomeHeroLogo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(283, 20);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(48, 47);
            pbxHomeHeroLogo.TabIndex = 11;
            pbxHomeHeroLogo.TabStop = false;
            // 
            // lblAdminDashboard
            // 
            lblAdminDashboard.AutoSize = true;
            lblAdminDashboard.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminDashboard.ForeColor = Color.White;
            lblAdminDashboard.Location = new Point(260, 109);
            lblAdminDashboard.Name = "lblAdminDashboard";
            lblAdminDashboard.Size = new Size(240, 38);
            lblAdminDashboard.TabIndex = 5;
            lblAdminDashboard.Text = "Admin Dashboard";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Orange;
            label16.Location = new Point(269, 84);
            label16.Name = "label16";
            label16.Size = new Size(121, 25);
            label16.TabIndex = 4;
            label16.Text = "Administrator";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 236F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 214F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 196F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            tableLayoutPanel1.Controls.Add(lnklblReports, 5, 0);
            tableLayoutPanel1.Controls.Add(lnklblServices, 4, 0);
            tableLayoutPanel1.Controls.Add(lnklblProviders, 3, 0);
            tableLayoutPanel1.Controls.Add(lnklblRequests, 2, 0);
            tableLayoutPanel1.Controls.Add(lnklblOverView, 1, 0);
            tableLayoutPanel1.Location = new Point(1, 174);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1909, 66);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // lnklblReports
            // 
            lnklblReports.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lnklblReports.AutoSize = true;
            lnklblReports.DisabledLinkColor = Color.White;
            lnklblReports.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnklblReports.LinkColor = Color.Black;
            lnklblReports.Location = new Point(1054, 28);
            lnklblReports.Name = "lnklblReports";
            lnklblReports.Size = new Size(111, 38);
            lnklblReports.TabIndex = 0;
            lnklblReports.TabStop = true;
            lnklblReports.Text = "Reports";
            lnklblReports.TextAlign = ContentAlignment.BottomCenter;
            lnklblReports.LinkClicked += lnklblReports_LinkClicked;
            // 
            // lnklblServices
            // 
            lnklblServices.Anchor = AnchorStyles.Bottom;
            lnklblServices.AutoSize = true;
            lnklblServices.DisabledLinkColor = Color.White;
            lnklblServices.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnklblServices.LinkColor = Color.Black;
            lnklblServices.Location = new Point(902, 28);
            lnklblServices.Name = "lnklblServices";
            lnklblServices.Size = new Size(117, 38);
            lnklblServices.TabIndex = 0;
            lnklblServices.TabStop = true;
            lnklblServices.Text = "Services";
            lnklblServices.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lnklblProviders
            // 
            lnklblProviders.Anchor = AnchorStyles.Bottom;
            lnklblProviders.AutoSize = true;
            lnklblProviders.DisabledLinkColor = Color.White;
            lnklblProviders.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnklblProviders.LinkColor = Color.Black;
            lnklblProviders.Location = new Point(707, 28);
            lnklblProviders.Name = "lnklblProviders";
            lnklblProviders.Size = new Size(132, 38);
            lnklblProviders.TabIndex = 0;
            lnklblProviders.TabStop = true;
            lnklblProviders.Text = "Providers";
            lnklblProviders.TextAlign = ContentAlignment.BottomCenter;
            lnklblProviders.LinkClicked += lnklblProviders_LinkClicked;
            // 
            // lnklblRequests
            // 
            lnklblRequests.Anchor = AnchorStyles.Bottom;
            lnklblRequests.AutoSize = true;
            lnklblRequests.DisabledLinkColor = Color.White;
            lnklblRequests.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnklblRequests.LinkColor = Color.Black;
            lnklblRequests.Location = new Point(504, 28);
            lnklblRequests.Name = "lnklblRequests";
            lnklblRequests.Size = new Size(128, 38);
            lnklblRequests.TabIndex = 0;
            lnklblRequests.TabStop = true;
            lnklblRequests.Text = "Requests";
            lnklblRequests.TextAlign = ContentAlignment.BottomCenter;
            lnklblRequests.LinkClicked += lnklblRequests_LinkClicked;
            // 
            // lnklblOverView
            // 
            lnklblOverView.Anchor = AnchorStyles.Bottom;
            lnklblOverView.AutoSize = true;
            lnklblOverView.DisabledLinkColor = Color.White;
            lnklblOverView.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnklblOverView.LinkColor = Color.Black;
            lnklblOverView.Location = new Point(277, 28);
            lnklblOverView.Name = "lnklblOverView";
            lnklblOverView.Size = new Size(131, 38);
            lnklblOverView.TabIndex = 0;
            lnklblOverView.TabStop = true;
            lnklblOverView.Text = "Overview";
            lnklblOverView.TextAlign = ContentAlignment.BottomCenter;
            lnklblOverView.LinkClicked += lnklblOverView_LinkClicked;
            // 
            // flwLPSearchRequest
            // 
            flwLPSearchRequest.AutoSize = true;
            flwLPSearchRequest.Controls.Add(lblResults);
            flwLPSearchRequest.Location = new Point(280, 309);
            flwLPSearchRequest.Name = "flwLPSearchRequest";
            flwLPSearchRequest.RightToLeft = RightToLeft.Yes;
            flwLPSearchRequest.Size = new Size(1336, 69);
            flwLPSearchRequest.TabIndex = 15;
            // 
            // lblResults
            // 
            lblResults.Anchor = AnchorStyles.None;
            lblResults.AutoSize = true;
            lblResults.Location = new Point(1278, 0);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(55, 20);
            lblResults.TabIndex = 0;
            lblResults.Text = "Results";
            // 
            // RequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1042);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlNavigationAdminPanl);
            Controls.Add(btnReassign);
            Controls.Add(cbxStatus);
            Controls.Add(btnSearch);
            Controls.Add(dgvRequests);
            Controls.Add(cbxCategory);
            Controls.Add(btnCancelRequests);
            Controls.Add(btnApproveRequests);
            Controls.Add(txtSearchRequests);
            Controls.Add(label1);
            Controls.Add(flwLPSearchRequest);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RequestManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RequestManagement";
            WindowState = FormWindowState.Maximized;
            Load += RequestManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            pnlNavigationAdminPanl.ResumeLayout(false);
            pnlNavigationAdminPanl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flwLPSearchRequest.ResumeLayout(false);
            flwLPSearchRequest.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearchRequests;
        private Button btnApproveRequests;
        private Button btnCancelRequests;
        private ComboBox cbxCategory;
        private DataGridView dgvRequests;
        private Button btnSearch;
        private ComboBox cbxStatus;
        private Button btnReassign;
        private Panel pnlNavigationAdminPanl;
        private Label lblAdminPortal;
        private Button btnExitAdmin;
        private PictureBox pictureBox1;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Label lblAdminDashboard;
        private Label label16;
        private TableLayoutPanel tableLayoutPanel1;
        private LinkLabel lnklblReports;
        private LinkLabel lnklblServices;
        private LinkLabel lnklblProviders;
        private LinkLabel lnklblRequests;
        private LinkLabel lnklblOverView;
        private FlowLayoutPanel flwLPSearchRequest;
        private Label lblResults;
    }
}