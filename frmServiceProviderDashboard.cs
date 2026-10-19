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
        private TabControl? providerTabs;
        private MessageCenterForm? providerMessageCenter;

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
            BackColor = Color.FromArgb(245, 247, 251);
            MinimumSize = new Size(1000, 700);
            Size = new Size(1440, 900);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            Panel header = new()
            {
                BackColor = Color.FromArgb(0, 0, 64),
                Dock = DockStyle.Top,
                Height = 86,
                Padding = new Padding(28, 0, 28, 0)
            };
            header.Controls.Add(new Label
            {
                Text = "HomeHero",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 21F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(26, 22)
            });
            header.Controls.Add(new Label
            {
                Text = $"PROVIDER WORKSPACE  ·  {currentProvider.FirstName} {currentProvider.LastName}".Trim(),
                ForeColor = Color.FromArgb(255, 174, 82),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(660, 32)
            });

            KryptonButton messagesButton = CreateActionButton("Messages");
            messagesButton.Location = new Point(1100, 20);
            messagesButton.Size = new Size(140, 46);
            messagesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            messagesButton.Click += (_, _) => SelectMessagesTab();

            KryptonButton logoutButton = CreateActionButton("Log out");
            logoutButton.Location = new Point(1250, 20);
            logoutButton.Size = new Size(130, 46);
            logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logoutButton.StateCommon.Back.Color1 = Color.FromArgb(33, 43, 74);
            logoutButton.StateCommon.Back.Color2 = Color.FromArgb(33, 43, 74);
            logoutButton.Click += Logout_Click;
            header.Controls.Add(messagesButton);
            header.Controls.Add(logoutButton);

            Panel workspace = new()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(28, 22, 28, 24),
                BackColor = Color.FromArgb(245, 247, 251)
            };
            Controls.Add(workspace);
            Controls.Add(header);

            Label title = new()
            {
                Text = "Your service hub",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                AutoSize = true,
                Location = new Point(28, 22)
            };
            Label subtitle = new()
            {
                Text = "Review customer requests, manage your schedule, and keep every job moving.",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(30, 66)
            };
            workspace.Controls.Add(title);
            workspace.Controls.Add(subtitle);

            FlowLayoutPanel metrics = new()
            {
                Location = new Point(28, 112),
                Size = new Size(1260, 112),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                WrapContents = false
            };
            metrics.Controls.Add(CreateMetricCard("New customer requests", summaryAvailable));
            metrics.Controls.Add(CreateMetricCard("My active jobs", summaryAssigned));
            metrics.Controls.Add(CreateMetricCard("Completed jobs", summaryCompleted));
            workspace.Controls.Add(metrics);

            TabControl tabs = new()
            {
                Location = new Point(28, 244),
                Size = new Size(1260, 510),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 10F)
            };
            TabPage overviewTab = new("Overview");
            TabPage requestsTab = new("Customer requests");
            TabPage jobsTab = new("My jobs");
            TabPage completedTab = new("Completed");
            TabPage messagesTab = new("Customer messages");
            tabs.TabPages.AddRange(new[] { overviewTab, requestsTab, jobsTab, completedTab, messagesTab });
            providerTabs = tabs;

            overviewTab.Controls.Add(CreateOverviewPanel());
            AddGridTab(requestsTab, availableRequestsGrid);
            AddGridTab(jobsTab, assignedRequestsGrid);
            AddGridTab(completedTab, completedRequestsGrid);
            AddMessageCenter(messagesTab);

            approveRequestButton.Location = new Point(18, 405);
            approveRequestButton.Size = new Size(210, 42);
            approveRequestButton.Click += ApproveRequest_Click;
            refreshButton.Location = new Point(1030, 405);
            refreshButton.Size = new Size(190, 42);
            refreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshButton.StateCommon.Back.Color1 = Color.FromArgb(0, 0, 64);
            refreshButton.StateCommon.Back.Color2 = Color.FromArgb(0, 0, 64);
            refreshButton.Click += (_, _) => LoadRequests();
            requestsTab.Controls.Add(approveRequestButton);
            requestsTab.Controls.Add(refreshButton);

            finalCostInput.DecimalPlaces = 2;
            finalCostInput.Maximum = 1000000;
            finalCostInput.Minimum = 0;
            finalCostInput.Size = new Size(150, 38);
            finalCostInput.Location = new Point(18, 405);
            finalCostInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            scheduleRequestButton.Location = new Point(185, 405);
            startRequestButton.Location = new Point(355, 405);
            completeRequestButton.Location = new Point(525, 405);
            foreach (KryptonButton button in new[]
                     {
                         scheduleRequestButton,
                         startRequestButton,
                         completeRequestButton
                     })
            {
                button.Size = new Size(155, 42);
                button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            }

            scheduleRequestButton.Click += (_, _) => UpdateSelectedRequest(RequestStatus.Scheduled);
            startRequestButton.Click += (_, _) => UpdateSelectedRequest(RequestStatus.InProgress);
            completeRequestButton.Click += CompleteRequest_Click;
            jobsTab.Controls.Add(finalCostInput);
            jobsTab.Controls.Add(scheduleRequestButton);
            jobsTab.Controls.Add(startRequestButton);
            jobsTab.Controls.Add(completeRequestButton);
            workspace.Controls.Add(tabs);
        }

        private void AddMessageCenter(TabPage messagesTab)
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
            messagesTab.Controls.Add(providerMessageCenter);
            providerMessageCenter.Show();
        }

        private void SelectMessagesTab()
        {
            if (providerTabs != null && providerTabs.TabPages.Count > 4)
            {
                providerTabs.SelectedIndex = 4;
            }
        }

        private Control CreateOverviewPanel()
        {
            Panel overview = new()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(28)
            };

            Label overviewTitle = new()
            {
                Text = "Recommended next steps",
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64),
                AutoSize = true,
                Location = new Point(28, 26)
            };
            overview.Controls.Add(overviewTitle);

            string[] steps =
            {
                "1. Review new requests and accept work that matches your services.",
                "2. Schedule accepted requests and keep appointment details current.",
                "3. Start work when you arrive, then record the final cost when finished.",
                "4. Use Messages to coordinate directly with each customer."
            };
            for (int index = 0; index < steps.Length; index++)
            {
                overview.Controls.Add(new Label
                {
                    Text = steps[index],
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(45, 52, 70),
                    AutoSize = true,
                    Location = new Point(32, 92 + index * 56)
                });
            }

            KryptonButton refreshOverviewButton = CreateActionButton("Refresh dashboard");
            refreshOverviewButton.Location = new Point(30, 330);
            refreshOverviewButton.Size = new Size(220, 46);
            refreshOverviewButton.Click += (_, _) => LoadRequests();
            overview.Controls.Add(refreshOverviewButton);
            return overview;
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
            return new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 355,
                ReadOnly = true,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
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
            MaintenanceRequest? selected = GetSelectedRequest(availableRequestsGrid);
            if (selected == null)
            {
                ShowSelectRequestMessage();
                return;
            }

            UpdateRequest(selected, request =>
            {
                if (request.Status == RequestStatus.Requested)
                {
                    if (!request.TryUpdateStatus(RequestStatus.Approved, out string approvalError))
                    {
                        return approvalError;
                    }
                }

                if (request.Status != RequestStatus.Approved)
                {
                    return "This request is no longer available.";
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
                Hide();
                new frmHomeHeroHomepage().Show();
            }
        }
    }
}
