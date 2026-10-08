namespace Home_Hero
{
    partial class frmServicesOverview
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
            pnlHomeHero = new Panel();
            tblpHomeHeroPanel = new TableLayoutPanel();
            flpNavigationTab = new FlowLayoutPanel();
            lnklblServices = new LinkLabel();
            lnklblHowItWorks = new LinkLabel();
            lnklblProviders = new LinkLabel();
            lnklblPricing = new LinkLabel();
            pnlServicesButtons = new Panel();
            btnRequestAService = new Button();
            btnCreateAccount = new Button();
            btnLogin = new Button();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            pnlHomeHero.SuspendLayout();
            tblpHomeHeroPanel.SuspendLayout();
            flpNavigationTab.SuspendLayout();
            pnlServicesButtons.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHomeHero
            // 
            pnlHomeHero.BackColor = Color.FromArgb(0, 0, 64);
            pnlHomeHero.Controls.Add(tblpHomeHeroPanel);
            pnlHomeHero.Dock = DockStyle.Top;
            pnlHomeHero.Location = new Point(0, 0);
            pnlHomeHero.Margin = new Padding(4, 5, 4, 5);
            pnlHomeHero.Name = "pnlHomeHero";
            pnlHomeHero.Padding = new Padding(98, 0, 98, 0);
            pnlHomeHero.Size = new Size(1886, 108);
            pnlHomeHero.TabIndex = 1;
            // 
            // tblpHomeHeroPanel
            // 
            tblpHomeHeroPanel.AutoSize = true;
            tblpHomeHeroPanel.BackColor = Color.FromArgb(0, 0, 64);
            tblpHomeHeroPanel.ColumnCount = 3;
            tblpHomeHeroPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 357F));
            tblpHomeHeroPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblpHomeHeroPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 622F));
            tblpHomeHeroPanel.Controls.Add(flpNavigationTab, 1, 0);
            tblpHomeHeroPanel.Controls.Add(pnlServicesButtons, 2, 0);
            tblpHomeHeroPanel.Controls.Add(pnlHomeHeroLogo, 0, 0);
            tblpHomeHeroPanel.Dock = DockStyle.Fill;
            tblpHomeHeroPanel.Location = new Point(98, 0);
            tblpHomeHeroPanel.Margin = new Padding(4, 5, 4, 5);
            tblpHomeHeroPanel.Name = "tblpHomeHeroPanel";
            tblpHomeHeroPanel.RowCount = 1;
            tblpHomeHeroPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblpHomeHeroPanel.Size = new Size(1690, 108);
            tblpHomeHeroPanel.TabIndex = 3;
            // 
            // flpNavigationTab
            // 
            flpNavigationTab.Anchor = AnchorStyles.None;
            flpNavigationTab.AutoSize = true;
            flpNavigationTab.Controls.Add(lnklblServices);
            flpNavigationTab.Controls.Add(lnklblHowItWorks);
            flpNavigationTab.Controls.Add(lnklblProviders);
            flpNavigationTab.Controls.Add(lnklblPricing);
            flpNavigationTab.Location = new Point(395, 38);
            flpNavigationTab.Name = "flpNavigationTab";
            flpNavigationTab.Size = new Size(635, 31);
            flpNavigationTab.TabIndex = 6;
            // 
            // lnklblServices
            // 
            lnklblServices.AutoSize = true;
            lnklblServices.Font = new Font("Segoe UI", 13.8F);
            lnklblServices.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblServices.LinkColor = Color.LightGray;
            lnklblServices.Location = new Point(25, 0);
            lnklblServices.Margin = new Padding(25, 0, 25, 0);
            lnklblServices.Name = "lnklblServices";
            lnklblServices.Size = new Size(96, 31);
            lnklblServices.TabIndex = 1;
            lnklblServices.TabStop = true;
            lnklblServices.Text = "Services";
            lnklblServices.LinkClicked += lnklblServices_LinkClicked;
            // 
            // lnklblHowItWorks
            // 
            lnklblHowItWorks.AutoSize = true;
            lnklblHowItWorks.Font = new Font("Segoe UI", 13.8F);
            lnklblHowItWorks.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblHowItWorks.LinkColor = Color.LightGray;
            lnklblHowItWorks.Location = new Point(171, 0);
            lnklblHowItWorks.Margin = new Padding(25, 0, 25, 0);
            lnklblHowItWorks.Name = "lnklblHowItWorks";
            lnklblHowItWorks.Size = new Size(145, 31);
            lnklblHowItWorks.TabIndex = 2;
            lnklblHowItWorks.TabStop = true;
            lnklblHowItWorks.Text = "How it works";
            lnklblHowItWorks.LinkClicked += lnklblHowItWorks_LinkClicked;
            // 
            // lnklblProviders
            // 
            lnklblProviders.AutoSize = true;
            lnklblProviders.Font = new Font("Segoe UI", 13.8F);
            lnklblProviders.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblProviders.LinkColor = Color.LightGray;
            lnklblProviders.Location = new Point(366, 0);
            lnklblProviders.Margin = new Padding(25, 0, 25, 0);
            lnklblProviders.Name = "lnklblProviders";
            lnklblProviders.Size = new Size(109, 31);
            lnklblProviders.TabIndex = 3;
            lnklblProviders.TabStop = true;
            lnklblProviders.Text = "Providers";
            lnklblProviders.LinkClicked += lnklblProviders_LinkClicked;
            // 
            // lnklblPricing
            // 
            lnklblPricing.AutoSize = true;
            lnklblPricing.Font = new Font("Segoe UI", 13.8F);
            lnklblPricing.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblPricing.LinkColor = Color.LightGray;
            lnklblPricing.Location = new Point(525, 0);
            lnklblPricing.Margin = new Padding(25, 0, 25, 0);
            lnklblPricing.Name = "lnklblPricing";
            lnklblPricing.Size = new Size(85, 31);
            lnklblPricing.TabIndex = 4;
            lnklblPricing.TabStop = true;
            lnklblPricing.Text = "Pricing";
            // 
            // pnlServicesButtons
            // 
            pnlServicesButtons.Controls.Add(btnRequestAService);
            pnlServicesButtons.Controls.Add(btnCreateAccount);
            pnlServicesButtons.Controls.Add(btnLogin);
            pnlServicesButtons.Location = new Point(1071, 3);
            pnlServicesButtons.Name = "pnlServicesButtons";
            pnlServicesButtons.Size = new Size(616, 102);
            pnlServicesButtons.TabIndex = 8;
            // 
            // btnRequestAService
            // 
            btnRequestAService.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRequestAService.AutoSize = true;
            btnRequestAService.BackColor = Color.FromArgb(255, 128, 0);
            btnRequestAService.FlatAppearance.BorderColor = Color.Navy;
            btnRequestAService.FlatStyle = FlatStyle.Popup;
            btnRequestAService.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRequestAService.ForeColor = Color.White;
            btnRequestAService.Location = new Point(431, 29);
            btnRequestAService.Margin = new Padding(9, 0, 9, 0);
            btnRequestAService.Name = "btnRequestAService";
            btnRequestAService.Size = new Size(176, 46);
            btnRequestAService.TabIndex = 2;
            btnRequestAService.Text = "Request a Service";
            btnRequestAService.UseVisualStyleBackColor = false;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateAccount.AutoSize = true;
            btnCreateAccount.BackColor = Color.FromArgb(0, 0, 64);
            btnCreateAccount.FlatAppearance.BorderColor = Color.DarkGray;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(272, 29);
            btnCreateAccount.Margin = new Padding(9, 0, 9, 0);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(150, 46);
            btnCreateAccount.TabIndex = 1;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogin.BackColor = Color.FromArgb(0, 0, 64);
            btnLogin.FlatAppearance.BorderColor = Color.DarkGray;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(154, 29);
            btnLogin.Margin = new Padding(9, 0, 9, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(111, 46);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // pnlHomeHeroLogo
            // 
            pnlHomeHeroLogo.Controls.Add(lblHero);
            pnlHomeHeroLogo.Controls.Add(lblHome);
            pnlHomeHeroLogo.Controls.Add(pbxHomeHeroLogo);
            pnlHomeHeroLogo.Location = new Point(3, 3);
            pnlHomeHeroLogo.Name = "pnlHomeHeroLogo";
            pnlHomeHeroLogo.Size = new Size(351, 102);
            pnlHomeHeroLogo.TabIndex = 9;
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
            // frmServicesOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 995);
            Controls.Add(pnlHomeHero);
            Name = "frmServicesOverview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmServicesOverview";
            WindowState = FormWindowState.Maximized;
            Load += frmServicesOverview_Load;
            pnlHomeHero.ResumeLayout(false);
            pnlHomeHero.PerformLayout();
            tblpHomeHeroPanel.ResumeLayout(false);
            tblpHomeHeroPanel.PerformLayout();
            flpNavigationTab.ResumeLayout(false);
            flpNavigationTab.PerformLayout();
            pnlServicesButtons.ResumeLayout(false);
            pnlServicesButtons.PerformLayout();
            pnlHomeHeroLogo.ResumeLayout(false);
            pnlHomeHeroLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHomeHero;
        private TableLayoutPanel tblpHomeHeroPanel;
        private FlowLayoutPanel flpNavigationTab;
        private LinkLabel lnklblServices;
        private LinkLabel lnklblHowItWorks;
        private LinkLabel lnklblProviders;
        private LinkLabel lnklblPricing;
        private Panel pnlServicesButtons;
        private Button btnRequestAService;
        private Button btnCreateAccount;
        private Button btnLogin;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
    }
}