namespace Home_Hero
{
    partial class frmProvidersOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProvidersOverview));
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label7 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            panel4 = new Panel();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            panel5 = new Panel();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            panel6 = new Panel();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            panel7 = new Panel();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            panel8 = new Panel();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
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
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
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
            pnlHomeHero.TabIndex = 2;
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
            lnklblHowItWorks.LinkClicked += lnklblHowItWorks_LinkClicked;
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
            pnlHowHomeHeroWorks.BackgroundImage = (Image)resources.GetObject("pnlHowHomeHeroWorks.BackgroundImage");
            pnlHowHomeHeroWorks.BackgroundImageLayout = ImageLayout.Stretch;
            pnlHowHomeHeroWorks.Controls.Add(tableLayoutPanel1);
            pnlHowHomeHeroWorks.Controls.Add(label1);
            pnlHowHomeHeroWorks.Controls.Add(lblOnePla);
            pnlHowHomeHeroWorks.Controls.Add(lblSimpleProcess);
            pnlHowHomeHeroWorks.ForeColor = Color.White;
            pnlHowHomeHeroWorks.Location = new Point(0, 108);
            pnlHowHomeHeroWorks.Name = "pnlHowHomeHeroWorks";
            pnlHowHomeHeroWorks.Size = new Size(1886, 891);
            pnlHowHomeHeroWorks.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel4, 2, 0);
            tableLayoutPanel1.Controls.Add(panel5, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 1);
            tableLayoutPanel1.Controls.Add(panel7, 2, 1);
            tableLayoutPanel1.Controls.Add(panel8, 3, 1);
            tableLayoutPanel1.ForeColor = Color.Black;
            tableLayoutPanel1.Location = new Point(53, 323);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1592, 517);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Goldenrod;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(6, 263);
            panel1.Name = "panel1";
            panel1.Size = new Size(388, 248);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(332, 62);
            label2.TabIndex = 1;
            label2.Text = "Repairs, fittings, locks, handles\r\nand basic maintenance.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 191);
            label3.Name = "label3";
            label3.Size = new Size(195, 46);
            label3.TabIndex = 0;
            label3.Text = "From R600";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.Goldenrod;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(10, 15);
            label7.Name = "label7";
            label7.Size = new Size(343, 46);
            label7.TabIndex = 0;
            label7.Text = "Windows and Doors";
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(6, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(388, 248);
            panel2.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(12, 79);
            label4.Name = "label4";
            label4.Size = new Size(381, 62);
            label4.TabIndex = 1;
            label4.Text = "Small repairs, leaking taps, blocked\r\ndrains and basic plumbing work.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 191);
            label5.Name = "label5";
            label5.Size = new Size(195, 46);
            label5.TabIndex = 0;
            label5.Text = "From R650";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(10, 15);
            label6.Name = "label6";
            label6.Size = new Size(176, 46);
            label6.TabIndex = 0;
            label6.Text = "Plumbing";
            // 
            // panel3
            // 
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(403, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(388, 248);
            panel3.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(12, 79);
            label8.Name = "label8";
            label8.Size = new Size(322, 62);
            label8.TabIndex = 1;
            label8.Text = "Basic electrical repairs,\r\ninstallations and fault finding.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(15, 191);
            label9.Name = "label9";
            label9.Size = new Size(195, 46);
            label9.TabIndex = 0;
            label9.Text = "From R750";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(10, 15);
            label10.Name = "label10";
            label10.Size = new Size(163, 46);
            label10.TabIndex = 0;
            label10.Text = "Electrical\r\n";
            // 
            // panel4
            // 
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label13);
            panel4.Location = new Point(800, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(388, 248);
            panel4.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(12, 79);
            label11.Name = "label11";
            label11.Size = new Size(356, 62);
            label11.TabIndex = 1;
            label11.Text = "Air-conditioner servicing, repairs\r\nand basic HVAC maintenance.";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(15, 191);
            label12.Name = "label12";
            label12.Size = new Size(195, 46);
            label12.TabIndex = 0;
            label12.Text = "From R650";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(10, 15);
            label13.Name = "label13";
            label13.Size = new Size(111, 46);
            label13.TabIndex = 0;
            label13.Text = "HVAC";
            // 
            // panel5
            // 
            panel5.Controls.Add(label14);
            panel5.Controls.Add(label15);
            panel5.Controls.Add(label16);
            panel5.Location = new Point(1197, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(389, 248);
            panel5.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label14.ForeColor = SystemColors.ButtonHighlight;
            label14.Location = new Point(12, 79);
            label14.Name = "label14";
            label14.Size = new Size(315, 62);
            label14.TabIndex = 1;
            label14.Text = "Minor roof repairs, leaks and\r\nmaintenance.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(15, 191);
            label15.Name = "label15";
            label15.Size = new Size(195, 46);
            label15.TabIndex = 0;
            label15.Text = "From R400";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.None;
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(10, 15);
            label16.Name = "label16";
            label16.Size = new Size(147, 46);
            label16.TabIndex = 0;
            label16.Text = "Roofing";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Goldenrod;
            panel6.Controls.Add(label17);
            panel6.Controls.Add(label18);
            panel6.Controls.Add(label19);
            panel6.Location = new Point(403, 263);
            panel6.Name = "panel6";
            panel6.Size = new Size(388, 248);
            panel6.TabIndex = 0;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label17.ForeColor = SystemColors.ButtonHighlight;
            label17.Location = new Point(12, 79);
            label17.Name = "label17";
            label17.Size = new Size(342, 62);
            label17.TabIndex = 1;
            label17.Text = "Garden maintenance, trimming,\r\ncleanup and basic landscaping";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.White;
            label18.Location = new Point(15, 191);
            label18.Name = "label18";
            label18.Size = new Size(195, 46);
            label18.TabIndex = 0;
            label18.Text = "From R500";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.White;
            label19.Location = new Point(10, 15);
            label19.Name = "label19";
            label19.Size = new Size(219, 46);
            label19.TabIndex = 0;
            label19.Text = "Landscaping";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Goldenrod;
            panel7.Controls.Add(label20);
            panel7.Controls.Add(label21);
            panel7.Controls.Add(label22);
            panel7.Location = new Point(800, 263);
            panel7.Name = "panel7";
            panel7.Size = new Size(388, 248);
            panel7.TabIndex = 0;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label20.ForeColor = SystemColors.ButtonHighlight;
            label20.Location = new Point(3, 79);
            label20.Name = "label20";
            label20.Size = new Size(399, 62);
            label20.TabIndex = 1;
            label20.Text = "Small-room painting and\r\nbasic interior/exterior painting work.";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.White;
            label21.Location = new Point(15, 191);
            label21.Name = "label21";
            label21.Size = new Size(195, 46);
            label21.TabIndex = 0;
            label21.Text = "From R450";
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.None;
            label22.AutoSize = true;
            label22.BackColor = Color.Transparent;
            label22.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.White;
            label22.Location = new Point(10, 15);
            label22.Name = "label22";
            label22.Size = new Size(154, 46);
            label22.TabIndex = 0;
            label22.Text = "Painting";
            // 
            // panel8
            // 
            panel8.BackColor = Color.Goldenrod;
            panel8.Controls.Add(label23);
            panel8.Controls.Add(label24);
            panel8.Controls.Add(label25);
            panel8.Location = new Point(1197, 263);
            panel8.Name = "panel8";
            panel8.Size = new Size(389, 248);
            panel8.TabIndex = 0;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.Transparent;
            label23.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label23.ForeColor = SystemColors.ButtonHighlight;
            label23.Location = new Point(12, 79);
            label23.Name = "label23";
            label23.Size = new Size(377, 62);
            label23.TabIndex = 1;
            label23.Text = "Deep cleaning for homes, kitchens,\r\nbathrooms and other areas.";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.Transparent;
            label24.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.White;
            label24.Location = new Point(15, 191);
            label24.Name = "label24";
            label24.Size = new Size(195, 46);
            label24.TabIndex = 0;
            label24.Text = "From R450";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.None;
            label25.AutoSize = true;
            label25.BackColor = Color.Transparent;
            label25.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.White;
            label25.Location = new Point(10, 15);
            label25.Name = "label25";
            label25.Size = new Size(251, 46);
            label25.TabIndex = 0;
            label25.Text = "Deep Cleaning";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(53, 174);
            label1.Name = "label1";
            label1.Size = new Size(801, 62);
            label1.TabIndex = 0;
            label1.Text = "Plan your next home project with realistic starting prices for trusted local\r\nprofessionals.";
            // 
            // lblOnePla
            // 
            lblOnePla.AutoSize = true;
            lblOnePla.BackColor = Color.Transparent;
            lblOnePla.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOnePla.ForeColor = Color.White;
            lblOnePla.Location = new Point(53, 112);
            lblOnePla.Name = "lblOnePla";
            lblOnePla.Size = new Size(357, 46);
            lblOnePla.TabIndex = 0;
            lblOnePla.Text = "Home service pricing";
            // 
            // lblSimpleProcess
            // 
            lblSimpleProcess.AutoSize = true;
            lblSimpleProcess.BackColor = Color.Transparent;
            lblSimpleProcess.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSimpleProcess.ForeColor = Color.FromArgb(255, 128, 0);
            lblSimpleProcess.Location = new Point(62, 60);
            lblSimpleProcess.Name = "lblSimpleProcess";
            lblSimpleProcess.Size = new Size(294, 31);
            lblSimpleProcess.TabIndex = 0;
            lblSimpleProcess.Text = "Straightforward estimates";
            // 
            // frmProvidersOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 995);
            Controls.Add(pnlHowHomeHeroWorks);
            Controls.Add(pnlHomeHero);
            Name = "frmProvidersOverview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProvidersOverview";
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
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
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
        private Button btnRequestAService;
        private Button btnCreateAccount;
        private Button btnLogin;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Panel pnlHowHomeHeroWorks;
        private Label label1;
        private Label lblOnePla;
        private Label lblSimpleProcess;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label7;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel3;
        private Label label8;
        private Label label9;
        private Label label10;
        private Panel panel4;
        private Label label11;
        private Label label12;
        private Label label13;
        private Panel panel5;
        private Label label14;
        private Label label15;
        private Label label16;
        private Panel panel6;
        private Label label17;
        private Label label18;
        private Label label19;
        private Panel panel7;
        private Label label20;
        private Label label21;
        private Label label22;
        private Panel panel8;
        private Label label23;
        private Label label24;
        private Label label25;
    }
}