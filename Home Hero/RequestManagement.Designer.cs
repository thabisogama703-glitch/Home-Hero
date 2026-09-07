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
            dgvRequests = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 115);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Request";
            // 
            // txtSearchRequests
            // 
            txtSearchRequests.Location = new Point(179, 112);
            txtSearchRequests.Name = "txtSearchRequests";
            txtSearchRequests.Size = new Size(220, 27);
            txtSearchRequests.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.MidnightBlue;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = SystemColors.ActiveBorder;
            btnBack.Location = new Point(695, 54);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnApproveRequests
            // 
            btnApproveRequests.Location = new Point(278, 497);
            btnApproveRequests.Name = "btnApproveRequests";
            btnApproveRequests.Size = new Size(199, 29);
            btnApproveRequests.TabIndex = 3;
            btnApproveRequests.Text = "Approve Request";
            btnApproveRequests.UseVisualStyleBackColor = true;
            btnApproveRequests.Click += btnApproveRequests_Click;
            // 
            // btnCancelRequests
            // 
            btnCancelRequests.Location = new Point(24, 497);
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
            comboBox1.Location = new Point(566, 498);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(211, 28);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Assign Provider";
            // 
            // dgvRequests
            // 
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(24, 146);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(764, 345);
            dgvRequests.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBack);
            panel1.Location = new Point(-1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 99);
            panel1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Tomato;
            label3.Location = new Point(190, 33);
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
            label2.Location = new Point(73, 33);
            label2.Name = "label2";
            label2.Size = new Size(127, 50);
            label2.TabIndex = 0;
            label2.Text = "Home";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Status : Submitted", "Status : Assigned", "Status : Schedule", "Status : In Progress", "Status : Completed" });
            comboBox2.Location = new Point(425, 112);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 8;
            comboBox2.Text = "Status: All";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Catagory : Plumbing", "Catagory : Eletrical", "Catagory : HVAC", "Catagory : Landscaping", "Catagory : Roofing", "Catagory : Painting" });
            comboBox3.Location = new Point(637, 111);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 9;
            comboBox3.Text = "Catagory : All";
            // 
            // RequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 538);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(panel1);
            Controls.Add(dgvRequests);
            Controls.Add(comboBox1);
            Controls.Add(btnCancelRequests);
            Controls.Add(btnApproveRequests);
            Controls.Add(txtSearchRequests);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RequestManagement";
            Text = "RequestManagement";
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private DataGridView dgvRequests;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
    }
}