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

            Panel header = new()
            {
                BackColor = Color.FromArgb(0, 0, 64),
                Dock = DockStyle.Top,
                Height = 82,
                Padding = new Padding(28, 0, 28, 0)
            };
            header.Controls.Add(new Label
            {
                Text = "HomeHero",
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(28, 18)
            });
            header.Controls.Add(new Label
            {
                Text = currentCustomerEmail,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(760, 30)
            });
            KryptonButton logoutButton = CreateActionButton("Log out", Color.FromArgb(33, 43, 74));
            logoutButton.Size = new Size(120, 42);
            logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logoutButton.Location = new Point(0, 20);
            logoutButton.Click += btnBackToHome_Click;
            header.Controls.Add(logoutButton);
            header.Resize += (_, _) =>
            {
                logoutButton.Location = new Point(header.ClientSize.Width - 148, 20);
                Control? emailLabel = header.Controls.Cast<Control>().FirstOrDefault(control =>
                    control is Label label && label.Text == currentCustomerEmail);
                if (emailLabel != null)
                {
                    emailLabel.Location = new Point(Math.Max(330, header.ClientSize.Width - 380), 30);
                }
            };

            FlowLayoutPanel navigation = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 58,
                Padding = new Padding(28, 12, 20, 8),
                WrapContents = false
            };
            navigation.Controls.Add(CreateNavLink("Overview", (_, _) => RefreshDashboard()));
            navigation.Controls.Add(CreateNavLink("New service request", btnNewServiceRequest_Click_1));
            navigation.Controls.Add(CreateNavLink("Active requests", BtnActiceRequests_Click));
            navigation.Controls.Add(CreateNavLink("Track a request", btnTrackRequest_Click_1));
            navigation.Controls.Add(CreateNavLink("Service history", btnServiceHistory_Click));
            navigation.Controls.Add(CreateNavLink("Messages", (_, _) => OpenMessages()));

            TableLayoutPanel content = new()
            {
                AutoScroll = true,
                BackColor = Color.FromArgb(246, 248, 252),
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(32, 22, 32, 28),
                RowCount = 5
            };
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 106F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Controls.Add(CreateWelcomePanel(), 0, 0);
            content.Controls.Add(CreateMetricsPanel(), 0, 1);
            content.Controls.Add(CreateProgressPanel(), 0, 2);
            content.Controls.Add(CreateRequestToolbar(), 0, 3);
            content.Controls.Add(CreateRequestListPanel(), 0, 4);

            Controls.Add(content);
            Controls.Add(navigation);
            Controls.Add(header);
        }

        private Control CreateWelcomePanel()
        {
            FlowLayoutPanel welcome = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            welcome.Controls.Add(new Label
            {
                Text = "Welcome back",
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 64)
            });
            welcome.Controls.Add(new Label
            {
                Text = "Manage your home services and follow every request from submission to completion.",
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.DimGray,
                Margin = new Padding(3, 2, 3, 0)
            });
            return welcome;
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
            requestsGrid.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    btnTrackRequest_Click_1(this, EventArgs.Empty);
                }
            };
            panel.Controls.Add(requestsGrid);
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
            BindRequestsGrid();
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

            requestsGrid.DataSource = filteredRequests
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
