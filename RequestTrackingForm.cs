using HomeHero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public enum RequestFilter { All, Active, Completed, Cancelled }

    public partial class frmRequestTracking : FitForm
    {
        private List<MaintenanceRequest> customerRequests = new List<MaintenanceRequest>();
        private List<MaintenanceRequest> visibleRequests = new List<MaintenanceRequest>();
        private string currentCustomerId;
        private RequestFilter currentFilter = RequestFilter.All;

        private readonly System.Windows.Forms.Timer countTimer = new System.Windows.Forms.Timer();
        private readonly decimal[] countTargets = new decimal[4];
        private int countStep;

        public frmRequestTracking()
            : this(CustomerSession.CustomerId)
        {
        }

        public frmRequestTracking(string customerId)
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            currentCustomerId = customerId;
            BuildUi();

            countTimer.Interval = 25;
            countTimer.Tick += CountTimer_Tick;
            FormClosed += (s, e) => countTimer.Dispose();

            Load += RequestTrackingForm_Load;
        }

        private void RequestTrackingForm_Load(object? sender, EventArgs e)
        {
            LoadData();
            UpdateFilterButtons();
        }

        // ------------------------------------------------------------------
        //  DATA
        // ------------------------------------------------------------------
        private void LoadData()
        {
            List<MaintenanceRequest> allRequests = DataManager.LoadRequests();

            customerRequests = allRequests
                .Where(request => request.CustomerId == currentCustomerId)
                .OrderByDescending(request => request.PreferredDate)
                .ToList();

            ApplyFilter();
            UpdateStats();
            lblUpdated.Text = "Last updated " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void ApplyFilter()
        {
            IEnumerable<MaintenanceRequest> query = customerRequests;

            switch (currentFilter)
            {
                case RequestFilter.Active:
                    query = query.Where(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled);
                    break;
                case RequestFilter.Completed:
                    query = query.Where(r => r.Status == RequestStatus.Completed);
                    break;
                case RequestFilter.Cancelled:
                    query = query.Where(r => r.Status == RequestStatus.Cancelled);
                    break;
            }

            string search = txtSearch.Text.Trim();
            if (search.Length > 0)
            {
                query = query.Where(r =>
                    ContainsText(r.RequestNumber, search) ||
                    ContainsText(r.ServiceCategory, search) ||
                    ContainsText(r.PropertyAddress, search) ||
                    ContainsText(r.ProblemDescription, search));
            }

            visibleRequests = query.ToList();

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = visibleRequests;

            bool empty = visibleRequests.Count == 0;
            lblEmpty.Text = customerRequests.Count == 0
                ? "No requests yet.\nCreate a new service request from your dashboard to get started."
                : "No requests match your search or filter.";
            lblEmpty.Visible = empty;
            if (empty)
            {
                lblEmpty.BringToFront();
                ClearDetails();
            }
            else
            {
                dgvRequests.BringToFront();
                ShowCurrentSelection();
            }
        }

        private static bool ContainsText(string? source, string value)
        {
            return source != null && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void UpdateStats()
        {
            int total = customerRequests.Count;
            int completed = customerRequests.Count(r => r.Status == RequestStatus.Completed);
            int active = customerRequests.Count(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled);
            decimal spend = customerRequests.Where(r => r.Status != RequestStatus.Cancelled).Sum(r => r.EstimatedCost);

            countTargets[0] = total;
            countTargets[1] = active;
            countTargets[2] = completed;
            countTargets[3] = spend;

            countStep = 0;
            countTimer.Start();
        }

        private void CountTimer_Tick(object? sender, EventArgs e)
        {
            countStep++;
            double t = Math.Min(1.0, countStep / 20.0);
            decimal eased = (decimal)(1 - Math.Pow(1 - t, 3));

            lblStatTotal.Text = ((int)Math.Round(countTargets[0] * eased)).ToString();
            lblStatActive.Text = ((int)Math.Round(countTargets[1] * eased)).ToString();
            lblStatCompleted.Text = ((int)Math.Round(countTargets[2] * eased)).ToString();
            lblStatSpend.Text = "R" + (countTargets[3] * eased).ToString("N0");

            if (countStep >= 20)
                countTimer.Stop();
        }

        // ------------------------------------------------------------------
        //  FILTER + SEARCH
        // ------------------------------------------------------------------
        private void SetFilter(RequestFilter filter)
        {
            currentFilter = filter;
            UpdateFilterButtons();
            ApplyFilter();
        }

        private void UpdateFilterButtons()
        {
            StyleChip(btnFilterAll, currentFilter == RequestFilter.All);
            StyleChip(btnFilterActive, currentFilter == RequestFilter.Active);
            StyleChip(btnFilterDone, currentFilter == RequestFilter.Completed);
            StyleChip(btnFilterCancelled, currentFilter == RequestFilter.Cancelled);
        }

        private static void StyleChip(ModernButton chip, bool selected)
        {
            chip.Outline = !selected;
            chip.BaseColor = Theme.Navy;
            chip.HoverColor = Theme.NavyLight;
            chip.Invalidate();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        // ------------------------------------------------------------------
        //  SELECTION -> DETAILS + TIMELINE + AI INSIGHTS
        // ------------------------------------------------------------------
        private void dgvRequests_SelectionChanged(object? sender, EventArgs e)
        {
            ShowCurrentSelection();
        }

        private void ShowCurrentSelection()
        {
            if (dgvRequests.CurrentRow != null &&
                dgvRequests.CurrentRow.DataBoundItem is MaintenanceRequest selected)
            {
                ShowSelectedRequest(selected);
            }
        }

        private void ShowSelectedRequest(MaintenanceRequest selected)
        {
            chatPanel.SetRequest(selected);
            fldRequestNum.Value = selected.RequestNumber;
            fldCategory.Value = selected.ServiceCategory;
            fldProvider.Value = string.IsNullOrWhiteSpace(selected.AssignedProviderId) ? "Unassigned" : selected.AssignedProviderId;
            fldProvider.ValueColor = fldProvider.Value == "Unassigned" ? Theme.Muted : Theme.Text;

            fldAppointment.Value = selected.PreferredDate.ToString("dd MMMM yyyy") + "  |  " + selected.PreferredTime;
            fldEstimated.Value = $"R{selected.EstimatedCost:F2}";

            if (selected.FinalCost > 0)
            {
                fldFinal.Value = $"R{selected.FinalCost:F2}";
                fldFinal.ValueColor = Theme.Green;
            }
            else
            {
                fldFinal.Value = "Pending completion";
                fldFinal.ValueColor = Theme.Muted;
            }

            StatusStyle(selected.Status, out Color fore, out Color back);
            pillStatus.PillText = GetStatusText(selected.Status);
            pillStatus.PillFore = fore;
            pillStatus.PillBack = back;

            timeline.Cancelled = selected.Status == RequestStatus.Cancelled;
            timeline.Current = StageIndex(selected.Status);

            ShowInsights(selected);
        }

        private void ClearDetails()
        {
            chatPanel.SetRequest(null);
            fldRequestNum.Value = "-";
            fldCategory.Value = "-";
            fldProvider.Value = "-";
            fldProvider.ValueColor = Theme.Text;
            fldAppointment.Value = "-";
            fldEstimated.Value = "-";
            fldFinal.Value = "-";
            fldFinal.ValueColor = Theme.Text;

            pillStatus.PillText = "No request selected";
            pillStatus.PillBack = Color.FromArgb(241, 245, 249);
            pillStatus.PillFore = Theme.Muted;

            timeline.Cancelled = false;
            timeline.Current = -1;

            lblAiHeadline.Text = "Select a request to see insights.";
            lblAiProgressText.Text = "JOURNEY PROGRESS";
            barAiProgress.Value = 0;
            lblAiBody.Text = "Hero Insights summarises where your job is, what happens next and how the cost compares.";
            lblAiTip.Text = "";
        }

        private void ShowInsights(MaintenanceRequest r)
        {
            int stage = StageIndex(r.Status);
            int lastStage = 5;

            if (r.Status == RequestStatus.Cancelled)
            {
                lblAiHeadline.Text = "This request was cancelled";
                lblAiProgressText.Text = "JOURNEY STOPPED";
                barAiProgress.Value = 0;
                lblAiBody.Text = "No further action is needed. You can raise a fresh request from your dashboard whenever you are ready.";
                lblAiTip.Text = "Tip: describing the problem in detail helps providers quote accurately the first time.";
                return;
            }

            int pct = stage * 100 / lastStage;
            barAiProgress.Value = pct;
            lblAiProgressText.Text = "JOURNEY PROGRESS  " + pct + "%";

            string next;
            switch (r.Status)
            {
                case RequestStatus.Requested:
                    lblAiHeadline.Text = "Request received - awaiting approval";
                    next = "Next step: our team reviews and approves your request.";
                    break;
                case RequestStatus.Approved:
                    lblAiHeadline.Text = "Approved - finding the right provider";
                    next = "Next step: a " + r.ServiceCategory.ToLowerInvariant() + " provider is assigned to your job.";
                    break;
                case RequestStatus.ProviderAssigned:
                    lblAiHeadline.Text = "Provider assigned - scheduling next";
                    next = "Next step: your appointment is confirmed with the provider.";
                    break;
                case RequestStatus.Scheduled:
                    lblAiHeadline.Text = "Appointment confirmed";
                    next = "Next step: the provider arrives and starts the job.";
                    break;
                case RequestStatus.InProgress:
                    lblAiHeadline.Text = "Work is underway";
                    next = "Next step: the provider completes the job and the final cost is confirmed.";
                    break;
                default:
                    lblAiHeadline.Text = "Job completed";
                    next = "All done - we hope everything is working perfectly.";
                    break;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(next);

            if (r.Status != RequestStatus.Completed)
            {
                int days = (r.PreferredDate.Date - DateTime.Today).Days;
                if (days > 1)
                    sb.Append("  Your preferred date is in " + days + " days (" + r.PreferredDate.ToString("dd MMM") + ").");
                else if (days == 1)
                    sb.Append("  Your preferred date is tomorrow.");
                else if (days == 0)
                    sb.Append("  Your preferred date is today.");
                else
                    sb.Append("  Your preferred date has passed - the provider will confirm a new time.");
            }

            if (r.Status == RequestStatus.Completed && r.FinalCost > 0)
            {
                decimal diff = r.FinalCost - r.EstimatedCost;
                if (diff == 0)
                    sb.Append("  The final cost matched the estimate exactly.");
                else
                {
                    string dir = diff < 0 ? "below" : "above";
                    decimal pctDiff = r.EstimatedCost > 0 ? Math.Abs(diff) * 100m / r.EstimatedCost : 0m;
                    sb.Append("  The final cost came in R" + Math.Abs(diff).ToString("F2") + " " + dir + " the estimate (" + pctDiff.ToString("F0") + "%).");
                }
            }
            else if (r.Status != RequestStatus.Completed)
            {
                sb.Append("  Your estimate of R" + r.EstimatedCost.ToString("F2") + " includes the standard call-out fee.");
            }

            lblAiBody.Text = sb.ToString();
            lblAiTip.Text = "Tip: " + CategoryTip(r.ServiceCategory);
        }

        private static string CategoryTip(string category)
        {
            switch (category)
            {
                case "Plumbing":
                    return "keep the area around the problem clear and know where your main water valve is.";
                case "Electrical":
                    return "avoid using the affected circuit until the provider has inspected it.";
                case "Painting":
                    return "move furniture away from the walls before the provider arrives.";
                case "Appliance Repair":
                    return "have the appliance model number ready for the provider.";
                default:
                    return "make sure someone is home to give the provider access.";
            }
        }

        // ------------------------------------------------------------------
        //  GRID: status pills + friendly cell text
        // ------------------------------------------------------------------
        private void dgvRequests_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colStatus.Index || !(e.Value is RequestStatus status))
                return;

            e.Handled = true;
            Graphics g = e.Graphics!;
            e.PaintBackground(e.CellBounds, (e.State & DataGridViewElementStates.Selected) != 0);

            string text = GetStatusText(status);
            StatusStyle(status, out Color fore, out Color back);

            using (Font f = Theme.MakeSemibold(8.5F))
            {
                Size ts = TextRenderer.MeasureText(g, text, f);
                int h = 26;
                int w = Math.Min(ts.Width + 26, Math.Max(40, e.CellBounds.Width - 14));
                Rectangle pill = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + (e.CellBounds.Height - h) / 2, w, h);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (System.Drawing.Drawing2D.GraphicsPath path = Theme.RoundRect(pill, h / 2f))
                using (SolidBrush b = new SolidBrush(back))
                    g.FillPath(b, path);

                TextRenderer.DrawText(g, text, f, pill, fore,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
            }

            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
        }

        private void dgvRequests_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle == null) return;

            string column = dgvRequests.Columns[e.ColumnIndex].Name;

            if (column == "FinalCost" && e.Value is decimal final && final <= 0)
            {
                e.Value = "Pending";
                e.CellStyle.ForeColor = Theme.Muted;
                e.FormattingApplied = true;
            }
            else if (column == "AssignedProviderId" && e.Value is string provider &&
                     (string.IsNullOrWhiteSpace(provider) || provider == "Unassigned"))
            {
                e.CellStyle.ForeColor = Theme.Muted;
            }
        }

        private static void StatusStyle(RequestStatus status, out Color fore, out Color back)
        {
            switch (status)
            {
                case RequestStatus.Requested:
                    fore = Theme.Blue; back = Theme.BlueSoft; break;
                case RequestStatus.Approved:
                    fore = Theme.Purple; back = Theme.PurpleSoft; break;
                case RequestStatus.ProviderAssigned:
                    fore = Theme.Amber; back = Theme.AmberSoft; break;
                case RequestStatus.Scheduled:
                    fore = Color.FromArgb(13, 148, 136); back = Color.FromArgb(204, 251, 241); break;
                case RequestStatus.InProgress:
                    fore = Color.FromArgb(194, 65, 12); back = Theme.OrangeSoft; break;
                case RequestStatus.Completed:
                    fore = Theme.Green; back = Theme.GreenSoft; break;
                case RequestStatus.Cancelled:
                    fore = Theme.Red; back = Theme.RedSoft; break;
                default:
                    fore = Theme.Muted; back = Color.FromArgb(241, 245, 249); break;
            }
        }

        private static int StageIndex(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Requested: return 0;
                case RequestStatus.Approved: return 1;
                case RequestStatus.ProviderAssigned: return 2;
                case RequestStatus.Scheduled: return 3;
                case RequestStatus.InProgress: return 4;
                case RequestStatus.Completed: return 5;
                default: return 0;
            }
        }

        // ------------------------------------------------------------------
        //  BUTTONS
        // ------------------------------------------------------------------
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            frmCustomerDashboard backtoHome = new frmCustomerDashboard();
            this.Hide();
            backtoHome.Show();
        }

        private string GetStatusText(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Requested:
                    return "Requested";

                case RequestStatus.Approved:
                    return "Approved";

                case RequestStatus.ProviderAssigned:
                    return "Provider Assigned";

                case RequestStatus.Scheduled:
                    return "Scheduled";

                case RequestStatus.InProgress:
                    return "In Progress";

                case RequestStatus.Completed:
                    return "Completed";

                case RequestStatus.Cancelled:
                    return "Cancelled";

                default:
                    return "Unknown";
            }
        }
    }
}
