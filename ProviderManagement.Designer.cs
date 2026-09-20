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
            dgvProviders = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            specialization = new DataGridViewTextBoxColumn();
            btnBack_ = new Button();
            btnAddProvider_ = new Button();
            btnRemoveProvider = new Button();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            txtSearchProvider = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProviders).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvProviders
            // 
            dgvProviders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProviders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProviders.Columns.AddRange(new DataGridViewColumn[] { name, specialization });
            dgvProviders.Location = new Point(28, 174);
            dgvProviders.Name = "dgvProviders";
            dgvProviders.RowHeadersWidth = 51;
            dgvProviders.Size = new Size(1175, 337);
            dgvProviders.TabIndex = 0;
            dgvProviders.CellContentClick += dataGridView1_CellContentClick;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            // 
            // specialization
            // 
            specialization.HeaderText = "Specialization";
            specialization.MinimumWidth = 6;
            specialization.Name = "specialization";
            // 
            // btnBack_
            // 
            btnBack_.Location = new Point(1116, 35);
            btnBack_.Name = "btnBack_";
            btnBack_.Size = new Size(94, 29);
            btnBack_.TabIndex = 1;
            btnBack_.Text = "Back";
            btnBack_.UseVisualStyleBackColor = true;
            // 
            // btnAddProvider_
            // 
            btnAddProvider_.Location = new Point(798, 560);
            btnAddProvider_.Name = "btnAddProvider_";
            btnAddProvider_.Size = new Size(186, 29);
            btnAddProvider_.TabIndex = 2;
            btnAddProvider_.Text = "Add Provider";
            btnAddProvider_.UseVisualStyleBackColor = true;
            btnAddProvider_.Click += btnAddProvider__Click;
            // 
            // btnRemoveProvider
            // 
            btnRemoveProvider.Location = new Point(28, 560);
            btnRemoveProvider.Name = "btnRemoveProvider";
            btnRemoveProvider.Size = new Size(186, 29);
            btnRemoveProvider.TabIndex = 3;
            btnRemoveProvider.Text = "Remove Provider";
            btnRemoveProvider.UseVisualStyleBackColor = true;
            btnRemoveProvider.Click += btnAddProvider_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(198, 15);
            label1.Name = "label1";
            label1.Size = new Size(108, 50);
            label1.TabIndex = 4;
            label1.Text = "Hero";
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnBack_);
            panel1.Location = new Point(-7, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1252, 102);
            panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Screenshot_2026_09_13_1713342;
            pictureBox1.Location = new Point(19, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(76, 15);
            label2.Name = "label2";
            label2.Size = new Size(127, 50);
            label2.TabIndex = 5;
            label2.Text = "Home";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 131);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 6;
            label3.Text = "Search for a provider";
            // 
            // txtSearchProvider
            // 
            txtSearchProvider.Location = new Point(212, 124);
            txtSearchProvider.Name = "txtSearchProvider";
            txtSearchProvider.Size = new Size(425, 27);
            txtSearchProvider.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(730, 122);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // ProviderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 611);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchProvider);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(btnRemoveProvider);
            Controls.Add(btnAddProvider_);
            Controls.Add(dgvProviders);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProviderManagement";
            Text = "ProviderManagement";
            Load += ProviderManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProviders).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProviders;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn specialization;
        private Button btnBack_;
        private Button btnAddProvider_;
        private Button btnRemoveProvider;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox txtSearchProvider;
        private Button btnSearch;
    }
}