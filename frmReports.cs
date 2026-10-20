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

namespace Home_Hero
{
    public partial class frmReports : FitForm
    {
        // ---- new UI pieces (existing controls keep their original names) ----
        private ComboBox cbxPeriod = null!;
        private TextBox txtSearchReports = null!;
        private ModernButton btnExportReport = null!;
        private HBarChart barRevenue = null!;
        private DonutChart donutStatus = null!;
        private Label lblRevenueSub = null!;
        private Label lblLedgerCount = null!;
        private Label lblPipelineValue = null!;
        private Label lblRevenueHint = null!;
        private Label lblJobsHint = null!;
        private Label lblAvgHint = null!;
        private Label lblRatingHint = null!;
        private Label lblPipelineHint = null!;
        private DataGridViewTextBoxColumn colReportStatus = null!;
        private DataGridViewTextBoxColumn colReportDate = null!;

        private bool ready;
        private List<MaintenanceRequest> scope = new List<MaintenanceRequest>();
        private Dictionary<string, string> providerNames = new Dictionary<string, string>();

        public frmReports()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildUi();
            ready = true;
            ReloadReport();
        }

        // ==================================================================
        //  UI CONSTRUCTION  (re-uses the designer's controls, restyled)
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();
            FormBorderStyle = FormBorderStyle.None;   // same as the other admin pages

            Panel body = new Panel();
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1200, 1240);
            body.Padding = new Padding(32, 22, 32, 22);

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.BackColor = Theme.Bg;
            layout.ColumnCount = 1;
            layout.RowCount = 4;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 390F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            layout.Controls.Add(BuildTitleRow(), 0, 0);
            layout.Controls.Add(BuildStatRow(), 0, 1);
            layout.Controls.Add(BuildChartRow(), 0, 2);
            layout.Controls.Add(BuildLedgerCard(), 0, 3);
            body.Controls.Add(layout);

            // the old hand-placed cards / hard-coded category bars are replaced by the layout above
            foreach (Control old in new Control[] { panel1, panel4, panel8, panel2, pnlServices })
                old.Dispose();

            AdminUi.ApplyChrome(this, "lnklblReports", body);

            dgvReports.CellPainting += dgvReports_CellPainting;
            ResumeLayout(true);
        }

        private Control BuildTitleRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            row.Controls.Add(AdminUi.PageTitle("Reports & Analytics", "Revenue, job completion and request activity across the whole platform"), 0, 0);

            cbxPeriod = new ComboBox();
            cbxPeriod.Items.AddRange(new object[] { "All time", "This month", "Last 30 days", "This year" });
            cbxPeriod.SelectedIndex = 0;
            cbxPeriod.SelectedIndexChanged += delegate { if (ready) ReloadReport(); };
            InputFrame periodFrame = AdminUi.Frame(cbxPeriod, 230, 50);
            periodFrame.Margin = new Padding(12, 6, 0, 0);

            btnExportReport = new ModernButton();
            btnExportReport.Text = "Export CSV";
            btnExportReport.Outline = true;
            btnExportReport.BaseColor = Theme.Navy;
            btnExportReport.Size = new Size(150, 50);
            btnExportReport.Margin = new Padding(0, 6, 0, 0);
            btnExportReport.Click += delegate { AdminUi.ExportGrid(this, dgvReports, "report"); };

            FlowLayoutPanel actions = new FlowLayoutPanel();
            actions.Dock = DockStyle.Fill;
            actions.FlowDirection = FlowDirection.RightToLeft;
            actions.WrapContents = false;
            actions.BackColor = Color.Transparent;
            actions.Controls.Add(btnExportReport);
            actions.Controls.Add(periodFrame);
            row.Controls.Add(actions, 1, 0);
            return row;
        }

        // re-uses the designer's value label so its name is still the one that shows the number
        private CardPanel MakeStat(string caption, string hint, Color accent, Label designerValue, out Label hintLabel)
        {
            Label created;
            CardPanel card = AdminUi.StatCard(caption, hint, accent, out created, out hintLabel);
            TableLayoutPanel stack = (TableLayoutPanel)card.Controls[0];
            stack.Controls.Remove(created);
            created.Dispose();

            designerValue.AutoSize = true;
            designerValue.BackColor = Color.Transparent;
            designerValue.Font = Theme.MakeFont(24F, FontStyle.Bold);
            designerValue.ForeColor = accent;
            designerValue.Margin = new Padding(0);
            stack.Controls.Add(designerValue, 0, 1);
            return card;
        }

        private Control BuildStatRow()
        {
            lblPipelineValue = Theme.MakeLabel("R 0.00", 24F, FontStyle.Bold, Theme.Blue);

            CardPanel c1 = MakeStat("Total Revenue", "From completed jobs", Theme.Green, lblTotalRevenueVale, out lblRevenueHint);
            CardPanel c2 = MakeStat("Completed Jobs", "Finished in this period", Theme.Navy, lblCompletedJobsValue, out lblJobsHint);
            CardPanel c3 = MakeStat("Avg. Job Value", "Per completed job", Theme.Orange, lblAverageJoValueValue, out lblAvgHint);
            CardPanel c4 = MakeStat("Avg. Job Rating", "Customer satisfaction", Theme.Purple, lblAvgJobRating, out lblRatingHint);
            CardPanel c5 = MakeStat("Pipeline Value", "Estimated value of open jobs", Theme.Blue, lblPipelineValue, out lblPipelineHint);

            return AdminUi.StatRow(5, c1, c2, c3, c4, c5);
        }

        private Control BuildChartRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ---- revenue by service ----
            CardPanel revCard = new CardPanel();
            revCard.Dock = DockStyle.Fill;
            revCard.Margin = new Padding(0, 8, 14, 8);
            revCard.Padding = new Padding(28, 84, 28, 38);

            Label revTitle = Theme.MakeLabel("Revenue by Service", 14F, FontStyle.Bold, Theme.Navy);
            revTitle.Location = new Point(28, 22);
            lblRevenueSub = Theme.MakeLabel("Completed jobs only", 9.5F, FontStyle.Regular, Theme.Muted);
            lblRevenueSub.Location = new Point(30, 54);

            barRevenue = new HBarChart();
            barRevenue.Dock = DockStyle.Fill;
            barRevenue.EmptyText = "No jobs in this period yet";
            barRevenue.ValueFormat = delegate (decimal v) { return "R " + v.ToString("#,##0", CultureInfo.InvariantCulture); };

            revCard.Controls.Add(barRevenue);
            revCard.Controls.Add(revTitle);
            revCard.Controls.Add(lblRevenueSub);

            // ---- requests by status ----
            CardPanel statusCard = new CardPanel();
            statusCard.Dock = DockStyle.Fill;
            statusCard.Margin = new Padding(0, 8, 0, 8);
            statusCard.Padding = new Padding(28, 84, 28, 38);

            Label stTitle = Theme.MakeLabel("Requests by Status", 14F, FontStyle.Bold, Theme.Navy);
            stTitle.Location = new Point(28, 22);
            Label stSub = Theme.MakeLabel("Where every request currently stands", 9.5F, FontStyle.Regular, Theme.Muted);
            stSub.Location = new Point(30, 54);

            donutStatus = new DonutChart();
            donutStatus.Dock = DockStyle.Fill;
            donutStatus.EmptyText = "no requests";

            statusCard.Controls.Add(donutStatus);
            statusCard.Controls.Add(stTitle);
            statusCard.Controls.Add(stSub);

            row.Controls.Add(revCard, 0, 0);
            row.Controls.Add(statusCard, 1, 0);
            return row;
        }

        private Control BuildLedgerCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 0, 0);
            card.Padding = new Padding(22, 20, 22, 30);

            // header: title + live search
            Label title = Theme.MakeLabel("Request Ledger", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(4, 4);
            lblLedgerCount = Theme.MakeLabel("", 9.5F, FontStyle.Regular, Theme.Muted);
            lblLedgerCount.Location = new Point(6, 36);

            txtSearchReports = new TextBox();
            txtSearchReports.PlaceholderText = "Search by request no., customer, provider or service...";
            txtSearchReports.TextChanged += delegate { if (ready) FillLedger(); };
            InputFrame searchFrame = AdminUi.Frame(txtSearchReports, 440, 50);
            searchFrame.Margin = new Padding(0);
            searchFrame.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 70;
            header.BackColor = Color.Transparent;
            header.Controls.Add(title);
            header.Controls.Add(lblLedgerCount);
            header.Controls.Add(searchFrame);
            header.Resize += delegate { searchFrame.Location = new Point(header.Width - searchFrame.Width, 2); };
            searchFrame.Location = new Point(Math.Max(0, 700 - searchFrame.Width), 2);

            // grid: original columns + two extra ones
            AdminUi.StyleGrid(dgvReports);

            colReportStatus = new DataGridViewTextBoxColumn();
            colReportStatus.Name = "colReportStatus";
            colReportStatus.HeaderText = "Status";
            colReportDate = new DataGridViewTextBoxColumn();
            colReportDate.Name = "colReportDate";
            colReportDate.HeaderText = "Preferred Date";

            dgvReports.Columns.Insert(clmProvider.Index + 1, colReportStatus);
            dgvReports.Columns.Add(colReportDate);

            SetWeight(cmlRequest, 20);
            SetWeight(cmlCustomer, 10);
            SetWeight(clmStatus, 16);
            SetWeight(clmProvider, 15);
            SetWeight(colReportStatus, 14);
            SetWeight(cmlCost, 12);
            SetWeight(cmlRating, 8);
            SetWeight(colReportDate, 12);
            cmlRequest.DefaultCellStyle.Font = Theme.MakeFont(10F, FontStyle.Bold);
            AdminUi.RightAlign(cmlCost);
            cmlRating.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cmlRating.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            card.Controls.Add(dgvReports);
            card.Controls.Add(header);
            dgvReports.BringToFront();
            return card;
        }

        private static void SetWeight(DataGridViewColumn c, float weight)
        {
            c.FillWeight = weight;
            c.MinimumWidth = 60;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        // ==================================================================
        //  DATA
        // ==================================================================
        private bool InPeriod(MaintenanceRequest r)
        {
            DateTime d = r.PreferredDate.Date;
            DateTime today = DateTime.Today;
            switch (cbxPeriod.SelectedIndex)
            {
                case 1: return d.Year == today.Year && d.Month == today.Month;
                case 2: return d >= today.AddDays(-30) && d <= today;
                case 3: return d.Year == today.Year;
                default: return true;
            }
        }

        private string ProviderLabel(string? assigned)
        {
            if (string.IsNullOrWhiteSpace(assigned) || assigned == "Unassigned") return "Unassigned";
            string name;
            if (providerNames.TryGetValue(assigned.Trim().ToLowerInvariant(), out name)) return name;
            return assigned;
        }

        private void ReloadReport()
        {
            providerNames = new Dictionary<string, string>();
            foreach (var p in DataManager.LoadServiceProviders())
            {
                string full = AdminUi.TitleCase(p.FirstName + " " + p.LastName);
                providerNames[p.UserId.ToString().ToLowerInvariant()] = full;
            }

            scope = DataManager.LoadRequests().Where(InPeriod).ToList();

            List<MaintenanceRequest> completed = scope.Where(r => r.Status == RequestStatus.Completed).ToList();
            decimal revenue = completed.Sum(r => r.FinalCost);
            decimal average = completed.Count > 0 ? revenue / completed.Count : 0m;
            decimal pipeline = scope
                .Where(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled)
                .Sum(r => r.EstimatedCost);
            int openJobs = scope.Count(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled);

            // ---- stat cards (designer labels keep their names) ----
            lblTotalRevenueVale.Text = AdminUi.Money(revenue);
            lblCompletedJobsValue.Text = completed.Count.ToString();
            lblAverageJoValueValue.Text = AdminUi.Money(average);
            lblAvgJobRating.Text = "-";
            lblPipelineValue.Text = AdminUi.Money(pipeline);

            lblRevenueHint.Text = completed.Count == 0 ? "No completed jobs yet" : "From " + completed.Count + (completed.Count == 1 ? " completed job" : " completed jobs");
            lblJobsHint.Text = scope.Count == 0 ? "No requests in this period" : (completed.Count * 100 / scope.Count) + "% of all requests";
            lblAvgHint.Text = "Per completed job";
            lblRatingHint.Text = "No customer reviews recorded yet";
            lblPipelineHint.Text = openJobs + (openJobs == 1 ? " open job" : " open jobs") + " in progress";

            // ---- revenue by service ----
            bool haveRevenue = completed.Any(r => r.FinalCost > 0);
            IEnumerable<KeyValuePair<string, decimal>> bars;
            if (haveRevenue)
            {
                lblRevenueSub.Text = "Completed jobs only";
                bars = completed
                    .GroupBy(r => string.IsNullOrWhiteSpace(r.ServiceCategory) ? "Other" : r.ServiceCategory)
                    .Select(g => new KeyValuePair<string, decimal>(g.Key, g.Sum(x => x.FinalCost)))
                    .OrderByDescending(k => k.Value);
            }
            else
            {
                lblRevenueSub.Text = "Estimated value - no completed jobs yet";
                bars = scope
                    .Where(r => r.Status != RequestStatus.Cancelled)
                    .GroupBy(r => string.IsNullOrWhiteSpace(r.ServiceCategory) ? "Other" : r.ServiceCategory)
                    .Select(g => new KeyValuePair<string, decimal>(g.Key, g.Sum(x => x.EstimatedCost)))
                    .OrderByDescending(k => k.Value);
            }
            barRevenue.SetData(bars.ToList());

            // ---- requests by status ----
            donutStatus.Clear();
            foreach (RequestStatus s in Enum.GetValues(typeof(RequestStatus)))
            {
                Color back;
                Color fore;
                AdminUi.StatusColors(s, out back, out fore);
                donutStatus.Add(AdminUi.StatusText(s), scope.Count(r => r.Status == s), fore);
            }
            donutStatus.Start();

            FillLedger();
        }

        private void FillLedger()
        {
            string text = txtSearchReports.Text.Trim();

            IEnumerable<MaintenanceRequest> q = scope;
            if (text.Length > 0)
            {
                q = q.Where(r =>
                    Has(r.RequestNumber, text) || Has(r.CustomerId, text) || Has(r.ServiceCategory, text) ||
                    Has(ProviderLabel(r.AssignedProviderId), text) || Has(AdminUi.StatusText(r.Status), text));
            }
            List<MaintenanceRequest> list = q.OrderByDescending(r => r.PreferredDate).ToList();

            dgvReports.SuspendLayout();
            dgvReports.Rows.Clear();
            foreach (MaintenanceRequest r in list)
            {
                int i = dgvReports.Rows.Add();
                DataGridViewRow row = dgvReports.Rows[i];
                row.Cells[cmlRequest.Index].Value = r.RequestNumber;
                row.Cells[cmlCustomer.Index].Value = r.CustomerId;
                row.Cells[clmStatus.Index].Value = ProviderLabel(r.AssignedProviderId);     // "Provider" column
                row.Cells[clmProvider.Index].Value = r.ServiceCategory;                     // "Service" column
                row.Cells[colReportStatus.Index].Value = AdminUi.StatusText(r.Status);
                row.Cells[colReportStatus.Index].Tag = r.Status;
                row.Cells[cmlCost.Index].Value = r.Status == RequestStatus.Completed && r.FinalCost > 0 ? AdminUi.Money(r.FinalCost) : "-";
                row.Cells[cmlRating.Index].Value = "-";
                row.Cells[colReportDate.Index].Value = r.PreferredDate.ToString("dd MMM yyyy");
            }
            dgvReports.ClearSelection();
            dgvReports.ResumeLayout();

            lblLedgerCount.Text = list.Count == 0
                ? "No requests found for this period / search"
                : (list.Count == scope.Count ? "All " + list.Count : list.Count + " of " + scope.Count) +
                  (scope.Count == 1 ? " request" : " requests") + " in the selected period";
        }

        private static bool Has(string? source, string text)
        {
            return (source ?? "").Contains(text, StringComparison.OrdinalIgnoreCase);
        }

        private void dgvReports_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvReports.Columns[e.ColumnIndex] != colReportStatus) return;

            object? tag = dgvReports.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
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
        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            AdminUi.Logout(this);
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminDashboard adminDashboard = new frmAdminDashboard();
            this.Hide();
            adminDashboard.Show();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestManagement requestManagement = new RequestManagement();
            this.Hide();
            requestManagement.Show();
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProviderManagement providerManagementPage = new frmProviderManagement();
            providerManagementPage.Show();
            this.Hide();
        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // already on the Reports page - just refresh the numbers
            ReloadReport();
        }
    }
}
