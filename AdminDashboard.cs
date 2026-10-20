using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Home_Hero
{
    public partial class frmAdminDashboard : FitForm
    {
        // ---- new UI pieces (existing controls keep their original names) ----
        private Label lblStatTotal = null!;
        private Label lblStatPending = null!;
        private Label lblStatProviders = null!;
        private Label lblStatRevenue = null!;
        private Label lblStatRating = null!;
        private Label lblStatTotalHint = null!;
        private Label lblStatPendingHint = null!;
        private Label lblStatProvidersHint = null!;
        private Label lblStatRevenueHint = null!;
        private Label lblStatRatingHint = null!;

        private Label lblApprovedValue = null!;
        private Label lblCancelledValue = null!;
        private readonly Dictionary<RequestStatus, MeterBar> breakdownBars = new Dictionary<RequestStatus, MeterBar>();
        private readonly Dictionary<RequestStatus, Label> breakdownCounts = new Dictionary<RequestStatus, Label>();
        private Label lblBreakdownTotal = null!;

        private DataGridView dgvRecent = null!;
        private Label lblRecentEmpty = null!;
        private HBarChart barServices = null!;
        private Label lblServicesSub = null!;
        private Label lblSnapshot = null!;

        private TableLayoutPanel mainLayout = null!;
        private CardPanel alertCard = null!;
        private Label lblAlertText = null!;

        public frmAdminDashboard()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildUi();
            LoadData();
        }

        // ==================================================================
        //  UI CONSTRUCTION
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();

            Panel body = new Panel();
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1200, 1180);
            body.Padding = new Padding(32, 22, 32, 22);

            mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.BackColor = Theme.Bg;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 4;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));    // title + attention banner
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));   // stats
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 440F));   // breakdown + recent
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));    // services + quick actions

            mainLayout.Controls.Add(BuildTitle(), 0, 0);
            mainLayout.Controls.Add(BuildStats(), 0, 1);
            mainLayout.Controls.Add(BuildMiddleRow(), 0, 2);
            mainLayout.Controls.Add(BuildBottomRow(), 0, 3);
            body.Controls.Add(mainLayout);

            // the old hand-placed cards / bars are replaced by the layout above
            // (the five count labels were re-parented into the new breakdown first)
            foreach (Control old in new Control[] { pnlSubmit, pnlBreakdown, panel8, panel4, panel3, panel2, panel1 })
                old.Dispose();

            AdminUi.ApplyChrome(this, "lnklblOverView", body);

            ResumeLayout(true);
        }

        private Control BuildTitle()
        {
            string greeting = DateTime.Now.Hour < 12 ? "Good morning" : (DateTime.Now.Hour < 18 ? "Good afternoon" : "Good evening");
            Panel holder = new Panel();
            holder.Dock = DockStyle.Fill;
            holder.BackColor = Color.Transparent;

            Control alert = BuildAlert();
            alert.Dock = DockStyle.Right;
            alert.Width = 660;

            Control title = AdminUi.PageTitle(greeting + ", Administrator", "Here is what is happening on Home Hero today");
            holder.Controls.Add(title);
            holder.Controls.Add(alert);
            title.BringToFront();
            return holder;
        }

        private Control BuildAlert()
        {
            alertCard = new CardPanel();
            alertCard.Margin = new Padding(0);
            alertCard.AccentColor = Theme.Amber;
            alertCard.FillColor = Color.FromArgb(255, 251, 235);
            alertCard.BorderColor = Color.FromArgb(253, 230, 138);
            alertCard.Padding = new Padding(26, 14, 20, 22);
            alertCard.Visible = false;

            lblAlertText = Theme.MakeLabel("", 11.5F, FontStyle.Bold, Color.FromArgb(146, 64, 14));
            lblAlertText.AutoSize = false;
            lblAlertText.Dock = DockStyle.Fill;
            lblAlertText.TextAlign = ContentAlignment.MiddleLeft;
            lblAlertText.Padding = new Padding(8, 0, 0, 0);

            ModernButton review = new ModernButton();
            review.Text = "Review now";
            review.BaseColor = Theme.Amber;
            review.HoverColor = Color.FromArgb(234, 138, 20);
            review.Dock = DockStyle.Right;
            review.Width = 170;
            review.Click += delegate { AdminUi.Navigate(this, "lnklblRequests"); };

            alertCard.Controls.Add(lblAlertText);
            alertCard.Controls.Add(review);
            lblAlertText.BringToFront();
            return alertCard;
        }

        private Control BuildStats()
        {
            CardPanel c1 = AdminUi.StatCard("Total Requests", "All time", Theme.Navy, out lblStatTotal, out lblStatTotalHint);
            CardPanel c2 = AdminUi.StatCard("Awaiting Approval", "Need action", Theme.Amber, out lblStatPending, out lblStatPendingHint);
            CardPanel c3 = AdminUi.StatCard("Active Providers", "Registered providers", Theme.Blue, out lblStatProviders, out lblStatProvidersHint);
            CardPanel c4 = AdminUi.StatCard("Total Revenue", "From completed jobs", Theme.Green, out lblStatRevenue, out lblStatRevenueHint);
            CardPanel c5 = AdminUi.StatCard("Avg Job Rating", "No reviews yet", Theme.Purple, out lblStatRating, out lblStatRatingHint);

            AdminUi.MakeClickable(c1, delegate { AdminUi.Navigate(this, "lnklblRequests"); });
            AdminUi.MakeClickable(c2, delegate { AdminUi.Navigate(this, "lnklblRequests"); });
            AdminUi.MakeClickable(c3, delegate { AdminUi.Navigate(this, "lnklblProviders"); });
            AdminUi.MakeClickable(c4, delegate { AdminUi.Navigate(this, "lnklblReports"); });
            return AdminUi.StatRow(5, c1, c2, c3, c4, c5);
        }

        private Control BuildMiddleRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            row.Controls.Add(BuildBreakdownCard(), 0, 0);
            row.Controls.Add(BuildRecentCard(), 1, 0);
            return row;
        }

        // ---- request status breakdown (re-uses the original five count labels) ----
        private Control BuildBreakdownCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 14, 8);
            card.Padding = new Padding(28, 84, 28, 38);

            Label title = Theme.MakeLabel("Request Status Breakdown", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(28, 22);
            lblBreakdownTotal = Theme.MakeLabel("0 requests in total", 9.5F, FontStyle.Regular, Theme.Muted);
            lblBreakdownTotal.Location = new Point(30, 54);

            lblApprovedValue = new Label();
            lblCancelledValue = new Label();

            Dictionary<RequestStatus, Label> labels = new Dictionary<RequestStatus, Label>();
            labels[RequestStatus.Requested] = lblSubmitValue;
            labels[RequestStatus.Approved] = lblApprovedValue;
            labels[RequestStatus.ProviderAssigned] = lblAssignedValue;
            labels[RequestStatus.Scheduled] = lblScheduledValue;
            labels[RequestStatus.InProgress] = lblProgressValue;
            labels[RequestStatus.Completed] = lblCompletedValue;
            labels[RequestStatus.Cancelled] = lblCancelledValue;

            RequestStatus[] order = (RequestStatus[])Enum.GetValues(typeof(RequestStatus));

            TableLayoutPanel rows = new TableLayoutPanel();
            rows.Dock = DockStyle.Fill;
            rows.BackColor = Color.Transparent;
            rows.ColumnCount = 3;
            rows.RowCount = order.Length;
            rows.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            rows.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rows.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 54F));
            for (int i = 0; i < order.Length; i++)
                rows.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / order.Length));

            for (int i = 0; i < order.Length; i++)
            {
                RequestStatus s = order[i];
                Color back;
                Color fore;
                AdminUi.StatusColors(s, out back, out fore);

                Label caption = Theme.MakeLabel(AdminUi.StatusText(s), 10.5F, FontStyle.Bold, Theme.Text);
                caption.AutoSize = false;
                caption.Dock = DockStyle.Fill;
                caption.TextAlign = ContentAlignment.MiddleLeft;

                MeterBar bar = new MeterBar();
                bar.BarColor = fore;
                bar.Height = 12;
                bar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                bar.Margin = new Padding(0, 0, 14, 0);

                Label count = labels[s];
                count.AutoSize = false;
                count.Dock = DockStyle.Fill;
                count.TextAlign = ContentAlignment.MiddleRight;
                count.BackColor = Color.Transparent;
                count.Font = Theme.MakeFont(11.5F, FontStyle.Bold);
                count.ForeColor = fore;
                count.Text = "0";

                rows.Controls.Add(caption, 0, i);
                rows.Controls.Add(bar, 1, i);
                rows.Controls.Add(count, 2, i);
                breakdownBars[s] = bar;
                breakdownCounts[s] = count;
            }

            card.Controls.Add(rows);
            card.Controls.Add(title);
            card.Controls.Add(lblBreakdownTotal);
            return card;
        }

        // ---- recent submissions ----
        private Control BuildRecentCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 0, 8);
            card.Padding = new Padding(22, 84, 22, 36);

            Label title = Theme.MakeLabel("Recent Submissions", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(28, 22);
            Label sub = Theme.MakeLabel("The latest requests from customers - double-click a row to manage it", 9.5F, FontStyle.Regular, Theme.Muted);
            sub.Location = new Point(30, 54);

            LinkLabel viewAll = new LinkLabel();
            viewAll.Text = "View all requests  →";
            viewAll.AutoSize = true;
            viewAll.Font = Theme.MakeSemibold(10F);
            viewAll.LinkColor = Theme.Orange;
            viewAll.ActiveLinkColor = Theme.OrangeHover;
            viewAll.VisitedLinkColor = Theme.Orange;
            viewAll.LinkBehavior = LinkBehavior.HoverUnderline;
            viewAll.BackColor = Color.Transparent;
            viewAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            viewAll.Location = new Point(card.Width - 200, 26);
            viewAll.LinkClicked += delegate { AdminUi.Navigate(this, "lnklblRequests"); };
            card.Resize += delegate { viewAll.Left = card.Width - viewAll.Width - 34; };

            dgvRecent = new DataGridView();
            AdminUi.StyleGrid(dgvRecent);
            dgvRecent.RowTemplate.Height = 46;
            dgvRecent.Columns.Add(MakeCol("colRecentNo", "Request No.", 26));
            dgvRecent.Columns.Add(MakeCol("colRecentService", "Service", 18));
            dgvRecent.Columns.Add(MakeCol("colRecentCustomer", "Customer", 12));
            dgvRecent.Columns.Add(MakeCol("colRecentDate", "Preferred Date", 16));
            dgvRecent.Columns.Add(MakeCol("colRecentStatus", "Status", 20));
            dgvRecent.Columns["colRecentNo"]!.DefaultCellStyle.Font = Theme.MakeFont(10F, FontStyle.Bold);
            dgvRecent.CellPainting += dgvRecent_CellPainting;
            dgvRecent.CellDoubleClick += delegate (object? s, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0) AdminUi.Navigate(this, "lnklblRequests");
            };

            lblRecentEmpty = Theme.MakeLabel("No requests have been submitted yet.\nNew customer requests will show up here.", 11F, FontStyle.Regular, Theme.Muted);
            lblRecentEmpty.AutoSize = false;
            lblRecentEmpty.Dock = DockStyle.Fill;
            lblRecentEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblRecentEmpty.BackColor = Color.White;
            lblRecentEmpty.Visible = false;

            card.Controls.Add(lblRecentEmpty);
            card.Controls.Add(dgvRecent);
            card.Controls.Add(title);
            card.Controls.Add(sub);
            card.Controls.Add(viewAll);
            dgvRecent.BringToFront();
            return card;
        }

        private static DataGridViewTextBoxColumn MakeCol(string name, string header, float weight)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.Name = name;
            c.HeaderText = header;
            c.FillWeight = weight;
            c.MinimumWidth = 90;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
            return c;
        }

        // ---- services chart + quick actions ----
        private Control BuildBottomRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            CardPanel svc = new CardPanel();
            svc.Dock = DockStyle.Fill;
            svc.Margin = new Padding(0, 8, 14, 0);
            svc.Padding = new Padding(28, 84, 28, 38);
            Label t1 = Theme.MakeLabel("Revenue by Service", 14F, FontStyle.Bold, Theme.Navy);
            t1.Location = new Point(28, 22);
            lblServicesSub = Theme.MakeLabel("Completed jobs only", 9.5F, FontStyle.Regular, Theme.Muted);
            lblServicesSub.Location = new Point(30, 54);
            barServices = new HBarChart();
            barServices.Dock = DockStyle.Fill;
            barServices.EmptyText = "No jobs yet";
            barServices.ValueFormat = delegate (decimal v) { return "R " + v.ToString("#,##0", CultureInfo.InvariantCulture); };
            svc.Controls.Add(barServices);
            svc.Controls.Add(t1);
            svc.Controls.Add(lblServicesSub);

            CardPanel quick = new CardPanel();
            quick.Dock = DockStyle.Fill;
            quick.Margin = new Padding(0, 8, 0, 0);
            quick.Padding = new Padding(28, 110, 28, 38);
            Label t2 = Theme.MakeLabel("Quick Actions", 14F, FontStyle.Bold, Theme.Navy);
            t2.Location = new Point(28, 22);
            lblSnapshot = Theme.MakeLabel("", 9.5F, FontStyle.Regular, Theme.Muted);
            lblSnapshot.Location = new Point(30, 54);

            TableLayoutPanel grid = new TableLayoutPanel();
            grid.Dock = DockStyle.Fill;
            grid.BackColor = Color.Transparent;
            grid.ColumnCount = 2;
            grid.RowCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            grid.Controls.Add(ActionTile("Review Requests", "lnklblRequests", true), 0, 0);
            grid.Controls.Add(ActionTile("Manage Providers", "lnklblProviders", false), 1, 0);
            grid.Controls.Add(ActionTile("Service Catalogue", "lnklblServices", false), 0, 1);
            grid.Controls.Add(ActionTile("View Reports", "lnklblReports", false), 1, 1);
            quick.Controls.Add(grid);
            quick.Controls.Add(t2);
            quick.Controls.Add(lblSnapshot);

            row.Controls.Add(svc, 0, 0);
            row.Controls.Add(quick, 1, 0);
            return row;
        }

        private ModernButton ActionTile(string text, string link, bool primary)
        {
            ModernButton b = new ModernButton();
            b.Text = text + "  →";
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(0, 0, 12, 12);
            b.Radius = 14;
            b.Font = Theme.MakeSemibold(11.5F);
            if (!primary)
            {
                b.Outline = true;
                b.BaseColor = Theme.Navy;
            }
            b.Click += delegate { AdminUi.Navigate(this, link); };
            return b;
        }

        // ==================================================================
        //  DATA
        // ==================================================================
        private void LoadData()
        {
            List<MaintenanceRequest> all = DataManager.LoadRequests();
            var providers = DataManager.LoadServiceProviders();

            int pending = all.Count(r => r.Status == RequestStatus.Requested);
            List<MaintenanceRequest> completed = all.Where(r => r.Status == RequestStatus.Completed).ToList();
            decimal revenue = completed.Sum(r => r.FinalCost);
            int available = providers.Count(p => !all.Any(r => AdminUi.IsAssignedTo(r, p) &&
                r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled));

            // ---- stats ----
            lblStatTotal.Text = all.Count.ToString();
            lblStatPending.Text = pending.ToString();
            lblStatProviders.Text = providers.Count.ToString();
            lblStatRevenue.Text = AdminUi.Money(revenue);
            lblStatRating.Text = "-";
            lblStatPendingHint.Text = pending == 0 ? "Nothing waiting - all caught up" : "Need action";
            lblStatProvidersHint.Text = providers.Count == 0 ? "No providers registered yet" : available + " available right now";
            lblStatRevenueHint.Text = completed.Count + (completed.Count == 1 ? " completed job" : " completed jobs");

            // ---- attention banner ----
            if (pending > 0)
            {
                lblAlertText.Text = pending + (pending == 1 ? " request is" : " requests are") + " waiting for your approval";
                alertCard.Visible = true;
            }
            else
            {
                alertCard.Visible = false;
            }

            // ---- breakdown ----
            lblBreakdownTotal.Text = all.Count + (all.Count == 1 ? " request in total" : " requests in total");
            foreach (RequestStatus s in breakdownBars.Keys)
            {
                int n = all.Count(r => r.Status == s);
                breakdownCounts[s].Text = n.ToString();
                breakdownBars[s].Value = all.Count == 0 ? 0 : (int)Math.Round(100.0 * n / all.Count);
            }

            // ---- recent submissions ----
            dgvRecent.Rows.Clear();
            foreach (MaintenanceRequest r in all.OrderByDescending(x => x.PreferredDate).Take(8))
            {
                int i = dgvRecent.Rows.Add(r.RequestNumber, r.ServiceCategory, r.CustomerId,
                    r.PreferredDate.ToString("dd MMM yyyy"), AdminUi.StatusText(r.Status));
                dgvRecent.Rows[i].Cells["colRecentStatus"].Tag = r.Status;
            }
            dgvRecent.ClearSelection();
            dgvRecent.Visible = all.Count > 0;
            lblRecentEmpty.Visible = all.Count == 0;

            // ---- revenue by service ----
            IEnumerable<KeyValuePair<string, decimal>> bars;
            if (completed.Any(r => r.FinalCost > 0))
            {
                lblServicesSub.Text = "Completed jobs only";
                bars = completed
                    .GroupBy(r => string.IsNullOrWhiteSpace(r.ServiceCategory) ? "Other" : r.ServiceCategory)
                    .Select(g => new KeyValuePair<string, decimal>(g.Key, g.Sum(x => x.FinalCost)))
                    .OrderByDescending(k => k.Value);
            }
            else
            {
                lblServicesSub.Text = "Estimated value - no completed jobs yet";
                bars = all.Where(r => r.Status != RequestStatus.Cancelled)
                    .GroupBy(r => string.IsNullOrWhiteSpace(r.ServiceCategory) ? "Other" : r.ServiceCategory)
                    .Select(g => new KeyValuePair<string, decimal>(g.Key, g.Sum(x => x.EstimatedCost)))
                    .OrderByDescending(k => k.Value);
            }
            barServices.SetData(bars.ToList());

            // ---- snapshot ----
            int rate = all.Count == 0 ? 0 : (int)Math.Round(100.0 * completed.Count / all.Count);
            lblSnapshot.Text = "Completion rate " + rate + "%   |   " + available + " of " + providers.Count + " providers free";
        }

        private void dgvRecent_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvRecent.Columns[e.ColumnIndex].Name != "colRecentStatus") return;

            object? tag = dgvRecent.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
            if (!(tag is RequestStatus)) return;

            RequestStatus s = (RequestStatus)tag;
            Color back;
            Color fore;
            AdminUi.StatusColors(s, out back, out fore);
            AdminUi.PaintPillCell(e, AdminUi.StatusText(s), back, fore);
        }

        // ==================================================================
        //  ORIGINAL HANDLERS  (names unchanged)
        // ==================================================================
        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnProviders_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnServices_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReports reportsPage = new frmReports();
            this.Hide();
            reportsPage.Show();
        }

        // the Services tab is wired for every admin page inside AdminUi.ApplyChrome
        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProviderManagement providerManagementPage = new frmProviderManagement();
            providerManagementPage.Show();
            this.Hide();
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // already on the Overview - just refresh the numbers
            LoadData();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestManagement requestManagement = new RequestManagement();
            this.Hide();
            requestManagement.Show();
        }

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            AdminUi.Logout(this);
        }
    }
}
