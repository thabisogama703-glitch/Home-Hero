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
            cbxCategory = new ComboBox();
            dgvRequests = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            btnSearch = new Button();
            cbxStatus = new ComboBox();
            btnReassign = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 132);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Request";
            // 
            // txtSearchRequests
            // 
            txtSearchRequests.Location = new Point(177, 129);
            txtSearchRequests.Name = "txtSearchRequests";
            txtSearchRequests.Size = new Size(470, 27);
            txtSearchRequests.TabIndex = 1;
            txtSearchRequests.Text = "Search by ID, Customer ...";
            txtSearchRequests.TextChanged += txtSearchRequests_TextChanged;
            // 
            // btnBack
            // 
            btnBack.ForeColor = SystemColors.ActiveBorder;
            btnBack.Location = new Point(1164, 76);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnApproveRequests
            // 
            btnApproveRequests.Location = new Point(24, 593);
            btnApproveRequests.Name = "btnApproveRequests";
            btnApproveRequests.Size = new Size(199, 29);
            btnApproveRequests.TabIndex = 3;
            btnApproveRequests.Text = "Approve Request";
            btnApproveRequests.UseVisualStyleBackColor = true;
            btnApproveRequests.Click += btnApproveRequests_Click;
            // 
            // btnCancelRequests
            // 
            btnCancelRequests.Location = new Point(451, 593);
            btnCancelRequests.Name = "btnCancelRequests";
            btnCancelRequests.Size = new Size(177, 29);
            btnCancelRequests.TabIndex = 4;
            btnCancelRequests.Text = "Cancel Request";
            btnCancelRequests.UseVisualStyleBackColor = true;
            btnCancelRequests.Click += btnCancelRequests_Click;
            // 
            // cbxCategory
            // 
            cbxCategory.FormattingEnabled = true;
            cbxCategory.Items.AddRange(new object[] { "Category : All", "Category : Plumbing", "Category : Electrical", "Category : HVAC", "Category : Landscaping", "Category : Roofing", "Category : Painting" });
            cbxCategory.Location = new Point(1059, 130);
            cbxCategory.Name = "cbxCategory";
            cbxCategory.Size = new Size(211, 28);
            cbxCategory.TabIndex = 5;
            cbxCategory.SelectedIndexChanged += cbxCategory_SelectedIndexChanged;
            // 
            // dgvRequests
            // 
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(24, 173);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(1248, 399);
            dgvRequests.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBack);
            panel1.Location = new Point(-11, -42);
            panel1.Name = "panel1";
            panel1.Size = new Size(1303, 150);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_2026_09_13_1713341;
            pictureBox1.Location = new Point(35, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 36);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Tomato;
            label3.Location = new Point(197, 55);
            label3.Name = "label3";
            label3.Size = new Size(108, 50);
            label3.TabIndex = 1;
            label3.Text = "Hero";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(85, 56);
            label2.Name = "label2";
            label2.Size = new Size(127, 50);
            label2.TabIndex = 0;
            label2.Text = "Home";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(665, 129);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(131, 29);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbxStatus
            // 
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Items.AddRange(new object[] { "Status : All", "Status : Submitted", "Status : Assigned", "Status : Scheduled", "Status : In Progress", "Status : Completed" });
            cbxStatus.Location = new Point(826, 130);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(199, 28);
            cbxStatus.TabIndex = 9;
            cbxStatus.SelectedIndexChanged += cbxStatus_SelectedIndexChanged;
            // 
            // btnReassign
            // 
            btnReassign.Location = new Point(1079, 593);
            btnReassign.Name = "btnReassign";
            btnReassign.Size = new Size(191, 29);
            btnReassign.TabIndex = 10;
            btnReassign.Text = "Reassign";
            btnReassign.UseVisualStyleBackColor = true;
            btnReassign.Click += btnReassign_Click;
            // 
            // RequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 634);
            Controls.Add(btnReassign);
            Controls.Add(cbxStatus);
            Controls.Add(btnSearch);
            Controls.Add(panel1);
            Controls.Add(dgvRequests);
            Controls.Add(cbxCategory);
            Controls.Add(btnCancelRequests);
            Controls.Add(btnApproveRequests);
            Controls.Add(txtSearchRequests);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RequestManagement";
            Text = "RequestManagement";
            Load += RequestManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearchRequests;
        private Button btnBack;
        private Button btnApproveRequests;
        private Button btnCancelRequests;
        private ComboBox cbxCategory;
        private DataGridView dgvRequests;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Button btnSearch;
        private ComboBox cbxStatus;
        private Button btnReassign;
    }
}