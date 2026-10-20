using HomeHero_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    public partial class frmProviderManagement : FitForm
    {
        // ---- data ----
        private List<ServiceProvider> allProviders = new List<ServiceProvider>();
        private List<MaintenanceRequest> allRequests = new List<MaintenanceRequest>();
        private bool binding;

        // ---- new UI pieces (existing controls keep their original names) ----
        private ComboBox cbxSpecialisation = null!;
        private ModernButton btnClearSearch = null!;
        private ModernButton btnExportProviders = null!;
        private Label lblProviderCount = null!;
        private Label lblStatTotal = null!;
        private Label lblStatAvailable = null!;
        private Label lblStatActive = null!;
        private Label lblStatAreas = null!;
        private Label lblStatTotalHint = null!;
        private Label lblStatAvailableHint = null!;
        private Label lblStatActiveHint = null!;
        private Label lblStatAreasHint = null!;

        // ---- detail card ----
        private CardPanel detailCard = null!;
        private AvatarCircle avatar = null!;
        private Label lblDetName = null!;
        private PillLabel pillWorkload = null!;
        private FieldBlock fldEmail = null!;
        private FieldBlock fldPhone = null!;
        private FieldBlock fldArea = null!;
        private FieldBlock fldJobs = null!;
        private FlowLayoutPanel flowSpec = null!;
        private MeterBar barWorkload = null!;
        private Label lblWorkloadHint = null!;
        private ModernButton btnEmailProvider = null!;
        private ModernButton btnResetPassword = null!;
        private ModernButton btnVerifyProvider = null!;
        private Panel detailBody = null!;     // scrolls if the card is short
        private Panel actionBar = null!;      // buttons stay pinned to the bottom of the card
        private string selectedEmail = "";

        private readonly Font boldCellFont = Theme.MakeFont(10F, FontStyle.Bold);

        public frmProviderManagement()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildUi();
            ReloadAll();
        }

        // ==================================================================
        //  UI CONSTRUCTION  (re-uses the designer's controls, restyled)
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();

            // old helper controls that the new layout replaces
            label3.Visible = false;
            flowLayoutPanel1.Visible = false;

            Panel body = new Panel();
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1150, 880);
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

            AdminUi.ApplyChrome(this, "lnklblProviders", body);

            dgvProviders.SelectionChanged += dgvProviders_SelectionChanged;
            dgvProviders.CellFormatting += dgvProviders_CellFormatting;
            txtSearchProvider.TextChanged += delegate { ApplyProviderFilter(); };
            txtSearchProvider.KeyDown += delegate (object? s, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; ApplyProviderFilter(); }
            };

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
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 560F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            row.Controls.Add(AdminUi.PageTitle("Provider Management", ""), 0, 0);

            // action buttons (original buttons, new look)
            btnAddProvider_.Text = "Add Provider";
            btnAddProvider_.BackColor = Color.Transparent;
            btnAddProvider_.Size = new Size(170, 50);
            btnAddProvider_.Margin = new Padding(12, 6, 0, 0);

            btnRemoveProvider.Text = "Remove Provider";
            btnRemoveProvider.BackColor = Color.Transparent;
            btnRemoveProvider.Outline = true;
            btnRemoveProvider.BaseColor = Theme.Red;
            btnRemoveProvider.Size = new Size(190, 50);
            btnRemoveProvider.Margin = new Padding(12, 6, 0, 0);

            btnExportProviders = new ModernButton();
            btnExportProviders.Text = "Export CSV";
            btnExportProviders.Outline = true;
            btnExportProviders.BaseColor = Theme.Navy;
            btnExportProviders.Size = new Size(140, 50);
            btnExportProviders.Margin = new Padding(12, 6, 0, 0);
            btnExportProviders.Click += delegate { AdminUi.ExportGrid(this, dgvProviders, "providers"); };

            FlowLayoutPanel actions = new FlowLayoutPanel();
            actions.Dock = DockStyle.Fill;
            actions.FlowDirection = FlowDirection.RightToLeft;
            actions.WrapContents = false;
            actions.BackColor = Color.Transparent;
            actions.Controls.Add(btnAddProvider_);
            actions.Controls.Add(btnRemoveProvider);
            actions.Controls.Add(btnExportProviders);
            row.Controls.Add(actions, 1, 0);
            return row;
        }

        private Control BuildStatRow()
        {
            Control c1 = AdminUi.StatCard("Total Providers", "Registered on the platform", Theme.Navy, out lblStatTotal, out lblStatTotalHint);
            Control c2 = AdminUi.StatCard("Available Now", "Providers with no active jobs", Theme.Green, out lblStatAvailable, out lblStatAvailableHint);
            Control c3 = AdminUi.StatCard("Active Jobs", "Currently assigned to providers", Theme.Orange, out lblStatActive, out lblStatActiveHint);
            Control c4 = AdminUi.StatCard("Service Areas", "Distinct areas covered", Theme.Purple, out lblStatAreas, out lblStatAreasHint);
            return AdminUi.StatRow(4, c1, c2, c3, c4);
        }

        private Control BuildMainRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 410F));
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

            // ---- toolbar ----
            txtSearchProvider.PlaceholderText = "Search by name, email, area or specialisation";
            InputFrame searchFrame = AdminUi.Frame(txtSearchProvider, 430, 50);

            cbxSpecialisation = new ComboBox();
            cbxSpecialisation.SelectedIndexChanged += delegate { if (!binding) ApplyProviderFilter(); };
            InputFrame specFrame = AdminUi.Frame(cbxSpecialisation, 250, 50);

            btnSearch.Text = "Search";
            btnSearch.BackColor = Color.Transparent;
            btnSearch.Size = new Size(120, 50);
            btnSearch.Margin = new Padding(0, 0, 12, 8);

            btnClearSearch = new ModernButton();
            btnClearSearch.Text = "Clear";
            btnClearSearch.Outline = true;
            btnClearSearch.BaseColor = Theme.Navy;
            btnClearSearch.Size = new Size(100, 50);
            btnClearSearch.Margin = new Padding(0, 0, 0, 8);
            btnClearSearch.Click += delegate
            {
                binding = true;
                txtSearchProvider.Text = "";
                if (cbxSpecialisation.Items.Count > 0) cbxSpecialisation.SelectedIndex = 0;
                binding = false;
                ApplyProviderFilter();
            };

            FlowLayoutPanel toolbar = new FlowLayoutPanel();
            toolbar.Dock = DockStyle.Top;
            toolbar.AutoSize = true;
            toolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toolbar.WrapContents = true;
            toolbar.BackColor = Color.Transparent;
            toolbar.Controls.Add(searchFrame);
            toolbar.Controls.Add(specFrame);
            toolbar.Controls.Add(btnSearch);
            toolbar.Controls.Add(btnClearSearch);

            lblProviderCount = Theme.MakeLabel("", 9.5F, FontStyle.Regular, Theme.Muted);
            lblProviderCount.AutoSize = false;
            lblProviderCount.Dock = DockStyle.Top;
            lblProviderCount.Height = 34;
            lblProviderCount.TextAlign = ContentAlignment.MiddleLeft;

            AdminUi.StyleGrid(dgvProviders);

            card.Controls.Add(dgvProviders);
            card.Controls.Add(lblProviderCount);
            card.Controls.Add(toolbar);
            dgvProviders.BringToFront();
            return card;
        }

        private Control BuildDetailCard()
        {
            detailCard = new CardPanel();
            detailCard.Dock = DockStyle.Fill;
            detailCard.Margin = new Padding(0, 6, 0, 0);
            detailCard.AccentColor = Theme.Orange;
            detailCard.Padding = new Padding(10, 12, 10, 18);   // re-scaled for DPI in LayoutDetailCard

            avatar = new AvatarCircle();
            avatar.Size = new Size(84, 84);
            avatar.Location = new Point(30, 20);

            lblDetName = Theme.MakeLabel("Select a provider", 15F, FontStyle.Bold, Theme.Navy);
            lblDetName.AutoSize = false;
            lblDetName.TextAlign = ContentAlignment.MiddleCenter;
            lblDetName.Size = new Size(350, 34);
            lblDetName.Location = new Point(130, 28);
            lblDetName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            pillWorkload = new PillLabel();
            pillWorkload.Width = 150;
            pillWorkload.Location = new Point(130, 70);
            pillWorkload.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pillWorkload.PillText = "No provider selected";
            pillWorkload.PillBack = Color.FromArgb(241, 245, 249);
            pillWorkload.PillFore = Theme.Muted;

            fldEmail = MakeField("Email", 130);
            fldPhone = MakeField("Phone", 186);
            fldArea = MakeField("Service area", 242);
            fldJobs = MakeField("Assigned jobs", 298);

            Label specCaption = Theme.MakeLabel("SPECIALISATIONS", 8F, FontStyle.Bold, Theme.Muted);
            specCaption.Location = new Point(30, 370);

            flowSpec = new FlowLayoutPanel();
            flowSpec.BackColor = Color.Transparent;
            flowSpec.Location = new Point(30, 392);
            flowSpec.Size = new Size(350, 64);
            flowSpec.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            flowSpec.WrapContents = true;

            Label loadCaption = Theme.MakeLabel("CURRENT WORKLOAD", 8F, FontStyle.Bold, Theme.Muted);
            loadCaption.Location = new Point(30, 464);

            barWorkload = new MeterBar();
            barWorkload.Location = new Point(30, 490);
            barWorkload.Size = new Size(350, 12);
            barWorkload.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            lblWorkloadHint = Theme.MakeLabel("-", 9F, FontStyle.Regular, Theme.Muted);
            lblWorkloadHint.Location = new Point(30, 508);

            btnEmailProvider = new ModernButton();
            btnEmailProvider.Text = "Send Email";
            btnEmailProvider.Outline = true;
            btnEmailProvider.BaseColor = Theme.Navy;
            btnEmailProvider.Size = new Size(170, 48);
            btnEmailProvider.Location = new Point(30, 596);
            btnEmailProvider.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnEmailProvider.Enabled = false;
            btnEmailProvider.Click += btnEmailProvider_Click;

            btnResetPassword = new ModernButton();
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.Outline = true;
            btnResetPassword.BaseColor = Theme.Orange;
            btnResetPassword.Size = new Size(170, 48);
            btnResetPassword.Location = new Point(210, 596);
            btnResetPassword.Enabled = false;
            btnResetPassword.Click += btnResetPassword_Click;

            btnVerifyProvider = new ModernButton();
            btnVerifyProvider.Text = "Verify Provider";
            btnVerifyProvider.Outline = true;
            btnVerifyProvider.BaseColor = Theme.Green;
            btnVerifyProvider.Size = new Size(350, 44);
            btnVerifyProvider.Location = new Point(30, 650);
            btnVerifyProvider.Enabled = false;
            btnVerifyProvider.Click += btnVerifyProvider_Click;

            // body (details, scrolls when the card is short) + action bar (always visible)
            detailBody = new Panel();
            detailBody.Dock = DockStyle.Fill;
            detailBody.BackColor = Color.White;
            detailBody.AutoScroll = true;

            actionBar = new Panel();
            actionBar.Dock = DockStyle.Bottom;
            actionBar.Height = 70;
            actionBar.BackColor = Color.White;
            actionBar.Paint += delegate (object? sender, PaintEventArgs pe)
            {
                using (Pen line = new Pen(Theme.Border))
                    pe.Graphics.DrawLine(line, 20, 0, actionBar.Width - 20, 0);
            };
            actionBar.Controls.Add(btnEmailProvider);
            actionBar.Controls.Add(btnResetPassword);
            actionBar.Controls.Add(btnVerifyProvider);

            detailBody.Controls.Add(avatar);
            detailBody.Controls.Add(lblDetName);
            detailBody.Controls.Add(pillWorkload);
            detailBody.Controls.Add(fldEmail);
            detailBody.Controls.Add(fldPhone);
            detailBody.Controls.Add(fldArea);
            detailBody.Controls.Add(fldJobs);
            detailBody.Controls.Add(specCaption);
            detailBody.Controls.Add(flowSpec);
            detailBody.Controls.Add(loadCaption);
            detailBody.Controls.Add(barWorkload);
            detailBody.Controls.Add(lblWorkloadHint);

            detailCard.Controls.Add(actionBar);
            detailCard.Controls.Add(detailBody);
            detailBody.BringToFront();

            // lay the card out from its real size (centre avatar / name / pill,
            // stretch the rest, split the button bar) whenever it is resized
            detailCard.Resize += delegate { LayoutDetailCard(); };
            detailBody.Resize += delegate { LayoutDetailCard(); };
            actionBar.Resize += delegate { LayoutDetailCard(); };
            LayoutDetailCard();
            return detailCard;
        }

        private void LayoutDetailCard()
        {
            if (detailCard == null || detailBody == null || actionBar == null) return;

            float s = detailCard.DeviceDpi / 96f;

            // keep the white body inside the card's rounded corners and clear of its orange edge + shadow
            Padding wanted = new Padding((int)(10 * s), (int)(12 * s), (int)(10 * s), (int)(18 * s));
            if (detailCard.Padding != wanted) detailCard.Padding = wanted;

            int barHeight = btnEmailProvider.Height * 2 + btnVerifyProvider.Height + (int)(32 * s);
            if (actionBar.Height != barHeight) actionBar.Height = barHeight;

            int bodyWidth = detailBody.ClientSize.Width;
            if (bodyWidth < 50) return;

            int pad = fldEmail.Left;                                   // same left gutter as the fields
            int w = Math.Max(50, bodyWidth - 2 * pad);

            foreach (Control c in new Control[] { fldEmail, fldPhone, fldArea, fldJobs, flowSpec, barWorkload })
                c.Width = w;
            flowSpec.MaximumSize = new Size(w, 0);
            flowSpec.PerformLayout();

            int scale = Math.Max(1, (int)Math.Round(s));
            int specTop = 370;
            int rowWidth = 0;
            int rows = 1;
            foreach (Control pill in flowSpec.Controls)
            {
                int pillWidth = pill.Width + pill.Margin.Horizontal;
                if (rowWidth > 0 && rowWidth + pillWidth > w)
                {
                    rows++;
                    rowWidth = 0;
                }
                rowWidth += pillWidth;
            }
            flowSpec.Height = Math.Max(30 * scale, rows * 38 * scale);
            flowSpec.SetBounds(pad, specTop + 22 * scale, w, flowSpec.Height);
            int loadTop = flowSpec.Bottom + 12 * scale;
            int barTop = loadTop + 26 * scale;
            int hintTop = barTop + 18 * scale;

            detailBody.AutoScrollMinSize = new Size(0, hintTop + lblWorkloadHint.Height + 20 * scale);
            Control? specCaption = detailBody.Controls.Cast<Control>()
                .FirstOrDefault(c => c is Label && c.Text == "SPECIALISATIONS");
            Control? loadCaption = detailBody.Controls.Cast<Control>()
                .FirstOrDefault(c => c is Label && c.Text == "CURRENT WORKLOAD");
            if (specCaption != null) specCaption.SetBounds(pad, specTop, w, 18 * scale);
            if (loadCaption != null) loadCaption.SetBounds(pad, loadTop, w, 18 * scale);
            barWorkload.SetBounds(pad, barTop, w, 12 * scale);
            lblWorkloadHint.SetBounds(pad, hintTop, w, lblWorkloadHint.Height);

            // header block: avatar on the left edge, name + status pill beside it - all left-aligned
            // with the detail fields underneath
            avatar.Left = pad;
            int textLeft = avatar.Right + (int)(18 * s);
            lblDetName.TextAlign = ContentAlignment.MiddleLeft;
            lblDetName.Left = textLeft;
            lblDetName.Width = Math.Max(60, bodyWidth - textLeft - pad);
            lblDetName.Top = avatar.Top + avatar.Height / 2 - lblDetName.Height - (int)(2 * s);
            pillWorkload.Left = textLeft;
            pillWorkload.Top = avatar.Top + avatar.Height / 2 + (int)(6 * s);

            // "Send Email" and "Reset Password" share the pinned bottom bar
            int barPad = (int)(20 * s);
            int gap = (int)(10 * s);
            int bw = Math.Max(100, actionBar.ClientSize.Width - 2 * barPad);
            int rowHeight = btnEmailProvider.Height;
            int firstTop = (int)(10 * s);
            int half = (bw - gap) / 2;
            btnEmailProvider.SetBounds(barPad, firstTop, half, rowHeight);
            btnResetPassword.SetBounds(barPad + half + gap, firstTop, bw - half - gap, rowHeight);
            btnVerifyProvider.SetBounds(barPad, firstTop + rowHeight + (int)(8 * s), bw, btnVerifyProvider.Height);
        }

        private FieldBlock MakeField(string caption, int top)
        {
            FieldBlock f = new FieldBlock(caption);
            f.Location = new Point(30, top);
            f.Size = new Size(350, 56);
            f.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            return f;
        }

        // ==================================================================
        //  DATA
        // ==================================================================
        private void ReloadAll()
        {
            allProviders = DataManager.LoadServiceProviders();
            allRequests = DataManager.LoadRequests();

            // specialisation filter list
            binding = true;
            string previous = cbxSpecialisation.SelectedItem == null ? "" : cbxSpecialisation.SelectedItem.ToString()!;
            cbxSpecialisation.Items.Clear();
            cbxSpecialisation.Items.Add("All specialisations");
            foreach (string specName in allProviders
                .Where(p => p.Specialisation != null)
                .SelectMany(p => p.Specialisation)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x))
            {
                cbxSpecialisation.Items.Add(specName);
            }
            int idx = previous.Length == 0 ? 0 : cbxSpecialisation.Items.IndexOf(previous);
            cbxSpecialisation.SelectedIndex = idx < 0 ? 0 : idx;
            binding = false;

            UpdateStats();
            ApplyProviderFilter();
        }

        private int ActiveJobsFor(ServiceProvider p)
        {
            return allRequests.Count(r => AdminUi.IsAssignedTo(r, p) &&
                r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled);
        }

        private int TotalJobsFor(ServiceProvider p)
        {
            int fromRequests = allRequests.Count(r => AdminUi.IsAssignedTo(r, p) && r.Status != RequestStatus.Cancelled);
            int own = p.Assignedjobs == null ? 0 : p.Assignedjobs.Count;
            return Math.Max(fromRequests, own);
        }

        private void UpdateStats()
        {
            int total = allProviders.Count;
            int available = allProviders.Count(p => ActiveJobsFor(p) == 0);
            int activeJobs = allProviders.Sum(p => ActiveJobsFor(p));
            int areas = allProviders
                .Select(p => (p.Location ?? "").Trim().ToLowerInvariant())
                .Where(a => a.Length > 0)
                .Distinct()
                .Count();

            lblStatTotal.Text = total.ToString();
            lblStatAvailable.Text = available.ToString();
            lblStatActive.Text = activeJobs.ToString();
            lblStatAreas.Text = areas.ToString();

            lblStatAvailableHint.Text = total == 0 ? "Providers with no active jobs" : (available * 100 / total) + "% of providers are free";
        }

        private void ApplyProviderFilter()
        {
            if (binding || allProviders == null) return;

            string text = txtSearchProvider.Text.Trim();
            string spec = cbxSpecialisation.SelectedIndex > 0 ? cbxSpecialisation.SelectedItem!.ToString()! : "";

            IEnumerable<ServiceProvider> query = allProviders;

            if (text.Length > 0)
            {
                query = query.Where(p =>
                    (p.FirstName + " " + p.LastName).Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    (p.Email ?? "").Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    (p.PhoneNumber ?? "").Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    (p.Location ?? "").Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    (p.Specialisation != null && p.Specialisation.Any(s => s.Contains(text, StringComparison.OrdinalIgnoreCase))));
            }

            if (spec.Length > 0)
            {
                query = query.Where(p => p.Specialisation != null &&
                    p.Specialisation.Any(s => string.Equals(s, spec, StringComparison.OrdinalIgnoreCase)));
            }

            LoadProvidersToGrid(query.ToList());
        }

        private void LoadProvidersToGrid(IEnumerable<ServiceProvider> providers)
        {
            List<ServiceProvider> list = providers.ToList();
            string keepId = SelectedProviderId();

            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Columns.Add("Phone");
            table.Columns.Add("Service Area");
            table.Columns.Add("Specialisation");
            table.Columns.Add("Jobs", typeof(int));

            foreach (var p in list)
            {
                string name = AdminUi.TitleCase(p.FirstName + " " + p.LastName);

                string specialisation = p.Specialisation == null ||
                                        p.Specialisation.Count == 0
                    ? "None"
                    : string.Join(", ", p.Specialisation);

                table.Rows.Add(
                    p.UserId.ToString(),
                    name,
                    p.Email,
                    p.PhoneNumber,
                    p.Location,
                    specialisation,
                    TotalJobsFor(p)
                );
            }

            binding = true;
            dgvProviders.DataSource = null;
            dgvProviders.DataSource = table;

            if (dgvProviders.Columns.Contains("Id")) dgvProviders.Columns["Id"]!.Visible = false;
            SetColumn("Name", 22, true);
            SetColumn("Email", 26, false);
            SetColumn("Phone", 14, false);
            SetColumn("Service Area", 16, false);
            SetColumn("Specialisation", 28, false);
            SetColumn("Jobs", 8, false);
            if (dgvProviders.Columns.Contains("Jobs"))
            {
                dgvProviders.Columns["Jobs"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProviders.Columns["Jobs"]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // restore selection (or pick the first row)
            dgvProviders.ClearSelection();
            DataGridViewRow? target = null;
            foreach (DataGridViewRow row in dgvProviders.Rows)
            {
                if (keepId.Length > 0 && Convert.ToString(row.Cells["Id"].Value) == keepId) { target = row; break; }
            }
            if (target == null && dgvProviders.Rows.Count > 0) target = dgvProviders.Rows[0];
            if (target != null)
            {
                target.Selected = true;
                int firstVisible = dgvProviders.Columns.Cast<DataGridViewColumn>().First(c => c.Visible).Index;
                dgvProviders.CurrentCell = target.Cells[firstVisible];
            }
            binding = false;

            lblProviderCount.Text = list.Count == allProviders.Count
                ? "Showing all " + allProviders.Count + (allProviders.Count == 1 ? " provider" : " providers")
                : "Showing " + list.Count + " of " + allProviders.Count + " providers";
            if (list.Count == 0)
                lblProviderCount.Text = allProviders.Count == 0
                    ? "No providers yet - click Add Provider to register your first one."
                    : "No matching providers found. Try a different search or clear the filters.";

            ShowSelectedProvider();
        }

        private void SetColumn(string name, float weight, bool bold)
        {
            if (!dgvProviders.Columns.Contains(name)) return;
            DataGridViewColumn c = dgvProviders.Columns[name]!;
            c.FillWeight = weight;
            c.MinimumWidth = 100;
            if (bold) c.DefaultCellStyle.Font = boldCellFont;
        }

        private string SelectedProviderId()
        {
            if (dgvProviders.CurrentRow == null || !dgvProviders.Columns.Contains("Id")) return "";
            return Convert.ToString(dgvProviders.CurrentRow.Cells["Id"].Value) ?? "";
        }

        private ServiceProvider? SelectedProvider()
        {
            string id = SelectedProviderId();
            if (id.Length == 0) return null;
            return allProviders.FirstOrDefault(p => p.UserId.ToString() == id);
        }

        // ==================================================================
        //  DETAIL CARD
        // ==================================================================
        private void dgvProviders_SelectionChanged(object? sender, EventArgs e)
        {
            if (binding) return;
            ShowSelectedProvider();
        }

        private void ShowSelectedProvider()
        {
            ServiceProvider? p = SelectedProvider();

            flowSpec.SuspendLayout();
            foreach (Control c in flowSpec.Controls.Cast<Control>().ToList())
            {
                flowSpec.Controls.Remove(c);
                c.Dispose();
            }

            if (p == null)
            {
                avatar.Initials = "?";
                lblDetName.Text = "Select a provider";
                pillWorkload.PillText = "No provider selected";
                pillWorkload.PillBack = Color.FromArgb(241, 245, 249);
                pillWorkload.PillFore = Theme.Muted;
                fldEmail.Value = "-";
                fldPhone.Value = "-";
                fldArea.Value = "-";
                fldJobs.Value = "-";
                barWorkload.Value = 0;
                lblWorkloadHint.Text = "Click a row to see the provider's details";
                btnEmailProvider.Enabled = false;
                btnResetPassword.Enabled = false;
                btnVerifyProvider.Enabled = false;
                selectedEmail = "";
                flowSpec.ResumeLayout();
                LayoutDetailCard();
                return;
            }

            string name = AdminUi.TitleCase(p.FirstName + " " + p.LastName);
            int active = ActiveJobsFor(p);
            int total = TotalJobsFor(p);

            avatar.Initials = AdminUi.Initials(name);
            lblDetName.Text = name;
            fldEmail.Value = p.Email ?? "-";
            fldPhone.Value = p.PhoneNumber ?? "-";
            fldArea.Value = string.IsNullOrWhiteSpace(p.Location) ? "-" : p.Location;
            fldJobs.Value = total + " total  |  " + active + " active";

            if (active == 0)
            {
                pillWorkload.PillText = "Available";
                pillWorkload.PillBack = Theme.GreenSoft;
                pillWorkload.PillFore = Theme.Green;
                barWorkload.BarColor = Theme.Green;
                lblWorkloadHint.Text = "No active jobs - ready for new work";
            }
            else if (active <= 2)
            {
                pillWorkload.PillText = "Light workload";
                pillWorkload.PillBack = Theme.BlueSoft;
                pillWorkload.PillFore = Theme.Blue;
                barWorkload.BarColor = Theme.Blue;
                lblWorkloadHint.Text = active + " active job" + (active == 1 ? "" : "s") + " - can take more";
            }
            else
            {
                pillWorkload.PillText = "Busy";
                pillWorkload.PillBack = Theme.AmberSoft;
                pillWorkload.PillFore = Theme.Amber;
                barWorkload.BarColor = Theme.Amber;
                lblWorkloadHint.Text = active + " active jobs - consider reassigning";
            }
            barWorkload.Value = Math.Min(100, active * 100 / 5);

            if (p.Specialisation != null)
            {
                int i = 0;
                foreach (string s in p.Specialisation)
                {
                    PillLabel pill = new PillLabel();
                    pill.PillText = s;
                    pill.Height = 30;
                    pill.Width = TextRenderer.MeasureText(s, pill.Font).Width + 34;
                    pill.Margin = new Padding(0, 0, 8, 8);
                    pill.PillBack = i % 2 == 0 ? Theme.OrangeSoft : Theme.BlueSoft;
                    pill.PillFore = i % 2 == 0 ? Theme.Orange : Theme.Blue;
                    flowSpec.Controls.Add(pill);
                    i++;
                }
            }
            flowSpec.ResumeLayout();
            LayoutDetailCard();

            selectedEmail = p.Email ?? "";
            btnEmailProvider.Enabled = selectedEmail.Contains("@");
            btnResetPassword.Enabled = true;
            btnVerifyProvider.Enabled = true;
            btnVerifyProvider.Text = p.IsVerified ? "Revoke Verification" : "Verify Provider";
            btnVerifyProvider.BaseColor = p.IsVerified ? Theme.Red : Theme.Green;
        }

        private void btnVerifyProvider_Click(object? sender, EventArgs e)
        {
            ServiceProvider? provider = SelectedProvider();
            if (provider == null) return;

            provider.IsVerified = !provider.IsVerified;
            if (!DataManager.UpdateServiceProvider(provider))
            {
                provider.IsVerified = !provider.IsVerified;
                AdminUi.Toast(this, "Provider verification could not be saved", false);
                return;
            }

            ReloadAll();
            AdminUi.Toast(this, provider.IsVerified ? "Provider verified" : "Provider verification revoked");
        }

        // Creates a fresh temporary password for the selected provider and shows it
        // in the same copy / e-mail dialog used when a provider is first added.
        private void btnResetPassword_Click(object? sender, EventArgs e)
        {
            ServiceProvider? p = SelectedProvider();
            if (p == null) return;

            string name = AdminUi.TitleCase(p.FirstName + " " + p.LastName);
            DialogResult ok = MessageBox.Show(
                "Create a new temporary password for " + name + "?\n\nTheir current password will stop working.",
                "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;

            string temporaryPassword = Guid.NewGuid().ToString("N").Substring(0, 8);
            p.SetPassword(temporaryPassword);
            if (!DataManager.UpdateServiceProvider(p))
            {
                AdminUi.Toast(this, "Provider could not be found", false);
                return;
            }

            using (CredentialsDialog creds = new CredentialsDialog(name, p.Email ?? "", temporaryPassword, true))
                creds.ShowDialog(this);
            ReloadAll();
        }

        private void btnEmailProvider_Click(object? sender, EventArgs e)
        {
            if (!selectedEmail.Contains("@")) return;
            try
            {
                Process.Start(new ProcessStartInfo("mailto:" + selectedEmail) { UseShellExecute = true });
            }
            catch (Exception)
            {
                Clipboard.SetText(selectedEmail);
                AdminUi.Toast(this, "No mail app found - address copied");
            }
        }

        private void dgvProviders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string col = dgvProviders.Columns[e.ColumnIndex].Name;

            if (col == "Jobs")
            {
                int jobs;
                if (int.TryParse(e.Value.ToString(), out jobs))
                {
                    e.CellStyle.Font = boldCellFont;
                    e.CellStyle.ForeColor = jobs == 0 ? Theme.Muted : (jobs >= 3 ? Theme.Amber : Theme.Blue);
                }
            }
            else if (col == "Specialisation" && e.Value.ToString() == "None")
            {
                e.CellStyle.ForeColor = Theme.Muted;
            }
        }

        // ==================================================================
        //  ORIGINAL HANDLERS  (names unchanged)
        // ==================================================================
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProviderManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyProviderFilter();
        }

        // "Remove Provider" button (the designer wires btnRemoveProvider to this handler)
        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            ServiceProvider? provider = SelectedProvider();

            if (provider == null)
            {
                AdminUi.Toast(this, "Please select a provider first", false);
                return;
            }

            string providerName = AdminUi.TitleCase(provider.FirstName + " " + provider.LastName);
            int active = ActiveJobsFor(provider);

            string message = "Are you sure you want to remove " + providerName + "?";
            if (active > 0)
                message += "\n\nThis provider still has " + active + " active job" + (active == 1 ? "" : "s") +
                           ". Those requests will need to be reassigned.";

            DialogResult result = MessageBox.Show(message, "Remove Provider", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (DataManager.DeleteServiceProvider(provider.UserId))
                {
                    ReloadAll();
                    AdminUi.Toast(this, providerName + " was removed");
                }
                else
                {
                    AdminUi.Toast(this, "Provider could not be found", false);
                }
            }
        }

        // "Add Provider" button
        private void btnAddProvider__Click(object sender, EventArgs e)
        {
            AddProvider addProviderForm = new AddProvider();
            addProviderForm.ShowDialog(this);
            ReloadAll();
        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReports reports = new frmReports();
            this.Hide();
            reports.Show();
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

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            AdminUi.Logout(this);
        }
    }
}
