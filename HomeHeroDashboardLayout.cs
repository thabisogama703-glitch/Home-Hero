using System.Drawing.Drawing2D;

namespace Home_Hero
{
    public static class HomeHeroTheme
    {
        public static readonly Color Navy = Color.FromArgb(0, 0, 64);
        public static readonly Color Orange = Color.FromArgb(255, 128, 0);
        public static readonly Color Canvas = Color.FromArgb(246, 248, 252);
        public static readonly Color Text = Color.FromArgb(35, 42, 55);
        public static readonly Color Muted = Color.FromArgb(102, 112, 128);

        public static void StyleInput(TextBox input)
        {
            input.BorderStyle = BorderStyle.FixedSingle;
            input.Font = new Font("Segoe UI", 10F);
            input.Height = 38;
            input.Margin = new Padding(0, 4, 0, 12);
            input.Dock = DockStyle.Fill;
        }

        public static void StyleButton(Button button, bool primary)
        {
            button.BackColor = primary ? Orange : Navy;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.Height = 44;
            button.Margin = new Padding(0, 8, 0, 8);
            button.UseVisualStyleBackColor = false;
        }

        public static Label CreateHeading(string text, float size = 22F) => new()
        {
            AutoEllipsis = true,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", size, FontStyle.Bold),
            ForeColor = Navy,
            Text = text,
            TextAlign = ContentAlignment.MiddleLeft
        };

        public static Label CreateFieldLabel(string text) => new()
        {
            AutoSize = false,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Text,
            Text = text,
            TextAlign = ContentAlignment.BottomLeft
        };

        public static Control CreateBrand()
        {
            FlowLayoutPanel brand = new()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 16, 0, 0),
                WrapContents = false
            };
            foreach ((string text, Color color) in new[]
                     {
                         ("Home", Color.White),
                         ("Hero", Orange)
                     })
            {
                brand.Controls.Add(new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                    ForeColor = color,
                    Margin = new Padding(0),
                    Text = text
                });
            }
            return brand;
        }

        public static void StyleHeaderButton(Button button)
        {
            StyleButton(button, false);
            button.BackColor = Navy;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.White;
            button.ForeColor = Color.White;
        }

        public static Control CreateField(string title, Control input, Button? action = null)
        {
            TableLayoutPanel field = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(10, 6, 10, 6),
                RowCount = 2
            };
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            field.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            field.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            field.Controls.Add(CreateFieldLabel(title), 0, 0);

            if (input is TextBox textBox)
            {
                StyleInput(textBox);
            }
            else
            {
                input.Dock = DockStyle.Fill;
                input.Margin = new Padding(0);
                input.Font = new Font("Segoe UI", 10F);
            }

            if (action == null)
            {
                field.Controls.Add(input, 0, 1);
                return field;
            }

            TableLayoutPanel inputLayout = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                RowCount = 1
            };
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            StyleButton(action, false);
            action.Dock = DockStyle.Fill;
            action.Margin = new Padding(8, 0, 0, 0);
            inputLayout.Controls.Add(input, 0, 0);
            inputLayout.Controls.Add(action, 1, 0);
            field.Controls.Add(inputLayout, 0, 1);
            return field;
        }
    }

    public sealed record DashboardMetric(string Title, string Value, string Detail);

    public class HomeHeroCard : Panel
    {
        public HomeHeroCard()
        {
            BackColor = Color.White;
            Padding = new Padding(20);
            Margin = new Padding(10);
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
            using Pen border = new(HomeHeroTheme.Orange, 1.5F);
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
        private readonly Panel gridFrame = new();
        private readonly Panel emptyState = new();
        private readonly Label emptyStateMessage = new();
        private readonly Button emptyStateAction = new();
        private EventHandler? emptyActionHandler;
        private string noRecordsMessage = "There are no records to show yet.";
        private string noResultsMessage = "No records match the current search or filters.";

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
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
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
            gridFrame = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(2)
            };
            grid.Dock = DockStyle.Fill;
            gridFrame.Controls.Add(grid);
            emptyState.BackColor = Color.White;
            emptyState.Dock = DockStyle.Fill;
            emptyState.Visible = false;
            TableLayoutPanel emptyLayout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                RowCount = 2
            };
            emptyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            emptyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            emptyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            emptyStateMessage.Dock = DockStyle.Fill;
            emptyStateMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            emptyStateMessage.ForeColor = HomeHeroTheme.Muted;
            emptyStateMessage.TextAlign = ContentAlignment.MiddleCenter;
            emptyLayout.Controls.Add(emptyStateMessage, 0, 0);
            emptyStateAction.Anchor = AnchorStyles.None;
            emptyStateAction.BackColor = HomeHeroTheme.Orange;
            emptyStateAction.FlatStyle = FlatStyle.Flat;
            emptyStateAction.FlatAppearance.BorderSize = 0;
            emptyStateAction.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            emptyStateAction.ForeColor = Color.White;
            emptyStateAction.Size = new Size(190, 38);
            emptyStateAction.UseVisualStyleBackColor = false;
            emptyStateAction.Visible = false;
            emptyLayout.Controls.Add(emptyStateAction, 0, 1);
            emptyState.Controls.Add(emptyLayout);
            gridFrame.Controls.Add(emptyState);
            layout.Controls.Add(gridFrame, 0, 2);
            ActionPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false
            };
            ActionPanel.ControlAdded += (_, _) =>
            {
                ActionPanel.Visible = true;
                ActionPanel.Padding = new Padding(0, 8, 0, 0);
            };
            ActionPanel.ControlRemoved += (_, _) =>
            {
                bool hasActions = ActionPanel.Controls.Count > 0;
                ActionPanel.Visible = hasActions;
                ActionPanel.Padding = hasActions ? new Padding(0, 8, 0, 0) : Padding.Empty;
            };
            ActionPanel.Visible = false;
            layout.Controls.Add(ActionPanel, 0, 3);
            Controls.Add(layout);
            RefreshEmptyState();
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

        public void SetEmptyState(string message, string actionText, EventHandler? action)
        {
            noRecordsMessage = message;
            emptyStateAction.Text = actionText;
            emptyStateAction.Visible = action != null;
            if (emptyActionHandler != null)
            {
                emptyStateAction.Click -= emptyActionHandler;
            }
            emptyActionHandler = action;
            if (action != null)
            {
                emptyStateAction.Click += action;
            }
            RefreshEmptyState();
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

            RefreshEmptyState();
        }

        private void RefreshEmptyState()
        {
            int visibleRows = grid.Rows.Cast<DataGridViewRow>()
                .Count(row => !row.IsNewRow && row.Visible);
            bool showEmptyState = visibleRows == 0;
            emptyStateMessage.Text = grid.Rows.Count == 0
                ? noRecordsMessage
                : noResultsMessage;
            grid.Visible = !showEmptyState;
            emptyState.Visible = showEmptyState;
        }
    }

    public sealed class HomeHeroServiceCard : HomeHeroCard
    {
        public HomeHeroServiceCard(HomeServiceOption service)
        {
            Padding = new Padding(18);
            MinimumSize = new Size(230, 190);
            Size = new Size(300, 210);
            TableLayoutPanel layout = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                RowCount = 4
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            Label icon = new()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Emoji", 27F, FontStyle.Regular),
                ForeColor = HomeHeroTheme.Orange,
                Text = IconFor(service.Name),
                TextAlign = ContentAlignment.MiddleLeft
            };
            layout.Controls.Add(icon, 0, 0);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Padding = new Padding(0, 4, 0, 0),
                Text = service.Name
            }, 0, 1);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(90, 99, 112),
                Padding = new Padding(0, 4, 0, 0),
                Text = service.Description,
                AutoEllipsis = true
            }, 0, 2);
            layout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(224, 112, 0),
                Padding = new Padding(0, 4, 0, 0),
                Text = $"Starting at R{service.StartingPrice:N0}"
            }, 0, 3);
            Controls.Add(layout);
            SetHoverColors(this, Color.White, Color.FromArgb(255, 248, 238));
        }

        private static string IconFor(string serviceName) =>
            HomeServiceCatalog.NormalizeCategory(serviceName) switch
            {
                "Electrical" => "⚡",
                "Plumbing" => "🚰",
                "Painting" => "🎨",
                "HVAC" => "❄",
                "Cleaning" or "Deep Cleaning" => "🧹",
                "Repairs" => "🔧",
                _ => "🏠"
            };

        private static void SetHoverColors(Control card, Color normal, Color hover)
        {
            void SetColor(Color color)
            {
                card.BackColor = color;
                card.Invalidate();
            }

            void Attach(Control control)
            {
                control.MouseEnter += (_, _) => SetColor(hover);
                control.MouseLeave += (_, _) =>
                {
                    Point cursor = card.PointToClient(Cursor.Position);
                    if (!card.ClientRectangle.Contains(cursor))
                    {
                        SetColor(normal);
                    }
                };
                foreach (Control child in control.Controls)
                {
                    Attach(child);
                }
            }

            Attach(card);
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
        private TableLayoutPanel rootLayout = new();
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

        public void SetHeaderHeights(int heroHeight, int metricsHeight)
        {
            if (heroHeight <= 0 || metricsHeight <= 0 || rootLayout.RowStyles.Count < 4)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(heroHeight),
                    "Hero and metric heights must be positive values.");
            }

            rootLayout.RowStyles[2].Height = heroHeight;
            rootLayout.RowStyles[3].Height = metricsHeight;
            metrics.Padding = new Padding(20, 3, 20, 3);
            if (heroHeight < 110)
            {
                titleLabel.Location = new Point(26, 8);
                descriptionLabel.Location = new Point(30, 43);
            }
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
                        ? HomeHeroTheme.Orange
                        : Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = string.Equals(section, selected, StringComparison.OrdinalIgnoreCase)
                        ? Color.White
                        : HomeHeroTheme.Navy,
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
            table.ColumnHeadersDefaultCellStyle.BackColor = HomeHeroTheme.Navy;
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
            rootLayout = new TableLayoutPanel
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 5
            };
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

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
            metrics.Padding = new Padding(20, 10, 20, 12);
            metrics.RowCount = 1;
            metrics.BackColor = Color.FromArgb(246, 248, 251);

            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(246, 248, 251);
            contentPanel.Padding = new Padding(20, 12, 20, 24);
            contentPanel.AutoScroll = true;

            rootLayout.Controls.Add(topBar, 0, 0);
            rootLayout.Controls.Add(navigation, 0, 1);
            rootLayout.Controls.Add(hero, 0, 2);
            rootLayout.Controls.Add(metrics, 0, 3);
            rootLayout.Controls.Add(contentPanel, 0, 4);
            Controls.Add(rootLayout);
        }

        private void BuildTopBar()
        {
            topBar.BackColor = HomeHeroTheme.Navy;
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
                BackColor = HomeHeroTheme.Navy,
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
                Padding = new Padding(20, 6, 14, 4)
            };
            Panel accent = new()
            {
                BackColor = HomeHeroTheme.Orange,
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
                Height = 20,
                Text = metric.Title
            });
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Height = 30,
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
