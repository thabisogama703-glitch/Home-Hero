using HomeHero_2;
using System.Globalization;

namespace Home_Hero
{
    public partial class frmReports : Form
    {
        private readonly DataGridView serviceSummaryGrid = CreateSummaryGrid();
        private readonly ComboBox reportStatusFilter = new();
        private HomeHeroDashboardLayout? dashboardLayout;
        private Control? workspaceContent;
        private HomeHeroDataGridCard? activityTableCard;
        private HomeHeroDataGridCard? serviceTableCard;

        public event EventHandler? WorkspaceDataChanged;

        public frmReports()
        {
            InitializeComponent();
            BuildReportsWorkspace();
            ConfigureServiceSummary();
            RefreshReport();
            Activated += (_, _) => RefreshReport();
        }

        private void BuildReportsWorkspace()
        {
            Controls.Clear();
            Text = "HomeHero | Platform reports";
            BackColor = Color.FromArgb(246, 248, 251);
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;

            dashboardLayout = new HomeHeroDashboardLayout();
            dashboardLayout.SetIdentity("ADMINISTRATOR PORTAL");
            dashboardLayout.SetHero("Platform performance reports", "Review completed work, revenue, request activity, and service demand.");
            dashboardLayout.SetHeroImage(Properties.Resources.Application_pic);
            dashboardLayout.SetNavigation(
                new[] { "Overview", "Requests", "Providers", "Services", "Reports" },
                "Reports");
            dashboardLayout.NavigationRequested += (_, section) => NavigateAdmin(section);

            Button logout = new()
            {
                BackColor = Color.FromArgb(33, 43, 74),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(106, 34),
                Text = "Log out",
                UseVisualStyleBackColor = false
            };
            logout.FlatAppearance.BorderSize = 0;
            logout.Click += btnExitAdmin_Click;
            dashboardLayout.HeaderPanel.Controls.Add(logout);
            dashboardLayout.HeaderPanel.Resize += (_, _) => logout.Location =
                new Point(dashboardLayout.HeaderPanel.ClientSize.Width - logout.Width - 28, 15);

            reportStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            reportStatusFilter.Items.AddRange(new object[]
            {
                "All statuses", "Requested", "Approved", "ProviderAssigned", "InProgress", "Completed", "Cancelled"
            });
            reportStatusFilter.SelectedIndex = 0;
            reportStatusFilter.Width = 180;
            reportStatusFilter.SelectedIndexChanged += (_, _) => ApplyReportFilters();

            TabControl reportTabs = new()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            TabPage activityTab = new("Request activity") { BackColor = Color.FromArgb(246, 248, 251), Padding = new Padding(4) };
            TabPage servicesTab = new("Service summary") { BackColor = Color.FromArgb(246, 248, 251), Padding = new Padding(4) };
            dgvReports.Dock = DockStyle.Fill;
            serviceSummaryGrid.Dock = DockStyle.Fill;
            HomeHeroDataGridCard activityCard = new("Request activity", dgvReports);
            activityTableCard = activityCard;
            activityCard.AddToolbarControl(reportStatusFilter);
            HomeHeroDataGridCard servicesCard = new("Service performance", serviceSummaryGrid);
            serviceTableCard = servicesCard;
            reportStatusFilter.SelectedIndexChanged += (_, _) => ApplyReportFilters();
            activityTab.Controls.Add(activityCard);
            servicesTab.Controls.Add(servicesCard);
            reportTabs.TabPages.Add(activityTab);
            reportTabs.TabPages.Add(servicesTab);

            Panel content = new() { Dock = DockStyle.Fill, Padding = new Padding(8) };
            content.Controls.Add(reportTabs);
            workspaceContent = content;
            dashboardLayout.ShowContent(content);
            Controls.Add(dashboardLayout);
        }

        public Control DetachWorkspaceContent()
        {
            if (workspaceContent?.Parent is Control parent)
            {
                parent.Controls.Remove(workspaceContent);
            }

            return workspaceContent ?? new Panel { BackColor = Color.FromArgb(246, 248, 251), Dock = DockStyle.Fill };
        }

        public void DisposeWorkspace()
        {
            workspaceContent?.Dispose();
            workspaceContent = null;
            Dispose();
        }

        public void RefreshWorkspace() => RefreshReport();

        private void ConfigureServiceSummary()
        {
            lnklblReports.LinkClicked += (_, _) => RefreshReport();
            dgvReports.AutoGenerateColumns = true;
            dgvReports.Columns.Clear();
            dgvReports.ReadOnly = true;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.RowHeadersVisible = false;
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
            dashboardLayout?.SetMetrics(new[]
            {
                new DashboardMetric("Total revenue", $"R{totalRevenue:N2}", "Completed work, all time"),
                new DashboardMetric("Completed jobs", completed.Count.ToString(CultureInfo.InvariantCulture), "All-time completed"),
                new DashboardMetric("Average job value", completed.Count == 0 ? "R0.00" : $"R{completed.Average(GetRecordedCost):N2}", "Based on completed work"),
                new DashboardMetric("Customer satisfaction", "N/A", "Ratings are not currently tracked")
            });

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
            activityTableCard?.ApplyCurrentSearch();
            serviceTableCard?.ApplyCurrentSearch();
            ApplyReportFilters();
            WorkspaceDataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ApplyReportFilters()
        {
            string status = reportStatusFilter.SelectedItem?.ToString() ?? "All statuses";
            if (dgvReports.CurrentCell != null)
            {
                dgvReports.CurrentCell = null;
            }

            foreach (DataGridViewRow row in dgvReports.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                row.Visible = status == "All statuses" ||
                              string.Equals(row.Cells["Status"]?.Value?.ToString(), status, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void NavigateAdmin(string section)
        {
            switch (section)
            {
                case "Overview":
                    Close();
                    break;
                case "Requests":
                    OpenAdminPage(new RequestManagement());
                    break;
                case "Providers":
                    OpenAdminPage(new frmProviderManagement());
                    break;
                case "Services":
                    OpenAdminPage(new frmAdminDashboard());
                    break;
                default:
                    dashboardLayout?.SetNavigation(
                        new[] { "Overview", "Requests", "Providers", "Services", "Reports" },
                        "Reports");
                    RefreshReport();
                    break;
            }
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
