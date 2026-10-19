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
        private readonly Label requestBreakdown = new();
        private FlowLayoutPanel? serviceCardsPanel;
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
            BackColor = Color.FromArgb(246, 248, 252);
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;

            sharedLayout = new HomeHeroDashboardLayout();
            sharedLayout.SetIdentity("ADMINISTRATOR PORTAL");
            sharedLayout.SetHero(
                "HomeHero Operations Center",
                "Manage providers, service requests, service information, and platform performance.");
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
                BackColor = Color.FromArgb(0, 0, 64),
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
                ForeColor = Color.FromArgb(0, 0, 64),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private Control CreateServicePanel()
        {
            Panel panel = CreateWhitePanel();
            panel.Padding = new Padding(12);
            TableLayoutPanel content = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.DimGray,
                Text = "Prices are starting estimates; the final quote may vary after a service assessment.",
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            serviceCardsPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                WrapContents = true
            };
            content.Controls.Add(serviceCardsPanel, 0, 1);
            panel.Controls.Add(content);
            return panel;
        }

        private Control CreateRecentRequestsPanel()
        {
            Panel panel = CreateWhitePanel();
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(16),
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

        private static Panel CreateWhitePanel()
        {
            return new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 12, 12)
            };
        }

        private static Label CreateMetricValue()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 128, 0),
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
                LinkColor = Color.FromArgb(0, 0, 64),
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
                    BackColor = Color.FromArgb(0, 0, 64),
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
                    sharedLayout.ShowContent(CreateServicePanel());
                    break;
                default:
                    sharedLayout.ShowContent(CreateOverviewContent());
                    break;
            }
        }

        private void OnAdminWorkspaceDataChanged(object? sender, EventArgs e) => UpdateAdminMetrics();

        private Control CreateOverviewContent()
        {
            TableLayoutPanel overview = new()
            {
                AutoScroll = true,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 330F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 280F));
            overview.Controls.Add(CreateSectionHeading("Home maintenance services and starting prices"), 0, 0);
            serviceSummarySection = CreateServicePanel();
            overview.Controls.Add(serviceSummarySection, 0, 1);
            overview.Controls.Add(CreateSectionHeading("Recent service requests"), 0, 2);
            overview.Controls.Add(CreateRecentRequestsPanel(), 0, 3);
            dashboardContent = overview;
            return overview;
        }

        private void BindServiceSummary(IEnumerable<MaintenanceRequest> requests)
        {
            if (serviceCardsPanel == null)
            {
                return;
            }

            serviceCardsPanel.SuspendLayout();
            foreach (Control existingCard in serviceCardsPanel.Controls.Cast<Control>().ToArray())
            {
                existingCard.Dispose();
            }
            serviceCardsPanel.Controls.Clear();
            foreach (HomeServiceOption service in HomeServiceCatalog.Services)
            {
                int count = requests.Count(request => string.Equals(
                    HomeServiceCatalog.NormalizeCategory(request.ServiceCategory),
                    service.Name,
                    StringComparison.OrdinalIgnoreCase));
                serviceCardsPanel.Controls.Add(CreateServiceCard(service, count));
            }
            serviceCardsPanel.ResumeLayout();
        }

        private static Control CreateServiceCard(HomeServiceOption service, int requestCount)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(6),
                Size = new Size(310, 128)
            };
            card.Controls.Add(new Panel
            {
                BackColor = Color.FromArgb(255, 128, 0),
                Dock = DockStyle.Left,
                Width = 5
            });
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                Location = new Point(18, 12),
                Size = new Size(276, 24),
                Text = service.Name
            });
            card.Controls.Add(new Label
            {
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.DimGray,
                Location = new Point(18, 39),
                Size = new Size(276, 42),
                Text = service.Description
            });
            card.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 128, 0),
                Location = new Point(18, 91),
                Text = $"From R{service.StartingPrice:N0}"
            });
            card.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.DimGray,
                Location = new Point(205, 94),
                Text = $"{requestCount} requests"
            });
            return card;
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
