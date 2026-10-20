using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HomeHero_2;

namespace Home_Hero
{
    /// <summary>
    /// Administrator "Services" page - the service catalogue with live pricing, demand,
    /// revenue and provider coverage for every service. Built entirely in code and fully responsive:
    /// the service cards re-flow into as many columns as the window allows.
    /// </summary>
    public class frmAdminServices : FitForm
    {
        private sealed class ServiceInfo
        {
            public string Name = "";
            public string Description = "";
            public Color Accent;
            public decimal Estimate;
            public decimal CallOut;
            public int Open;
            public int Completed;
            public decimal Revenue;
            public int Providers;
        }

        private static readonly string[,] Known =
        {
            { "Electrical", "Wiring, sockets, DB boards, lighting upgrades and fault finding by certified electricians." },
            { "Plumbing", "Leaking taps and pipes, geysers, blocked drains, toilets and burst-pipe emergencies." },
            { "Appliance Repair", "Fridges, washing machines, ovens, dishwashers and other household appliances." },
            { "Painting", "Interior and exterior painting, plastering, wall repairs and damp-proof finishing." },
            { "General Maintenance", "Doors, windows, locks, tiles, gates, fences and the everyday handyman jobs." }
        };

        // ---- state ----
        private List<ServiceInfo> services = new List<ServiceInfo>();
        private List<MaintenanceRequest> allRequests = new List<MaintenanceRequest>();
        private Dictionary<string, string> providerNames = new Dictionary<string, string>();
        private readonly Dictionary<string, CardPanel> cards = new Dictionary<string, CardPanel>();
        private string? selected;

        // ---- controls ----
        private FlowLayoutPanel flowCards = null!;
        private DataGridView dgvServiceRequests = null!;
        private Label lblLedgerTitle = null!;
        private Label lblLedgerSub = null!;
        private ModernButton btnShowAll = null!;
        private Label lblEmpty = null!;
        private Label lblStatServices = null!;
        private Label lblStatRequests = null!;
        private Label lblStatRevenue = null!;
        private Label lblStatProviders = null!;
        private Label lblStatServicesHint = null!;
        private Label lblStatRequestsHint = null!;
        private Label lblStatRevenueHint = null!;
        private Label lblStatProvidersHint = null!;

        public frmAdminServices()
        {
            ScrollWholeForm = false;
            Text = "Services";
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            AdminUi.CreateShell(this);
            BuildUi();
            LoadData();
        }

        // ==================================================================
        //  UI
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();

            Panel body = new Panel();
            body.AutoScroll = true;
            body.Padding = new Padding(32, 22, 32, 22);

            // title
            Panel titleHolder = new Panel();
            titleHolder.Dock = DockStyle.Top;
            titleHolder.Height = 92;
            titleHolder.BackColor = Color.Transparent;
            titleHolder.Controls.Add(AdminUi.PageTitle("Service Catalogue", "Everything Home Hero offers - pricing, demand and provider coverage at a glance"));

            // stats
            CardPanel c1 = AdminUi.StatCard("Services Offered", "Categories customers can book", Theme.Navy, out lblStatServices, out lblStatServicesHint);
            CardPanel c2 = AdminUi.StatCard("Total Requests", "Across all services", Theme.Orange, out lblStatRequests, out lblStatRequestsHint);
            CardPanel c3 = AdminUi.StatCard("Service Revenue", "From completed jobs", Theme.Green, out lblStatRevenue, out lblStatRevenueHint);
            CardPanel c4 = AdminUi.StatCard("Providers", "Registered service providers", Theme.Blue, out lblStatProviders, out lblStatProvidersHint);
            Panel statHolder = new Panel();
            statHolder.Dock = DockStyle.Top;
            statHolder.Height = 162;
            statHolder.Padding = new Padding(0, 0, 0, 12);
            statHolder.BackColor = Color.Transparent;
            statHolder.Controls.Add(AdminUi.StatRow(4, c1, c2, c3, c4));

            // responsive card flow
            flowCards = new FlowLayoutPanel();
            flowCards.Dock = DockStyle.Top;
            flowCards.AutoSize = true;
            flowCards.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowCards.WrapContents = true;
            flowCards.BackColor = Color.Transparent;
            flowCards.Padding = new Padding(0, 6, 0, 0);
            flowCards.Resize += delegate { ResizeCards(); };

            // ledger
            CardPanel ledger = BuildLedger();
            ledger.Dock = DockStyle.Top;
            ledger.Height = 620;

            // docking order: first added sits lowest
            body.Controls.Add(ledger);
            body.Controls.Add(flowCards);
            body.Controls.Add(statHolder);
            body.Controls.Add(titleHolder);

            AdminUi.ApplyChrome(this, "lnklblServices", body);
            ResumeLayout(true);
        }

        private CardPanel BuildLedger()
        {
            CardPanel card = new CardPanel();
            card.Padding = new Padding(22, 92, 22, 34);

            lblLedgerTitle = Theme.MakeLabel("All service requests", 14F, FontStyle.Bold, Theme.Navy);
            lblLedgerTitle.Location = new Point(28, 22);
            lblLedgerSub = Theme.MakeLabel("", 9.5F, FontStyle.Regular, Theme.Muted);
            lblLedgerSub.Location = new Point(30, 54);

            btnShowAll = new ModernButton();
            btnShowAll.Text = "Show all services";
            btnShowAll.Outline = true;
            btnShowAll.BaseColor = Theme.Navy;
            btnShowAll.Size = new Size(190, 44);
            btnShowAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowAll.Visible = false;
            btnShowAll.Click += delegate { SelectService(null); };
            card.Resize += delegate { btnShowAll.Location = new Point(card.Width - btnShowAll.Width - 34, 24); };

            dgvServiceRequests = new DataGridView();
            AdminUi.StyleGrid(dgvServiceRequests);
            dgvServiceRequests.Columns.Add(Col("colSvcNo", "Request No.", 24));
            dgvServiceRequests.Columns.Add(Col("colSvcService", "Service", 16));
            dgvServiceRequests.Columns.Add(Col("colSvcCustomer", "Customer", 10));
            dgvServiceRequests.Columns.Add(Col("colSvcProvider", "Provider", 18));
            dgvServiceRequests.Columns.Add(Col("colSvcDate", "Preferred Date", 12));
            dgvServiceRequests.Columns.Add(Col("colSvcStatus", "Status", 16));
            dgvServiceRequests.Columns.Add(Col("colSvcEstimate", "Estimate", 12));
            dgvServiceRequests.Columns["colSvcNo"]!.DefaultCellStyle.Font = Theme.MakeFont(10F, FontStyle.Bold);
            AdminUi.RightAlign(dgvServiceRequests.Columns["colSvcEstimate"]!);
            dgvServiceRequests.CellPainting += dgvServiceRequests_CellPainting;

            lblEmpty = Theme.MakeLabel("No requests for this service yet.", 11F, FontStyle.Regular, Theme.Muted);
            lblEmpty.AutoSize = false;
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.BackColor = Color.White;
            lblEmpty.Visible = false;

            card.Controls.Add(lblEmpty);
            card.Controls.Add(dgvServiceRequests);
            card.Controls.Add(lblLedgerTitle);
            card.Controls.Add(lblLedgerSub);
            card.Controls.Add(btnShowAll);
            dgvServiceRequests.BringToFront();
            return card;
        }

        private static DataGridViewTextBoxColumn Col(string name, string header, float weight)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.Name = name;
            c.HeaderText = header;
            c.FillWeight = weight;
            c.MinimumWidth = 100;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
            return c;
        }

        // ==================================================================
        //  DATA
        // ==================================================================
        private static Color AccentFor(string name)
        {
            switch (name)
            {
                case "Electrical": return Theme.Amber;
                case "Plumbing": return Theme.Blue;
                case "Appliance Repair": return Theme.Purple;
                case "Painting": return Theme.Orange;
                case "General Maintenance": return Theme.Green;
                default: return Theme.Navy;
            }
        }

        private void LoadData()
        {
            allRequests = DataManager.LoadRequests();
            List<ServiceProvider> providers = DataManager.LoadServiceProviders();

            providerNames = new Dictionary<string, string>();
            foreach (ServiceProvider p in providers)
                providerNames[p.UserId.ToString().ToLowerInvariant()] = AdminUi.TitleCase(p.FirstName + " " + p.LastName);

            // catalogue = the known services + any extra category found in the data
            List<string[]> catalogue = new List<string[]>();
            for (int i = 0; i < Known.GetLength(0); i++) catalogue.Add(new[] { Known[i, 0], Known[i, 1] });
            foreach (string extra in allRequests.Select(r => r.ServiceCategory)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase))
            {
                if (!catalogue.Any(c => string.Equals(c[0], extra, StringComparison.OrdinalIgnoreCase)))
                    catalogue.Add(new[] { extra, "Custom service category requested by customers." });
            }

            MaintenanceRequest calc = new MaintenanceRequest();
            decimal callOut = calc.CalculateEstimatedCost("");

            services = new List<ServiceInfo>();
            foreach (string[] c in catalogue)
            {
                ServiceInfo s = new ServiceInfo();
                s.Name = c[0];
                s.Description = c[1];
                s.Accent = AccentFor(c[0]);
                s.Estimate = calc.CalculateEstimatedCost(c[0]);
                s.CallOut = callOut;

                List<MaintenanceRequest> mine = allRequests
                    .Where(r => string.Equals(r.ServiceCategory, s.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                s.Open = mine.Count(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled);
                s.Completed = mine.Count(r => r.Status == RequestStatus.Completed);
                s.Revenue = mine.Where(r => r.Status == RequestStatus.Completed).Sum(r => r.FinalCost);
                s.Providers = providers.Count(p => p.Specialisation != null &&
                    p.Specialisation.Any(x => string.Equals(x, s.Name, StringComparison.OrdinalIgnoreCase)));
                services.Add(s);
            }

            // stats
            lblStatServices.Text = services.Count.ToString();
            lblStatRequests.Text = allRequests.Count.ToString();
            lblStatRevenue.Text = AdminUi.Money(services.Sum(s => s.Revenue));
            lblStatProviders.Text = providers.Count.ToString();
            int uncovered = services.Count(s => s.Providers == 0);
            lblStatProvidersHint.Text = uncovered == 0 ? "Every service has coverage" : uncovered + (uncovered == 1 ? " service has" : " services have") + " no provider";

            BuildCards();
            SelectService(selected);
        }

        // ==================================================================
        //  SERVICE CARDS
        // ==================================================================
        private void BuildCards()
        {
            flowCards.SuspendLayout();
            foreach (Control c in flowCards.Controls.Cast<Control>().ToList())
            {
                flowCards.Controls.Remove(c);
                c.Dispose();
            }
            cards.Clear();

            int maxProviders = Math.Max(1, services.Max(s => s.Providers));
            foreach (ServiceInfo s in services)
            {
                CardPanel card = MakeCard(s, maxProviders);
                cards[s.Name] = card;
                flowCards.Controls.Add(card);
            }
            flowCards.ResumeLayout(true);
            ResizeCards();
        }

        private CardPanel MakeCard(ServiceInfo s, int maxProviders)
        {
            CardPanel card = new CardPanel();
            card.Size = new Size(380, 420);
            card.Margin = new Padding(0, 0, 14, 14);
            card.AccentColor = s.Accent;
            card.Padding = new Padding(26, 18, 22, 22);
            card.Tag = s.Name;
            card.AutoScroll = true;

            TableLayoutPanel stack = new TableLayoutPanel();
            stack.Dock = DockStyle.Top;
            stack.AutoSize = true;
            stack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            stack.BackColor = Color.White;
            stack.ColumnCount = 1;
            stack.RowCount = 6;
            stack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            stack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            stack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            stack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));

            Panel header = new Panel();
            header.Dock = DockStyle.Fill;
            header.BackColor = Color.White;
            AvatarCircle icon = new AvatarCircle();
            icon.Size = new Size(56, 56);
            icon.Initials = AdminUi.Initials(s.Name);
            icon.Location = new Point(0, 4);

            Label name = Theme.MakeLabel(s.Name, 14F, FontStyle.Bold, Theme.Navy);
            name.AutoSize = false;
            name.AutoEllipsis = true;
            name.Size = new Size(240, 30);
            name.Location = new Point(68, 0);
            name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            PillLabel price = new PillLabel();
            price.PillText = "From " + AdminUi.Money(s.Estimate).Replace(".00", "");
            price.PillBack = Color.FromArgb(
                Math.Min(255, s.Accent.R + (255 - s.Accent.R) * 85 / 100),
                Math.Min(255, s.Accent.G + (255 - s.Accent.G) * 85 / 100),
                Math.Min(255, s.Accent.B + (255 - s.Accent.B) * 85 / 100));
            price.PillFore = s.Accent;
            price.Size = new Size(150, 30);
            price.Location = new Point(68, 34);
            header.Controls.Add(icon);
            header.Controls.Add(name);
            header.Controls.Add(price);

            Label desc = Theme.MakeLabel(s.Description, 9.5F, FontStyle.Regular, Theme.Muted);
            desc.AutoSize = true;
            desc.MaximumSize = new Size(320, 0);
            desc.Margin = new Padding(0, 6, 0, 4);

            Label breakdown = Theme.MakeLabel("Call-out " + AdminUi.Money(s.CallOut).Replace(".00", "") +
                "  +  base rate " + AdminUi.Money(s.Estimate - s.CallOut).Replace(".00", ""), 9F, FontStyle.Bold, Theme.Text);
            breakdown.AutoSize = true;
            breakdown.MaximumSize = new Size(320, 0);
            breakdown.Margin = new Padding(0, 2, 0, 8);

            TableLayoutPanel stats = new TableLayoutPanel();
            stats.Dock = DockStyle.Fill;
            stats.BackColor = Color.Transparent;
            stats.ColumnCount = 3;
            stats.RowCount = 1;
            stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            stats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            stats.Controls.Add(StatCell("OPEN", s.Open.ToString(), Theme.Orange), 0, 0);
            stats.Controls.Add(StatCell("DONE", s.Completed.ToString(), Theme.Green), 1, 0);
            stats.Controls.Add(StatCell("REVENUE", AdminUi.Money(s.Revenue).Replace(".00", ""), Theme.Navy), 2, 0);

            Label cover = Theme.MakeLabel(s.Providers + (s.Providers == 1 ? " provider covers this service" : " providers cover this service"),
                9F, FontStyle.Regular, s.Providers == 0 ? Theme.Red : Theme.Muted);
            cover.AutoSize = true;
            cover.MaximumSize = new Size(320, 0);
            cover.Margin = new Padding(0, 6, 0, 4);

            MeterBar meter = new MeterBar();
            meter.Dock = DockStyle.Fill;
            meter.BarColor = s.Providers == 0 ? Theme.Red : s.Accent;
            meter.Value = s.Providers == 0 ? 4 : Math.Max(12, s.Providers * 100 / maxProviders);

            stack.Controls.Add(header, 0, 0);
            stack.Controls.Add(desc, 0, 1);
            stack.Controls.Add(breakdown, 0, 2);
            stack.Controls.Add(stats, 0, 3);
            stack.Controls.Add(cover, 0, 4);
            stack.Controls.Add(meter, 0, 5);
            card.Controls.Add(stack);

            Action layoutCard = delegate
            {
                int contentWidth = Math.Max(120,
                    card.ClientSize.Width - card.Padding.Horizontal
                    - (card.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0));
                stack.Width = contentWidth;
                name.Width = Math.Max(60, contentWidth - name.Left);
                desc.MaximumSize = new Size(contentWidth, 0);
                breakdown.MaximumSize = new Size(contentWidth, 0);
                cover.MaximumSize = new Size(contentWidth, 0);
            };
            card.Resize += delegate { layoutCard(); };
            layoutCard();

            string key = s.Name;
            AdminUi.MakeClickable(card, delegate { SelectService(selected == key ? null : key); });
            foreach (Control inner in stats.Controls)
            {
                inner.Cursor = Cursors.Hand;
                inner.Click += delegate { SelectService(selected == key ? null : key); };
                foreach (Control leaf in inner.Controls)
                {
                    leaf.Cursor = Cursors.Hand;
                    leaf.Click += delegate { SelectService(selected == key ? null : key); };
                }
            }
            return card;
        }

        private Control StatCell(string caption, string value, Color color)
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Fill;
            p.BackColor = Color.Transparent;

            Label cap = Theme.MakeLabel(caption, 8F, FontStyle.Bold, Theme.Muted);
            cap.Location = new Point(0, 0);

            Label val = Theme.MakeLabel(value, 12.5F, FontStyle.Bold, color);
            val.AutoSize = false;
            val.AutoEllipsis = true;
            val.Location = new Point(0, 20);
            val.Size = new Size(120, 32);
            val.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            p.Controls.Add(cap);
            p.Controls.Add(val);
            return p;
        }

        /// <summary>Re-flows the cards so they always fill the width - 1, 2, 3 or more per row.</summary>
        private void ResizeCards()
        {
            if (flowCards == null || cards.Count == 0) return;

            float s = DeviceDpi / 96f;
            int usable = flowCards.ClientSize.Width - flowCards.Padding.Horizontal;
            int gap = (int)(14 * s);
            int minWidth = (int)(380 * s);
            int cols = Math.Max(1, (usable + gap) / (minWidth + gap));
            int width = Math.Max((int)(300 * s), (usable - (cols - 1) * gap) / cols - 1);

            flowCards.SuspendLayout();
            foreach (CardPanel c in cards.Values)
            {
                if (c.Width != width) c.Width = width;
            }
            flowCards.ResumeLayout(true);
        }

        // ==================================================================
        //  SELECTION + LEDGER
        // ==================================================================
        private void SelectService(string? name)
        {
            selected = name;

            foreach (KeyValuePair<string, CardPanel> kv in cards)
            {
                bool on = kv.Key == name;
                kv.Value.BorderColor = on ? Theme.Orange : Theme.Border;
                kv.Value.FillColor = on ? Color.FromArgb(255, 250, 247) : Color.White;
                kv.Value.Invalidate();
            }

            IEnumerable<MaintenanceRequest> q = allRequests;
            if (name != null)
                q = q.Where(r => string.Equals(r.ServiceCategory, name, StringComparison.OrdinalIgnoreCase));
            List<MaintenanceRequest> list = q.OrderByDescending(r => r.PreferredDate).ToList();

            lblLedgerTitle.Text = name == null ? "All service requests" : name + " requests";
            lblLedgerSub.Text = name == null
                ? "Click a service card above to see only that service's requests"
                : list.Count + (list.Count == 1 ? " request" : " requests") + " for this service";
            btnShowAll.Visible = name != null;

            dgvServiceRequests.Rows.Clear();
            foreach (MaintenanceRequest r in list)
            {
                int i = dgvServiceRequests.Rows.Add(r.RequestNumber, r.ServiceCategory, r.CustomerId, ProviderLabel(r.AssignedProviderId),
                    r.PreferredDate.ToString("dd MMM yyyy"), AdminUi.StatusText(r.Status), AdminUi.Money(r.EstimatedCost));
                dgvServiceRequests.Rows[i].Cells["colSvcStatus"].Tag = r.Status;
            }
            dgvServiceRequests.ClearSelection();
            dgvServiceRequests.Visible = list.Count > 0;
            lblEmpty.Visible = list.Count == 0;
            lblEmpty.Text = name == null ? "No requests have been submitted yet." : "No requests for " + name + " yet.";
        }

        private string ProviderLabel(string? assigned)
        {
            if (string.IsNullOrWhiteSpace(assigned) || assigned == "Unassigned") return "Unassigned";
            string name;
            if (providerNames.TryGetValue(assigned.Trim().ToLowerInvariant(), out name)) return name;
            return assigned;
        }

        private void dgvServiceRequests_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvServiceRequests.Columns[e.ColumnIndex].Name != "colSvcStatus") return;

            object? tag = dgvServiceRequests.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
            if (!(tag is RequestStatus)) return;

            RequestStatus st = (RequestStatus)tag;
            Color back;
            Color fore;
            AdminUi.StatusColors(st, out back, out fore);
            AdminUi.PaintPillCell(e, AdminUi.StatusText(st), back, fore);
        }
    }
}
