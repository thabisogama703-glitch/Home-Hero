namespace Home_Hero
{
    partial class RequestManagement
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
            label1 = new Label();
            txtSearchRequests = new TextBox();
            btnBack = new Button();
            btnApproveRequests = new Button();
            btnCancelRequests = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            requestNumber = new DataGridViewTextBoxColumn();
            customerId = new DataGridViewTextBoxColumn();
            serviceCategory = new DataGridViewTextBoxColumn();
            problemDescription = new DataGridViewTextBoxColumn();
            propertyAddress = new DataGridViewTextBoxColumn();
            prefferredTime = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Request";
            // 
            // txtSearchRequests
            // 
            txtSearchRequests.Location = new Point(170, 19);
            txtSearchRequests.Name = "txtSearchRequests";
            txtSearchRequests.Size = new Size(352, 27);
            txtSearchRequests.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(694, 20);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnApproveRequests
            // 
            btnApproveRequests.Location = new Point(286, 409);
            btnApproveRequests.Name = "btnApproveRequests";
            btnApproveRequests.Size = new Size(199, 29);
            btnApproveRequests.TabIndex = 3;
            btnApproveRequests.Text = "Approve Request";
            btnApproveRequests.UseVisualStyleBackColor = true;
            btnApproveRequests.Click += btnApproveRequests_Click;
            // 
            // btnCancelRequests
            // 
            btnCancelRequests.Location = new Point(34, 409);
            btnCancelRequests.Name = "btnCancelRequests";
            btnCancelRequests.Size = new Size(177, 29);
            btnCancelRequests.TabIndex = 4;
            btnCancelRequests.Text = "Cancel Request";
            btnCancelRequests.UseVisualStyleBackColor = true;
            btnCancelRequests.Click += btnCancelRequests_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(545, 411);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(211, 28);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Assign Provider";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { requestNumber, customerId, serviceCategory, problemDescription, propertyAddress, prefferredTime });
            dataGridView1.Location = new Point(24, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(764, 346);
            dataGridView1.TabIndex = 6;
            // 
            // requestNumber
            // 
            requestNumber.HeaderText = "Request Number";
            requestNumber.MinimumWidth = 6;
            requestNumber.Name = "requestNumber";
            // 
            // customerId
            // 
            customerId.HeaderText = "Customer ID";
            customerId.MinimumWidth = 6;
            customerId.Name = "customerId";
            // 
            // serviceCategory
            // 
            serviceCategory.HeaderText = "Service Category";
            serviceCategory.MinimumWidth = 6;
            serviceCategory.Name = "serviceCategory";
            // 
            // problemDescription
            // 
            problemDescription.HeaderText = "Problem Description";
            problemDescription.MinimumWidth = 6;
            problemDescription.Name = "problemDescription";
            // 
            // propertyAddress
            // 
            propertyAddress.HeaderText = "Property Address";
            propertyAddress.MinimumWidth = 6;
            propertyAddress.Name = "propertyAddress";
            // 
            // prefferredTime
            // 
            prefferredTime.HeaderText = "Preferred  Time";
            prefferredTime.MinimumWidth = 6;
            prefferredTime.Name = "prefferredTime";
            // 
            // RequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelRequests);
            Controls.Add(btnApproveRequests);
            Controls.Add(btnBack);
            Controls.Add(txtSearchRequests);
            Controls.Add(label1);
            Name = "RequestManagement";
            Text = "RequestManagement";
            Load += RequestManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearchRequests;
        private Button btnBack;
        private Button btnApproveRequests;
        private Button btnCancelRequests;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn requestNumber;
        private DataGridViewTextBoxColumn customerId;
        private DataGridViewTextBoxColumn serviceCategory;
        private DataGridViewTextBoxColumn problemDescription;
        private DataGridViewTextBoxColumn propertyAddress;
        private DataGridViewTextBoxColumn prefferredTime;
    }
}