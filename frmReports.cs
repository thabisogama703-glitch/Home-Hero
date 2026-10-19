using HomeHero_2;
using System.Globalization;

namespace Home_Hero
{
    public partial class frmReports : Form
    {
        private readonly DataGridView serviceSummaryGrid = CreateSummaryGrid();
        private readonly TextBox reportSearch = new();
        private readonly ComboBox reportStatusFilter = new();
        private HomeHeroDashboardLayout? dashboardLayout;
        private Control? workspaceContent;

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

            reportSearch.Dock = DockStyle.Fill;
            reportSearch.Font = new Font("Segoe UI", 9.5F);
            reportSearch.PlaceholderText = "Search requests or providers";
            reportSearch.TextChanged += (_, _) => ApplyReportFilters();
            reportStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            reportStatusFilter.Items.AddRange(new object[]
            {
                "All statuses", "Requested", "Approved", "ProviderAssigned", "InProgress", "Completed", "Cancelled"
            });
            reportStatusFilter.SelectedIndex = 0;
            reportStatusFilter.Width = 180;
            reportStatusFilter.SelectedIndexChanged += (_, _) => ApplyReportFilters();

            TableLayoutPanel filters = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 5, 0, 8),
                RowCount = 1
            };
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195F));
            filters.Controls.Add(reportSearch, 0, 0);
            filters.Controls.Add(reportStatusFilter, 1, 0);

            TabControl reportTabs = new()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            TabPage activityTab = new("Request activity") { BackColor = Color.White, Padding = new Padding(8) };
            TabPage servicesTab = new("Service summary") { BackColor = Color.White, Padding = new Padding(8) };
            HomeHeroDashboardLayout.StyleTable(dgvReports);
            HomeHeroDashboardLayout.StyleTable(serviceSummaryGrid);
            dgvReports.Dock = DockStyle.Fill;
            serviceSummaryGrid.Dock = DockStyle.Fill;
            activityTab.Controls.Add(dgvReports);
            servicesTab.Controls.Add(serviceSummaryGrid);
            reportTabs.TabPages.Add(activityTab);
            reportTabs.TabPages.Add(servicesTab);

            TableLayoutPanel content = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                RowCount = 2
            };
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Controls.Add(filters, 0, 0);
            Panel card = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            card.Controls.Add(reportTabs);
            content.Controls.Add(card, 0, 1);
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
            ApplyReportFilters();
            WorkspaceDataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ApplyReportFilters()
        {
            string search = reportSearch.Text.Trim();
            string status = reportStatusFilter.SelectedItem?.ToString() ?? "All statuses";
            foreach (DataGridView grid in new[] { dgvReports, serviceSummaryGrid })
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    string rowText = string.Join(" ", row.Cells.Cast<DataGridViewCell>()
                        .Select(cell => cell.Value?.ToString() ?? string.Empty));
                    bool matchesSearch = string.IsNullOrWhiteSpace(search) ||
                                         rowText.Contains(search, StringComparison.OrdinalIgnoreCase);
                    bool matchesStatus = grid != dgvReports ||
                                         status == "All statuses" ||
                                         string.Equals(row.Cells["Status"]?.Value?.ToString(), status, StringComparison.OrdinalIgnoreCase);
                    row.Visible = matchesSearch && matchesStatus;
                }
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
