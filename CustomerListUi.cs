using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using HomeHero_2;

namespace Home_Hero
{
    /// <summary>
    /// Shared modern layout for the customer list screens (Active Requests and
    /// Service History): navy header, three summary tiles and a styled grid card.
    /// The forms only have to add columns and rows.
    /// </summary>
    internal class CustomerListPage
    {
        public Label[] TileValues = new Label[3];
        public Label CountLabel = new Label();
        public Label EmptyLabel = new Label();
        public DataGridView Grid = null!;

        public void SetEmpty(bool empty)
        {
            Grid.Visible = !empty;
            EmptyLabel.Visible = empty;
        }

        // ------------------------------------------------------------------
        //  PAGE BUILDER
        // ------------------------------------------------------------------
        public static CustomerListPage Build(
            Form form, DataGridView grid, Button back,
            string title, string subtitle,
            string[] tileCaptions, Color[] tileAccents,
            string listHeading, string emptyTitle, string emptyHint)
        {
            CustomerListPage page = new CustomerListPage();
            page.Grid = grid;

            List<Control> oldControls = form.Controls.Cast<Control>().ToList();

            form.SuspendLayout();
            form.BackColor = Theme.Bg;
            form.Font = Theme.MakeFont(10F);
            form.ClientSize = new Size(1180, 720);
            form.MinimumSize = new Size(900, 560);
            form.StartPosition = FormStartPosition.CenterScreen;

            // ---------------- header ----------------
            GradientPanel header = new GradientPanel();
            header.Photo = UiAssets.GetImage("Home Care Concierges");
            header.Dock = DockStyle.Top;
            header.Height = 104;

            Label brand = Theme.MakeLabel("HOME HERO", 9F, FontStyle.Bold, Theme.Orange);
            brand.Location = new Point(34, 14);
            header.Controls.Add(brand);

            Label titleLabel = Theme.MakeLabel(title, 21F, FontStyle.Bold, Color.White);
            titleLabel.Location = new Point(32, 32);
            header.Controls.Add(titleLabel);

            Label subLabel = Theme.MakeLabel(subtitle, 10F, FontStyle.Regular, Color.FromArgb(176, 190, 215));
            subLabel.Location = new Point(35, 72);
            header.Controls.Add(subLabel);

            // re-use the existing Back button (keeps its click handler)
            back.Text = "Back to Dashboard";
            back.Size = new Size(190, 44);
            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;
            back.FlatAppearance.MouseOverBackColor = Theme.OrangeHover;
            back.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 90, 40);
            back.BackColor = Theme.Orange;
            back.ForeColor = Color.White;
            back.Font = Theme.MakeSemibold(10.5F);
            back.Cursor = Cursors.Hand;
            back.UseVisualStyleBackColor = false;
            back.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            header.Controls.Add(back);
            back.Location = new Point(header.Width - back.Width - 32, 30);
            header.Resize += delegate { back.Left = header.ClientSize.Width - back.Width - 32; };
            form.Load += delegate { back.Left = header.ClientSize.Width - back.Width - 32; };

            // ---------------- summary tiles ----------------
            TableLayoutPanel tiles = new TableLayoutPanel();
            tiles.Dock = DockStyle.Top;
            tiles.Height = 134;
            tiles.Padding = new Padding(24, 20, 24, 0);
            tiles.BackColor = Theme.Bg;
            tiles.ColumnCount = 3;
            tiles.RowCount = 1;
            tiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tiles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            for (int i = 0; i < 3; i++)
            {
                CardPanel tile = new CardPanel();
                tile.Dock = DockStyle.Fill;
                tile.Margin = new Padding(0, 0, i < 2 ? 16 : 0, 0);
                tile.Padding = new Padding(0);
                tile.AccentColor = tileAccents[i];

                Label caption = Theme.MakeLabel(tileCaptions[i], 8.5F, FontStyle.Bold, Theme.Muted);
                caption.Location = new Point(24, 20);
                tile.Controls.Add(caption);

                Label value = Theme.MakeLabel("0", 21F, FontStyle.Bold, Theme.Navy);
                value.Location = new Point(22, 44);
                tile.Controls.Add(value);

                page.TileValues[i] = value;
                tiles.Controls.Add(tile, i, 0);
            }

            // ---------------- grid card ----------------
            Panel body = new Panel();
            body.Dock = DockStyle.Fill;
            body.Padding = new Padding(24, 4, 24, 24);
            body.BackColor = Theme.Bg;

            CardPanel gridCard = new CardPanel();
            gridCard.Dock = DockStyle.Fill;
            gridCard.Padding = new Padding(22, 16, 22, 26);

            StyleGrid(grid);
            gridCard.Controls.Add(grid);          // moves the grid out of the old group box
            grid.Dock = DockStyle.Fill;

            page.EmptyLabel.Dock = DockStyle.Fill;
            page.EmptyLabel.BackColor = Color.White;
            page.EmptyLabel.ForeColor = Theme.Muted;
            page.EmptyLabel.Font = Theme.MakeFont(11F);
            page.EmptyLabel.TextAlign = ContentAlignment.MiddleCenter;
            page.EmptyLabel.Text = emptyTitle + "\r\n\r\n" + emptyHint;
            page.EmptyLabel.Visible = false;
            gridCard.Controls.Add(page.EmptyLabel);

            Panel listTop = new Panel();
            listTop.Dock = DockStyle.Top;
            listTop.Height = 46;
            listTop.BackColor = Color.White;

            Label heading = Theme.MakeLabel(listHeading, 13F, FontStyle.Bold, Theme.Navy);
            heading.BackColor = Color.White;
            heading.Location = new Point(0, 8);
            listTop.Controls.Add(heading);

            page.CountLabel = Theme.MakeLabel("", 10F, FontStyle.Regular, Theme.Muted);
            page.CountLabel.BackColor = Color.White;
            page.CountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            listTop.Controls.Add(page.CountLabel);
            page.CountLabel.Location = new Point(listTop.Width - 140, 12);
            listTop.Resize += delegate { page.CountLabel.Left = listTop.ClientSize.Width - page.CountLabel.Width; };
            page.CountLabel.SizeChanged += delegate { page.CountLabel.Left = listTop.ClientSize.Width - page.CountLabel.Width; };

            gridCard.Controls.Add(listTop);
            body.Controls.Add(gridCard);

            // The last control added to a form docks first, so: body (fill), tiles, header.
            form.Controls.Add(body);
            form.Controls.Add(tiles);
            form.Controls.Add(header);

            // remove the old designer layout (the Back button and grid were already moved out of it)
            foreach (Control old in oldControls)
            {
                form.Controls.Remove(old);
                old.Dispose();
            }

            form.ResumeLayout(true);
            return page;
        }

        // ------------------------------------------------------------------
        //  GRID HELPERS
        // ------------------------------------------------------------------
        public static void StyleGrid(DataGridView g)
        {
            g.Columns.Clear();
            g.Rows.Clear();

            g.AutoGenerateColumns = false;
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Theme.Border;

            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 46;
            g.ColumnHeadersDefaultCellStyle.BackColor = Theme.Bg;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Muted;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Bg;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Theme.Muted;
            g.ColumnHeadersDefaultCellStyle.Font = Theme.MakeFont(9F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.AllowUserToResizeColumns = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.ShowCellToolTips = true;
            g.ScrollBars = ScrollBars.Vertical;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            g.RowTemplate.Height = 56;
            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.ForeColor = Theme.Text;
            g.DefaultCellStyle.Font = Theme.MakeFont(10F);
            g.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            g.DefaultCellStyle.SelectionBackColor = Theme.OrangeSoft;
            g.DefaultCellStyle.SelectionForeColor = Theme.Text;
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 254);
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = Theme.OrangeSoft;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Theme.Text;

            // smoother painting
            PropertyInfo? doubleBuffered = typeof(DataGridView).GetProperty(
                "DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            if (doubleBuffered != null) doubleBuffered.SetValue(g, true, null);
        }

        public static void AddColumn(DataGridView g, string name, string header, float weight,
                                     bool rightAligned = false, bool bold = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = header.ToUpper();
            col.FillWeight = weight;
            col.MinimumWidth = 80;
            col.ReadOnly = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (rightAligned)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (bold)
            {
                col.DefaultCellStyle.Font = Theme.MakeFont(10F, FontStyle.Bold);
                col.DefaultCellStyle.ForeColor = Theme.Navy;
            }
            g.Columns.Add(col);
        }

        /// <summary>
        /// Draws the Status column as a coloured pill. Each row's Tag must hold its MaintenanceRequest.
        /// </summary>
        public static void AttachStatusPills(DataGridView g, string statusColumnName)
        {
            Font pillFont = Theme.MakeFont(9F, FontStyle.Bold);

            g.CellPainting += delegate (object? sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null) return;
                if (g.Columns[e.ColumnIndex].Name != statusColumnName) return;

                MaintenanceRequest? request = g.Rows[e.RowIndex].Tag as MaintenanceRequest;
                if (request == null) return;

                e.PaintBackground(e.CellBounds, true);

                Color back;
                Color fore;
                AdminUi.StatusColors(request.Status, out back, out fore);
                string text = AdminUi.StatusText(request.Status);

                Size textSize = TextRenderer.MeasureText(text, pillFont);
                int width = textSize.Width + 30;
                int height = 28;
                Rectangle pill = new Rectangle(
                    e.CellBounds.X + 10,
                    e.CellBounds.Y + (e.CellBounds.Height - height) / 2,
                    width, height);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = Theme.RoundRect(pill, height / 2f))
                using (SolidBrush brush = new SolidBrush(back))
                {
                    e.Graphics.FillPath(brush, path);
                }

                TextRenderer.DrawText(e.Graphics, text, pillFont, pill, fore,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

                e.Handled = true;
            };
        }

        // ------------------------------------------------------------------
        //  DATA HELPERS
        // ------------------------------------------------------------------
        public static Dictionary<string, string> ProviderNameLookup()
        {
            Dictionary<string, string> lookup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                foreach (var provider in DataManager.LoadServiceProviders())
                {
                    string fullName = (provider.FirstName + " " + provider.LastName).Trim();
                    lookup[provider.UserId.ToString()] = AdminUi.TitleCase(fullName);
                }
            }
            catch (Exception)
            {
                // No provider file yet - ids are shown as they are.
            }
            return lookup;
        }

        public static string ProviderName(string? assignedId, Dictionary<string, string> lookup)
        {
            if (string.IsNullOrWhiteSpace(assignedId) ||
                assignedId.Trim().Equals("Unassigned", StringComparison.OrdinalIgnoreCase))
            {
                return "Not yet assigned";
            }

            string key = assignedId.Trim();
            string? name;
            return lookup.TryGetValue(key, out name) ? name : AdminUi.TitleCase(key);
        }
    }
}
