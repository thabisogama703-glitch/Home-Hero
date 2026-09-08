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
            button1 = new Button();
            ValidationError = new ErrorProvider(components);
            btnShowPassword = new Button();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(57, 36);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(57, 88);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(81, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password : ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(185, 36);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(185, 103);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblLoginAs
            // 
            lblLoginAs.AutoSize = true;
            lblLoginAs.Location = new Point(57, 158);
            lblLoginAs.Name = "lblLoginAs";
            lblLoginAs.Size = new Size(75, 20);
            lblLoginAs.TabIndex = 4;
            lblLoginAs.Text = "Login as : ";
            // 
            // cmbLoginAs
            // 
            cmbLoginAs.FormattingEnabled = true;
            cmbLoginAs.Items.AddRange(new object[] { "Customer", "Service Provider", "Administrator" });
            cmbLoginAs.Location = new Point(185, 158);
            cmbLoginAs.Name = "cmbLoginAs";
            cmbLoginAs.Size = new Size(125, 28);
            cmbLoginAs.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(216, 220);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // button1
            // 
            button1.Location = new Point(57, 283);
            button1.Name = "button1";
            button1.Size = new Size(253, 29);
            button1.TabIndex = 7;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Location = new Point(329, 103);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(94, 29);
            btnShowPassword.TabIndex = 8;
            btnShowPassword.Text = "Show password";
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // frmHomeHeroLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 623);
            Controls.Add(btnShowPassword);
            Controls.Add(button1);
            Controls.Add(btnLogin);
            Controls.Add(cmbLoginAs);
            Controls.Add(lblLoginAs);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Name = "frmHomeHeroLogin";
            Text = "HomeHeroLogin";
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lblLoginAs;
        private ComboBox cmbLoginAs;
        private Button btnLogin;
        private Button button1;
        private ErrorProvider ValidationError;
        private Button btnShowPassword;
    }
}
