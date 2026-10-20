using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmCreateRequest
    {
        // ---- header ----
        private GradientPanel pnlHeader = null!;
        private ModernButton btnBack = null!;

        // ---- card 1 : category + priority ----
        private ComboBox cmbCategory = null!;
        private readonly List<ModernButton> categoryChips = new List<ModernButton>();
        private OptionCard RdbxNormalPriorityLevel1 = null!;
        private OptionCard RdbtnUrgent1 = null!;

        // ---- card 2 : description ----
        private TextBox txtProblemDescription = null!;
        private Label lblMinimumCharacters = null!;
        private Label lblQuality = null!;
        private Label lblQualityHint = null!;
        private MeterBar barQuality = null!;

        // ---- card 3 : date / time / address ----
        private DateTimePicker dtpDatePreferred = null!;
        private ComboBox cmbTimeSlot = null!;
        private TextBox txtAddress = null!;

        // ---- AI assistant ----
        private Label lblAiStatus = null!;
        private Label lblAiHeadline = null!;
        private PillLabel pillAiCategory = null!;
        private PillLabel pillAiPriority = null!;
        private Label lblAiConfidence = null!;
        private Label lblAiTip = null!;
        private ModernButton btnAiApply = null!;

        // ---- footer ----
        private Label lblEstimatedCost = null!;
        private Label lblCostBreakdown = null!;
        private Label lblCompleteness = null!;
        private MeterBar barCompleteness = null!;
        private ModernButton btnSubmitRequest = null!;

        private void BuildUi()
        {
            SuspendLayout();

            BackColor = Theme.Bg;
            Font = Theme.MakeFont(9.5F);

            // =================== BODY ===================
            Panel body = new Panel();
            body.Dock = DockStyle.Fill;
            body.BackColor = Theme.Bg;
            body.Padding = new Padding(32, 22, 32, 18);
            body.AutoScroll = true;
            body.AutoScrollMinSize = new Size(1150, 930);

            TableLayoutPanel columns = new TableLayoutPanel();
            columns.Dock = DockStyle.Fill;
            columns.BackColor = Theme.Bg;
            columns.ColumnCount = 2;
            columns.RowCount = 1;
            columns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            columns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            columns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ---- left column ----
            TableLayoutPanel left = new TableLayoutPanel();
            left.Dock = DockStyle.Fill;
            left.Margin = new Padding(0, 0, 16, 0);
            left.BackColor = Theme.Bg;
            left.ColumnCount = 1;
            left.RowCount = 2;
            left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            left.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
            left.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            left.Controls.Add(BuildCategoryCard(), 0, 0);
            left.Controls.Add(BuildDescriptionCard(), 0, 1);

            // ---- right column ----
            TableLayoutPanel right = new TableLayoutPanel();
            right.Dock = DockStyle.Fill;
            right.Margin = new Padding(0);
            right.BackColor = Theme.Bg;
            right.ColumnCount = 1;
            right.RowCount = 3;
            right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 176F));
            right.Controls.Add(BuildScheduleCard(), 0, 0);
            right.Controls.Add(BuildAiCard(), 0, 1);
            right.Controls.Add(BuildFooterCard(), 0, 2);

            columns.Controls.Add(left, 0, 0);
            columns.Controls.Add(right, 1, 0);
            body.Controls.Add(columns);

            // =================== HEADER ===================
            pnlHeader = new GradientPanel();
            pnlHeader.Photo = UiAssets.GetImage("Emergency Plumbing Service");
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 104;

            Label brand = Theme.MakeLabel("Home Hero", 24F, FontStyle.Bold, Color.White);
            brand.Location = new Point(30, 12);

            Label tagline = Theme.MakeLabel("NEW SERVICE REQUEST", 8.5F, FontStyle.Bold, Theme.Orange);
            tagline.Location = new Point(34, 64);

            Label title = Theme.MakeLabel("Tell us what needs fixing", 17F, FontStyle.Bold, Color.White);
            title.Location = new Point(420, 22);

            Label subtitle = Theme.MakeLabel("Our smart assistant reads your description and helps you get the request right first time", 10F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
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
            pnlHeader.Resize += (s, e) => { btnBack.Left = pnlHeader.ClientSize.Width - btnBack.Width - 40; };

            Controls.Add(body);
            Controls.Add(pnlHeader);

            ResumeLayout(true);
        }

        // ------------------------------------------------------------------
        private PillLabel MakeStepBadge(string number, Point location)
        {
            PillLabel badge = new PillLabel();
            badge.PillText = number;
            badge.PillBack = Theme.Orange;
            badge.PillFore = Color.White;
            badge.Font = Theme.MakeFont(13F, FontStyle.Bold);
            badge.Size = new Size(40, 40);
            badge.Location = location;
            return badge;
        }

        private Control BuildCategoryCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 0, 0, 8);

            card.Controls.Add(MakeStepBadge("1", new Point(28, 20)));

            Label title = Theme.MakeLabel("Service Category", 15F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(80, 18);

            Label hint = Theme.MakeLabel("What type of service do you need?", 9.5F, FontStyle.Regular, Theme.Muted);
            hint.Location = new Point(82, 48);

            // quick-pick chips
            FlowLayoutPanel chips = new FlowLayoutPanel();
            chips.BackColor = Color.Transparent;
            chips.Location = new Point(28, 86);
            chips.Size = new Size(card.Width - 56, 46);
            chips.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chips.WrapContents = false;

            string[] cats = { "Plumbing", "Electrical", "Painting", "Appliance Repair", "General Maintenance" };
            foreach (string c in cats)
            {
                ModernButton chip = new ModernButton();
                chip.Text = c;
                chip.Tag = c;
                chip.Radius = 20;
                chip.Outline = true;
                chip.BaseColor = Theme.Navy;
                chip.HoverColor = Theme.NavyLight;
                chip.Height = 40;
                chip.Width = c.Length > 12 ? (c.Length > 17 ? 178 : 150) : 106;
                chip.Margin = new Padding(0, 0, 10, 0);
                chip.Font = Theme.MakeSemibold(9.5F);
                chip.Click += categoryChip_Click;
                categoryChips.Add(chip);
                chips.Controls.Add(chip);
            }

            InputFrame comboFrame = new InputFrame();
            comboFrame.Location = new Point(28, 144);
            comboFrame.Size = new Size(430, 46);
            cmbCategory = new ComboBox();
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = Theme.MakeFont(10.5F);
            cmbCategory.BackColor = Color.White;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            comboFrame.Controls.Add(cmbCategory);

            Label orLabel = Theme.MakeLabel("...or choose from the list", 9F, FontStyle.Regular, Theme.Muted);
            orLabel.Location = new Point(470, 157);

            Label priority = Theme.MakeLabel("PRIORITY", 8.5F, FontStyle.Bold, Theme.Muted);
            priority.Location = new Point(30, 208);

            TableLayoutPanel prio = new TableLayoutPanel();
            prio.BackColor = Color.Transparent;
            prio.Location = new Point(28, 232);
            prio.Size = new Size(card.Width - 56, 76);
            prio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prio.ColumnCount = 2;
            prio.RowCount = 1;
            prio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            prio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            prio.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            RdbxNormalPriorityLevel1 = new OptionCard();
            RdbxNormalPriorityLevel1.Title = "Normal";
            RdbxNormalPriorityLevel1.Subtitle = "Within a few days";
            RdbxNormalPriorityLevel1.Accent = Theme.Green;
            RdbxNormalPriorityLevel1.AccentSoft = Theme.GreenSoft;
            RdbxNormalPriorityLevel1.Dock = DockStyle.Fill;
            RdbxNormalPriorityLevel1.Margin = new Padding(0, 0, 8, 0);
            RdbxNormalPriorityLevel1.Checked = true;

            RdbtnUrgent1 = new OptionCard();
            RdbtnUrgent1.Title = "Urgent";
            RdbtnUrgent1.Subtitle = "Same day / ASAP";
            RdbtnUrgent1.Accent = Theme.Red;
            RdbtnUrgent1.AccentSoft = Theme.RedSoft;
            RdbtnUrgent1.Dock = DockStyle.Fill;
            RdbtnUrgent1.Margin = new Padding(8, 0, 0, 0);

            prio.Controls.Add(RdbxNormalPriorityLevel1, 0, 0);
            prio.Controls.Add(RdbtnUrgent1, 1, 0);

            card.Controls.Add(title);
            card.Controls.Add(hint);
            card.Controls.Add(chips);
            card.Controls.Add(comboFrame);
            card.Controls.Add(orLabel);
            card.Controls.Add(priority);
            card.Controls.Add(prio);
            return card;
        }

        // ------------------------------------------------------------------
        private Control BuildDescriptionCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 0, 0);
            card.Padding = new Padding(0, 4, 0, 10);

            // middle: text box
            Panel middle = new Panel();
            middle.Dock = DockStyle.Fill;
            middle.BackColor = Color.Transparent;
            middle.Padding = new Padding(28, 4, 28, 6);

            InputFrame frame = new InputFrame();
            frame.Dock = DockStyle.Fill;
            txtProblemDescription = new TextBox();
            txtProblemDescription.Multiline = true;
            txtProblemDescription.BorderStyle = BorderStyle.None;
            txtProblemDescription.Font = Theme.MakeFont(10.5F);
            txtProblemDescription.BackColor = Color.White;
            txtProblemDescription.ScrollBars = ScrollBars.Vertical;
            txtProblemDescription.PlaceholderText = "Describe what needs fixing, any relevant details about the problem - where it is, since when, what you have tried...";
            txtProblemDescription.TextChanged += txtProblemDescription_TextChanged;
            frame.Controls.Add(txtProblemDescription);
            middle.Controls.Add(frame);

            // bottom: quality meter
            Panel bottom = new Panel();
            bottom.Dock = DockStyle.Bottom;
            bottom.Height = 92;
            bottom.BackColor = Color.Transparent;

            Label qCaption = Theme.MakeLabel("DESCRIPTION QUALITY", 8.5F, FontStyle.Bold, Theme.Muted);
            qCaption.Location = new Point(30, 8);

            lblQuality = Theme.MakeLabel("Waiting for details", 9.5F, FontStyle.Bold, Theme.Navy);
            lblQuality.Location = new Point(190, 6);

            lblMinimumCharacters = Theme.MakeLabel("0 chars (20 more needed)", 9F, FontStyle.Regular, Theme.Muted);
            lblMinimumCharacters.Location = new Point(400, 8);

            barQuality = new MeterBar();
            barQuality.Location = new Point(30, 34);
            barQuality.Size = new Size(card.Width - 60, 10);
            barQuality.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            barQuality.BarColor = Theme.Orange;

            lblQualityHint = Theme.MakeLabel("Tell us what happened, where it is and since when.", 9F, FontStyle.Regular, Theme.Muted);
            lblQualityHint.Location = new Point(30, 54);

            bottom.Resize += (s, e) => { lblMinimumCharacters.Left = bottom.ClientSize.Width - lblMinimumCharacters.Width - 30; };

            bottom.Controls.Add(qCaption);
            bottom.Controls.Add(lblQuality);
            bottom.Controls.Add(lblMinimumCharacters);
            bottom.Controls.Add(barQuality);
            bottom.Controls.Add(lblQualityHint);

            // top: header
            Panel top = new Panel();
            top.Dock = DockStyle.Top;
            top.Height = 78;
            top.BackColor = Color.Transparent;

            top.Controls.Add(MakeStepBadge("2", new Point(28, 14)));
            Label title = Theme.MakeLabel("Problem Description", 15F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(80, 12);
            Label hint = Theme.MakeLabel("Describe the issue - the more detail, the better your quote and visit", 9.5F, FontStyle.Regular, Theme.Muted);
            hint.Location = new Point(82, 42);
            top.Controls.Add(title);
            top.Controls.Add(hint);

            card.Controls.Add(middle);
            card.Controls.Add(bottom);
            card.Controls.Add(top);
            return card;
        }

        // ------------------------------------------------------------------
        private Control BuildScheduleCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 0, 0, 8);

            card.Controls.Add(MakeStepBadge("3", new Point(28, 20)));

            Label title = Theme.MakeLabel("Preferred Date And Time", 15F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(80, 18);
            Label hint = Theme.MakeLabel("When should the provider visit?", 9.5F, FontStyle.Regular, Theme.Muted);
            hint.Location = new Point(82, 48);

            TableLayoutPanel cols = new TableLayoutPanel();
            cols.BackColor = Color.Transparent;
            cols.Location = new Point(28, 86);
            cols.Size = new Size(card.Width - 56, 76);
            cols.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cols.ColumnCount = 2;
            cols.RowCount = 1;
            cols.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cols.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cols.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // date
            Panel dateCell = new Panel();
            dateCell.Dock = DockStyle.Fill;
            dateCell.Margin = new Padding(0, 0, 8, 0);
            dateCell.BackColor = Color.Transparent;
            Label dateLabel = Theme.MakeLabel("PREFERRED DATE", 8.5F, FontStyle.Bold, Theme.Muted);
            dateLabel.Location = new Point(2, 0);
            InputFrame dateFrame = new InputFrame();
            dateFrame.Location = new Point(0, 24);
            dateFrame.Size = new Size(dateCell.Width, 46);
            dateFrame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDatePreferred = new DateTimePicker();
            dtpDatePreferred.Format = DateTimePickerFormat.Short;
            dtpDatePreferred.Font = Theme.MakeFont(10.5F);
            dtpDatePreferred.ValueChanged += (s, e) => UpdateCompleteness();
            dateFrame.Controls.Add(dtpDatePreferred);
            dateCell.Controls.Add(dateLabel);
            dateCell.Controls.Add(dateFrame);

            // time slot
            Panel timeCell = new Panel();
            timeCell.Dock = DockStyle.Fill;
            timeCell.Margin = new Padding(8, 0, 0, 0);
            timeCell.BackColor = Color.Transparent;
            Label timeLabel = Theme.MakeLabel("TIME SLOT", 8.5F, FontStyle.Bold, Theme.Muted);
            timeLabel.Location = new Point(2, 0);
            InputFrame timeFrame = new InputFrame();
            timeFrame.Location = new Point(0, 24);
            timeFrame.Size = new Size(timeCell.Width, 46);
            timeFrame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTimeSlot = new ComboBox();
            cmbTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeSlot.FlatStyle = FlatStyle.Flat;
            cmbTimeSlot.Font = Theme.MakeFont(10.5F);
            cmbTimeSlot.BackColor = Color.White;
            cmbTimeSlot.SelectedIndexChanged += (s, e) => UpdateCompleteness();
            timeFrame.Controls.Add(cmbTimeSlot);
            timeCell.Controls.Add(timeLabel);
            timeCell.Controls.Add(timeFrame);

            cols.Controls.Add(dateCell, 0, 0);
            cols.Controls.Add(timeCell, 1, 0);

            Label addrLabel = Theme.MakeLabel("PROPERTY ADDRESS", 8.5F, FontStyle.Bold, Theme.Muted);
            addrLabel.Location = new Point(30, 176);

            InputFrame addrFrame = new InputFrame();
            addrFrame.Location = new Point(28, 200);
            addrFrame.Size = new Size(card.Width - 56, 112);
            addrFrame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress = new TextBox();
            txtAddress.Multiline = true;
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = Theme.MakeFont(10.5F);
            txtAddress.BackColor = Color.White;
            txtAddress.PlaceholderText = "Enter street address and suburb, e.g. 45 Oak Street, Sandton";
            txtAddress.TextChanged += (s, e) => UpdateCompleteness();
            addrFrame.Controls.Add(txtAddress);

            card.Controls.Add(title);
            card.Controls.Add(hint);
            card.Controls.Add(cols);
            card.Controls.Add(addrLabel);
            card.Controls.Add(addrFrame);
            return card;
        }

        // ------------------------------------------------------------------
        private Control BuildAiCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 0, 8);
            card.FillColor = Color.FromArgb(250, 247, 255);
            card.BorderColor = Color.FromArgb(221, 214, 254);
            card.AccentColor = Theme.Purple;

            PillLabel aiBadge = new PillLabel();
            aiBadge.PillText = "AI";
            aiBadge.PillBack = Theme.Purple;
            aiBadge.PillFore = Color.White;
            aiBadge.Size = new Size(44, 26);
            aiBadge.Location = new Point(30, 18);

            Label title = Theme.MakeLabel("Smart Assistant", 14F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(84, 16);

            lblAiStatus = Theme.MakeLabel("Ready", 9F, FontStyle.Italic, Theme.Purple);
            lblAiStatus.Location = new Point(250, 22);

            lblAiHeadline = Theme.MakeLabel("Start typing and I will analyse your problem.", 10.5F, FontStyle.Bold, Theme.Text);
            lblAiHeadline.AutoSize = false;
            lblAiHeadline.Location = new Point(30, 58);
            lblAiHeadline.Size = new Size(card.Width - 60, 24);
            lblAiHeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            pillAiCategory = new PillLabel();
            pillAiCategory.Width = 150;
            pillAiCategory.Location = new Point(30, 90);
            pillAiCategory.Visible = false;

            pillAiPriority = new PillLabel();
            pillAiPriority.Width = 150;
            pillAiPriority.Location = new Point(190, 90);
            pillAiPriority.Visible = false;

            lblAiConfidence = Theme.MakeLabel("", 9F, FontStyle.Bold, Theme.Purple);
            lblAiConfidence.Location = new Point(350, 95);

            lblAiTip = Theme.MakeLabel("", 9.5F, FontStyle.Regular, Color.FromArgb(76, 29, 149));
            lblAiTip.AutoSize = false;
            lblAiTip.Location = new Point(30, 128);
            lblAiTip.Size = new Size(card.Width - 60, 60);
            lblAiTip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnAiApply = new ModernButton();
            btnAiApply.Text = "Apply suggestions";
            btnAiApply.BaseColor = Theme.Purple;
            btnAiApply.HoverColor = Color.FromArgb(139, 92, 246);
            btnAiApply.Size = new Size(190, 40);
            btnAiApply.Location = new Point(30, 196);
            btnAiApply.Enabled = false;
            btnAiApply.Click += btnAiApply_Click;

            card.Controls.Add(aiBadge);
            card.Controls.Add(title);
            card.Controls.Add(lblAiStatus);
            card.Controls.Add(lblAiHeadline);
            card.Controls.Add(pillAiCategory);
            card.Controls.Add(pillAiPriority);
            card.Controls.Add(lblAiConfidence);
            card.Controls.Add(lblAiTip);
            card.Controls.Add(btnAiApply);
            return card;
        }

        // ------------------------------------------------------------------
        private Control BuildFooterCard()
        {
            CardPanel card = new CardPanel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 8, 0, 0);
            card.AccentColor = Theme.Orange;

            Label cap = Theme.MakeLabel("ESTIMATED COST", 8.5F, FontStyle.Bold, Theme.Muted);
            cap.Location = new Point(28, 18);

            lblEstimatedCost = Theme.MakeLabel("R0.00", 24F, FontStyle.Bold, Theme.Navy);
            lblEstimatedCost.Location = new Point(26, 36);

            lblCostBreakdown = Theme.MakeLabel("Pick a category to see the breakdown", 8.5F, FontStyle.Regular, Theme.Muted);
            lblCostBreakdown.Location = new Point(28, 86);

            lblCompleteness = Theme.MakeLabel("Request completeness  20%", 8.5F, FontStyle.Bold, Theme.Muted);
            lblCompleteness.Location = new Point(28, 112);

            barCompleteness = new MeterBar();
            barCompleteness.Location = new Point(28, 136);
            barCompleteness.Size = new Size(260, 8);
            barCompleteness.BarColor = Theme.Green;
            barCompleteness.Value = 20;

            btnSubmitRequest = new ModernButton();
            btnSubmitRequest.Text = "Submit Request";
            btnSubmitRequest.Font = Theme.MakeSemibold(12F);
            btnSubmitRequest.Size = new Size(230, 58);
            btnSubmitRequest.Radius = 14;
            btnSubmitRequest.Click += btnSubmitRequest_Click;

            card.Resize += (s, e) =>
            {
                btnSubmitRequest.Left = card.ClientSize.Width - btnSubmitRequest.Width - 30;
                btnSubmitRequest.Top = (card.ClientSize.Height - 12 - btnSubmitRequest.Height) / 2 + 2;
            };

            card.Controls.Add(cap);
            card.Controls.Add(lblEstimatedCost);
            card.Controls.Add(lblCostBreakdown);
            card.Controls.Add(lblCompleteness);
            card.Controls.Add(barCompleteness);
            card.Controls.Add(btnSubmitRequest);
            return card;
        }
    }
}
