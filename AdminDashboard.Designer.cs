namespace Home_Hero
{
    partial class AdminDashboard
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            btnViewRequests = new Button();
            btnManageProviders = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 292);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 15);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Requests";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(495, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(221, 292);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 15);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Services";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(label3);
            panel3.Location = new Point(263, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(209, 292);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Providers";
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(label4);
            panel4.Location = new Point(741, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(245, 292);
            panel4.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 15);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 2;
            label4.Text = "Appointments";
            // 
            // btnViewRequests
            // 
            btnViewRequests.Location = new Point(13, 321);
            btnViewRequests.Name = "btnViewRequests";
            btnViewRequests.Size = new Size(206, 29);
            btnViewRequests.TabIndex = 4;
            btnViewRequests.Text = "View Requests";
            btnViewRequests.UseVisualStyleBackColor = true;
            btnViewRequests.Click += btnViewRequests_Click;
            // 
            // btnManageProviders
            // 
            btnManageProviders.Location = new Point(263, 321);
            btnManageProviders.Name = "btnManageProviders";
            btnManageProviders.Size = new Size(206, 29);
            btnManageProviders.TabIndex = 5;
            btnManageProviders.Text = "Manage Poviders";
            btnManageProviders.UseVisualStyleBackColor = true;
            btnManageProviders.Click += btnManageProviders_Click;
            // 
            // button3
            // 
            button3.Location = new Point(495, 321);
            button3.Name = "button3";
            button3.Size = new Size(206, 29);
            button3.TabIndex = 6;
            button3.Text = "Manage Services";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(741, 321);
            button4.Name = "button4";
            button4.Size = new Size(206, 29);
            button4.TabIndex = 7;
            button4.Text = "Manage Appointments";
            button4.UseVisualStyleBackColor = true;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(btnManageProviders);
            Controls.Add(btnViewRequests);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button btnViewRequests;
        private Button btnManageProviders;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}