using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using HomeHero_2;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    // =====================================================================
    //  ADMIN UI  - shared look & feel for every Administrator screen
    //  (header, navigation bar, stat tiles, grids, charts, toast, CSV export)
    // =====================================================================
    internal static class AdminUi
    {
        public static string Money(decimal value)
        {
            return "R " + value.ToString("#,##0.00", CultureInfo.InvariantCulture);
        }

        public static string TitleCase(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.Trim().ToLower());
        }

        /// <summary>True when a request's assigned provider is this provider (matched by name or id).</summary>
        public static bool IsAssignedTo(MaintenanceRequest r, ServiceProvider p)
        {
            if (r == null || p == null || string.IsNullOrWhiteSpace(r.AssignedProviderId)) return false;
            string assigned = r.AssignedProviderId.Trim();
            if (string.Equals(assigned, p.UserId.ToString(), StringComparison.OrdinalIgnoreCase)) return true;
            return string.Equals(assigned, (p.FirstName + " " + p.LastName).Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public static string Initials(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "?";
            string[] parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0].Substring(0, 1).ToUpper();
            return (parts[0].Substring(0, 1) + parts[parts.Length - 1].Substring(0, 1)).ToUpper();
        }

        // ------------------------------------------------------------------
        //  Request-status look (shared by Requests + Reports)
        // ------------------------------------------------------------------
        public static string StatusText(RequestStatus s)
        {
            switch (s)
            {
                case RequestStatus.ProviderAssigned: return "Provider Assigned";
                case RequestStatus.InProgress: return "In Progress";
                default: return s.ToString();
            }
        }

        public static void StatusColors(RequestStatus s, out Color back, out Color fore)
        {
            switch (s)
            {
                case RequestStatus.Requested: back = Theme.AmberSoft; fore = Theme.Amber; break;
                case RequestStatus.Approved: back = Theme.BlueSoft; fore = Theme.Blue; break;
                case RequestStatus.ProviderAssigned: back = Theme.PurpleSoft; fore = Theme.Purple; break;
                case RequestStatus.Scheduled: back = Color.FromArgb(207, 250, 254); fore = Color.FromArgb(14, 116, 144); break;
                case RequestStatus.InProgress: back = Theme.OrangeSoft; fore = Theme.Orange; break;
                case RequestStatus.Completed: back = Theme.GreenSoft; fore = Theme.Green; break;
                default: back = Theme.RedSoft; fore = Theme.Red; break;
            }
        }

        // ------------------------------------------------------------------
        //  Page chrome: gradient header + tab navigation + scrolling body
        // ------------------------------------------------------------------
        /// <summary>Scale everything by the real screen DPI so text is never clipped by fixed pixel sizes.</summary>
        public static void UseDpiScaling(Form f)
        {
            f.AutoScaleMode = AutoScaleMode.Dpi;
            f.AutoScaleDimensions = new SizeF(96F, 96F);
        }

        public static void ApplyChrome(Form f, string activeLinkName, Control body)
        {
            UseDpiScaling(f);
            f.SuspendLayout();
            f.BackColor = Theme.Bg;

            // ---------- header ----------
            GradientPanel? header = f.Controls.Find("pnlNavigationAdminPanl", true).FirstOrDefault() as GradientPanel;
            if (header != null)
            {
                string photoResource = activeLinkName == "lnklblRequests"
                    ? "How to Handle Maintenance Requests Efficiently as___"
                    : activeLinkName == "lnklblProviders"
                        ? "Home Care Concierges"
                        : activeLinkName == "lnklblServices"
                            ? "20+ Essential Home Maintenance Services to Keep Your Space Sparkling and Safe!"
                            : activeLinkName == "lnklblReports"
                                ? "Reliable Building Maintenance Services in Irvine"
                                : "8 Home Maintenance Jobs That MUST Be Done Once A Year - NewsBreak";
                header.Photo = UiAssets.GetImage(photoResource);
                header.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                header.Dock = DockStyle.Top;
                header.Height = 100;

                Control? shield = Child(header, "pictureBox1");
                if (shield != null) shield.Visible = false;
                Control? dashTitle = Child(header, "lblAdminDashboard");
                if (dashTitle != null) dashTitle.Visible = false;

                PictureBox? logo = Child(header, "pbxHomeHeroLogo") as PictureBox;
                if (logo != null)
                {
                    logo.SizeMode = PictureBoxSizeMode.Zoom;
                    logo.Size = new Size(54, 54);
                    logo.Location = new Point(36, 22);
                }

                Label? home = Child(header, "lblHome") as Label;
                Label? hero = Child(header, "lblHero") as Label;
                if (home != null && hero != null)
                {
                    home.BackColor = Color.Transparent;
                    hero.BackColor = Color.Transparent;
                    home.Font = Theme.MakeFont(18F, FontStyle.Bold);
                    hero.Font = Theme.MakeFont(18F, FontStyle.Bold);
                    home.ForeColor = Color.White;
                    hero.ForeColor = Theme.Orange;
                    home.Location = new Point(102, 18);
                    hero.Location = new Point(home.Left + home.PreferredWidth - 8, 18);
                }

                Label? tag = Child(header, "label16") as Label;
                if (tag != null)
                {
                    tag.BackColor = Color.Transparent;
                    tag.Font = Theme.MakeFont(9F, FontStyle.Bold);
                    tag.ForeColor = Theme.Orange;
                    tag.Text = "ADMINISTRATOR  |  DASHBOARD";
                    tag.Location = new Point(106, 58);
                }

                Label? portal = Child(header, "lblAdminPortal") as Label;
                Button? exit = Child(header, "btnExitAdmin") as Button;
                if (portal != null)
                {
                    portal.BackColor = Color.Transparent;
                    portal.Font = Theme.MakeFont(12F, FontStyle.Regular);
                    portal.ForeColor = Color.FromArgb(190, 205, 230);
                }
                ModernButton? modernExit = exit as ModernButton;
                if (modernExit != null)
                {
                    modernExit.BaseColor = Color.FromArgb(34, 62, 118);
                    modernExit.HoverColor = Theme.Orange;
                    modernExit.TextColor = Color.White;
                    modernExit.BorderColor = Color.FromArgb(88, 116, 168);
                    modernExit.Radius = 12;
                    modernExit.Font = Theme.MakeSemibold(10.5F);
                    modernExit.Size = new Size(176, 46);
                }
                else if (exit != null)
                {
                    exit.FlatStyle = FlatStyle.Flat;
                    exit.UseVisualStyleBackColor = false;
                    exit.BackColor = Color.FromArgb(34, 62, 118);
                    exit.ForeColor = Color.White;
                    exit.Font = Theme.MakeSemibold(10.5F);
                    exit.FlatAppearance.BorderSize = 1;
                    exit.FlatAppearance.BorderColor = Color.FromArgb(88, 116, 168);
                    exit.FlatAppearance.MouseOverBackColor = Theme.Orange;
                    exit.FlatAppearance.MouseDownBackColor = Theme.OrangeHover;
                    exit.Cursor = Cursors.Hand;
                    exit.Size = new Size(176, 46);
                }

                EventHandler place = delegate
                {
                    if (exit != null)
                    {
                        exit.Left = header.ClientSize.Width - exit.Width - 36;
                        exit.Top = (header.ClientSize.Height - exit.Height) / 2;
                    }
                    if (portal != null && exit != null)
                    {
                        portal.Left = exit.Left - portal.Width - 20;
                        portal.Top = (header.ClientSize.Height - portal.Height) / 2;
                    }
                };
                header.Resize += place;
                place(header, EventArgs.Empty);
            }

            // ---------- tab navigation ----------
            Control? oldNav = f.Controls.Find("tableLayoutPanel1", true).FirstOrDefault();
            string[] order = { "lnklblOverView", "lnklblRequests", "lnklblProviders", "lnklblServices", "lnklblReports" };

            Panel navBar = new Panel();
            navBar.Dock = DockStyle.Top;
            navBar.Height = 60;
            navBar.BackColor = Color.White;
            navBar.Paint += delegate (object? s, PaintEventArgs e)
            {
                using (Pen p = new Pen(Theme.Border, 1f))
                    e.Graphics.DrawLine(p, 0, navBar.Height - 1, navBar.Width, navBar.Height - 1);
            };

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.WrapContents = false;
            flow.FlowDirection = FlowDirection.LeftToRight;
            flow.Padding = new Padding(26, 0, 0, 0);
            flow.BackColor = Color.White;

            Label date = new Label();
            date.Dock = DockStyle.Right;
            date.Width = 360;
            date.TextAlign = ContentAlignment.MiddleRight;
            date.Font = Theme.MakeFont(9.5F);
            date.ForeColor = Theme.Muted;
            date.BackColor = Color.White;
            date.Padding = new Padding(0, 0, 36, 0);
            date.Text = DateTime.Now.ToString("dddd, d MMMM yyyy", CultureInfo.CurrentCulture);

            foreach (string name in order)
            {
                LinkLabel? link = f.Controls.Find(name, true).FirstOrDefault() as LinkLabel;
                if (link == null) continue;

                bool active = name == activeLinkName;
                Color rest = active ? Theme.Orange : Theme.Navy;

                link.AutoSize = false;
                link.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                link.Font = Theme.MakeSemibold(11.5F);
                link.LinkBehavior = LinkBehavior.NeverUnderline;
                link.LinkColor = rest;
                link.VisitedLinkColor = rest;
                link.ActiveLinkColor = Theme.OrangeHover;
                link.TextAlign = ContentAlignment.MiddleCenter;
                link.BackColor = active ? Color.FromArgb(255, 247, 243) : Color.White;
                link.Margin = new Padding(2, 0, 2, 0);
                link.Height = navBar.Height - 1;
                link.Width = TextRenderer.MeasureText(link.Text, link.Font).Width + 52;
                link.Cursor = Cursors.Hand;

                LinkLabel captured = link;
                link.MouseEnter += delegate { captured.LinkColor = Theme.Orange; };
                link.MouseLeave += delegate { captured.LinkColor = rest; };
                if (active)
                {
                    link.Paint += delegate (object? s, PaintEventArgs e)
                    {
                        using (SolidBrush b = new SolidBrush(Theme.Orange))
                            e.Graphics.FillRectangle(b, 14, captured.Height - 4, captured.Width - 28, 4);
                    };
                }
                if (name == "lnklblServices" && !(f is frmAdminServices))
                    link.LinkClicked += delegate { Navigate(f, "lnklblServices"); };

                flow.Controls.Add(link);
            }

            navBar.Controls.Add(flow);
            navBar.Controls.Add(date);
            flow.BringToFront();

            if (oldNav != null)
            {
                oldNav.Dock = DockStyle.None;
                oldNav.Visible = false;
            }

            // ---------- body ----------
            body.Dock = DockStyle.Fill;
            body.BackColor = Theme.Bg;

            f.Controls.Add(body);
            f.Controls.Add(navBar);
            body.BringToFront();
            navBar.SendToBack();
            if (header != null) header.SendToBack();

            f.ResumeLayout(true);
        }

        private static Control? Child(Control parent, string name)
        {
            return parent.Controls.Find(name, true).FirstOrDefault();
        }

        // ------------------------------------------------------------------
        //  Navigation shared by every admin page
        // ------------------------------------------------------------------
        public static void Navigate(Form from, string linkName)
        {
            Form? next = null;
            switch (linkName)
            {
                case "lnklblOverView": if (!(from is frmAdminDashboard)) next = new frmAdminDashboard(); break;
                case "lnklblRequests": if (!(from is RequestManagement)) next = new RequestManagement(); break;
                case "lnklblProviders": if (!(from is frmProviderManagement)) next = new frmProviderManagement(); break;
                case "lnklblServices": if (!(from is frmAdminServices)) next = new frmAdminServices(); break;
                case "lnklblReports": if (!(from is frmReports)) next = new frmReports(); break;
            }
            if (next == null) return;
            from.Hide();
            next.Show();
        }

        public static void Logout(Form from)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                SignOutAndGoHome(from);
        }

        /// <summary>Ends the session and returns to a fresh homepage, closing every old (hidden) screen so a new login starts clean.</summary>
        public static void SignOutAndGoHome(Form from)
        {
            CustomerSession.SignOut();

            frmHomeHeroHomepage homepage = new frmHomeHeroHomepage();
            homepage.Show();

            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                if (f != homepage)
                    f.Close();
            }
        }

        /// <summary>
        /// Creates the standard header + navigation controls (same names the designer pages use)
        /// for pages that are built entirely in code. Call ApplyChrome afterwards.
        /// </summary>
        public static void CreateShell(Form f)
        {
            GradientPanel header = new GradientPanel();
            header.Name = "pnlNavigationAdminPanl";

            PictureBox logo = new PictureBox();
            logo.Name = "pbxHomeHeroLogo";
            logo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            logo.SizeMode = PictureBoxSizeMode.Zoom;

            Label home = new Label(); home.Name = "lblHome"; home.Text = "Home"; home.AutoSize = true;
            Label hero = new Label(); hero.Name = "lblHero"; hero.Text = "Hero"; hero.AutoSize = true;
            Label tag = new Label(); tag.Name = "label16"; tag.Text = "Administrator"; tag.AutoSize = true;
            Label portal = new Label(); portal.Name = "lblAdminPortal"; portal.Text = "Administrator Portal"; portal.AutoSize = true;
            Button exit = new ModernButton(); exit.Name = "btnExitAdmin"; exit.Text = "\u2190 Exit Admin";
            exit.Click += delegate { Logout(f); };

            header.Controls.Add(logo);
            header.Controls.Add(home);
            header.Controls.Add(hero);
            header.Controls.Add(tag);
            header.Controls.Add(portal);
            header.Controls.Add(exit);

            TableLayoutPanel holder = new TableLayoutPanel();
            holder.Name = "tableLayoutPanel1";
            string[,] links =
            {
                { "lnklblOverView", "Overview" }, { "lnklblRequests", "Requests" }, { "lnklblProviders", "Providers" },
                { "lnklblServices", "Services" }, { "lnklblReports", "Reports" }
            };
            for (int i = 0; i < links.GetLength(0); i++)
            {
                LinkLabel l = new LinkLabel();
                l.Name = links[i, 0];
                l.Text = links[i, 1];
                string target = links[i, 0];
                if (target != "lnklblServices")   // ApplyChrome wires the Services link itself
                    l.LinkClicked += delegate { Navigate(f, target); };
                holder.Controls.Add(l);
            }

            f.Controls.Add(header);
            f.Controls.Add(holder);
        }

        // ------------------------------------------------------------------
        //  Small builders
        // ------------------------------------------------------------------
        public static Panel PageTitle(string title, string subtitle)
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Fill;
            p.BackColor = Theme.Bg;

            Label t = Theme.MakeLabel(title, 22F, FontStyle.Bold, Theme.Navy);
            t.BackColor = Theme.Bg;
            t.Location = new Point(0, 2);
            p.Controls.Add(t);

            // the sentence under the heading is optional (pass "" to leave it out)
            if (!string.IsNullOrWhiteSpace(subtitle))
            {
                Label s = Theme.MakeLabel(subtitle, 10.5F, FontStyle.Regular, Color.FromArgb(71, 85, 105));
                s.BackColor = Theme.Bg;
                s.Location = new Point(3, 52);
                p.Controls.Add(s);
            }
            return p;
        }

        public static CardPanel StatCard(string caption, string hint, Color accent, out Label valueLabel, out Label hintLabel)
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 0, 14, 0);
            card.AccentColor = accent;
            float s = card.DeviceDpi / 96f;
            card.Padding = new Padding((int)(26 * s), (int)(14 * s), (int)(14 * s), (int)(22 * s));

            // caption / number / hint sit in auto-sized rows, so a big number or a longer
            // hint can never overlap or cut off the line next to it (at any Windows scaling)
            TableLayoutPanel stack = new TableLayoutPanel();
            stack.Dock = DockStyle.Fill;
            stack.BackColor = Color.Transparent;
            stack.ColumnCount = 1;
            stack.RowCount = 3;
            stack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            stack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            stack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            stack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label cap = Theme.MakeLabel(caption.ToUpperInvariant(), 8.5F, FontStyle.Bold, Theme.Muted);
            cap.Margin = new Padding(0, 2, 0, 0);

            valueLabel = Theme.MakeLabel("0", 24F, FontStyle.Bold, accent);
            valueLabel.Margin = new Padding(0, 0, 0, 0);

            hintLabel = Theme.MakeLabel(hint, 8.5F, FontStyle.Regular, Theme.Muted);
            hintLabel.Margin = new Padding(2, 0, 0, 0);
            Label hintRef = hintLabel;
            // long hints wrap onto a second line instead of running past the card
            stack.SizeChanged += delegate { hintRef.MaximumSize = new Size(Math.Max(40, stack.ClientSize.Width - 4), 0); };

            stack.Controls.Add(cap, 0, 0);
            stack.Controls.Add(valueLabel, 0, 1);
            stack.Controls.Add(hintLabel, 0, 2);
            card.Controls.Add(stack);
            return card;
        }

        /// <summary>Wires a click on the whole card (and its labels) to an action.</summary>
        public static void MakeClickable(Control card, Action action)
        {
            card.Cursor = Cursors.Hand;
            card.Click += delegate { action(); };
            foreach (Control c in card.Controls)
                MakeClickable(c, action);
        }

        public static TableLayoutPanel StatRow(int columns, params Control[] cards)
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = columns;
            row.RowCount = 1;
            for (int i = 0; i < columns; i++)
                row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            for (int i = 0; i < cards.Length; i++)
                row.Controls.Add(cards[i], i, 0);
            // last card has no right gap
            if (cards.Length > 0) cards[cards.Length - 1].Margin = new Padding(0);
            return row;
        }

        /// <summary>Puts a TextBox or ComboBox in a rounded frame with an orange focus ring.</summary>
        public static InputFrame Frame(Control inner, int width, int height)
        {
            TextBox? tb = inner as TextBox;
            if (tb != null)
            {
                tb.BorderStyle = BorderStyle.None;
                tb.Font = Theme.MakeFont(10.5F);
                tb.BackColor = Color.White;
                tb.ForeColor = Theme.Text;
            }
            ComboBox? cb = inner as ComboBox;
            if (cb != null)
            {
                cb.FlatStyle = FlatStyle.Flat;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.Font = Theme.MakeFont(10.5F);
                cb.BackColor = Color.White;
                cb.ForeColor = Theme.Text;
            }

            InputFrame frame = new InputFrame();
            frame.Size = new Size(width, height);
            frame.Margin = new Padding(0, 0, 12, 8);
            frame.Controls.Add(inner);
            return frame;
        }

        // ------------------------------------------------------------------
        //  Grid styling
        // ------------------------------------------------------------------
        public static void StyleGrid(DataGridView g)
        {
            typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(g, true, null);

            g.Dock = DockStyle.Fill;
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.GridColor = Color.FromArgb(238, 242, 247);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.EnableHeadersVisualStyles = false;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 48;
            g.RowTemplate.Height = 52;
            g.RowTemplate.MinimumHeight = 52;
            g.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;   // long text wraps instead of being cut off

            DataGridViewCellStyle head = new DataGridViewCellStyle();
            head.BackColor = Color.FromArgb(248, 250, 252);
            head.ForeColor = Theme.Muted;
            head.Font = Theme.MakeFont(9F, FontStyle.Bold);
            head.SelectionBackColor = Color.FromArgb(248, 250, 252);
            head.SelectionForeColor = Theme.Muted;
            head.Alignment = DataGridViewContentAlignment.MiddleLeft;
            head.Padding = new Padding(12, 0, 0, 0);
            g.ColumnHeadersDefaultCellStyle = head;

            DataGridViewCellStyle cell = new DataGridViewCellStyle();
            cell.BackColor = Color.White;
            cell.ForeColor = Theme.Text;
            cell.Font = Theme.MakeFont(10F);
            cell.SelectionBackColor = Theme.OrangeSoft;
            cell.SelectionForeColor = Theme.Navy;
            cell.Padding = new Padding(12, 8, 6, 8);
            cell.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cell.WrapMode = DataGridViewTriState.True;
            g.DefaultCellStyle = cell;

            // only the back colour differs - copying the whole cell style here would
            // override per-column fonts/alignment on every second row
            DataGridViewCellStyle alt = new DataGridViewCellStyle();
            alt.BackColor = Color.FromArgb(251, 252, 254);
            g.AlternatingRowsDefaultCellStyle = alt;
        }

        public static void RightAlign(DataGridViewColumn col)
        {
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Padding = new Padding(0, 0, 12, 0);
        }

        /// <summary>Draws a rounded status pill inside a grid cell.</summary>
        public static void PaintPillCell(DataGridViewCellPaintingEventArgs e, string text, Color back, Color fore)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.SelectionBackground);

            Graphics g = e.Graphics!;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font font = Theme.MakeSemibold(9F);
            Size sz = TextRenderer.MeasureText(g, text, font);
            float w = Math.Min(e.CellBounds.Width - 20, sz.Width + 30);
            float h = 28;
            RectangleF r = new RectangleF(e.CellBounds.X + 12, e.CellBounds.Y + (e.CellBounds.Height - h) / 2f, w, h);

            using (GraphicsPath path = Theme.RoundRect(r, h / 2f))
            using (SolidBrush b = new SolidBrush(back))
                g.FillPath(b, path);

            TextRenderer.DrawText(g, text, font, Rectangle.Round(r), fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
            e.Handled = true;
        }

        // ------------------------------------------------------------------
        //  Toast notification (replaces blocking "success" message boxes)
        // ------------------------------------------------------------------
        public static void Toast(Form f, string message, bool success = true)
        {
            PillLabel toast = new PillLabel();
            toast.Font = Theme.MakeSemibold(10.5F);
            toast.PillText = message;
            toast.PillBack = success ? Theme.Green : Theme.Red;
            toast.PillFore = Color.White;
            int w = TextRenderer.MeasureText(message, toast.Font).Width + 64;
            toast.Size = new Size(Math.Max(220, w), 52);
            toast.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            toast.Location = new Point(f.ClientSize.Width - toast.Width - 36, f.ClientSize.Height - toast.Height - 36);

            f.Controls.Add(toast);
            toast.BringToFront();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2800;
            timer.Tick += delegate
            {
                timer.Stop();
                timer.Dispose();
                f.Controls.Remove(toast);
                toast.Dispose();
            };
            timer.Start();
        }

        // ------------------------------------------------------------------
        //  CSV export (visible columns of any grid)
        // ------------------------------------------------------------------
        public static bool ExportGrid(Form owner, DataGridView g, string defaultName)
        {
            if (g.Rows.Count == 0)
            {
                Toast(owner, "Nothing to export yet", false);
                return false;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV file (*.csv)|*.csv";
                dlg.FileName = defaultName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
                if (dlg.ShowDialog(owner) != DialogResult.OK) return false;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    List<DataGridViewColumn> cols = g.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible).OrderBy(c => c.DisplayIndex).ToList();

                    sb.AppendLine(string.Join(",", cols.Select(c => Csv(c.HeaderText))));
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        sb.AppendLine(string.Join(",", cols.Select(c =>
                        {
                            object? v = row.Cells[c.Index].Value;
                            return Csv(v == null ? "" : Convert.ToString(v, CultureInfo.InvariantCulture));
                        })));
                    }
                    File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                    Toast(owner, "Exported " + g.Rows.Count + " rows to CSV");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The file could not be saved.\n\n" + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private static string Csv(string? value)
        {
            string v = value ?? "";
            if (v.Contains(",") || v.Contains("\"") || v.Contains("\n") || v.Contains("\r"))
                return "\"" + v.Replace("\"", "\"\"") + "\"";
            return v;
        }

        public static Color[] ChartPalette = new Color[]
        {
            Theme.Orange, Theme.Navy, Theme.Blue, Theme.Green, Theme.Purple, Theme.Amber
        };
    }

    // =====================================================================
    //  HORIZONTAL BAR CHART  - animated "revenue by service"
    // =====================================================================
    internal class HBarChart : Control
    {
        private readonly List<KeyValuePair<string, decimal>> items = new List<KeyValuePair<string, decimal>>();
        private readonly System.Windows.Forms.Timer anim = new System.Windows.Forms.Timer();
        private float progress = 1f;
        private int tick;

        public string EmptyText { get; set; } = "No data to show yet";
        public Func<decimal, string> ValueFormat { get; set; } = v => v.ToString("N0");

        public HBarChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
            anim.Interval = 16;
            anim.Tick += delegate
            {
                tick++;
                float t = Math.Min(1f, tick / 28f);
                progress = 1f - (float)Math.Pow(1f - t, 3);
                Invalidate();
                if (t >= 1f) anim.Stop();
            };
        }

        public void SetData(IEnumerable<KeyValuePair<string, decimal>> data)
        {
            items.Clear();
            items.AddRange(data);
            tick = 0;
            progress = 0f;
            anim.Start();
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) anim.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (items.Count == 0)
            {
                TextRenderer.DrawText(g, EmptyText, Theme.MakeFont(10.5F), ClientRectangle, Theme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            decimal max = items.Max(i => i.Value);
            if (max <= 0) max = 1;

            int n = items.Count;
            int labelW = 150;
            int valueW = 130;
            float rowH = Math.Min(54f, Height / (float)n);
            float barH = Math.Min(16f, rowH * 0.34f);
            float trackX = labelW;
            float trackW = Math.Max(40, Width - labelW - valueW);

            for (int i = 0; i < n; i++)
            {
                float y = i * rowH;
                float cy = y + rowH / 2f;
                Color c = AdminUi.ChartPalette[i % AdminUi.ChartPalette.Length];

                TextRenderer.DrawText(g, items[i].Key, Theme.MakeSemibold(10F),
                    new Rectangle(0, (int)y, labelW - 10, (int)rowH), Theme.Text,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine);

                RectangleF track = new RectangleF(trackX, cy - barH / 2f, trackW, barH);
                using (GraphicsPath tp = Theme.RoundRect(track, barH / 2f))
                using (SolidBrush tb = new SolidBrush(Color.FromArgb(238, 242, 247)))
                    g.FillPath(tb, tp);

                float w = trackW * (float)(items[i].Value / max) * progress;
                if (w >= barH)
                {
                    RectangleF bar = new RectangleF(trackX, cy - barH / 2f, w, barH);
                    using (GraphicsPath bp = Theme.RoundRect(bar, barH / 2f))
                    using (SolidBrush bb = new SolidBrush(c))
                        g.FillPath(bb, bp);
                }

                TextRenderer.DrawText(g, ValueFormat(items[i].Value), Theme.MakeSemibold(10F),
                    new Rectangle((int)(trackX + trackW + 8), (int)y, valueW - 8, (int)rowH), Theme.Navy,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
            }
        }
    }

    // =====================================================================
    //  DONUT CHART  - animated breakdown with legend
    // =====================================================================
    internal class DonutChart : Control
    {
        private class Slice
        {
            public string Label = "";
            public int Count;
            public Color Color;
        }

        private readonly List<Slice> slices = new List<Slice>();
        private readonly System.Windows.Forms.Timer anim = new System.Windows.Forms.Timer();
        private float progress = 1f;
        private int tick;

        public string CenterCaption { get; set; } = "requests";
        public string EmptyText { get; set; } = "No data to show yet";

        public DonutChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
            anim.Interval = 16;
            anim.Tick += delegate
            {
                tick++;
                float t = Math.Min(1f, tick / 32f);
                progress = 1f - (float)Math.Pow(1f - t, 3);
                Invalidate();
                if (t >= 1f) anim.Stop();
            };
        }

        public void Clear()
        {
            slices.Clear();
        }

        public void Add(string label, int count, Color color)
        {
            if (count <= 0) return;
            Slice s = new Slice();
            s.Label = label;
            s.Count = count;
            s.Color = color;
            slices.Add(s);
        }

        public void Start()
        {
            tick = 0;
            progress = 0f;
            anim.Start();
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) anim.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int total = slices.Sum(s => s.Count);
            int size = Math.Min(Height - 10, Math.Max(120, Width / 2 - 10));
            float thick = size * 0.17f;
            RectangleF ring = new RectangleF(10 + thick / 2f, (Height - size) / 2f + thick / 2f, size - thick, size - thick);

            using (Pen track = new Pen(Color.FromArgb(238, 242, 247), thick))
                g.DrawEllipse(track, ring);

            if (total > 0)
            {
                float start = -90f;
                foreach (Slice s in slices)
                {
                    float sweep = 360f * s.Count / total * progress;
                    using (Pen p = new Pen(s.Color, thick))
                    {
                        p.StartCap = LineCap.Flat;
                        p.EndCap = LineCap.Flat;
                        if (sweep > 0.5f)
                            g.DrawArc(p, ring, start, Math.Max(0.5f, sweep - (slices.Count > 1 ? 1.2f : 0f)));
                    }
                    start += sweep;
                }
            }

            Rectangle inner = Rectangle.Round(ring);
            Rectangle top = new Rectangle(inner.X, inner.Y + inner.Height / 2 - 32, inner.Width, 38);
            Rectangle bot = new Rectangle(inner.X, inner.Y + inner.Height / 2 + 6, inner.Width, 22);
            TextRenderer.DrawText(g, total.ToString(), Theme.MakeFont(22F, FontStyle.Bold), top, Theme.Navy,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            TextRenderer.DrawText(g, total == 0 ? EmptyText : CenterCaption, Theme.MakeFont(9F), bot, Theme.Muted,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // legend
            int lx = 10 + size + 28;
            int rowH = 34;
            int ly = Math.Max(0, (Height - slices.Count * rowH) / 2);
            foreach (Slice s in slices)
            {
                using (SolidBrush b = new SolidBrush(s.Color))
                    g.FillEllipse(b, lx, ly + 11, 12, 12);

                TextRenderer.DrawText(g, s.Label, Theme.MakeFont(10F), new Rectangle(lx + 22, ly, Math.Max(60, Width - lx - 110), rowH),
                    Theme.Text, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine);

                int pct = total == 0 ? 0 : (int)Math.Round(100.0 * s.Count / total);
                TextRenderer.DrawText(g, s.Count + "  (" + pct + "%)", Theme.MakeSemibold(10F),
                    new Rectangle(Width - 100, ly, 100, rowH), Theme.Navy,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                ly += rowH;
            }
        }
    }

    // =====================================================================
    //  AVATAR  - circular initials badge
    // =====================================================================
    internal class AvatarCircle : Control
    {
        private string initials = "?";
        public string Initials { get { return initials; } set { initials = value; Invalidate(); } }

        public AvatarCircle()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(76, 76);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF r = new RectangleF(1, 1, Width - 3, Height - 3);
            using (LinearGradientBrush br = new LinearGradientBrush(r, Theme.NavyLight, Theme.NavyDeep, 45f))
                g.FillEllipse(br, r);
            using (Pen ring = new Pen(Theme.Orange, 3f))
                g.DrawEllipse(ring, r);
            TextRenderer.DrawText(g, initials, Theme.MakeFont(Math.Max(10F, Width / 4.2F), FontStyle.Bold), ClientRectangle, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }
    }

    // =====================================================================
    //  PROVIDER PICKER  - used by "Reassign" on the request screen
    // =====================================================================
    internal class PickProviderDialog : FitForm
    {
        private readonly ComboBox combo = new ComboBox();
        private readonly List<ServiceProvider> providers;

        public string? SelectedProviderName { get; private set; }

        public PickProviderDialog(List<ServiceProvider> providers, string requestNumber, string category, string? current)
        {
            this.providers = providers;

            Text = "Assign Provider";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.White;
            ClientSize = new Size(520, 330);

            Label title = Theme.MakeLabel("Assign a service provider", 16F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(28, 24);

            Label sub = Theme.MakeLabel(requestNumber + "  |  " + category, 10F, FontStyle.Regular, Theme.Muted);
            sub.Location = new Point(30, 62);

            Label cur = Theme.MakeLabel("Currently: " + (string.IsNullOrWhiteSpace(current) ? "Unassigned" : current), 10F, FontStyle.Regular, Theme.Muted);
            cur.Location = new Point(30, 90);

            // providers whose specialisation matches the request are listed first
            List<ServiceProvider> ordered = providers
                .OrderByDescending(p => p.Specialisation != null && p.Specialisation.Any(s => string.Equals(s, category, StringComparison.OrdinalIgnoreCase)))
                .ThenBy(p => p.FirstName)
                .ToList();
            this.providers.Clear();
            this.providers.AddRange(ordered);

            foreach (ServiceProvider p in ordered)
            {
                bool match = p.Specialisation != null && p.Specialisation.Any(s => string.Equals(s, category, StringComparison.OrdinalIgnoreCase));
                string spec = p.Specialisation == null || p.Specialisation.Count == 0 ? "General" : string.Join(", ", p.Specialisation);
                combo.Items.Add((match ? "★  " : "      ") + AdminUi.TitleCase(p.FirstName + " " + p.LastName) + "   -   " + spec);
            }
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;

            InputFrame frame = AdminUi.Frame(combo, 464, 50);
            frame.Location = new Point(28, 128);
            frame.Margin = new Padding(0);

            Label hint = Theme.MakeLabel("★ = specialises in " + category, 9F, FontStyle.Regular, Theme.Orange);
            hint.Location = new Point(30, 188);

            ModernButton ok = new ModernButton();
            ok.Text = "Assign Provider";
            ok.Size = new Size(200, 48);
            ok.Location = new Point(292, 250);
            ok.Enabled = providers.Count > 0;
            ok.Click += delegate
            {
                if (combo.SelectedIndex < 0) return;
                ServiceProvider p = this.providers[combo.SelectedIndex];
                SelectedProviderName = AdminUi.TitleCase(p.FirstName + " " + p.LastName);
                DialogResult = DialogResult.OK;
                Close();
            };

            ModernButton cancel = new ModernButton();
            cancel.Text = "Cancel";
            cancel.Outline = true;
            cancel.BaseColor = Theme.Navy;
            cancel.Size = new Size(140, 48);
            cancel.Location = new Point(136, 250);
            cancel.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(title);
            Controls.Add(sub);
            Controls.Add(cur);
            Controls.Add(frame);
            Controls.Add(hint);
            Controls.Add(cancel);
            Controls.Add(ok);
            AcceptButton = ok;
            CancelButton = cancel;
        }
    }

    // =====================================================================
    //  CHIP TOGGLE  - selectable pill (used for specialisations)
    // =====================================================================
    internal class ChipToggle : Control
    {
        private bool isChecked;
        private bool hover;

        public event EventHandler? CheckedChanged;

        public bool Checked
        {
            get { return isChecked; }
            set
            {
                if (isChecked == value) return;
                isChecked = value;
                Invalidate();
                if (CheckedChanged != null) CheckedChanged(this, EventArgs.Empty);
            }
        }

        public ChipToggle(string text)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Font = Theme.MakeSemibold(10F);
            Text = text;
            Height = 42;
            Width = TextRenderer.MeasureText(text, Font).Width + 58;
            Margin = new Padding(0, 0, 10, 10);
        }

        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnClick(EventArgs e) { Checked = !Checked; base.OnClick(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF r = new RectangleF(1, 1, Width - 3, Height - 3);
            using (GraphicsPath path = Theme.RoundRect(r, r.Height / 2f))
            {
                using (SolidBrush b = new SolidBrush(isChecked ? Theme.Orange : (hover ? Theme.OrangeSoft : Color.White)))
                    g.FillPath(b, path);
                using (Pen p = new Pen(isChecked ? Theme.Orange : (hover ? Theme.Orange : Color.FromArgb(203, 213, 225)), 1.5f))
                    g.DrawPath(p, path);
            }

            string label = isChecked ? "\u2713  " + Text : Text;
            TextRenderer.DrawText(g, label, Font, ClientRectangle, isChecked ? Color.White : Theme.Navy,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }
    }
}
