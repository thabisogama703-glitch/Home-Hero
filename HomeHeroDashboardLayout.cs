using System.Drawing.Drawing2D;

namespace Home_Hero
{
    public sealed record DashboardMetric(string Title, string Value, string Detail);

    public class HomeHeroCard : Panel
    {
        public HomeHeroCard()
        {
            BackColor = Color.White;
            Padding = new Padding(20);
            Margin = new Padding(8);
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
            SizeChanged += (_, _) => UpdateRoundedRegion();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? Color.FromArgb(246, 248, 251));
            Rectangle shadowBounds = ClientRectangle;
            shadowBounds.Inflate(-3, -3);
            shadowBounds.Offset(0, 2);
            using GraphicsPath shadowPath = CreateRoundedPath(shadowBounds, 14);
            using SolidBrush shadow = new(Color.FromArgb(20, 24, 39, 75));
            e.Graphics.FillPath(shadow, shadowPath);
            using GraphicsPath cardPath = CreateRoundedPath(ClientRectangle, 14);
            using SolidBrush background = new(BackColor);
            e.Graphics.FillPath(background, cardPath);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using GraphicsPath path = CreateRoundedPath(
                new Rectangle(1, 1, Math.Max(0, Width - 3), Math.Max(0, Height - 3)), 14);
            using Pen border = new(Color.FromArgb(255, 138, 0), 1.5F);
            e.Graphics.DrawPath(border, path);
        }

        private void UpdateRoundedRegion()
        {
            if (Width < 2 || Height < 2)
            {
                return;
            }

            using GraphicsPath path = CreateRoundedPath(ClientRectangle, 14);
            Region = new Region(path);
        }

        private static GraphicsPath CreateRoundedPath(Rectangle bounds, int radius)
        {
            int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            GraphicsPath path = new();
            if (diameter < 2)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    public sealed class HomeHeroDataGridCard : HomeHeroCard
    {
        private readonly DataGridView grid;

        public HomeHeroDataGridCard(string title, DataGridView grid)
        {
            this.grid = grid;
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(2, 2, 89),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            FlowLayoutPanel toolbar = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 5, 0, 5),
                WrapContents = false
            };
            SearchBox = new TextBox
            {
                Font = new Font("Segoe UI", 9.5F),
                PlaceholderText = "Search this table",
                Width = 260,
                Height = 32,
                Margin = new Padding(0, 0, 10, 0)
            };
            SearchBox.TextChanged += (_, _) => ApplySearch();
            toolbar.Controls.Add(SearchBox);
            ToolbarPanel = toolbar;
            layout.Controls.Add(toolbar, 0, 1);

            HomeHeroDashboardLayout.StyleTable(grid);
            Panel gridFrame = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(2)
            };
            grid.Dock = DockStyle.Fill;
            gridFrame.Controls.Add(grid);
            layout.Controls.Add(gridFrame, 0, 2);
            ActionPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 8, 0, 0),
                WrapContents = false
            };
            layout.Controls.Add(ActionPanel, 0, 3);
            Controls.Add(layout);
        }

        public TextBox SearchBox { get; }
        public FlowLayoutPanel ToolbarPanel { get; }
        public FlowLayoutPanel ActionPanel { get; }

        public void AddToolbarControl(Control control)
        {
            control.Margin = new Padding(0, 0, 10, 0);
            ToolbarPanel.Controls.Add(control);
        }

        public void AddActionControl(Control control)
        {
            control.Margin = new Padding(0, 0, 10, 0);
            ActionPanel.Controls.Add(control);
        }

        public void ApplyCurrentSearch() => ApplySearch();

        private void ApplySearch()
        {
            if (grid.RowCount == 0)
            {
                return;
            }

            string query = SearchBox.Text.Trim();
            if (grid.CurrentCell != null)
            {
                grid.CurrentCell = null;
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                bool matches = string.IsNullOrWhiteSpace(query) ||
                               string.Join(" ", row.Cells.Cast<DataGridViewCell>()
                                       .Select(cell => cell.Value?.ToString() ?? string.Empty))
                                   .Contains(query, StringComparison.OrdinalIgnoreCase);
                row.Visible = matches;
            }
        }
    }

    public sealed class HomeHeroServiceCard : HomeHeroCard
    {
        public HomeHeroServiceCard(HomeServiceOption service, Image image)
        {
            Padding = new Padding(0);
            Size = new Size(260, 260);
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                RowCount = 4
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            PictureBox picture = new()
            {
                Dock = DockStyle.Fill,
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            layout.Controls.Add(picture, 0, 0);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(2, 2, 89),
                Padding = new Padding(16, 6, 10, 0),
                Text = service.Name
            }, 0, 1);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(90, 99, 112),
                Padding = new Padding(16, 4, 12, 0),
                Text = service.Description
            }, 0, 2);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(224, 112, 0),
                Padding = new Padding(16, 4, 10, 0),
                Text = $"Starting at R{service.StartingPrice:N0}"
            }, 0, 3);
            Controls.Add(layout);
        }

        public static Image ImageFor(string serviceName)
        {
            return HomeServiceCatalog.NormalizeCategory(serviceName) switch
            {
                "Electrical" => Properties.Resources.Application_pic,
                "Plumbing" => Properties.Resources._8_Home_Maintenance_Jobs_That_MUST_Be_Done_Once_A_Year___NewsBreak,
                "Painting" => Properties.Resources.Home_Hero_background_image,
                "Cleaning" => Properties.Resources.Breathtaking_new_Hamptons_style_house_in_Melbourne_s_south_east,
                "Deep Cleaning" => Properties.Resources.Breathtaking_new_Hamptons_style_house_in_Melbourne_s_south_east,
                "HVAC" => Properties.Resources.BackG_image,
                "Repairs" => Properties.Resources.Application_pic,
                _ => Properties.Resources.Application_pic
            };
        }
    }

    public sealed class HomeHeroDashboardLayout : UserControl
    {
        private readonly FlowLayoutPanel navigation = new();
        private readonly TableLayoutPanel metrics = new();
        private readonly Panel contentPanel = new();
        private readonly Panel topBar = new();
        private readonly Label titleLabel = new();
        private readonly Label descriptionLabel = new();
        private readonly Label identityLabel = new();
        private Panel heroPanel = new();
        private Control? currentContent;

        public HomeHeroDashboardLayout()
        {
            BackColor = Color.FromArgb(246, 248, 251);
            Dock = DockStyle.Fill;
            BuildLayout();
            contentPanel.Resize += (_, _) =>
            {
                if (currentContent?.AutoSize == true)
                {
                    currentContent.Width = contentPanel.ClientSize.Width;
                }
            };
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

        public void SetHeroImage(Image image)
        {
            heroPanel.BackgroundImage = image;
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
            currentContent = content;
            if (content.AutoSize)
            {
                content.Dock = DockStyle.Top;
                content.Width = contentPanel.ClientSize.Width;
            }
            else
            {
                content.Dock = DockStyle.Fill;
            }
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
            table.RowTemplate.Height = 38;
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
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 168F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 116F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            BuildTopBar();
            navigation.Dock = DockStyle.Fill;
            navigation.BackColor = Color.White;
            navigation.FlowDirection = FlowDirection.LeftToRight;
            navigation.Padding = new Padding(28, 9, 20, 5);
            navigation.WrapContents = false;
            navigation.AutoScroll = true;

            Panel hero = BuildHero();
            heroPanel = hero;
            metrics.Dock = DockStyle.Fill;
            metrics.Padding = new Padding(20, 12, 20, 16);
            metrics.RowCount = 1;
            metrics.BackColor = Color.FromArgb(246, 248, 251);

            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(246, 248, 251);
            contentPanel.Padding = new Padding(20, 12, 20, 24);
            contentPanel.AutoScroll = true;

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
            topBar.Resize += (_, _) => identityLabel.Location =
                new Point(Math.Min(260, Math.Max(190, topBar.ClientSize.Width / 3)), 23);
        }

        private Panel BuildHero()
        {
            Panel hero = new()
            {
                BackColor = Color.FromArgb(2, 2, 89),
                BackgroundImage = Properties.Resources.Home_Hero_background_image,
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Fill,
                Margin = new Padding(20, 12, 20, 12),
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
            HomeHeroCard card = new()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(7, 0, 8, 0),
                Padding = new Padding(20, 14, 14, 12)
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
