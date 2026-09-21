namespace HomeHero_2
{
    partial class frmForgottonPassword
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
            lblEmail = new Label();
            lblLoginAs = new Label();
            lblNewPassword = new Label();
            lblConfirmNewPassword = new Label();
            txtForgotEmail = new TextBox();
            cmbFogotLoginAs = new ComboBox();
            txtNewPssword = new TextBox();
            txtConfirmNewPassword = new TextBox();
            btnCreateNewPassword = new Button();
            ValidationError = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(40, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email :";
            // 
            // lblLoginAs
            // 
            lblLoginAs.AutoSize = true;
            lblLoginAs.Location = new Point(40, 82);
            lblLoginAs.Name = "lblLoginAs";
            lblLoginAs.Size = new Size(71, 20);
            lblLoginAs.TabIndex = 1;
            lblLoginAs.Text = "Login as :";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(40, 137);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(115, 20);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "New Password : ";
            // 
            // lblConfirmNewPassword
            // 
            lblConfirmNewPassword.AutoSize = true;
            lblConfirmNewPassword.Location = new Point(40, 192);
            lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            lblConfirmNewPassword.Size = new Size(171, 20);
            lblConfirmNewPassword.TabIndex = 3;
            lblConfirmNewPassword.Text = "Confirm new password : ";
            // 
            // txtForgotEmail
            // 
            txtForgotEmail.Location = new Point(224, 23);
            txtForgotEmail.Name = "txtForgotEmail";
            txtForgotEmail.Size = new Size(207, 27);
            txtForgotEmail.TabIndex = 4;
            // 
            // cmbFogotLoginAs
            // 
            cmbFogotLoginAs.FormattingEnabled = true;
            cmbFogotLoginAs.Items.AddRange(new object[] { "Customer", "Service Provider", "Administrator" });
            cmbFogotLoginAs.Location = new Point(224, 82);
            cmbFogotLoginAs.Name = "cmbFogotLoginAs";
            cmbFogotLoginAs.Size = new Size(207, 28);
            cmbFogotLoginAs.TabIndex = 5;
            // 
            // txtNewPssword
            // 
            txtNewPssword.Location = new Point(224, 137);
            txtNewPssword.Name = "txtNewPssword";
            txtNewPssword.Size = new Size(207, 27);
            txtNewPssword.TabIndex = 6;
            txtNewPssword.UseSystemPasswordChar = true;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Location = new Point(224, 185);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.Size = new Size(207, 27);
            txtConfirmNewPassword.TabIndex = 7;
            txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // btnCreateNewPassword
            // 
            btnCreateNewPassword.Location = new Point(224, 244);
            btnCreateNewPassword.Name = "btnCreateNewPassword";
            btnCreateNewPassword.Size = new Size(207, 29);
            btnCreateNewPassword.TabIndex = 8;
            btnCreateNewPassword.Text = "Create new password";
            btnCreateNewPassword.UseVisualStyleBackColor = true;
            btnCreateNewPassword.Click += btnCreateNewPassword_Click;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // frmForgottonPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreateNewPassword);
            Controls.Add(txtConfirmNewPassword);
            Controls.Add(txtNewPssword);
            Controls.Add(cmbFogotLoginAs);
            Controls.Add(txtForgotEmail);
            Controls.Add(lblConfirmNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(lblLoginAs);
            Controls.Add(lblEmail);
            Name = "frmForgottonPassword";
            Text = "frmForgottonPassword";
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private Label lblLoginAs;
        private Label lblNewPassword;
        private Label lblConfirmNewPassword;
        private TextBox txtForgotEmail;
        private ComboBox cmbFogotLoginAs;
        private TextBox txtNewPssword;
        private TextBox txtConfirmNewPassword;
        private Button btnCreateNewPassword;
        private ErrorProvider ValidationError;
    }
}