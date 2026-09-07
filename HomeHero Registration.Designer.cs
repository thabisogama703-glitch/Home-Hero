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
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(32, 52);
            lblName.Name = "lblName";
            lblName.Size = new Size(60, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name : ";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(32, 108);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email : ";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(32, 154);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(116, 20);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "Phone number : ";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(32, 209);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password :";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(32, 259);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(136, 20);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Confirm password :";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(222, 317);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(83, 29);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(180, 57);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(180, 108);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(180, 154);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(125, 27);
            txtPhoneNumber.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(180, 212);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(180, 252);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(125, 27);
            txtConfirmPassword.TabIndex = 10;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(32, 317);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Location = new Point(351, 217);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(94, 29);
            btnShowPassword.TabIndex = 12;
            btnShowPassword.Text = "Show password";
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // btnShowConfirmPassword
            // 
            btnShowConfirmPassword.Location = new Point(351, 259);
            btnShowConfirmPassword.Name = "btnShowConfirmPassword";
            btnShowConfirmPassword.Size = new Size(94, 29);
            btnShowConfirmPassword.TabIndex = 13;
            btnShowConfirmPassword.Text = "show confirm password";
            btnShowConfirmPassword.UseVisualStyleBackColor = true;
            btnShowConfirmPassword.Click += btnShowConfirmPassword_Click;
            // 
            // frmHomeHeroRegistration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 670);
            Controls.Add(btnShowConfirmPassword);
            Controls.Add(btnShowPassword);
            Controls.Add(btnBack);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(btnRegister);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblEmail);
            Controls.Add(lblName);
            Name = "frmHomeHeroRegistration";
            Text = "HomeHero_Registration";
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}