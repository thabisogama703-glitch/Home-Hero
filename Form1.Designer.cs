namespace ServiceProviderDashboard
{
    partial class frmServiceProviderDashboard
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
            grpAssignedJobs = new GroupBox();
            dgvAssignedJobs = new DataGridView();
            reqNo = new DataGridViewTextBoxColumn();
            customer = new DataGridViewTextBoxColumn();
            service = new DataGridViewTextBoxColumn();
            appointment = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            grpUpcomingJos = new GroupBox();
            dgvUpcomingJobs = new DataGridView();
            reqNum = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colService = new DataGridViewTextBoxColumn();
            coldate = new DataGridViewTextBoxColumn();
            tim = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            grpCompletedJobs = new GroupBox();
            dgvCompletedJobs = new DataGridView();
            requestNum = new DataGridViewTextBoxColumn();
            cust = new DataGridViewTextBoxColumn();
            serv = new DataGridViewTextBoxColumn();
            coDate = new DataGridViewTextBoxColumn();
            finalCost = new DataGridViewTextBoxColumn();
            coStatus = new DataGridViewTextBoxColumn();
            btnViewJobs = new Button();
            grpAssignedJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignedJobs).BeginInit();
            grpUpcomingJos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingJobs).BeginInit();
            grpCompletedJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompletedJobs).BeginInit();
            SuspendLayout();
            // 
            // grpAssignedJobs
            // 
            grpAssignedJobs.BackColor = Color.White;
            grpAssignedJobs.Controls.Add(dgvAssignedJobs);
            grpAssignedJobs.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpAssignedJobs.ForeColor = Color.FromArgb(255, 128, 0);
            grpAssignedJobs.Location = new Point(0, 0);
            grpAssignedJobs.Name = "grpAssignedJobs";
            grpAssignedJobs.Size = new Size(811, 217);
            grpAssignedJobs.TabIndex = 1;
            grpAssignedJobs.TabStop = false;
            grpAssignedJobs.Text = "Assigned Jobs";
            // 
            // dgvAssignedJobs
            // 
            dgvAssignedJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssignedJobs.Columns.AddRange(new DataGridViewColumn[] { reqNo, customer, service, appointment, date, status });
            dgvAssignedJobs.GridColor = Color.FromArgb(0, 0, 64);
            dgvAssignedJobs.Location = new Point(3, 27);
            dgvAssignedJobs.Name = "dgvAssignedJobs";
            dgvAssignedJobs.RowHeadersWidth = 51;
            dgvAssignedJobs.Size = new Size(804, 188);
            dgvAssignedJobs.TabIndex = 0;
            // 
            // reqNo
            // 
            reqNo.HeaderText = "Request Number";
            reqNo.MinimumWidth = 6;
            reqNo.Name = "reqNo";
            reqNo.Width = 125;
            // 
            // customer
            // 
            customer.HeaderText = "Customer";
            customer.MinimumWidth = 6;
            customer.Name = "customer";
            customer.Width = 125;
            // 
            // service
            // 
            service.HeaderText = "Service";
            service.MinimumWidth = 6;
            service.Name = "service";
            service.Width = 125;
            // 
            // appointment
            // 
            appointment.HeaderText = "Appointment";
            appointment.MinimumWidth = 6;
            appointment.Name = "appointment";
            appointment.Width = 125;
            // 
            // date
            // 
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.Width = 125;
            // 
            // grpUpcomingJos
            // 
            grpUpcomingJos.BackColor = Color.White;
            grpUpcomingJos.Controls.Add(dgvUpcomingJobs);
            grpUpcomingJos.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpUpcomingJos.ForeColor = Color.FromArgb(255, 128, 0);
            grpUpcomingJos.Location = new Point(3, 223);
            grpUpcomingJos.Name = "grpUpcomingJos";
            grpUpcomingJos.Size = new Size(804, 227);
            grpUpcomingJos.TabIndex = 1;
            grpUpcomingJos.TabStop = false;
            grpUpcomingJos.Text = "Upcoming Jobs";
            // 
            // dgvUpcomingJobs
            // 
            dgvUpcomingJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpcomingJobs.Columns.AddRange(new DataGridViewColumn[] { reqNum, colCustomer, colService, coldate, tim, colTime });
            dgvUpcomingJobs.GridColor = Color.FromArgb(0, 0, 64);
            dgvUpcomingJobs.Location = new Point(3, 23);
            dgvUpcomingJobs.Name = "dgvUpcomingJobs";
            dgvUpcomingJobs.RowHeadersWidth = 51;
            dgvUpcomingJobs.Size = new Size(795, 188);
            dgvUpcomingJobs.TabIndex = 0;
            // 
            // reqNum
            // 
            reqNum.HeaderText = "Request Number";
            reqNum.MinimumWidth = 6;
            reqNum.Name = "reqNum";
            reqNum.Width = 125;
            // 
            // colCustomer
            // 
            colCustomer.HeaderText = "Customer";
            colCustomer.MinimumWidth = 6;
            colCustomer.Name = "colCustomer";
            colCustomer.Width = 125;
            // 
            // colService
            // 
            colService.HeaderText = "Service";
            colService.MinimumWidth = 6;
            colService.Name = "colService";
            colService.Width = 125;
            // 
            // coldate
            // 
            coldate.HeaderText = "Date";
            coldate.MinimumWidth = 6;
            coldate.Name = "coldate";
            coldate.Width = 125;
            // 
            // tim
            // 
            tim.HeaderText = "Time";
            tim.MinimumWidth = 6;
            tim.Name = "tim";
            tim.Width = 125;
            // 
            // colTime
            // 
            colTime.HeaderText = "Status";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.Width = 125;
            // 
            // grpCompletedJobs
            // 
            grpCompletedJobs.BackColor = Color.WhiteSmoke;
            grpCompletedJobs.Controls.Add(dgvCompletedJobs);
            grpCompletedJobs.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCompletedJobs.ForeColor = Color.FromArgb(255, 128, 0);
            grpCompletedJobs.Location = new Point(0, 456);
            grpCompletedJobs.Name = "grpCompletedJobs";
            grpCompletedJobs.Size = new Size(811, 213);
            grpCompletedJobs.TabIndex = 1;
            grpCompletedJobs.TabStop = false;
            grpCompletedJobs.Text = "Completed Jobs";
            // 
            // dgvCompletedJobs
            // 
            dgvCompletedJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompletedJobs.Columns.AddRange(new DataGridViewColumn[] { requestNum, cust, serv, coDate, finalCost, coStatus });
            dgvCompletedJobs.GridColor = Color.FromArgb(0, 0, 64);
            dgvCompletedJobs.Location = new Point(12, 26);
            dgvCompletedJobs.Name = "dgvCompletedJobs";
            dgvCompletedJobs.RowHeadersWidth = 51;
            dgvCompletedJobs.Size = new Size(799, 162);
            dgvCompletedJobs.TabIndex = 0;
            // 
            // requestNum
            // 
            requestNum.HeaderText = "Request Number";
            requestNum.MinimumWidth = 6;
            requestNum.Name = "requestNum";
            requestNum.Width = 125;
            // 
            // cust
            // 
            cust.HeaderText = "Customer";
            cust.MinimumWidth = 6;
            cust.Name = "cust";
            cust.Width = 125;
            // 
            // serv
            // 
            serv.HeaderText = "Service";
            serv.MinimumWidth = 6;
            serv.Name = "serv";
            serv.Width = 125;
            // 
            // coDate
            // 
            coDate.HeaderText = "Date";
            coDate.MinimumWidth = 6;
            coDate.Name = "coDate";
            coDate.Width = 125;
            // 
            // finalCost
            // 
            finalCost.HeaderText = "Final Cost";
            finalCost.MinimumWidth = 6;
            finalCost.Name = "finalCost";
            finalCost.Width = 125;
            // 
            // coStatus
            // 
            coStatus.HeaderText = "Status";
            coStatus.MinimumWidth = 6;
            coStatus.Name = "coStatus";
            coStatus.Width = 125;
            // 
            // btnViewJobs
            // 
            btnViewJobs.BackColor = Color.FromArgb(0, 0, 64);
            btnViewJobs.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewJobs.ForeColor = Color.White;
            btnViewJobs.Location = new Point(85, 675);
            btnViewJobs.Name = "btnViewJobs";
            btnViewJobs.Size = new Size(207, 39);
            btnViewJobs.TabIndex = 1;
            btnViewJobs.Text = "View  Job Details";
            btnViewJobs.UseVisualStyleBackColor = false;
            btnViewJobs.Click += btnViewAssignedJobs_Click;
            // 
            // frmServiceProviderDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(817, 716);
            Controls.Add(btnViewJobs);
            Controls.Add(grpCompletedJobs);
            Controls.Add(grpUpcomingJos);
            Controls.Add(grpAssignedJobs);
            Name = "frmServiceProviderDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Service Provider Dashboard";
            grpAssignedJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssignedJobs).EndInit();
            grpUpcomingJos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingJobs).EndInit();
            grpCompletedJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCompletedJobs).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grpAssignedJobs;
        private DataGridView dgvAssignedJobs;
        private DataGridViewTextBoxColumn reqNo;
        private DataGridViewTextBoxColumn customer;
        private DataGridViewTextBoxColumn appointment;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn service;
        private GroupBox grpUpcomingJos;
        private DataGridView dgvUpcomingJobs;
        private DataGridViewTextBoxColumn reqNum;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colService;
        private DataGridViewTextBoxColumn coldate;
        private DataGridViewTextBoxColumn tim;
        private DataGridViewTextBoxColumn colTime;
        private GroupBox grpCompletedJobs;
        private DataGridView dgvCompletedJobs;
        private DataGridViewTextBoxColumn requestNum;
        private DataGridViewTextBoxColumn cust;
        private DataGridViewTextBoxColumn serv;
        private DataGridViewTextBoxColumn coDate;
        private DataGridViewTextBoxColumn finalCost;
        private DataGridViewTextBoxColumn coStatus;
        private Button btnViewJobs;
    }
}
