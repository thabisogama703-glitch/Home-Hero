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
        private List<MaintenanceRequest> customerRequests = new();
        private HomeHeroDashboardLayout? dashboardLayout;
        private string activeSection = "Overview";
        private Panel? messagesContent;
        private HomeHeroDataGridCard? requestsTableCard;

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
            BackColor = HomeHeroTheme.Canvas;
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;
            dashboardLayout = new HomeHeroDashboardLayout();
            dashboardLayout.SetHeaderHeights(89, 77);
            dashboardLayout.SetIdentity("CUSTOMER DASHBOARD");
            dashboardLayout.SetHero(
                "Your Home, Expertly Managed",
                "Track requests, communicate with providers, and keep your home in perfect condition.");
            dashboardLayout.SetHeroImage(Home_Hero.Properties.Resources.Home_Hero_background_image);
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
                BackColor = HomeHeroTheme.Navy,
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
            KryptonButton requestButton = CreateActionButton("Request a service", HomeHeroTheme.Orange);
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
            HomeHeroCard panel = new() { Padding = new Padding(20) };
            progressSummary.AutoSize = true;
            progressSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressSummary.ForeColor = HomeHeroTheme.Navy;
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
                ForeColor = HomeHeroTheme.Navy,
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
            requestsTableCard = new HomeHeroDataGridCard("Recent requests", requestsGrid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };
            requestsTableCard.AddToolbarControl(statusFilter);
            statusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            statusFilter.Items.Clear();
            statusFilter.Items.AddRange(new object[] { "All requests", "Active", "Completed", "Cancelled" });
            statusFilter.SelectedIndex = 0;
            statusFilter.Width = 170;
            statusFilter.SelectedIndexChanged += (_, _) => BindRequestsGrid();
            requestsGrid.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    btnTrackRequest_Click_1(this, EventArgs.Empty);
                }
            };
            return requestsTableCard;
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
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            overview.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            string name = currentCustomerEmail.Contains('@')
                ? currentCustomerEmail[..currentCustomerEmail.IndexOf('@')]
                : currentCustomerEmail;

            Label welcome = (Label)CreateSectionHeading($"Welcome back, {name}");
            welcome.Margin = new Padding(10, 0, 0, 0);
            overview.Controls.Add(welcome, 0, 0);
            Control quickActions = CreateQuickActions();
            quickActions.Margin = new Padding(0);
            overview.Controls.Add(quickActions, 1, 0);

            TableLayoutPanel leftColumn = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                RowCount = 3
            };
            leftColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
            leftColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            leftColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            leftColumn.Controls.Add(CreateRequestListPanel(), 0, 0);
            leftColumn.Controls.Add(CreateRequestGridCard(
                "Service history",
                customerRequests.Where(request =>
                    request.Status == RequestStatus.Completed || request.Status == RequestStatus.Cancelled).ToList(),
                "No completed or cancelled services yet."), 0, 1);
            leftColumn.Controls.Add(CreateOverviewInfoCard(
                "Activity feed",
                GetActivityItems(),
                "No request activity yet. Your service updates will appear here.",
                "Create a request",
                btnNewServiceRequest_Click_1), 0, 2);
            overview.Controls.Add(leftColumn, 0, 1);

            TableLayoutPanel rightColumn = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                RowCount = 3
            };
            rightColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            rightColumn.Controls.Add(CreateOverviewInfoCard(
                "Upcoming visits",
                GetAppointmentItems(true),
                "No upcoming visits. Schedule a service to see it here.",
                "Book a service",
                btnNewServiceRequest_Click_1), 0, 0);
            rightColumn.Controls.Add(CreateRequestGridCard(
                "Active services",
                customerRequests.Where(request =>
                    request.Status != RequestStatus.Completed && request.Status != RequestStatus.Cancelled).ToList(),
                "No active services. New and in-progress requests will appear here."), 0, 1);
            rightColumn.Controls.Add(CreateOverviewInfoCard(
                "Recent messages",
                GetRecentMessageItems(),
                "Messages from service providers will appear here.",
                "Open messages",
                (_, _) => ShowCustomerSection("Messages")), 0, 2);
            overview.Controls.Add(rightColumn, 1, 1);
            return overview;
        }

        private Control CreateRequestGridCard(
            string title,
            List<MaintenanceRequest> requests,
            string emptyMessage)
        {
            DataGridView grid = CreateRequestsGrid();
            grid.DataSource = requests.Select(request => new
            {
                Request = request.RequestNumber,
                Service = request.ServiceCategory,
                Date = request.PreferredDate.ToString("d"),
                Status = request.Status.ToString(),
                Cost = request.Status == RequestStatus.Completed
                    ? $"R{(request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost):N2}"
                    : $"R{request.EstimatedCost:N2}"
            }).ToList();

            HomeHeroDataGridCard card = new(title, grid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };
            card.SetEmptyState(
                emptyMessage,
                title == "Service history" ? "Request a service" : "View requests",
                title == "Service history"
                    ? (_, _) => btnNewServiceRequest_Click_1(this, EventArgs.Empty)
                    : (_, _) => ShowCustomerSection("Active Services"));
            return card;
        }

        private static HomeHeroCard CreateOverviewInfoCard(
            string title,
            IEnumerable<(string Heading, string Detail)> entries,
            string emptyMessage,
            string actionText,
            EventHandler action)
        {
            HomeHeroCard card = new() { Dock = DockStyle.Fill, Margin = new Padding(10) };
            List<(string Heading, string Detail)> items = entries.Take(3).ToList();
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            if (items.Count == 0)
            {
                TableLayoutPanel empty = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    RowCount = 2
                };
                empty.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                empty.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                empty.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                empty.Controls.Add(new Label
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = HomeHeroTheme.Muted,
                    Text = emptyMessage,
                    TextAlign = ContentAlignment.MiddleLeft
                }, 0, 0);
                Button button = new()
                {
                    BackColor = HomeHeroTheme.Navy,
                    Dock = DockStyle.Left,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Text = actionText,
                    Width = 165,
                    UseVisualStyleBackColor = false
                };
                button.FlatAppearance.BorderSize = 0;
                button.Click += action;
                empty.Controls.Add(button, 0, 1);
                layout.Controls.Add(empty, 0, 1);
            }
            else
            {
                FlowLayoutPanel list = new()
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    Padding = new Padding(2, 4, 2, 0),
                    WrapContents = false
                };
                foreach ((string heading, string detail) in items)
                {
                    TableLayoutPanel item = new()
                    {
                        ColumnCount = 1,
                        Height = 46,
                        Margin = new Padding(0, 0, 0, 4),
                        RowCount = 2
                    };
                    item.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                    item.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
                    item.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                    item.Controls.Add(new Label
                    {
                        AutoEllipsis = true,
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        ForeColor = HomeHeroTheme.Text,
                        Text = heading,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 0, 0);
                    item.Controls.Add(new Label
                    {
                        AutoEllipsis = true,
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 8.5F),
                        ForeColor = HomeHeroTheme.Muted,
                        Text = detail,
                        TextAlign = ContentAlignment.MiddleLeft
                    }, 0, 1);
                    list.Controls.Add(item);
                    item.Width = Math.Max(0, list.ClientSize.Width - 8);
                    list.SizeChanged += (_, _) => item.Width = Math.Max(0, list.ClientSize.Width - 8);
                }
                layout.Controls.Add(list, 0, 1);
            }
            card.Controls.Add(layout);
            return card;
        }

        private IEnumerable<(string Heading, string Detail)> GetAppointmentItems(bool upcomingOnly)
        {
            IEnumerable<MaintenanceRequest> appointments = customerRequests
                .Where(request => request.Status == RequestStatus.Scheduled)
                .Where(request => upcomingOnly
                    ? request.PreferredDate.Date > DateTime.Today
                    : request.PreferredDate.Date == DateTime.Today)
                .OrderBy(request => request.PreferredDate)
                .ThenBy(request => request.PreferredTime);

            return appointments.Select(request => (
                $"{request.PreferredDate:ddd, d MMM}  ·  {request.PreferredTime}",
                $"{request.ServiceCategory}  ·  {request.Status}"));
        }

        private IEnumerable<(string Heading, string Detail)> GetRecommendedServiceItems()
        {
            return HomeServiceCatalog.Services
                .Where(service => new[] { "Electrical", "Plumbing", "Painting" }
                    .Contains(service.Name, StringComparer.OrdinalIgnoreCase))
                .Select(service => (service.Name, $"Home maintenance from R{service.StartingPrice:N0}"));
        }

        private IEnumerable<(string Heading, string Detail)> GetRecentMessageItems()
        {
            return MessageRepository.LoadMessages()
                .Where(message => string.Equals(
                    message.CustomerEmail,
                    currentCustomerEmail,
                    StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(message => message.SentAt)
                .Take(3)
                .Select(message => (
                    $"{message.ProviderEmail}  ·  {message.SentAt:g}",
                    message.Body.Length > 72 ? $"{message.Body[..69]}..." : message.Body));
        }

        private IEnumerable<(string Heading, string Detail)> GetHistoryItems()
        {
            return customerRequests
                .Where(request => request.Status == RequestStatus.Completed)
                .OrderByDescending(request => request.PreferredDate)
                .Take(3)
                .Select(request => (
                    $"{request.ServiceCategory}  ·  {request.PreferredDate:d}",
                    $"Completed · R{(request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost):N2}"));
        }

        private IEnumerable<(string Heading, string Detail)> GetActivityItems()
        {
            return customerRequests
                .OrderByDescending(request => request.PreferredDate)
                .Take(3)
                .Select(request => (
                    $"{request.ServiceCategory} request {request.Status.ToString().ToLowerInvariant()}",
                    $"{request.RequestNumber}  ·  {request.PreferredDate:d}"));
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
            actions.Controls.Add(CreateQuickActionButton("+ Request service", HomeHeroTheme.Orange, btnNewServiceRequest_Click_1));
            actions.Controls.Add(CreateQuickActionButton("Track request", HomeHeroTheme.Navy, btnTrackRequest_Click_1));
            actions.Controls.Add(CreateQuickActionButton("Contact provider", HomeHeroTheme.Navy, (_, _) => ShowCustomerSection("Messages")));
            actions.Controls.Add(CreateQuickActionButton("Service history", HomeHeroTheme.Navy, (_, _) => ShowCustomerSection("Service History")));
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
                Margin = new Padding(0, 0, 8, 0),
                Size = new Size(180, 40),
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
                AutoScroll = false,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(CreateSectionHeading("Choose a home service"), 0, 0);
            Button startRequest = CreateQuickActionButton("Start service request", HomeHeroTheme.Orange, btnNewServiceRequest_Click_1);
            layout.Controls.Add(startRequest, 0, 1);
            FlowLayoutPanel services = new()
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                WrapContents = true,
                Padding = new Padding(0, 8, 0, 8)
            };
            string[] featuredServices = { "Electrical", "Plumbing", "Painting", "Deep Cleaning", "HVAC", "General Maintenance" };
            foreach (HomeServiceOption service in HomeServiceCatalog.Services.Where(service =>
                         featuredServices.Contains(service.Name, StringComparer.OrdinalIgnoreCase)))
            {
                HomeServiceOption featured = service.Name switch
                {
                    "Deep Cleaning" => service with { Name = "Cleaning" },
                    "General Maintenance" => service with { Name = "Repairs" },
                    _ => service
                };
                HomeHeroServiceCard card = new(featured)
                {
                    Margin = new Padding(10),
                    Height = 210
                };
                services.Controls.Add(card);
            }
            void ResizeCards()
            {
                int columns = services.ClientSize.Width >= 1000 ? 3 : services.ClientSize.Width >= 620 ? 2 : 1;
                int available = services.ClientSize.Width - services.Padding.Horizontal - 20 * columns;
                int width = Math.Max(230, available / columns);
                foreach (Control card in services.Controls)
                {
                    card.Width = width;
                }
            }
            services.SizeChanged += (_, _) => ResizeCards();
            ResizeCards();
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
            layout.Controls.Add(CreateQuickActionButton("Open request tracking", HomeHeroTheme.Orange, btnTrackRequest_Click_1), 0, 1);
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
            DataGridView grid = CreateRequestsGrid();
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
            HomeHeroDataGridCard card = new("Request details", grid)
            {
                Dock = DockStyle.Fill
            };
            card.SetEmptyState(
                emptyMessage,
                "Request a service",
                (_, _) => btnNewServiceRequest_Click_1(this, EventArgs.Empty));
            return card;
        }

        private Control GetMessagesContent()
        {
            if (messagesContent == null)
            {
                messagesContent = new HomeHeroCard { Dock = DockStyle.Fill, Padding = new Padding(20) };
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
            ForeColor = HomeHeroTheme.Navy,
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
            requestsTableCard?.SetEmptyState(
                customerRequests.Count == 0
                    ? "No service requests yet. Create your first request to get started."
                    : "No requests match the selected search or status filter.",
                customerRequests.Count == 0 ? "New request" : "Clear filters",
                customerRequests.Count == 0
                    ? (_, _) => btnNewServiceRequest_Click_1(this, EventArgs.Empty)
                    : (_, _) =>
                    {
                        statusFilter.SelectedIndex = 0;
                        requestsTableCard?.SearchBox.Clear();
                    });
            requestsTableCard?.ApplyCurrentSearch();
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
