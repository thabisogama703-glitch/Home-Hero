namespace Home_Hero
{
    partial class frmCreateAccount
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
            lblWhatTypeOfAccountAreCreating = new Label();
            grpGetStarted = new GroupBox();
            lblCreatingAccount = new Label();
            grpCustomer = new GroupBox();
            lbl1 = new Label();
            btnCustomer = new Button();
            grpSpecialist = new GroupBox();
            label1 = new Label();
            btnSpecialist = new Button();
            grpGetStarted.SuspendLayout();
            grpCustomer.SuspendLayout();
            grpSpecialist.SuspendLayout();
            SuspendLayout();
            // 
            // lblWhatTypeOfAccountAreCreating
            // 
            lblWhatTypeOfAccountAreCreating.AutoSize = true;
            lblWhatTypeOfAccountAreCreating.Location = new Point(12, 97);
            lblWhatTypeOfAccountAreCreating.Name = "lblWhatTypeOfAccountAreCreating";
            lblWhatTypeOfAccountAreCreating.Size = new Size(280, 20);
            lblWhatTypeOfAccountAreCreating.TabIndex = 0;
            lblWhatTypeOfAccountAreCreating.Text = "What type of acccount are you creating ?";
            // 
            // grpGetStarted
            // 
            grpGetStarted.Controls.Add(lblCreatingAccount);
            grpGetStarted.Location = new Point(12, -1);
            grpGetStarted.Name = "grpGetStarted";
            grpGetStarted.Size = new Size(786, 95);
            grpGetStarted.TabIndex = 1;
            grpGetStarted.TabStop = false;
            grpGetStarted.Text = "Get Started ";
            // 
            // lblCreatingAccount
            // 
            lblCreatingAccount.AutoSize = true;
            lblCreatingAccount.Location = new Point(145, 49);
            lblCreatingAccount.Name = "lblCreatingAccount";
            lblCreatingAccount.Size = new Size(219, 20);
            lblCreatingAccount.TabIndex = 2;
            lblCreatingAccount.Text = "Create Your HomeHero account";
            // 
            // grpCustomer
            // 
            grpCustomer.Controls.Add(lbl1);
            grpCustomer.Controls.Add(btnCustomer);
            grpCustomer.Location = new Point(12, 136);
            grpCustomer.Name = "grpCustomer";
            grpCustomer.Size = new Size(728, 110);
            grpCustomer.TabIndex = 3;
            grpCustomer.TabStop = false;
            grpCustomer.Text = "Customer";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(57, 23);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(207, 80);
            lbl1.TabIndex = 3;
            lbl1.Text = "Find trusted professionals and\r\nbook home services.\r\n\r\n\r\n";
            // 
            // btnCustomer
            // 
            btnCustomer.Location = new Point(368, 26);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(319, 54);
            btnCustomer.TabIndex = 0;
            btnCustomer.Text = "Continue as a customer";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // grpSpecialist
            // 
            grpSpecialist.Controls.Add(label1);
            grpSpecialist.Controls.Add(btnSpecialist);
            grpSpecialist.Location = new Point(12, 263);
            grpSpecialist.Name = "grpSpecialist";
            grpSpecialist.Size = new Size(728, 110);
            grpSpecialist.TabIndex = 4;
            grpSpecialist.TabStop = false;
            grpSpecialist.Text = "Specialist ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 23);
            label1.Name = "label1";
            label1.Size = new Size(164, 80);
            label1.TabIndex = 4;
            label1.Text = "Offer your services and \r\nconnect with customer \r\n\r\n\r\n";
            // 
            // btnSpecialist
            // 
            btnSpecialist.Location = new Point(368, 35);
            btnSpecialist.Name = "btnSpecialist";
            btnSpecialist.Size = new Size(319, 54);
            btnSpecialist.TabIndex = 0;
            btnSpecialist.Text = "Continue as a Specialist";
            btnSpecialist.UseVisualStyleBackColor = true;
            btnSpecialist.Click += btnSpecialist_Click;
            // 
            // frmCreateAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpSpecialist);
            Controls.Add(grpCustomer);
            Controls.Add(grpGetStarted);
            Controls.Add(lblWhatTypeOfAccountAreCreating);
            Name = "frmCreateAccount";
            Text = "Form2";
            grpGetStarted.ResumeLayout(false);
            grpGetStarted.PerformLayout();
            grpCustomer.ResumeLayout(false);
            grpCustomer.PerformLayout();
            grpSpecialist.ResumeLayout(false);
            grpSpecialist.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWhatTypeOfAccountAreCreating;
        private GroupBox grpGetStarted;
        private Label lblCreatingAccount;
        private GroupBox grpCustomer;
        private Label lbl1;
        private Button btnCustomer;
        private GroupBox grpSpecialist;
        private Button btnSpecialist;
        private Label label1;
    }
}