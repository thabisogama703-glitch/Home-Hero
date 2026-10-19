using HomeHero_2;
using System.Globalization;

namespace Home_Hero
{
    public partial class frmReports : Form
    {
        private readonly DataGridView serviceSummaryGrid = CreateSummaryGrid();

        public frmReports()
        {
            InitializeComponent();
            ConfigureServiceSummary();
            RefreshReport();
            Activated += (_, _) => RefreshReport();
        }

        private void ConfigureServiceSummary()
        {
            pnlServices.Controls.Clear();
            serviceSummaryGrid.Dock = DockStyle.Fill;
            pnlServices.Controls.Add(serviceSummaryGrid);
            panel5.Dock = DockStyle.Top;
            panel5.BringToFront();
            pnlServices.Controls.Add(panel5);
            pnlServices.BringToFront();

            lnklblReports.LinkClicked += (_, _) => RefreshReport();
            dgvReports.AutoGenerateColumns = true;
            dgvReports.Columns.Clear();
            dgvReports.ReadOnly = true;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.RowHeadersVisible = false;
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void RefreshReport()
        {
            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<ServiceProvider> providers = CustomerRepository.LoadRegisteredServiceProviders();
            Dictionary<string, string> providerNames = providers
                .Where(provider => !string.IsNullOrWhiteSpace(provider.Email))
                .GroupBy(provider => provider.Email, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(
                    group => group.Key,
                    group => $"{group.First().FirstName} {group.First().LastName}".Trim(),
                    StringComparer.OrdinalIgnoreCase);
            List<MaintenanceRequest> completed = requests
                .Where(request => request.Status == RequestStatus.Completed)
                .ToList();
            DateTime monthStart = new(DateTime.Today.Year, DateTime.Today.Month, 1);
            List<MaintenanceRequest> completedThisMonth = completed
                .Where(request => request.PreferredDate.Date >= monthStart &&
                                  request.PreferredDate.Date <= DateTime.Today)
                .ToList();
            decimal totalRevenue = completed.Sum(GetRecordedCost);

            lblTotalRevenueVale.Text = $"R{totalRevenue:N2}";
            lblCompletedJobsValue.Text = completedThisMonth.Count.ToString(CultureInfo.InvariantCulture);
            lblAverageJoValueValue.Text = completed.Count == 0
                ? "R0.00"
                : $"R{completed.Average(GetRecordedCost):N2}";
            lblAvgJobRating.Text = "N/A";
            lblCustomerSatisfaction.Text = "Ratings not tracked";
            lblThisPeriod.Text = "Completed (scheduled this month)";
            lblAllCompletedJobs.Text = $"{completed.Count} completed total";
            lblPerCompletedJob.Text = "Average completed value";
            label10.Text = "Avg. Job Value";
            label5.Text = "Rating";
            label9.Text = "Total Revenue";
            lblRevenue.Text = "Service request activity";

            dgvReports.DataSource = requests
                .OrderByDescending(request => request.PreferredDate)
                .Select(request => new
                {
                    Request = request.RequestNumber,
                    Customer = request.CustomerId,
                    Status = request.Status.ToString(),
                    Provider = providerNames.TryGetValue(request.AssignedProviderId ?? string.Empty, out string? providerName)
                        ? providerName
                        : IsUnassigned(request)
                            ? "Unassigned"
                            : request.AssignedProviderId,
                    Service = request.ServiceCategory,
                    Cost = request.Status == RequestStatus.Completed
                        ? $"R{GetRecordedCost(request):N2}"
                        : $"R{request.EstimatedCost:N2}"
                })
                .ToList();

            BindServiceSummary(requests);
        }

        private void BindServiceSummary(IEnumerable<MaintenanceRequest> requests)
        {
            serviceSummaryGrid.DataSource = requests
                .GroupBy(request => string.IsNullOrWhiteSpace(request.ServiceCategory)
                    ? "Uncategorized"
                    : request.ServiceCategory.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(group => new
                {
                    Service = group.Key,
                    Requests = group.Count(),
                    Completed = group.Count(request => request.Status == RequestStatus.Completed),
                    Revenue = $"R{group.Where(request => request.Status == RequestStatus.Completed).Sum(GetRecordedCost):N2}"
                })
                .OrderByDescending(service => service.Requests)
                .ThenBy(service => service.Service)
                .ToList();
        }

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshReport();
        }

        private void OpenAdminPage(Form page)
        {
            page.FormClosed += (_, _) =>
            {
                Show();
                RefreshReport();
            };
            Hide();
            page.Show();
        }

        private static decimal GetRecordedCost(MaintenanceRequest request)
        {
            return request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost;
        }

        private static bool IsUnassigned(MaintenanceRequest request)
        {
            return string.IsNullOrWhiteSpace(request.AssignedProviderId) ||
                   string.Equals(request.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase);
        }

        private static DataGridView CreateSummaryGrid()
        {
            return new DataGridView
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
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

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want ot logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmHomeHeroHomepage homepage = new frmHomeHeroHomepage();
                this.Hide();
                homepage.Show();
            }
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new RequestManagement());
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new frmProviderManagement());
        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
