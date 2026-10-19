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
            BackColor = Color.FromArgb(246, 248, 251);
            MinimumSize = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            dashboardLayout = new HomeHeroDashboardLayout();
            dashboardLayout.SetIdentity($"PROVIDER WORKSPACE  ·  {currentProvider.FirstName} {currentProvider.LastName}".Trim());
            dashboardLayout.SetHero(
                $"Welcome back, {currentProvider.FirstName}",
                "Grow your business by delivering excellent service and keeping every customer informed.");
            dashboardLayout.SetNavigation(
                new[] { "Customer Requests", "My Jobs", "Completed Jobs", "Messages", "Analytics" },
                "Customer Requests");
            dashboardLayout.NavigationRequested += (_, section) => ShowProviderSection(section);
            HomeHeroDashboardLayout.StyleTable(availableRequestsGrid);
            HomeHeroDashboardLayout.StyleTable(assignedRequestsGrid);
            HomeHeroDashboardLayout.StyleTable(completedRequestsGrid);
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
            messagesContent = new() { Dock = DockStyle.Fill, BackColor = Color.White };
            AddMessageCenter(messagesContent);

            approveRequestButton.Size = new Size(180, 38);
            approveRequestButton.Enabled = false;
            approveRequestButton.Click += ApproveRequest_Click;
            refreshButton.Size = new Size(156, 38);
            refreshButton.StateCommon.Back.Color1 = Color.FromArgb(0, 0, 64);
            refreshButton.StateCommon.Back.Color2 = Color.FromArgb(0, 0, 64);
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
            Panel content = new() { Dock = DockStyle.Fill, BackColor = Color.FromArgb(246, 248, 251) };
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(2, 2, 89),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            Panel tableCard = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            grid.Dock = DockStyle.Fill;
            tableCard.Controls.Add(grid);
            layout.Controls.Add(tableCard, 0, 1);
            FlowLayoutPanel actionBar = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 8, 0, 0),
                WrapContents = false,
                Tag = "action-bar"
            };
            layout.Controls.Add(actionBar, 0, 2);
            content.Controls.Add(layout);
            return content;
        }

        private static void AddTableActions(Panel content, params Control[] actions)
        {
            if (content.Controls.Count == 0 ||
                content.Controls[0] is not TableLayoutPanel layout ||
                layout.GetControlFromPosition(0, 2) is not FlowLayoutPanel actionBar)
            {
                return;
            }

            foreach (Control action in actions)
            {
                action.Margin = new Padding(0, 0, 10, 0);
                actionBar.Controls.Add(action);
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
            Panel overview = new()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(246, 248, 251)
            };
            TableLayoutPanel layout = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                RowCount = 1
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            layout.Controls.Add(CreatePipelinePanel(), 0, 0);
            layout.Controls.Add(CreateSchedulePanel(), 1, 0);
            overview.Controls.Add(layout);
            return overview;
        }

        private Control CreatePipelinePanel()
        {
            Panel card = CreateProviderCard("Job pipeline");
            FlowLayoutPanel pipeline = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(20, 18, 20, 10),
                WrapContents = false,
                AutoScroll = true
            };
            List<MaintenanceRequest> mine = DataManager.LoadRequests()
                .Where(IsAssignedToCurrentProvider)
                .ToList();
            AddPipelineRow(pipeline, "Accepted", mine.Count(request => request.Status == RequestStatus.ProviderAssigned));
            AddPipelineRow(pipeline, "Scheduled", mine.Count(request => request.Status == RequestStatus.Scheduled));
            AddPipelineRow(pipeline, "In progress", mine.Count(request => request.Status == RequestStatus.InProgress));
            AddPipelineRow(pipeline, "Completed", mine.Count(request => request.Status == RequestStatus.Completed));
            ((TableLayoutPanel)card.Tag!).Controls.Add(pipeline, 0, 1);
            return card;
        }

        private static void AddPipelineRow(FlowLayoutPanel panel, string title, int count)
        {
            Panel row = new()
            {
                BackColor = Color.FromArgb(246, 248, 251),
                Margin = new Padding(0, 0, 0, 10),
                Size = new Size(440, 58)
            };
            row.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(27, 27, 27),
                Location = new Point(14, 18),
                Text = title
            });
            row.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 138, 0),
                Location = new Point(370, 14),
                Text = count.ToString()
            });
            panel.Controls.Add(row);
        }

        private Control CreateSchedulePanel()
        {
            Panel card = CreateProviderCard("Today's schedule");
            FlowLayoutPanel schedule = new()
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(18, 18, 18, 10),
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
                        Size = new Size(330, 44),
                        Text = $"{job.PreferredTime}  ·  {job.ServiceCategory}\n{job.CustomerId}"
                    });
                }
            }
            ((TableLayoutPanel)card.Tag!).Controls.Add(schedule, 0, 1);
            return card;
        }

        private static Panel CreateProviderCard(string title)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 14, 0),
                Padding = new Padding(14)
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
                ForeColor = Color.FromArgb(2, 2, 89),
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
                ForeColor = Color.FromArgb(255, 128, 0),
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
            button.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 0);
            button.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 0);
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
                    BackColor = Color.FromArgb(2, 2, 89),
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
            grid.Location = new Point(18, 18);
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.Size = new Size(1200, 355);
            tab.Controls.Add(grid);
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
