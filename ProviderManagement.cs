using HomeHero_2;

namespace Home_Hero
{
    public partial class frmProviderManagement : Form
    {
        private readonly DataGridView providersGrid = CreateGrid();
        private readonly TextBox searchBox = new();
        private readonly Label providerCountValue = CreateMetricValue();
        private readonly Label serviceCountValue = CreateMetricValue();
        private readonly Label openJobsValue = CreateMetricValue();
        private List<ServiceProvider> providers = new();
        private List<MaintenanceRequest> requests = new();

        public frmProviderManagement()
        {
            InitializeComponent();
            BuildWorkspace();
            MigrateLegacyProviders();
            RefreshProviders();
        }

        private void BuildWorkspace()
        {
            Controls.Clear();
            Text = "HomeHero | Provider management";
            BackColor = Color.FromArgb(246, 248, 252);
            MinimumSize = new Size(1050, 720);
            WindowState = FormWindowState.Maximized;

            Panel header = new()
            {
                BackColor = Color.FromArgb(0, 0, 64),
                Dock = DockStyle.Top,
                Height = 76,
                Padding = new Padding(28, 0, 28, 0)
            };
            header.Controls.Add(new Label
            {
                Text = "HomeHero",
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(28, 15)
            });
            Button logoutButton = CreateButton("Log out", Color.FromArgb(33, 43, 74));
            logoutButton.Size = new Size(120, 42);
            logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logoutButton.Location = new Point(0, 17);
            logoutButton.Click += btnExitAdmin_Click;
            header.Controls.Add(logoutButton);
            header.Resize += (_, _) => logoutButton.Location =
                new Point(header.ClientSize.Width - logoutButton.Width - 28, 17);

            FlowLayoutPanel navigation = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 54,
                Padding = new Padding(28, 12, 20, 8),
                WrapContents = false
            };
            navigation.Controls.Add(CreateNavLink("Overview", (_, _) => Close()));
            navigation.Controls.Add(CreateNavLink("Requests", (_, _) => OpenAdminPage(new RequestManagement())));
            navigation.Controls.Add(CreateNavLink("Providers", (_, _) => RefreshProviders()));
            navigation.Controls.Add(CreateNavLink("Reports", (_, _) => OpenAdminPage(new frmReports())));

            TableLayoutPanel content = new()
            {
                AutoScroll = true,
                BackColor = Color.FromArgb(246, 248, 252),
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(28, 20, 28, 24),
                RowCount = 4
            };
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 154F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 104F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Controls.Add(CreateHeroBanner(), 0, 0);
            content.Controls.Add(CreateMetricsPanel(), 0, 1);
            content.Controls.Add(CreateToolbar(), 0, 2);
            content.Controls.Add(CreateGridPanel(), 0, 3);

            Controls.Add(content);
            Controls.Add(navigation);
            Controls.Add(header);
        }

        private Control CreateHeroBanner()
        {
            Panel banner = new()
            {
                BackColor = Color.FromArgb(0, 0, 64),
                BackgroundImage = Properties.Resources.Home_Hero_background_image,
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 16),
                Padding = new Padding(24)
            };
            banner.Paint += (_, e) =>
            {
                using SolidBrush overlay = new(Color.FromArgb(185, 0, 0, 64));
                e.Graphics.FillRectangle(overlay, banner.ClientRectangle);
            };
            banner.Controls.Add(new Label
            {
                Text = "Service provider management",
                AutoSize = true,
                Font = new Font("Segoe UI", 23F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(26, 30)
            });
            banner.Controls.Add(new Label
            {
                Text = "Manage registered tradespeople, update their service details, and add new providers.",
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
                Padding = new Padding(0, 0, 0, 14),
                RowCount = 1
            };
            for (int column = 0; column < 3; column++)
            {
                metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            }

            metrics.Controls.Add(CreateMetricCard("Registered providers", providerCountValue), 0, 0);
            metrics.Controls.Add(CreateMetricCard("Services covered", serviceCountValue), 1, 0);
            metrics.Controls.Add(CreateMetricCard("Open assigned jobs", openJobsValue), 2, 0);
            return metrics;
        }

        private Control CreateToolbar()
        {
            TableLayoutPanel toolbar = new()
            {
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 8, 0, 8),
                RowCount = 1
            };
            toolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            toolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            toolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            toolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));

            searchBox.Dock = DockStyle.Fill;
            searchBox.Font = new Font("Segoe UI", 10F);
            searchBox.PlaceholderText = "Search by provider, email, service area, or specialization";
            searchBox.TextChanged += (_, _) => BindProviders();
            toolbar.Controls.Add(searchBox, 0, 0);

            Button editButton = CreateButton("Edit selected", Color.FromArgb(0, 0, 64));
            editButton.Dock = DockStyle.Fill;
            editButton.Margin = new Padding(10, 0, 0, 0);
            editButton.Click += (_, _) => EditSelectedProvider();
            toolbar.Controls.Add(editButton, 1, 0);

            Button removeButton = CreateButton("Remove selected", Color.FromArgb(176, 48, 48));
            removeButton.Dock = DockStyle.Fill;
            removeButton.Margin = new Padding(10, 0, 0, 0);
            removeButton.Click += btnAddProvider_Click;
            toolbar.Controls.Add(removeButton, 2, 0);

            Button addButton = CreateButton("+ Add provider", Color.FromArgb(255, 128, 0));
            addButton.Dock = DockStyle.Fill;
            addButton.Margin = new Padding(10, 0, 0, 0);
            addButton.Click += btnAddProvider__Click;
            toolbar.Controls.Add(addButton, 3, 0);
            return toolbar;
        }

        private Control CreateGridPanel()
        {
            Panel panel = new()
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            providersGrid.Dock = DockStyle.Fill;
            providersGrid.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    EditSelectedProvider();
                }
            };
            panel.Controls.Add(providersGrid);
            return panel;
        }

        private static Panel CreateMetricCard(string title, Label value)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 14, 0)
            };
            card.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(16, 12),
                Text = title
            });
            value.Location = new Point(16, 38);
            card.Controls.Add(value);
            return card;
        }

        private static Label CreateMetricValue() => new()
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 21F, FontStyle.Bold),
            ForeColor = Color.FromArgb(255, 128, 0),
            Text = "0"
        };

        private static DataGridView CreateGrid() => new()
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
            ColumnHeadersHeight = 40,
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

        private static Button CreateButton(string text, Color color)
        {
            Button button = new()
            {
                BackColor = color,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Text = text,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
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

        private void MigrateLegacyProviders()
        {
            HashSet<string> registeredEmails = CustomerRepository.LoadRegisteredServiceProviders()
                .Select(provider => provider.Email)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (ServiceProvider provider in DataManager.LoadServiceProviders())
            {
                if (!string.IsNullOrWhiteSpace(provider.Email) && registeredEmails.Add(provider.Email))
                {
                    CustomerRepository.SaveServiceProvider(provider);
                }
            }
        }

        private void RefreshProviders()
        {
            providers = CustomerRepository.LoadRegisteredServiceProviders();
            providerCountValue.Text = providers.Count.ToString();
            serviceCountValue.Text = providers
                .SelectMany(provider => provider.Specialisation ?? new List<string>())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count()
                .ToString();
            requests = DataManager.LoadRequests();
            openJobsValue.Text = requests.Count(request =>
                request.Status != RequestStatus.Completed &&
                request.Status != RequestStatus.Cancelled &&
                providers.Any(provider => IsAssignedToProvider(request, provider))).ToString();
            BindProviders();
        }

        private void BindProviders()
        {
            string query = searchBox.Text.Trim();
            providersGrid.DataSource = providers
                .Where(provider =>
                {
                    string searchableText = string.Join(" ", provider.FirstName, provider.LastName, provider.Email,
                        provider.PhoneNumber, provider.Location, string.Join(" ", provider.Specialisation ?? new List<string>()));
                    return searchableText.Contains(query, StringComparison.OrdinalIgnoreCase);
                })
                .Select(provider => new
                {
                    Name = $"{provider.FirstName} {provider.LastName}".Trim(),
                    provider.Email,
                    Phone = provider.PhoneNumber,
                    ServiceArea = provider.Location,
                    Specializations = string.Join(", ", provider.Specialisation ?? new List<string>()),
                    ActiveRequests = requests.Count(request =>
                        IsAssignedToProvider(request, provider) &&
                        request.Status != RequestStatus.Completed &&
                        request.Status != RequestStatus.Cancelled)
                })
                .ToList();
        }

        private static bool IsAssignedToProvider(MaintenanceRequest request, ServiceProvider provider)
        {
            string providerName = $"{provider.FirstName} {provider.LastName}".Trim();
            return string.Equals(request.AssignedProviderId, provider.Email, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(request.AssignedProviderId, providerName, StringComparison.OrdinalIgnoreCase);
        }

        private ServiceProvider? GetSelectedProvider()
        {
            string? email = providersGrid.CurrentRow?.Cells["Email"].Value?.ToString();
            return providers.FirstOrDefault(provider =>
                string.Equals(provider.Email, email, StringComparison.OrdinalIgnoreCase));
        }

        private void EditSelectedProvider()
        {
            ServiceProvider? selectedProvider = GetSelectedProvider();
            if (selectedProvider == null)
            {
                MessageBox.Show("Select a provider to edit.", "No Provider Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using AddProvider editForm = new(selectedProvider);
            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshProviders();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) => BindProviders();

        private void btnAddProvider__Click(object sender, EventArgs e)
        {
            using AddProvider addProviderForm = new();
            if (addProviderForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshProviders();
            }
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            ServiceProvider? provider = GetSelectedProvider();
            if (provider == null)
            {
                MessageBox.Show("Select a provider to remove.", "No Provider Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Remove {provider.FirstName} {provider.LastName} ({provider.Email}) from the provider directory?",
                "Remove Provider",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                return;
            }

            CustomerRepository.DeleteServiceProvider(provider.Email);
            DataManager.DeleteServiceProvider(provider.Email);
            RefreshProviders();
        }

        private void OpenAdminPage(Form page)
        {
            page.FormClosed += (_, _) =>
            {
                Show();
                RefreshProviders();
            };
            Hide();
            page.Show();
        }

        private void ProviderManagement_Load(object sender, EventArgs e) => RefreshProviders();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            OpenAdminPage(new frmReports());

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Close();

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
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
    }
}
