namespace Home_Hero
{
    partial class frmRequestAService
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
            btnBackHome = new Button();
            pnlServiceRequest = new Panel();
            lblMaintenanceRequest = new Label();
            lblHero = new Label();
            lblHome = new Label();
            pbxLogo = new PictureBox();
            btnCustomerDashboard = new Button();
            pnlServiceRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            SuspendLayout();
            // 
            // btnBackHome
            // 
            btnBackHome.AutoSize = true;
            btnBackHome.BackColor = Color.Navy;
            btnBackHome.FlatAppearance.BorderColor = Color.DarkGray;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(1675, 28);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(199, 43);
            btnBackHome.TabIndex = 0;
            btnBackHome.Text = "<- back to Home";
            btnBackHome.UseVisualStyleBackColor = false;
            btnBackHome.Click += btnBackHome_Click;
            // 
            // pnlServiceRequest
            // 
            pnlServiceRequest.BackColor = Color.FromArgb(0, 0, 64);
            pnlServiceRequest.Controls.Add(lblMaintenanceRequest);
            pnlServiceRequest.Controls.Add(btnBackHome);
            pnlServiceRequest.Controls.Add(lblHero);
            pnlServiceRequest.Controls.Add(lblHome);
            pnlServiceRequest.Controls.Add(pbxLogo);
            pnlServiceRequest.Dock = DockStyle.Top;
            pnlServiceRequest.Location = new Point(0, 0);
            pnlServiceRequest.Margin = new Padding(4, 5, 4, 5);
            pnlServiceRequest.Name = "pnlServiceRequest";
            pnlServiceRequest.Padding = new Padding(98, 0, 98, 0);
            pnlServiceRequest.Size = new Size(1886, 160);
            pnlServiceRequest.TabIndex = 1;
            pnlServiceRequest.Paint += pnlServiceRequest_Paint;
            // 
            // lblMaintenanceRequest
            // 
            lblMaintenanceRequest.AutoSize = true;
            lblMaintenanceRequest.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceRequest.ForeColor = Color.White;
            lblMaintenanceRequest.Location = new Point(932, 23);
            lblMaintenanceRequest.Name = "lblMaintenanceRequest";
            lblMaintenanceRequest.Size = new Size(284, 38);
            lblMaintenanceRequest.TabIndex = 2;
            lblMaintenanceRequest.Text = "Maintenance Request";
            // 
            // lblHero
            // 
            lblHero.AutoSize = true;
            lblHero.BackColor = Color.Transparent;
            lblHero.FlatStyle = FlatStyle.Flat;
            lblHero.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHero.ForeColor = Color.FromArgb(255, 128, 0);
            lblHero.Location = new Point(307, 30);
            lblHero.Name = "lblHero";
            lblHero.Size = new Size(87, 41);
            lblHero.TabIndex = 10;
            lblHero.Text = "Hero";
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.BackColor = Color.Transparent;
            lblHome.FlatStyle = FlatStyle.Flat;
            lblHome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.White;
            lblHome.Location = new Point(215, 30);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(102, 41);
            lblHome.TabIndex = 10;
            lblHome.Text = "Home";
            // 
            // pbxLogo
            // 
            pbxLogo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            pbxLogo.Location = new Point(161, 24);
            pbxLogo.Name = "pbxLogo";
            pbxLogo.Size = new Size(48, 47);
            pbxLogo.TabIndex = 10;
            pbxLogo.TabStop = false;
            // 
            // btnCustomerDashboard
            // 
            btnCustomerDashboard.AutoSize = true;
            btnCustomerDashboard.Location = new Point(45, 223);
            btnCustomerDashboard.Name = "btnCustomerDashboard";
            btnCustomerDashboard.Size = new Size(159, 30);
            btnCustomerDashboard.TabIndex = 2;
            btnCustomerDashboard.Text = "Customer Dashboard";
            btnCustomerDashboard.UseVisualStyleBackColor = true;
            btnCustomerDashboard.Click += btnCustomerDashboard_Click;
            // 
            // frmRequestAService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 995);
            Controls.Add(btnCustomerDashboard);
            Controls.Add(pnlServiceRequest);
            Name = "frmRequestAService";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRequestAService";
            WindowState = FormWindowState.Maximized;
            Load += frmRequestAService_Load;
            pnlServiceRequest.ResumeLayout(false);
            pnlServiceRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBackHome;
        private Panel pnlServiceRequest;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxLogo;
        private Label lblMaintenanceRequest;
        private Button btnCustomerDashboard;
    }
}