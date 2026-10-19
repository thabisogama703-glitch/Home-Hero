using Guna.UI2.WinForms;

namespace HomeHero_2
{
    partial class frmHomeHeroLogin
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
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new Guna2TextBox();
            txtPassword = new Guna2TextBox();
            btnLogin = new Guna2Button();
            ValidationError = new ErrorProvider(components);
            btnShowPassword = new Guna2Button();
            pnlNavigationTab = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblName = new Label();
            btnBack = new Guna2Button();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            lblWelcome = new Label();
            lblLog = new Label();
            panel2 = new Panel();
            lblLoginSummary = new Label();
            pnlDetails = new Panel();
            chkRemember = new CheckBox();
            label2 = new Label();
            button1 = new Guna2Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            lblEasyBook = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            pnlNavigationTab.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            panel2.SuspendLayout();
            pnlDetails.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(25, 69);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(105, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email address";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(25, 198);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password ";
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 10;
            txtEmail.BorderColor = Color.FromArgb(206, 212, 218);
            txtEmail.FillColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(25, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.Gray;
            txtEmail.PlaceholderText = "johndoe123@gmail.com";
            txtEmail.Size = new Size(577, 42);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderRadius = 10;
            txtPassword.BorderColor = Color.FromArgb(206, 212, 218);
            txtPassword.FillColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(25, 250);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderForeColor = Color.Gray;
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(477, 42);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 10;
            btnLogin.FillColor = Color.FromArgb(255, 128, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverState.FillColor = Color.FromArgb(255, 147, 64);
            btnLogin.Location = new Point(25, 372);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(577, 42);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BorderRadius = 8;
            btnShowPassword.FillColor = Color.FromArgb(240, 240, 240);
            btnShowPassword.ForeColor = Color.FromArgb(17, 17, 17);
            btnShowPassword.Location = new Point(508, 250);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(94, 42);
            btnShowPassword.TabIndex = 8;
            btnShowPassword.Text = "Show";
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // pnlNavigationTab
            // 
            pnlNavigationTab.BackColor = Color.FromArgb(0, 0, 64);
            pnlNavigationTab.Controls.Add(tableLayoutPanel1);
            pnlNavigationTab.Controls.Add(pnlHomeHeroLogo);
            pnlNavigationTab.Dock = DockStyle.Top;
            pnlNavigationTab.Location = new Point(0, 0);
            pnlNavigationTab.Name = "pnlNavigationTab";
            pnlNavigationTab.RightToLeft = RightToLeft.Yes;
            pnlNavigationTab.Size = new Size(1705, 108);
            pnlNavigationTab.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 622F));
            tableLayoutPanel1.Controls.Add(lblName, 1, 0);
            tableLayoutPanel1.Controls.Add(btnBack, 0, 0);
            tableLayoutPanel1.Location = new Point(522, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1137, 105);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.None;
            lblName.AutoSize = true;
            lblName.FlatStyle = FlatStyle.Flat;
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(231, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(160, 38);
            lblName.TabIndex = 11;
            lblName.Text = "HomeHero";
            lblName.Click += lblName_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Left;
            btnBack.AutoSize = true;
            btnBack.FillColor = Color.Transparent;
            btnBack.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(972, 29);
            btnBack.Name = "btnBack";
            btnBack.RightToLeft = RightToLeft.No;
            btnBack.Size = new Size(162, 46);
            btnBack.TabIndex = 10;
            btnBack.Text = " ← Back to Home";
            btnBack.Click += btnBack_Click;
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
            pbxHomeHeroLogo.Image = Home_Hero.Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(36, 28);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(48, 47);
            pbxHomeHeroLogo.TabIndex = 10;
            pbxHomeHeroLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.FlatStyle = FlatStyle.Flat;
            lblWelcome.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(255, 128, 0);
            lblWelcome.Location = new Point(17, 32);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(127, 23);
            lblWelcome.TabIndex = 11;
            lblWelcome.Text = "Welcome Back";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.FlatStyle = FlatStyle.Flat;
            lblLog.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLog.ForeColor = Color.White;
            lblLog.Location = new Point(12, 54);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(304, 41);
            lblLog.TabIndex = 13;
            lblLog.Text = "Log in to HomeHero";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(lblLoginSummary);
            panel2.Controls.Add(lblLog);
            panel2.Controls.Add(lblWelcome);
            panel2.Location = new Point(110, 144);
            panel2.Name = "panel2";
            panel2.Size = new Size(669, 226);
            panel2.TabIndex = 12;
            // 
            // lblLoginSummary
            // 
            lblLoginSummary.AutoSize = true;
            lblLoginSummary.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoginSummary.ForeColor = Color.LightGray;
            lblLoginSummary.Location = new Point(12, 104);
            lblLoginSummary.Name = "lblLoginSummary";
            lblLoginSummary.Size = new Size(376, 23);
            lblLoginSummary.TabIndex = 14;
            lblLoginSummary.Text = "Access your account and get things done, faster";
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = Color.White;
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(chkRemember);
            pnlDetails.Controls.Add(label2);
            pnlDetails.Controls.Add(button1);
            pnlDetails.Controls.Add(txtEmail);
            pnlDetails.Controls.Add(lblEmail);
            pnlDetails.Controls.Add(lblPassword);
            pnlDetails.Controls.Add(btnShowPassword);
            pnlDetails.Controls.Add(btnLogin);
            pnlDetails.Controls.Add(txtPassword);
            pnlDetails.Location = new Point(110, 290);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(669, 510);
            pnlDetails.TabIndex = 14;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Location = new Point(25, 320);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(129, 24);
            chkRemember.TabIndex = 11;
            chkRemember.Text = "Remember me";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 450);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 10;
            label2.Text = "Don't have an account?";
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.FillColor = Color.WhiteSmoke;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(255, 128, 0);
            button1.Location = new Point(220, 450);
            button1.Name = "button1";
            button1.Size = new Size(130, 29);
            button1.TabIndex = 9;
            button1.Text = "Create Account";
            button1.Click += button1_Click_1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.BackColor = Color.FromArgb(0, 0, 64);
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label3, 2, 0);
            tableLayoutPanel2.Controls.Add(lblEasyBook, 1, 0);
            tableLayoutPanel2.Controls.Add(label4, 3, 0);
            tableLayoutPanel2.Location = new Point(0, 868);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1705, 109);
            tableLayoutPanel2.TabIndex = 15;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(83, 26);
            label1.Name = "label1";
            label1.Size = new Size(260, 56);
            label1.TabIndex = 0;
            label1.Text = "\U0001f91d Trusted Proffesionals\r\n     Verified and rated experts";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(972, 26);
            label3.Name = "label3";
            label3.Size = new Size(185, 56);
            label3.TabIndex = 1;
            label3.Text = "🔒Secure Payments\r\n     Safe And reliable";
            // 
            // lblEasyBook
            // 
            lblEasyBook.Anchor = AnchorStyles.None;
            lblEasyBook.AutoSize = true;
            lblEasyBook.Font = new Font("Segoe UI", 12F);
            lblEasyBook.ForeColor = Color.White;
            lblEasyBook.Location = new Point(521, 26);
            lblEasyBook.Name = "lblEasyBook";
            lblEasyBook.Size = new Size(235, 56);
            lblEasyBook.TabIndex = 1;
            lblEasyBook.Text = "⌚Fast And Easy Booking\r\n     Book in Minutes";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1296, 26);
            label4.Name = "label4";
            label4.Size = new Size(391, 56);
            label4.TabIndex = 1;
            label4.Text = "🏠Home Services\r\n      Repairs,cleaning, maintenance and more";
            // 
            // frmHomeHeroLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Home_Hero.Properties.Resources.BackG_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1705, 971);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(pnlDetails);
            Controls.Add(panel2);
            Controls.Add(pnlNavigationTab);
            Name = "frmHomeHeroLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeHeroLogin";
            WindowState = FormWindowState.Maximized;
            Load += frmHomeHeroLogin_Load;
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            pnlNavigationTab.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlHomeHeroLogo.ResumeLayout(false);
            pnlHomeHeroLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private Label lblPassword;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPassword;
        private Guna2Button btnLogin;
        private ErrorProvider ValidationError;
        private Guna2Button btnShowPassword;
        private Panel pnlNavigationTab;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Guna2Button btnBack;
        private Label lblName;
        private Panel panel2;
        private Label lblLog;
        private Label lblWelcome;
        private Panel pnlDetails;
        private Label label2;
        private Guna2Button button1;
        private CheckBox chkRemember;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblLoginSummary;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label3;
        private Label lblEasyBook;
        private Label label4;
    }
}
