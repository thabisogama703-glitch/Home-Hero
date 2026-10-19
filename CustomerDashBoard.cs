using Home_Hero;
using HomeHero_2;
using Krypton.Toolkit;

namespace HomeHero
{
    public partial class frmCustomerDashboard : Form
    {
        private readonly string currentCustomerEmail;
        private readonly Label totalRequestsValue = CreateMetricValue();
        private readonly Label activeRequestsValue = CreateMetricValue();
        private readonly Label inProgressValue = CreateMetricValue();
        private readonly Label completedValue = CreateMetricValue();
        private readonly Label progressSummary = new();
        private readonly ProgressBar completionProgress = new();
        private readonly DataGridView requestsGrid = CreateRequestsGrid();
        private readonly ComboBox statusFilter = new();
        private readonly Label emptyRequestsLabel = new();
        private List<MaintenanceRequest> customerRequests = new();
        private HomeHeroDashboardLayout? dashboardLayout;
        private string activeSection = "Overview";
        private Panel? messagesContent;

        public frmCustomerDashboard()
            : this(string.Empty)
        {
        }

        public frmCustomerDashboard(string customerEmail)
        {
            InitializeComponent();
            currentCustomerEmail = customerEmail;
            BuildCustomerWorkspace();
            RefreshDashboard();
            Activated += (_, _) => RefreshDashboard();
        }

        private void BuildCustomerWorkspace()
        {
            Controls.Clear();
            Text = "HomeHero | Customer dashboard";
            BackColor = Color.FromArgb(246, 248, 252);
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;
            dashboardLayout = new HomeHeroDashboardLayout();
            dashboardLayout.SetIdentity("CUSTOMER DASHBOARD");
            dashboardLayout.SetHero(
                "Your Home, Expertly Managed",
                "Track requests, communicate with providers, and keep your home in perfect condition.");
            dashboardLayout.SetNavigation(
                new[] { "Overview", "Request Service", "Active Services", "Track Service", "Service History", "Messages" },
                "Overview");
            dashboardLayout.NavigationRequested += (_, section) => ShowCustomerSection(section);
            KryptonButton logoutButton = CreateActionButton("Log out", Color.FromArgb(33, 43, 74));
            logoutButton.Size = new Size(106, 34);
            logoutButton.Click += btnBackToHome_Click;
            dashboardLayout.HeaderPanel.Controls.Add(logoutButton);
            dashboardLayout.HeaderPanel.Resize += (_, _) => logoutButton.Location =
                new Point(dashboardLayout.HeaderPanel.ClientSize.Width - logoutButton.Width - 28, 15);
            Controls.Add(dashboardLayout);
            UpdateCustomerMetrics();
            ShowCustomerSection("Overview");
        }

        private Control CreateHeroBanner()
        {
            Panel banner = new()
            {
                BackColor = Color.FromArgb(0, 0, 64),
                BackgroundImage = Home_Hero.Properties.Resources.Home_Hero_background_image,
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
                Text = "Your home, well cared for.",
                AutoSize = true,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(26, 28)
            });
            banner.Controls.Add(new Label
            {
                Text = "Manage your home services and follow every request from submission to completion.",
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.White,
                Location = new Point(30, 82)
            });
            KryptonButton requestButton = CreateActionButton("Request a service", Color.FromArgb(255, 128, 0));
            requestButton.Size = new Size(190, 42);
            requestButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            requestButton.Location = new Point(0, 82);
            requestButton.Click += btnNewServiceRequest_Click_1;
            banner.Controls.Add(requestButton);
            banner.Resize += (_, _) =>
                requestButton.Location = new Point(banner.ClientSize.Width - requestButton.Width - 26, 78);
            return banner;
        }

        private Control CreateMetricsPanel()
        {
            TableLayoutPanel metrics = new()
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            for (int column = 0; column < 4; column++)
            {
                metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            metrics.Controls.Add(CreateMetricCard("Total requests", totalRequestsValue), 0, 0);
            metrics.Controls.Add(CreateMetricCard("Active requests", activeRequestsValue), 1, 0);
            metrics.Controls.Add(CreateMetricCard("In progress", inProgressValue), 2, 0);
            metrics.Controls.Add(CreateMetricCard("Completed", completedValue), 3, 0);
            return metrics;
        }

        private Control CreateProgressPanel()
        {
            Panel panel = CreateWhitePanel();
            panel.Padding = new Padding(18, 12, 18, 12);
            progressSummary.AutoSize = true;
            progressSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressSummary.ForeColor = Color.FromArgb(0, 0, 64);
            progressSummary.Dock = DockStyle.Top;
            completionProgress.Dock = DockStyle.Bottom;
            completionProgress.Height = 22;
            completionProgress.Minimum = 0;
            completionProgress.Maximum = 100;
            panel.Controls.Add(completionProgress);
            panel.Controls.Add(progressSummary);
            return panel;
        }

        private Control CreateRequestToolbar()
        {
            Panel toolbar = new() { Dock = DockStyle.Fill };
            toolbar.Controls.Add(new Label
            {
                Text = "Your recent requests",
                AutoSize = true,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                Location = new Point(0, 10)
            });
            statusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            statusFilter.Items.AddRange(new object[] { "All requests", "Active", "Completed", "Cancelled" });
            statusFilter.SelectedIndex = 0;
            statusFilter.Size = new Size(175, 32);
            statusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusFilter.SelectedIndexChanged += (_, _) => BindRequestsGrid();
            toolbar.Controls.Add(statusFilter);
            toolbar.Resize += (_, _) => statusFilter.Location =
                new Point(toolbar.ClientSize.Width - statusFilter.Width, 4);
            return toolbar;
        }

        private Control CreateRequestListPanel()
        {
            Panel panel = CreateWhitePanel();
            requestsGrid.Dock = DockStyle.Fill;
            emptyRequestsLabel.Dock = DockStyle.Fill;
            emptyRequestsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            emptyRequestsLabel.ForeColor = Color.DimGray;
            emptyRequestsLabel.TextAlign = ContentAlignment.MiddleCenter;
            requestsGrid.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    btnTrackRequest_Click_1(this, EventArgs.Empty);
                }
            };
            panel.Controls.Add(requestsGrid);
            panel.Controls.Add(emptyRequestsLabel);
            return panel;
        }

        private static Panel CreateMetricCard(string title, Label value)
        {
            Panel card = CreateWhitePanel();
            card.Margin = new Padding(0, 0, 14, 0);
            card.Controls.Add(new Label
            {
                Text = title,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(16, 13)
            });
            value.Location = new Point(16, 42);
            card.Controls.Add(value);
            return card;
        }

        private static Panel CreateWhitePanel()
        {
            return new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 14, 0)
            };
        }

        private static Label CreateMetricValue()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 23F, FontStyle.Bold),
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
            button.Size = new Size(170, 40);
            button.StateCommon.Back.Color1 = color;
            button.StateCommon.Back.Color2 = color;
            button.StateCommon.Content.ShortText.Color1 = Color.White;
            button.StateCommon.Border.Rounding = 8;
            return button;
        }

        private static DataGridView CreateRequestsGrid()
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

        private void btnNewServiceRequest_Click_1(object? sender, EventArgs e)
        {
            using frmCreateRequest requestForm = new(currentCustomerEmail);
            requestForm.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnTrackRequest_Click_1(object? sender, EventArgs e)
        {
            using frmRequestTracking requestTracking = new(currentCustomerEmail);
            requestTracking.ShowDialog(this);
            RefreshDashboard();
        }

        private void BtnActiceRequests_Click(object? sender, EventArgs e)
        {
            using frmActiveRequest activeRequest = new(GetCustomerRequests());
            activeRequest.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnServiceHistory_Click(object? sender, EventArgs e)
        {
            using ServiceHistoryForm serviceHistory = new(GetCustomerRequests());
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

        private void ShowCustomerSection(string section)
        {
            if (dashboardLayout == null)
            {
                return;
            }

            activeSection = section;
            dashboardLayout.SetNavigation(
                new[] { "Overview", "Request Service", "Active Services", "Track Service", "Service History", "Messages" },
                section);
            Control content = section switch
            {
                "Request Service" => CreateRequestServiceContent(),
                "Active Services" => CreateRequestsPage("Active services", customerRequests.Where(request =>
                    request.Status != RequestStatus.Completed && request.Status != RequestStatus.Cancelled).ToList(),
                    "Active work assigned to you will appear here."),
                "Track Service" => CreateTrackServiceContent(),
                "Service History" => CreateRequestsPage("Service history", customerRequests.Where(request =>
                    request.Status == RequestStatus.Completed || request.Status == RequestStatus.Cancelled).ToList(),
                    "Completed and cancelled requests will appear here."),
                "Messages" => GetMessagesContent(),
                _ => CreateCustomerOverview()
            };
            dashboardLayout.ShowContent(content);
        }

        private Control CreateCustomerOverview()
        {
            TableLayoutPanel overview = new()
            {
                AutoScroll = true,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            string name = currentCustomerEmail.Contains('@')
                ? currentCustomerEmail[..currentCustomerEmail.IndexOf('@')]
                : currentCustomerEmail;
            overview.Controls.Add(CreateSectionHeading($"Welcome back, {name}"), 0, 0);
            overview.Controls.Add(CreateProgressPanel(), 0, 1);
            overview.Controls.Add(CreateQuickActions(), 0, 2);
            overview.Controls.Add(CreateRequestListPanel(), 0, 3);
            return overview;
        }

        private Control CreateQuickActions()
        {
            FlowLayoutPanel actions = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 8, 0, 4)
            };
            actions.Controls.Add(CreateQuickActionButton("+ Request service", Color.FromArgb(255, 138, 0), btnNewServiceRequest_Click_1));
            actions.Controls.Add(CreateQuickActionButton("Track request", Color.FromArgb(2, 2, 89), btnTrackRequest_Click_1));
            actions.Controls.Add(CreateQuickActionButton("Contact provider", Color.FromArgb(2, 2, 89), (_, _) => ShowCustomerSection("Messages")));
            actions.Controls.Add(CreateQuickActionButton("Service history", Color.FromArgb(2, 2, 89), (_, _) => ShowCustomerSection("Service History")));
            return actions;
        }

        private static Button CreateQuickActionButton(string text, Color color, EventHandler onClick)
        {
            Button button = new()
            {
                BackColor = color,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Margin = new Padding(0, 0, 10, 0),
                Size = new Size(170, 36),
                Text = text,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += onClick;
            return button;
        }

        private Control CreateRequestServiceContent()
        {
            TableLayoutPanel layout = new()
            {
                AutoScroll = true,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(CreateSectionHeading("Choose a home service"), 0, 0);
            Button startRequest = CreateQuickActionButton("Start service request", Color.FromArgb(255, 138, 0), btnNewServiceRequest_Click_1);
            layout.Controls.Add(startRequest, 0, 1);
            FlowLayoutPanel services = new()
            {
                AutoScroll = false,
                Dock = DockStyle.Fill,
                WrapContents = true,
                Padding = new Padding(0, 8, 0, 8)
            };
            foreach (HomeServiceOption service in HomeServiceCatalog.Services)
            {
                Panel card = new()
                {
                    BackColor = Color.White,
                    Margin = new Padding(0, 0, 12, 12),
                    Padding = new Padding(14),
                    Size = new Size(240, 94)
                };
                card.Controls.Add(new Label
                {
                    AutoEllipsis = true,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(2, 2, 89),
                    Height = 25,
                    Text = service.Name
                });
                card.Controls.Add(new Label
                {
                    AutoEllipsis = true,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Text = $"{service.Description}\nFrom R{service.StartingPrice:N0}"
                });
                services.Controls.Add(card);
            }
            layout.Controls.Add(services, 0, 2);
            return layout;
        }

        private Control CreateTrackServiceContent()
        {
            Panel page = new() { Dock = DockStyle.Fill, BackColor = Color.FromArgb(246, 248, 251) };
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(CreateSectionHeading("Track a service request"), 0, 0);
            layout.Controls.Add(CreateQuickActionButton("Open request tracking", Color.FromArgb(255, 138, 0), btnTrackRequest_Click_1), 0, 1);
            layout.Controls.Add(CreateRequestsGridCard(customerRequests, "Select a request to review its status and provider."), 0, 2);
            page.Controls.Add(layout);
            return page;
        }

        private Control CreateRequestsPage(string title, List<MaintenanceRequest> requests, string emptyMessage)
        {
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(CreateSectionHeading(title), 0, 0);
            layout.Controls.Add(CreateRequestsGridCard(requests, emptyMessage), 0, 1);
            return layout;
        }

        private Control CreateRequestsGridCard(List<MaintenanceRequest> requests, string emptyMessage)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            DataGridView grid = CreateRequestsGrid();
            HomeHeroDashboardLayout.StyleTable(grid);
            List<MaintenanceRequest> snapshot = requests.ToList();
            grid.DataSource = snapshot.Select(request => new
            {
                Request = request.RequestNumber,
                Service = request.ServiceCategory,
                Appointment = $"{request.PreferredDate:d} · {request.PreferredTime}",
                Status = request.Status.ToString(),
                Progress = $"{request.ProgressPercentage}%",
                Provider = IsUnassigned(request) ? "Awaiting provider" : request.AssignedProviderId
            }).ToList();
            if (snapshot.Count == 0)
            {
                card.Controls.Add(new Label
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Text = emptyMessage,
                    TextAlign = ContentAlignment.MiddleCenter
                });
            }
            else
            {
                card.Controls.Add(grid);
            }

            return card;
        }

        private Control GetMessagesContent()
        {
            if (messagesContent == null)
            {
                messagesContent = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(10) };
                MessageCenterForm messageCenter = new(currentCustomerEmail, false, GetCustomerRequests())
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                messagesContent.Controls.Add(messageCenter);
                messageCenter.Show();
            }
            else if (messagesContent.Controls.Count > 0 && messagesContent.Controls[0] is MessageCenterForm messageCenter)
            {
                messageCenter.RefreshRequests(GetCustomerRequests());
            }

            return messagesContent;
        }

        private static Label CreateSectionHeading(string text) => new()
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            ForeColor = Color.FromArgb(2, 2, 89),
            Text = text,
            TextAlign = ContentAlignment.MiddleLeft
        };

        private void UpdateCustomerMetrics()
        {
            if (dashboardLayout == null)
            {
                return;
            }

            int activeCount = customerRequests.Count(request =>
                request.Status != RequestStatus.Completed && request.Status != RequestStatus.Cancelled);
            int inProgressCount = customerRequests.Count(request => request.Status == RequestStatus.InProgress);
            int completedCount = customerRequests.Count(request => request.Status == RequestStatus.Completed);
            dashboardLayout.SetMetrics(new[]
            {
                new DashboardMetric("Total requests", customerRequests.Count.ToString(), "All requests"),
                new DashboardMetric("Active services", activeCount.ToString(), "Currently open"),
                new DashboardMetric("In progress", inProgressCount.ToString(), "Work underway"),
                new DashboardMetric("Completed", completedCount.ToString(), "Finished services")
            });
        }

        private void RefreshDashboard()
        {
            customerRequests = GetCustomerRequests();
            int activeCount = customerRequests.Count(request =>
                request.Status != RequestStatus.Completed &&
                request.Status != RequestStatus.Cancelled);
            int inProgressCount = customerRequests.Count(request => request.Status == RequestStatus.InProgress);
            int completedCount = customerRequests.Count(request => request.Status == RequestStatus.Completed);
            int averageProgress = customerRequests.Count == 0
                ? 0
                : (int)Math.Round(customerRequests.Average(request => request.ProgressPercentage));

            totalRequestsValue.Text = customerRequests.Count.ToString();
            activeRequestsValue.Text = activeCount.ToString();
            inProgressValue.Text = inProgressCount.ToString();
            completedValue.Text = completedCount.ToString();
            completionProgress.Value = Math.Clamp(averageProgress, 0, 100);
            progressSummary.Text = $"Average request progress  ·  {averageProgress}%";
            UpdateCustomerMetrics();
            BindRequestsGrid();
            if (activeSection == "Overview")
            {
                ShowCustomerSection("Overview");
            }
        }

        private void BindRequestsGrid()
        {
            IEnumerable<MaintenanceRequest> filteredRequests = customerRequests;
            if (statusFilter.SelectedItem?.ToString() == "Active")
            {
                filteredRequests = filteredRequests.Where(request =>
                    request.Status != RequestStatus.Completed && request.Status != RequestStatus.Cancelled);
            }
            else if (statusFilter.SelectedItem?.ToString() == "Completed")
            {
                filteredRequests = filteredRequests.Where(request => request.Status == RequestStatus.Completed);
            }
            else if (statusFilter.SelectedItem?.ToString() == "Cancelled")
            {
                filteredRequests = filteredRequests.Where(request => request.Status == RequestStatus.Cancelled);
            }

            List<MaintenanceRequest> visibleRequests = filteredRequests.ToList();
            requestsGrid.DataSource = visibleRequests
                .Select(request => new
                {
                    Request = request.RequestNumber,
                    Service = request.ServiceCategory,
                    Appointment = $"{request.PreferredDate:d} · {request.PreferredTime}",
                    Status = request.Status.ToString(),
                    Progress = $"{request.ProgressPercentage}%",
                    StartingEstimate = $"R{request.EstimatedCost:N2}",
                    Provider = IsUnassigned(request) ? "Awaiting provider" : request.AssignedProviderId
                })
                .ToList();
            requestsGrid.Visible = visibleRequests.Count > 0;
            emptyRequestsLabel.Visible = visibleRequests.Count == 0;
            emptyRequestsLabel.Text = customerRequests.Count == 0
                ? "No service requests yet. Start by booking your first home maintenance service."
                : "No requests match this filter.";
        }

        private static bool IsUnassigned(MaintenanceRequest request)
        {
            return string.IsNullOrWhiteSpace(request.AssignedProviderId) ||
                   string.Equals(request.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase);
        }

        private void OpenMessages()
        {
            using MessageCenterForm messageCenter = new(currentCustomerEmail, false, GetCustomerRequests());
            messageCenter.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnBackToHome_Click(object? sender, EventArgs e)
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
    }
}
