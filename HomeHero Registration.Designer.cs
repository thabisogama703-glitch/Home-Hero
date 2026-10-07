namespace HomeHero_2
{
    partial class frmHomeHeroRegistration
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
            components = new System.ComponentModel.Container();
            lblName = new Label();
            lblEmail = new Label();
            lblPhoneNumber = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            btnRegister = new Button();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnBack = new Button();
            ValidationError = new ErrorProvider(components);
            btnShowPassword = new Button();
            btnShowConfirmPassword = new Button();
            pnlNavigationTab = new Panel();
            label2 = new Label();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            panel2 = new Panel();
            lblCreate = new Label();
            lbCustomer = new Label();
            pnlDetails = new Panel();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            pnlNavigationTab.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            panel2.SuspendLayout();
            pnlDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(28, 36);
            lblName.Name = "lblName";
            lblName.Size = new Size(51, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(31, 141);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(47, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(28, 233);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(112, 20);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "Phone number";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(31, 330);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.Location = new Point(31, 430);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(137, 20);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Confirm password";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 128, 0);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(125, 528);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(232, 29);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Create Customer Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(28, 76);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Sandra Mokoena";
            txtName.Size = new Size(273, 27);
            txtName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(31, 181);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "you@email.com";
            txtEmail.Size = new Size(270, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(31, 272);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "082 000 0000";
            txtPhoneNumber.Size = new Size(270, 27);
            txtPhoneNumber.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(31, 375);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Create a strong password";
            txtPassword.Size = new Size(270, 27);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(31, 468);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "Repeat Password";
            txtConfirmPassword.Size = new Size(270, 27);
            txtConfirmPassword.TabIndex = 10;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 0, 64);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(334, 21);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(151, 29);
            btnBack.TabIndex = 11;
            btnBack.Text = " ← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Location = new Point(390, 375);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(94, 29);
            btnShowPassword.TabIndex = 12;
            btnShowPassword.Text = "Show password";
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // btnShowConfirmPassword
            // 
            btnShowConfirmPassword.Location = new Point(390, 466);
            btnShowConfirmPassword.Name = "btnShowConfirmPassword";
            btnShowConfirmPassword.Size = new Size(94, 29);
            btnShowConfirmPassword.TabIndex = 13;
            btnShowConfirmPassword.Text = "show confirm password";
            btnShowConfirmPassword.UseVisualStyleBackColor = true;
            btnShowConfirmPassword.Click += btnShowConfirmPassword_Click;
            // 
            // pnlNavigationTab
            // 
            pnlNavigationTab.BackColor = Color.FromArgb(0, 0, 64);
            pnlNavigationTab.Controls.Add(label2);
            pnlNavigationTab.Controls.Add(pnlHomeHeroLogo);
            pnlNavigationTab.Dock = DockStyle.Top;
            pnlNavigationTab.Location = new Point(0, 0);
            pnlNavigationTab.Name = "pnlNavigationTab";
            pnlNavigationTab.RightToLeft = RightToLeft.Yes;
            pnlNavigationTab.Size = new Size(1595, 108);
            pnlNavigationTab.TabIndex = 14;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(717, 35);
            label2.Name = "label2";
            label2.Size = new Size(160, 38);
            label2.TabIndex = 13;
            label2.Text = "HomeHero";
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
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(lblCreate);
            panel2.Controls.Add(lbCustomer);
            panel2.Controls.Add(btnBack);
            panel2.Location = new Point(717, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(510, 104);
            panel2.TabIndex = 15;
            // 
            // lblCreate
            // 
            lblCreate.AutoSize = true;
            lblCreate.FlatStyle = FlatStyle.Flat;
            lblCreate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreate.ForeColor = Color.White;
            lblCreate.Location = new Point(12, 54);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(228, 31);
            lblCreate.TabIndex = 13;
            lblCreate.Text = "Create your account";
            // 
            // lbCustomer
            // 
            lbCustomer.AutoSize = true;
            lbCustomer.FlatStyle = FlatStyle.Flat;
            lbCustomer.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCustomer.ForeColor = Color.FromArgb(255, 128, 0);
            lbCustomer.Location = new Point(12, 9);
            lbCustomer.Name = "lbCustomer";
            lbCustomer.Size = new Size(157, 23);
            lbCustomer.TabIndex = 11;
            lbCustomer.Text = "Customer Account";
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = Color.White;
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(txtName);
            pnlDetails.Controls.Add(lblName);
            pnlDetails.Controls.Add(txtEmail);
            pnlDetails.Controls.Add(btnRegister);
            pnlDetails.Controls.Add(btnShowConfirmPassword);
            pnlDetails.Controls.Add(lblEmail);
            pnlDetails.Controls.Add(btnShowPassword);
            pnlDetails.Controls.Add(txtPhoneNumber);
            pnlDetails.Controls.Add(lblPhoneNumber);
            pnlDetails.Controls.Add(txtConfirmPassword);
            pnlDetails.Controls.Add(lblConfirmPassword);
            pnlDetails.Controls.Add(txtPassword);
            pnlDetails.Controls.Add(lblPassword);
            pnlDetails.Location = new Point(717, 267);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(510, 580);
            pnlDetails.TabIndex = 16;
            // 
            // frmHomeHeroRegistration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1595, 935);
            Controls.Add(pnlDetails);
            Controls.Add(panel2);
            Controls.Add(pnlNavigationTab);
            Name = "frmHomeHeroRegistration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeHero_Registration";
            WindowState = FormWindowState.Maximized;
            Load += frmHomeHeroRegistration_Load;
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            pnlNavigationTab.ResumeLayout(false);
            pnlNavigationTab.PerformLayout();
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

        private Label lblName;
        private Label lblEmail;
        private Label lblPhoneNumber;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Button btnRegister;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnBack;
        private ErrorProvider ValidationError;
        private Button btnShowConfirmPassword;
        private Button btnShowPassword;
        private Panel pnlNavigationTab;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Panel panel2;
        private Label lblCreate;
        private Label lbCustomer;
        private Panel pnlDetails;
        private Label label2;
    }
}