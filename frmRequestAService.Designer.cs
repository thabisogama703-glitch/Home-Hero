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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequestAService));
            btnBackHome = new ModernButton();
            pnlServiceRequest = new Panel();
            lblGetHelpFast = new Label();
            lblMaintenanceR = new Label();
            lblMaintenanceRequest = new Label();
            lblSubmitaMaintenanceRequest = new Label();
            lblHero = new Label();
            lblHome = new Label();
            pbxLogo = new PictureBox();
            pnlHeaderDivider = new Panel();
            pnlPriorityDivider = new Panel();
            panel1 = new CardPanel();
            RdbtnUrgent = new RadioButton();
            RdbxNormalPriorityLevel = new RadioButton();
            lblPriorityLevel = new Label();
            cbxServices = new ComboBox();
            lblAesterick = new Label();
            label1 = new Label();
            lblServiceCategory = new Label();
            lblServicenumber1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panel2 = new CardPanel();
            lblMinimumCharacters = new Label();
            txtProblemDEscription = new TextBox();
            label3 = new Label();
            label4 = new Label();
            lblProblemDescription = new Label();
            label6 = new Label();
            btnNext = new ModernButton();
            ValidationError = new ErrorProvider(components);
            panel3 = new CardPanel();
            pnlNote = new SoftNote();
            lblMessage = new Label();
            cbxPreferredTime = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label11 = new Label();
            label5 = new Label();
            label10 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel4 = new CardPanel();
            gbxReadyToSubmit = new SoftGroupBox();
            btnSubmitRequest = new ModernButton();
            btnCancelReuest = new ModernButton();
            gbxPropertyAddress = new SoftGroupBox();
            txtPropertyAddress = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmailAddress = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label17 = new Label();
            label13 = new Label();
            lblEmailAddress = new Label();
            label14 = new Label();
            lblLastName = new Label();
            lblName = new Label();
            lblYourInformation = new Label();
            label15 = new Label();
            gxContactDetails = new SoftGroupBox();
            lblPhoneNumber = new Label();
            label18 = new Label();
            pnlServiceRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ValidationError).BeginInit();
            panel3.SuspendLayout();
            pnlNote.SuspendLayout();
            panel4.SuspendLayout();
            gbxReadyToSubmit.SuspendLayout();
            gbxPropertyAddress.SuspendLayout();
            gxContactDetails.SuspendLayout();
            SuspendLayout();
            // 
            // btnBackHome
            // 
            btnBackHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackHome.AutoSize = false;
            btnBackHome.BackColor = Color.FromArgb(22, 45, 92);
            btnBackHome.Cursor = Cursors.Hand;
            btnBackHome.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(1660, 69);
            btnBackHome.Size = new Size(170, 42);
            btnBackHome.UseVisualStyleBackColor = false;
            btnBackHome.FlatAppearance.BorderColor = Color.FromArgb(255, 107, 53);
            btnBackHome.FlatAppearance.BorderSize = 1;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.BaseColor = Color.FromArgb(22, 45, 92);
            btnBackHome.HoverColor = Color.FromArgb(44, 80, 140);
            btnBackHome.BorderColor = Color.FromArgb(255, 107, 53);
            btnBackHome.Radius = 12;
            btnBackHome.Name = "btnBackHome";
            btnBackHome.TabIndex = 0;
            btnBackHome.Text = "<- back to Home";
            btnBackHome.Click += btnBackHome_Click;
            // 
            // pnlServiceRequest
            // 
            pnlServiceRequest.BackColor = Color.FromArgb(22, 45, 92);
            pnlServiceRequest.Size = new Size(1886, 160);
            pnlServiceRequest.BackgroundImageLayout = ImageLayout.Stretch;
            pnlServiceRequest.Controls.Add(lblGetHelpFast);
            pnlServiceRequest.Controls.Add(lblMaintenanceR);
            pnlServiceRequest.Controls.Add(lblMaintenanceRequest);
            pnlServiceRequest.Controls.Add(lblSubmitaMaintenanceRequest);
            pnlServiceRequest.Controls.Add(btnBackHome);
            pnlServiceRequest.Controls.Add(lblHero);
            pnlServiceRequest.Controls.Add(lblHome);
            pnlServiceRequest.Controls.Add(pbxLogo);
            pnlServiceRequest.Controls.Add(pnlHeaderDivider);
            pnlServiceRequest.Dock = DockStyle.Top;
            pnlServiceRequest.Location = new Point(0, 0);
            pnlServiceRequest.Margin = new Padding(4, 5, 4, 5);
            pnlServiceRequest.Name = "pnlServiceRequest";
            pnlServiceRequest.TabIndex = 1;
            pnlServiceRequest.Paint += pnlServiceRequest_Paint;
            // 
            // lblGetHelpFast
            // 
            lblGetHelpFast.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGetHelpFast.ForeColor = Color.FromArgb(255, 107, 53);
            lblGetHelpFast.Location = new Point(352, 40);
            lblGetHelpFast.AutoSize = true;
            lblGetHelpFast.Name = "lblGetHelpFast";
            lblGetHelpFast.Size = new Size(109, 20);
            lblGetHelpFast.TabIndex = 11;
            lblGetHelpFast.Text = "GET HELP FAST";
            // 
            // lblMaintenanceR
            // 
            lblMaintenanceR.BackColor = Color.Transparent;
            lblMaintenanceR.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceR.ForeColor = Color.FromArgb(203, 213, 232);
            lblMaintenanceR.Location = new Point(354, 108);
            lblMaintenanceR.Size = new Size(1100, 40);
            lblMaintenanceR.Name = "lblMaintenanceR";
            lblMaintenanceR.TabIndex = 1;
            lblMaintenanceR.Text = "Fill in the details below and we'll match you with a verified, insured professional — usually within 2 hours.";
            // 
            // lblMaintenanceRequest
            // 
            lblMaintenanceRequest.Visible = false;
            lblMaintenanceRequest.AutoSize = true;
            lblMaintenanceRequest.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceRequest.ForeColor = Color.White;
            lblMaintenanceRequest.Location = new Point(932, 23);
            lblMaintenanceRequest.Name = "lblMaintenanceRequest";
            lblMaintenanceRequest.Size = new Size(284, 38);
            lblMaintenanceRequest.TabIndex = 2;
            lblMaintenanceRequest.Text = "Maintenance Request";
            // 
            // lblSubmitaMaintenanceRequest
            // 
            lblSubmitaMaintenanceRequest.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubmitaMaintenanceRequest.Location = new Point(352, 60);
            lblSubmitaMaintenanceRequest.AutoSize = true;
            lblSubmitaMaintenanceRequest.ForeColor = Color.White;
            lblSubmitaMaintenanceRequest.Name = "lblSubmitaMaintenanceRequest";
            lblSubmitaMaintenanceRequest.Size = new Size(429, 41);
            lblSubmitaMaintenanceRequest.TabIndex = 2;
            lblSubmitaMaintenanceRequest.Text = "Submit a Maintenance Request";
            // 
            // lblHero
            // 
            lblHero.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHero.ForeColor = Color.White;
            lblHero.Location = new Point(214, 70);
            lblHero.AutoSize = true;
            lblHero.BackColor = Color.Transparent;
            lblHero.FlatStyle = FlatStyle.Flat;
            lblHero.Name = "lblHero";
            lblHero.Size = new Size(87, 41);
            lblHero.TabIndex = 10;
            lblHero.Text = "Hero";
            // 
            // lblHome
            // 
            lblHome.Location = new Point(122, 70);
            lblHome.AutoSize = true;
            lblHome.BackColor = Color.Transparent;
            lblHome.FlatStyle = FlatStyle.Flat;
            lblHome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.White;
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(102, 41);
            lblHome.TabIndex = 10;
            lblHome.Text = "Home";
            // 
            // pbxLogo
            // 
            pbxLogo.Location = new Point(56, 62);
            pbxLogo.Size = new Size(56, 56);
            pbxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbxLogo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            pbxLogo.Name = "pbxLogo";
            pbxLogo.TabIndex = 10;
            pbxLogo.TabStop = false;
            // 
            // pnlHeaderDivider
            // 
            pnlHeaderDivider.BackColor = Color.FromArgb(80, 102, 150);
            pnlHeaderDivider.Location = new Point(330, 48);
            pnlHeaderDivider.Name = "pnlHeaderDivider";
            pnlHeaderDivider.Size = new Size(1, 84);
            pnlHeaderDivider.TabIndex = 12;
            // 
            // pnlPriorityDivider
            // 
            pnlPriorityDivider.BackColor = Color.FromArgb(226, 232, 240);
            pnlPriorityDivider.Location = new Point(32, 176);
            pnlPriorityDivider.Name = "pnlPriorityDivider";
            pnlPriorityDivider.Size = new Size(811, 1);
            pnlPriorityDivider.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.None;
            panel1.ForeColor = Color.FromArgb(22, 45, 92);
            panel1.Location = new Point(56, 180);
            panel1.Size = new Size(875, 310);
            panel1.Controls.Add(RdbtnUrgent);
            panel1.Controls.Add(RdbxNormalPriorityLevel);
            panel1.Controls.Add(lblPriorityLevel);
            panel1.Controls.Add(cbxServices);
            panel1.Controls.Add(lblAesterick);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblServiceCategory);
            panel1.Controls.Add(lblServicenumber1);
            panel1.Controls.Add(pnlPriorityDivider);
            panel1.Name = "panel1";
            panel1.TabIndex = 2;
            // 
            // RdbtnUrgent
            // 
            RdbtnUrgent.Cursor = Cursors.Hand;
            RdbtnUrgent.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RdbtnUrgent.Location = new Point(300, 226);
            RdbtnUrgent.AutoSize = true;
            RdbtnUrgent.Name = "RdbtnUrgent";
            RdbtnUrgent.Size = new Size(145, 44);
            RdbtnUrgent.TabIndex = 7;
            RdbtnUrgent.TabStop = true;
            RdbtnUrgent.Text = "🔴Urgent\r\nSame day / ASAP\r\n";
            RdbtnUrgent.UseVisualStyleBackColor = true;
            // 
            // RdbxNormalPriorityLevel
            // 
            RdbxNormalPriorityLevel.Cursor = Cursors.Hand;
            RdbxNormalPriorityLevel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RdbxNormalPriorityLevel.Location = new Point(32, 226);
            RdbxNormalPriorityLevel.AutoSize = true;
            RdbxNormalPriorityLevel.Name = "RdbxNormalPriorityLevel";
            RdbxNormalPriorityLevel.Size = new Size(147, 44);
            RdbxNormalPriorityLevel.TabIndex = 7;
            RdbxNormalPriorityLevel.TabStop = true;
            RdbxNormalPriorityLevel.Text = "\U0001f7e2Normal\r\nWithin a few days";
            RdbxNormalPriorityLevel.UseVisualStyleBackColor = true;
            // 
            // lblPriorityLevel
            // 
            lblPriorityLevel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPriorityLevel.Location = new Point(32, 192);
            lblPriorityLevel.AutoSize = true;
            lblPriorityLevel.Name = "lblPriorityLevel";
            lblPriorityLevel.Size = new Size(125, 28);
            lblPriorityLevel.TabIndex = 5;
            lblPriorityLevel.Text = "Priority Level";
            // 
            // cbxServices
            // 
            cbxServices.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxServices.Location = new Point(32, 126);
            cbxServices.Size = new Size(811, 31);
            cbxServices.FormattingEnabled = true;
            cbxServices.Items.AddRange(new object[] { "🔧Plumbing", "⚡Electrical", "🔌Appliance Repair", "🎨Painting", "🌿Landscaping", "🏠General Maintenance" });
            cbxServices.Name = "cbxServices";
            cbxServices.TabIndex = 4;
            // 
            // lblAesterick
            // 
            lblAesterick.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAesterick.ForeColor = Color.FromArgb(220, 53, 69);
            lblAesterick.Location = new Point(307, 92);
            lblAesterick.AutoSize = true;
            lblAesterick.Name = "lblAesterick";
            lblAesterick.Size = new Size(15, 20);
            lblAesterick.TabIndex = 3;
            lblAesterick.Text = "*";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 92);
            label1.AutoSize = true;
            label1.Name = "label1";
            label1.Size = new Size(314, 28);
            label1.TabIndex = 2;
            label1.Text = "What type of service do you need?";
            // 
            // lblServiceCategory
            // 
            lblServiceCategory.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServiceCategory.Location = new Point(80, 25);
            lblServiceCategory.AutoSize = true;
            lblServiceCategory.Name = "lblServiceCategory";
            lblServiceCategory.Size = new Size(224, 38);
            lblServiceCategory.TabIndex = 1;
            lblServiceCategory.Text = "Service Category";
            // 
            // lblServicenumber1
            // 
            lblServicenumber1.AutoSize = false;
            lblServicenumber1.BackColor = Color.FromArgb(255, 107, 53);
            lblServicenumber1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServicenumber1.ForeColor = Color.White;
            lblServicenumber1.Location = new Point(28, 22);
            lblServicenumber1.Size = new Size(40, 40);
            lblServicenumber1.TextAlign = ContentAlignment.MiddleCenter;
            lblServicenumber1.Name = "lblServicenumber1";
            lblServicenumber1.TabIndex = 0;
            lblServicenumber1.Text = "1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.None;
            panel2.ForeColor = Color.FromArgb(22, 45, 92);
            panel2.Location = new Point(56, 510);
            panel2.Size = new Size(875, 480);
            panel2.Controls.Add(lblMinimumCharacters);
            panel2.Controls.Add(txtProblemDEscription);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblProblemDescription);
            panel2.Controls.Add(label6);
            panel2.Name = "panel2";
            panel2.TabIndex = 2;
            // 
            // lblMinimumCharacters
            // 
            lblMinimumCharacters.AutoSize = false;
            lblMinimumCharacters.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMinimumCharacters.ForeColor = Color.FromArgb(100, 116, 139);
            lblMinimumCharacters.Location = new Point(443, 428);
            lblMinimumCharacters.Size = new Size(400, 24);
            lblMinimumCharacters.TextAlign = ContentAlignment.MiddleRight;
            lblMinimumCharacters.Name = "lblMinimumCharacters";
            lblMinimumCharacters.TabIndex = 5;
            lblMinimumCharacters.Text = "20 characters minimum";
            // 
            // txtProblemDEscription
            // 
            txtProblemDEscription.BorderStyle = BorderStyle.FixedSingle;
            txtProblemDEscription.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProblemDEscription.Location = new Point(32, 126);
            txtProblemDEscription.Size = new Size(811, 290);
            txtProblemDEscription.Multiline = true;
            txtProblemDEscription.Name = "txtProblemDEscription";
            txtProblemDEscription.PlaceholderText = "E.g The kitchen sink has been dripping for 3 days - water is pooling under the cabinet I've turned off the tap under the sink. The property is available during business hours.";
            txtProblemDEscription.TabIndex = 4;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(220, 53, 69);
            label3.Location = new Point(252, 92);
            label3.AutoSize = true;
            label3.Name = "label3";
            label3.Size = new Size(15, 20);
            label3.TabIndex = 3;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 92);
            label4.AutoSize = true;
            label4.Name = "label4";
            label4.Size = new Size(242, 28);
            label4.TabIndex = 2;
            label4.Text = "Describe the issue in detail";
            // 
            // lblProblemDescription
            // 
            lblProblemDescription.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProblemDescription.Location = new Point(80, 25);
            lblProblemDescription.AutoSize = true;
            lblProblemDescription.Name = "lblProblemDescription";
            lblProblemDescription.Size = new Size(270, 38);
            lblProblemDescription.TabIndex = 1;
            lblProblemDescription.Text = "Problem Description";
            // 
            // label6
            // 
            label6.AutoSize = false;
            label6.BackColor = Color.FromArgb(255, 107, 53);
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(28, 22);
            label6.Size = new Size(40, 40);
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Name = "label6";
            label6.TabIndex = 0;
            label6.Text = "2";
            // 
            // btnNext
            // 
            btnNext.FlatAppearance.BorderColor = Color.Gray;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.ForeColor = Color.FromArgb(255, 128, 0);
            btnNext.Location = new Point(1616, 508);
            btnNext.Outline = true;
            btnNext.BaseColor = Color.FromArgb(255, 107, 53);
            btnNext.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // ValidationError
            // 
            ValidationError.ContainerControl = this;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.None;
            panel3.ForeColor = Color.FromArgb(22, 45, 92);
            panel3.Location = new Point(955, 180);
            panel3.Size = new Size(875, 282);
            panel3.Controls.Add(pnlNote);
            panel3.Controls.Add(cbxPreferredTime);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label9);
            panel3.Name = "panel3";
            panel3.TabIndex = 2;
            // 
            // pnlNote
            // 
            pnlNote.BackColor = Color.FromArgb(232, 241, 252);
            pnlNote.BorderStyle = BorderStyle.None;
            pnlNote.Location = new Point(32, 184);
            pnlNote.Size = new Size(811, 70);
            pnlNote.Controls.Add(lblMessage);
            pnlNote.Name = "pnlNote";
            pnlNote.TabIndex = 6;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.FromArgb(22, 45, 92);
            lblMessage.Location = new Point(16, 14);
            lblMessage.AutoSize = true;
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(554, 40);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Note: This is your preferred slot — we'll confirm availability once a pro is matched.\r\nUrgent requests may be responded to sooner.";
            // 
            // cbxPreferredTime
            // 
            cbxPreferredTime.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxPreferredTime.Location = new Point(449, 126);
            cbxPreferredTime.Size = new Size(394, 31);
            cbxPreferredTime.ForeColor = Color.Black;
            cbxPreferredTime.FormattingEnabled = true;
            cbxPreferredTime.Items.AddRange(new object[] { "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" });
            cbxPreferredTime.Name = "cbxPreferredTime";
            cbxPreferredTime.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dddd dd MMMM yyyy";
            dateTimePicker1.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(32, 126);
            dateTimePicker1.Size = new Size(394, 31);
            dateTimePicker1.MinDate = new DateTime(2026, 9, 21, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.TabIndex = 4;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(220, 53, 69);
            label11.Location = new Point(578, 92);
            label11.AutoSize = true;
            label11.Name = "label11";
            label11.Size = new Size(15, 20);
            label11.TabIndex = 3;
            label11.Text = "*";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(220, 53, 69);
            label5.Location = new Point(160, 92);
            label5.AutoSize = true;
            label5.Name = "label5";
            label5.Size = new Size(15, 20);
            label5.TabIndex = 3;
            label5.Text = "*";
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(449, 92);
            label10.AutoSize = true;
            label10.Name = "label10";
            label10.Size = new Size(139, 28);
            label10.TabIndex = 2;
            label10.Text = "Preferred Time";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(32, 92);
            label7.AutoSize = true;
            label7.Name = "label7";
            label7.Size = new Size(138, 28);
            label7.TabIndex = 2;
            label7.Text = "Preferred Date";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(80, 25);
            label8.AutoSize = true;
            label8.Name = "label8";
            label8.Size = new Size(326, 38);
            label8.TabIndex = 1;
            label8.Text = "Preferred Date And Time";
            // 
            // label9
            // 
            label9.AutoSize = false;
            label9.BackColor = Color.FromArgb(255, 107, 53);
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(28, 22);
            label9.Size = new Size(40, 40);
            label9.TextAlign = ContentAlignment.MiddleCenter;
            label9.Name = "label9";
            label9.TabIndex = 0;
            label9.Text = "3";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.None;
            panel4.ForeColor = Color.FromArgb(22, 45, 92);
            panel4.Location = new Point(955, 482);
            panel4.Size = new Size(875, 508);
            panel4.Controls.Add(gbxReadyToSubmit);
            panel4.Controls.Add(gbxPropertyAddress);
            panel4.Controls.Add(txtPhoneNumber);
            panel4.Controls.Add(txtEmailAddress);
            panel4.Controls.Add(txtLastName);
            panel4.Controls.Add(txtFirstName);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(lblEmailAddress);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(lblLastName);
            panel4.Controls.Add(lblName);
            panel4.Controls.Add(lblYourInformation);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(gxContactDetails);
            panel4.Name = "panel4";
            panel4.TabIndex = 2;
            // 
            // gbxReadyToSubmit
            // 
            gbxReadyToSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxReadyToSubmit.ForeColor = Color.FromArgb(22, 45, 92);
            gbxReadyToSubmit.Location = new Point(28, 422);
            gbxReadyToSubmit.Size = new Size(819, 72);
            gbxReadyToSubmit.Controls.Add(btnSubmitRequest);
            gbxReadyToSubmit.Controls.Add(btnCancelReuest);
            gbxReadyToSubmit.Name = "gbxReadyToSubmit";
            gbxReadyToSubmit.TabIndex = 7;
            gbxReadyToSubmit.TabStop = false;
            gbxReadyToSubmit.Text = "Ready to Submit?";
            // 
            // btnSubmitRequest
            // 
            btnSubmitRequest.BackColor = Color.FromArgb(255, 107, 53);
            btnSubmitRequest.Cursor = Cursors.Hand;
            btnSubmitRequest.FlatAppearance.BorderSize = 0;
            btnSubmitRequest.FlatStyle = FlatStyle.Flat;
            btnSubmitRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmitRequest.ForeColor = Color.White;
            btnSubmitRequest.Location = new Point(418, 28);
            btnSubmitRequest.Size = new Size(385, 34);
            btnSubmitRequest.BaseColor = Color.FromArgb(255, 107, 53);
            btnSubmitRequest.HoverColor = Color.FromArgb(255, 132, 84);
            btnSubmitRequest.Name = "btnSubmitRequest";
            btnSubmitRequest.TabIndex = 0;
            btnSubmitRequest.Text = "→ Submit Request";
            btnSubmitRequest.UseVisualStyleBackColor = false;
            btnSubmitRequest.Click += btnSubmitRequest_Click;
            // 
            // btnCancelReuest
            // 
            btnCancelReuest.BackColor = Color.FromArgb(108, 117, 136);
            btnCancelReuest.Cursor = Cursors.Hand;
            btnCancelReuest.FlatAppearance.BorderSize = 0;
            btnCancelReuest.FlatStyle = FlatStyle.Flat;
            btnCancelReuest.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelReuest.ForeColor = Color.White;
            btnCancelReuest.Location = new Point(16, 28);
            btnCancelReuest.Size = new Size(385, 34);
            btnCancelReuest.UseVisualStyleBackColor = false;
            btnCancelReuest.BaseColor = Color.FromArgb(108, 117, 136);
            btnCancelReuest.HoverColor = Color.FromArgb(130, 139, 158);
            btnCancelReuest.Name = "btnCancelReuest";
            btnCancelReuest.TabIndex = 0;
            btnCancelReuest.Text = "Cancel";
            btnCancelReuest.Click += btnCancelReuest_Click;
            // 
            // gbxPropertyAddress
            // 
            gbxPropertyAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxPropertyAddress.ForeColor = Color.FromArgb(22, 45, 92);
            gbxPropertyAddress.Location = new Point(28, 276);
            gbxPropertyAddress.Size = new Size(819, 132);
            gbxPropertyAddress.Controls.Add(txtPropertyAddress);
            gbxPropertyAddress.Name = "gbxPropertyAddress";
            gbxPropertyAddress.TabIndex = 6;
            gbxPropertyAddress.TabStop = false;
            gbxPropertyAddress.Text = "Property Address";
            // 
            // txtPropertyAddress
            // 
            txtPropertyAddress.BorderStyle = BorderStyle.FixedSingle;
            txtPropertyAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPropertyAddress.Location = new Point(16, 28);
            txtPropertyAddress.Size = new Size(787, 88);
            txtPropertyAddress.Multiline = true;
            txtPropertyAddress.Name = "txtPropertyAddress";
            txtPropertyAddress.TabIndex = 0;
            txtPropertyAddress.TextChanged += txtPropertyAddress_TextChanged;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPhoneNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(44, 210);
            txtPhoneNumber.Size = new Size(785, 27);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "0708506666";
            txtPhoneNumber.TabIndex = 4;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.BorderStyle = BorderStyle.FixedSingle;
            txtEmailAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailAddress.Location = new Point(578, 136);
            txtEmailAddress.Size = new Size(251, 27);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.PlaceholderText = "johndoe7@gmail.com";
            txtEmailAddress.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(311, 136);
            txtLastName.Size = new Size(251, 27);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Cena";
            txtLastName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(44, 136);
            txtFirstName.Size = new Size(251, 27);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "John";
            txtFirstName.TabIndex = 4;
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.FromArgb(220, 53, 69);
            label17.Location = new Point(399, 108);
            label17.AutoSize = true;
            label17.Name = "label17";
            label17.Size = new Size(15, 20);
            label17.TabIndex = 3;
            label17.Text = "*";
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(220, 53, 69);
            label13.Location = new Point(134, 108);
            label13.AutoSize = true;
            label13.Name = "label13";
            label13.Size = new Size(15, 20);
            label13.TabIndex = 3;
            label13.Text = "*";
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmailAddress.ForeColor = Color.FromArgb(220, 53, 69);
            lblEmailAddress.Location = new Point(693, 108);
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(15, 20);
            lblEmailAddress.TabIndex = 3;
            lblEmailAddress.Text = "*";
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(578, 108);
            label14.AutoSize = true;
            label14.Name = "label14";
            label14.Size = new Size(134, 28);
            label14.TabIndex = 2;
            label14.Text = "Email Address";
            // 
            // lblLastName
            // 
            lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(311, 108);
            lblLastName.AutoSize = true;
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(103, 28);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(44, 108);
            lblName.AutoSize = true;
            lblName.Name = "lblName";
            lblName.Size = new Size(106, 28);
            lblName.TabIndex = 2;
            lblName.Text = "First Name";
            // 
            // lblYourInformation
            // 
            lblYourInformation.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYourInformation.Location = new Point(80, 25);
            lblYourInformation.AutoSize = true;
            lblYourInformation.Name = "lblYourInformation";
            lblYourInformation.Size = new Size(224, 38);
            lblYourInformation.TabIndex = 1;
            lblYourInformation.Text = "Your Information";
            // 
            // label15
            // 
            label15.AutoSize = false;
            label15.BackColor = Color.FromArgb(255, 107, 53);
            label15.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(28, 22);
            label15.Size = new Size(40, 40);
            label15.TextAlign = ContentAlignment.MiddleCenter;
            label15.Name = "label15";
            label15.TabIndex = 0;
            label15.Text = "4";
            // 
            // gxContactDetails
            // 
            gxContactDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gxContactDetails.ForeColor = Color.FromArgb(22, 45, 92);
            gxContactDetails.Location = new Point(28, 76);
            gxContactDetails.Size = new Size(819, 186);
            gxContactDetails.Controls.Add(lblPhoneNumber);
            gxContactDetails.Controls.Add(label18);
            gxContactDetails.Name = "gxContactDetails";
            gxContactDetails.TabIndex = 5;
            gxContactDetails.TabStop = false;
            gxContactDetails.Text = "Contact Details";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(16, 106);
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(105, 20);
            lblPhoneNumber.TabIndex = 0;
            lblPhoneNumber.Text = "Phone number";
            // 
            // label18
            // 
            label18.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(220, 53, 69);
            label18.Location = new Point(137, 106);
            label18.AutoSize = true;
            label18.Name = "label18";
            label18.Size = new Size(15, 20);
            label18.TabIndex = 3;
            label18.Text = "*";
            // 
            // frmRequestAService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 242, 247);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1886, 1055);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnlServiceRequest);
            Controls.Add(btnNext);
            Name = "frmRequestAService";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRequestAService";
            WindowState = FormWindowState.Maximized;
            Load += frmRequestAService_Load;
            pnlServiceRequest.ResumeLayout(false);
            pnlServiceRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ValidationError).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlNote.ResumeLayout(false);
            pnlNote.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            gbxReadyToSubmit.ResumeLayout(false);
            gbxPropertyAddress.ResumeLayout(false);
            gbxPropertyAddress.PerformLayout();
            gxContactDetails.ResumeLayout(false);
            gxContactDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ModernButton btnBackHome;
        private Panel pnlServiceRequest;
        private Label lblHero;
        private Label lblHome;
        private PictureBox pbxLogo;
        private Label lblMaintenanceRequest;
        private Label lblMaintenanceR;
        private Label lblSubmitaMaintenanceRequest;
        private Label lblGetHelpFast;
        private CardPanel panel1;
        private Label lblServicenumber1;
        private ComboBox cbxServices;
        private Label lblAesterick;
        private Label label1;
        private Label lblServiceCategory;
        private Label lblPriorityLevel;
        private OpenFileDialog openFileDialog1;
        private CardPanel panel2;
        private TextBox txtProblemDEscription;
        private Label label3;
        private Label label4;
        private Label lblProblemDescription;
        private Label label6;
        private Label lblMinimumCharacters;
        private ModernButton btnNext;
        private ErrorProvider ValidationError;
        private CardPanel panel3;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePicker1;
        private Label label11;
        private Label label10;
        private ComboBox cbxPreferredTime;
        private Panel pnlNote;
        private Label lblMessage;
        private CardPanel panel4;
        private Label label12;
        private Label lblName;
        private Label lblYourInformation;
        private Label label15;
        private Label label16;
        private Label label14;
        private Label lblLastName;
        private TextBox txtPhoneNumber;
        private TextBox txtEmailAddress;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label17;
        private Label label13;
        private Label lblEmailAddress;
        private Label label18;
        private SoftGroupBox gbxPropertyAddress;
        private TextBox txtPropertyAddress;
        private SoftGroupBox gxContactDetails;
        private SoftGroupBox gbxReadyToSubmit;
        private ModernButton btnSubmitRequest;
        private ModernButton btnCancelReuest;
        private Label lblPhoneNumber;
        private RadioButton RdbxNormalPriorityLevel;
        private RadioButton RdbtnUrgent;
        private Panel pnlHeaderDivider;
        private Panel pnlPriorityDivider;
    }
}