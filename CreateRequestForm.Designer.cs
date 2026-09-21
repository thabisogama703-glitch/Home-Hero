namespace Home_Hero
{
    partial class frmCreateRequest
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
            cmbCategory = new ComboBox();
            label2 = new Label();
            txtProblemDescription = new TextBox();
            dtpDatePreferred = new DateTimePicker();
            lblEstimatedCost = new Label();
            btnSubmitRequest = new Button();
            cmbTimeSlot = new ComboBox();
            label5 = new Label();
            panel1 = new Panel();
            panel5 = new Panel();
            label1 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblDate = new Label();
            panel4 = new Panel();
            lblMinimumCharacters = new Label();
            label3 = new Label();
            lblProblemDescription = new Label();
            label6 = new Label();
            lblDescribe = new Label();
            panel3 = new Panel();
            lblServiceCategory = new Label();
            RdbtnUrgent1 = new RadioButton();
            lblServicenumber1 = new Label();
            RdbxNormalPriorityLevel1 = new RadioButton();
            lblService = new Label();
            lblPriority = new Label();
            panel2 = new Panel();
            lblRequest = new Label();
            btnBack = new Button();
            txtAddress = new TextBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(56, 160);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(403, 28);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(827, 438);
            label2.Name = "label2";
            label2.Size = new Size(150, 25);
            label2.TabIndex = 3;
            label2.Text = "Property Address";
            // 
            // txtProblemDescription
            // 
            txtProblemDescription.Location = new Point(42, 125);
            txtProblemDescription.Multiline = true;
            txtProblemDescription.Name = "txtProblemDescription";
            txtProblemDescription.PlaceholderText = "Describe what needs fixing, any relevant details about the problem.....";
            txtProblemDescription.Size = new Size(682, 235);
            txtProblemDescription.TabIndex = 4;
            // 
            // dtpDatePreferred
            // 
            dtpDatePreferred.Format = DateTimePickerFormat.Short;
            dtpDatePreferred.Location = new Point(42, 167);
            dtpDatePreferred.MinDate = new DateTime(2026, 9, 2, 0, 0, 0, 0);
            dtpDatePreferred.Name = "dtpDatePreferred";
            dtpDatePreferred.Size = new Size(210, 27);
            dtpDatePreferred.TabIndex = 6;
            // 
            // lblEstimatedCost
            // 
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstimatedCost.Location = new Point(1201, 679);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(185, 25);
            lblEstimatedCost.TabIndex = 7;
            lblEstimatedCost.Text = "Estimated Cost: R0.00";
            // 
            // btnSubmitRequest
            // 
            btnSubmitRequest.BackColor = Color.FromArgb(255, 128, 0);
            btnSubmitRequest.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmitRequest.ForeColor = Color.White;
            btnSubmitRequest.Location = new Point(1201, 750);
            btnSubmitRequest.Name = "btnSubmitRequest";
            btnSubmitRequest.Size = new Size(207, 40);
            btnSubmitRequest.TabIndex = 8;
            btnSubmitRequest.Text = "Submit Request";
            btnSubmitRequest.UseVisualStyleBackColor = false;
            btnSubmitRequest.Click += btnSubmitRequest_Click;
            // 
            // cmbTimeSlot
            // 
            cmbTimeSlot.FormattingEnabled = true;
            cmbTimeSlot.Location = new Point(469, 156);
            cmbTimeSlot.Name = "cmbTimeSlot";
            cmbTimeSlot.Size = new Size(217, 28);
            cmbTimeSlot.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(527, 108);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 11;
            label5.Text = "Time Slot";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnSubmitRequest);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(lblEstimatedCost);
            panel1.Location = new Point(33, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(1800, 830);
            panel1.TabIndex = 18;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(label1);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(cmbTimeSlot);
            panel5.Controls.Add(lblDate);
            panel5.Controls.Add(dtpDatePreferred);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(809, 113);
            panel5.Name = "panel5";
            panel5.Size = new Size(922, 319);
            panel5.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(172, 132);
            label1.Name = "label1";
            label1.Size = new Size(15, 20);
            label1.TabIndex = 3;
            label1.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(93, 31);
            label8.Name = "label8";
            label8.Size = new Size(326, 38);
            label8.TabIndex = 1;
            label8.Text = "Preferred Date And Time";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Wheat;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DarkOrange;
            label9.Location = new Point(42, 31);
            label9.Name = "label9";
            label9.Size = new Size(45, 52);
            label9.TabIndex = 0;
            label9.Text = "3";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(42, 126);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(183, 25);
            lblDate.TabIndex = 13;
            lblDate.Text = "Preferred data & time";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(lblMinimumCharacters);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(lblProblemDescription);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtProblemDescription);
            panel4.Controls.Add(lblDescribe);
            panel4.Location = new Point(11, 438);
            panel4.Name = "panel4";
            panel4.Size = new Size(780, 396);
            panel4.TabIndex = 20;
            // 
            // lblMinimumCharacters
            // 
            lblMinimumCharacters.AutoSize = true;
            lblMinimumCharacters.Location = new Point(546, 360);
            lblMinimumCharacters.Name = "lblMinimumCharacters";
            lblMinimumCharacters.Size = new Size(178, 20);
            lblMinimumCharacters.TabIndex = 5;
            lblMinimumCharacters.Text = "0 chars (20 more needed)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.DarkOrange;
            label3.Location = new Point(271, 132);
            label3.Name = "label3";
            label3.Size = new Size(15, 20);
            label3.TabIndex = 3;
            label3.Text = "*";
            // 
            // lblProblemDescription
            // 
            lblProblemDescription.AutoSize = true;
            lblProblemDescription.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProblemDescription.Location = new Point(93, 31);
            lblProblemDescription.Name = "lblProblemDescription";
            lblProblemDescription.Size = new Size(270, 38);
            lblProblemDescription.TabIndex = 1;
            lblProblemDescription.Text = "Problem Description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Wheat;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkOrange;
            label6.Location = new Point(42, 31);
            label6.Name = "label6";
            label6.Size = new Size(45, 52);
            label6.TabIndex = 0;
            label6.Text = "2";
            // 
            // lblDescribe
            // 
            lblDescribe.AutoSize = true;
            lblDescribe.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescribe.Location = new Point(42, 102);
            lblDescribe.Name = "lblDescribe";
            lblDescribe.Size = new Size(135, 20);
            lblDescribe.TabIndex = 1;
            lblDescribe.Text = "Describe the issue";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(lblServiceCategory);
            panel3.Controls.Add(RdbtnUrgent1);
            panel3.Controls.Add(lblServicenumber1);
            panel3.Controls.Add(RdbxNormalPriorityLevel1);
            panel3.Controls.Add(lblService);
            panel3.Controls.Add(cmbCategory);
            panel3.Controls.Add(lblPriority);
            panel3.Location = new Point(11, 113);
            panel3.Name = "panel3";
            panel3.Size = new Size(780, 319);
            panel3.TabIndex = 19;
            // 
            // lblServiceCategory
            // 
            lblServiceCategory.AutoSize = true;
            lblServiceCategory.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServiceCategory.Location = new Point(93, 31);
            lblServiceCategory.Name = "lblServiceCategory";
            lblServiceCategory.Size = new Size(224, 38);
            lblServiceCategory.TabIndex = 1;
            lblServiceCategory.Text = "Service Category";
            // 
            // RdbtnUrgent1
            // 
            RdbtnUrgent1.AutoSize = true;
            RdbtnUrgent1.ForeColor = Color.Red;
            RdbtnUrgent1.Location = new Point(477, 242);
            RdbtnUrgent1.Name = "RdbtnUrgent1";
            RdbtnUrgent1.Size = new Size(145, 44);
            RdbtnUrgent1.TabIndex = 18;
            RdbtnUrgent1.TabStop = true;
            RdbtnUrgent1.Text = "🔴Urgent\r\nSame day / ASAP\r\n";
            RdbtnUrgent1.UseVisualStyleBackColor = true;
            // 
            // lblServicenumber1
            // 
            lblServicenumber1.AutoSize = true;
            lblServicenumber1.BackColor = Color.Wheat;
            lblServicenumber1.BorderStyle = BorderStyle.Fixed3D;
            lblServicenumber1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServicenumber1.ForeColor = Color.DarkOrange;
            lblServicenumber1.Location = new Point(42, 31);
            lblServicenumber1.Name = "lblServicenumber1";
            lblServicenumber1.Size = new Size(45, 52);
            lblServicenumber1.TabIndex = 0;
            lblServicenumber1.Text = "1";
            // 
            // RdbxNormalPriorityLevel1
            // 
            RdbxNormalPriorityLevel1.AutoSize = true;
            RdbxNormalPriorityLevel1.ForeColor = Color.FromArgb(255, 128, 0);
            RdbxNormalPriorityLevel1.Location = new Point(80, 256);
            RdbxNormalPriorityLevel1.Name = "RdbxNormalPriorityLevel1";
            RdbxNormalPriorityLevel1.Size = new Size(147, 44);
            RdbxNormalPriorityLevel1.TabIndex = 17;
            RdbxNormalPriorityLevel1.TabStop = true;
            RdbxNormalPriorityLevel1.Text = "\U0001f7e2Normal\r\nWithin a few days";
            RdbxNormalPriorityLevel1.UseVisualStyleBackColor = true;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblService.ForeColor = Color.FromArgb(64, 64, 64);
            lblService.Location = new Point(56, 117);
            lblService.Name = "lblService";
            lblService.Size = new Size(226, 20);
            lblService.TabIndex = 4;
            lblService.Text = "What type of service do you need?";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPriority.Location = new Point(71, 221);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(61, 20);
            lblPriority.TabIndex = 9;
            lblPriority.Text = "Priority";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(lblRequest);
            panel2.Controls.Add(btnBack);
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1796, 108);
            panel2.TabIndex = 16;
            // 
            // lblRequest
            // 
            lblRequest.AutoSize = true;
            lblRequest.FlatStyle = FlatStyle.Flat;
            lblRequest.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRequest.ForeColor = Color.FromArgb(255, 128, 0);
            lblRequest.Location = new Point(12, 9);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new Size(199, 23);
            lblRequest.TabIndex = 11;
            lblRequest.Text = "NEW SERVICE REQUEST";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 128, 0);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1557, 39);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(151, 29);
            btnBack.TabIndex = 11;
            btnBack.Text = " ← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(809, 482);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "124 Main Street, Johannesburg Enter street address, e.g 45 Oak Street, Sandton";
            txtAddress.Size = new Size(911, 161);
            txtAddress.TabIndex = 2;
            // 
            // frmCreateRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1845, 902);
            Controls.Add(panel1);
            Name = "frmCreateRequest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Request";
            Load += CreateRequestForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCategory;
        private Label label2;
        private TextBox txtProblemDescription;
        private DateTimePicker dtpDatePreferred;
        private Label lblEstimatedCost;
        private Button btnSubmitRequest;
        private ComboBox cmbTimeSlot;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private Label lblRequest;
        private Button btnBack;
        private Label lblDate;
        private Button btnUrgent;
        private Button btnNormal;
        private Label lblPriority;
        private Label lblDescribe;
        private Label lblService;
        private RadioButton RdbxNormalPriorityLevel1;
        private RadioButton RdbtnUrgent1;
        private Panel panel3;
        private Label lblServiceCategory;
        private Label lblServicenumber1;
        private TextBox txtAddress;
        private Panel panel4;
        private Label lblMinimumCharacters;
        private Label label3;
        private Label lblProblemDescription;
        private Label label6;
        private Panel panel5;
        private Label label1;
        private Label label8;
        private Label label9;
    }
}