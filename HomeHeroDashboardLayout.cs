namespace Home_Hero
{
    public sealed record DashboardMetric(string Title, string Value, string Detail);

    public sealed class HomeHeroDashboardLayout : UserControl
    {
        private readonly FlowLayoutPanel navigation = new();
        private readonly TableLayoutPanel metrics = new();
        private readonly Panel contentPanel = new();
        private readonly Panel topBar = new();
        private readonly Label titleLabel = new();
        private readonly Label descriptionLabel = new();
        private readonly Label identityLabel = new();
        private string selectedSection = string.Empty;

        public HomeHeroDashboardLayout()
        {
            BackColor = Color.FromArgb(246, 248, 251);
            Dock = DockStyle.Fill;
            BuildLayout();
        }

        public Panel ContentPanel => contentPanel;
        public Panel HeaderPanel => topBar;

        public event EventHandler<string>? NavigationRequested;

        public void SetIdentity(string identity)
        {
            identityLabel.Text = identity;
        }

        public void SetHero(string title, string description)
        {
            titleLabel.Text = title;
            descriptionLabel.Text = description;
        }

        public void SetMetrics(IEnumerable<DashboardMetric> values)
        {
            List<DashboardMetric> items = values.Take(6).ToList();
            metrics.SuspendLayout();
            metrics.Controls.Clear();
            metrics.ColumnStyles.Clear();
            metrics.ColumnCount = Math.Max(1, items.Count);

            for (int index = 0; index < items.Count; index++)
            {
                metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / items.Count));
                metrics.Controls.Add(CreateMetricCard(items[index]), index, 0);
            }

            metrics.ResumeLayout();
        }

        public void SetNavigation(IEnumerable<string> sections, string selected)
        {
            navigation.SuspendLayout();
            navigation.Controls.Clear();
            selectedSection = selected;
            foreach (string section in sections)
            {
                Button button = new()
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    BackColor = string.Equals(section, selected, StringComparison.OrdinalIgnoreCase)
                        ? Color.FromArgb(255, 138, 0)
                        : Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = string.Equals(section, selected, StringComparison.OrdinalIgnoreCase)
                        ? Color.White
                        : Color.FromArgb(2, 2, 89),
                    Margin = new Padding(0, 0, 10, 0),
                    Padding = new Padding(14, 8, 14, 8),
                    Text = section,
                    UseVisualStyleBackColor = false,
                    Tag = section
                };
                button.FlatAppearance.BorderSize = 0;
                button.Click += (_, _) => NavigationRequested?.Invoke(this, section);
                navigation.Controls.Add(button);
            }
            navigation.ResumeLayout();
        }

        public void ShowContent(Control content)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            content.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(content);
            contentPanel.ResumeLayout();
        }

        public static void StyleTable(DataGridView table)
        {
            table.AllowUserToAddRows = false;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.BackgroundColor = Color.White;
            table.BorderStyle = BorderStyle.None;
            table.ColumnHeadersHeight = 42;
            table.EnableHeadersVisualStyles = false;
            table.MultiSelect = false;
            table.ReadOnly = true;
            table.RowHeadersVisible = false;
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(2, 2, 89);
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            table.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            table.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            table.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 238, 250);
            table.DefaultCellStyle.SelectionForeColor = Color.FromArgb(27, 27, 27);
            table.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 251);
            table.CellFormatting += (_, e) =>
            {
                if (e.RowIndex < 0 ||
                    e.ColumnIndex < 0 ||
                    !string.Equals(table.Columns[e.ColumnIndex].Name, "Status", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                string status = e.Value?.ToString() ?? string.Empty;
                (Color background, Color foreground) = status.ToLowerInvariant() switch
                {
                    "completed" => (Color.FromArgb(225, 245, 234), Color.FromArgb(31, 122, 74)),
                    "cancelled" => (Color.FromArgb(252, 229, 229), Color.FromArgb(164, 46, 46)),
                    "inprogress" or "scheduled" => (Color.FromArgb(225, 237, 250), Color.FromArgb(41, 93, 150)),
                    "requested" or "approved" or "providerassigned" => (Color.FromArgb(255, 243, 218), Color.FromArgb(148, 92, 15)),
                    _ => (Color.White, Color.FromArgb(27, 27, 27))
                };
                e.CellStyle.BackColor = background;
                e.CellStyle.ForeColor = foreground;
                e.CellStyle.SelectionBackColor = background;
                e.CellStyle.SelectionForeColor = foreground;
            };
        }

        private void BuildLayout()
        {
            TableLayoutPanel root = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 5
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            BuildTopBar();
            navigation.Dock = DockStyle.Fill;
            navigation.BackColor = Color.White;
            navigation.FlowDirection = FlowDirection.LeftToRight;
            navigation.Padding = new Padding(28, 9, 20, 5);
            navigation.WrapContents = false;
            navigation.AutoScroll = true;

            Panel hero = BuildHero();
            metrics.Dock = DockStyle.Fill;
            metrics.Padding = new Padding(28, 8, 28, 10);
            metrics.RowCount = 1;
            metrics.BackColor = Color.FromArgb(246, 248, 251);

            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(246, 248, 251);
            contentPanel.Padding = new Padding(28, 8, 28, 26);
            contentPanel.AutoScroll = false;

            root.Controls.Add(topBar, 0, 0);
            root.Controls.Add(navigation, 0, 1);
            root.Controls.Add(hero, 0, 2);
            root.Controls.Add(metrics, 0, 3);
            root.Controls.Add(contentPanel, 0, 4);
            Controls.Add(root);
        }

        private void BuildTopBar()
        {
            topBar.BackColor = Color.FromArgb(2, 2, 89);
            topBar.Dock = DockStyle.Fill;
            topBar.Padding = new Padding(28, 0, 28, 0);
            topBar.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(28, 12),
                Text = "HomeHero"
            });
            identityLabel.AutoSize = true;
            identityLabel.Anchor = AnchorStyles.Top;
            identityLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            identityLabel.ForeColor = Color.FromArgb(255, 174, 82);
            identityLabel.Location = new Point(220, 22);
            identityLabel.TextAlign = ContentAlignment.MiddleRight;
            topBar.Controls.Add(identityLabel);
        }

        private Panel BuildHero()
        {
            Panel hero = new()
            {
                BackColor = Color.FromArgb(2, 2, 89),
                BackgroundImage = Properties.Resources.Home_Hero_background_image,
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Fill,
                Margin = new Padding(28, 10, 28, 8),
                Padding = new Padding(26)
            };
            hero.Paint += (_, e) =>
            {
                using SolidBrush overlay = new(Color.FromArgb(178, 2, 2, 89));
                e.Graphics.FillRectangle(overlay, hero.ClientRectangle);
            };
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(26, 30);
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 10F);
            descriptionLabel.ForeColor = Color.White;
            descriptionLabel.Location = new Point(30, 84);
            hero.Controls.Add(titleLabel);
            hero.Controls.Add(descriptionLabel);
            return hero;
        }

        private static Control CreateMetricCard(DashboardMetric metric)
        {
            Panel card = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 12, 0),
                Padding = new Padding(16)
            };
            Panel accent = new()
            {
                BackColor = Color.FromArgb(255, 138, 0),
                Dock = DockStyle.Left,
                Width = 4
            };
            card.Controls.Add(accent);
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(107, 114, 128),
                Height = 24,
                Text = metric.Title
            });
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(2, 2, 89),
                Height = 38,
                Text = metric.Value
            });
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Text = metric.Detail
            });
            return card;
        }
    }
}
