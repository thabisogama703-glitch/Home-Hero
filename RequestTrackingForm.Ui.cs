using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmRequestTracking
    {
        // ---- header ----
        private GradientPanel pnlHeader = null!;
        private ModernButton btnBack = null!;

        // ---- stat cards ----
        private Label lblStatTotal = null!;
        private Label lblStatActive = null!;
        private Label lblStatCompleted = null!;
        private Label lblStatSpend = null!;

        // ---- details ----
        private PillLabel pillStatus = null!;
        private FieldBlock fldRequestNum = null!;
        private FieldBlock fldCategory = null!;
        private FieldBlock fldProvider = null!;
        private FieldBlock fldAppointment = null!;
        private FieldBlock fldEstimated = null!;
        private FieldBlock fldFinal = null!;
        private StepTimeline timeline = null!;

        // ---- AI insights ----
        private Label lblAiHeadline = null!;
        private Label lblAiProgressText = null!;
        private MeterBar barAiProgress = null!;
        private Label lblAiBody = null!;
        private Label lblAiTip = null!;

        // ---- grid area ----
        private TextBox txtSearch = null!;
        private ModernButton btnFilterAll = null!;
        private ModernButton btnFilterActive = null!;
        private ModernButton btnFilterDone = null!;
        private ModernButton btnFilterCancelled = null!;
        private ModernButton btnRefresh = null!;
        private Label lblUpdated = null!;
        private DataGridView dgvRequests = null!;
        private Label lblEmpty = null!;
        private DataGridViewTextBoxColumn colStatus = null!;
        private RequestChatPanel chatPanel = null!;

        private void BuildUi()
        {
            SuspendLayout();

            BackColor = Theme.Bg;
            Font = Theme.MakeFont(9.5F);

            // =================== BODY ===================
            Panel body = new Panel();
            body.Dock = DockStyle.Fill;
            body.BackColor = Theme.Bg;
            body.Padding = new Padding(32, 20, 32, 20);
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1360, 1200);

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 1;
            layout.RowCount = 4;
            layout.BackColor = Theme.Bg;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 352F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 284F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            layout.Controls.Add(BuildStatRow(), 0, 0);
            layout.Controls.Add(BuildMiddleRow(), 0, 1);
            layout.Controls.Add(BuildChatCard(), 0, 2);
            layout.Controls.Add(BuildGridCard(), 0, 3);
            body.Controls.Add(layout);

            // =================== HEADER ===================
            pnlHeader = new GradientPanel();
            pnlHeader.Photo = UiAssets.GetImage("How to Handle Maintenance Requests Efficiently as___");
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 104;

            Label brand = Theme.MakeLabel("Home Hero", 24F, FontStyle.Bold, Color.White);
            brand.Location = new Point(30, 12);

            Label tagline = Theme.MakeLabel("TRACK  |  FOLLOW  |  RELAX", 8.5F, FontStyle.Bold, Theme.Orange);
            tagline.Location = new Point(34, 64);

            Label title = Theme.MakeLabel("Track and Follow your Maintenance Request", 17F, FontStyle.Bold, Color.White);
            title.Location = new Point(420, 22);

            Label subtitle = Theme.MakeLabel("Live status, smart insights and every request in one place", 10F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
            subtitle.Location = new Point(422, 60);

            btnBack = new ModernButton();
            btnBack.Text = "<  Back";
            btnBack.UseHeaderStyle();
            btnBack.Size = new Size(130, 42);
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.Location = new Point(Math.Max(600, ClientSize.Width - 130 - 40), 28);
            btnBack.Click += btnBack_Click;

            pnlHeader.Controls.Add(brand);
            pnlHeader.Controls.Add(tagline);
            pnlHeader.Controls.Add(title);
            pnlHeader.Controls.Add(subtitle);
            pnlHeader.Controls.Add(btnBack);

            // Keep the Back button pinned to the right edge
            pnlHeader.Resize += (s, e) => { btnBack.Left = pnlHeader.ClientSize.Width - btnBack.Width - 40; };

            Controls.Add(body);
            Controls.Add(pnlHeader);

            ResumeLayout(true);
        }

        // ------------------------------------------------------------------
        private Control BuildStatRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Theme.Bg;
            row.MinimumSize = new Size(1296, 0);
            row.ColumnCount = 4;
            row.RowCount = 1;
            for (int i = 0; i < 4; i++)
                row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            row.Controls.Add(MakeStatCard("TOTAL REQUESTS", "All requests you have made", Theme.Navy, out lblStatTotal), 0, 0);
            row.Controls.Add(MakeStatCard("COMPLETED", "Jobs finished successfully", Theme.Green, out lblStatCompleted), 1, 0);
            row.Controls.Add(MakeStatCard("ACTIVE NOW", "Being worked on or scheduled", Theme.Orange, out lblStatActive), 2, 0);
            row.Controls.Add(MakeStatCard("TOTAL ESTIMATED", "Across all non-cancelled jobs", Theme.Purple, out lblStatSpend), 3, 0);
            return row;
        }

        private CardPanel MakeStatCard(string caption, string hint, Color accent, out Label valueLabel)
        {
            // the shared stat card stacks caption / number / hint in auto-sized rows,
            // so the sentence under the number is always fully visible
            Label hintLabel;
            CardPanel card = AdminUi.StatCard(caption, hint, accent, out valueLabel, out hintLabel);
            return card;
        }

        // ------------------------------------------------------------------
        private Control BuildMiddleRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Theme.Bg;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37F));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            row.Controls.Add(BuildDetailsCard(), 0, 0);
            row.Controls.Add(BuildAiCard(), 1, 0);
            return row;
        }

        private Control BuildChatCard()
        {
            string name = string.Equals(CustomerSession.CustomerId, currentCustomerId, StringComparison.OrdinalIgnoreCase)
                ? CustomerSession.Name
                : currentCustomerId;
            chatPanel = new RequestChatPanel(false, currentCustomerId, name);
            chatPanel.Dock = DockStyle.Fill;
            chatPanel.Margin = new Padding(0, 4, 0, 8);
            return chatPanel;
        }

        private Control BuildDetailsCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 14, 8);
            card.Padding = new Padding(28, 22, 28, 18);

            Label title = Theme.MakeLabel("Service Details", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(28, 20);

            pillStatus = new PillLabel();
            pillStatus.PillText = "No request selected";
            pillStatus.PillBack = Color.FromArgb(241, 245, 249);
            pillStatus.PillFore = Theme.Muted;
            pillStatus.Width = 170;
            pillStatus.Location = new Point(200, 22);

            TableLayoutPanel fields = new TableLayoutPanel();
            fields.BackColor = Color.Transparent;
            fields.ColumnCount = 3;
            fields.RowCount = 2;
            fields.Location = new Point(28, 66);
            fields.Size = new Size(card.Width - 56, 140);
            fields.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            for (int i = 0; i < 3; i++)
                fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            fldRequestNum = new FieldBlock("Request Number");
            fldCategory = new FieldBlock("Service Type");
            fldProvider = new FieldBlock("Assigned Provider");
            fldAppointment = new FieldBlock("Date & Time");
            fldEstimated = new FieldBlock("Estimated Cost");
            fldFinal = new FieldBlock("Final Cost");

            FieldBlock[] all = { fldRequestNum, fldCategory, fldProvider, fldAppointment, fldEstimated, fldFinal };
            foreach (FieldBlock f in all)
            {
                f.Dock = DockStyle.Fill;
                f.Margin = new Padding(0, 0, 10, 0);
            }
            fields.Controls.Add(fldRequestNum, 0, 0);
            fields.Controls.Add(fldCategory, 1, 0);
            fields.Controls.Add(fldProvider, 2, 0);
            fields.Controls.Add(fldAppointment, 0, 1);
            fields.Controls.Add(fldEstimated, 1, 1);
            fields.Controls.Add(fldFinal, 2, 1);

            Panel divider = new Panel();
            divider.BackColor = Theme.Border;
            divider.Height = 1;
            divider.Location = new Point(28, 214);
            divider.Width = card.Width - 56;
            divider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            timeline = new StepTimeline();
            timeline.Location = new Point(18, 226);
            timeline.Size = new Size(card.Width - 36, 92);
            timeline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            card.Controls.Add(title);
            card.Controls.Add(pillStatus);
            card.Controls.Add(fields);
            card.Controls.Add(divider);
            card.Controls.Add(timeline);
            return card;
        }

        private Control BuildAiCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 0, 8);
            card.Padding = new Padding(26, 20, 26, 16);
            card.FillColor = Color.FromArgb(250, 247, 255);
            card.BorderColor = Color.FromArgb(221, 214, 254);
            card.AccentColor = Theme.Purple;

            PillLabel aiBadge = new PillLabel();
            aiBadge.PillText = "AI";
            aiBadge.PillBack = Theme.Purple;
            aiBadge.PillFore = Color.White;
            aiBadge.Width = 44;
            aiBadge.Height = 26;
            aiBadge.Location = new Point(30, 22);

            Label title = Theme.MakeLabel("Hero Insights", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(84, 20);

            lblAiHeadline = Theme.MakeLabel("Select a request to see insights.", 11F, FontStyle.Bold, Theme.Text);
            lblAiHeadline.AutoSize = false;
            lblAiHeadline.Location = new Point(30, 64);
            lblAiHeadline.Size = new Size(card.Width - 60, 26);
            lblAiHeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblAiProgressText = Theme.MakeLabel("Journey progress", 8.5F, FontStyle.Bold, Theme.Muted);
            lblAiProgressText.AutoSize = false;
            lblAiProgressText.Location = new Point(30, 98);
            lblAiProgressText.Size = new Size(card.Width - 60, 20);
            lblAiProgressText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            barAiProgress = new MeterBar();
            barAiProgress.BarColor = Theme.Purple;
            barAiProgress.Location = new Point(30, 122);
            barAiProgress.Size = new Size(card.Width - 60, 10);
            barAiProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblAiBody = Theme.MakeLabel("", 9.5F, FontStyle.Regular, Theme.Text);
            lblAiBody.AutoSize = false;
            lblAiBody.Location = new Point(30, 146);
            lblAiBody.Size = new Size(card.Width - 60, 90);
            lblAiBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblAiTip = Theme.MakeLabel("", 9F, FontStyle.Regular, Color.FromArgb(91, 33, 182));
            lblAiTip.AutoSize = false;
            lblAiTip.Location = new Point(30, 240);
            lblAiTip.Size = new Size(card.Width - 60, 70);
            lblAiTip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            card.Controls.Add(aiBadge);
            card.Controls.Add(title);
            card.Controls.Add(lblAiHeadline);
            card.Controls.Add(lblAiProgressText);
            card.Controls.Add(barAiProgress);
            card.Controls.Add(lblAiBody);
            card.Controls.Add(lblAiTip);
            return card;
        }

        // ------------------------------------------------------------------
        private Control BuildGridCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 6, 0, 0);
            card.Padding = new Padding(22, 18, 22, 22);

            // ---------- toolbar ----------
            Panel toolbar = new Panel();
            toolbar.Dock = DockStyle.Top;
            toolbar.Height = 62;
            toolbar.BackColor = Color.Transparent;

            Label title = Theme.MakeLabel("My Requests", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(2, 10);

            lblUpdated = Theme.MakeLabel("", 8.5F, FontStyle.Regular, Theme.Muted);
            lblUpdated.Location = new Point(4, 38);

            InputFrame searchFrame = new InputFrame();
            searchFrame.Size = new Size(330, 42);
            searchFrame.Location = new Point(210, 8);
            txtSearch = new TextBox();
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = Theme.MakeFont(10F);
            txtSearch.PlaceholderText = "Search number, service or address...";
            txtSearch.BackColor = Color.White;
            txtSearch.TextChanged += txtSearch_TextChanged;
            searchFrame.Controls.Add(txtSearch);

            btnFilterAll = MakeChip("All", 556);
            btnFilterActive = MakeChip("Active", 626);
            btnFilterDone = MakeChip("Completed", 706);
            btnFilterCancelled = MakeChip("Cancelled", 806);
            btnFilterAll.Click += (s, e) => SetFilter(RequestFilter.All);
            btnFilterActive.Click += (s, e) => SetFilter(RequestFilter.Active);
            btnFilterDone.Click += (s, e) => SetFilter(RequestFilter.Completed);
            btnFilterCancelled.Click += (s, e) => SetFilter(RequestFilter.Cancelled);

            btnRefresh = new ModernButton();
            btnRefresh.Text = "Refresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(Math.Max(920, card.Width - 150), 9);
            btnRefresh.Click += btnRefresh_Click;
            toolbar.Resize += (s, e) => { btnRefresh.Left = toolbar.ClientSize.Width - btnRefresh.Width - 4; };

            toolbar.Controls.Add(title);
            toolbar.Controls.Add(lblUpdated);
            toolbar.Controls.Add(searchFrame);
            toolbar.Controls.Add(btnFilterAll);
            toolbar.Controls.Add(btnFilterActive);
            toolbar.Controls.Add(btnFilterDone);
            toolbar.Controls.Add(btnFilterCancelled);
            toolbar.Controls.Add(btnRefresh);

            // ---------- grid ----------
            Panel gridHost = new Panel();
            gridHost.Dock = DockStyle.Fill;
            gridHost.BackColor = Color.White;

            dgvRequests = new DataGridView();
            dgvRequests.Dock = DockStyle.Fill;
            StyleGrid(dgvRequests);

            lblEmpty = new Label();
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.BackColor = Color.White;
            lblEmpty.ForeColor = Theme.Muted;
            lblEmpty.Font = Theme.MakeFont(11F);
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.Text = "No requests to show yet.\nCreate a new service request from your dashboard to get started.";
            lblEmpty.Visible = false;

            gridHost.Controls.Add(dgvRequests);
            gridHost.Controls.Add(lblEmpty);

            card.Controls.Add(gridHost);
            card.Controls.Add(toolbar);
            return card;
        }

        private ModernButton MakeChip(string text, int left)
        {
            ModernButton b = new ModernButton();
            b.Text = text;
            b.Size = new Size(text.Length > 6 ? 94 : 66, 38);
            b.Location = new Point(left, 10);
            b.Radius = 19;
            b.Outline = true;
            b.BaseColor = Theme.Navy;
            b.HoverColor = Theme.NavyLight;
            b.Font = Theme.MakeSemibold(9.5F);
            return b;
        }

        private void StyleGrid(DataGridView g)
        {
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.RowHeadersVisible = false;
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(238, 242, 247);
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 46;
            g.RowTemplate.Height = 50;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.DefaultCellStyle.Font = Theme.MakeFont(9.5F);
            g.DefaultCellStyle.ForeColor = Theme.Text;
            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.SelectionBackColor = Theme.OrangeSoft;
            g.DefaultCellStyle.SelectionForeColor = Theme.Text;
            g.DefaultCellStyle.Padding = new Padding(8, 0, 4, 0);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Navy;
            g.ColumnHeadersDefaultCellStyle.Font = Theme.MakeSemibold(9.5F);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Theme.Navy;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 4, 0);

            g.Columns.Add(MakeColumn("RequestNumber", "Request No.", 15F));
            g.Columns.Add(MakeColumn("ServiceCategory", "Service", 10F));
            g.Columns.Add(MakeColumn("ProblemDescription", "Problem Description", 18F));
            g.Columns.Add(MakeColumn("PropertyAddress", "Property Address", 15F));
            g.Columns.Add(MakeColumn("PreferredDate", "Appointment Date", 10F));
            g.Columns.Add(MakeColumn("PreferredTime", "Appointment Time", 11F));
            colStatus = MakeColumn("Status", "Status", 11F);
            g.Columns.Add(colStatus);
            g.Columns.Add(MakeColumn("AssignedProviderId", "Assigned Provider", 10F));
            g.Columns.Add(MakeColumn("EstimatedCost", "Estimated Cost", 9F));
            g.Columns.Add(MakeColumn("FinalCost", "Final Cost", 9F));

            g.Columns["PreferredDate"]!.DefaultCellStyle.Format = "dd MMM yyyy";
            g.Columns["EstimatedCost"]!.DefaultCellStyle.Format = "'R'#,##0.00";
            g.Columns["FinalCost"]!.DefaultCellStyle.Format = "'R'#,##0.00";
            g.Columns["RequestNumber"]!.DefaultCellStyle.Font = Theme.MakeSemibold(9.5F);
            g.Columns["RequestNumber"]!.DefaultCellStyle.ForeColor = Theme.Navy;

            g.SelectionChanged += dgvRequests_SelectionChanged;
            g.CellPainting += dgvRequests_CellPainting;
            g.CellFormatting += dgvRequests_CellFormatting;
        }

        private DataGridViewTextBoxColumn MakeColumn(string property, string header, float weight)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.Name = property;
            c.DataPropertyName = property;
            c.HeaderText = header;
            c.FillWeight = weight;
            c.MinimumWidth = 70;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
            return c;
        }
    }
}
