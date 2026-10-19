using HomeHero_2;
using System.Globalization;

namespace Home_Hero
{
    public partial class frmAdminDashboard : Form
    {
        private readonly Label totalRequestsValue = CreateDashboardValue();
        private readonly Label awaitingApprovalValue = CreateDashboardValue();
        private readonly Label registeredProvidersValue = CreateDashboardValue();
        private readonly Label totalRevenueValue = CreateDashboardValue();
        private readonly Label customerMessagesValue = CreateDashboardValue();
        private readonly DataGridView recentRequestsGrid = CreateRecentRequestsGrid();

        public frmAdminDashboard()
        {
            InitializeComponent();
            AddDashboardValues();
            pnlSubmit.Controls.Add(recentRequestsGrid);
            panel7.BringToFront();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnProviders_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnServices_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new frmReports());
        }

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new frmReports());
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new frmProviderManagement());
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshDashboard();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new RequestManagement());
        }

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want ot logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                frmHomeHeroHomepage homepage = new frmHomeHeroHomepage();
                this.Hide();
                homepage.Show();
            }
        }

        private void AddDashboardValues()
        {
            panel1.Controls.Add(totalRequestsValue);
            panel2.Controls.Add(registeredProvidersValue);
            panel3.Controls.Add(awaitingApprovalValue);
            panel4.Controls.Add(totalRevenueValue);
            panel8.Controls.Add(customerMessagesValue);

            foreach (Label value in new[]
                     {
                         totalRequestsValue,
                         registeredProvidersValue,
                         awaitingApprovalValue,
                         totalRevenueValue,
                         customerMessagesValue
                     })
            {
                value.Location = new Point(18, 78);
            }

            label7.Text = "Registered Providers";
            label2.Text = "On HomeHero";
            label5.Text = "Awaiting Approval";
            label4.Text = "Completed";
            label11.Text = "All time";
            label10.Text = "Customer Messages";
        }

        private void RefreshDashboard()
        {
            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<ServiceProvider> providers = CustomerRepository.LoadRegisteredServiceProviders();
            List<MessageRecord> messages = MessageRepository.LoadMessages();
            int total = requests.Count;
            int awaitingApproval = requests.Count(request => request.Status == RequestStatus.Requested);
            int assigned = requests.Count(request =>
                request.Status == RequestStatus.Approved ||
                request.Status == RequestStatus.ProviderAssigned);
            int scheduled = requests.Count(request => request.Status == RequestStatus.Scheduled);
            int inProgress = requests.Count(request => request.Status == RequestStatus.InProgress);
            List<MaintenanceRequest> completed = requests
                .Where(request => request.Status == RequestStatus.Completed)
                .ToList();
            int activeRequests = total - requests.Count(request => request.Status == RequestStatus.Cancelled);

            totalRequestsValue.Text = total.ToString(CultureInfo.InvariantCulture);
            awaitingApprovalValue.Text = awaitingApproval.ToString(CultureInfo.InvariantCulture);
            registeredProvidersValue.Text = providers.Count.ToString(CultureInfo.InvariantCulture);
            totalRevenueValue.Text = $"R{completed.Sum(request => request.FinalCost):N2}";
            customerMessagesValue.Text = messages.Count.ToString(CultureInfo.InvariantCulture);

            lblSubmitValue.Text = requests.Count(request => request.Status == RequestStatus.Requested).ToString();
            lblAssignedValue.Text = assigned.ToString();
            lblScheduledValue.Text = scheduled.ToString();
            lblProgressValue.Text = inProgress.ToString();
            lblCompletedValue.Text = completed.Count.ToString();

            UpdateBreakdownBars(activeRequests, awaitingApproval, assigned, scheduled, inProgress, completed.Count);
            BindRecentRequests(requests, providers);
        }

        private void UpdateBreakdownBars(
            int activeRequests,
            int submitted,
            int assigned,
            int scheduled,
            int inProgress,
            int completed)
        {
            int maxCount = Math.Max(1, new[] { submitted, assigned, scheduled, inProgress, completed }.Max());
            int barWidth = 250;
            panel10.Width = GetBarWidth(submitted, maxCount, barWidth);
            panel14.Width = GetBarWidth(assigned, maxCount, barWidth);
            panel12.Width = GetBarWidth(scheduled, maxCount, barWidth);
            panel13.Width = GetBarWidth(inProgress, maxCount, barWidth);
            panel11.Width = GetBarWidth(completed, maxCount, barWidth);
            lblBreakdown.Text = $"Active Request Status Breakdown ({activeRequests} active)";
        }

        private static int GetBarWidth(int count, int maxCount, int maxWidth)
        {
            return count == 0 ? 0 : Math.Max(4, (int)Math.Round(maxWidth * count / (double)maxCount));
        }

        private void BindRecentRequests(
            IEnumerable<MaintenanceRequest> requests,
            IEnumerable<ServiceProvider> providers)
        {
            Dictionary<string, string> providerNames = providers
                .GroupBy(provider => provider.Email, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(
                    group => group.Key,
                    group => $"{group.First().FirstName} {group.First().LastName}".Trim(),
                    StringComparer.OrdinalIgnoreCase);

            recentRequestsGrid.DataSource = requests
                .Reverse()
                .Take(10)
                .Select(request => new
                {
                    Request = request.RequestNumber,
                    Service = request.ServiceCategory,
                    Customer = request.CustomerId,
                    Status = request.Status.ToString(),
                    Provider = providerNames.TryGetValue(request.AssignedProviderId ?? string.Empty, out string? name)
                        ? name
                        : IsUnassigned(request)
                            ? "Unassigned"
                            : request.AssignedProviderId,
                    Cost = request.Status == RequestStatus.Completed
                        ? $"R{request.FinalCost:N2}"
                        : $"R{request.EstimatedCost:N2}"
                })
                .ToList();
        }

        private static bool IsUnassigned(MaintenanceRequest request)
        {
            return string.IsNullOrWhiteSpace(request.AssignedProviderId) ||
                   string.Equals(request.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase);
        }

        private void OpenAdminPage(Form page)
        {
            page.FormClosed += (_, _) =>
            {
                Show();
                RefreshDashboard();
            };
            Hide();
            page.Show();
        }

        private static Label CreateDashboardValue()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                Text = "0"
            };
        }

        private static DataGridView CreateRecentRequestsGrid()
        {
            return new DataGridView
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Location = new Point(12, 52),
                ReadOnly = true,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(869, 405),
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle =
                {
                    BackColor = Color.FromArgb(0, 0, 64),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                },
                AlternatingRowsDefaultCellStyle =
                {
                    BackColor = Color.FromArgb(245, 247, 251)
                }
            };
        }
    }
}
