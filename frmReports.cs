using HomeHero_2;
using System.Globalization;

namespace Home_Hero
{
    public partial class frmReports : Form
    {
        private readonly DataGridView serviceSummaryGrid = CreateSummaryGrid();
        private readonly DataGridView revenueGrid = CreateSummaryGrid();
        private readonly DataGridView providerPerformanceGrid = CreateSummaryGrid();
        private readonly ComboBox reportStatusFilter = new();
        private HomeHeroDashboardLayout? dashboardLayout;
        private Control? workspaceContent;
        private HomeHeroDataGridCard? activityTableCard;
        private HomeHeroDataGridCard? serviceTableCard;
        private HomeHeroDataGridCard? revenueTableCard;
        private HomeHeroDataGridCard? providerTableCard;
        private Panel? revenueChart;
        private List<(string Service, decimal Revenue)> revenueChartData = new();
        private List<RequestStatusSummary> requestStatusSummaries = new();

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
                "All statuses", "Requested", "Approved", "ProviderAssigned", "Scheduled", "InProgress", "Completed", "Cancelled"
            });
            reportStatusFilter.SelectedIndex = 0;
            reportStatusFilter.Width = 180;
            reportStatusFilter.SelectedIndexChanged += (_, _) => ApplyReportFilters();

            TabControl reportTabs = new()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            TabPage overviewTab = CreateReportTab("Overview");
            TabPage revenueTab = CreateReportTab("Revenue report");
            TabPage activityTab = CreateReportTab("Request analytics");
            TabPage providersTab = CreateReportTab("Provider performance");

            dgvReports.Dock = DockStyle.Fill;
            serviceSummaryGrid.Dock = DockStyle.Fill;
            revenueGrid.Dock = DockStyle.Fill;
            providerPerformanceGrid.Dock = DockStyle.Fill;

            HomeHeroDataGridCard serviceCard = new("Top services summary", serviceSummaryGrid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8)
            };
            serviceTableCard = serviceCard;
            Control revenueChartCard = CreateRevenueChart();
            TableLayoutPanel overview = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(2),
                RowCount = 1
            };
            overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            overview.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            overview.Controls.Add(revenueChartCard, 0, 0);
            overview.Controls.Add(serviceCard, 1, 0);
            overviewTab.Controls.Add(overview);

            HomeHeroDataGridCard revenueCard = new("Revenue by month", revenueGrid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8)
            };
            revenueTableCard = revenueCard;
            revenueTab.Controls.Add(revenueCard);

            HomeHeroDataGridCard activityCard = new("Request analytics by status", dgvReports)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8)
            };
            activityTableCard = activityCard;
            activityCard.AddToolbarControl(reportStatusFilter);
            activityTab.Controls.Add(activityCard);

            HomeHeroDataGridCard providersCard = new("Provider performance", providerPerformanceGrid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8)
            };
            providerTableCard = providersCard;
            providersTab.Controls.Add(providersCard);

            reportTabs.TabPages.Add(overviewTab);
            reportTabs.TabPages.Add(revenueTab);
            reportTabs.TabPages.Add(activityTab);
            reportTabs.TabPages.Add(providersTab);

            Panel content = new() { Dock = DockStyle.Fill, Padding = new Padding(0) };
            content.Controls.Add(reportTabs);
            workspaceContent = content;
            dashboardLayout.ShowContent(content);
            Controls.Add(dashboardLayout);
        }

        private static TabPage CreateReportTab(string title) =>
            new(title)
            {
                BackColor = Color.FromArgb(246, 248, 251),
                Padding = new Padding(4)
            };

        private Control CreateRevenueChart()
        {
            HomeHeroCard chartCard = new()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                Padding = new Padding(20)
            };
            Panel chart = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill
            };
            chart.Paint += (_, e) => DrawRevenueChart(e.Graphics, chart.ClientRectangle);
            revenueChart = chart;
            chartCard.Controls.Add(chart);
            return chartCard;
        }

        private void DrawRevenueChart(Graphics graphics, Rectangle bounds)
        {
            graphics.Clear(Color.White);
            using Font titleFont = new("Segoe UI", 15F, FontStyle.Bold);
            using Font labelFont = new("Segoe UI", 9F);
            using Font valueFont = new("Segoe UI", 8F, FontStyle.Bold);
            using SolidBrush navy = new(HomeHeroTheme.Navy);
            using SolidBrush muted = new(HomeHeroTheme.Muted);
            using SolidBrush orange = new(HomeHeroTheme.Orange);
            graphics.DrawString("Revenue by service", titleFont, navy, 4, 4);

            List<(string Service, decimal Revenue)> items = revenueChartData.Take(6).ToList();
            if (items.Count == 0 || items.All(item => item.Revenue <= 0))
            {
                graphics.DrawString("No completed service revenue to chart yet.", labelFont, muted, 8, 58);
                return;
            }

            int chartTop = 54;
            int chartBottom = Math.Max(chartTop + 1, bounds.Height - 42);
            int labelWidth = Math.Min(108, Math.Max(76, bounds.Width / 4));
            int barLeft = labelWidth + 18;
            int barWidth = Math.Max(20, bounds.Width - barLeft - 76);
            decimal maxValue = items.Max(item => item.Revenue);
            int rowHeight = Math.Max(34, (chartBottom - chartTop) / items.Count);

            for (int index = 0; index < items.Count; index++)
            {
                (string service, decimal revenue) = items[index];
                int y = chartTop + index * rowHeight;
                graphics.DrawString(service, labelFont, muted, 4, y + 5);
                int width = maxValue <= 0
                    ? 0
                    : Math.Max(2, (int)(barWidth * revenue / maxValue));
                graphics.FillRectangle(orange, barLeft, y + 3, width, Math.Max(12, rowHeight - 10));
                graphics.DrawString($"R{revenue:N0}", valueFont, navy, barLeft + barWidth + 8, y + 4);
            }
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

            requestStatusSummaries = requests
                .GroupBy(request => request.Status)
                .OrderBy(group => group.Key)
                .Select(group => new RequestStatusSummary(
                    group.Key.ToString(),
                    group.Count(),
                    group.Count(request => request.Status == RequestStatus.Completed),
                    $"R{group.Average(request => request.EstimatedCost):N2}",
                    $"{group.Count(request => request.Status == RequestStatus.Completed) * 100D / group.Count():N0}%"))
                .ToList();
            revenueGrid.DataSource = completed
                .GroupBy(request => new DateTime(request.PreferredDate.Year, request.PreferredDate.Month, 1))
                .OrderByDescending(group => group.Key)
                .Select(group => new
                {
                    Month = group.Key.ToString("MMMM yyyy", CultureInfo.InvariantCulture),
                    CompletedJobs = group.Count(),
                    Revenue = $"R{group.Sum(GetRecordedCost):N2}",
                    AverageJobValue = $"R{group.Average(GetRecordedCost):N2}"
                })
                .ToList();
            providerPerformanceGrid.DataSource = providers
                .Where(provider => !string.IsNullOrWhiteSpace(provider.Email))
                .Select(provider =>
                {
                    List<MaintenanceRequest> providerRequests = requests
                        .Where(request => string.Equals(
                            request.AssignedProviderId,
                            provider.Email,
                            StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    List<MaintenanceRequest> providerCompleted = providerRequests
                        .Where(request => request.Status == RequestStatus.Completed)
                        .ToList();
                    int activeJobs = providerRequests.Count(request =>
                        request.Status != RequestStatus.Completed && request.Status != RequestStatus.Cancelled);
                    return new
                    {
                        Provider = $"{provider.FirstName} {provider.LastName}".Trim(),
                        Email = provider.Email,
                        AssignedRequests = providerRequests.Count,
                        ActiveJobs = activeJobs,
                        CompletedJobs = providerCompleted.Count,
                        Revenue = $"R{providerCompleted.Sum(GetRecordedCost):N2}",
                        CompletionRate = providerRequests.Count == 0
                            ? "N/A"
                            : $"{providerCompleted.Count * 100D / providerRequests.Count:N0}%"
                    };
                })
                .OrderByDescending(provider => provider.CompletedJobs)
                .ThenBy(provider => provider.Provider)
                .ToList();

            BindServiceSummary(requests);
            serviceTableCard?.SetEmptyState("Service demand will appear after the first request is submitted.", string.Empty, null);
            revenueTableCard?.SetEmptyState("No completed jobs are available for revenue reporting yet.", string.Empty, null);
            providerTableCard?.SetEmptyState("No service providers are registered yet.", string.Empty, null);
            ApplyReportFilters();
            activityTableCard?.ApplyCurrentSearch();
            serviceTableCard?.ApplyCurrentSearch();
            revenueTableCard?.ApplyCurrentSearch();
            providerTableCard?.ApplyCurrentSearch();
            WorkspaceDataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ApplyReportFilters()
        {
            string status = reportStatusFilter.SelectedItem?.ToString() ?? "All statuses";
            List<RequestStatusSummary> filtered = requestStatusSummaries
                .Where(summary => status == "All statuses" ||
                                  string.Equals(summary.Status, status, StringComparison.OrdinalIgnoreCase))
                .ToList();
            dgvReports.DataSource = filtered;
            activityTableCard?.SetEmptyState(
                requestStatusSummaries.Count == 0
                    ? "No service requests are available to analyze yet."
                    : "No requests match this status filter.",
                requestStatusSummaries.Count == 0 ? "Refresh report" : "Clear filters",
                requestStatusSummaries.Count == 0
                    ? (_, _) => RefreshReport()
                    : (_, _) =>
                    {
                        reportStatusFilter.SelectedIndex = 0;
                        activityTableCard?.SearchBox.Clear();
                    });
            activityTableCard?.ApplyCurrentSearch();
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
            List<MaintenanceRequest> requestList = requests.ToList();
            serviceSummaryGrid.DataSource = requestList
                .GroupBy(request => string.IsNullOrWhiteSpace(request.ServiceCategory)
                    ? "Uncategorized"
                    : request.ServiceCategory.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(group => new
                {
                    Service = group.Key,
                    Requests = group.Count(),
                    Completed = group.Count(request => request.Status == RequestStatus.Completed),
                    Active = group.Count(request => request.Status != RequestStatus.Completed &&
                                                    request.Status != RequestStatus.Cancelled),
                    Revenue = $"R{group.Where(request => request.Status == RequestStatus.Completed).Sum(GetRecordedCost):N2}"
                })
                .OrderByDescending(service => service.Requests)
                .ThenBy(service => service.Service)
                .ToList();
            revenueChartData = requestList
                .Where(request => request.Status == RequestStatus.Completed)
                .GroupBy(request => string.IsNullOrWhiteSpace(request.ServiceCategory)
                    ? "Uncategorized"
                    : request.ServiceCategory.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(group => (Service: group.Key, Revenue: group.Sum(GetRecordedCost)))
                .OrderByDescending(item => item.Revenue)
                .Take(6)
                .ToList();
            revenueChart?.Invalidate();
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

        private sealed record RequestStatusSummary(
            string Status,
            int Requests,
            int Completed,
            string AverageEstimate,
            string CompletionRate);

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
