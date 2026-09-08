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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            lblLoginAs = new Label();
            cmbLoginAs = new ComboBox();
            btnLogin = new Button();
            btnRegister = new Button();
            ValidationError = new ErrorProvider(components);
            btnShowPassword = new Button();
            pnlNavigationTab = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblName = new Label();
            btnBack = new Button();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            lblWelcome = new Label();
            lblLog = new Label();
            panel2 = new Panel();
            pnlDetails = new Panel();
            chkRemember = new CheckBox();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            pnlNavigationTab.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            panel2.SuspendLayout();
            pnlDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(33, 66);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(105, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email address";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(35, 169);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(35, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(252, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(35, 207);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(252, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblLoginAs
            // 
            lblLoginAs.AutoSize = true;
            lblLoginAs.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginAs.Location = new Point(35, 273);
            lblLoginAs.Name = "lblLoginAs";
            lblLoginAs.Size = new Size(71, 20);
            lblLoginAs.TabIndex = 4;
            lblLoginAs.Text = "Login as ";
            // 
            // cmbLoginAs
            // 
            cmbLoginAs.FormattingEnabled = true;
            cmbLoginAs.Items.AddRange(new object[] { "Customer", "Service Provider", "Administrator" });
            cmbLoginAs.Location = new Point(35, 314);
            cmbLoginAs.Name = "cmbLoginAs";
            cmbLoginAs.Size = new Size(252, 28);
            cmbLoginAs.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 128, 0);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(222, 376);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 128, 0);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(146, 446);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(253, 31);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += button1_Click;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Location = new Point(350, 207);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(94, 29);
            btnShowPassword.TabIndex = 8;
            btnShowPassword.Text = "Show password";
            btnShowPassword.UseVisualStyleBackColor = true;
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
            pnlNavigationTab.Size = new Size(1595, 108);
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
            tableLayoutPanel1.Location = new Point(467, 0);
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
            btnBack.Anchor = AnchorStyles.None;
            btnBack.AutoSize = true;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(799, 29);
            btnBack.Name = "btnBack";
            btnBack.RightToLeft = RightToLeft.No;
            btnBack.Size = new Size(162, 46);
            btnBack.TabIndex = 10;
            btnBack.Text = " ← Back to Home";
            btnBack.UseVisualStyleBackColor = true;
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
            lblWelcome.Location = new Point(12, 14);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(127, 23);
            lblWelcome.TabIndex = 11;
            lblWelcome.Text = "Welcome Back";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.FlatStyle = FlatStyle.Flat;
            lblLog.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLog.ForeColor = Color.White;
            lblLog.Location = new Point(12, 54);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(234, 31);
            lblLog.TabIndex = 13;
            lblLog.Text = "Log in to HomeHero";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(lblLog);
            panel2.Controls.Add(lblWelcome);
            panel2.Location = new Point(725, 182);
            panel2.Name = "panel2";
            panel2.Size = new Size(510, 104);
            panel2.TabIndex = 12;
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
            pnlDetails.Controls.Add(txtPassword);
            pnlDetails.Controls.Add(lblPassword);
            pnlDetails.Controls.Add(btnRegister);
            pnlDetails.Controls.Add(btnShowPassword);
            pnlDetails.Controls.Add(btnLogin);
            pnlDetails.Controls.Add(cmbLoginAs);
            pnlDetails.Controls.Add(lblLoginAs);
            pnlDetails.Location = new Point(725, 284);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(510, 571);
            pnlDetails.TabIndex = 14;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Location = new Point(35, 399);
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
            label2.Location = new Point(122, 515);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 10;
            label2.Text = "Don't have an account?";
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(255, 128, 0);
            button1.Location = new Point(291, 511);
            button1.Name = "button1";
            button1.Size = new Size(130, 29);
            button1.TabIndex = 9;
            button1.Text = "Create Account";
            button1.UseVisualStyleBackColor = false;
            // 
            // frmHomeHeroLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1595, 935);
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
            ResumeLayout(false);
        }

        #endregion

        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lblLoginAs;
        private ComboBox cmbLoginAs;
        private Button btnLogin;
        private Button btnRegister;
        private ErrorProvider ValidationError;
        private Button btnShowPassword;
        private Panel pnlNavigationTab;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Button btnBack;
        private Label lblName;
        private Panel panel2;
        private Label lblLog;
        private Label lblWelcome;
        private Panel pnlDetails;
        private Label label2;
        private Button button1;
        private CheckBox chkRemember;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
