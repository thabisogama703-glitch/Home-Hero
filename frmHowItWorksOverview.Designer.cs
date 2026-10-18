namespace Home_Hero
{
    partial class frmHowItWorksOverview
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
            lnklblHome = new LinkLabel();
            lnklblServices = new LinkLabel();
            lnklblHowItWorks = new LinkLabel();
            lnklblPricings = new LinkLabel();
            pnlServicesButtons = new Panel();
            btnRequestAService = new Button();
            btnCreateAccount = new Button();
            btnLogin = new Button();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            pnlHowHomeHeroWorks = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel5 = new Panel();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            panel8 = new Panel();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            panel7 = new Panel();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel6 = new Panel();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            panel4 = new Panel();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel3 = new Panel();
            lblCreateCustomer = new Label();
            label6 = new Label();
            lblSteps = new Label();
            panel1 = new Panel();
            lblShortDescr = new Label();
            label2 = new Label();
            lblForCustomers = new Label();
            label1 = new Label();
            lblOnePla = new Label();
            lblSimpleProcess = new Label();
            pnlHomeHero.SuspendLayout();
            tblpHomeHeroPanel.SuspendLayout();
            flpNavigationTab.SuspendLayout();
            pnlServicesButtons.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            pnlHowHomeHeroWorks.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
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
            flpNavigationTab.Controls.Add(lnklblHome);
            flpNavigationTab.Controls.Add(lnklblServices);
            flpNavigationTab.Controls.Add(lnklblHowItWorks);
            flpNavigationTab.Controls.Add(lnklblPricings);
            flpNavigationTab.Location = new Point(407, 38);
            flpNavigationTab.Name = "flpNavigationTab";
            flpNavigationTab.Size = new Size(611, 31);
            flpNavigationTab.TabIndex = 6;
            // 
            // lnklblHome
            // 
            lnklblHome.AutoSize = true;
            lnklblHome.Font = new Font("Segoe UI", 13.8F);
            lnklblHome.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblHome.LinkColor = Color.LightGray;
            lnklblHome.Location = new Point(25, 0);
            lnklblHome.Margin = new Padding(25, 0, 25, 0);
            lnklblHome.Name = "lnklblHome";
            lnklblHome.Size = new Size(75, 31);
            lnklblHome.TabIndex = 4;
            lnklblHome.TabStop = true;
            lnklblHome.Text = "Home";
            lnklblHome.LinkClicked += lnklblHome_LinkClicked;
            // 
            // lnklblServices
            // 
            lnklblServices.AutoSize = true;
            lnklblServices.Font = new Font("Segoe UI", 13.8F);
            lnklblServices.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblServices.LinkColor = Color.LightGray;
            lnklblServices.Location = new Point(150, 0);
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
            lnklblHowItWorks.Location = new Point(296, 0);
            lnklblHowItWorks.Margin = new Padding(25, 0, 25, 0);
            lnklblHowItWorks.Name = "lnklblHowItWorks";
            lnklblHowItWorks.Size = new Size(145, 31);
            lnklblHowItWorks.TabIndex = 2;
            lnklblHowItWorks.TabStop = true;
            lnklblHowItWorks.Text = "How it works";
            // 
            // lnklblPricings
            // 
            lnklblPricings.AutoSize = true;
            lnklblPricings.Font = new Font("Segoe UI", 13.8F);
            lnklblPricings.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblPricings.LinkColor = Color.LightGray;
            lnklblPricings.Location = new Point(491, 0);
            lnklblPricings.Margin = new Padding(25, 0, 25, 0);
            lnklblPricings.Name = "lnklblPricings";
            lnklblPricings.Size = new Size(95, 31);
            lnklblPricings.TabIndex = 3;
            lnklblPricings.TabStop = true;
            lnklblPricings.Text = "Pricings";
            lnklblPricings.LinkClicked += lnklblProviders_LinkClicked;
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
            // pnlHowHomeHeroWorks
            // 
            pnlHowHomeHeroWorks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlHowHomeHeroWorks.BackColor = Color.MidnightBlue;
            pnlHowHomeHeroWorks.BackgroundImage = Properties.Resources._715579828291516585;
            pnlHowHomeHeroWorks.BackgroundImageLayout = ImageLayout.Stretch;
            pnlHowHomeHeroWorks.Controls.Add(tableLayoutPanel2);
            pnlHowHomeHeroWorks.Controls.Add(tableLayoutPanel1);
            pnlHowHomeHeroWorks.Controls.Add(label1);
            pnlHowHomeHeroWorks.Controls.Add(lblOnePla);
            pnlHowHomeHeroWorks.Controls.Add(lblSimpleProcess);
            pnlHowHomeHeroWorks.Location = new Point(0, 108);
            pnlHowHomeHeroWorks.Name = "pnlHowHomeHeroWorks";
            pnlHowHomeHeroWorks.Size = new Size(1886, 886);
            pnlHowHomeHeroWorks.TabIndex = 4;
            pnlHowHomeHeroWorks.Paint += pnlHowHomeHeroWorks_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.BackColor = Color.MidnightBlue;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(panel5, 0, 3);
            tableLayoutPanel2.Controls.Add(panel8, 0, 1);
            tableLayoutPanel2.Controls.Add(panel7, 0, 2);
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Location = new Point(969, 288);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(884, 568);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label12);
            panel5.Location = new Point(6, 429);
            panel5.Name = "panel5";
            panel5.Size = new Size(716, 117);
            panel5.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(111, 58);
            label10.Name = "label10";
            label10.Size = new Size(478, 40);
            label10.TabIndex = 2;
            label10.Text = "Review suitable service requests, manage accepted jobs and build your\r\nreputation through completed work and reviews.";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(105, 20);
            label11.Name = "label11";
            label11.Size = new Size(297, 31);
            label11.TabIndex = 1;
            label11.Text = "Receive requests and grow";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(255, 128, 0);
            label12.Location = new Point(20, 30);
            label12.Name = "label12";
            label12.Size = new Size(50, 41);
            label12.TabIndex = 0;
            label12.Text = "03";
            // 
            // panel8
            // 
            panel8.Controls.Add(label19);
            panel8.Controls.Add(label20);
            panel8.Controls.Add(label21);
            panel8.Location = new Point(6, 147);
            panel8.Name = "panel8";
            panel8.Size = new Size(716, 117);
            panel8.TabIndex = 2;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.Silver;
            label19.Location = new Point(111, 58);
            label19.Name = "label19";
            label19.Size = new Size(444, 40);
            label19.TabIndex = 2;
            label19.Text = "Register as a service provider and add your personal details, skills,\r\nexperience and service areas.";
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.None;
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.White;
            label20.Location = new Point(105, 20);
            label20.Name = "label20";
            label20.Size = new Size(320, 31);
            label20.TabIndex = 1;
            label20.Text = "Create your specialist profile";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.None;
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.FromArgb(255, 128, 0);
            label21.Location = new Point(18, 20);
            label21.Name = "label21";
            label21.Size = new Size(50, 41);
            label21.TabIndex = 0;
            label21.Text = "01";
            // 
            // panel7
            // 
            panel7.Controls.Add(label16);
            panel7.Controls.Add(label17);
            panel7.Controls.Add(label18);
            panel7.Location = new Point(6, 288);
            panel7.Name = "panel7";
            panel7.Size = new Size(716, 117);
            panel7.TabIndex = 2;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Silver;
            label16.Location = new Point(111, 58);
            label16.Name = "label16";
            label16.Size = new Size(474, 40);
            label16.TabIndex = 2;
            label16.Text = "Submit the required identity, qualification and business information so\r\ncustomers can book with confidence.";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.None;
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(105, 20);
            label17.Name = "label17";
            label17.Size = new Size(246, 31);
            label17.TabIndex = 1;
            label17.Text = "Complete verification";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.None;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(255, 128, 0);
            label18.Location = new Point(20, 30);
            label18.Name = "label18";
            label18.Size = new Size(50, 41);
            label18.TabIndex = 0;
            label18.Text = "02";
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(6, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(865, 132);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.AppWorkspace;
            label3.Location = new Point(18, 66);
            label3.Name = "label3";
            label3.Size = new Size(672, 56);
            label3.TabIndex = 4;
            label3.Text = "Join HomeHero as an independent professional and connect with customers\r\nwho need your expertise.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(18, 29);
            label4.Name = "label4";
            label4.Size = new Size(431, 31);
            label4.TabIndex = 2;
            label4.Text = "Turn your skills into new opportunities";
            label4.Click += label2_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(20, 5);
            label5.Name = "label5";
            label5.Size = new Size(190, 23);
            label5.TabIndex = 2;
            label5.Text = "🛠️For Service Providers";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.MidnightBlue;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel6, 0, 3);
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new Point(63, 318);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(884, 568);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(label13);
            panel6.Controls.Add(label14);
            panel6.Controls.Add(label15);
            panel6.Location = new Point(6, 429);
            panel6.Name = "panel6";
            panel6.Size = new Size(872, 133);
            panel6.TabIndex = 2;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Silver;
            label13.Location = new Point(144, 69);
            label13.Name = "label13";
            label13.Size = new Size(472, 40);
            label13.TabIndex = 2;
            label13.Text = "Get matched with a verified service provider, confirm the booking and\r\nfollow the job through to completion.";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(144, 26);
            label14.Name = "label14";
            label14.Size = new Size(289, 31);
            label14.TabIndex = 1;
            label14.Text = "Book and manage the job";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.None;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.FromArgb(255, 128, 0);
            label15.Location = new Point(18, 18);
            label15.Name = "label15";
            label15.Size = new Size(50, 41);
            label15.TabIndex = 0;
            label15.Text = "03";
            // 
            // panel4
            // 
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label9);
            panel4.Location = new Point(6, 147);
            panel4.Name = "panel4";
            panel4.Size = new Size(870, 132);
            panel4.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(144, 70);
            label7.Name = "label7";
            label7.Size = new Size(441, 40);
            label7.TabIndex = 2;
            label7.Text = "Register as a customer and tell us where you need help so we can\r\nfind suitable professionals near you.";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(144, 30);
            label8.Name = "label8";
            label8.Size = new Size(334, 31);
            label8.TabIndex = 1;
            label8.Text = "Create your customer account";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(255, 128, 0);
            label9.Location = new Point(18, 30);
            label9.Name = "label9";
            label9.Size = new Size(50, 41);
            label9.TabIndex = 0;
            label9.Text = "01";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblCreateCustomer);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(lblSteps);
            panel3.Location = new Point(6, 288);
            panel3.Name = "panel3";
            panel3.Size = new Size(870, 130);
            panel3.TabIndex = 2;
            // 
            // lblCreateCustomer
            // 
            lblCreateCustomer.AutoSize = true;
            lblCreateCustomer.ForeColor = Color.Silver;
            lblCreateCustomer.Location = new Point(144, 58);
            lblCreateCustomer.Name = "lblCreateCustomer";
            lblCreateCustomer.Size = new Size(464, 40);
            lblCreateCustomer.TabIndex = 2;
            lblCreateCustomer.Text = "Choose a service, explain the problem and share your preferred date,\r\ntime and location.";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(144, 17);
            label6.Name = "label6";
            label6.Size = new Size(331, 31);
            label6.TabIndex = 1;
            label6.Text = "Describe the service you need";
            // 
            // lblSteps
            // 
            lblSteps.Anchor = AnchorStyles.None;
            lblSteps.AutoSize = true;
            lblSteps.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSteps.ForeColor = Color.FromArgb(255, 128, 0);
            lblSteps.Location = new Point(18, 17);
            lblSteps.Name = "lblSteps";
            lblSteps.Size = new Size(50, 41);
            lblSteps.TabIndex = 0;
            lblSteps.Text = "02";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblShortDescr);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblForCustomers);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(872, 132);
            panel1.TabIndex = 3;
            // 
            // lblShortDescr
            // 
            lblShortDescr.AutoSize = true;
            lblShortDescr.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShortDescr.ForeColor = SystemColors.AppWorkspace;
            lblShortDescr.Location = new Point(18, 69);
            lblShortDescr.Name = "lblShortDescr";
            lblShortDescr.Size = new Size(635, 56);
            lblShortDescr.TabIndex = 4;
            lblShortDescr.Text = "Find and book verified professionals for repairs, maintenance and home\r\nimprovements.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 32);
            label2.Name = "label2";
            label2.Size = new Size(347, 31);
            label2.TabIndex = 2;
            label2.Text = "Get trusted help for your home";
            label2.Click += label2_Click;
            // 
            // lblForCustomers
            // 
            lblForCustomers.Anchor = AnchorStyles.None;
            lblForCustomers.AutoSize = true;
            lblForCustomers.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblForCustomers.ForeColor = Color.FromArgb(255, 128, 0);
            lblForCustomers.Location = new Point(17, 8);
            lblForCustomers.Name = "lblForCustomers";
            lblForCustomers.Size = new Size(143, 23);
            lblForCustomers.TabIndex = 2;
            lblForCustomers.Text = "👤For Customers";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(53, 174);
            label1.Name = "label1";
            label1.Size = new Size(825, 62);
            label1.TabIndex = 0;
            label1.Text = "Whether you need reliable help at home or want to offer your services as an\r\nindependent professional, HomeHero gives you a clear path forward.";
            // 
            // lblOnePla
            // 
            lblOnePla.AutoSize = true;
            lblOnePla.BackColor = Color.Transparent;
            lblOnePla.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOnePla.ForeColor = Color.White;
            lblOnePla.Location = new Point(53, 112);
            lblOnePla.Name = "lblOnePla";
            lblOnePla.Size = new Size(632, 46);
            lblOnePla.TabIndex = 0;
            lblOnePla.Text = "One Platform, Two ways to get started";
            // 
            // lblSimpleProcess
            // 
            lblSimpleProcess.AutoSize = true;
            lblSimpleProcess.BackColor = Color.Transparent;
            lblSimpleProcess.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSimpleProcess.ForeColor = Color.FromArgb(255, 128, 0);
            lblSimpleProcess.Location = new Point(62, 60);
            lblSimpleProcess.Name = "lblSimpleProcess";
            lblSimpleProcess.Size = new Size(174, 31);
            lblSimpleProcess.TabIndex = 0;
            lblSimpleProcess.Text = "Simple Process";
            // 
            // frmHowItWorksOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 995);
            Controls.Add(pnlHowHomeHeroWorks);
            Controls.Add(pnlHomeHero);
            Name = "frmHowItWorksOverview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmHowItWorksOverview";
            WindowState = FormWindowState.Maximized;
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
            pnlHowHomeHeroWorks.ResumeLayout(false);
            pnlHowHomeHeroWorks.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHomeHero;
        private TableLayoutPanel tblpHomeHeroPanel;
        private FlowLayoutPanel flpNavigationTab;
        private LinkLabel lnklblServices;
        private LinkLabel lnklblHowItWorks;
        private LinkLabel lnklblPricings;
        private LinkLabel lnklblHome;
        private Panel pnlServicesButtons;
        private Button btnCreateAccount;
        private Button btnLogin;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Button btnRequestAService;
        private Panel pnlHowHomeHeroWorks;
        private Label lblSimpleProcess;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label lblOnePla;
        private Label lblForCustomers;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Label lblShortDescr;
        private Panel panel3;
        private Label lblCreateCustomer;
        private Label label6;
        private Label lblSteps;
        private Panel panel4;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel5;
        private Label label10;
        private Label label11;
        private Label label12;
        private Panel panel7;
        private Label label16;
        private Label label17;
        private Label label18;
        private Panel panel6;
        private Label label13;
        private Label label14;
        private Label label15;
        private Panel panel8;
        private Label label19;
        private Label label20;
        private Label label21;
    }
}