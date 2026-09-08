namespace Home_Hero
{
    partial class RequestTrackingForm
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
            dgvRequests = new DataGridView();
            lblRequestNum = new Label();
            lblCategory = new Label();
            lblStatus = new Label();
            lblAssignedProvider = new Label();
            lblAppointment = new Label();
            lblEstimatedCost = new Label();
            lblFinalCost = new Label();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(61, 196);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(1135, 188);
            dgvRequests.TabIndex = 0;
            // 
            // lblRequestNum
            // 
            lblRequestNum.AutoSize = true;
            lblRequestNum.Location = new Point(61, 45);
            lblRequestNum.Name = "lblRequestNum";
            lblRequestNum.Size = new Size(123, 20);
            lblRequestNum.TabIndex = 1;
            lblRequestNum.Text = "Request Number:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(306, 45);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(94, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Service Type:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(522, 45);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(116, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Assigned Status:";
            // 
            // lblAssignedProvider
            // 
            lblAssignedProvider.AutoSize = true;
            lblAssignedProvider.Location = new Point(61, 106);
            lblAssignedProvider.Name = "lblAssignedProvider";
            lblAssignedProvider.Size = new Size(131, 20);
            lblAssignedProvider.TabIndex = 4;
            lblAssignedProvider.Text = "Assigned Provider:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(306, 106);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(85, 20);
            lblAppointment.TabIndex = 5;
            lblAppointment.Text = "Date & Time:";
            // 
            // lblEstimatedCost
            // 
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Location = new Point(522, 106);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(111, 20);
            lblEstimatedCost.TabIndex = 6;
            lblEstimatedCost.Text = "Estimated Cost:";
            // 
            // lblFinalCost
            // 
            lblFinalCost.AutoSize = true;
            lblFinalCost.Location = new Point(61, 169);
            lblFinalCost.Name = "lblFinalCost";
            lblFinalCost.Size = new Size(76, 20);
            lblFinalCost.TabIndex = 7;
            lblFinalCost.Text = "Final Cost:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(61, 390);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(111, 29);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // RequestTrackingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 450);
            Controls.Add(btnRefresh);
            Controls.Add(lblFinalCost);
            Controls.Add(lblEstimatedCost);
            Controls.Add(lblAppointment);
            Controls.Add(lblAssignedProvider);
            Controls.Add(lblStatus);
            Controls.Add(lblCategory);
            Controls.Add(lblRequestNum);
            Controls.Add(dgvRequests);
            Name = "RequestTrackingForm";
            Text = "RequestTrackingForm";
            Load += RequestTrackingForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRequests;
        private Label lblRequestNum;
        private Label lblCategory;
        private Label lblStatus;
        private Label lblAssignedProvider;
        private Label lblAppointment;
        private Label lblEstimatedCost;
        private Label lblFinalCost;
        private Button btnRefresh;
    }
}