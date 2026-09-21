namespace Home_Hero
{
    partial class frmHomeHeroHomepage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
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
            pnlAboutTheAppAndSearchBar = new Panel();
            lblPopular = new Label();
            lblPopularServices = new Label();
            btnFindAPro = new Button();
            txtLiveUpdate = new TextBox();
            pnlSearchBox = new Panel();
            pbxSearchMagnifier = new PictureBox();
            txtSearchForService = new TextBox();
            flpAboutTheApplication = new FlowLayoutPanel();
            lblDetailedExplaination = new Label();
            flpSlogan = new FlowLayoutPanel();
            lblHomeCare = new Label();
            lblDoneRight = new Label();
            tblpStatistics = new TableLayoutPanel();
            pnlAvgResponseTime = new Panel();
            lblAvgResponseTime = new Label();
            lblAverageResponseTimeValue = new Label();
            pnlVerifiedPros = new Panel();
            lblVerifiedPros2 = new Label();
            lblVerifiedprosValue = new Label();
            pnlAverageRating = new Panel();
            lblAverageRating = new Label();
            lblAvgRatingValue = new Label();
            pnlMoreInfo = new Panel();
            lblJobsCompleted2 = new Label();
            lblJobsCompletedValue = new Label();
            ValidationError = new ErrorProvider(components);
            pnlHomeHero.SuspendLayout();
            tblpHomeHeroPanel.SuspendLayout();
            flpNavigationTab.SuspendLayout();
            pnlServicesButtons.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            pnlAboutTheAppAndSearchBar.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxSearchMagnifier).BeginInit();
            flpAboutTheApplication.SuspendLayout();
            flpSlogan.SuspendLayout();
            tblpStatistics.SuspendLayout();
            pnlAvgResponseTime.SuspendLayout();
            pnlVerifiedPros.SuspendLayout();
            pnlAverageRating.SuspendLayout();
            pnlMoreInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
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
            pnlHomeHero.TabIndex = 0;
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
            btnRequestAService.Click += btnRequestAService_Click;
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
            btnCreateAccount.Click += btnCreateAccount_Click;
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
            btnLogin.Click += btnLogin_Click;
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
            // pnlAboutTheAppAndSearchBar
            // 
            pnlAboutTheAppAndSearchBar.Anchor = AnchorStyles.None;
            pnlAboutTheAppAndSearchBar.Controls.Add(lblPopular);
            pnlAboutTheAppAndSearchBar.Controls.Add(lblPopularServices);
            pnlAboutTheAppAndSearchBar.Controls.Add(btnFindAPro);
            pnlAboutTheAppAndSearchBar.Controls.Add(txtLiveUpdate);
            pnlAboutTheAppAndSearchBar.Controls.Add(pnlSearchBox);
            pnlAboutTheAppAndSearchBar.Controls.Add(flpAboutTheApplication);
            pnlAboutTheAppAndSearchBar.Controls.Add(flpSlogan);
            pnlAboutTheAppAndSearchBar.Location = new Point(98, 118);
            pnlAboutTheAppAndSearchBar.Margin = new Padding(4, 5, 4, 5);
            pnlAboutTheAppAndSearchBar.Name = "pnlAboutTheAppAndSearchBar";
            pnlAboutTheAppAndSearchBar.Size = new Size(1113, 661);
            pnlAboutTheAppAndSearchBar.TabIndex = 5;
            // 
            // lblPopular
            // 
            lblPopular.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPopular.Location = new Point(58, 622);
            lblPopular.Name = "lblPopular";
            lblPopular.Size = new Size(83, 35);
            lblPopular.TabIndex = 7;
            lblPopular.Text = "Popular:";
            // 
            // lblPopularServices
            // 
            lblPopularServices.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPopularServices.Location = new Point(134, 622);
            lblPopularServices.Name = "lblPopularServices";
            lblPopularServices.Size = new Size(619, 35);
            lblPopularServices.TabIndex = 6;
            lblPopularServices.Text = "Plumbing · Electrical · HVAC · Painting · Cleaning";
            // 
            // btnFindAPro
            // 
            btnFindAPro.BackColor = Color.FromArgb(255, 128, 0);
            btnFindAPro.FlatAppearance.BorderColor = Color.LightGray;
            btnFindAPro.FlatStyle = FlatStyle.Flat;
            btnFindAPro.ForeColor = Color.White;
            btnFindAPro.Location = new Point(60, 558);
            btnFindAPro.Name = "btnFindAPro";
            btnFindAPro.Size = new Size(619, 40);
            btnFindAPro.TabIndex = 5;
            btnFindAPro.Text = "Find a Pro";
            btnFindAPro.UseVisualStyleBackColor = false;
            btnFindAPro.Click += btnFindAPro_Click;
            // 
            // txtLiveUpdate
            // 
            txtLiveUpdate.BackColor = Color.FromArgb(255, 192, 128);
            txtLiveUpdate.BorderStyle = BorderStyle.FixedSingle;
            txtLiveUpdate.CharacterCasing = CharacterCasing.Upper;
            txtLiveUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLiveUpdate.Location = new Point(49, 50);
            txtLiveUpdate.Name = "txtLiveUpdate";
            txtLiveUpdate.ReadOnly = true;
            txtLiveUpdate.Size = new Size(227, 34);
            txtLiveUpdate.TabIndex = 9;
            txtLiveUpdate.Text = "NOW LIVE IN 40+ CITIES";
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = Color.White;
            pnlSearchBox.BorderStyle = BorderStyle.Fixed3D;
            pnlSearchBox.Controls.Add(pbxSearchMagnifier);
            pnlSearchBox.Controls.Add(txtSearchForService);
            pnlSearchBox.Location = new Point(59, 498);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Size = new Size(620, 100);
            pnlSearchBox.TabIndex = 4;
            // 
            // pbxSearchMagnifier
            // 
            pbxSearchMagnifier.Image = Properties.Resources.Screenshot_2026_09_06_085246;
            pbxSearchMagnifier.Location = new Point(-1, -1);
            pbxSearchMagnifier.Name = "pbxSearchMagnifier";
            pbxSearchMagnifier.Size = new Size(48, 58);
            pbxSearchMagnifier.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxSearchMagnifier.TabIndex = 4;
            pbxSearchMagnifier.TabStop = false;
            // 
            // txtSearchForService
            // 
            txtSearchForService.BorderStyle = BorderStyle.None;
            txtSearchForService.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchForService.ForeColor = Color.Gray;
            txtSearchForService.Location = new Point(53, 14);
            txtSearchForService.Name = "txtSearchForService";
            txtSearchForService.PlaceholderText = " What do you need? e.g leaking pipe, broken Ac...";
            txtSearchForService.Size = new Size(506, 27);
            txtSearchForService.TabIndex = 3;
            // 
            // flpAboutTheApplication
            // 
            flpAboutTheApplication.Controls.Add(lblDetailedExplaination);
            flpAboutTheApplication.Location = new Point(39, 279);
            flpAboutTheApplication.Name = "flpAboutTheApplication";
            flpAboutTheApplication.Size = new Size(765, 184);
            flpAboutTheApplication.TabIndex = 2;
            // 
            // lblDetailedExplaination
            // 
            lblDetailedExplaination.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetailedExplaination.Location = new Point(3, 0);
            lblDetailedExplaination.Name = "lblDetailedExplaination";
            lblDetailedExplaination.Size = new Size(762, 184);
            lblDetailedExplaination.TabIndex = 0;
            lblDetailedExplaination.Text = "Connect with vetted, insured home service professionals\r\n— plumbers, electricians, HVAC techs, and more — booked online in minutes.";
            // 
            // flpSlogan
            // 
            flpSlogan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flpSlogan.Controls.Add(lblHomeCare);
            flpSlogan.Controls.Add(lblDoneRight);
            flpSlogan.FlowDirection = FlowDirection.TopDown;
            flpSlogan.Location = new Point(39, 119);
            flpSlogan.Name = "flpSlogan";
            flpSlogan.Size = new Size(945, 147);
            flpSlogan.TabIndex = 1;
            // 
            // lblHomeCare
            // 
            lblHomeCare.Anchor = AnchorStyles.None;
            lblHomeCare.AutoSize = true;
            lblHomeCare.Font = new Font("Segoe UI Black", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHomeCare.ForeColor = Color.FromArgb(0, 0, 64);
            lblHomeCare.Location = new Point(3, 0);
            lblHomeCare.Name = "lblHomeCare";
            lblHomeCare.Size = new Size(296, 62);
            lblHomeCare.TabIndex = 0;
            lblHomeCare.Text = "Home Care,";
            // 
            // lblDoneRight
            // 
            lblDoneRight.AutoSize = true;
            lblDoneRight.Font = new Font("Segoe UI Black", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoneRight.ForeColor = Color.FromArgb(255, 128, 0);
            lblDoneRight.Location = new Point(3, 62);
            lblDoneRight.Name = "lblDoneRight";
            lblDoneRight.Size = new Size(283, 62);
            lblDoneRight.TabIndex = 1;
            lblDoneRight.Text = "done right.";
            // 
            // tblpStatistics
            // 
            tblpStatistics.Anchor = AnchorStyles.None;
            tblpStatistics.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tblpStatistics.ColumnCount = 4;
            tblpStatistics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 485F));
            tblpStatistics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 485F));
            tblpStatistics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 485F));
            tblpStatistics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 485F));
            tblpStatistics.Controls.Add(pnlAvgResponseTime, 3, 0);
            tblpStatistics.Controls.Add(pnlVerifiedPros, 2, 0);
            tblpStatistics.Controls.Add(pnlAverageRating, 1, 0);
            tblpStatistics.Controls.Add(pnlMoreInfo, 0, 0);
            tblpStatistics.Location = new Point(-19, 865);
            tblpStatistics.Name = "tblpStatistics";
            tblpStatistics.RowCount = 1;
            tblpStatistics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblpStatistics.Size = new Size(1903, 125);
            tblpStatistics.TabIndex = 8;
            // 
            // pnlAvgResponseTime
            // 
            pnlAvgResponseTime.Controls.Add(lblAvgResponseTime);
            pnlAvgResponseTime.Controls.Add(lblAverageResponseTimeValue);
            pnlAvgResponseTime.Location = new Point(1462, 4);
            pnlAvgResponseTime.Name = "pnlAvgResponseTime";
            pnlAvgResponseTime.Size = new Size(479, 117);
            pnlAvgResponseTime.TabIndex = 4;
            // 
            // lblAvgResponseTime
            // 
            lblAvgResponseTime.Anchor = AnchorStyles.None;
            lblAvgResponseTime.AutoSize = true;
            lblAvgResponseTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvgResponseTime.Location = new Point(127, 80);
            lblAvgResponseTime.Name = "lblAvgResponseTime";
            lblAvgResponseTime.Size = new Size(218, 28);
            lblAvgResponseTime.TabIndex = 1;
            lblAvgResponseTime.Text = "Average Response Time";
            // 
            // lblAverageResponseTimeValue
            // 
            lblAverageResponseTimeValue.Anchor = AnchorStyles.None;
            lblAverageResponseTimeValue.AutoSize = true;
            lblAverageResponseTimeValue.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAverageResponseTimeValue.Location = new Point(157, 18);
            lblAverageResponseTimeValue.Name = "lblAverageResponseTimeValue";
            lblAverageResponseTimeValue.Size = new Size(118, 62);
            lblAverageResponseTimeValue.TabIndex = 0;
            lblAverageResponseTimeValue.Text = "N/A";
            // 
            // pnlVerifiedPros
            // 
            pnlVerifiedPros.Controls.Add(lblVerifiedPros2);
            pnlVerifiedPros.Controls.Add(lblVerifiedprosValue);
            pnlVerifiedPros.Location = new Point(976, 4);
            pnlVerifiedPros.Name = "pnlVerifiedPros";
            pnlVerifiedPros.Size = new Size(479, 117);
            pnlVerifiedPros.TabIndex = 9;
            // 
            // lblVerifiedPros2
            // 
            lblVerifiedPros2.Anchor = AnchorStyles.None;
            lblVerifiedPros2.AutoSize = true;
            lblVerifiedPros2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVerifiedPros2.Location = new Point(164, 80);
            lblVerifiedPros2.Name = "lblVerifiedPros2";
            lblVerifiedPros2.Size = new Size(121, 28);
            lblVerifiedPros2.TabIndex = 1;
            lblVerifiedPros2.Text = "Verified Pros";
            // 
            // lblVerifiedprosValue
            // 
            lblVerifiedprosValue.Anchor = AnchorStyles.None;
            lblVerifiedprosValue.AutoSize = true;
            lblVerifiedprosValue.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVerifiedprosValue.Location = new Point(151, 14);
            lblVerifiedprosValue.Name = "lblVerifiedprosValue";
            lblVerifiedprosValue.Size = new Size(54, 62);
            lblVerifiedprosValue.TabIndex = 0;
            lblVerifiedprosValue.Text = "0";
            // 
            // pnlAverageRating
            // 
            pnlAverageRating.Controls.Add(lblAverageRating);
            pnlAverageRating.Controls.Add(lblAvgRatingValue);
            pnlAverageRating.Location = new Point(490, 4);
            pnlAverageRating.Name = "pnlAverageRating";
            pnlAverageRating.Size = new Size(479, 117);
            pnlAverageRating.TabIndex = 9;
            // 
            // lblAverageRating
            // 
            lblAverageRating.Anchor = AnchorStyles.None;
            lblAverageRating.AutoSize = true;
            lblAverageRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAverageRating.Location = new Point(164, 76);
            lblAverageRating.Name = "lblAverageRating";
            lblAverageRating.Size = new Size(146, 28);
            lblAverageRating.TabIndex = 1;
            lblAverageRating.Text = "Average Rating";
            // 
            // lblAvgRatingValue
            // 
            lblAvgRatingValue.Anchor = AnchorStyles.None;
            lblAvgRatingValue.AutoSize = true;
            lblAvgRatingValue.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvgRatingValue.Location = new Point(185, 14);
            lblAvgRatingValue.Name = "lblAvgRatingValue";
            lblAvgRatingValue.Size = new Size(94, 62);
            lblAvgRatingValue.TabIndex = 0;
            lblAvgRatingValue.Text = "0.0";
            // 
            // pnlMoreInfo
            // 
            pnlMoreInfo.Controls.Add(lblJobsCompleted2);
            pnlMoreInfo.Controls.Add(lblJobsCompletedValue);
            pnlMoreInfo.Location = new Point(4, 4);
            pnlMoreInfo.Name = "pnlMoreInfo";
            pnlMoreInfo.Size = new Size(479, 117);
            pnlMoreInfo.TabIndex = 2;
            // 
            // lblJobsCompleted2
            // 
            lblJobsCompleted2.Anchor = AnchorStyles.None;
            lblJobsCompleted2.AutoSize = true;
            lblJobsCompleted2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJobsCompleted2.Location = new Point(137, 80);
            lblJobsCompleted2.Name = "lblJobsCompleted2";
            lblJobsCompleted2.Size = new Size(153, 28);
            lblJobsCompleted2.TabIndex = 1;
            lblJobsCompleted2.Text = "Jobs Completed";
            // 
            // lblJobsCompletedValue
            // 
            lblJobsCompletedValue.Anchor = AnchorStyles.None;
            lblJobsCompletedValue.AutoSize = true;
            lblJobsCompletedValue.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJobsCompletedValue.Location = new Point(120, 18);
            lblJobsCompletedValue.Name = "lblJobsCompletedValue";
            lblJobsCompletedValue.Size = new Size(54, 62);
            lblJobsCompletedValue.TabIndex = 0;
            lblJobsCompletedValue.Text = "0";
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // frmHomeHeroHomepage
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1886, 995);
            Controls.Add(tblpStatistics);
            Controls.Add(pnlHomeHero);
            Controls.Add(pnlAboutTheAppAndSearchBar);
            Font = new Font("Segoe UI", 13.8F);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1613, 982);
            Name = "frmHomeHeroHomepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Hero";
            WindowState = FormWindowState.Maximized;
            Load += frmHomeHeroHomepage_Load;
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
            pnlAboutTheAppAndSearchBar.ResumeLayout(false);
            pnlAboutTheAppAndSearchBar.PerformLayout();
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxSearchMagnifier).EndInit();
            flpAboutTheApplication.ResumeLayout(false);
            flpSlogan.ResumeLayout(false);
            flpSlogan.PerformLayout();
            tblpStatistics.ResumeLayout(false);
            pnlAvgResponseTime.ResumeLayout(false);
            pnlAvgResponseTime.PerformLayout();
            pnlVerifiedPros.ResumeLayout(false);
            pnlVerifiedPros.PerformLayout();
            pnlAverageRating.ResumeLayout(false);
            pnlAverageRating.PerformLayout();
            pnlMoreInfo.ResumeLayout(false);
            pnlMoreInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHomeHero;
        private LinkLabel lnklblServices;
        private LinkLabel lnklblHowItWorks;
        private LinkLabel lnklblProviders;
        private LinkLabel lnklblPricing;
        private Button btnLogin;
        private Button btnCreateAccount;
        private Button btnRequestAService;
        private Panel pnlAboutTheAppAndSearchBar;
        private TableLayoutPanel tblpHomeHeroPanel;
        private FlowLayoutPanel flpNavigationTab;
        private FlowLayoutPanel flpSlogan;
        private Label lblHomeCare;
        private Label lblDoneRight;
        private FlowLayoutPanel flpAboutTheApplication;
        private Label lblDetailedExplaination;
        private TextBox txtSearchForService;
        private Panel pnlSearchBox;
        private PictureBox pbxSearchMagnifier;
        private Button btnFindAPro;
        private Label lblPopularServices;
        private TableLayoutPanel tblpStatistics;
        private Label lblPopular;
        private Label lblJobsCompletedValue;
        private Label lblJobsCompleted2;
        private Panel pnlMoreInfo;
        private Panel pnlServicesButtons;
        private Panel pnlAvgResponseTime;
        private Label lblAvgResponseTime;
        private Label lblAverageResponseTimeValue;
        private Panel pnlVerifiedPros;
        private Label lblVerifiedPros2;
        private Label lblVerifiedprosValue;
        private Panel pnlAverageRating;
        private Label lblAverageRating;
        private Label lblAvgRatingValue;
        private TextBox txtLiveUpdate;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private ErrorProvider ValidationError;
    }
}
