namespace Home_Hero
{
    partial class frmProviderManagement
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
            dgvProviders = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            specialization = new DataGridViewTextBoxColumn();
            btnAddProvider_ = new Button();
            btnRemoveProvider = new Button();
            label3 = new Label();
            txtSearchProvider = new TextBox();
            btnSearch = new Button();
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvProviders).BeginInit();
            pnlNavigationAdminPanl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProviders
            // 
            dgvProviders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProviders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProviders.Columns.AddRange(new DataGridViewColumn[] { name, specialization });
            dgvProviders.Location = new Point(176, 359);
            dgvProviders.Name = "dgvProviders";
            dgvProviders.RowHeadersWidth = 51;
            dgvProviders.Size = new Size(1336, 577);
            dgvProviders.TabIndex = 0;
            dgvProviders.CellContentClick += dataGridView1_CellContentClick;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            // 
            // specialization
            // 
            specialization.HeaderText = "Specialization";
            specialization.MinimumWidth = 6;
            specialization.Name = "specialization";
            // 
            // btnAddProvider_
            // 
            btnAddProvider_.BackColor = Color.FromArgb(255, 128, 0);
            btnAddProvider_.FlatAppearance.BorderSize = 0;
            btnAddProvider_.FlatStyle = FlatStyle.Flat;
            btnAddProvider_.ForeColor = Color.White;
            btnAddProvider_.Location = new Point(849, 981);
            btnAddProvider_.Name = "btnAddProvider_";
            btnAddProvider_.Size = new Size(667, 29);
            btnAddProvider_.TabIndex = 2;
            btnAddProvider_.Text = "Add Provider";
            btnAddProvider_.UseVisualStyleBackColor = false;
            btnAddProvider_.Click += btnAddProvider__Click;
            // 
            // btnRemoveProvider
            // 
            btnRemoveProvider.BackColor = Color.FromArgb(255, 128, 0);
            btnRemoveProvider.FlatAppearance.BorderSize = 0;
            btnRemoveProvider.FlatStyle = FlatStyle.Flat;
            btnRemoveProvider.ForeColor = Color.White;
            btnRemoveProvider.Location = new Point(176, 981);
            btnRemoveProvider.Name = "btnRemoveProvider";
            btnRemoveProvider.Size = new Size(667, 29);
            btnRemoveProvider.TabIndex = 3;
            btnRemoveProvider.Text = "Remove Provider";
            btnRemoveProvider.UseVisualStyleBackColor = false;
            btnRemoveProvider.Click += btnAddProvider_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 316);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 6;
            label3.Text = "Search for a provider";
            // 
            // txtSearchProvider
            // 
            txtSearchProvider.Location = new Point(376, 309);
            txtSearchProvider.Name = "txtSearchProvider";
            txtSearchProvider.Size = new Size(767, 27);
            txtSearchProvider.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(255, 128, 0);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1359, 307);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
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
            pnlNavigationAdminPanl.TabIndex = 13;
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
            tableLayoutPanel1.TabIndex = 15;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Location = new Point(176, 293);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel1.Size = new Size(1336, 69);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // frmProviderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1042);
            Controls.Add(btnSearch);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlNavigationAdminPanl);
            Controls.Add(txtSearchProvider);
            Controls.Add(label3);
            Controls.Add(btnRemoveProvider);
            Controls.Add(btnAddProvider_);
            Controls.Add(dgvProviders);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProviderManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProviderManagement";
            WindowState = FormWindowState.Maximized;
            Load += ProviderManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProviders).EndInit();
            pnlNavigationAdminPanl.ResumeLayout(false);
            pnlNavigationAdminPanl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProviders;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn specialization;
        private Button btnAddProvider_;
        private Button btnRemoveProvider;
        private Label label3;
        private TextBox txtSearchProvider;
        private Button btnSearch;
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
        private FlowLayoutPanel flowLayoutPanel1;
    }
}