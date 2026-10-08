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
            lnklblHome = new LinkLabel();
            pnlServicesButtons = new Panel();
            btnRequestAService = new Button();
            btnCreateAccount = new Button();
            btnLogin = new Button();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            panel1 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button8 = new Button();
            button3 = new Button();
            button7 = new Button();
            btnElectrical = new Button();
            button6 = new Button();
            btnPlumbing = new Button();
            lblDescription = new Label();
            label1 = new Label();
            lblWhatWeOffer = new Label();
            pnlHomeHero.SuspendLayout();
            tblpHomeHeroPanel.SuspendLayout();
            flpNavigationTab.SuspendLayout();
            pnlServicesButtons.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
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
            flpNavigationTab.Controls.Add(lnklblProviders);
            flpNavigationTab.Location = new Point(400, 38);
            flpNavigationTab.Name = "flpNavigationTab";
            flpNavigationTab.Size = new Size(625, 31);
            flpNavigationTab.TabIndex = 6;
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
            // lnklblProviders
            // 
            lnklblProviders.AutoSize = true;
            lnklblProviders.Font = new Font("Segoe UI", 13.8F);
            lnklblProviders.LinkBehavior = LinkBehavior.NeverUnderline;
            lnklblProviders.LinkColor = Color.LightGray;
            lnklblProviders.Location = new Point(491, 0);
            lnklblProviders.Margin = new Padding(25, 0, 25, 0);
            lnklblProviders.Name = "lnklblProviders";
            lnklblProviders.Size = new Size(109, 31);
            lnklblProviders.TabIndex = 3;
            lnklblProviders.TabStop = true;
            lnklblProviders.Text = "Providers";
            lnklblProviders.LinkClicked += lnklblProviders_LinkClicked;
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
            // panel1
            // 
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(btnElectrical);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(btnPlumbing);
            panel1.Controls.Add(lblDescription);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblWhatWeOffer);
            panel1.Location = new Point(98, 171);
            panel1.Name = "panel1";
            panel1.Size = new Size(1678, 812);
            panel1.TabIndex = 2;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 128, 0);
            button5.Font = new Font("Segoe UI", 13.8F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1348, 386);
            button5.Name = "button5";
            button5.Size = new Size(330, 155);
            button5.TabIndex = 3;
            button5.Text = "\U0001fa9f\r\nWindows & Doors";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button4.Font = new Font("Segoe UI", 13.8F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(1011, 386);
            button4.Name = "button4";
            button4.Size = new Size(330, 155);
            button4.TabIndex = 3;
            button4.Text = "🏠\r\nRoofing";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(0, 0, 64);
            button8.Font = new Font("Segoe UI", 13.8F);
            button8.ForeColor = Color.White;
            button8.Location = new Point(675, 561);
            button8.Name = "button8";
            button8.Size = new Size(330, 155);
            button8.TabIndex = 3;
            button8.Text = "\U0001f9f9\r\nDeep Cleaning";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 0);
            button3.Font = new Font("Segoe UI", 13.8F);
            button3.Location = new Point(675, 386);
            button3.Name = "button3";
            button3.Size = new Size(330, 155);
            button3.TabIndex = 3;
            button3.Text = "❄️\r\nHVAC";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(255, 128, 0);
            button7.Font = new Font("Segoe UI", 13.8F);
            button7.ForeColor = Color.White;
            button7.Location = new Point(339, 561);
            button7.Name = "button7";
            button7.Size = new Size(330, 155);
            button7.TabIndex = 3;
            button7.Text = "🎨\r\nPainting";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // btnElectrical
            // 
            btnElectrical.BackColor = Color.FromArgb(0, 0, 64);
            btnElectrical.Font = new Font("Segoe UI", 13.8F);
            btnElectrical.ForeColor = Color.White;
            btnElectrical.Location = new Point(339, 386);
            btnElectrical.Name = "btnElectrical";
            btnElectrical.Size = new Size(330, 155);
            btnElectrical.TabIndex = 3;
            btnElectrical.Text = "⚡\r\nElectrical";
            btnElectrical.UseVisualStyleBackColor = false;
            btnElectrical.Click += btnElectrical_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(0, 0, 64);
            button6.Font = new Font("Segoe UI", 13.8F);
            button6.ForeColor = Color.White;
            button6.Location = new Point(3, 561);
            button6.Name = "button6";
            button6.Size = new Size(330, 155);
            button6.TabIndex = 3;
            button6.Text = "🌿\r\nLandscaping";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // btnPlumbing
            // 
            btnPlumbing.BackColor = Color.FromArgb(255, 128, 0);
            btnPlumbing.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPlumbing.ForeColor = Color.White;
            btnPlumbing.Location = new Point(3, 386);
            btnPlumbing.Name = "btnPlumbing";
            btnPlumbing.Size = new Size(330, 155);
            btnPlumbing.TabIndex = 3;
            btnPlumbing.Text = "🔧\r\nPlumbing";
            btnPlumbing.UseVisualStyleBackColor = false;
            btnPlumbing.Click += btnPlumbing_Click;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(39, 238);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(744, 114);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "From emergency repairs to scheduled maintenance, our\r\nnetwork covers all the trades that keep your home running\r\nsmoothly.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 94);
            label1.Name = "label1";
            label1.Size = new Size(465, 124);
            label1.TabIndex = 1;
            label1.Text = "Every home service,\r\nin one place";
            // 
            // lblWhatWeOffer
            // 
            lblWhatWeOffer.AutoSize = true;
            lblWhatWeOffer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWhatWeOffer.ForeColor = Color.FromArgb(255, 128, 0);
            lblWhatWeOffer.Location = new Point(39, 42);
            lblWhatWeOffer.Name = "lblWhatWeOffer";
            lblWhatWeOffer.Size = new Size(130, 20);
            lblWhatWeOffer.TabIndex = 0;
            lblWhatWeOffer.Text = "WHAT WE OFFER";
            // 
            // frmServicesOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 995);
            Controls.Add(panel1);
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
        private LinkLabel lnklblProviders;
        private LinkLabel lnklblHome;
        private Panel pnlServicesButtons;
        private Button btnRequestAService;
        private Button btnCreateAccount;
        private Button btnLogin;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Panel panel1;
        private Label label1;
        private Label lblWhatWeOffer;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button btnElectrical;
        private Button btnPlumbing;
        private Label lblDescription;
        private Button button8;
        private Button button7;
        private Button button6;
    }
}