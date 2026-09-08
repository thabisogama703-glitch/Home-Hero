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
<<<<<<< HEAD
            label9 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label10 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            label8 = new Label();
            label4 = new Label();
            btnViewRequests = new Button();
            btnProviders = new Button();
            btnServices = new Button();
            btnReports = new Button();
            button1 = new Button();
            panel5 = new Panel();
            label7 = new Label();
            label5 = new Label();
            panel6 = new Panel();
            label12 = new Label();
            label11 = new Label();
            panel7 = new Panel();
            label13 = new Label();
            panel8 = new Panel();
            label14 = new Label();
=======
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
>>>>>>> 0a21678 (Fix issues in Home Hero)
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 177);
            panel1.TabIndex = 0;
            // 
<<<<<<< HEAD
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(109, 15);
            label9.Name = "label9";
            label9.Size = new Size(64, 20);
            label9.TabIndex = 6;
            label9.Text = "All Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 153);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Total Requests";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(445, 125);
            panel2.Name = "panel2";
            panel2.Size = new Size(195, 177);
            panel2.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(95, 15);
            label10.Name = "label10";
            label10.Size = new Size(97, 20);
            label10.TabIndex = 7;
            label10.Text = "Of the 6 total";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 153);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 1;
            label2.Text = "Active Providers";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(224, 125);
            panel3.Name = "panel3";
            panel3.Size = new Size(197, 177);
            panel3.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 15);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 3;
            label6.Text = "Need Action";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 153);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 2;
            label3.Text = "Awaiting Approval";
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(660, 125);
            panel4.Name = "panel4";
            panel4.Size = new Size(185, 177);
            panel4.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(66, 15);
            label8.Name = "label8";
            label8.Size = new Size(116, 20);
            label8.TabIndex = 5;
            label8.Text = "Completed Jobs";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 153);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 2;
            label4.Text = "Total Revenue";
            // 
            // btnViewRequests
            // 
            btnViewRequests.Location = new Point(224, 73);
            btnViewRequests.Name = "btnViewRequests";
            btnViewRequests.Size = new Size(157, 29);
            btnViewRequests.TabIndex = 4;
            btnViewRequests.Text = "Requests";
            btnViewRequests.UseVisualStyleBackColor = true;
            btnViewRequests.Click += btnViewRequests_Click;
            // 
            // btnProviders
            // 
            btnProviders.Location = new Point(445, 73);
            btnProviders.Name = "btnProviders";
            btnProviders.Size = new Size(179, 29);
            btnProviders.TabIndex = 5;
            btnProviders.Text = "Poviders";
            btnProviders.UseVisualStyleBackColor = true;
            btnProviders.Click += btnManageProviders_Click;
            // 
            // btnServices
            // 
            btnServices.Location = new Point(663, 73);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(153, 29);
            btnServices.TabIndex = 6;
            btnServices.Text = "Services";
            btnServices.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(863, 73);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(178, 29);
            btnReports.TabIndex = 7;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 73);
            button1.Name = "button1";
            button1.Size = new Size(131, 29);
            button1.TabIndex = 8;
            button1.Text = "Overview";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(863, 125);
            panel5.Name = "panel5";
            panel5.Size = new Size(166, 177);
            panel5.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(62, 15);
            label7.Name = "label7";
            label7.Size = new Size(101, 20);
            label7.TabIndex = 4;
            label7.Text = "Acess All Jobs";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 153);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 3;
            label5.Text = "Avg Job Rating";
            // 
            // panel6
            // 
            panel6.BackColor = Color.MidnightBlue;
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label11);
            panel6.Location = new Point(-2, -2);
            panel6.Name = "panel6";
            panel6.Size = new Size(1043, 69);
            panel6.TabIndex = 10;
            panel6.Paint += panel6_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Tomato;
            label12.Location = new Point(164, 11);
            label12.Name = "label12";
            label12.Size = new Size(108, 50);
            label12.TabIndex = 1;
            label12.Text = "Hero";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.MidnightBlue;
            label11.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(44, 11);
            label11.Name = "label11";
            label11.Size = new Size(137, 54);
            label11.TabIndex = 0;
            label11.Text = "Home";
            // 
            // panel7
            // 
            panel7.BackColor = Color.WhiteSmoke;
            panel7.Controls.Add(label13);
            panel7.Location = new Point(17, 342);
            panel7.Name = "panel7";
            panel7.Size = new Size(508, 205);
            panel7.TabIndex = 11;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 12);
            label13.Name = "label13";
            label13.Size = new Size(184, 20);
            label13.TabIndex = 0;
            label13.Text = "Request Status Breakdown";
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.Controls.Add(label14);
            panel8.Location = new Point(540, 342);
            panel8.Name = "panel8";
            panel8.Size = new Size(486, 205);
            panel8.TabIndex = 12;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(17, 12);
            label14.Name = "label14";
            label14.Size = new Size(139, 20);
            label14.TabIndex = 1;
            label14.Text = "Recent Submissions";
            // 
=======
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
>>>>>>> 0a21678 (Fix issues in Home Hero)
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1041, 559);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(button1);
            Controls.Add(btnReports);
            Controls.Add(btnServices);
            Controls.Add(btnProviders);
            Controls.Add(btnViewRequests);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminDashboard";
<<<<<<< HEAD
            Text = "HomeHero";
=======
            Text = "AdminDashboard";
>>>>>>> 0a21678 (Fix issues in Home Hero)
            Load += AdminDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button btnViewRequests;
        private Button btnProviders;
        private Button btnServices;
        private Button btnReports;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Panel panel5;
        private Label label5;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label label8;
        private Label label7;
        private Panel panel6;
        private Label label11;
        private Label label12;
        private Panel panel7;
        private Panel panel8;
        private Label label13;
        private Label label14;
    }
}