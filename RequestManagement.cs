using HomeHero_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    public partial class RequestManagement : FitForm
    {
        // ---- state ----
        private bool ready;
        private List<MaintenanceRequest> shown = new List<MaintenanceRequest>();

        private static readonly RequestStatus[] Journey = new RequestStatus[]
        {
            RequestStatus.Requested, RequestStatus.Approved, RequestStatus.ProviderAssigned,
            RequestStatus.Scheduled, RequestStatus.InProgress, RequestStatus.Completed
        };

        // ---- new UI pieces (existing controls keep their original names) ----
        private ModernButton btnClearFilters = null!;
        private ModernButton btnExportRequests = null!;
        private Label lblEmptyRequests = null!;

        private Label lblStatTotal = null!;
        private Label lblStatPending = null!;
        private Label lblStatActive = null!;
        private Label lblStatDone = null!;
        private Label lblStatCancelled = null!;
        private Label lblStatTotalHint = null!;
        private Label lblStatPendingHint = null!;
        private Label lblStatActiveHint = null!;
        private Label lblStatDoneHint = null!;
        private Label lblStatCancelledHint = null!;

        // ---- detail card ----
        private CardPanel detailCard = null!;
        private Label lblReqNumber = null!;
        private PillLabel pillReqStatus = null!;
        private MeterBar barProgress = null!;
        private Label lblProgress = null!;
        private FieldBlock fldCustomer = null!;
        private FieldBlock fldService = null!;
        private FieldBlock fldWhen = null!;
        private FieldBlock fldProvider = null!;
        private FieldBlock fldEstimate = null!;
        private FieldBlock fldFinal = null!;
        private FieldBlock fldAddress = null!;
        private Label lblDescription = null!;
        private Panel descNote = null!;

        private readonly Font boldCellFont = Theme.MakeFont(10F, FontStyle.Bold);
        private readonly Font mutedCellFont = Theme.MakeFont(10F, FontStyle.Italic);

        public RequestManagement()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildUi();
            ready = true;
            ApplyFilters();
        }

        // ==================================================================
        //  UI CONSTRUCTION  (re-uses the designer's controls, restyled)
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();

            label1.Visible = false;              // "Search Request" caption - replaced by placeholder text
            flwLPSearchRequest.Visible = false;  // old results strip - lblResults is moved into the grid card

            Panel body = new Panel();
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1200, 880);
            body.Padding = new Padding(32, 6, 32, 8);

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.BackColor = Theme.Bg;
            layout.ColumnCount = 1;
            layout.RowCount = 3;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            layout.Controls.Add(BuildTitleRow(), 0, 0);
            layout.Controls.Add(BuildStatRow(), 0, 1);
            layout.Controls.Add(BuildMainRow(), 0, 2);
            body.Controls.Add(layout);

            AdminUi.ApplyChrome(this, "lnklblRequests", body);

            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
            dgvRequests.CellPainting += dgvRequests_CellPainting;
            dgvRequests.CellFormatting += dgvRequests_CellFormatting;
            txtSearchRequests.KeyDown += delegate (object? s, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; ApplyFilters(); }
            };

            ResumeLayout(true);
        }

        private Control BuildTitleRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            row.RowCount = 1;
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            row.Controls.Add(AdminUi.PageTitle("Request Management", ""), 0, 0);

            btnExportRequests = new ModernButton();
            btnExportRequests.Text = "Export CSV";
            btnExportRequests.Outline = true;
            btnExportRequests.BaseColor = Theme.Navy;
            btnExportRequests.Size = new Size(150, 50);
            btnExportRequests.Margin = new Padding(0, 6, 0, 0);
            btnExportRequests.Click += delegate { AdminUi.ExportGrid(this, dgvRequests, "requests"); };

            FlowLayoutPanel actions = new FlowLayoutPanel();
            actions.Dock = DockStyle.Fill;
            actions.FlowDirection = FlowDirection.RightToLeft;
            actions.BackColor = Color.Transparent;
            actions.Controls.Add(btnExportRequests);
            row.Controls.Add(actions, 1, 0);
            return row;
        }

        private Control BuildStatRow()
        {
            CardPanel c1 = AdminUi.StatCard("All Requests", "Every request on the platform", Theme.Navy, out lblStatTotal, out lblStatTotalHint);
            CardPanel c2 = AdminUi.StatCard("Awaiting Approval", "Click to review them now", Theme.Amber, out lblStatPending, out lblStatPendingHint);
            CardPanel c3 = AdminUi.StatCard("In Progress", "Approved, assigned or scheduled", Theme.Blue, out lblStatActive, out lblStatActiveHint);
            CardPanel c4 = AdminUi.StatCard("Completed", "Jobs finished successfully", Theme.Green, out lblStatDone, out lblStatDoneHint);
            CardPanel c5 = AdminUi.StatCard("Cancelled", "Requests that were cancelled", Theme.Red, out lblStatCancelled, out lblStatCancelledHint);

            // stat cards double as quick filters
            AdminUi.MakeClickable(c1, delegate { SetStatusFilter(0); });
            AdminUi.MakeClickable(c2, delegate { SetStatusFilter(1); });
            AdminUi.MakeClickable(c4, delegate { SetStatusFilter(6); });
            AdminUi.MakeClickable(c5, delegate { SetStatusFilter(7); });

            return AdminUi.StatRow(5, c1, c2, c3, c4, c5);
        }

        private void SetStatusFilter(int index)
        {
            if (cbxStatus.Items.Count > index) cbxStatus.SelectedIndex = index;
        }

        private Control BuildMainRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 440F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            row.Controls.Add(BuildGridCard(), 0, 0);
            row.Controls.Add(BuildDetailCard(), 1, 0);
            return row;
        }

        private Control BuildGridCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 6, 14, 0);
            card.Padding = new Padding(22, 20, 22, 30);

            // ---- filters ----
            txtSearchRequests.Text = "";
            txtSearchRequests.PlaceholderText = "Search by request no., customer, service, address...";
            InputFrame searchFrame = AdminUi.Frame(txtSearchRequests, 380, 50);

            cbxStatus.Items.Clear();
            cbxStatus.Items.Add("All statuses");
            foreach (RequestStatus s in Enum.GetValues(typeof(RequestStatus)))
                cbxStatus.Items.Add(AdminUi.StatusText(s));
            cbxStatus.SelectedIndex = 0;
            InputFrame statusFrame = AdminUi.Frame(cbxStatus, 210, 50);

            List<string> categories = new List<string> { "Electrical", "Plumbing", "Appliance Repair", "Painting", "General Maintenance" };
            foreach (string extra in DataManager.LoadRequests()
                .Select(r => r.ServiceCategory)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase))
            {
                if (!categories.Contains(extra, StringComparer.OrdinalIgnoreCase)) categories.Add(extra);
            }
            cbxCategory.Items.Clear();
            cbxCategory.Items.Add("All categories");
            foreach (string c in categories) cbxCategory.Items.Add(c);
            cbxCategory.SelectedIndex = 0;
            InputFrame categoryFrame = AdminUi.Frame(cbxCategory, 230, 50);

            btnSearch.Text = "Search";
            btnSearch.BackColor = Color.Transparent;
            btnSearch.Size = new Size(120, 50);
            btnSearch.Margin = new Padding(0, 0, 12, 8);

            btnClearFilters = new ModernButton();
            btnClearFilters.Text = "Clear";
            btnClearFilters.Outline = true;
            btnClearFilters.BaseColor = Theme.Navy;
            btnClearFilters.Size = new Size(100, 50);
            btnClearFilters.Margin = new Padding(0, 0, 0, 8);
            btnClearFilters.Click += delegate
            {
                ready = false;
                txtSearchRequests.Text = "";
                cbxStatus.SelectedIndex = 0;
                cbxCategory.SelectedIndex = 0;
                ready = true;
                ApplyFilters();
            };

            FlowLayoutPanel toolbar = new FlowLayoutPanel();
            toolbar.Dock = DockStyle.Top;
            toolbar.AutoSize = true;
            toolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toolbar.WrapContents = true;
            toolbar.BackColor = Color.Transparent;
            toolbar.Controls.Add(searchFrame);
            toolbar.Controls.Add(statusFrame);
            toolbar.Controls.Add(categoryFrame);
            toolbar.Controls.Add(btnSearch);
            toolbar.Controls.Add(btnClearFilters);

            // results strip
            lblResults.AutoSize = false;
            lblResults.Dock = DockStyle.Top;
            lblResults.Height = 34;
            lblResults.TextAlign = ContentAlignment.MiddleLeft;
            lblResults.Font = Theme.MakeFont(9.5F);
            lblResults.ForeColor = Theme.Muted;
            lblResults.BackColor = Color.Transparent;
            lblResults.Text = "";

            // grid
            AdminUi.StyleGrid(dgvRequests);
            ConfigureColumns();

            lblEmptyRequests = Theme.MakeLabel("No requests match your filters.\nTry a different search or clear the filters.", 11F, FontStyle.Regular, Theme.Muted);
            lblEmptyRequests.AutoSize = false;
            lblEmptyRequests.Dock = DockStyle.Fill;
            lblEmptyRequests.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyRequests.BackColor = Color.White;
            lblEmptyRequests.Visible = false;

            card.Controls.Add(lblEmptyRequests);
            card.Controls.Add(dgvRequests);
            card.Controls.Add(lblResults);
            card.Controls.Add(toolbar);
            dgvRequests.BringToFront();
            return card;
        }

        private void ConfigureColumns()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();

            AddColumn("RequestNumber", "Request No.", 20, true);
            AddColumn("CustomerId", "Customer", 9, false);
            AddColumn("ServiceCategory", "Service", 15, false);
            DataGridViewColumn issue = AddColumn("ProblemDescription", "Issue", 18, false);
            issue.DefaultCellStyle.WrapMode = DataGridViewTriState.False;   // keep every row the same compact height
            issue.DefaultCellStyle.ForeColor = Theme.Muted;
            issue.DefaultCellStyle.Font = Theme.MakeFont(9.5F);
            AddColumn("Status", "Status", 14, false);
            AddColumn("PreferredDate", "Preferred Date", 12, false).DefaultCellStyle.Format = "dd MMM yyyy";
            AddColumn("AssignedProviderId", "Provider", 19, false);
            DataGridViewColumn est = AddColumn("EstimatedCost", "Estimate", 11, false);
            est.DefaultCellStyle.Format = "'R' #,##0.00";
            AdminUi.RightAlign(est);
            DataGridViewColumn fin = AddColumn("FinalCost", "Final Cost", 11, false);
            fin.DefaultCellStyle.Format = "'R' #,##0.00";
            AdminUi.RightAlign(fin);
        }

        private DataGridViewColumn AddColumn(string property, string header, float weight, bool bold)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.Name = property;
            c.DataPropertyName = property;
            c.HeaderText = header;
            c.FillWeight = weight;
            c.MinimumWidth = 110;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
            if (bold) c.DefaultCellStyle.Font = boldCellFont;
            dgvRequests.Columns.Add(c);
            return c;
        }

        private Control BuildDetailCard()
        {
            detailCard = new CardPanel();
            detailCard.Dock = DockStyle.Fill;
            detailCard.Margin = new Padding(0, 6, 0, 0);
            detailCard.AccentColor = Theme.Orange;
            detailCard.Padding = new Padding(26, 20, 26, 30);
            detailCard.AutoScroll = true;
            detailCard.AutoScrollMinSize = new Size(0, 740);

            Label cap = Theme.MakeLabel("SELECTED REQUEST", 8F, FontStyle.Bold, Theme.Muted);
            cap.Location = new Point(30, 18);

            lblReqNumber = Theme.MakeLabel("Nothing selected", 12.5F, FontStyle.Bold, Theme.Navy);
            lblReqNumber.AutoSize = false;
            lblReqNumber.AutoEllipsis = true;
            lblReqNumber.Size = new Size(350, 32);
            lblReqNumber.Location = new Point(30, 36);

            pillReqStatus = new PillLabel();
            pillReqStatus.Width = 180;
            pillReqStatus.Height = 30;
            pillReqStatus.Location = new Point(30, 74);
            pillReqStatus.PillText = "No request selected";
            pillReqStatus.PillBack = Color.FromArgb(241, 245, 249);
            pillReqStatus.PillFore = Theme.Muted;

            barProgress = new MeterBar();
            barProgress.Location = new Point(30, 114);
            barProgress.Size = new Size(350, 10);

            lblProgress = Theme.MakeLabel("-", 9F, FontStyle.Regular, Theme.Muted);
            lblProgress.Location = new Point(30, 130);

            fldProvider = MakeField("Assigned provider", 30, 152, 350);
            fldCustomer = MakeField("Customer", 30, 210, 170);
            fldService = MakeField("Service", 210, 210, 170);
            fldWhen = MakeField("Preferred slot", 30, 268, 350);
            fldEstimate = MakeField("Estimate", 30, 326, 170);
            fldFinal = MakeField("Final cost", 210, 326, 170);
            fldAddress = MakeField("Property address", 30, 384, 350);

            Label descCap = Theme.MakeLabel("PROBLEM DESCRIPTION", 8F, FontStyle.Bold, Theme.Muted);
            descCap.Location = new Point(30, 448);

            // compact note box: soft background + orange edge, fixed small height,
            // longer descriptions scroll inside the box instead of pushing the page down
            Panel descBox = new Panel();
            descBox.Location = new Point(30, 470);
            descBox.Size = new Size(350, 78);
            descBox.BackColor = Color.FromArgb(250, 251, 253);
            descBox.Padding = new Padding(16, 8, 10, 8);
            descBox.AutoScroll = true;
            descBox.Paint += delegate (object? s2, PaintEventArgs pe)
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                RectangleF r = new RectangleF(0.5F, 0.5F, descBox.Width - 2, descBox.Height - 2);
                using (System.Drawing.Drawing2D.GraphicsPath p = Theme.RoundRect(r, 8))
                using (Pen pen = new Pen(Theme.Border, 1f))
                    pe.Graphics.DrawPath(pen, p);
                using (SolidBrush bar = new SolidBrush(Theme.Orange))
                    pe.Graphics.FillRectangle(bar, 0, 10, 4, descBox.Height - 22);
            };

            lblDescription = Theme.MakeLabel("-", 9.5F, FontStyle.Regular, Theme.Text);
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(16, 8);
            lblDescription.MaximumSize = new Size(300, 0);
            descBox.Controls.Add(lblDescription);
            descBox.Resize += delegate { lblDescription.MaximumSize = new Size(Math.Max(60, descBox.ClientSize.Width - 30), 0); };
            descNote = descBox;

            // action buttons (original buttons, new look and position)
            btnApproveRequests.BackColor = Color.Transparent;
            btnApproveRequests.Text = "Approve Request";
            btnApproveRequests.BaseColor = Theme.Green;
            btnApproveRequests.HoverColor = Color.FromArgb(34, 184, 90);

            btnReassign.BackColor = Color.Transparent;
            btnReassign.Text = "Reassign Provider";
            btnReassign.Outline = true;
            btnReassign.BaseColor = Theme.Navy;

            btnCancelRequests.BackColor = Color.Transparent;
            btnCancelRequests.Text = "Cancel Request";
            btnCancelRequests.Outline = true;
            btnCancelRequests.BaseColor = Theme.Red;

            btnApproveRequests.Enabled = false;
            btnReassign.Enabled = false;
            btnCancelRequests.Enabled = false;

            detailCard.Controls.Add(cap);
            detailCard.Controls.Add(lblReqNumber);
            detailCard.Controls.Add(pillReqStatus);
            detailCard.Controls.Add(barProgress);
            detailCard.Controls.Add(lblProgress);
            detailCard.Controls.Add(fldCustomer);
            detailCard.Controls.Add(fldService);
            detailCard.Controls.Add(fldWhen);
            detailCard.Controls.Add(fldProvider);
            detailCard.Controls.Add(fldEstimate);
            detailCard.Controls.Add(fldFinal);
            detailCard.Controls.Add(fldAddress);
            detailCard.Controls.Add(descCap);
            detailCard.Controls.Add(descNote);
            detailCard.Controls.Add(btnApproveRequests);
            detailCard.Controls.Add(btnReassign);
            detailCard.Controls.Add(btnCancelRequests);
            detailCard.Resize += delegate { LayoutDetailCard(); };
            LayoutDetailCard();
            return detailCard;
        }

        private void LayoutDetailCard()
        {
            const int inset = 30;
            const int gap = 12;
            int width = Math.Max(220, detailCard.ClientSize.Width - inset * 2);
            int halfWidth = (width - gap) / 2;

            lblReqNumber.SetBounds(inset, 36, width, 32);
            barProgress.SetBounds(inset, 114, width, 10);
            fldProvider.SetBounds(inset, 152, width, 56);
            fldCustomer.SetBounds(inset, 210, halfWidth, 56);
            fldService.SetBounds(inset + halfWidth + gap, 210, width - halfWidth - gap, 56);
            fldWhen.SetBounds(inset, 268, width, 56);
            fldEstimate.SetBounds(inset, 326, halfWidth, 56);
            fldFinal.SetBounds(inset + halfWidth + gap, 326, width - halfWidth - gap, 56);
            fldAddress.SetBounds(inset, 384, width, 56);
            descNote.SetBounds(inset, 470, width, 78);

            btnApproveRequests.SetBounds(inset, 566, width, 50);
            btnReassign.SetBounds(inset, 624, halfWidth, 50);
            btnCancelRequests.SetBounds(inset + halfWidth + gap, 624, width - halfWidth - gap, 50);
        }

        private FieldBlock MakeField(string caption, int left, int top, int width)
        {
            FieldBlock f = new FieldBlock(caption);
            f.Location = new Point(left, top);
            f.Size = new Size(width, 56);
            return f;
        }

        // ==================================================================
        //  FILTERING + BINDING
        // ==================================================================
        private static bool Has(string? source, string text)
        {
            return (source ?? "").Contains(text, StringComparison.OrdinalIgnoreCase);
        }

        private MaintenanceRequest? SelectedRequest()
        {
            if (dgvRequests.SelectedRows.Count == 0) return null;
            return dgvRequests.SelectedRows[0].DataBoundItem as MaintenanceRequest;
        }

        private void ApplyFilters()
        {
            if (!ready) return;

            string? keepNumber = SelectedRequest()?.RequestNumber;

            List<MaintenanceRequest> all = DataManager.LoadRequests();
            UpdateStats(all);

            IEnumerable<MaintenanceRequest> q = all;

            string text = txtSearchRequests.Text.Trim();
            if (text.Length > 0)
            {
                q = q.Where(r =>
                    Has(r.RequestNumber, text) || Has(r.CustomerId, text) || Has(r.ServiceCategory, text) ||
                    Has(r.PropertyAddress, text) || Has(r.ProblemDescription, text) || Has(r.AssignedProviderId, text));
            }

            if (cbxStatus.SelectedIndex > 0)
            {
                RequestStatus wanted = (RequestStatus)(cbxStatus.SelectedIndex - 1);
                q = q.Where(r => r.Status == wanted);
            }

            if (cbxCategory.SelectedIndex > 0)
            {
                string cat = cbxCategory.SelectedItem!.ToString()!;
                q = q.Where(r => string.Equals(r.ServiceCategory, cat, StringComparison.OrdinalIgnoreCase));
            }

            // requests that need the admin's attention come first, then newest dates
            shown = q.OrderBy(r => r.Status == RequestStatus.Requested ? 0 : 1)
                     .ThenByDescending(r => r.PreferredDate)
                     .ToList();

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = shown;

            dgvRequests.ClearSelection();
            DataGridViewRow? target = null;
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                MaintenanceRequest? r = row.DataBoundItem as MaintenanceRequest;
                if (r != null && keepNumber != null && r.RequestNumber == keepNumber) { target = row; break; }
            }
            if (target == null && dgvRequests.Rows.Count > 0) target = dgvRequests.Rows[0];
            if (target != null)
            {
                target.Selected = true;
                dgvRequests.CurrentCell = target.Cells[0];
            }

            bool empty = shown.Count == 0;
            dgvRequests.Visible = !empty;
            lblEmptyRequests.Visible = empty;
            lblResults.Text = shown.Count == all.Count
                ? "Showing all " + all.Count + (all.Count == 1 ? " request" : " requests")
                : "Showing " + shown.Count + " of " + all.Count + " requests";
            if (all.Count == 0) lblEmptyRequests.Text = "No requests have been submitted yet.\nNew customer requests will appear here for approval.";
            else lblEmptyRequests.Text = "No requests match your filters.\nTry a different search or clear the filters.";

            UpdateDetail();
        }

        private void UpdateStats(List<MaintenanceRequest> all)
        {
            int pending = all.Count(r => r.Status == RequestStatus.Requested);
            int active = all.Count(r => r.Status == RequestStatus.Approved || r.Status == RequestStatus.ProviderAssigned ||
                                        r.Status == RequestStatus.Scheduled || r.Status == RequestStatus.InProgress);
            int done = all.Count(r => r.Status == RequestStatus.Completed);
            int cancelled = all.Count(r => r.Status == RequestStatus.Cancelled);

            lblStatTotal.Text = all.Count.ToString();
            lblStatPending.Text = pending.ToString();
            lblStatActive.Text = active.ToString();
            lblStatDone.Text = done.ToString();
            lblStatCancelled.Text = cancelled.ToString();

            lblStatPendingHint.Text = pending == 0 ? "Nothing waiting - all caught up" : "Click to review them now";
        }

        // ==================================================================
        //  DETAIL CARD
        // ==================================================================
        private void dgvRequests_SelectionChanged(object? sender, EventArgs e)
        {
            if (!ready) return;
            UpdateDetail();
        }

        private void UpdateDetail()
        {
            MaintenanceRequest? r = SelectedRequest();

            if (r == null)
            {
                lblReqNumber.Text = "Nothing selected";
                pillReqStatus.PillText = "No request selected";
                pillReqStatus.PillBack = Color.FromArgb(241, 245, 249);
                pillReqStatus.PillFore = Theme.Muted;
                barProgress.Value = 0;
                lblProgress.Text = "Select a request in the table to manage it";
                fldCustomer.Value = "-";
                fldService.Value = "-";
                fldWhen.Value = "-";
                fldProvider.Value = "-";
                fldEstimate.Value = "-";
                fldFinal.Value = "-";
                fldAddress.Value = "-";
                lblDescription.Text = "-";
                btnApproveRequests.Enabled = false;
                btnReassign.Enabled = false;
                btnCancelRequests.Enabled = false;
                return;
            }

            Color back;
            Color fore;
            AdminUi.StatusColors(r.Status, out back, out fore);

            lblReqNumber.Text = r.RequestNumber;
            pillReqStatus.PillText = AdminUi.StatusText(r.Status);
            pillReqStatus.PillBack = back;
            pillReqStatus.PillFore = fore;

            if (r.Status == RequestStatus.Cancelled)
            {
                barProgress.BarColor = Theme.Red;
                barProgress.Value = 100;
                lblProgress.Text = "This request was cancelled";
            }
            else
            {
                int step = Array.IndexOf(Journey, r.Status);
                barProgress.BarColor = r.Status == RequestStatus.Completed ? Theme.Green : Theme.Orange;
                barProgress.Value = (step + 1) * 100 / Journey.Length;
                lblProgress.Text = "Step " + (step + 1) + " of " + Journey.Length + "  -  " + AdminUi.StatusText(r.Status);
            }

            fldCustomer.Value = string.IsNullOrWhiteSpace(r.CustomerId) ? "-" : r.CustomerId;
            fldService.Value = string.IsNullOrWhiteSpace(r.ServiceCategory) ? "-" : r.ServiceCategory;
            fldWhen.Value = r.PreferredDate.ToString("dd MMM yyyy") + (string.IsNullOrWhiteSpace(r.PreferredTime) ? "" : ", " + r.PreferredTime);
            fldProvider.Value = string.IsNullOrWhiteSpace(r.AssignedProviderId) ? "Unassigned" : r.AssignedProviderId;
            fldEstimate.Value = AdminUi.Money(r.EstimatedCost);
            fldFinal.Value = r.FinalCost > 0 ? AdminUi.Money(r.FinalCost) : "Pending";
            fldAddress.Value = string.IsNullOrWhiteSpace(r.PropertyAddress) ? "-" : r.PropertyAddress;
            lblDescription.Text = string.IsNullOrWhiteSpace(r.ProblemDescription) ? "-" : r.ProblemDescription.Trim();
            descNote.AutoScrollPosition = new Point(0, 0);

            bool open = r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled;
            btnApproveRequests.Enabled = r.Status == RequestStatus.Requested;
            btnReassign.Enabled = r.Status == RequestStatus.Approved || r.Status == RequestStatus.ProviderAssigned ||
                                  r.Status == RequestStatus.Scheduled || r.Status == RequestStatus.Cancelled;
            btnCancelRequests.Enabled = open;
        }

        private void dgvRequests_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvRequests.Columns[e.ColumnIndex].Name != "Status") return;
            if (!(e.Value is RequestStatus)) return;

            RequestStatus s = (RequestStatus)e.Value;
            Color back;
            Color fore;
            AdminUi.StatusColors(s, out back, out fore);
            AdminUi.PaintPillCell(e, AdminUi.StatusText(s), back, fore);
        }

        private void dgvRequests_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string col = dgvRequests.Columns[e.ColumnIndex].Name;

            if (col == "ProblemDescription")
            {
                // one tidy line: line breaks / extra spaces collapsed, full text appears on hover
                string full = (e.Value.ToString() ?? "").Trim();
                string oneLine = System.Text.RegularExpressions.Regex.Replace(full, @"\s+", " ");
                if (oneLine.Length == 0) oneLine = "-";
                e.Value = oneLine;
                e.FormattingApplied = true;
                dgvRequests.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = full;
            }
            else if (col == "AssignedProviderId")
            {
                string v = e.Value.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(v) || v == "Unassigned")
                {
                    e.Value = "Unassigned";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Theme.Muted;
                    e.CellStyle.Font = mutedCellFont;
                }
            }
            else if (col == "FinalCost")
            {
                decimal d;
                if (decimal.TryParse(e.Value.ToString(), out d) && d <= 0)
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                    e.CellStyle.ForeColor = Theme.Muted;
                }
            }
        }

        // ==================================================================
        //  ACTIONS
        // ==================================================================
        private void SaveChange(MaintenanceRequest changed)
        {
            var requests = DataManager.LoadRequests();
            var existing = requests.FirstOrDefault(r => r.RequestNumber == changed.RequestNumber);
            if (existing != null)
            {
                existing.Status = changed.Status;
                existing.AssignedProviderId = changed.AssignedProviderId;
                DataManager.SaveRequests(requests);
            }
        }

        private void btnCancelRequests_Click(object sender, EventArgs e)
        {
            var request = SelectedRequest();

            if (request != null)
            {
                var result = MessageBox.Show(
                    "Do you really want to cancel this request?\n\n" + request.RequestNumber + "  |  " + request.ServiceCategory,
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string errorMessage;
                    if (request.TryUpdateStatus(RequestStatus.Cancelled, out errorMessage))
                    {
                        SaveChange(request);
                        AdminUi.Toast(this, "Request cancelled");
                        RefreshGrid();
                    }
                    else
                    {
                        AdminUi.Toast(this, errorMessage, false);
                    }
                }
            }
            else
            {
                AdminUi.Toast(this, "Please select a request first", false);
            }
        }

        private void RefreshGrid()
        {
            ApplyFilters();
        }

        private void btnApproveRequests_Click(object sender, EventArgs e)
        {
            var request = SelectedRequest();

            if (request != null)
            {
                string errorMessage;
                if (request.TryUpdateStatus(RequestStatus.Approved, out errorMessage))
                {
                    SaveChange(request);
                    AdminUi.Toast(this, "Request approved - now assign a provider");
                    RefreshGrid();
                }
                else
                {
                    AdminUi.Toast(this, errorMessage, false);
                }
            }
            else
            {
                AdminUi.Toast(this, "Please select a request first", false);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdminDashboard adminDashboard = new frmAdminDashboard();
            adminDashboard.Show();
        }

        private void RequestManagement_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchRequests_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Assign (or change) the provider for an approved request
        private void btnReassign_Click(object sender, EventArgs e)
        {
            var request = SelectedRequest();
            if (request == null)
            {
                AdminUi.Toast(this, "Please select a request first", false);
                return;
            }

            bool wasCancelled = request.Status == RequestStatus.Cancelled;

            if (request.Status != RequestStatus.Approved &&
                request.Status != RequestStatus.ProviderAssigned &&
                request.Status != RequestStatus.Scheduled &&
                !wasCancelled)
            {
                AdminUi.Toast(this, "Approve the request before assigning a provider", false);
                return;
            }

            if (wasCancelled)
            {
                DialogResult reinstate = MessageBox.Show(
                    "This request was cancelled.\n\nDo you want to reinstate it and assign a provider?\n\n" +
                    request.RequestNumber + "  |  " + request.ServiceCategory,
                    "Reinstate Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reinstate != DialogResult.Yes) return;
            }

            var providers = DataManager.LoadServiceProviders();
            if (providers.Count == 0)
            {
                MessageBox.Show("There are no service providers yet.\nAdd one in Provider Management first.",
                    "Assign Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PickProviderDialog dlg = new PickProviderDialog(providers, request.RequestNumber, request.ServiceCategory, request.AssignedProviderId))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK || string.IsNullOrWhiteSpace(dlg.SelectedProviderName))
                    return;

                string errorMessage = "";
                if (wasCancelled)
                {
                    // administrator override: bring the cancelled request back, straight to "Provider Assigned"
                    if (!request.TryReinstate(RequestStatus.ProviderAssigned, out errorMessage))
                    {
                        AdminUi.Toast(this, errorMessage, false);
                        return;
                    }
                }
                else if (request.Status == RequestStatus.Approved &&
                    !request.TryUpdateStatus(RequestStatus.ProviderAssigned, out errorMessage))
                {
                    AdminUi.Toast(this, errorMessage, false);
                    return;
                }

                request.AssignedProviderId = dlg.SelectedProviderName!;
                SaveChange(request);
                AdminUi.Toast(this, (wasCancelled ? "Request reinstated and assigned to " : "Assigned to ") + dlg.SelectedProviderName);
                RefreshGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearchRequests.Focus();
            ApplyFilters();
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminDashboard frmAdminDashboard = new frmAdminDashboard();
            this.Hide();
            frmAdminDashboard.Show();
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProviderManagement management = new frmProviderManagement();
            this.Hide();
            management.Show();
        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReports reports = new frmReports();
            this.Hide();
            reports.Show();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // already on the Requests page - just refresh the data
            RefreshGrid();
        }

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            AdminUi.Logout(this);
        }
    }
}
