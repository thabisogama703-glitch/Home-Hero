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
            name = new DataGridViewTextBoxColumn();
            specialization = new DataGridViewTextBoxColumn();
            btnBack_ = new Button();
            btnAddProvider_ = new Button();
            btnAddProvider = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { name, specialization });
            dataGridView1.Location = new Point(28, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 337);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            btnBack_.Location = new Point(694, 12);
            btnBack_.Name = "btnBack_";
            btnBack_.Size = new Size(94, 29);
            btnBack_.TabIndex = 1;
            btnBack_.Text = "Back";
            btnBack_.UseVisualStyleBackColor = true;
            // 
            // btnAddProvider_
            // 
            btnAddProvider_.Location = new Point(602, 399);
            btnAddProvider_.Name = "btnAddProvider_";
            btnAddProvider_.Size = new Size(186, 29);
            btnAddProvider_.TabIndex = 2;
            btnAddProvider_.Text = "Add Provider";
            btnAddProvider_.UseVisualStyleBackColor = true;
            // 
            // btnAddProvider
            // 
            btnAddProvider.Location = new Point(28, 399);
            btnAddProvider.Name = "btnAddProvider";
            btnAddProvider.Size = new Size(186, 29);
            btnAddProvider.TabIndex = 3;
            btnAddProvider.Text = "Remove Provider";
            btnAddProvider.UseVisualStyleBackColor = true;
            // 
            // ProviderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddProvider);
            Controls.Add(btnAddProvider_);
            Controls.Add(btnBack_);
            Controls.Add(dataGridView1);
            Name = "ProviderManagement";
            Text = "ProviderManagement";
            Load += ProviderManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn specialization;
        private Button btnBack_;
        private Button btnAddProvider_;
        private Button btnAddProvider;
    }
}