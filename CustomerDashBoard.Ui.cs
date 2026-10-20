using Home_Hero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeHero
{
    // The modern look of the Customer Dashboard (built in code so the existing
    // buttons and their click handlers keep working exactly as before).
    public partial class frmCustomerDashboard
    {
        private Panel pnlContent = null!;
        private HeroPanel heroPanel = null!;
        private Label lblGreeting = null!;
        private Label lblWelcome = null!;
        private Label lblHeroSub = null!;
        private Panel activityHost = null!;
        private Label lblTip = null!;
        private Label lblHeaderTime = null!;
        private Label lblHeaderDate = null!;

        private readonly Label[] tileValues = new Label[4];
        private readonly BadgeCircle[] tipDots = new BadgeCircle[4];
        private readonly decimal[] countTargets = new decimal[3];

        private readonly System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
        private readonly System.Windows.Forms.Timer countTimer = new System.Windows.Forms.Timer();
        private readonly System.Windows.Forms.Timer tipTimer = new System.Windows.Forms.Timer();
        private readonly System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();

        private const int CountSteps = 28;
        private int countStep;
        private int tipIndex;

        private static readonly string[] Tips = new string[]
        {
            "Describe the problem in detail when you submit a request. It helps your provider arrive prepared.",
            "Pick a time slot that suits you, then follow every step of your job under Track Request.",
            "Small leaks and loose fittings are cheapest to fix early. Report them before they grow.",
            "Open Service History any time to see what was done and what it cost."
        };

        // ------------------------------------------------------------------
        //  BUILD
        // ------------------------------------------------------------------
        private void BuildModernUi()
        {
            SuspendLayout();
            BackColor = Theme.Bg;
            Image photo = UiAssets.GetImage("Home Repairs");

            // the old welcome card and overview panel are replaced by the new content
            Controls.Remove(pnlWelcomeCard);
            Controls.Remove(pnlDashBoard);

            BuildHeaderExtras();
            BuildSidebar();

            pnlContent = new Panel();
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Theme.Bg;
            pnlContent.AutoScroll = true;
            pnlContent.AutoScrollMinSize = new Size(980, 900);

            TableLayoutPanel root = new TableLayoutPanel();
            root.Dock = DockStyle.Fill;
            root.BackColor = Theme.Bg;
            root.Padding = new Padding(28, 24, 28, 24);
            root.ColumnCount = 1;
            root.RowCount = 3;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 206F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(BuildHero(photo), 0, 0);
            root.Controls.Add(BuildTiles(), 0, 1);
            root.Controls.Add(BuildLowerSection(), 0, 2);

            pnlContent.Controls.Add(root);
            Controls.Add(pnlContent);
            Controls.SetChildIndex(pnlContent, 0);   // fill area is docked last

            // header + sidebar keep the order: header on top, sidebar on the left
            panel1.Dock = DockStyle.Top;
            panel1.Height = 104;
            panel3.Dock = DockStyle.Left;
            panel3.Width = 299;

            SetUpTimers();
            ResumeLayout(true);
        }

        private void BuildHeaderExtras()
        {
            lblHeaderTime = Theme.MakeLabel("00:00", 20F, FontStyle.Bold, Color.White);
            lblHeaderTime.Location = new Point(0, 20);
            lblHeaderTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(lblHeaderTime);

            lblHeaderDate = Theme.MakeLabel("", 10F, FontStyle.Regular, Color.FromArgb(176, 190, 215));
            lblHeaderDate.Location = new Point(0, 62);
            lblHeaderDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(lblHeaderDate);

            panel1.Resize += delegate { PositionHeaderClock(); };
        }

        private void PositionHeaderClock()
        {
            int right = panel1.ClientSize.Width - 36;
            lblHeaderTime.Left = right - lblHeaderTime.Width;
            lblHeaderDate.Left = right - lblHeaderDate.Width;
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            lblHeaderTime.Text = now.ToString("HH:mm");
            lblHeaderDate.Text = now.ToString("dddd, d MMMM yyyy");
            PositionHeaderClock();
        }

        private void BuildSidebar()
        {
            string name = string.IsNullOrWhiteSpace(CustomerSession.Name) ? "Customer" : CustomerSession.Name;

            BadgeCircle avatar = new BadgeCircle();
            avatar.Initials = AdminUi.Initials(name);
            avatar.Fill = Theme.Orange;
            avatar.RingColor = Color.FromArgb(255, 176, 130);
            avatar.FontSize = 15F;
            avatar.Size = new Size(56, 56);
            avatar.Location = new Point(24, 24);
            panel3.Controls.Add(avatar);

            Label nameLabel = Theme.MakeLabel(name, 11.5F, FontStyle.Bold, Color.White);
            nameLabel.AutoSize = false;
            nameLabel.AutoEllipsis = true;
            nameLabel.Size = new Size(190, 26);
            nameLabel.Location = new Point(92, 30);
            panel3.Controls.Add(nameLabel);

            Label roleLabel = Theme.MakeLabel("Customer account", 9.5F, FontStyle.Regular, Color.FromArgb(140, 160, 195));
            roleLabel.Location = new Point(93, 56);
            panel3.Controls.Add(roleLabel);

            Panel divider = new Panel();
            divider.BackColor = Color.FromArgb(48, 76, 130);
            divider.Location = new Point(24, 104);
            divider.Size = new Size(251, 1);
            panel3.Controls.Add(divider);

            Label menuLabel = Theme.MakeLabel("MENU", 8.5F, FontStyle.Bold, Color.FromArgb(120, 142, 180));
            menuLabel.Location = new Point(28, 122);
            panel3.Controls.Add(menuLabel);

            // make room for the profile block
            BtnActiceRequests.Top += 118;
            btnServiceHistory.Top += 118;
            btnTrackRequest.Top += 118;
            btnNewServiceRequest.Top += 118;

            // keep Logout pinned to the bottom of the sidebar
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panel3.Resize += delegate { PositionLogout(); };
        }

        private void PositionLogout()
        {
            btnLogout.Top = panel3.ClientSize.Height - btnLogout.Height - 28;
        }

        // ------------------------------------------------------------------
        //  HERO
        // ------------------------------------------------------------------
        private Control BuildHero(Image? photo)
        {
            heroPanel = new HeroPanel();
            heroPanel.Photo = photo;
            heroPanel.Dock = DockStyle.Fill;
            heroPanel.Margin = new Padding(0, 0, 0, 16);

            lblGreeting = Theme.MakeLabel("GOOD DAY", 10F, FontStyle.Bold, Color.FromArgb(255, 160, 110));
            lblGreeting.Location = new Point(38, 30);
            heroPanel.Controls.Add(lblGreeting);

            lblWelcome = Theme.MakeLabel("Welcome back!", 26F, FontStyle.Bold, Color.White);
            lblWelcome.AutoSize = false;
            lblWelcome.AutoEllipsis = true;
            lblWelcome.Size = new Size(720, 56);
            lblWelcome.Location = new Point(36, 54);
            heroPanel.Controls.Add(lblWelcome);

            lblHeroSub = Theme.MakeLabel("", 11F, FontStyle.Regular, Color.FromArgb(205, 216, 236));
            lblHeroSub.AutoSize = false;
            lblHeroSub.Size = new Size(620, 48);
            lblHeroSub.Location = new Point(38, 112);
            heroPanel.Controls.Add(lblHeroSub);

            // (the New Service Request / Track Request shortcuts live in the sidebar and Quick actions,
            //  so the welcome banner stays clean)
            return heroPanel;
        }

        // ------------------------------------------------------------------
        //  STAT TILES
        // ------------------------------------------------------------------
        private Control BuildTiles()
        {
            TableLayoutPanel tiles = new TableLayoutPanel();
            tiles.Dock = DockStyle.Fill;
            tiles.BackColor = Theme.Bg;
            tiles.Margin = new Padding(0);
            tiles.ColumnCount = 4;
            tiles.RowCount = 1;
            for (int i = 0; i < 4; i++)
                tiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tiles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            string[] captions = { "ACTIVE REQUESTS", "COMPLETED JOBS", "TOTAL SPENT", "NEXT APPOINTMENT" };
            Color[] accents = { Theme.Orange, Theme.Green, Theme.Blue, Theme.Purple };

            for (int i = 0; i < 4; i++)
            {
                CardPanel tile = new CardPanel();
                tile.Dock = DockStyle.Fill;
                tile.Margin = new Padding(0, 0, i < 3 ? 14 : 0, 8);
                float sc = tile.DeviceDpi / 96f;
                tile.Padding = new Padding((int)(26 * sc), (int)(14 * sc), (int)(14 * sc), (int)(22 * sc));
                tile.AccentColor = accents[i];

                // Keep the KPI label and value only; the dashboard already explains each metric elsewhere.
                TableLayoutPanel stack = new TableLayoutPanel();
                stack.Dock = DockStyle.Fill;
                stack.BackColor = Color.Transparent;
                stack.ColumnCount = 1;
                stack.RowCount = 2;
                stack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                stack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                stack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tile.Controls.Add(stack);

                Label caption = Theme.MakeLabel(captions[i], 8.5F, FontStyle.Bold, Theme.Muted);
                caption.Margin = new Padding(0, 2, 0, 0);
                stack.Controls.Add(caption, 0, 0);

                Label value = Theme.MakeLabel(i == 3 ? "None" : "0", i == 3 ? 17F : 22F, FontStyle.Bold, Theme.Navy);
                value.Margin = new Padding(0, i == 3 ? 6 : 0, 0, 0);
                stack.Controls.Add(value, 0, 1);

                tileValues[i] = value;
                tiles.Controls.Add(tile, i, 0);
            }
            return tiles;
        }

        // ------------------------------------------------------------------
        //  LOWER SECTION: recent activity + quick actions + tips
        // ------------------------------------------------------------------
        private Control BuildLowerSection()
        {
            TableLayoutPanel lower = new TableLayoutPanel();
            lower.Dock = DockStyle.Fill;
            lower.BackColor = Theme.Bg;
            lower.Margin = new Padding(0);
            lower.ColumnCount = 2;
            lower.RowCount = 1;
            lower.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            lower.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            lower.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ---- recent activity card ----
            CardPanel activityCard = new CardPanel();
            activityCard.Dock = DockStyle.Fill;
            activityCard.Margin = new Padding(0);
            activityCard.Padding = new Padding(26, 18, 26, 28);

            activityHost = new Panel();
            activityHost.Dock = DockStyle.Fill;
            activityHost.BackColor = Color.White;
            activityCard.Controls.Add(activityHost);

            Panel top = new Panel();
            top.Dock = DockStyle.Top;
            top.Height = 46;
            top.BackColor = Color.White;

            Label title = Theme.MakeLabel("Recent activity", 13F, FontStyle.Bold, Theme.Navy);
            title.BackColor = Color.White;
            title.Location = new Point(0, 8);
            top.Controls.Add(title);

            Label viewAll = Theme.MakeLabel("View all requests", 10F, FontStyle.Bold, Theme.Orange);
            viewAll.BackColor = Color.White;
            viewAll.Cursor = Cursors.Hand;
            viewAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            viewAll.Click += btnTrackRequest_Click_1;
            top.Controls.Add(viewAll);
            viewAll.Location = new Point(Math.Max(0, top.Width - viewAll.Width), 12);
            top.Resize += delegate { viewAll.Left = top.ClientSize.Width - viewAll.Width; };
            activityCard.Controls.Add(top);

            lower.Controls.Add(activityCard, 0, 0);

            // ---- right column ----
            TableLayoutPanel right = new TableLayoutPanel();
            right.Dock = DockStyle.Fill;
            right.BackColor = Theme.Bg;
            right.Margin = new Padding(16, 0, 0, 0);
            right.ColumnCount = 1;
            right.RowCount = 2;
            right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 236F));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            right.Controls.Add(BuildQuickActions(), 0, 0);
            right.Controls.Add(BuildTipCard(), 0, 1);

            lower.Controls.Add(right, 1, 0);
            return lower;
        }

        private Control BuildQuickActions()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 0, 0, 12);
            card.Padding = new Padding(24, 16, 24, 22);

            TableLayoutPanel buttons = new TableLayoutPanel();
            buttons.Dock = DockStyle.Fill;
            buttons.BackColor = Color.White;
            buttons.ColumnCount = 1;
            buttons.RowCount = 3;
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 3; i++)
                buttons.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));

            ModernButton active = new ModernButton();
            active.Text = "Active Requests";
            active.BaseColor = Theme.Navy;
            active.HoverColor = Theme.NavyLight;
            active.Dock = DockStyle.Fill;
            active.Margin = new Padding(0, 4, 0, 4);
            active.Click += BtnActiceRequests_Click;
            buttons.Controls.Add(active, 0, 0);

            ModernButton history = new ModernButton();
            history.Text = "Service History";
            history.Outline = true;
            history.BaseColor = Theme.Navy;
            history.Dock = DockStyle.Fill;
            history.Margin = new Padding(0, 4, 0, 4);
            history.Click += btnServiceHistory_Click;
            buttons.Controls.Add(history, 0, 1);

            ModernButton track = new ModernButton();
            track.Text = "Track a Request";
            track.Outline = true;
            track.BaseColor = Theme.Navy;
            track.Dock = DockStyle.Fill;
            track.Margin = new Padding(0, 4, 0, 4);
            track.Click += btnTrackRequest_Click_1;
            buttons.Controls.Add(track, 0, 2);

            card.Controls.Add(buttons);

            Label title = Theme.MakeLabel("Quick actions", 13F, FontStyle.Bold, Theme.Navy);
            title.BackColor = Color.White;
            title.AutoSize = false;
            title.Dock = DockStyle.Top;
            title.Height = 40;
            card.Controls.Add(title);

            return card;
        }

        private Control BuildTipCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0);
            card.Padding = new Padding(30, 16, 24, 22);
            card.AccentColor = Theme.Orange;

            lblTip = Theme.MakeLabel(Tips[0], 10.5F, FontStyle.Regular, Theme.Text);
            lblTip.AutoSize = false;
            lblTip.Dock = DockStyle.Fill;
            lblTip.TextAlign = ContentAlignment.TopLeft;
            card.Controls.Add(lblTip);

            Panel dots = new Panel();
            dots.Dock = DockStyle.Bottom;
            dots.Height = 20;
            dots.BackColor = Color.White;
            for (int i = 0; i < tipDots.Length; i++)
            {
                BadgeCircle dot = new BadgeCircle();
                dot.Size = new Size(10, 10);
                dot.Location = new Point(i * 18, 6);
                dot.Fill = i == 0 ? Theme.Orange : Theme.Border;
                tipDots[i] = dot;
                dots.Controls.Add(dot);
            }
            card.Controls.Add(dots);

            Label heading = Theme.MakeLabel("HOME HERO TIP", 8.5F, FontStyle.Bold, Theme.Orange);
            heading.AutoSize = false;
            heading.Dock = DockStyle.Top;
            heading.Height = 26;
            card.Controls.Add(heading);

            return card;
        }

        private void ShowTip(int index)
        {
            lblTip.Text = Tips[index];
            for (int i = 0; i < tipDots.Length; i++)
            {
                tipDots[i].Fill = i == index ? Theme.Orange : Theme.Border;
                tipDots[i].Invalidate();
            }
        }

        // ------------------------------------------------------------------
        //  LIVE DATA
        // ------------------------------------------------------------------
        private void RefreshDashboard()
        {
            string name = CustomerSession.Name;
            int hour = DateTime.Now.Hour;
            lblGreeting.Text = hour < 12 ? "GOOD MORNING" : (hour < 18 ? "GOOD AFTERNOON" : "GOOD EVENING");
            lblWelcome.Text = string.IsNullOrWhiteSpace(name) ? "Welcome back!" : "Welcome back, " + name + "!";

            string customerId = CustomerSession.CustomerId;
            List<MaintenanceRequest> mine = DataManager.LoadRequests()
                .Where(r => r.CustomerId == customerId)
                .ToList();

            List<MaintenanceRequest> active = mine
                .Where(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled)
                .ToList();
            List<MaintenanceRequest> completed = mine
                .Where(r => r.Status == RequestStatus.Completed)
                .ToList();

            decimal spent = completed.Sum(r => r.FinalCost > 0 ? r.FinalCost : r.EstimatedCost);
            int awaiting = active.Count(r => r.Status == RequestStatus.Requested);

            MaintenanceRequest? next = active
                .Where(r => r.PreferredDate.Date >= DateTime.Today)
                .OrderBy(r => r.PreferredDate)
                .FirstOrDefault();

            lblHeroSub.Text = active.Count == 0
                ? "You have no active requests right now. Something needs fixing? We are just a click away."
                : (active.Count == 1
                    ? "You have 1 active request. We will keep you updated every step of the way."
                    : "You have " + active.Count + " active requests. We will keep you updated every step of the way.");

            countTargets[0] = active.Count;
            countTargets[1] = completed.Count;
            countTargets[2] = spent;
            tileValues[0].Text = "0";
            tileValues[1].Text = "0";
            tileValues[2].Text = AdminUi.Money(0);

            if (next == null)
            {
                tileValues[3].Text = "None";
            }
            else
            {
                tileValues[3].Text = next.PreferredDate.ToString("dd MMM yyyy");
            }

            List<MaintenanceRequest> recent = mine
                .OrderByDescending(r => r.RequestNumber ?? "")
                .Take(4)
                .ToList();
            BuildActivityRows(recent);
        }

        private void BuildActivityRows(List<MaintenanceRequest> recent)
        {
            activityHost.SuspendLayout();
            activityHost.Controls.Clear();

            if (recent.Count == 0)
            {
                Label empty = new Label();
                empty.Dock = DockStyle.Fill;
                empty.BackColor = Color.White;
                empty.ForeColor = Theme.Muted;
                empty.Font = Theme.MakeFont(11F);
                empty.TextAlign = ContentAlignment.MiddleCenter;
                empty.Text = "No requests yet.\r\n\r\nUse \"New Service Request\" to get your first job on its way.";
                activityHost.Controls.Add(empty);
            }
            else
            {
                // docked-top controls stack with the last one added on top, so add oldest first
                for (int i = recent.Count - 1; i >= 0; i--)
                    activityHost.Controls.Add(MakeActivityRow(recent[i]));
            }

            activityHost.ResumeLayout(true);
        }

        private Panel MakeActivityRow(MaintenanceRequest request)
        {
            Panel row = new Panel();
            row.Dock = DockStyle.Top;
            row.Height = 66;
            row.BackColor = Color.White;

            Panel line = new Panel();
            line.Dock = DockStyle.Bottom;
            line.Height = 1;
            line.BackColor = Theme.Border;
            row.Controls.Add(line);

            string category = string.IsNullOrWhiteSpace(request.ServiceCategory) ? "Service" : request.ServiceCategory;
            Color badgeFill;
            Color badgeFore;
            CategoryColors(category, out badgeFill, out badgeFore);

            BadgeCircle badge = new BadgeCircle();
            badge.Initials = category.Substring(0, 1).ToUpper();
            badge.Fill = badgeFill;
            badge.TextColor = badgeFore;
            badge.FontSize = 12F;
            badge.Size = new Size(42, 42);
            badge.Location = new Point(2, 12);
            row.Controls.Add(badge);

            Label titleLabel = Theme.MakeLabel(category, 11F, FontStyle.Bold, Theme.Text);
            titleLabel.BackColor = Color.White;
            titleLabel.AutoSize = false;
            titleLabel.AutoEllipsis = true;
            titleLabel.Size = new Size(300, 24);
            titleLabel.Location = new Point(58, 11);
            row.Controls.Add(titleLabel);

            string description = request.ProblemDescription ?? "";
            string subText = description + "   |   " + request.PreferredDate.ToString("dd MMM yyyy");
            Label subLabel = Theme.MakeLabel(subText, 9F, FontStyle.Regular, Theme.Muted);
            subLabel.BackColor = Color.White;
            subLabel.AutoSize = false;
            subLabel.AutoEllipsis = true;
            subLabel.Size = new Size(300, 20);
            subLabel.Location = new Point(58, 36);
            row.Controls.Add(subLabel);

            Color pillBack;
            Color pillFore;
            AdminUi.StatusColors(request.Status, out pillBack, out pillFore);
            PillLabel pill = new PillLabel();
            pill.PillText = AdminUi.StatusText(request.Status);
            pill.PillBack = pillBack;
            pill.PillFore = pillFore;
            pill.Size = new Size(130, 28);
            row.Controls.Add(pill);

            Action layout = delegate
            {
                pill.Location = new Point(row.ClientSize.Width - pill.Width - 6, 19);
                int w = Math.Max(80, pill.Left - 70);
                titleLabel.Width = w;
                subLabel.Width = w;
            };
            row.Resize += delegate { layout(); };
            layout();

            return row;
        }

        private static void CategoryColors(string? category, out Color fill, out Color fore)
        {
            string c = (category ?? "").ToLower();
            if (c.Contains("plumb")) { fill = Theme.BlueSoft; fore = Theme.Blue; }
            else if (c.Contains("elec")) { fill = Theme.AmberSoft; fore = Theme.Amber; }
            else if (c.Contains("paint")) { fill = Theme.PurpleSoft; fore = Theme.Purple; }
            else if (c.Contains("appliance")) { fill = Theme.GreenSoft; fore = Theme.Green; }
            else { fill = Theme.OrangeSoft; fore = Theme.Orange; }
        }

        // ------------------------------------------------------------------
        //  ANIMATION
        // ------------------------------------------------------------------
        private void SetUpTimers()
        {
            fadeTimer.Interval = 15;
            fadeTimer.Tick += delegate
            {
                Opacity = Math.Min(1.0, Opacity + 0.08);
                if (Opacity >= 1.0) fadeTimer.Stop();
            };

            countTimer.Interval = 22;
            countTimer.Tick += delegate
            {
                countStep++;
                double t = Math.Min(1.0, countStep / (double)CountSteps);
                decimal eased = (decimal)(1.0 - Math.Pow(1.0 - t, 3));

                tileValues[0].Text = ((int)Math.Round(countTargets[0] * eased)).ToString();
                tileValues[1].Text = ((int)Math.Round(countTargets[1] * eased)).ToString();
                tileValues[2].Text = AdminUi.Money(countTargets[2] * eased);

                if (countStep >= CountSteps) countTimer.Stop();
            };

            tipTimer.Interval = 6500;
            tipTimer.Tick += delegate
            {
                tipIndex = (tipIndex + 1) % Tips.Length;
                ShowTip(tipIndex);
            };

            clockTimer.Interval = 1000;
            clockTimer.Tick += delegate { UpdateClock(); };

            // hidden dashboards should not keep ticking in the background
            VisibleChanged += delegate
            {
                clockTimer.Enabled = Visible;
                tipTimer.Enabled = Visible;
            };

            FormClosed += delegate
            {
                fadeTimer.Dispose();
                countTimer.Dispose();
                tipTimer.Dispose();
                clockTimer.Dispose();
            };
        }

        private void StartAnimations()
        {
            RefreshDashboard();
            UpdateClock();
            PositionLogout();

            Opacity = 0;
            fadeTimer.Start();

            countStep = 0;
            countTimer.Start();

            tipIndex = 0;
            ShowTip(0);
            clockTimer.Start();
            tipTimer.Start();
        }
    }
}
