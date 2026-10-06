namespace Home_Hero
{
    partial class AddProvider
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
            panel1 = new Panel();
            pnlAddProvider = new Panel();
            btnAddProvider = new Button();
            btnCancel = new Button();
            chkSpecialization = new CheckedListBox();
            txtSeaviceArea = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            panel3 = new Panel();
            label8 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pnlAddProvider.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Location = new Point(-9, -8);
            panel1.Name = "panel1";
            panel1.Size = new Size(1459, 109);
            panel1.TabIndex = 0;
            // 
            // pnlAddProvider
            // 
            pnlAddProvider.BackColor = Color.WhiteSmoke;
            pnlAddProvider.Controls.Add(btnAddProvider);
            pnlAddProvider.Controls.Add(btnCancel);
            pnlAddProvider.Controls.Add(chkSpecialization);
            pnlAddProvider.Controls.Add(txtSeaviceArea);
            pnlAddProvider.Controls.Add(txtPhone);
            pnlAddProvider.Controls.Add(txtEmail);
            pnlAddProvider.Controls.Add(txtLastName);
            pnlAddProvider.Controls.Add(txtFirstName);
            pnlAddProvider.Controls.Add(panel3);
            pnlAddProvider.Controls.Add(label2);
            pnlAddProvider.Controls.Add(label3);
            pnlAddProvider.Controls.Add(label4);
            pnlAddProvider.Controls.Add(label5);
            pnlAddProvider.Controls.Add(label6);
            pnlAddProvider.Controls.Add(label7);
            pnlAddProvider.Location = new Point(480, 129);
            pnlAddProvider.Name = "pnlAddProvider";
            pnlAddProvider.Size = new Size(619, 552);
            pnlAddProvider.TabIndex = 1;
            // 
            // btnAddProvider
            // 
            btnAddProvider.BackColor = Color.Tomato;
            btnAddProvider.Location = new Point(375, 510);
            btnAddProvider.Name = "btnAddProvider";
            btnAddProvider.Size = new Size(223, 29);
            btnAddProvider.TabIndex = 14;
            btnAddProvider.Text = "Add Provider";
            btnAddProvider.UseVisualStyleBackColor = false;
            btnAddProvider.Click += btnAddProvider_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(28, 510);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(223, 29);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chkSpecialization
            // 
            chkSpecialization.FormattingEnabled = true;
            chkSpecialization.Items.AddRange(new object[] { "Plumbing", "Electrical", "Painting", "HVAC", "Roofing", "Landscaping", "Cleaning", "Gardening", "General Maintenance" });
            chkSpecialization.Location = new Point(28, 346);
            chkSpecialization.Name = "chkSpecialization";
            chkSpecialization.Size = new Size(570, 158);
            chkSpecialization.TabIndex = 12;
            // 
            // txtSeaviceArea
            // 
            txtSeaviceArea.Location = new Point(31, 283);
            txtSeaviceArea.Name = "txtSeaviceArea";
            txtSeaviceArea.Size = new Size(570, 27);
            txtSeaviceArea.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(324, 215);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(277, 27);
            txtPhone.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(31, 215);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(256, 27);
            txtEmail.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(324, 124);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(277, 27);
            txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(31, 124);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(262, 27);
            txtFirstName.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, -8);
            panel3.Name = "panel3";
            panel3.Size = new Size(619, 88);
            panel3.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.OrangeRed;
            label8.Location = new Point(14, 21);
            label8.Name = "label8";
            label8.Size = new Size(136, 28);
            label8.TabIndex = 7;
            label8.Text = "Add Provider";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 49);
            label1.Name = "label1";
            label1.Size = new Size(216, 28);
            label1.TabIndex = 0;
            label1.Text = "New Service Provider";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 323);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Specialization";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 260);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 2;
            label3.Text = "Service Area";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(324, 176);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "Phone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 176);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 4;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(324, 101);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 5;
            label6.Text = "Last Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 101);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 6;
            label7.Text = "First Name";
            // 
            // AddProvider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 693);
            Controls.Add(pnlAddProvider);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddProvider";
            Text = "AddProvider";
            pnlAddProvider.ResumeLayout(false);
            pnlAddProvider.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlAddProvider;
        private Panel panel3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckedListBox chkSpecialization;
        private TextBox txtSeaviceArea;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Button btnAddProvider;
        private Button btnCancel;
    }
}