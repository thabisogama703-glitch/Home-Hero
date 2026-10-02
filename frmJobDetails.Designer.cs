namespace Home_Hero
{
    partial class frmJobDetails
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
            lblJobDetails = new Label();
            lblCustomer = new Label();
            lblReqNo = new Label();
            lblService = new Label();
            lblAppointment = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtWorkPerformed = new TextBox();
            lblCost = new Label();
            btnRecordWork = new Button();
            btnUpdateStatus = new Button();
            btnBack = new Button();
            nudFinalCost = new NumericUpDown();
            lblProblemValue = new Label();
            lblCustomerValue = new Label();
            lblRequestNumberValue = new Label();
            lblServiceValue = new Label();
            lblAppoint = new Label();
            lblAppointmentValue = new Label();
            cmbJobStatus = new ComboBox();
            pbxHomeHeroLogo = new PictureBox();
            grpJobDetails = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)nudFinalCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).BeginInit();
            grpJobDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblJobDetails
            // 
            lblJobDetails.AutoSize = true;
            lblJobDetails.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJobDetails.ForeColor = Color.FromArgb(255, 128, 0);
            lblJobDetails.Location = new Point(296, 42);
            lblJobDetails.Name = "lblJobDetails";
            lblJobDetails.Size = new Size(146, 31);
            lblJobDetails.TabIndex = 0;
            lblJobDetails.Text = "JOB DETAILS";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblCustomer.Location = new Point(93, 95);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(89, 23);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Customer:";
            // 
            // lblReqNo
            // 
            lblReqNo.AutoSize = true;
            lblReqNo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblReqNo.Location = new Point(85, 148);
            lblReqNo.Name = "lblReqNo";
            lblReqNo.Size = new Size(150, 23);
            lblReqNo.TabIndex = 3;
            lblReqNo.Text = " Request Number:";
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblService.Location = new Point(89, 200);
            lblService.Name = "lblService";
            lblService.Size = new Size(69, 23);
            lblService.TabIndex = 5;
            lblService.Text = "Service:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(85, 234);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(100, 20);
            lblAppointment.TabIndex = 7;
            lblAppointment.Text = "Appointment:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(85, 302);
            label4.Name = "label4";
            label4.Size = new Size(169, 23);
            label4.TabIndex = 9;
            label4.Text = "Problem Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.Location = new Point(89, 370);
            label5.Name = "label5";
            label5.Size = new Size(93, 23);
            label5.TabIndex = 11;
            label5.Text = "Job Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.Location = new Point(89, 447);
            label6.Name = "label6";
            label6.Size = new Size(136, 23);
            label6.TabIndex = 13;
            label6.Text = "Work Performed";
            // 
            // txtWorkPerformed
            // 
            txtWorkPerformed.Location = new Point(85, 470);
            txtWorkPerformed.Multiline = true;
            txtWorkPerformed.Name = "txtWorkPerformed";
            txtWorkPerformed.Size = new Size(608, 94);
            txtWorkPerformed.TabIndex = 15;
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCost.Location = new Point(89, 636);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(85, 23);
            lblCost.TabIndex = 16;
            lblCost.Text = "Final Cost";
            // 
            // btnRecordWork
            // 
            btnRecordWork.BackColor = Color.Navy;
            btnRecordWork.ForeColor = Color.FromArgb(255, 128, 0);
            btnRecordWork.Location = new Point(297, 690);
            btnRecordWork.Name = "btnRecordWork";
            btnRecordWork.Size = new Size(129, 41);
            btnRecordWork.TabIndex = 18;
            btnRecordWork.Text = "Record Work";
            btnRecordWork.UseVisualStyleBackColor = false;
            btnRecordWork.Click += btnRecordWork_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.Navy;
            btnUpdateStatus.ForeColor = Color.FromArgb(255, 128, 0);
            btnUpdateStatus.Location = new Point(89, 690);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(125, 41);
            btnUpdateStatus.TabIndex = 19;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Navy;
            btnBack.ForeColor = Color.FromArgb(255, 128, 0);
            btnBack.Location = new Point(503, 690);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 41);
            btnBack.TabIndex = 20;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // nudFinalCost
            // 
            nudFinalCost.Location = new Point(234, 629);
            nudFinalCost.Name = "nudFinalCost";
            nudFinalCost.Size = new Size(150, 27);
            nudFinalCost.TabIndex = 21;
            // 
            // lblProblemValue
            // 
            lblProblemValue.AutoSize = true;
            lblProblemValue.Location = new Point(323, 302);
            lblProblemValue.Name = "lblProblemValue";
            lblProblemValue.Size = new Size(163, 20);
            lblProblemValue.TabIndex = 22;
            lblProblemValue.Text = "[Kitchen sink is leaking]";
            // 
            // lblCustomerValue
            // 
            lblCustomerValue.AutoSize = true;
            lblCustomerValue.Location = new Point(330, 95);
            lblCustomerValue.Name = "lblCustomerValue";
            lblCustomerValue.Size = new Size(121, 20);
            lblCustomerValue.TabIndex = 23;
            lblCustomerValue.Text = "[customer name]";
            // 
            // lblRequestNumberValue
            // 
            lblRequestNumberValue.AutoSize = true;
            lblRequestNumberValue.Location = new Point(330, 148);
            lblRequestNumberValue.Name = "lblRequestNumberValue";
            lblRequestNumberValue.Size = new Size(77, 20);
            lblRequestNumberValue.TabIndex = 24;
            lblRequestNumberValue.Text = "[REQ-001]";
            lblRequestNumberValue.Click += label1_Click;
            // 
            // lblServiceValue
            // 
            lblServiceValue.AutoSize = true;
            lblServiceValue.Location = new Point(330, 200);
            lblServiceValue.Name = "lblServiceValue";
            lblServiceValue.Size = new Size(82, 20);
            lblServiceValue.TabIndex = 25;
            lblServiceValue.Text = "[Plumbing]";
            lblServiceValue.Click += label1_Click_1;
            // 
            // lblAppoint
            // 
            lblAppoint.AutoSize = true;
            lblAppoint.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAppoint.Location = new Point(87, 248);
            lblAppoint.Name = "lblAppoint";
            lblAppoint.Size = new Size(115, 23);
            lblAppoint.TabIndex = 26;
            lblAppoint.Text = "Appointment:";
            // 
            // lblAppointmentValue
            // 
            lblAppointmentValue.AutoSize = true;
            lblAppointmentValue.Location = new Point(323, 248);
            lblAppointmentValue.Name = "lblAppointmentValue";
            lblAppointmentValue.Size = new Size(89, 20);
            lblAppointmentValue.TabIndex = 27;
            lblAppointmentValue.Text = "[dd/mm/yy]";
            // 
            // cmbJobStatus
            // 
            cmbJobStatus.FormattingEnabled = true;
            cmbJobStatus.Items.AddRange(new object[] { "Not Started", "In Progress", "Completed" });
            cmbJobStatus.Location = new Point(323, 362);
            cmbJobStatus.Name = "cmbJobStatus";
            cmbJobStatus.Size = new Size(151, 28);
            cmbJobStatus.TabIndex = 28;
            // 
            // pbxHomeHeroLogo
            // 
            pbxHomeHeroLogo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            pbxHomeHeroLogo.Location = new Point(233, 26);
            pbxHomeHeroLogo.Name = "pbxHomeHeroLogo";
            pbxHomeHeroLogo.Size = new Size(48, 47);
            pbxHomeHeroLogo.TabIndex = 29;
            pbxHomeHeroLogo.TabStop = false;
            // 
            // grpJobDetails
            // 
            grpJobDetails.BackColor = Color.Navy;
            grpJobDetails.Controls.Add(pbxHomeHeroLogo);
            grpJobDetails.Controls.Add(lblJobDetails);
            grpJobDetails.ForeColor = Color.Navy;
            grpJobDetails.Location = new Point(1, -6);
            grpJobDetails.Name = "grpJobDetails";
            grpJobDetails.Size = new Size(761, 87);
            grpJobDetails.TabIndex = 30;
            grpJobDetails.TabStop = false;
            // 
            // frmJobDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(756, 743);
            Controls.Add(grpJobDetails);
            Controls.Add(cmbJobStatus);
            Controls.Add(lblAppointmentValue);
            Controls.Add(lblAppoint);
            Controls.Add(lblServiceValue);
            Controls.Add(lblRequestNumberValue);
            Controls.Add(lblCustomerValue);
            Controls.Add(lblProblemValue);
            Controls.Add(nudFinalCost);
            Controls.Add(btnBack);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnRecordWork);
            Controls.Add(lblCost);
            Controls.Add(txtWorkPerformed);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblService);
            Controls.Add(lblReqNo);
            Controls.Add(lblCustomer);
            Name = "frmJobDetails";
            Text = "Job Details";
            ((System.ComponentModel.ISupportInitialize)nudFinalCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHomeHeroLogo).EndInit();
            grpJobDetails.ResumeLayout(false);
            grpJobDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJobDetails;
        private Label lblCustomer;
        private Label lblRequestNumberValue;
        private Label lblReqNo;
        private Label label2;
        private Label lblService;
        private Label lblSer;
        private Label lblAppointment;
        private Label label3;
        private Label label4;
        private TextBox txtDescription;
        private Label label5;
        private ComboBox lblJobStatus;
        private Label label6;
        private TextBox txtWorkPerformed;
        private Label lblCost;
        private TextBox txtCost;
        private Button btnRecordWork;
        private Button btnUpdateStatus;
        private Button btnBack;
        private NumericUpDown nudFinalCost;
        private Label lblProblemValue;
        private Label lblCustomerValue;
        private Label lblServiceValue;
        private Label lblAppoint;
        private Label lblAppointmentValue;
        private ComboBox cmbJobStatus;
        private PictureBox pbxHomeHeroLogo;
        private GroupBox grpJobDetails;
    }
}