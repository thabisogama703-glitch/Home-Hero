using HomeHero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmCreateRequest : Form
    {
        private readonly string customerEmail;

        public frmCreateRequest()
            : this(string.Empty)
        {
        }

        public frmCreateRequest(string customerEmail)
        {
            InitializeComponent();
            this.customerEmail = customerEmail;
            SetupDefaults();
            BuildBookingLayout();
        }

        private void SetupDefaults()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(HomeServiceCatalog.Services.Select(service => service.Name).ToArray());

            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.Items.Add("08:00 AM - 10:00 AM");
            cmbTimeSlot.Items.Add("10:00 AM - 12:00 PM");
            cmbTimeSlot.Items.Add("12:00 PM - 02:00 PM");
            cmbTimeSlot.Items.Add("02:00 PM - 04:00 PM");

            cmbCategory.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;

            dtpDatePreferred.MinDate = DateTime.Today;

            lblEstimatedCost.Text = "Starting estimate: R0.00";
            txtProblemDescription.TextChanged += (_, _) =>
            {
                int remaining = Math.Max(0, 10 - txtProblemDescription.Text.Trim().Length);
                lblMinimumCharacters.Text = remaining == 0
                    ? "Description length looks good."
                    : $"{remaining} more characters recommended.";
            };

        }

        private void BuildBookingLayout()
        {
            Controls.Clear();
            Text = "HomeHero | Request a service";
            BackColor = Color.FromArgb(246, 248, 251);
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;

            TableLayoutPanel page = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 176F));
            page.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));

            Panel hero = new()
            {
                BackColor = Color.FromArgb(2, 2, 89),
                BackgroundImage = Properties.Resources.BackG_image,
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Fill,
                Padding = new Padding(32)
            };
            hero.Paint += (_, e) =>
            {
                using SolidBrush overlay = new(Color.FromArgb(162, 2, 2, 89));
                e.Graphics.FillRectangle(overlay, hero.ClientRectangle);
            };
            hero.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 174, 82),
                Location = new Point(32, 24),
                Text = "HOMEHERO  /  SERVICE BOOKING"
            });
            hero.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 25F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(32, 52),
                Text = "Tell us what your home needs."
            });
            hero.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Location = new Point(36, 112),
                Text = "Choose a service, select a time, and share a few details. We’ll take it from there."
            });
            Button back = new()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(255, 138, 0),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Size = new Size(150, 38),
                Text = "Back"
            };
            back.FlatAppearance.BorderSize = 0;
            back.Click += btnBack_Click;
            hero.Controls.Add(back);
            hero.Resize += (_, _) => back.Location = new Point(hero.ClientSize.Width - back.Width - 28, 24);

            Panel cardViewport = new()
            {
                AutoScroll = true,
                BackColor = Color.FromArgb(246, 248, 251),
                Dock = DockStyle.Fill,
                Padding = new Padding(18)
            };
            TableLayoutPanel cards = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Top,
                Height = 564,
                RowCount = 2
            };
            cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cards.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cards.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cards.Controls.Add(CreateCategoryCard(), 0, 0);
            cards.Controls.Add(CreateAppointmentCard(), 1, 0);
            cards.Controls.Add(CreateDescriptionCard(), 0, 1);
            cards.Controls.Add(CreateAddressCard(), 1, 1);
            cardViewport.Controls.Add(cards);

            FlowLayoutPanel footer = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(20),
                WrapContents = false
            };
            btnSubmitRequest.Size = new Size(190, 42);
            btnSubmitRequest.Margin = new Padding(0, 0, 0, 0);
            btnSubmitRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEstimatedCost.ForeColor = Color.FromArgb(2, 2, 89);
            lblEstimatedCost.Margin = new Padding(0, 8, 20, 0);
            footer.Controls.Add(btnSubmitRequest);
            footer.Controls.Add(lblEstimatedCost);

            page.Controls.Add(hero, 0, 0);
            page.Controls.Add(cardViewport, 0, 1);
            page.Controls.Add(footer, 0, 2);
            Controls.Add(page);
            panel1.Dispose();
        }

        private HomeHeroCard CreateCategoryCard()
        {
            HomeHeroCard card = CreateBookingCard("01  Service and priority");
            TableLayoutPanel fields = CreateBookingFields(card);
            lblService.Dock = DockStyle.Fill;
            cmbCategory.Dock = DockStyle.Fill;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            lblPriority.Dock = DockStyle.Fill;
            FlowLayoutPanel priority = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };
            RdbxNormalPriorityLevel1.Margin = new Padding(0, 4, 24, 0);
            RdbtnUrgent1.Margin = new Padding(0, 4, 0, 0);
            priority.Controls.Add(RdbxNormalPriorityLevel1);
            priority.Controls.Add(RdbtnUrgent1);
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            fields.RowCount = fields.RowStyles.Count;
            fields.Controls.Add(lblService, 0, 0);
            fields.Controls.Add(cmbCategory, 0, 1);
            fields.Controls.Add(lblPriority, 0, 2);
            fields.Controls.Add(priority, 0, 3);
            return card;
        }

        private HomeHeroCard CreateAppointmentCard()
        {
            HomeHeroCard card = CreateBookingCard("02  Preferred appointment");
            TableLayoutPanel fields = CreateBookingFields(card);
            lblDate.Dock = DockStyle.Fill;
            dtpDatePreferred.Dock = DockStyle.Fill;
            label5.Text = "Preferred time slot";
            label5.Dock = DockStyle.Fill;
            cmbTimeSlot.Dock = DockStyle.Fill;
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            fields.RowCount = fields.RowStyles.Count;
            fields.Controls.Add(lblDate, 0, 0);
            fields.Controls.Add(dtpDatePreferred, 0, 1);
            fields.Controls.Add(label5, 0, 2);
            fields.Controls.Add(cmbTimeSlot, 0, 3);
            return card;
        }

        private HomeHeroCard CreateDescriptionCard()
        {
            HomeHeroCard card = CreateBookingCard("03  Describe the issue");
            TableLayoutPanel fields = CreateBookingFields(card);
            lblDescribe.Dock = DockStyle.Fill;
            txtProblemDescription.Dock = DockStyle.Fill;
            txtProblemDescription.MinimumSize = new Size(0, 110);
            lblMinimumCharacters.Dock = DockStyle.Fill;
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            fields.RowCount = fields.RowStyles.Count;
            fields.Controls.Add(lblDescribe, 0, 0);
            fields.Controls.Add(txtProblemDescription, 0, 1);
            fields.Controls.Add(lblMinimumCharacters, 0, 2);
            return card;
        }

        private HomeHeroCard CreateAddressCard()
        {
            HomeHeroCard card = CreateBookingCard("04  Service address");
            TableLayoutPanel fields = CreateBookingFields(card);
            label2.Dock = DockStyle.Fill;
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.MinimumSize = new Size(0, 110);
            txtAddress.Multiline = true;
            fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            fields.RowCount = fields.RowStyles.Count;
            fields.Controls.Add(label2, 0, 0);
            fields.Controls.Add(txtAddress, 0, 1);
            return card;
        }

        private static HomeHeroCard CreateBookingCard(string title)
        {
            HomeHeroCard card = new()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                Padding = new Padding(20)
            };
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(2, 2, 89),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            card.Controls.Add(layout);
            card.Tag = layout;
            return card;
        }

        private static TableLayoutPanel CreateBookingFields(HomeHeroCard card)
        {
            TableLayoutPanel fields = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(4, 8, 4, 4),
                RowCount = 1
            };
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            if (card.Tag is TableLayoutPanel layout)
            {
                layout.Controls.Add(fields, 0, 1);
            }
            return fields;
        }


        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a service category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtProblemDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a detailed description of the problem.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtProblemDescription.Text.Trim().Length < 10)
            {
                MessageBox.Show(
                    "Please provide a more detailed description of the problem.",
                    "Invalid Description",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Please enter the property address.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtAddress.Text.Trim().Length < 5)
            {
                MessageBox.Show(
                    "Please enter a valid property address.",
                    "Invalid Address",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpDatePreferred.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Please select a date that is today or later.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (cmbTimeSlot.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a preferred time slot.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (dtpDatePreferred.Value.Date == DateTime.Today &&
                   cmbTimeSlot.SelectedIndex != -1)
            {
                string selectedTime = cmbTimeSlot.SelectedItem.ToString();

                DateTime currentTime = DateTime.Now;

                if (selectedTime.StartsWith("08:00") &&
                    currentTime.TimeOfDay >= new TimeSpan(8, 0, 0))
                {
                    MessageBox.Show(
                        "The selected time slot has already passed. Please choose another time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (selectedTime.StartsWith("10:00") &&
                    currentTime.TimeOfDay >= new TimeSpan(10, 0, 0))
                {
                    MessageBox.Show(
                        "The selected time slot has already passed. Please choose another time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (selectedTime.StartsWith("12:00") &&
                    currentTime.TimeOfDay >= new TimeSpan(12, 0, 0))
                {
                    MessageBox.Show(
                        "The selected time slot has already passed. Please choose another time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (selectedTime.StartsWith("02:00") &&
                    currentTime.TimeOfDay >= new TimeSpan(14, 0, 0))
                {
                    MessageBox.Show(
                        "The selected time slot has already passed. Please choose another time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(customerEmail))
            {
                MessageBox.Show(
                    "Please sign in as a customer before creating a service request.",
                    "Customer Sign-in Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MaintenanceRequest newRequest = new MaintenanceRequest(
                customerEmail,
                cmbCategory.SelectedItem.ToString(),
                txtProblemDescription.Text.Trim(),
                txtAddress.Text.Trim(),
                dtpDatePreferred.Value.Date,
                cmbTimeSlot.SelectedItem.ToString()
                );
            if (!newRequest.ValidateRequest(out string errorMessage))
            {
                MessageBox.Show(
                    errorMessage,
                    "Invalid Request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataManager.AddRequest(newRequest);

            DialogResult result =  MessageBox.Show(
            "Request submitted successfully!\n\n" +
            "Request Number: " + newRequest.RequestNumber + "\n" +
            "Estimated starting price: R" +
            newRequest.EstimatedCost.ToString("F2") + "\n" +
            "Status: " + newRequest.Status + "\n Would you like to create another service request?",
            "Request Submitted",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if(result == DialogResult.No)
            {
                Close();
            }
            else
            {

            }

            ClearForm();
        }
        private void ClearForm()
        {
            cmbCategory.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;
            txtAddress.Clear();
            txtProblemDescription.Clear();
            dtpDatePreferred.Value = DateTime.Today;
            lblEstimatedCost.Text = "Starting estimate: R0.00";
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                lblEstimatedCost.Text =
                    "Starting estimate: R0.00";
                return;
            }

            string category = cmbCategory.SelectedItem.ToString();
            MaintenanceRequest temp = new MaintenanceRequest();
            decimal estimate = temp.CalculateEstimatedCost(category);
            lblEstimatedCost.Text = $"Starting estimate: R{estimate:F2}";
        }

        private void CreateRequestForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
