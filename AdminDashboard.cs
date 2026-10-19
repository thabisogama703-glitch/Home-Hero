using HomeHero_2;
using Krypton.Toolkit;
using System.Globalization;

namespace Home_Hero
{
    public partial class frmAdminDashboard : Form
    {
        private readonly Label totalRequestsValue = CreateMetricValue();
        private readonly Label awaitingApprovalValue = CreateMetricValue();
        private readonly Label registeredProvidersValue = CreateMetricValue();
        private readonly Label completedJobsValue = CreateMetricValue();
        private readonly DataGridView recentRequestsGrid = CreateGrid();
        private readonly DataGridView serviceSummaryGrid = CreateGrid();
        private readonly Label requestBreakdown = new();
        private Control? serviceSummarySection;
        private TableLayoutPanel? dashboardContent;
        private HomeHeroDashboardLayout? sharedLayout;
        private RequestManagement? requestManagement;
        private frmProviderManagement? providerManagement;
        private frmReports? reportsPage;
        private string activeSection = "Overview";

        public frmAdminDashboard()
        {
            InitializeComponent();
            BuildAdminWorkspace();
            RefreshDashboard();
            Activated += (_, _) => RefreshDashboard();
        }

        private void BuildAdminWorkspace()
        {
            Controls.Clear();
            Text = "HomeHero | Administrator dashboard";
            BackColor = HomeHeroTheme.Canvas;
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;

            sharedLayout = new HomeHeroDashboardLayout();
            sharedLayout.SetIdentity("ADMINISTRATOR PORTAL");
            sharedLayout.SetHero(
                "HomeHero Operations Center",
                "Manage providers, service requests, service information, and platform performance.");
            sharedLayout.SetHeroImage(Properties.Resources.Application_pic);
            sharedLayout.SetNavigation(
                new[] { "Overview", "Requests", "Providers", "Services", "Reports" },
                "Overview");
            sharedLayout.NavigationRequested += (_, section) => ShowAdminSection(section);
            KryptonButton logoutButton = CreateActionButton("Log out", Color.FromArgb(33, 43, 74));
            logoutButton.Size = new Size(106, 34);
            logoutButton.Click += btnExitAdmin_Click;
            sharedLayout.HeaderPanel.Controls.Add(logoutButton);
            sharedLayout.HeaderPanel.Resize += (_, _) => logoutButton.Location =
                new Point(sharedLayout.HeaderPanel.ClientSize.Width - logoutButton.Width - 28, 15);
            Controls.Add(sharedLayout);
            FormClosed += (_, _) =>
            {
                requestManagement?.DisposeWorkspace();
                providerManagement?.DisposeWorkspace();
                reportsPage?.DisposeWorkspace();
            };
            UpdateAdminMetrics();
            ShowAdminSection("Overview");
        }

        private Control CreateHeroBanner()
        {
            Panel banner = new()
            {
                BackColor = HomeHeroTheme.Navy,
                BackgroundImage = Properties.Resources.Home_Hero_background_image,
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 14),
                Padding = new Padding(26)
            };
            banner.Paint += (_, e) =>
            {
                using SolidBrush overlay = new(Color.FromArgb(185, 0, 0, 64));
                e.Graphics.FillRectangle(overlay, banner.ClientRectangle);
            };
            banner.Controls.Add(new Label
            {
                Text = "Administrator overview",
                AutoSize = true,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(26, 28)
            });
            banner.Controls.Add(new Label
            {
                Text = "Manage trusted home services, keep requests moving, and support your provider network.",
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.White,
                Location = new Point(30, 82)
            });
            return banner;
        }

        private Control CreateMetricsPanel()
        {
            TableLayoutPanel metrics = new()
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                RowCount = 1
            };
            for (int column = 0; column < 4; column++)
            {
                metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            metrics.Controls.Add(CreateMetricCard("Total requests", totalRequestsValue), 0, 0);
            metrics.Controls.Add(CreateMetricCard("Awaiting approval", awaitingApprovalValue), 1, 0);
            metrics.Controls.Add(CreateMetricCard("Registered providers", registeredProvidersValue), 2, 0);
            metrics.Controls.Add(CreateMetricCard("Completed jobs", completedJobsValue), 3, 0);
            return metrics;
        }

        private Control CreateSectionHeading(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private Control CreateServicePanel()
        {
            HomeHeroDataGridCard card = new("Service category performance", serviceSummaryGrid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };
            card.SetEmptyState(
                "No service categories are available.",
                "Refresh summary",
                (_, _) => BindServiceSummary(DataManager.LoadRequests()));
            serviceSummarySection = card;
            return card;
        }

        private Control CreateRecentRequestsPanel()
        {
            Panel panel = CreateWhitePanel();
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            requestBreakdown.Dock = DockStyle.Fill;
            requestBreakdown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            requestBreakdown.ForeColor = Color.DimGray;
            requestBreakdown.TextAlign = ContentAlignment.MiddleLeft;
            recentRequestsGrid.Dock = DockStyle.Fill;
            layout.Controls.Add(requestBreakdown, 0, 0);
            layout.Controls.Add(recentRequestsGrid, 0, 1);
            panel.Controls.Add(layout);
            return panel;
        }

        private static Panel CreateMetricCard(string title, Label value)
        {
            Panel panel = CreateWhitePanel();
            panel.Margin = new Padding(0, 0, 14, 0);
            panel.Controls.Add(new Label
            {
                Text = title,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(16, 14)
            });
            value.Location = new Point(16, 44);
            panel.Controls.Add(value);
            return panel;
        }

        private static HomeHeroCard CreateWhitePanel()
        {
            return new HomeHeroCard
            {
                Dock = DockStyle.Fill
            };
        }

        private static Label CreateMetricValue()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Orange,
                Text = "0"
            };
        }

        private static LinkLabel CreateNavLink(string text, EventHandler onClick)
        {
            LinkLabel link = new()
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                LinkBehavior = LinkBehavior.NeverUnderline,
                LinkColor = HomeHeroTheme.Navy,
                Margin = new Padding(0, 5, 28, 0),
                Text = text
            };
            link.Click += onClick;
            return link;
        }

        private static KryptonButton CreateActionButton(string text, Color color)
        {
            KryptonButton button = new() { Text = text };
            button.StateCommon.Back.Color1 = color;
            button.StateCommon.Back.Color2 = color;
            button.StateCommon.Content.ShortText.Color1 = Color.White;
            button.StateCommon.Border.Rounding = 8;
            return button;
        }

        private static DataGridView CreateGrid()
        {
            return new DataGridView
            {
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersDefaultCellStyle =
                {
                    BackColor = HomeHeroTheme.Navy,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                },
                AlternatingRowsDefaultCellStyle =
                {
                    BackColor = Color.FromArgb(246, 248, 252)
                }
            };
        }

        private void RefreshDashboard()
        {
            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<ServiceProvider> providers = CustomerRepository.LoadRegisteredServiceProviders();
            int awaiting = requests.Count(request => request.Status == RequestStatus.Requested);
            int completed = requests.Count(request => request.Status == RequestStatus.Completed);

            totalRequestsValue.Text = requests.Count.ToString(CultureInfo.InvariantCulture);
            awaitingApprovalValue.Text = awaiting.ToString(CultureInfo.InvariantCulture);
            registeredProvidersValue.Text = providers.Count.ToString(CultureInfo.InvariantCulture);
            completedJobsValue.Text = completed.ToString(CultureInfo.InvariantCulture);
            requestBreakdown.Text =
                $"Recent requests  ·  {requests.Count(request => request.Status != RequestStatus.Completed && request.Status != RequestStatus.Cancelled)} active  ·  {completed} completed";
            UpdateAdminMetrics();

            BindServiceSummary(requests);
            BindRecentRequests(requests, providers);
            if (activeSection == "Overview")
            {
                ShowAdminSection("Overview");
            }
        }

        private void UpdateAdminMetrics()
        {
            if (sharedLayout == null)
            {
                return;
            }

            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<ServiceProvider> providers = CustomerRepository.LoadRegisteredServiceProviders();
            sharedLayout.SetMetrics(new[]
            {
                new DashboardMetric("Total requests", requests.Count.ToString(CultureInfo.InvariantCulture), "All submitted jobs"),
                new DashboardMetric("Awaiting approval", requests.Count(request => request.Status == RequestStatus.Requested).ToString(CultureInfo.InvariantCulture), "Need review"),
                new DashboardMetric("Verified providers", providers.Count.ToString(CultureInfo.InvariantCulture), "In provider directory"),
                new DashboardMetric("Completed jobs", requests.Count(request => request.Status == RequestStatus.Completed).ToString(CultureInfo.InvariantCulture), "All-time completions")
            });
        }

        private void ShowAdminSection(string section)
        {
            if (sharedLayout == null)
            {
                return;
            }

            activeSection = section;
            sharedLayout.SetNavigation(
                new[] { "Overview", "Requests", "Providers", "Services", "Reports" },
                section);
            switch (section)
            {
                case "Requests":
                    requestManagement ??= new RequestManagement();
                    requestManagement.WorkspaceDataChanged -= OnAdminWorkspaceDataChanged;
                    requestManagement.WorkspaceDataChanged += OnAdminWorkspaceDataChanged;
                    requestManagement.RefreshWorkspace();
                    sharedLayout.ShowContent(requestManagement.DetachWorkspaceContent());
                    return;
                case "Providers":
                    providerManagement ??= new frmProviderManagement();
                    providerManagement.WorkspaceDataChanged -= OnAdminWorkspaceDataChanged;
                    providerManagement.WorkspaceDataChanged += OnAdminWorkspaceDataChanged;
                    providerManagement.RefreshWorkspace();
                    sharedLayout.ShowContent(providerManagement.DetachWorkspaceContent());
                    return;
                case "Reports":
                    reportsPage ??= new frmReports();
                    reportsPage.WorkspaceDataChanged -= OnAdminWorkspaceDataChanged;
                    reportsPage.WorkspaceDataChanged += OnAdminWorkspaceDataChanged;
                    reportsPage.RefreshWorkspace();
                    sharedLayout.ShowContent(reportsPage.DetachWorkspaceContent());
                    return;
                case "Services":
                    Control services = CreateServicePanel();
                    BindServiceSummary(DataManager.LoadRequests());
                    sharedLayout.ShowContent(services);
                    break;
                default:
                    sharedLayout.ShowContent(CreateOverviewContent());
                    break;
            }
        }

        private void OnAdminWorkspaceDataChanged(object? sender, EventArgs e) => UpdateAdminMetrics();

        private Control CreateOverviewContent()
        {
            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<ServiceProvider> providers = CustomerRepository.LoadRegisteredServiceProviders();
            List<MaintenanceRequest> pending = requests
                .Where(request => request.Status == RequestStatus.Requested)
                .OrderBy(request => request.PreferredDate)
                .Take(4)
                .ToList();
            DateTime monthStart = new(DateTime.Today.Year, DateTime.Today.Month, 1);
            decimal revenueThisMonth = requests
                .Where(request => request.Status == RequestStatus.Completed &&
                                  request.PreferredDate.Date >= monthStart &&
                                  request.PreferredDate.Date <= DateTime.Today)
                .Sum(GetRecordedCost);
            decimal totalRevenue = requests
                .Where(request => request.Status == RequestStatus.Completed)
                .Sum(GetRecordedCost);
            int completed = requests.Count(request => request.Status == RequestStatus.Completed);
            int active = requests.Count(request =>
                request.Status != RequestStatus.Completed &&
                request.Status != RequestStatus.Cancelled);
            string categorySummary = string.Join(Environment.NewLine, requests
                .GroupBy(request => HomeServiceCatalog.NormalizeCategory(request.ServiceCategory))
                .OrderByDescending(group => group.Count())
                .Take(3)
                .Select(group => $"{group.Key}: {group.Count()} requests"));

            TableLayoutPanel cardGrid = new()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                Margin = new Padding(0)
            };
            cardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int row = 0; row < 4; row++)
            {
                cardGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }
            cardGrid.Controls.Add(CreateOperationalCard(
                "Provider analytics",
                $"{providers.Count} providers are registered.{Environment.NewLine}Verification and ratings are not tracked in the current data model.",
                "Manage providers",
                (_, _) => ShowAdminSection("Providers")), 0, 0);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Pending verifications",
                $"{providers.Count} provider profiles are registered. Verification status is not tracked yet.",
                "Manage providers",
                (_, _) => ShowAdminSection("Providers")), 1, 0);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Service demand trends",
                string.IsNullOrWhiteSpace(categorySummary)
                    ? "Category activity will appear after requests are submitted."
                    : categorySummary,
                "View services",
                (_, _) => ShowAdminSection("Services")), 0, 1);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Customer reports",
                $"{completed} completed jobs are available for reporting.{Environment.NewLine}Customer ratings are not currently collected.",
                "Open reports",
                (_, _) => ShowAdminSection("Reports")), 1, 1);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Platform health",
                pending.Count == 0
                    ? $"Request queue clear.{Environment.NewLine}{active} active jobs are being tracked."
                    : string.Join(Environment.NewLine, pending.Select(request =>
                        $"{request.ServiceCategory}  ·  {request.PreferredDate:d}  ·  {request.CustomerId}")),
                "Review request queue",
                (_, _) => ShowAdminSection("Requests")), 0, 2);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Revenue overview",
                $"This month: R{revenueThisMonth:N2}{Environment.NewLine}All-time completed revenue: R{totalRevenue:N2}",
                "Open reports",
                (_, _) => ShowAdminSection("Reports")), 1, 2);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Pending customer requests",
                pending.Count == 0
                    ? "The request queue is clear. New customer requests will appear here."
                    : string.Join(Environment.NewLine, pending.Select(request =>
                        $"{request.ServiceCategory}  ·  {request.PreferredDate:d}  ·  {request.CustomerId}")),
                "Review requests",
                (_, _) => ShowAdminSection("Requests")), 0, 3);
            cardGrid.Controls.Add(CreateOperationalCard(
                "Recent activity timeline",
                requests.Count == 0
                    ? "No platform activity yet. Submitted service requests will appear here."
                    : string.Join(Environment.NewLine, requests
                        .OrderByDescending(request => request.PreferredDate)
                        .Take(3)
                        .Select(request => $"{request.PreferredDate:d}  ·  {request.ServiceCategory}  ·  {request.Status}")),
                "Open reports",
                (_, _) => ShowAdminSection("Reports")), 1, 3);
            return cardGrid;
        }

        private static Control CreateOperationalCard(string title, string details, string actionText, EventHandler action)
        {
            HomeHeroCard card = new()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                Padding = new Padding(20)
            };
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(90, 99, 112),
                Text = details,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 1);
            Button button = new()
            {
                BackColor = HomeHeroTheme.Navy,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = actionText,
                Width = 180
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += action;
            layout.Controls.Add(button, 0, 2);
            card.Controls.Add(layout);
            return card;
        }

        private void BindServiceSummary(IEnumerable<MaintenanceRequest> requests)
        {
            List<MaintenanceRequest> requestList = requests.ToList();
            serviceSummaryGrid.DataSource = HomeServiceCatalog.Services
                .Select(service =>
                {
                    List<MaintenanceRequest> categoryRequests = requestList
                        .Where(request => string.Equals(
                            HomeServiceCatalog.NormalizeCategory(request.ServiceCategory),
                            HomeServiceCatalog.NormalizeCategory(service.Name),
                            StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    List<MaintenanceRequest> completed = categoryRequests
                        .Where(request => request.Status == RequestStatus.Completed)
                        .ToList();
                    return new
                    {
                        Service = service.Name,
                        Description = service.Description,
                        StartingEstimate = $"R{service.StartingPrice:N2}",
                        Requests = categoryRequests.Count,
                        Active = categoryRequests.Count(request =>
                            request.Status != RequestStatus.Completed &&
                            request.Status != RequestStatus.Cancelled),
                        Completed = completed.Count,
                        Revenue = $"R{completed.Sum(GetRecordedCost):N2}"
                    };
                })
                .OrderByDescending(service => service.Requests)
                .ThenBy(service => service.Service)
                .ToList();
            if (serviceSummarySection is HomeHeroDataGridCard card)
            {
                card.SetEmptyState(
                    "No service categories are available.",
                    "Refresh summary",
                    (_, _) => BindServiceSummary(DataManager.LoadRequests()));
                card.ApplyCurrentSearch();
            }
        }

        private void BindRecentRequests(
            IEnumerable<MaintenanceRequest> requests,
            IEnumerable<ServiceProvider> providers)
        {
            Dictionary<string, string> providerNames = providers
                .Where(provider => !string.IsNullOrWhiteSpace(provider.Email))
                .GroupBy(provider => provider.Email, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(
                    group => group.Key,
                    group => $"{group.First().FirstName} {group.First().LastName}".Trim(),
                    StringComparer.OrdinalIgnoreCase);

            recentRequestsGrid.DataSource = requests
                .OrderByDescending(request => request.PreferredDate)
                .Take(12)
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
                    StartingEstimate = $"R{request.EstimatedCost:N2}",
                    FinalCost = request.Status == RequestStatus.Completed ? $"R{GetRecordedCost(request):N2}" : "—"
                })
                .ToList();
        }

        private void FocusServiceSummary()
        {
            if (sharedLayout != null)
            {
                ShowAdminSection("Services");
            }
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

        private static decimal GetRecordedCost(MaintenanceRequest request)
        {
            return request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost;
        }

        private static bool IsUnassigned(MaintenanceRequest request)
        {
            return string.IsNullOrWhiteSpace(request.AssignedProviderId) ||
                   string.Equals(request.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase);
        }

        private void AdminDashboard_Load(object? sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void btnReports_Click(object? sender, EventArgs e) =>
            OpenAdminPage(new frmReports());

        private void btnProviders_Click(object? sender, EventArgs e) =>
            OpenAdminPage(new frmProviderManagement());

        private void btnServices_Click(object? sender, EventArgs e) =>
            FocusServiceSummary();

        private void lnklblReports_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
            OpenAdminPage(new frmReports());

        private void lnklblServices_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
            FocusServiceSummary();

        private void lnklblProviders_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
            OpenAdminPage(new frmProviderManagement());

        private void lnklblOverView_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
            RefreshDashboard();

        private void lnklblRequests_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
            OpenAdminPage(new RequestManagement());

        private void btnExitAdmin_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Log out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
                new frmHomeHeroHomepage().Show();
            }
        }

        private void panel7_Paint(object? sender, PaintEventArgs e) { }
        private void panel8_Paint(object? sender, PaintEventArgs e) { }
    }
}
