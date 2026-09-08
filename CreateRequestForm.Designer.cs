namespace Home_Hero
{
    partial class CreateRequestForm
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
            label1 = new Label();
            txtAddress = new TextBox();
            label2 = new Label();
            txtProblemDescription = new TextBox();
            label3 = new Label();
            dtpDatePreferred = new DateTimePicker();
            lblEstimatedCost = new Label();
            btnSubmitRequest = new Button();
            label4 = new Label();
            cmbTimeSlot = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(201, 50);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(163, 28);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 53);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 1;
            label1.Text = "Service Category";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(575, 44);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(273, 69);
            txtAddress.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(415, 53);
            label2.Name = "label2";
            label2.Size = new Size(150, 25);
            label2.TabIndex = 3;
            label2.Text = "Property Address";
            // 
            // txtProblemDescription
            // 
            txtProblemDescription.Location = new Point(32, 138);
            txtProblemDescription.Multiline = true;
            txtProblemDescription.Name = "txtProblemDescription";
            txtProblemDescription.Size = new Size(354, 182);
            txtProblemDescription.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 103);
            label3.Name = "label3";
            label3.Size = new Size(174, 25);
            label3.TabIndex = 5;
            label3.Text = "Problem Description";
            // 
            // dtpDatePreferred
            // 
            dtpDatePreferred.Format = DateTimePickerFormat.Short;
            dtpDatePreferred.Location = new Point(575, 138);
            dtpDatePreferred.MinDate = new DateTime(2026, 9, 2, 0, 0, 0, 0);
            dtpDatePreferred.Name = "dtpDatePreferred";
            dtpDatePreferred.Size = new Size(210, 27);
            dtpDatePreferred.TabIndex = 6;
            // 
            // lblEstimatedCost
            // 
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstimatedCost.Location = new Point(415, 295);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(185, 25);
            lblEstimatedCost.TabIndex = 7;
            lblEstimatedCost.Text = "Estimated Cost: R0.00";
            // 
            // btnSubmitRequest
            // 
            btnSubmitRequest.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmitRequest.Location = new Point(403, 404);
            btnSubmitRequest.Name = "btnSubmitRequest";
            btnSubmitRequest.Size = new Size(207, 40);
            btnSubmitRequest.TabIndex = 8;
            btnSubmitRequest.Text = "Submit Request";
            btnSubmitRequest.UseVisualStyleBackColor = true;
            btnSubmitRequest.Click += btnSubmitRequest_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(415, 143);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 9;
            label4.Text = "Preferred Date";
            // 
            // cmbTimeSlot
            // 
            cmbTimeSlot.FormattingEnabled = true;
            cmbTimeSlot.Location = new Point(575, 214);
            cmbTimeSlot.Name = "cmbTimeSlot";
            cmbTimeSlot.Size = new Size(151, 28);
            cmbTimeSlot.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(415, 222);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 11;
            label5.Text = "Time Slot";
            // 
            // CreateRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 511);
            Controls.Add(label5);
            Controls.Add(cmbTimeSlot);
            Controls.Add(label4);
            Controls.Add(btnSubmitRequest);
            Controls.Add(lblEstimatedCost);
            Controls.Add(dtpDatePreferred);
            Controls.Add(label3);
            Controls.Add(txtProblemDescription);
            Controls.Add(label2);
            Controls.Add(txtAddress);
            Controls.Add(label1);
            Controls.Add(cmbCategory);
            Name = "CreateRequestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateRequestForm";
            Load += CreateRequestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategory;
        private Label label1;
        private TextBox txtAddress;
        private Label label2;
        private TextBox txtProblemDescription;
        private Label label3;
        private DateTimePicker dtpDatePreferred;
        private Label lblEstimatedCost;
        private Button btnSubmitRequest;
        private Label label4;
        private ComboBox cmbTimeSlot;
        private Label label5;
    }
}