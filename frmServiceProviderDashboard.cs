using HomeHero_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    // =====================================================================
    //  SERVICE PROVIDER DASHBOARD
    //  Jobs come from the real request file: every request the Administrator
    //  has assigned to this provider shows up here. The provider can start a
    //  job, complete it (recording the final cost) and the change is saved
    //  straight back so the admin and the customer see it too.
    // =====================================================================
    public partial class frmServiceProviderDashboard : FitForm
    {
        private readonly ServiceProvider currentProvider;

        private List<MaintenanceRequest> allJobs = new List<MaintenanceRequest>();
        private readonly HashSet<string> knownJobs = new HashSet<string>();
        private System.Windows.Forms.Timer? refreshTimer;
        private string lastSignature = "";
        private bool firstLoad = true;
        private bool busy;
        private bool binding;
        private string filter = "All";
        private string? selectedNumber;
        private string? planNumber;

        // header / title
        private Label lblWelcome = null!;
        private Label lblSubtitle = null!;

        // smart plan banner
        private Label lblPlan = null!;

        // stat tiles
        private Label lblActive = null!, hintActive = null!;
        private Label lblDue = null!, hintDue = null!;
        private Label lblDone = null!, hintDone = null!;
        private Label lblEarn = null!, hintEarn = null!;

        // jobs list
        private readonly Dictionary<string, ModernButton> filterButtons = new Dictionary<string, ModernButton>();
        private readonly DataGridView grid = new DataGridView();
        private Label emptyLabel = null!;
        private readonly Font refFont = Theme.MakeSemibold(9.5F);

        // detail panel
        private Panel emptyPanel = null!;
        private FlowLayoutPanel detailFlow = null!;
        private Panel actionBar = null!;
        private Label lblReq = null!, lblService = null!;
        private PillLabel pillStatus = null!;
        private StepTimeline timeline = null!;
        private FieldBlock fbCustomer = null!, fbWhen = null!, fbAddress = null!, fbCost = null!;
        private Label lblProblem = null!;
        private Label lblAiHeadline = null!, lblAiTip = null!;
        private PillLabel pillUrgent = null!, pillSkill = null!;
        private ModernButton btnStart = null!, btnComplete = null!;
        private ModernButton btnFindRequests = null!;
        private RequestChatPanel chatPanel = null!;

        public frmServiceProviderDashboard(ServiceProvider provider)
        {
            InitializeComponent();
            ScrollWholeForm = false;   // the body scrolls under the fixed header
            currentProvider = provider;

            BuildUi();
            LoadJobs(true);

            // pick up new assignments automatically while the dashboard is open
            refreshTimer = new System.Windows.Forms.Timer(components!);
            refreshTimer.Interval = 20000;
            refreshTimer.Tick += delegate
            {
                if (!busy && Visible) LoadJobs(false);
            };
            refreshTimer.Start();
        }

        // ==================================================================
        //  UI CONSTRUCTION
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();
            AdminUi.UseDpiScaling(this);

            Text = "HomeHero | Service Provider Dashboard";
            BackColor = Theme.Bg;
            Font = Theme.MakeFont(9F);
            MinimumSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            Panel body = BuildBody();
            Control header = BuildHeader();

            Controls.Add(body);     // fills what the header leaves
            Controls.Add(header);

            Disposed += delegate { refFont.Dispose(); };

            ResumeLayout(true);
        }

        // ------------------------------------------------------------------
        //  Header
        // ------------------------------------------------------------------
        private Control BuildHeader()
        {
            string fullName = AdminUi.TitleCase((currentProvider.FirstName + " " + currentProvider.LastName).Trim());
            if (fullName.Length == 0) fullName = "Service Provider";

            GradientPanel header = new GradientPanel();
            header.Photo = UiAssets.GetImage("Reliable Building Maintenance Services in Irvine");
            header.Dock = DockStyle.Top;
            header.Height = 100;

            // brand
            FlowLayoutPanel brand = new FlowLayoutPanel();
            brand.BackColor = Color.Transparent;
            brand.AutoSize = true;
            brand.WrapContents = false;
            brand.FlowDirection = FlowDirection.LeftToRight;
            brand.Location = new Point(36, 22);

            PictureBox logo = new PictureBox();
            logo.Image = Properties.Resources.Screenshot_2026_09_05_180629;
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.Size = new Size(54, 54);
            logo.BackColor = Color.Transparent;
            logo.Margin = new Padding(0, 0, 12, 0);

            Label home = Theme.MakeLabel("Home", 18F, FontStyle.Bold, Color.White);
            Label hero = Theme.MakeLabel("Hero", 18F, FontStyle.Bold, Theme.Orange);
            home.Margin = new Padding(0, 12, 0, 0);
            hero.Margin = new Padding(0, 12, 0, 0);

            Label portal = Theme.MakeLabel("SERVICE PROVIDER PORTAL", 8.5F, FontStyle.Bold, Color.FromArgb(190, 205, 230));
            portal.Margin = new Padding(18, 22, 0, 0);

            brand.Controls.Add(logo);
            brand.Controls.Add(home);
            brand.Controls.Add(hero);
            brand.Controls.Add(portal);

            // right side: avatar, name, logout
            FlowLayoutPanel right = new FlowLayoutPanel();
            right.Dock = DockStyle.Right;
            right.AutoSize = true;
            right.WrapContents = false;
            right.FlowDirection = FlowDirection.LeftToRight;
            right.BackColor = Color.Transparent;
            right.Padding = new Padding(0, 24, 36, 0);

            AvatarCircle avatar = new AvatarCircle();
            avatar.Size = new Size(48, 48);
            avatar.Initials = AdminUi.Initials(fullName);
            avatar.Margin = new Padding(0, 0, 12, 0);

            Panel who = new Panel();
            who.BackColor = Color.Transparent;
            who.Size = new Size(200, 48);
            who.Margin = new Padding(0, 0, 8, 0);

            Label name = Theme.MakeLabel(fullName, 11F, FontStyle.Bold, Color.White);
            name.AutoSize = false;
            name.AutoEllipsis = true;
            name.Size = new Size(200, 24);
            name.Location = new Point(0, 2);
            Label role = Theme.MakeLabel("Service Provider", 9F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
            role.Location = new Point(0, 27);
            who.Controls.Add(name);
            who.Controls.Add(role);

            ModernButton logout = new ModernButton();
            logout.Text = "Logout";
            logout.UseHeaderStyle();
            logout.Size = new Size(120, 44);
            logout.Margin = new Padding(16, 2, 0, 0);
            logout.Click += btnLogout_Click;

            right.Controls.Add(avatar);
            right.Controls.Add(who);
            right.Controls.Add(logout);

            header.Controls.Add(right);
            header.Controls.Add(brand);
            return header;
        }

        // ------------------------------------------------------------------
        //  Body
        // ------------------------------------------------------------------
        private Panel BuildBody()
        {
            Panel body = new Panel();
            body.Dock = DockStyle.Fill;
            body.BackColor = Theme.Bg;
            body.Padding = new Padding(36, 18, 36, 22);
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1150, 780);

            TableLayoutPanel root = new TableLayoutPanel();
            root.Dock = DockStyle.Fill;
            root.BackColor = Color.Transparent;
            root.ColumnCount = 1;
            root.RowCount = 4;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));         // title (sizes itself to the heading + subtitle)
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));    // smart plan
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));   // stat tiles
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));    // jobs + details

            root.Controls.Add(BuildTitleRow(), 0, 0);
            root.Controls.Add(BuildBanner(), 0, 1);
            root.Controls.Add(BuildStats(), 0, 2);
            root.Controls.Add(BuildMain(), 0, 3);

            body.Controls.Add(root);
            return body;
        }

        private Control BuildTitleRow()
        {
            TableLayoutPanel row = new TableLayoutPanel();
            row.Dock = DockStyle.Fill;
            row.BackColor = Color.Transparent;
            row.ColumnCount = 2;
            row.RowCount = 1;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            FlowLayoutPanel titles = new FlowLayoutPanel();
            titles.Dock = DockStyle.Fill;
            titles.BackColor = Color.Transparent;
            titles.FlowDirection = FlowDirection.TopDown;
            titles.WrapContents = false;
            titles.AutoScroll = false;
            titles.Padding = new Padding(0);

            // Labels are stacked by the flow panel (not placed at fixed pixel positions),
            // so the subtitle always sits fully below the heading whatever the screen scaling is.
            lblWelcome = Theme.MakeLabel("Welcome back", 21F, FontStyle.Bold, Theme.Navy);
            lblWelcome.Margin = new Padding(0, 0, 0, 2);
            lblSubtitle = Theme.MakeLabel("", 10.5F, FontStyle.Regular, Theme.Muted);
            lblSubtitle.Margin = new Padding(3, 0, 0, 0);
            titles.Controls.Add(lblWelcome);
            titles.Controls.Add(lblSubtitle);

            FlowLayoutPanel buttons = new FlowLayoutPanel();
            buttons.Dock = DockStyle.Fill;
            buttons.AutoSize = true;
            buttons.WrapContents = false;
            buttons.FlowDirection = FlowDirection.RightToLeft;
            buttons.BackColor = Color.Transparent;
            buttons.Padding = new Padding(0, 6, 0, 0);

            ModernButton export = new ModernButton();
            export.Text = "Export CSV";
            export.Outline = true;
            export.BaseColor = Theme.Navy;
            export.Size = new Size(140, 44);
            export.Margin = new Padding(10, 0, 0, 0);
            export.Click += btnExport_Click;

            ModernButton refresh = new ModernButton();
            refresh.Text = "\u21BB  Refresh";
            refresh.Outline = true;
            refresh.BaseColor = Theme.Navy;
            refresh.Size = new Size(140, 44);
            refresh.Margin = new Padding(10, 0, 0, 0);
            refresh.Click += btnRefresh_Click;

            btnFindRequests = new ModernButton();
            btnFindRequests.Text = "Find Available Requests";
            btnFindRequests.Outline = true;
            btnFindRequests.BaseColor = Theme.Orange;
            btnFindRequests.Size = new Size(190, 44);
            btnFindRequests.Margin = new Padding(10, 0, 0, 0);
            btnFindRequests.Click += btnFindRequests_Click;

            buttons.Controls.Add(export);
            buttons.Controls.Add(refresh);
            buttons.Controls.Add(btnFindRequests);

            row.Controls.Add(titles, 0, 0);
            row.Controls.Add(buttons, 1, 0);
            return row;
        }

        private Control BuildBanner()
        {
            SoftBox box = new SoftBox();
            box.Dock = DockStyle.Fill;
            box.Margin = new Padding(0, 2, 0, 10);
            box.Padding = new Padding(22, 0, 16, 0);
            box.FillColor = Color.FromArgb(246, 244, 255);
            box.BorderColor = Color.FromArgb(221, 214, 254);
            box.AccentColor = Theme.Purple;

            TableLayoutPanel t = new TableLayoutPanel();
            t.Dock = DockStyle.Fill;
            t.BackColor = Color.Transparent;
            t.ColumnCount = 2;
            t.RowCount = 1;
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            t.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            PillLabel pill = new PillLabel();
            pill.PillText = "SMART PLAN";
            pill.PillBack = Theme.Purple;
            pill.PillFore = Color.White;
            pill.Size = new Size(112, 26);
            pill.Anchor = AnchorStyles.None;

            lblPlan = new Label();
            lblPlan.Dock = DockStyle.Fill;
            lblPlan.AutoSize = false;
            lblPlan.AutoEllipsis = true;
            lblPlan.TextAlign = ContentAlignment.MiddleLeft;
            lblPlan.Font = Theme.MakeFont(10F);
            lblPlan.ForeColor = Theme.Text;
            lblPlan.BackColor = Color.Transparent;
            lblPlan.Cursor = Cursors.Hand;
            lblPlan.Click += delegate { FocusPlannedJob(); };

            t.Controls.Add(pill, 0, 0);
            t.Controls.Add(lblPlan, 1, 0);
            box.Controls.Add(t);
            return box;
        }

        private Control BuildStats()
        {
            CardPanel cActive = AdminUi.StatCard("Active jobs", "-", Theme.Orange, out lblActive, out hintActive);
            CardPanel cDue = AdminUi.StatCard("Due this week", "-", Theme.Blue, out lblDue, out hintDue);
            CardPanel cDone = AdminUi.StatCard("Completed", "-", Theme.Green, out lblDone, out hintDone);
            CardPanel cEarn = AdminUi.StatCard("Total earned", "-", Theme.Purple, out lblEarn, out hintEarn);

            AdminUi.MakeClickable(cActive, delegate { SetFilter("To do"); });
            AdminUi.MakeClickable(cDone, delegate { SetFilter("Completed"); });

            return AdminUi.StatRow(4, cActive, cDue, cDone, cEarn);
        }

        private Control BuildMain()
        {
            TableLayoutPanel main = new TableLayoutPanel();
            main.Dock = DockStyle.Fill;
            main.BackColor = Color.Transparent;
            main.ColumnCount = 2;
            main.RowCount = 1;
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Control jobs = BuildJobsCard();
            jobs.Margin = new Padding(0, 0, 16, 0);
            Control detail = BuildDetailCard();
            detail.Margin = new Padding(0);

            main.Controls.Add(jobs, 0, 0);
            main.Controls.Add(detail, 1, 0);
            return main;
        }

        // ------------------------------------------------------------------
        //  Jobs card: filter tabs + grid
        // ------------------------------------------------------------------
        private Control BuildJobsCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Padding = new Padding(20, 18, 20, 22);

            TableLayoutPanel t = new TableLayoutPanel();
            t.Dock = DockStyle.Fill;
            t.BackColor = Color.Transparent;
            t.ColumnCount = 1;
            t.RowCount = 2;
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            t.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ---- filter tabs ----
            FlowLayoutPanel tabs = new FlowLayoutPanel();
            tabs.Dock = DockStyle.Fill;
            tabs.BackColor = Color.Transparent;
            tabs.WrapContents = false;
            tabs.FlowDirection = FlowDirection.LeftToRight;
            foreach (string key in new[] { "All", "To do", "In progress", "Completed" })
            {
                ModernButton b = new ModernButton();
                b.Text = key;
                b.Size = new Size(138, 40);
                b.Margin = new Padding(0, 0, 10, 0);
                b.Font = Theme.MakeSemibold(10F);
                string captured = key;
                b.Click += delegate { SetFilter(captured); };
                filterButtons[key] = b;
                tabs.Controls.Add(b);
            }

            // ---- grid ----
            Panel gridHost = new Panel();
            gridHost.Dock = DockStyle.Fill;
            gridHost.BackColor = Color.Transparent;

            AdminUi.StyleGrid(grid);
            grid.Columns.Add(Col("colReq", "REQUEST", 24F));
            grid.Columns.Add(Col("colCustomer", "CUSTOMER", 20F));
            grid.Columns.Add(Col("colService", "SERVICE", 15F));
            grid.Columns.Add(Col("colDate", "DATE", 16F));
            grid.Columns.Add(Col("colTime", "TIME SLOT", 17F));
            grid.Columns.Add(Col("colStatus", "STATUS", 17F));
            DataGridViewTextBoxColumn amount = Col("colAmount", "AMOUNT", 13F);
            grid.Columns.Add(amount);
            AdminUi.RightAlign(amount);

            grid.CellPainting += Grid_CellPainting;
            grid.CellFormatting += Grid_CellFormatting;
            grid.SelectionChanged += Grid_SelectionChanged;

            emptyLabel = new Label();
            emptyLabel.Dock = DockStyle.Fill;
            emptyLabel.AutoSize = false;
            emptyLabel.TextAlign = ContentAlignment.MiddleCenter;
            emptyLabel.Font = Theme.MakeFont(11F);
            emptyLabel.ForeColor = Theme.Muted;
            emptyLabel.BackColor = Color.Transparent;
            emptyLabel.Visible = false;

            gridHost.Controls.Add(grid);
            gridHost.Controls.Add(emptyLabel);

            t.Controls.Add(tabs, 0, 0);
            t.Controls.Add(gridHost, 0, 1);
            card.Controls.Add(t);
            return card;
        }

        private static DataGridViewTextBoxColumn Col(string name, string header, float weight)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.Name = name;
            c.HeaderText = header;
            c.FillWeight = weight;
            c.MinimumWidth = 60;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
            return c;
        }

        // ------------------------------------------------------------------
        //  Detail card
        // ------------------------------------------------------------------
        private Control BuildDetailCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Padding = new Padding(24, 20, 24, 24);

            Panel host = new Panel();
            host.Dock = DockStyle.Fill;
            host.BackColor = Color.Transparent;

            // ---- empty state ----
            emptyPanel = new Panel();
            emptyPanel.Dock = DockStyle.Fill;
            emptyPanel.BackColor = Color.Transparent;
            Label emptyText = new Label();
            emptyText.Dock = DockStyle.Fill;
            emptyText.AutoSize = false;
            emptyText.TextAlign = ContentAlignment.MiddleCenter;
            emptyText.Font = Theme.MakeFont(11F);
            emptyText.ForeColor = Theme.Muted;
            emptyText.BackColor = Color.Transparent;
            emptyText.Text = "Select a job to see its details,\r\nthe customer's problem and your smart briefing.";
            emptyPanel.Controls.Add(emptyText);

            // ---- details (scrolling stack) ----
            detailFlow = new FlowLayoutPanel();
            detailFlow.Dock = DockStyle.Fill;
            detailFlow.FlowDirection = FlowDirection.TopDown;
            detailFlow.WrapContents = false;
            detailFlow.AutoScroll = true;
            detailFlow.BackColor = Color.Transparent;
            detailFlow.Visible = false;

            // head: request number, status pill, service
            Panel head = new Panel();
            head.BackColor = Color.Transparent;
            head.Height = 66;
            lblReq = Theme.MakeLabel("", 13.5F, FontStyle.Bold, Theme.Navy);
            lblReq.Location = new Point(0, 0);
            pillStatus = new PillLabel();
            pillStatus.Size = new Size(150, 28);
            pillStatus.Location = new Point(0, 34);
            lblService = Theme.MakeLabel("", 10.5F, FontStyle.Bold, Theme.Muted);
            lblService.Location = new Point(162, 37);
            head.Controls.Add(lblReq);
            head.Controls.Add(pillStatus);
            head.Controls.Add(lblService);

            timeline = new StepTimeline();
            timeline.Steps = new string[] { "Assigned", "Scheduled", "In Progress", "Completed" };
            timeline.Height = 84;

            // fields
            TableLayoutPanel fields = new TableLayoutPanel();
            fields.BackColor = Color.Transparent;
            fields.ColumnCount = 2;
            fields.RowCount = 2;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            fields.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            fields.Height = 126;
            fbCustomer = new FieldBlock("Customer");
            fbWhen = new FieldBlock("Date & time");
            fbAddress = new FieldBlock("Property address");
            fbCost = new FieldBlock("Cost");
            foreach (FieldBlock fb in new[] { fbCustomer, fbWhen, fbAddress, fbCost })
                fb.Dock = DockStyle.Fill;
            fields.Controls.Add(fbCustomer, 0, 0);
            fields.Controls.Add(fbWhen, 1, 0);
            fields.Controls.Add(fbAddress, 0, 1);
            fields.Controls.Add(fbCost, 1, 1);

            // problem description
            Label problemCaption = Theme.MakeLabel("PROBLEM DESCRIPTION", 8F, FontStyle.Bold, Theme.Muted);
            problemCaption.AutoSize = false;
            problemCaption.Height = 20;

            lblProblem = new Label();
            lblProblem.AutoSize = false;
            lblProblem.AutoEllipsis = true;
            lblProblem.Height = 62;
            lblProblem.Font = Theme.MakeFont(10F);
            lblProblem.ForeColor = Theme.Text;
            lblProblem.BackColor = Color.Transparent;

            // smart briefing box
            SoftBox ai = new SoftBox();
            ai.Height = 148;
            ai.FillColor = Color.FromArgb(246, 244, 255);
            ai.BorderColor = Color.FromArgb(221, 214, 254);
            ai.AccentColor = Theme.Purple;
            ai.Padding = new Padding(24, 12, 14, 12);

            TableLayoutPanel at = new TableLayoutPanel();
            at.Dock = DockStyle.Fill;
            at.BackColor = Color.Transparent;
            at.ColumnCount = 1;
            at.RowCount = 4;
            at.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            at.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            at.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            at.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            at.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));

            PillLabel aiTag = new PillLabel();
            aiTag.PillText = "SMART BRIEFING";
            aiTag.PillBack = Theme.Purple;
            aiTag.PillFore = Color.White;
            aiTag.Size = new Size(140, 24);
            aiTag.Margin = new Padding(0, 2, 0, 0);

            lblAiHeadline = new Label();
            lblAiHeadline.Dock = DockStyle.Fill;
            lblAiHeadline.AutoSize = false;
            lblAiHeadline.AutoEllipsis = true;
            lblAiHeadline.TextAlign = ContentAlignment.MiddleLeft;
            lblAiHeadline.Font = Theme.MakeFont(10.5F, FontStyle.Bold);
            lblAiHeadline.ForeColor = Theme.Navy;
            lblAiHeadline.BackColor = Color.Transparent;

            lblAiTip = new Label();
            lblAiTip.Dock = DockStyle.Fill;
            lblAiTip.AutoSize = false;
            lblAiTip.Font = Theme.MakeFont(9.5F);
            lblAiTip.ForeColor = Theme.Muted;
            lblAiTip.BackColor = Color.Transparent;

            FlowLayoutPanel chipsRow = new FlowLayoutPanel();
            chipsRow.Dock = DockStyle.Fill;
            chipsRow.WrapContents = false;
            chipsRow.BackColor = Color.Transparent;
            pillUrgent = new PillLabel();
            pillUrgent.PillText = "Urgent";
            pillUrgent.PillBack = Theme.RedSoft;
            pillUrgent.PillFore = Theme.Red;
            pillUrgent.Size = new Size(90, 26);
            pillUrgent.Margin = new Padding(0, 2, 8, 0);
            pillSkill = new PillLabel();
            pillSkill.Size = new Size(170, 26);
            pillSkill.Margin = new Padding(0, 2, 0, 0);
            chipsRow.Controls.Add(pillUrgent);
            chipsRow.Controls.Add(pillSkill);

            at.Controls.Add(aiTag, 0, 0);
            at.Controls.Add(lblAiHeadline, 0, 1);
            at.Controls.Add(lblAiTip, 0, 2);
            at.Controls.Add(chipsRow, 0, 3);
            ai.Controls.Add(at);

            chatPanel = new RequestChatPanel(
                true,
                currentProvider.UserId.ToString(),
                AdminUi.TitleCase((currentProvider.FirstName + " " + currentProvider.LastName).Trim()));
            chatPanel.Height = 280;

            foreach (Control c in new Control[] { head, timeline, fields, problemCaption, lblProblem, ai, chatPanel })
            {
                c.Margin = new Padding(0, 0, 0, 6);
                detailFlow.Controls.Add(c);
            }
            detailFlow.ClientSizeChanged += delegate { FitDetailWidths(); };

            // ---- action bar ----
            actionBar = new Panel();
            actionBar.Dock = DockStyle.Bottom;
            actionBar.Height = 66;
            actionBar.BackColor = Color.Transparent;
            actionBar.Visible = false;

            TableLayoutPanel at2 = new TableLayoutPanel();
            at2.Dock = DockStyle.Fill;
            at2.BackColor = Color.Transparent;
            at2.ColumnCount = 2;
            at2.RowCount = 1;
            at2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            at2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            at2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            btnStart = new ModernButton();
            btnStart.Dock = DockStyle.Fill;
            btnStart.Margin = new Padding(0, 12, 8, 0);
            btnStart.Font = Theme.MakeSemibold(11F);
            btnStart.Click += btnStart_Click;

            btnComplete = new ModernButton();
            btnComplete.Dock = DockStyle.Fill;
            btnComplete.Margin = new Padding(8, 12, 0, 0);
            btnComplete.Font = Theme.MakeSemibold(11F);
            btnComplete.BaseColor = Theme.Green;
            btnComplete.HoverColor = Color.FromArgb(34, 190, 94);
            btnComplete.Click += btnComplete_Click;

            at2.Controls.Add(btnStart, 0, 0);
            at2.Controls.Add(btnComplete, 1, 0);
            actionBar.Controls.Add(at2);

            // action bar docks first (it sits at the back), the rest fills what is left
            host.Controls.Add(emptyPanel);
            host.Controls.Add(detailFlow);
            host.Controls.Add(actionBar);

            card.Controls.Add(host);
            return card;
        }

        /// <summary>The scrolling stack needs each row sized to its width.</summary>
        private void FitDetailWidths()
        {
            if (detailFlow == null) return;
            foreach (Control c in detailFlow.Controls)
            {
                int w = detailFlow.ClientSize.Width - c.Margin.Horizontal;
                if (w > 20 && c.Width != w) c.Width = w;
            }
        }

        // ==================================================================
        //  DATA
        // ==================================================================
        private static bool IsActive(MaintenanceRequest r)
        {
            return r.Status == RequestStatus.Approved
                || r.Status == RequestStatus.ProviderAssigned
                || r.Status == RequestStatus.Scheduled
                || r.Status == RequestStatus.InProgress;
        }

        private static bool IsOverdue(MaintenanceRequest r)
        {
            return IsActive(r) && r.Status != RequestStatus.InProgress && r.PreferredDate.Date < DateTime.Today;
        }

        private void LoadJobs(bool force)
        {
            List<MaintenanceRequest> latest;
            try
            {
                latest = DataManager.LoadRequests()
                    .Where(r => AdminUi.IsAssignedTo(r, currentProvider)
                                && r.Status != RequestStatus.Cancelled
                                && r.Status != RequestStatus.Requested)
                    .OrderBy(r => r.Status == RequestStatus.Completed ? 1 : 0)
                    .ThenBy(r => r.Status == RequestStatus.InProgress ? 0 : 1)
                    .ThenBy(r => r.PreferredDate)
                    .ThenBy(r => r.PreferredTime)
                    .ToList();
            }
            catch (Exception)
            {
                latest = new List<MaintenanceRequest>();
            }

            string signature = string.Join(";", latest.Select(r =>
                r.RequestNumber + "|" + r.Status + "|" + r.FinalCost + "|" + r.PreferredDate.Ticks));
            if (!force && signature == lastSignature) return;
            lastSignature = signature;

            List<MaintenanceRequest> fresh = latest.Where(r => !knownJobs.Contains(r.RequestNumber)).ToList();
            foreach (MaintenanceRequest r in latest) knownJobs.Add(r.RequestNumber);

            allJobs = latest;

            UpdateTitle();
            UpdateStats();
            UpdateFilterButtons();
            UpdatePlan();
            ApplyFilter();

            if (!firstLoad && fresh.Count > 0)
            {
                AdminUi.Toast(this, fresh.Count == 1 ? "A new job was assigned to you" : fresh.Count + " new jobs were assigned to you");
            }
            firstLoad = false;
        }

        private bool SaveJob(MaintenanceRequest job)
        {
            List<MaintenanceRequest> all = DataManager.LoadRequests();
            MaintenanceRequest? existing = all.FirstOrDefault(r => r.RequestNumber == job.RequestNumber);
            if (existing == null)
            {
                MessageBox.Show("This request could not be found any more. Please refresh.", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            existing.Status = job.Status;
            existing.FinalCost = job.FinalCost;
            DataManager.SaveRequests(all);
            return true;
        }

        /// <summary>Moves a request forward one allowed step at a time until it reaches the target.</summary>
        private bool AdvanceTo(MaintenanceRequest r, RequestStatus target)
        {
            int guard = 0;
            while (r.Status != target && guard++ < 8)
            {
                RequestStatus next;
                switch (r.Status)
                {
                    case RequestStatus.Approved: next = RequestStatus.ProviderAssigned; break;
                    case RequestStatus.ProviderAssigned: next = RequestStatus.Scheduled; break;
                    case RequestStatus.Scheduled: next = RequestStatus.InProgress; break;
                    case RequestStatus.InProgress: next = RequestStatus.Completed; break;
                    default:
                        MessageBox.Show("This job cannot be moved forward from its current status.", "Update job", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                }

                string error;
                if (!r.TryUpdateStatus(next, out error))
                {
                    MessageBox.Show(error, "Update job", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return r.Status == target;
        }

        // ==================================================================
        //  VIEW UPDATES
        // ==================================================================
        private void UpdateTitle()
        {
            string first = AdminUi.TitleCase(currentProvider.FirstName);
            lblWelcome.Text = first.Length == 0 ? "Welcome back" : "Welcome back, " + first;

            int active = allJobs.Count(IsActive);
            string date = DateTime.Now.ToString("dddd, d MMMM yyyy", CultureInfo.CurrentCulture);
            lblSubtitle.Text = date + "   \u2022   " + (active == 0 ? "no active jobs" : active + (active == 1 ? " active job" : " active jobs"));
        }

        private void UpdateStats()
        {
            DateTime today = DateTime.Today;
            int active = allJobs.Count(IsActive);
            int inProgress = allJobs.Count(r => r.Status == RequestStatus.InProgress);
            int overdue = allJobs.Count(IsOverdue);
            int dueWeek = allJobs.Count(r => IsActive(r) && r.PreferredDate.Date <= today.AddDays(7));
            List<MaintenanceRequest> done = allJobs.Where(r => r.Status == RequestStatus.Completed).ToList();
            decimal earned = done.Sum(r => r.FinalCost);

            lblActive.Text = active.ToString();
            hintActive.Text = inProgress == 0 ? "None started yet" : inProgress + " in progress now";

            lblDue.Text = dueWeek.ToString();
            hintDue.Text = overdue > 0 ? overdue + " overdue - act now" : "Next 7 days";
            hintDue.ForeColor = overdue > 0 ? Theme.Red : Theme.Muted;

            lblDone.Text = done.Count.ToString();
            hintDone.Text = done.Count == 0 ? "Finish a job to see it here" : "All time on HomeHero";

            lblEarn.Text = AdminUi.Money(earned);
            hintEarn.Text = done.Count == 0 ? "Earnings appear after completion" : "Avg " + AdminUi.Money(earned / done.Count) + " per job";
        }

        private void UpdateFilterButtons()
        {
            int todo = allJobs.Count(r => r.Status == RequestStatus.Approved || r.Status == RequestStatus.ProviderAssigned || r.Status == RequestStatus.Scheduled);
            int prog = allJobs.Count(r => r.Status == RequestStatus.InProgress);
            int done = allJobs.Count(r => r.Status == RequestStatus.Completed);

            filterButtons["All"].Text = "All  (" + allJobs.Count + ")";
            filterButtons["To do"].Text = "To do  (" + todo + ")";
            filterButtons["In progress"].Text = "In progress  (" + prog + ")";
            filterButtons["Completed"].Text = "Completed  (" + done + ")";

            foreach (KeyValuePair<string, ModernButton> kv in filterButtons)
            {
                bool on = kv.Key == filter;
                kv.Value.Outline = !on;
                kv.Value.BaseColor = Theme.Navy;
                kv.Value.HoverColor = Theme.NavyLight;
                kv.Value.Invalidate();
            }
        }

        private void SetFilter(string key)
        {
            filter = key;
            UpdateFilterButtons();
            ApplyFilter();
        }

        private bool MatchesFilter(MaintenanceRequest r)
        {
            switch (filter)
            {
                case "To do":
                    return r.Status == RequestStatus.Approved || r.Status == RequestStatus.ProviderAssigned || r.Status == RequestStatus.Scheduled;
                case "In progress":
                    return r.Status == RequestStatus.InProgress;
                case "Completed":
                    return r.Status == RequestStatus.Completed;
                default:
                    return true;
            }
        }

        private void ApplyFilter()
        {
            binding = true;
            grid.Visible = true;
            grid.Rows.Clear();

            foreach (MaintenanceRequest r in allJobs.Where(MatchesFilter))
            {
                bool overdue = IsOverdue(r);
                string date = r.PreferredDate.ToString("ddd, d MMM yyyy", CultureInfo.CurrentCulture) + (overdue ? "  (overdue)" : "");
                string amount = r.Status == RequestStatus.Completed && r.FinalCost > 0
                    ? AdminUi.Money(r.FinalCost)
                    : "Est. " + AdminUi.Money(r.EstimatedCost);

                int i = grid.Rows.Add(
                    r.RequestNumber,
                    r.CustomerId,
                    r.ServiceCategory,
                    date,
                    r.PreferredTime,
                    AdminUi.StatusText(r.Status),
                    amount);
                grid.Rows[i].Tag = r;
            }

            // keep the same job selected after a refresh, otherwise pick the first
            DataGridViewRow? pick = null;
            foreach (DataGridViewRow row in grid.Rows)
            {
                MaintenanceRequest? r = row.Tag as MaintenanceRequest;
                if (r != null && r.RequestNumber == selectedNumber) { pick = row; break; }
            }
            if (pick == null && grid.Rows.Count > 0) pick = grid.Rows[0];

            grid.ClearSelection();
            if (pick != null)
            {
                pick.Selected = true;
                grid.CurrentCell = pick.Cells[0];
                selectedNumber = (pick.Tag as MaintenanceRequest)?.RequestNumber;
            }
            else
            {
                selectedNumber = null;
            }

            bool any = grid.Rows.Count > 0;
            grid.Visible = any;
            emptyLabel.Visible = !any;
            emptyLabel.Text = allJobs.Count == 0
                ? "No jobs assigned to you yet.\r\nWhen the administrator assigns a request it will appear here automatically."
                : "Nothing in this view.\r\nTry another filter above.";

            binding = false;
            ShowJob(SelectedJob());
        }

        private MaintenanceRequest? SelectedJob()
        {
            if (selectedNumber == null) return null;
            return allJobs.FirstOrDefault(j => j.RequestNumber == selectedNumber);
        }

        // ------------------------------------------------------------------
        //  Smart plan (on-device assistant: ranks active jobs)
        // ------------------------------------------------------------------
        private void UpdatePlan()
        {
            planNumber = null;
            List<MaintenanceRequest> todo = allJobs.Where(IsActive).ToList();

            if (allJobs.Count == 0)
            {
                lblPlan.Text = "No jobs yet - new assignments from the administrator will show up here automatically.";
                lblPlan.Cursor = Cursors.Default;
                return;
            }
            if (todo.Count == 0)
            {
                lblPlan.Text = "You are all caught up - every assigned job is complete. Well done!";
                lblPlan.Cursor = Cursors.Default;
                return;
            }

            MaintenanceRequest? best = null;
            int bestScore = int.MinValue;
            string bestWhy = "";

            foreach (MaintenanceRequest r in todo)
            {
                AiSuggestion ai = SmartAssistant.Analyse(r.ProblemDescription ?? "");
                int days = (r.PreferredDate.Date - DateTime.Today).Days;
                int score = Math.Max(-20, 40 - days * 4);
                string why = days <= 0 ? "it is booked for today" : "it is the soonest on your schedule";

                if (days < 0) { score += 30; why = "it is overdue"; }
                if (ai.Urgent) { score += 100; why = "the smart assistant flagged it as urgent"; }
                if (r.Status == RequestStatus.InProgress) { score += 60; if (!ai.Urgent) why = "it is already in progress - finish it first"; }

                if (score > bestScore) { bestScore = score; best = r; bestWhy = why; }
            }

            if (best == null) return;
            planNumber = best.RequestNumber;
            string when = best.PreferredDate.Date == DateTime.Today ? "today" : best.PreferredDate.ToString("ddd d MMM", CultureInfo.CurrentCulture);
            lblPlan.Text = "Start with " + best.RequestNumber + "  -  " + best.ServiceCategory + " for " + best.CustomerId
                + ", " + when + ", because " + bestWhy + "."
                + (todo.Count > 1 ? "  " + (todo.Count - 1) + " more after that." : "");
            lblPlan.Cursor = Cursors.Hand;
        }

        private void FocusPlannedJob()
        {
            if (planNumber == null) return;
            selectedNumber = planNumber;
            SetFilter("All");
        }

        // ------------------------------------------------------------------
        //  Detail panel
        // ------------------------------------------------------------------
        private static int TimelineIndex(RequestStatus s)
        {
            switch (s)
            {
                case RequestStatus.Scheduled: return 1;
                case RequestStatus.InProgress: return 2;
                case RequestStatus.Completed: return 3;
                default: return 0;
            }
        }

        private void ShowJob(MaintenanceRequest? r)
        {
            emptyPanel.Visible = r == null;
            detailFlow.Visible = r != null;
            actionBar.Visible = r != null;
            chatPanel.SetRequest(r);
            if (r == null) return;

            lblReq.Text = r.RequestNumber;
            lblService.Text = r.ServiceCategory;

            Color back, fore;
            AdminUi.StatusColors(r.Status, out back, out fore);
            pillStatus.PillText = AdminUi.StatusText(r.Status);
            pillStatus.PillBack = back;
            pillStatus.PillFore = fore;

            timeline.Current = TimelineIndex(r.Status);

            fbCustomer.Value = r.CustomerId;
            fbWhen.Value = r.PreferredDate.ToString("d MMM", CultureInfo.CurrentCulture) + " | " + r.PreferredTime;
            fbAddress.Value = string.IsNullOrWhiteSpace(r.PropertyAddress) ? "-" : r.PropertyAddress;
            if (r.Status == RequestStatus.Completed && r.FinalCost > 0)
            {
                fbCost.Caption = "Final cost";
                fbCost.Value = AdminUi.Money(r.FinalCost);
                fbCost.ValueColor = Theme.Green;
            }
            else
            {
                fbCost.Caption = "Estimated cost";
                fbCost.Value = AdminUi.Money(r.EstimatedCost);
                fbCost.ValueColor = Theme.Text;
            }

            string desc = (r.ProblemDescription ?? "").Trim();
            lblProblem.Text = desc.Length == 0 ? "No description was provided." : desc;

            FillBriefing(r, desc);

            bool inProgress = r.Status == RequestStatus.InProgress;
            bool finished = r.Status == RequestStatus.Completed;
            btnStart.Enabled = !inProgress && !finished;
            btnStart.Text = finished ? "Job finished" : (inProgress ? "Job in progress" : "\u25B6  Start job");
            btnComplete.Enabled = inProgress;
            btnComplete.Text = finished ? "\u2713  Completed" : "\u2713  Mark complete";

            FitDetailWidths();
        }

        private void FillBriefing(MaintenanceRequest r, string desc)
        {
            bool enough = desc.Length >= 12;
            AiSuggestion ai = SmartAssistant.Analyse(desc);

            lblAiHeadline.Text = enough && ai.Category != null
                ? ai.Headline
                : "Not enough detail to analyse this job.";
            lblAiTip.Text = enough && !string.IsNullOrWhiteSpace(ai.Tip)
                ? ai.Tip
                : "Contact the customer to confirm the problem and ask for photos before you travel.";

            pillUrgent.Visible = enough && ai.Urgent;

            List<string> skills = currentProvider.Specialisation ?? new List<string>();
            if (skills.Count == 0)
            {
                pillSkill.Visible = false;
            }
            else
            {
                bool match = skills.Any(s => string.Equals(s, r.ServiceCategory, StringComparison.OrdinalIgnoreCase));
                pillSkill.Visible = true;
                pillSkill.PillText = match ? "In your skills" : "Outside your skills";
                pillSkill.PillBack = match ? Theme.GreenSoft : Theme.AmberSoft;
                pillSkill.PillFore = match ? Theme.Green : Theme.Amber;
            }
        }

        // ==================================================================
        //  GRID EVENTS
        // ==================================================================
        private void Grid_SelectionChanged(object? sender, EventArgs e)
        {
            if (binding) return;
            MaintenanceRequest? r = grid.SelectedRows.Count > 0 ? grid.SelectedRows[0].Tag as MaintenanceRequest : null;
            selectedNumber = r?.RequestNumber;
            ShowJob(SelectedJob());
        }

        private void Grid_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (grid.Columns[e.ColumnIndex].Name != "colStatus") return;

            MaintenanceRequest? r = grid.Rows[e.RowIndex].Tag as MaintenanceRequest;
            if (r == null) return;

            Color back, fore;
            AdminUi.StatusColors(r.Status, out back, out fore);
            AdminUi.PaintPillCell(e, AdminUi.StatusText(r.Status), back, fore);
        }

        private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            MaintenanceRequest? r = grid.Rows[e.RowIndex].Tag as MaintenanceRequest;
            if (r == null) return;

            string col = grid.Columns[e.ColumnIndex].Name;
            if (col == "colReq")
            {
                e.CellStyle.Font = refFont;
                e.CellStyle.ForeColor = Theme.Navy;
            }
            else if (col == "colDate" && IsOverdue(r))
            {
                e.CellStyle.ForeColor = Theme.Red;
                e.CellStyle.SelectionForeColor = Theme.Red;
            }
        }

        // ==================================================================
        //  ACTIONS
        // ==================================================================
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadJobs(true);
            AdminUi.Toast(this, "Jobs refreshed");
        }

        private static bool IsUnassigned(MaintenanceRequest request)
        {
            return string.IsNullOrWhiteSpace(request.AssignedProviderId)
                || string.Equals(request.AssignedProviderId.Trim(), "Unassigned", StringComparison.OrdinalIgnoreCase);
        }

        private bool CanClaim(MaintenanceRequest request)
        {
            List<string> skills = currentProvider.Specialisation ?? new List<string>();
            return skills.Count == 0 || skills.Any(skill =>
                string.Equals(skill, request.ServiceCategory, StringComparison.OrdinalIgnoreCase));
        }

        private void btnFindRequests_Click(object? sender, EventArgs e)
        {
            List<MaintenanceRequest> available = DataManager.LoadRequests()
                .Where(r => r.Status == RequestStatus.Approved && IsUnassigned(r) && CanClaim(r))
                .OrderBy(r => r.PreferredDate)
                .ThenBy(r => r.PreferredTime)
                .ToList();

            if (available.Count == 0)
            {
                AdminUi.Toast(this, "No approved, unassigned requests match your skills");
                return;
            }

            using (AvailableRequestsDialog dialog = new AvailableRequestsDialog(available))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.SelectedRequestNumber))
                    return;

                List<string> skills = currentProvider.Specialisation ?? new List<string>();
                if (!DataManager.TryClaimApprovedRequest(
                    dialog.SelectedRequestNumber,
                    currentProvider.UserId.ToString(),
                    skills,
                    out string error))
                {
                    MessageBox.Show(this, error, "Unable to claim request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedNumber = dialog.SelectedRequestNumber;
                LoadJobs(true);
                AdminUi.Toast(this, "Request claimed and added to your jobs");
            }
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            AdminUi.ExportGrid(this, grid, "MyJobs");
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            AdminUi.Logout(this);
        }

        private void btnStart_Click(object? sender, EventArgs e)
        {
            MaintenanceRequest? r = SelectedJob();
            if (r == null || r.Status == RequestStatus.InProgress || r.Status == RequestStatus.Completed) return;

            busy = true;
            bool ok;
            try
            {
                ok = AdvanceTo(r, RequestStatus.InProgress) && SaveJob(r);
            }
            finally
            {
                busy = false;
            }

            LoadJobs(true);
            if (ok) AdminUi.Toast(this, "Job started - good luck!");
        }

        private void btnComplete_Click(object? sender, EventArgs e)
        {
            MaintenanceRequest? r = SelectedJob();
            if (r == null || r.Status != RequestStatus.InProgress) return;

            bool ok = false;
            busy = true;
            try
            {
                using (CompleteJobDialog dlg = new CompleteJobDialog(r))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        r.FinalCost = dlg.FinalCost;
                        ok = AdvanceTo(r, RequestStatus.Completed) && SaveJob(r);
                    }
                }
            }
            finally
            {
                busy = false;
            }

            LoadJobs(true);
            if (ok) AdminUi.Toast(this, "Job completed - " + AdminUi.Money(r.FinalCost) + " recorded");
        }

    }

    // =====================================================================
    //  COMPLETE-JOB DIALOG  - records the final cost
    // =====================================================================
    internal class CompleteJobDialog : FitForm
    {
        private readonly TextBox txtCost = new TextBox();
        private readonly Label lblError;

        public decimal FinalCost { get; private set; }

        public CompleteJobDialog(MaintenanceRequest job)
        {
            AdminUi.UseDpiScaling(this);

            Text = "Complete job";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.White;
            ClientSize = new Size(520, 340);

            Label title = Theme.MakeLabel("Complete this job", 16F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(28, 24);

            Label sub = Theme.MakeLabel(job.RequestNumber + "  |  " + job.ServiceCategory, 10F, FontStyle.Regular, Theme.Muted);
            sub.Location = new Point(30, 62);

            Label cap = Theme.MakeLabel("FINAL COST (RAND)", 8.5F, FontStyle.Bold, Theme.Muted);
            cap.Location = new Point(30, 104);

            decimal start = job.FinalCost > 0 ? job.FinalCost : job.EstimatedCost;
            txtCost.Text = start.ToString("0.00", CultureInfo.CurrentCulture);
            InputFrame frame = AdminUi.Frame(txtCost, 464, 52);
            frame.Location = new Point(28, 128);
            frame.Margin = new Padding(0);

            Label hint = Theme.MakeLabel("Pre-filled from the estimate - change it if the final amount was different.", 9F, FontStyle.Regular, Theme.Muted);
            hint.Location = new Point(30, 190);

            lblError = Theme.MakeLabel("", 9.5F, FontStyle.Bold, Theme.Red);
            lblError.Location = new Point(30, 216);

            ModernButton ok = new ModernButton();
            ok.Text = "Complete Job";
            ok.BaseColor = Theme.Green;
            ok.HoverColor = Color.FromArgb(34, 190, 94);
            ok.Size = new Size(200, 48);
            ok.Location = new Point(292, 266);
            ok.Click += delegate { Confirm(); };

            ModernButton cancel = new ModernButton();
            cancel.Text = "Cancel";
            cancel.Outline = true;
            cancel.BaseColor = Theme.Navy;
            cancel.Size = new Size(140, 48);
            cancel.Location = new Point(136, 266);
            cancel.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(title);
            Controls.Add(sub);
            Controls.Add(cap);
            Controls.Add(frame);
            Controls.Add(hint);
            Controls.Add(lblError);
            Controls.Add(cancel);
            Controls.Add(ok);
            AcceptButton = ok;
            CancelButton = cancel;
            ActiveControl = txtCost;
            txtCost.SelectAll();
        }

        private void Confirm()
        {
            string raw = txtCost.Text.Trim().Replace("R", "").Replace("r", "").Trim();
            decimal value;
            if (!decimal.TryParse(raw, NumberStyles.Number, CultureInfo.CurrentCulture, out value) || value < 0 || value > 1000000m)
            {
                lblError.Text = "Enter a valid amount, for example 850.00";
                txtCost.Focus();
                return;
            }

            FinalCost = Math.Round(value, 2);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
