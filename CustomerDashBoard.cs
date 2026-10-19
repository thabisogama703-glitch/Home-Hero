using Home_Hero;
using HomeHero_2;
using Krypton.Toolkit;

namespace HomeHero
{
    public partial class frmCustomerDashboard : Form
    {
        private readonly string currentCustomerEmail;

        public frmCustomerDashboard()
            : this(string.Empty)
        {
        }

        public frmCustomerDashboard(string customerEmail)
        {
            InitializeComponent();
            currentCustomerEmail = customerEmail;
            AddMessagesButton();
            RefreshDashboard();
        }

        private void btnNewServiceRequest_Click_1(object sender, EventArgs e)
        {
            using frmCreateRequest requestForm = new frmCreateRequest(currentCustomerEmail);
            requestForm.ShowDialog(this);
            RefreshDashboard();
        }

        public void btnTrackRequest_Click_1(object sender, EventArgs e)
        {
            using frmRequestTracking requestTracking = new frmRequestTracking(currentCustomerEmail);
            requestTracking.ShowDialog(this);
            RefreshDashboard();
        }

        private void BtnActiceRequests_Click(object sender, EventArgs e)
        {
            using frmActiveRequest activeRequest = new frmActiveRequest(GetCustomerRequests());
            activeRequest.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnServiceHistory_Click(object sender, EventArgs e)
        {
            using ServiceHistoryForm serviceHistory = new ServiceHistoryForm(GetCustomerRequests());
            serviceHistory.ShowDialog(this);
            RefreshDashboard();
        }

        private void frmCustomerDashboard_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private List<MaintenanceRequest> GetCustomerRequests()
        {
            if (string.IsNullOrWhiteSpace(currentCustomerEmail))
            {
                return new List<MaintenanceRequest>();
            }

            return DataManager.LoadRequests()
                .Where(request => string.Equals(
                    request.CustomerId,
                    currentCustomerEmail,
                    StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(request => request.PreferredDate)
                .ToList();
        }

        private void AddMessagesButton()
        {
            KryptonButton messagesButton = new()
            {
                Text = "Messages",
                Location = new Point(12, 396),
                Size = new Size(265, 42),
                BackColor = Color.FromArgb(255, 128, 0),
                ForeColor = Color.White
            };
            messagesButton.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 0);
            messagesButton.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 0);
            messagesButton.StateCommon.Content.ShortText.Color1 = Color.White;
            messagesButton.StateCommon.Border.Rounding = 8;
            messagesButton.Click += (_, _) =>
            {
                using MessageCenterForm messageCenter =
                    new(currentCustomerEmail, false, GetCustomerRequests());
                messageCenter.ShowDialog(this);
            };
            panel3.Controls.Add(messagesButton);
            btnLogout.Location = new Point(btnLogout.Location.X, 458);
        }

        private void RefreshDashboard()
        {
            List<MaintenanceRequest> requests = GetCustomerRequests();
            int activeCount = requests.Count(request =>
                request.Status != RequestStatus.Completed &&
                request.Status != RequestStatus.Cancelled);
            int completedCount = requests.Count(request => request.Status == RequestStatus.Completed);
            int inProgressCount = requests.Count(request => request.Status == RequestStatus.InProgress);
            int totalCount = requests.Count;
            int progress = totalCount == 0 ? 0 : (int)Math.Round(completedCount * 100.0 / totalCount);

            pnlDashBoard.Controls.Clear();
            pnlDashBoard.Controls.Add(new Label
            {
                Text = "Your home service overview",
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                AutoSize = true,
                Location = new Point(28, 24)
            });

            AddSummaryCard("Total requests", totalCount, 28);
            AddSummaryCard("Active requests", activeCount, 405);
            AddSummaryCard("In progress", inProgressCount, 782);
            AddSummaryCard("Completed", completedCount, 1159);

            pnlDashBoard.Controls.Add(new Label
            {
                Text = $"Completed services  {progress}%",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                AutoSize = true,
                Location = new Point(30, 230)
            });

            ProgressBar progressBar = new()
            {
                Minimum = 0,
                Maximum = 100,
                Value = progress,
                Location = new Point(30, 264),
                Size = new Size(1450, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlDashBoard.Controls.Add(progressBar);

            string latestSummary = requests.Count == 0
                ? "Create a service request to see updates and progress here."
                : $"Latest update: {requests[0].ServiceCategory} · {requests[0].RequestNumber} · {requests[0].Status}";
            pnlDashBoard.Controls.Add(new Label
            {
                Text = latestSummary,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(30, 320)
            });
        }

        private void AddSummaryCard(string title, int value, int x)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(x, 96),
                Size = new Size(345, 112)
            };
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(18, 15)
            });
            card.Controls.Add(new Label
            {
                Text = value.ToString(),
                Font = new Font("Segoe UI", 25F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 128, 0),
                AutoSize = true,
                Location = new Point(18, 44)
            });
            pnlDashBoard.Controls.Add(card);
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logging Out", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmHomeHeroHomepage frmHomeHeroHomepage = new frmHomeHeroHomepage();
                this.Hide();
                frmHomeHeroHomepage.Show();
            }
            else
            {

            }


        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void lblJobsDoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerDashboardTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            frmHomeHeroHomepage backtoHome = new frmHomeHeroHomepage();
            this.Hide();
            backtoHome.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
