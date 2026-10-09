namespace Home_Hero
{
    partial class frmCreateServiceProvider
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
            pnlNavigationTab = new Panel();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            pnlHomeHeroLogo = new Panel();
            lblHero = new Label();
            lblHome = new Label();
            pbxHomeHeroLogo = new PictureBox();
            pnlDetails = new Panel();
            txtName = new TextBox();
            lblName = new Label();
            txtEmail = new TextBox();
            btnRegister = new Button();
            btnShowConfirmPassword = new Button();
            lblEmail = new Label();
            btnShowPassword = new Button();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            gbxPersonalInformation = new GroupBox();
            gbxServicesAndPlace = new GroupBox();
            txtServiceArea = new TextBox();
            lblAreaofWork = new Label();
            chkbxPainting = new CheckBox();
            chkbxPlumbing = new CheckBox();
            chkbxDeepCleaning = new CheckBox();
            lblSpecialisation = new Label();
            chkbxLandscaping = new CheckBox();
            chkBxElectrical = new CheckBox();
            chkbxWindowsDoors = new CheckBox();
            chkbxHVAC = new CheckBox();
            chkbxRoofing = new CheckBox();
            panel2 = new Panel();
            lblCreate = new Label();
            lbCustomer = new Label();
            btnBack = new Button();
            ValidationError = new ErrorProvider(components);
            pnlNavigationTab.SuspendLayout();
            pnlHomeHeroLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            pnlDetails.SuspendLayout();
            gbxServicesAndPlace.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            SuspendLayout();
            // 
            // pnlNavigationTab
            // 
            pnlNavigationTab.BackColor = Color.FromArgb(0, 0, 64);
            pnlNavigationTab.Controls.Add(button1);
            pnlNavigationTab.Controls.Add(label1);
            pnlNavigationTab.Controls.Add(label2);
            pnlNavigationTab.Controls.Add(pnlHomeHeroLogo);
            pnlNavigationTab.Dock = DockStyle.Top;
            pnlNavigationTab.Location = new Point(0, 0);
            pnlNavigationTab.Name = "pnlNavigationTab";
            pnlNavigationTab.RightToLeft = RightToLeft.Yes;
            pnlNavigationTab.Size = new Size(1886, 108);
            pnlNavigationTab.TabIndex = 15;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1633, 36);
            button1.Name = "button1";
            button1.Size = new Size(201, 47);
            button1.TabIndex = 15;
            button1.Text = "Sign Up as Homeowner";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1455, 49);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(172, 20);
            label1.TabIndex = 14;
            label1.Text = "Here to Find a Hero? 👉";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(838, 35);
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
            pbxHomeHeroLogo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(36, 28);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(48, 47);
            pbxHomeHeroLogo.TabIndex = 10;
            pbxHomeHeroLogo.TabStop = false;
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
            pnlDetails.Controls.Add(gbxPersonalInformation);
            pnlDetails.Controls.Add(gbxServicesAndPlace);
            pnlDetails.Location = new Point(564, 266);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(904, 590);
            pnlDetails.TabIndex = 18;
            pnlDetails.Paint += pnlDetails_Paint;
            // 
            // txtName
            // 
            txtName.Location = new Point(28, 76);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Sandra Mokoena";
            txtName.Size = new Size(273, 27);
            txtName.TabIndex = 6;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(28, 36);
            lblName.Name = "lblName";
            lblName.Size = new Size(51, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(31, 181);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "you@email.com";
            txtEmail.Size = new Size(270, 27);
            txtEmail.TabIndex = 7;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 128, 0);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(398, 545);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(232, 29);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Create Service Provider Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnShowConfirmPassword
            // 
            btnShowConfirmPassword.ForeColor = Color.Black;
            btnShowConfirmPassword.Location = new Point(390, 466);
            btnShowConfirmPassword.Name = "btnShowConfirmPassword";
            btnShowConfirmPassword.Size = new Size(94, 29);
            btnShowConfirmPassword.TabIndex = 13;
            btnShowConfirmPassword.Text = "show confirm password";
            btnShowConfirmPassword.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(31, 141);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(47, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // btnShowPassword
            // 
            btnShowPassword.ForeColor = Color.Black;
            btnShowPassword.Location = new Point(390, 375);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(94, 29);
            btnShowPassword.TabIndex = 12;
            btnShowPassword.Text = "Show password";
            btnShowPassword.UseVisualStyleBackColor = true;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(31, 272);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "082 000 0000";
            txtPhoneNumber.Size = new Size(270, 27);
            txtPhoneNumber.TabIndex = 8;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhoneNumber.ForeColor = Color.Black;
            lblPhoneNumber.Location = new Point(28, 233);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(112, 20);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "Phone number";
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
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.ForeColor = Color.Black;
            lblConfirmPassword.Location = new Point(31, 430);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(137, 20);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Confirm password";
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
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(31, 330);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // gbxPersonalInformation
            // 
            gbxPersonalInformation.Location = new Point(11, 9);
            gbxPersonalInformation.Name = "gbxPersonalInformation";
            gbxPersonalInformation.Size = new Size(488, 516);
            gbxPersonalInformation.TabIndex = 16;
            gbxPersonalInformation.TabStop = false;
            gbxPersonalInformation.Text = "Personal Information";
            // 
            // gbxServicesAndPlace
            // 
            gbxServicesAndPlace.Controls.Add(txtServiceArea);
            gbxServicesAndPlace.Controls.Add(lblAreaofWork);
            gbxServicesAndPlace.Controls.Add(chkbxPainting);
            gbxServicesAndPlace.Controls.Add(chkbxPlumbing);
            gbxServicesAndPlace.Controls.Add(chkbxDeepCleaning);
            gbxServicesAndPlace.Controls.Add(lblSpecialisation);
            gbxServicesAndPlace.Controls.Add(chkbxLandscaping);
            gbxServicesAndPlace.Controls.Add(chkBxElectrical);
            gbxServicesAndPlace.Controls.Add(chkbxWindowsDoors);
            gbxServicesAndPlace.Controls.Add(chkbxHVAC);
            gbxServicesAndPlace.Controls.Add(chkbxRoofing);
            gbxServicesAndPlace.Location = new Point(505, 9);
            gbxServicesAndPlace.Name = "gbxServicesAndPlace";
            gbxServicesAndPlace.Size = new Size(389, 516);
            gbxServicesAndPlace.TabIndex = 17;
            gbxServicesAndPlace.TabStop = false;
            gbxServicesAndPlace.Text = "Services and Location";
            // 
            // txtServiceArea
            // 
            txtServiceArea.Location = new Point(16, 293);
            txtServiceArea.Multiline = true;
            txtServiceArea.Name = "txtServiceArea";
            txtServiceArea.Size = new Size(349, 193);
            txtServiceArea.TabIndex = 17;
            // 
            // lblAreaofWork
            // 
            lblAreaofWork.AutoSize = true;
            lblAreaofWork.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAreaofWork.ForeColor = Color.Black;
            lblAreaofWork.Location = new Point(16, 266);
            lblAreaofWork.Name = "lblAreaofWork";
            lblAreaofWork.Size = new Size(96, 20);
            lblAreaofWork.TabIndex = 16;
            lblAreaofWork.Text = "Service Area";
            // 
            // chkbxPainting
            // 
            chkbxPainting.AutoSize = true;
            chkbxPainting.ForeColor = Color.Black;
            chkbxPainting.Location = new Point(15, 196);
            chkbxPainting.Name = "chkbxPainting";
            chkbxPainting.Size = new Size(109, 24);
            chkbxPainting.TabIndex = 15;
            chkbxPainting.Text = "🎨 Painting\r\n";
            chkbxPainting.UseVisualStyleBackColor = true;
            // 
            // chkbxPlumbing
            // 
            chkbxPlumbing.AutoSize = true;
            chkbxPlumbing.ForeColor = Color.Black;
            chkbxPlumbing.Location = new Point(15, 67);
            chkbxPlumbing.Name = "chkbxPlumbing";
            chkbxPlumbing.Size = new Size(119, 24);
            chkbxPlumbing.TabIndex = 15;
            chkbxPlumbing.Text = "🔧 Plumbing";
            chkbxPlumbing.UseVisualStyleBackColor = true;
            // 
            // chkbxDeepCleaning
            // 
            chkbxDeepCleaning.AutoSize = true;
            chkbxDeepCleaning.ForeColor = Color.Black;
            chkbxDeepCleaning.Location = new Point(226, 196);
            chkbxDeepCleaning.Name = "chkbxDeepCleaning";
            chkbxDeepCleaning.Size = new Size(154, 24);
            chkbxDeepCleaning.TabIndex = 15;
            chkbxDeepCleaning.Text = "\U0001f9f9 Deep Cleaning\r\n";
            chkbxDeepCleaning.UseVisualStyleBackColor = true;
            // 
            // lblSpecialisation
            // 
            lblSpecialisation.AutoSize = true;
            lblSpecialisation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpecialisation.ForeColor = Color.Black;
            lblSpecialisation.Location = new Point(12, 27);
            lblSpecialisation.Name = "lblSpecialisation";
            lblSpecialisation.Size = new Size(104, 20);
            lblSpecialisation.TabIndex = 0;
            lblSpecialisation.Text = "Specialization";
            // 
            // chkbxLandscaping
            // 
            chkbxLandscaping.AutoSize = true;
            chkbxLandscaping.ForeColor = Color.Black;
            chkbxLandscaping.Location = new Point(226, 154);
            chkbxLandscaping.Name = "chkbxLandscaping";
            chkbxLandscaping.Size = new Size(139, 24);
            chkbxLandscaping.TabIndex = 15;
            chkbxLandscaping.Text = "🌿 Landscaping";
            chkbxLandscaping.UseVisualStyleBackColor = true;
            chkbxLandscaping.CheckedChanged += chkbxLandscaping_CheckedChanged;
            // 
            // chkBxElectrical
            // 
            chkBxElectrical.AutoSize = true;
            chkBxElectrical.ForeColor = Color.Black;
            chkBxElectrical.Location = new Point(226, 67);
            chkBxElectrical.Name = "chkBxElectrical";
            chkBxElectrical.Size = new Size(116, 24);
            chkBxElectrical.TabIndex = 15;
            chkBxElectrical.Text = "⚡ Electrical";
            chkBxElectrical.UseVisualStyleBackColor = true;
            // 
            // chkbxWindowsDoors
            // 
            chkbxWindowsDoors.AutoSize = true;
            chkbxWindowsDoors.ForeColor = Color.Black;
            chkbxWindowsDoors.Location = new Point(15, 154);
            chkbxWindowsDoors.Name = "chkbxWindowsDoors";
            chkbxWindowsDoors.Size = new Size(165, 24);
            chkbxWindowsDoors.TabIndex = 15;
            chkbxWindowsDoors.Text = "\U0001fa9f Windows & Doors";
            chkbxWindowsDoors.UseVisualStyleBackColor = true;
            // 
            // chkbxHVAC
            // 
            chkbxHVAC.AutoSize = true;
            chkbxHVAC.ForeColor = Color.Black;
            chkbxHVAC.Location = new Point(226, 114);
            chkbxHVAC.Name = "chkbxHVAC";
            chkbxHVAC.Size = new Size(94, 24);
            chkbxHVAC.TabIndex = 15;
            chkbxHVAC.Text = "❄️ HVAC";
            chkbxHVAC.UseVisualStyleBackColor = true;
            // 
            // chkbxRoofing
            // 
            chkbxRoofing.AutoSize = true;
            chkbxRoofing.ForeColor = Color.Black;
            chkbxRoofing.Location = new Point(15, 114);
            chkbxRoofing.Name = "chkbxRoofing";
            chkbxRoofing.Size = new Size(109, 24);
            chkbxRoofing.TabIndex = 15;
            chkbxRoofing.Text = "🏠 Roofing\r\n";
            chkbxRoofing.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(lblCreate);
            panel2.Controls.Add(lbCustomer);
            panel2.Controls.Add(btnBack);
            panel2.Location = new Point(564, 166);
            panel2.Name = "panel2";
            panel2.Size = new Size(904, 104);
            panel2.TabIndex = 17;
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
            lbCustomer.Size = new Size(141, 23);
            lbCustomer.TabIndex = 11;
            lbCustomer.Text = "Service Provider";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 0, 64);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(744, 9);
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
            // frmCreateServiceProvider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 995);
            Controls.Add(pnlDetails);
            Controls.Add(panel2);
            Controls.Add(pnlNavigationTab);
            ForeColor = Color.White;
            Name = "frmCreateServiceProvider";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCreateServiceProvider";
            WindowState = FormWindowState.Maximized;
            pnlNavigationTab.ResumeLayout(false);
            pnlNavigationTab.PerformLayout();
            pnlHomeHeroLogo.ResumeLayout(false);
            pnlHomeHeroLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            gbxServicesAndPlace.ResumeLayout(false);
            gbxServicesAndPlace.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNavigationTab;
        private Label label2;
        private Panel pnlHomeHeroLogo;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxHomeHeroLogo;
        private Panel pnlDetails;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtEmail;
        private Button btnRegister;
        private Button btnShowConfirmPassword;
        private Label lblEmail;
        private Button btnShowPassword;
        private TextBox txtPhoneNumber;
        private Label lblPhoneNumber;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private TextBox txtPassword;
        private Label lblPassword;
        private Panel panel2;
        private Label lblCreate;
        private Label lbCustomer;
        private Button btnBack;
        private Button button1;
        private Label label1;
        private CheckBox chkbxWindowsDoors;
        private CheckBox chkbxRoofing;
        private CheckBox chkbxHVAC;
        private CheckBox chkBxElectrical;
        private CheckBox chkbxPlumbing;
        private CheckBox chkbxLandscaping;
        private Label lblSpecialisation;
        private GroupBox gbxPersonalInformation;
        private CheckBox chkbxPainting;
        private CheckBox chkbxDeepCleaning;
        private GroupBox gbxServicesAndPlace;
        private ErrorProvider ValidationError;
        private TextBox txtServiceArea;
        private Label lblAreaofWork;
    }
}