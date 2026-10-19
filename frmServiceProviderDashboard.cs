using HomeHero_2;
using Krypton.Toolkit;

namespace Home_Hero
{
    public partial class frmServiceProviderDashboard : Form
    {
        private readonly ServiceProvider currentProvider;
        private readonly DataGridView availableRequestsGrid = CreateGrid();
        private readonly DataGridView assignedRequestsGrid = CreateGrid();
        private readonly DataGridView completedRequestsGrid = CreateGrid();
        private readonly Label summaryAvailable = CreateMetricValue();
        private readonly Label summaryAssigned = CreateMetricValue();
        private readonly Label summaryCompleted = CreateMetricValue();
        private readonly KryptonButton approveRequestButton = CreateActionButton("Accept request");
        private readonly KryptonButton scheduleRequestButton = CreateActionButton("Schedule");
        private readonly KryptonButton startRequestButton = CreateActionButton("Start work");
        private readonly KryptonButton completeRequestButton = CreateActionButton("Complete job");
        private readonly KryptonButton refreshButton = CreateActionButton("Refresh requests");
        private readonly NumericUpDown finalCostInput = new();
        private HomeHeroDashboardLayout? dashboardLayout;
        private MessageCenterForm? providerMessageCenter;
        private Panel? messagesContent;
        private Panel? requestsContent;
        private Panel? jobsContent;
        private Panel? completedContent;
        private Control? analyticsContent;
        private string currentSection = "Customer Requests";

        public frmServiceProviderDashboard(ServiceProvider provider)
        {
            currentProvider = provider;
            InitializeComponent();
            BuildProviderWorkspace();
            LoadRequests();
        }

        private void BuildProviderWorkspace()
        {
            Controls.Clear();
            Text = "HomeHero Provider Workspace";
            BackColor = HomeHeroTheme.Canvas;
            MinimumSize = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            dashboardLayout = new HomeHeroDashboardLayout();
            dashboardLayout.SetIdentity($"PROVIDER WORKSPACE  ·  {currentProvider.FirstName} {currentProvider.LastName}".Trim());
            dashboardLayout.SetHero(
                $"Welcome back, {currentProvider.FirstName}",
                "Grow your business by delivering excellent service and keeping every customer informed.");
            dashboardLayout.SetHeroImage(Properties.Resources.Home_Hero_background_image);
            dashboardLayout.SetNavigation(
                new[] { "Customer Requests", "My Jobs", "Completed Jobs", "Messages", "Analytics" },
                "Customer Requests");
            dashboardLayout.NavigationRequested += (_, section) => ShowProviderSection(section);
            KryptonButton logoutButton = CreateActionButton("Log out");
            logoutButton.Size = new Size(104, 34);
            logoutButton.StateCommon.Back.Color1 = Color.FromArgb(33, 43, 74);
            logoutButton.StateCommon.Back.Color2 = Color.FromArgb(33, 43, 74);
            logoutButton.Click += Logout_Click;
            dashboardLayout.HeaderPanel.Controls.Add(logoutButton);
            dashboardLayout.HeaderPanel.Resize += (_, _) => logoutButton.Location =
                new Point(dashboardLayout.HeaderPanel.ClientSize.Width - logoutButton.Width - 28, 15);

            requestsContent = CreateProviderTableContent("New customer requests", availableRequestsGrid);
            jobsContent = CreateProviderTableContent("My active jobs", assignedRequestsGrid);
            completedContent = CreateProviderTableContent("Completed jobs", completedRequestsGrid);
            analyticsContent = CreateOverviewPanel();
            messagesContent = new HomeHeroCard { Dock = DockStyle.Fill, Padding = new Padding(20) };
            AddMessageCenter(messagesContent);

            approveRequestButton.Size = new Size(180, 38);
            approveRequestButton.Enabled = false;
            approveRequestButton.Click += ApproveRequest_Click;
            refreshButton.Size = new Size(156, 38);
            refreshButton.StateCommon.Back.Color1 = HomeHeroTheme.Navy;
            refreshButton.StateCommon.Back.Color2 = HomeHeroTheme.Navy;
            refreshButton.Click += (_, _) => LoadRequests();
            AddTableActions(requestsContent, approveRequestButton, refreshButton);
            availableRequestsGrid.SelectionChanged += (_, _) =>
                approveRequestButton.Enabled = GetSelectedRequest(availableRequestsGrid) != null;
            availableRequestsGrid.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    ApproveRequest_Click(availableRequestsGrid, EventArgs.Empty);
                }
            };

            finalCostInput.DecimalPlaces = 2;
            finalCostInput.Maximum = 1000000;
            finalCostInput.Minimum = 0;
            finalCostInput.Size = new Size(150, 38);
            finalCostInput.Font = new Font("Segoe UI", 10F);
            foreach (KryptonButton button in new[]
                     {
                         scheduleRequestButton,
                         startRequestButton,
                         completeRequestButton
                     })
            {
                button.Size = new Size(140, 38);
            }

            scheduleRequestButton.Click += (_, _) => UpdateSelectedRequest(RequestStatus.Scheduled);
            startRequestButton.Click += (_, _) => UpdateSelectedRequest(RequestStatus.InProgress);
            completeRequestButton.Click += CompleteRequest_Click;
            AddTableActions(jobsContent, finalCostInput, scheduleRequestButton, startRequestButton, completeRequestButton);
            Controls.Add(dashboardLayout);
            UpdateProviderMetrics();
            ShowProviderSection("Customer Requests");
        }

        private void AddMessageCenter(Panel messagesPanel)
        {
            providerMessageCenter = new MessageCenterForm(
                currentProvider.Email,
                true,
                DataManager.LoadRequests(),
                $"{currentProvider.FirstName} {currentProvider.LastName}".Trim())
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            messagesPanel.Controls.Add(providerMessageCenter);
            providerMessageCenter.Show();
        }

        private void ShowProviderSection(string section)
        {
            if (dashboardLayout == null)
            {
                return;
            }

            dashboardLayout.SetNavigation(
                new[] { "Customer Requests", "My Jobs", "Completed Jobs", "Messages", "Analytics" },
                section);
            currentSection = section;
            Control content = section switch
            {
                "Customer Requests" => requestsContent!,
                "My Jobs" => jobsContent!,
                "Completed Jobs" => completedContent!,
                "Messages" => messagesContent!,
                _ => analyticsContent!
            };
            dashboardLayout.ShowContent(content);
        }

        private static Panel CreateProviderTableContent(string title, DataGridView grid)
        {
            HomeHeroDataGridCard card = new(title, grid);
            return card;
        }

        private static void AddTableActions(Panel content, params Control[] actions)
        {
            if (content is not HomeHeroDataGridCard card)
            {
                return;
            }

            foreach (Control action in actions)
            {
                card.AddActionControl(action);
            }
        }

        private void UpdateProviderMetrics()
        {
            if (dashboardLayout == null)
            {
                return;
            }

            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<MaintenanceRequest> mine = requests.Where(IsAssignedToCurrentProvider).ToList();
            int activeJobs = mine.Count(request =>
                request.Status != RequestStatus.Completed &&
                request.Status != RequestStatus.Cancelled);
            int completedJobs = mine.Count(request => request.Status == RequestStatus.Completed);
            DateTime monthStart = new(DateTime.Today.Year, DateTime.Today.Month, 1);
            decimal monthlyEarnings = mine
                .Where(request => request.Status == RequestStatus.Completed &&
                                  request.PreferredDate >= monthStart &&
                                  request.PreferredDate <= DateTime.Today)
                .Sum(request => request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost);

            dashboardLayout.SetMetrics(new[]
            {
                new DashboardMetric("New requests", summaryAvailable.Text, "Available to accept"),
                new DashboardMetric("Active jobs", activeJobs.ToString(), "Accepted and underway"),
                new DashboardMetric("Completed jobs", completedJobs.ToString(), "All-time completed"),
                new DashboardMetric("Monthly earnings", $"R{monthlyEarnings:N0}", "Completed this month"),
                new DashboardMetric("Services offered", (currentProvider.Specialisation?.Count ?? 0).ToString(), "Listed specialties"),
                new DashboardMetric("Upcoming jobs", mine.Count(request =>
                    request.Status == RequestStatus.Scheduled && request.PreferredDate.Date >= DateTime.Today).ToString(),
                    "Scheduled from today")
            });
        }

        private Control CreateOverviewPanel()
        {
            TableLayoutPanel overview = new()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(246, 248, 251),
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(0)
            };
            for (int column = 0; column < 2; column++)
            {
                overview.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }
            for (int row = 0; row < 4; row++)
            {
                overview.RowStyles.Add(new RowStyle(SizeType.Absolute, 190F));
            }

            overview.Controls.Add(CreateSchedulePanel(), 0, 0);
            overview.Controls.Add(CreateIncomingRequestsPanel(), 1, 0);
            overview.Controls.Add(CreateCurrentJobsPanel(), 0, 1);
            overview.Controls.Add(CreateUpcomingJobsPanel(), 1, 1);
            overview.Controls.Add(CreateRevenuePanel(), 0, 2);
            overview.Controls.Add(CreateRatingPanel(), 1, 2);
            overview.Controls.Add(CreateRecentMessagesPanel(), 0, 3);
            overview.Controls.Add(CreatePipelinePanel(), 1, 3);
            return overview;
        }

        private Control CreateIncomingRequestsPanel()
        {
            HomeHeroCard card = CreateProviderCard("Incoming requests");
            FlowLayoutPanel list = CreateCardList();
            List<MaintenanceRequest> incoming = DataManager.LoadRequests()
                .Where(request => (request.Status == RequestStatus.Requested ||
                                   request.Status == RequestStatus.Approved) &&
                                  IsUnassigned(request))
                .OrderBy(request => request.PreferredDate)
                .Take(3)
                .ToList();
            if (incoming.Count == 0)
            {
                list.Controls.Add(CreateEmptyState("No unassigned customer requests."));
            }
            else
            {
                foreach (MaintenanceRequest request in incoming)
                {
                    list.Controls.Add(CreateProviderDetail(
                        $"{request.ServiceCategory}  ·  {request.PreferredDate:d}",
                        $"{request.CustomerId}  ·  R{request.EstimatedCost:N0} estimate"));
                }
            }
            ((TableLayoutPanel)card.Tag!).Controls.Add(list, 0, 1);
            return card;
        }

        private Control CreateCurrentJobsPanel()
        {
            HomeHeroCard card = CreateProviderCard("Current jobs");
            FlowLayoutPanel list = CreateCardList();
            List<MaintenanceRequest> jobs = DataManager.LoadRequests()
                .Where(IsAssignedToCurrentProvider)
                .Where(request => request.Status != RequestStatus.Completed &&
                                  request.Status != RequestStatus.Cancelled)
                .OrderBy(request => request.PreferredDate)
                .Take(3)
                .ToList();
            if (jobs.Count == 0)
            {
                list.Controls.Add(CreateEmptyState("Accepted jobs will appear here."));
            }
            else
            {
                foreach (MaintenanceRequest job in jobs)
                {
                    list.Controls.Add(CreateProviderDetail(
                        $"{job.ServiceCategory}  ·  {job.Status}",
                        $"{job.PreferredDate:d}  ·  {job.CustomerId}"));
                }
            }
            ((TableLayoutPanel)card.Tag!).Controls.Add(list, 0, 1);
            return card;
        }

        private Control CreatePipelinePanel()
        {
            Panel card = CreateProviderCard("Job pipeline");
            TableLayoutPanel pipeline = new()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 8, 12, 6),
                ColumnCount = 2,
                RowCount = 2
            };
            pipeline.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pipeline.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pipeline.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pipeline.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            List<MaintenanceRequest> mine = DataManager.LoadRequests()
                .Where(IsAssignedToCurrentProvider)
                .ToList();
            pipeline.Controls.Add(CreatePipelineStage("Accepted", mine.Count(request => request.Status == RequestStatus.ProviderAssigned)), 0, 0);
            pipeline.Controls.Add(CreatePipelineStage("Scheduled", mine.Count(request => request.Status == RequestStatus.Scheduled)), 1, 0);
            pipeline.Controls.Add(CreatePipelineStage("In progress", mine.Count(request => request.Status == RequestStatus.InProgress)), 0, 1);
            pipeline.Controls.Add(CreatePipelineStage("Completed", mine.Count(request => request.Status == RequestStatus.Completed)), 1, 1);
            ((TableLayoutPanel)card.Tag!).Controls.Add(pipeline, 0, 1);
            return card;
        }

        private static Control CreatePipelineStage(string title, int count)
        {
            TableLayoutPanel stage = new()
            {
                BackColor = Color.FromArgb(246, 248, 251),
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = new Padding(4),
                RowCount = 1
            };
            stage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            stage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            stage.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(27, 27, 27),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            stage.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Orange,
                Text = count.ToString(),
                TextAlign = ContentAlignment.MiddleCenter
            }, 1, 0);
            return stage;
        }

        private Control CreateSchedulePanel()
        {
            HomeHeroCard card = CreateProviderCard("Today's schedule");
            FlowLayoutPanel schedule = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(14, 8, 14, 6),
                WrapContents = false
            };
            List<MaintenanceRequest> todaysJobs = DataManager.LoadRequests()
                .Where(IsAssignedToCurrentProvider)
                .Where(request => request.Status == RequestStatus.Scheduled &&
                                  request.PreferredDate.Date == DateTime.Today)
                .OrderBy(request => request.PreferredTime)
                .ToList();
            if (todaysJobs.Count == 0)
            {
                schedule.Controls.Add(new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Text = "No appointments scheduled for today."
                });
            }
            else
            {
                foreach (MaintenanceRequest job in todaysJobs)
                {
                    schedule.Controls.Add(new Label
                    {
                        AutoEllipsis = true,
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(27, 27, 27),
                        Margin = new Padding(0, 0, 0, 12),
                        Size = new Size(250, 50),
                        Text = $"{job.PreferredTime}  ·  {job.ServiceCategory}\n{job.CustomerId}"
                    });
                }
            }
            schedule.SizeChanged += (_, _) =>
            {
                foreach (Control item in schedule.Controls)
                {
                    item.Width = Math.Max(0, schedule.ClientSize.Width - schedule.Padding.Horizontal);
                }
            };
            ((TableLayoutPanel)card.Tag!).Controls.Add(schedule, 0, 1);
            return card;
        }

        private Control CreateUpcomingJobsPanel()
        {
            HomeHeroCard card = CreateProviderCard("Upcoming jobs");
            FlowLayoutPanel list = CreateCardList();
            List<MaintenanceRequest> upcoming = DataManager.LoadRequests()
                .Where(IsAssignedToCurrentProvider)
                .Where(request => request.Status == RequestStatus.Scheduled &&
                                  request.PreferredDate.Date > DateTime.Today)
                .OrderBy(request => request.PreferredDate)
                .Take(2)
                .ToList();
            if (upcoming.Count == 0)
            {
                list.Controls.Add(CreateEmptyState("No upcoming jobs are scheduled."));
            }
            else
            {
                foreach (MaintenanceRequest job in upcoming)
                {
                    list.Controls.Add(CreateProviderDetail(
                        $"{job.PreferredDate:ddd, d MMM}  ·  {job.PreferredTime}",
                        $"{job.ServiceCategory}  ·  {job.CustomerId}"));
                }
            }

            ((TableLayoutPanel)card.Tag!).Controls.Add(list, 0, 1);
            return card;
        }

        private Control CreateRevenuePanel()
        {
            HomeHeroCard card = CreateProviderCard("Revenue summary");
            List<MaintenanceRequest> completed = DataManager.LoadRequests()
                .Where(IsAssignedToCurrentProvider)
                .Where(request => request.Status == RequestStatus.Completed)
                .ToList();
            DateTime monthStart = new(DateTime.Today.Year, DateTime.Today.Month, 1);
            decimal monthly = completed
                .Where(request => request.PreferredDate.Date >= monthStart &&
                                  request.PreferredDate.Date <= DateTime.Today)
                .Sum(request => request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost);
            decimal total = completed.Sum(request =>
                request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost);
            FlowLayoutPanel list = CreateCardList();
            list.Controls.Add(CreateProviderDetail($"R{monthly:N2}", "Earned from completed jobs this month"));
            list.Controls.Add(CreateProviderDetail($"R{total:N2}", $"All-time · {completed.Count} completed jobs"));
            ((TableLayoutPanel)card.Tag!).Controls.Add(list, 0, 1);
            return card;
        }

        private Control CreateRatingPanel()
        {
            HomeHeroCard card = CreateProviderCard("Customer rating");
            FlowLayoutPanel list = CreateCardList();
            list.Controls.Add(CreateProviderDetail("Rating data not tracked", "Customer feedback can be surfaced here once collected."));
            ((TableLayoutPanel)card.Tag!).Controls.Add(list, 0, 1);
            return card;
        }

        private Control CreateRecentMessagesPanel()
        {
            HomeHeroCard card = CreateProviderCard("Recent messages");
            FlowLayoutPanel list = CreateCardList();
            List<MessageRecord> recent = MessageRepository.LoadMessages()
                .Where(message => string.Equals(message.ProviderEmail, currentProvider.Email, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(message => message.SentAt)
                .Take(2)
                .ToList();
            if (recent.Count == 0)
            {
                list.Controls.Add(CreateEmptyState("No customer messages yet."));
            }
            else
            {
                foreach (MessageRecord message in recent)
                {
                    string preview = message.Body.Length > 54 ? $"{message.Body[..51]}..." : message.Body;
                    list.Controls.Add(CreateProviderDetail(
                        $"{message.CustomerEmail}  ·  {message.SentAt:g}",
                        preview));
                }
            }

            ((TableLayoutPanel)card.Tag!).Controls.Add(list, 0, 1);
            return card;
        }

        private static FlowLayoutPanel CreateCardList()
        {
            FlowLayoutPanel list = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(14, 8, 14, 6),
                WrapContents = false
            };
            list.SizeChanged += (_, _) =>
            {
                foreach (Control item in list.Controls)
                {
                    item.Width = Math.Max(0, list.ClientSize.Width - list.Padding.Horizontal);
                }
            };
            return list;
        }

        private static Control CreateProviderDetail(string heading, string detail)
        {
            TableLayoutPanel item = new()
            {
                ColumnCount = 1,
                Margin = new Padding(0, 0, 0, 6),
                RowCount = 2,
                Dock = DockStyle.Top,
                Height = 54
            };
            item.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            item.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            item.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            item.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Text = heading,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            item.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(90, 99, 112),
                Text = detail,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 1);
            return item;
        }

        private static Control CreateEmptyState(string text)
        {
            return new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(90, 99, 112),
                Height = 48,
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private static HomeHeroCard CreateProviderCard(string title)
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
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            card.Controls.Add(layout);
            card.Tag = layout;
            return card;
        }

        private static Panel CreateMetricCard(string title, Label valueLabel)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(390, 100),
                Margin = new Padding(0, 0, 22, 0)
            };
            card.Controls.Add(new Label
            {
                Text = title,
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(18, 14)
            });
            valueLabel.Location = new Point(18, 42);
            card.Controls.Add(valueLabel);
            return card;
        }

        private static Label CreateMetricValue()
        {
            return new Label
            {
                Text = "0",
                ForeColor = HomeHeroTheme.Orange,
                Font = new Font("Segoe UI", 23F, FontStyle.Bold),
                AutoSize = true
            };
        }

        private static KryptonButton CreateActionButton(string text)
        {
            KryptonButton button = new()
            {
                Text = text
            };
            button.StateCommon.Back.Color1 = HomeHeroTheme.Orange;
            button.StateCommon.Back.Color2 = HomeHeroTheme.Orange;
            button.StateCommon.Content.ShortText.Color1 = Color.White;
            button.StateCommon.Border.Rounding = 8;
            return button;
        }

        private static DataGridView CreateGrid()
        {
            DataGridView grid = new()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 42,
                ColumnHeadersDefaultCellStyle =
                {
                    BackColor = HomeHeroTheme.Navy,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                },
                AlternatingRowsDefaultCellStyle =
                {
                    BackColor = Color.FromArgb(246, 248, 251)
                }
            };
            return grid;
        }

        private static void AddGridTab(TabPage tab, DataGridView grid)
        {
            HomeHeroDataGridCard card = new(tab.Text, grid)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(20)
            };
            tab.Controls.Add(card);
        }

        private void LoadRequests()
        {
            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            List<MaintenanceRequest> available = requests
                .Where(request =>
                    (request.Status == RequestStatus.Requested || request.Status == RequestStatus.Approved) &&
                    IsUnassigned(request))
                .OrderBy(request => request.PreferredDate)
                .ToList();

            List<MaintenanceRequest> assigned = requests
                .Where(IsAssignedToCurrentProvider)
                .Where(request => request.Status != RequestStatus.Completed &&
                                  request.Status != RequestStatus.Cancelled)
                .OrderBy(request => request.PreferredDate)
                .ToList();

            List<MaintenanceRequest> completed = requests
                .Where(IsAssignedToCurrentProvider)
                .Where(request => request.Status == RequestStatus.Completed)
                .OrderByDescending(request => request.PreferredDate)
                .ToList();

            BindRequestsGrid(availableRequestsGrid, available);
            BindRequestsGrid(assignedRequestsGrid, assigned);
            BindRequestsGrid(completedRequestsGrid, completed);
            (requestsContent as HomeHeroDataGridCard)?.ApplyCurrentSearch();
            (jobsContent as HomeHeroDataGridCard)?.ApplyCurrentSearch();
            (completedContent as HomeHeroDataGridCard)?.ApplyCurrentSearch();
            summaryAvailable.Text = available.Count.ToString();
            summaryAssigned.Text = assigned.Count.ToString();
            summaryCompleted.Text = completed.Count.ToString();
            providerMessageCenter?.RefreshRequests(requests);
            UpdateProviderMetrics();
            analyticsContent = CreateOverviewPanel();
            if (currentSection == "Analytics")
            {
                ShowProviderSection(currentSection);
            }
        }

        private void BindRequestsGrid(DataGridView grid, List<MaintenanceRequest> requests)
        {
            grid.DataSource = null;
            grid.DataSource = requests;
            if (grid.Columns["RequestNumber"] != null)
                grid.Columns["RequestNumber"].HeaderText = "Request";
            if (grid.Columns["CustomerId"] != null)
                grid.Columns["CustomerId"].HeaderText = "Customer";
            if (grid.Columns["ServiceCategory"] != null)
                grid.Columns["ServiceCategory"].HeaderText = "Service";
            if (grid.Columns["ProblemDescription"] != null)
                grid.Columns["ProblemDescription"].HeaderText = "Customer notes";
            if (grid.Columns["PropertyAddress"] != null)
                grid.Columns["PropertyAddress"].HeaderText = "Service address";
            if (grid.Columns["PreferredDate"] != null)
                grid.Columns["PreferredDate"].HeaderText = "Preferred date";
            if (grid.Columns["PreferredTime"] != null)
                grid.Columns["PreferredTime"].HeaderText = "Preferred time";
            if (grid.Columns["EstimatedCost"] != null)
                grid.Columns["EstimatedCost"].HeaderText = "Estimate";
            if (grid.Columns["FinalCost"] != null)
                grid.Columns["FinalCost"].HeaderText = "Final cost";
            if (grid.Columns["AssignedProviderId"] != null)
                grid.Columns["AssignedProviderId"].Visible = false;
            if (grid.Columns["ServiceRequest"] != null)
                grid.Columns["ServiceRequest"].Visible = false;
            if (grid.Columns["ProgressPercentage"] != null)
            {
                grid.Columns["ProgressPercentage"].HeaderText = "Progress";
                grid.Columns["ProgressPercentage"].DefaultCellStyle.Format = "0'%'";
            }
        }

        private static bool IsUnassigned(MaintenanceRequest request)
        {
            return string.IsNullOrWhiteSpace(request.AssignedProviderId) ||
                   string.Equals(request.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsAssignedToCurrentProvider(MaintenanceRequest request)
        {
            string providerName = $"{currentProvider.FirstName} {currentProvider.LastName}".Trim();
            return string.Equals(request.AssignedProviderId, currentProvider.Email, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(request.AssignedProviderId, providerName, StringComparison.OrdinalIgnoreCase);
        }

        private MaintenanceRequest? GetSelectedRequest(DataGridView grid)
        {
            return grid.CurrentRow?.DataBoundItem as MaintenanceRequest;
        }

        private void ApproveRequest_Click(object? sender, EventArgs e)
        {
            if (sender is DataGridView grid && grid.CurrentRow != null)
            {
                grid.CurrentRow.Selected = true;
            }

            MaintenanceRequest? selected = GetSelectedRequest(availableRequestsGrid);
            if (selected == null)
            {
                ShowSelectRequestMessage();
                return;
            }

            UpdateRequest(selected, request =>
            {
                if (request.Status != RequestStatus.Requested &&
                    request.Status != RequestStatus.Approved)
                {
                    return $"This request cannot be accepted because its current status is {request.Status}.";
                }

                if (!IsUnassigned(request))
                {
                    return "This request has already been assigned to another provider.";
                }

                if (request.Status == RequestStatus.Requested &&
                    !request.TryUpdateStatus(RequestStatus.Approved, out string approvalError))
                {
                    return approvalError;
                }

                if (!request.TryUpdateStatus(RequestStatus.ProviderAssigned, out string assignmentError))
                {
                    return assignmentError;
                }

                request.AssignedProviderId = currentProvider.Email;
                return string.Empty;
            }, "Request approved and added to your jobs.");
        }

        private void UpdateSelectedRequest(RequestStatus status)
        {
            MaintenanceRequest? selected = GetSelectedRequest(assignedRequestsGrid);
            if (selected == null)
            {
                ShowSelectRequestMessage();
                return;
            }

            UpdateRequest(selected, request =>
                request.TryUpdateStatus(status, out string error) ? string.Empty : error,
                $"Request updated to {status}.");
        }

        private void CompleteRequest_Click(object? sender, EventArgs e)
        {
            MaintenanceRequest? selected = GetSelectedRequest(assignedRequestsGrid);
            if (selected == null)
            {
                ShowSelectRequestMessage();
                return;
            }

            UpdateRequest(selected, request =>
            {
                if (!request.TryUpdateStatus(RequestStatus.Completed, out string error))
                {
                    return error;
                }

                request.FinalCost = finalCostInput.Value > 0
                    ? finalCostInput.Value
                    : request.EstimatedCost;
                return string.Empty;
            }, "Job marked complete and final cost recorded.");
        }

        private void UpdateRequest(
            MaintenanceRequest selected,
            Func<MaintenanceRequest, string> update,
            string successMessage)
        {
            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            MaintenanceRequest? storedRequest = requests.FirstOrDefault(request =>
                request.RequestNumber == selected.RequestNumber);
            if (storedRequest == null ||
                (!IsUnassigned(storedRequest) && !IsAssignedToCurrentProvider(storedRequest)))
            {
                MessageBox.Show(
                    "This request is no longer available to your account. Refresh the dashboard.",
                    "Request Changed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                LoadRequests();
                return;
            }

            string error = update(storedRequest);
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error, "Request Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadRequests();
                return;
            }

            if (!DataManager.SaveRequests(requests))
            {
                LoadRequests();
                return;
            }

            LoadRequests();
            MessageBox.Show(successMessage, "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowSelectRequestMessage()
        {
            MessageBox.Show(
                "Select a request first.",
                "No Request Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void Logout_Click(object? sender, EventArgs e)
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
