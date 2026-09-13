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
            dgvRequests = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 119);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Request";
            // 
            // txtSearchRequests
            // 
            txtSearchRequests.Location = new Point(167, 116);
            txtSearchRequests.Name = "txtSearchRequests";
            txtSearchRequests.Size = new Size(387, 27);
            txtSearchRequests.TabIndex = 1;
            txtSearchRequests.Text = "Search by ID, Customer or title";
            // 
            // btnBack
            // 
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = SystemColors.ActiveBorder;
            btnBack.Location = new Point(1051, 34);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnApproveRequests
            // 
            btnApproveRequests.Location = new Point(374, 496);
            btnApproveRequests.Name = "btnApproveRequests";
            btnApproveRequests.Size = new Size(199, 29);
            btnApproveRequests.TabIndex = 3;
            btnApproveRequests.Text = "Approve Request";
            btnApproveRequests.UseVisualStyleBackColor = true;
            btnApproveRequests.Click += btnApproveRequests_Click;
            // 
            // btnCancelRequests
            // 
            btnCancelRequests.Location = new Point(22, 497);
            btnCancelRequests.Name = "btnCancelRequests";
            btnCancelRequests.Size = new Size(177, 29);
            btnCancelRequests.TabIndex = 4;
            btnCancelRequests.Text = "Cancel Request";
            btnCancelRequests.UseVisualStyleBackColor = true;
            btnCancelRequests.Click += btnCancelRequests_Click;
            // 
            // dgvRequests
            // 
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(22, 157);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(1109, 334);
            dgvRequests.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBack);
            panel1.Location = new Point(-7, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 106);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Screenshot_2026_09_13_1713341;
            pictureBox1.Location = new Point(50, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 42);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(106, 25);
            label3.Name = "label3";
            label3.Size = new Size(127, 50);
            label3.TabIndex = 4;
            label3.Text = "Home";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(219, 25);
            label2.Name = "label2";
            label2.Size = new Size(108, 50);
            label2.TabIndex = 3;
            label2.Text = "Hero";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Status : Submitted", "Status : Assigned", "Status : Scheduled", "Status : In Progrss", "Status : Completed" });
            comboBox2.Location = new Point(639, 119);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(198, 28);
            comboBox2.TabIndex = 8;
            comboBox2.Text = "Status : All";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Category : Plumbing ", "Category : Electrical", "Category : HVAC", "Category : Landscaping", "Category : Roofing", "Category : Painting" });
            comboBox3.Location = new Point(912, 119);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(219, 28);
            comboBox3.TabIndex = 9;
            comboBox3.Text = "Category : All";
            // 
            // RequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 537);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(panel1);
            Controls.Add(dgvRequests);
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
        private DataGridView dgvRequests;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
    }
}