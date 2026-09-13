namespace Home_Hero
{
    partial class ProviderManagement
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
            dataGridView1 = new DataGridView();
            btnBack_ = new Button();
            btnAddProvider_ = new Button();
            btnAddProvider = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 136);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 257);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnBack_
            // 
            btnBack_.FlatStyle = FlatStyle.Flat;
            btnBack_.ForeColor = SystemColors.ActiveBorder;
            btnBack_.Location = new Point(918, 31);
            btnBack_.Name = "btnBack_";
            btnBack_.Size = new Size(94, 29);
            btnBack_.TabIndex = 1;
            btnBack_.Text = "Back";
            btnBack_.UseVisualStyleBackColor = true;
            // 
            // btnAddProvider_
            // 
            btnAddProvider_.Location = new Point(597, 399);
            btnAddProvider_.Name = "btnAddProvider_";
            btnAddProvider_.Size = new Size(186, 29);
            btnAddProvider_.TabIndex = 2;
            btnAddProvider_.Text = "Add Provider";
            btnAddProvider_.UseVisualStyleBackColor = true;
            // 
            // btnAddProvider
            // 
            btnAddProvider.Location = new Point(12, 409);
            btnAddProvider.Name = "btnAddProvider";
            btnAddProvider.Size = new Size(186, 29);
            btnAddProvider.TabIndex = 3;
            btnAddProvider.Text = "Remove Provider";
            btnAddProvider.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBack_);
            panel1.Location = new Point(-9, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1027, 100);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(79, 19);
            label1.Name = "label1";
            label1.Size = new Size(127, 50);
            label1.TabIndex = 5;
            label1.Text = "Home";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(195, 19);
            label2.Name = "label2";
            label2.Size = new Size(108, 50);
            label2.TabIndex = 6;
            label2.Text = "Hero";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Screenshot_2026_09_13_1713342;
            pictureBox1.Location = new Point(21, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 41);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // ProviderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 450);
            Controls.Add(panel1);
            Controls.Add(btnAddProvider);
            Controls.Add(btnAddProvider_);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProviderManagement";
            Text = "ProviderManagement";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnBack_;
        private Button btnAddProvider_;
        private Button btnAddProvider;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}