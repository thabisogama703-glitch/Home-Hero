namespace ServiceProviderDashboard
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
            lblCustomer = new Label();
            lblCustomerName = new Label();
            lblServiceTitle = new Label();
            lblService = new Label();
            lblReqNo = new Label();
            lblRequestNumber = new Label();
            lblAppointmentTitle = new Label();
            lblAppointment = new Label();
            lblProblemTitle = new Label();
            lblProblem = new Label();
            lblJobStatus = new Label();
            lblWorkPerformed = new Label();
            cmbStatus = new ComboBox();
            rtbWorkPerformed = new RichTextBox();
            lblFinalCost = new Label();
            txtFinalCost = new TextBox();
            btnUpdateStatus = new Button();
            btnRecordWork = new Button();
            btnBack = new Button();
            lblDetails = new Label();
            lblJob = new Label();
            grpJobInfo = new GroupBox();
            groupBox1 = new GroupBox();
            grpWorkPerfomed = new GroupBox();
            groupBox2 = new GroupBox();
            grpJobInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            grpWorkPerfomed.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(8, 70);
            lblCustomer.Margin = new Padding(4, 0, 4, 0);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(79, 20);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(144, 70);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(129, 20);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "[Customer Name]";
            // 
            // lblServiceTitle
            // 
            lblServiceTitle.AutoSize = true;
            lblServiceTitle.Location = new Point(8, 130);
            lblServiceTitle.Margin = new Padding(4, 0, 4, 0);
            lblServiceTitle.Name = "lblServiceTitle";
            lblServiceTitle.Size = new Size(63, 20);
            lblServiceTitle.TabIndex = 2;
            lblServiceTitle.Text = "Service:";
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(144, 130);
            lblService.Margin = new Padding(4, 0, 4, 0);
            lblService.Name = "lblService";
            lblService.Size = new Size(114, 20);
            lblService.TabIndex = 3;
            lblService.Text = "[Service Name]";
            // 
            // lblReqNo
            // 
            lblReqNo.AutoSize = true;
            lblReqNo.Location = new Point(8, 196);
            lblReqNo.Margin = new Padding(4, 0, 4, 0);
            lblReqNo.Name = "lblReqNo";
            lblReqNo.Size = new Size(129, 20);
            lblReqNo.TabIndex = 4;
            lblReqNo.Text = "Request Number:";
            // 
            // lblRequestNumber
            // 
            lblRequestNumber.AutoSize = true;
            lblRequestNumber.Location = new Point(171, 196);
            lblRequestNumber.Margin = new Padding(4, 0, 4, 0);
            lblRequestNumber.Name = "lblRequestNumber";
            lblRequestNumber.Size = new Size(134, 20);
            lblRequestNumber.TabIndex = 5;
            lblRequestNumber.Text = "[Request Number]";
            // 
            // lblAppointmentTitle
            // 
            lblAppointmentTitle.AutoSize = true;
            lblAppointmentTitle.Location = new Point(8, 265);
            lblAppointmentTitle.Margin = new Padding(4, 0, 4, 0);
            lblAppointmentTitle.Name = "lblAppointmentTitle";
            lblAppointmentTitle.Size = new Size(103, 20);
            lblAppointmentTitle.TabIndex = 6;
            lblAppointmentTitle.Text = "Appointment:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(160, 265);
            lblAppointment.Margin = new Padding(4, 0, 4, 0);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(145, 20);
            lblAppointment.TabIndex = 7;
            lblAppointment.Text = "[Appointment Date]";
            // 
            // lblProblemTitle
            // 
            lblProblemTitle.AutoSize = true;
            lblProblemTitle.Location = new Point(8, 342);
            lblProblemTitle.Margin = new Padding(4, 0, 4, 0);
            lblProblemTitle.Name = "lblProblemTitle";
            lblProblemTitle.Size = new Size(71, 20);
            lblProblemTitle.TabIndex = 8;
            lblProblemTitle.Text = "Problem:";
            // 
            // lblProblem
            // 
            lblProblem.AutoSize = true;
            lblProblem.Location = new Point(146, 342);
            lblProblem.Margin = new Padding(4, 0, 4, 0);
            lblProblem.Name = "lblProblem";
            lblProblem.Size = new Size(159, 20);
            lblProblem.TabIndex = 9;
            lblProblem.Text = "[Problem Description]";
            // 
            // lblJobStatus
            // 
            lblJobStatus.AutoSize = true;
            lblJobStatus.Location = new Point(102, 60);
            lblJobStatus.Margin = new Padding(4, 0, 4, 0);
            lblJobStatus.Name = "lblJobStatus";
            lblJobStatus.Size = new Size(110, 28);
            lblJobStatus.TabIndex = 10;
            lblJobStatus.Text = "Job Status";
            // 
            // lblWorkPerformed
            // 
            lblWorkPerformed.AutoSize = true;
            lblWorkPerformed.Location = new Point(18, 50);
            lblWorkPerformed.Margin = new Padding(4, 0, 4, 0);
            lblWorkPerformed.Name = "lblWorkPerformed";
            lblWorkPerformed.Size = new Size(296, 31);
            lblWorkPerformed.TabIndex = 12;
            lblWorkPerformed.Text = "Enter The Work Performed:";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Not Started", "In Progress", "Completed ", "Paused" });
            cmbStatus.Location = new Point(102, 104);
            cmbStatus.Margin = new Padding(4, 4, 4, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(533, 36);
            cmbStatus.TabIndex = 13;
            // 
            // rtbWorkPerformed
            // 
            rtbWorkPerformed.Location = new Point(8, 85);
            rtbWorkPerformed.Margin = new Padding(4, 4, 4, 4);
            rtbWorkPerformed.Name = "rtbWorkPerformed";
            rtbWorkPerformed.Size = new Size(748, 134);
            rtbWorkPerformed.TabIndex = 14;
            rtbWorkPerformed.Text = "";
            // 
            // lblFinalCost
            // 
            lblFinalCost.AutoSize = true;
            lblFinalCost.Location = new Point(18, 42);
            lblFinalCost.Margin = new Padding(4, 0, 4, 0);
            lblFinalCost.Name = "lblFinalCost";
            lblFinalCost.Size = new Size(105, 28);
            lblFinalCost.TabIndex = 15;
            lblFinalCost.Text = "Final Cost:";
            // 
            // txtFinalCost
            // 
            txtFinalCost.Location = new Point(147, 43);
            txtFinalCost.Margin = new Padding(4, 4, 4, 4);
            txtFinalCost.Name = "txtFinalCost";
            txtFinalCost.Size = new Size(264, 34);
            txtFinalCost.TabIndex = 16;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.FromArgb(255, 128, 0);
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.Location = new Point(102, 168);
            btnUpdateStatus.Margin = new Padding(4, 4, 4, 4);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(535, 50);
            btnUpdateStatus.TabIndex = 17;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnRecordWork
            // 
            btnRecordWork.BackColor = Color.FromArgb(255, 128, 0);
            btnRecordWork.ForeColor = Color.White;
            btnRecordWork.Location = new Point(147, 85);
            btnRecordWork.Margin = new Padding(4, 4, 4, 4);
            btnRecordWork.Name = "btnRecordWork";
            btnRecordWork.Size = new Size(264, 41);
            btnRecordWork.TabIndex = 18;
            btnRecordWork.Text = "Record Work";
            btnRecordWork.UseVisualStyleBackColor = false;
            btnRecordWork.Click += btnRecordWork_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(86, 543);
            btnBack.Margin = new Padding(4, 4, 4, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(172, 41);
            btnBack.TabIndex = 19;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblDetails
            // 
            lblDetails.AutoSize = true;
            lblDetails.Font = new Font("Tahoma", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetails.ForeColor = Color.FromArgb(255, 128, 0);
            lblDetails.Location = new Point(120, 62);
            lblDetails.Margin = new Padding(4, 0, 4, 0);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(159, 45);
            lblDetails.TabIndex = 21;
            lblDetails.Text = " Details";
            // 
            // lblJob
            // 
            lblJob.AutoSize = true;
            lblJob.Font = new Font("Tahoma", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJob.ForeColor = Color.FromArgb(0, 0, 64);
            lblJob.Location = new Point(27, 38);
            lblJob.Margin = new Padding(4, 0, 4, 0);
            lblJob.Name = "lblJob";
            lblJob.Size = new Size(108, 57);
            lblJob.TabIndex = 22;
            lblJob.Text = "Job";
            // 
            // grpJobInfo
            // 
            grpJobInfo.Controls.Add(lblCustomer);
            grpJobInfo.Controls.Add(lblCustomerName);
            grpJobInfo.Controls.Add(lblServiceTitle);
            grpJobInfo.Controls.Add(lblService);
            grpJobInfo.Controls.Add(lblReqNo);
            grpJobInfo.Controls.Add(lblRequestNumber);
            grpJobInfo.Controls.Add(btnBack);
            grpJobInfo.Controls.Add(lblAppointmentTitle);
            grpJobInfo.Controls.Add(lblAppointment);
            grpJobInfo.Controls.Add(lblProblemTitle);
            grpJobInfo.Controls.Add(lblProblem);
            grpJobInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpJobInfo.Location = new Point(48, 111);
            grpJobInfo.Margin = new Padding(4, 4, 4, 4);
            grpJobInfo.Name = "grpJobInfo";
            grpJobInfo.Padding = new Padding(4, 4, 4, 4);
            grpJobInfo.Size = new Size(468, 608);
            grpJobInfo.TabIndex = 23;
            grpJobInfo.TabStop = false;
            grpJobInfo.Text = "Job Information";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblJobStatus);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(btnUpdateStatus);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(0, 0, 64);
            groupBox1.Location = new Point(524, 111);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(781, 227);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Update Job Status";
            // 
            // grpWorkPerfomed
            // 
            grpWorkPerfomed.Controls.Add(lblWorkPerformed);
            grpWorkPerfomed.Controls.Add(rtbWorkPerformed);
            grpWorkPerfomed.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpWorkPerfomed.ForeColor = Color.FromArgb(0, 0, 64);
            grpWorkPerfomed.Location = new Point(524, 346);
            grpWorkPerfomed.Margin = new Padding(4, 4, 4, 4);
            grpWorkPerfomed.Name = "grpWorkPerfomed";
            grpWorkPerfomed.Padding = new Padding(4, 4, 4, 4);
            grpWorkPerfomed.Size = new Size(781, 233);
            grpWorkPerfomed.TabIndex = 25;
            grpWorkPerfomed.TabStop = false;
            grpWorkPerfomed.Text = "Work Performed";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblFinalCost);
            groupBox2.Controls.Add(txtFinalCost);
            groupBox2.Controls.Add(btnRecordWork);
            groupBox2.ForeColor = Color.FromArgb(0, 0, 64);
            groupBox2.Location = new Point(524, 586);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(781, 133);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Final Cost";
            // 
            // frmJobDetails
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 736);
            Controls.Add(groupBox2);
            Controls.Add(grpWorkPerfomed);
            Controls.Add(groupBox1);
            Controls.Add(grpJobInfo);
            Controls.Add(lblJob);
            Controls.Add(lblDetails);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 0, 64);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmJobDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Job Details";
            grpJobInfo.ResumeLayout(false);
            grpJobInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpWorkPerfomed.ResumeLayout(false);
            grpWorkPerfomed.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private Label lblCustomerName;
        private Label lblServiceTitle;
        private Label lblService;
        private Label lblReqNo;
        private Label lblRequestNumber;
        private Label lblAppointmentTitle;
        private Label lblAppointment;
        private Label lblProblemTitle;
        private Label lblProblem;
        private Label lblJobStatus;
        private Label lblWorkPerformed;
        private ComboBox cmbStatus;
        private RichTextBox rtbWorkPerformed;
        private Label lblFinalCost;
        private TextBox txtFinalCost;
        private Button btnUpdateStatus;
        private Button btnRecordWork;
        private Button btnBack;
        private Label lblDetails;
        private Label lblJob;
        private GroupBox grpJobInfo;
        private GroupBox groupBox1;
        private GroupBox grpWorkPerfomed;
        private GroupBox groupBox2;
    }
}