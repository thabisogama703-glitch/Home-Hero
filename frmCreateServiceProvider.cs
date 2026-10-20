using HomeHero_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    // =====================================================================
    //  SERVICE PROVIDER REGISTRATION
    //  Split screen: brand panel (left) + clean sign-up card (right).
    //  Accounts are saved to providers.json (the same store the Administrator
    //  uses), so a provider can log in straight after registering and the
    //  admin can see and assign them.
    // =====================================================================
    public partial class frmCreateServiceProvider : FitForm
    {
        private static readonly string[] AllSpecialisations =
        {
            "Plumbing", "Electrical", "Painting", "HVAC", "Roofing",
            "Appliance Repair", "General Maintenance", "Landscaping", "Windows & Doors", "Deep Cleaning"
        };

        // inputs
        private readonly TextBox txtFirstName = new TextBox();
        private readonly TextBox txtLastName = new TextBox();
        private readonly TextBox txtEmail = new TextBox();
        private readonly TextBox txtPhoneNumber = new TextBox();
        private readonly TextBox txtServiceArea = new TextBox();
        private readonly TextBox txtPassword = new TextBox();
        private readonly TextBox txtConfirmPassword = new TextBox();
        private readonly List<ChipToggle> chips = new List<ChipToggle>();

        // live feedback
        private ModernButton btnRegister = null!;
        private ModernButton btnBack = null!;
        private Label lblError = null!;
        private Label lblSpecCaption = null!;
        private Label lblStrength = null!;
        private Label lblMatch = null!;
        private Label lblShowPasswords = null!;
        private Label lblProfilePct = null!;
        private Label lblProfileHint = null!;
        private MeterBar mbStrength = null!;
        private MeterBar mbProfile = null!;

        // layout
        private Panel host = null!;
        private CardPanel card = null!;
        private bool building = true;

        public frmCreateServiceProvider()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildUi();
        }

        // ==================================================================
        //  UI CONSTRUCTION
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();
            AdminUi.UseDpiScaling(this);

            Text = "HomeHero | Become a Service Provider";
            BackColor = Theme.Bg;
            Font = Theme.MakeFont(9F);
            MinimumSize = new Size(1000, 760);
            WindowState = FormWindowState.Maximized;

            Control formSide = BuildFormSide();
            Control brandSide = BuildBrandSide();

            // the form side fills what the brand panel leaves behind
            Controls.Add(formSide);
            Controls.Add(brandSide);

            AcceptButton = btnRegister;

            building = false;
            ResumeLayout(true);
            CenterCard();
            UpdateLiveState();
            Load += delegate { CenterCard(); };
            ActiveControl = txtFirstName;
        }

        // ------------------------------------------------------------------
        //  LEFT: brand panel
        // ------------------------------------------------------------------
        private Control BuildBrandSide()
        {
            GradientPanel p = new GradientPanel();
            p.Photo = UiAssets.GetImage("Home Care Concierges");
            p.Dock = DockStyle.Left;
            p.Width = 520;

            // logo + wordmark
            FlowLayoutPanel brand = new FlowLayoutPanel();
            brand.BackColor = Color.Transparent;
            brand.AutoSize = true;
            brand.WrapContents = false;
            brand.FlowDirection = FlowDirection.LeftToRight;
            brand.Location = new Point(48, 38);

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

            brand.Controls.Add(logo);
            brand.Controls.Add(home);
            brand.Controls.Add(hero);
            p.Controls.Add(brand);

            Label kicker = Theme.MakeLabel("FOR SERVICE PROVIDERS", 9F, FontStyle.Bold, Theme.Orange);
            kicker.Location = new Point(50, 150);
            p.Controls.Add(kicker);

            Label headline = Theme.MakeLabel("Grow your business\nwith HomeHero.", 27F, FontStyle.Bold, Color.White);
            headline.AutoSize = false;
            headline.Size = new Size(440, 112);
            headline.Location = new Point(48, 176);
            p.Controls.Add(headline);

            Label sub = Theme.MakeLabel(
                "Join a network of trusted professionals and get matched with maintenance jobs in your area.",
                11F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
            sub.AutoSize = false;
            sub.Size = new Size(430, 70);
            sub.Location = new Point(50, 292);
            p.Controls.Add(sub);

            p.Controls.Add(Benefit("Jobs matched to your skills", "Admins assign requests that fit your specialisations.", 384));
            p.Controls.Add(Benefit("Work close to home", "Tell us the area you cover and stay local.", 444));
            p.Controls.Add(Benefit("Everything in one dashboard", "Start jobs, record the final cost and track earnings.", 504));

            // profile-strength card (glass)
            SoftBox glass = new SoftBox();
            glass.FillColor = Color.FromArgb(34, 255, 255, 255);
            glass.BorderColor = Color.FromArgb(70, 255, 255, 255);
            glass.Radius = 14;
            glass.Size = new Size(424, 132);
            glass.Location = new Point(48, 600);

            Label cap = Theme.MakeLabel("PROFILE STRENGTH", 8.5F, FontStyle.Bold, Color.FromArgb(190, 205, 230));
            cap.Location = new Point(20, 14);
            lblProfilePct = Theme.MakeLabel("0%", 20F, FontStyle.Bold, Color.White);
            lblProfilePct.Location = new Point(18, 32);
            mbProfile = new MeterBar();
            mbProfile.Size = new Size(384, 10);
            mbProfile.Location = new Point(20, 80);
            mbProfile.BarColor = Theme.Orange;
            lblProfileHint = Theme.MakeLabel("Next: add your first name", 9.5F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
            lblProfileHint.Location = new Point(20, 98);

            glass.Controls.Add(cap);
            glass.Controls.Add(lblProfilePct);
            glass.Controls.Add(mbProfile);
            glass.Controls.Add(lblProfileHint);
            p.Controls.Add(glass);

            // keep the glass card pinned to the bottom of the panel
            p.Resize += delegate
            {
                glass.Top = Math.Max(p.ClientSize.Height - glass.Height - (int)(44 * p.DeviceDpi / 96f), 0);
            };

            return p;
        }

        private Control Benefit(string title, string text, int y)
        {
            Panel row = new Panel();
            row.BackColor = Color.Transparent;
            row.Size = new Size(430, 52);
            row.Location = new Point(48, y);

            Panel badge = new Panel();
            badge.Size = new Size(34, 34);
            badge.Location = new Point(0, 4);
            badge.BackColor = Color.Transparent;
            badge.Paint += delegate (object? s, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (SolidBrush b = new SolidBrush(Theme.Orange))
                    e.Graphics.FillEllipse(b, 0, 0, badge.Width - 2, badge.Height - 2);
                TextRenderer.DrawText(e.Graphics, "\u2713", Theme.MakeFont(11F, FontStyle.Bold),
                    new Rectangle(0, 0, badge.Width, badge.Height), Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            };

            Label t = Theme.MakeLabel(title, 11F, FontStyle.Bold, Color.White);
            t.Location = new Point(48, 0);
            Label d = Theme.MakeLabel(text, 9.5F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
            d.Location = new Point(48, 24);

            row.Controls.Add(badge);
            row.Controls.Add(t);
            row.Controls.Add(d);
            return row;
        }

        // ------------------------------------------------------------------
        //  RIGHT: sign-up card
        // ------------------------------------------------------------------
        private Control BuildFormSide()
        {
            Panel side = new Panel();
            side.Dock = DockStyle.Fill;
            side.BackColor = Theme.Bg;

            // ---------- top bar ----------
            Panel bar = new Panel();
            bar.Dock = DockStyle.Top;
            bar.Height = 76;
            bar.BackColor = Theme.Bg;

            btnBack = MakeButton("\u2190  Back to login", 170, 42, true, Theme.Navy);
            btnBack.Location = new Point(36, 17);
            btnBack.Click += btnBack_Click;

            FlowLayoutPanel right = new FlowLayoutPanel();
            right.Dock = DockStyle.Right;
            right.AutoSize = true;
            right.WrapContents = false;
            right.FlowDirection = FlowDirection.LeftToRight;
            right.BackColor = Color.Transparent;
            right.Padding = new Padding(0, 17, 36, 0);

            Label ask = Theme.MakeLabel("Here to find a Hero?", 10F, FontStyle.Regular, Theme.Muted);
            ask.Margin = new Padding(0, 11, 14, 0);
            ModernButton homeowner = MakeButton("Sign up as Homeowner", 215, 42, true, Theme.Orange);
            homeowner.Margin = new Padding(0);
            homeowner.Click += btnSignUpAsHomeowner_Click;
            right.Controls.Add(ask);
            right.Controls.Add(homeowner);

            bar.Controls.Add(btnBack);
            bar.Controls.Add(right);

            // ---------- scrolling host + card ----------
            host = new Panel();
            host.Dock = DockStyle.Fill;
            host.AutoScroll = true;
            host.AutoScrollMargin = new Size(0, 24);
            host.BackColor = Theme.Bg;

            card = BuildCard();
            host.Controls.Add(card);
            host.Resize += delegate { CenterCard(); };

            side.Controls.Add(host);
            side.Controls.Add(bar);
            return side;
        }

        private CardPanel BuildCard()
        {
            CardPanel c = new CardPanel();
            c.FillColor = Color.White;
            c.Size = new Size(720, 904);

            const int L = 36;      // left edge of content
            const int W = 648;     // content width
            const int COL = 312;   // one column of a two-column row
            const int X2 = L + COL + 24;

            // title
            Label title = Theme.MakeLabel("Create your account", 22F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(L - 2, 24);
            Label subtitle = Theme.MakeLabel("Takes about two minutes. You can start receiving jobs as soon as an admin assigns one.", 10F, FontStyle.Regular, Theme.Muted);
            subtitle.Location = new Point(L, 68);
            c.Controls.Add(title);
            c.Controls.Add(subtitle);

            // ---------- personal ----------
            Section(c, "Personal details", L, 104, W);
            Field(c, "First name", txtFirstName, "e.g. Sandra", L, 142, COL);
            Field(c, "Last name", txtLastName, "e.g. Mokoena", X2, 142, COL);
            Field(c, "Email address", txtEmail, "you@email.com", L, 226, COL);
            Field(c, "Phone number", txtPhoneNumber, "10 digits, e.g. 0821234567", X2, 226, COL);
            txtPhoneNumber.MaxLength = 10;
            txtPhoneNumber.KeyPress += delegate (object? s, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            // ---------- services ----------
            Section(c, "Services & location", L, 316, W);

            lblSpecCaption = Theme.MakeLabel("SPECIALISATIONS  -  choose at least one", 8.5F, FontStyle.Bold, Theme.Muted);
            lblSpecCaption.Location = new Point(L + 2, 352);
            c.Controls.Add(lblSpecCaption);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.BackColor = Color.Transparent;
            flow.Location = new Point(L, 376);
            flow.Size = new Size(W, 152);
            foreach (string name in AllSpecialisations)
            {
                ChipToggle chip = new ChipToggle(name);
                chip.Margin = new Padding(0, 0, 10, 8);
                chip.CheckedChanged += OnFieldChanged;
                chips.Add(chip);
                flow.Controls.Add(chip);
            }
            c.Controls.Add(flow);

            Field(c, "Service area", txtServiceArea, "Suburbs or cities you cover, e.g. Sandton, Randburg, Fourways", L, 534, W);

            // ---------- security ----------
            Section(c, "Security", L, 626, W);
            Field(c, "Password", txtPassword, "At least 8 characters", L, 664, COL);
            Field(c, "Confirm password", txtConfirmPassword, "Repeat your password", X2, 664, COL);
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            lblShowPasswords = Theme.MakeLabel("Show", 9F, FontStyle.Bold, Theme.Orange);
            lblShowPasswords.Cursor = Cursors.Hand;
            lblShowPasswords.Location = new Point(L + COL - 36, 664);
            lblShowPasswords.Click += btnShowPassword_Click;
            c.Controls.Add(lblShowPasswords);

            mbStrength = new MeterBar();
            mbStrength.Size = new Size(190, 8);
            mbStrength.Location = new Point(L + 2, 744);
            mbStrength.BarColor = Theme.Border;
            c.Controls.Add(mbStrength);

            lblStrength = Theme.MakeLabel("", 9F, FontStyle.Bold, Theme.Muted);
            lblStrength.Location = new Point(L + 200, 737);
            c.Controls.Add(lblStrength);

            lblMatch = Theme.MakeLabel("", 9F, FontStyle.Bold, Theme.Muted);
            lblMatch.Location = new Point(X2 + 2, 737);
            c.Controls.Add(lblMatch);

            // ---------- error + submit ----------
            lblError = Theme.MakeLabel("", 10F, FontStyle.Bold, Theme.Red);
            lblError.AutoSize = false;
            lblError.Size = new Size(W, 24);
            lblError.Location = new Point(L, 772);
            lblError.AutoEllipsis = true;
            c.Controls.Add(lblError);

            btnRegister = new ModernButton();
            btnRegister.Text = "Create Provider Account";
            btnRegister.Font = Theme.MakeSemibold(11.5F);
            btnRegister.Size = new Size(W, 52);
            btnRegister.Location = new Point(L, 802);
            btnRegister.Click += btnRegister_Click;
            c.Controls.Add(btnRegister);

            LinkLabel foot = new LinkLabel();
            foot.Text = "Already have an account?  Log in";
            foot.AutoSize = false;
            foot.Size = new Size(W, 24);
            foot.Location = new Point(L, 868);
            foot.TextAlign = ContentAlignment.MiddleCenter;
            foot.Font = Theme.MakeFont(10F);
            foot.ForeColor = Theme.Muted;
            foot.LinkColor = Theme.Orange;
            foot.ActiveLinkColor = Theme.OrangeHover;
            foot.VisitedLinkColor = Theme.Orange;
            foot.LinkBehavior = LinkBehavior.HoverUnderline;
            foot.BackColor = Color.Transparent;
            foot.LinkArea = new LinkArea(foot.Text.IndexOf("Log in", StringComparison.Ordinal), 6);
            foot.LinkClicked += delegate { GoToLogin(); };
            c.Controls.Add(foot);

            return c;
        }

        private void Section(Control parent, string text, int x, int y, int width)
        {
            Label l = Theme.MakeLabel(text.ToUpperInvariant(), 9F, FontStyle.Bold, Theme.Orange);
            l.Location = new Point(x + 2, y);
            Panel line = new Panel();
            line.BackColor = Theme.Border;
            line.Size = new Size(width, 1);
            line.Location = new Point(x, y + 24);
            parent.Controls.Add(l);
            parent.Controls.Add(line);
        }

        private void Field(Control parent, string caption, TextBox input, string placeholder, int x, int y, int width)
        {
            Label cap = Theme.MakeLabel(caption.ToUpperInvariant(), 8.5F, FontStyle.Bold, Theme.Muted);
            cap.Location = new Point(x + 2, y);

            input.PlaceholderText = placeholder;
            InputFrame frame = AdminUi.Frame(input, width, 46);
            frame.Location = new Point(x, y + 22);
            input.TextChanged += OnFieldChanged;

            parent.Controls.Add(cap);
            parent.Controls.Add(frame);
        }

        private static ModernButton MakeButton(string text, int w, int h, bool outline, Color baseColor)
        {
            ModernButton b = new ModernButton();
            b.Text = text;
            b.Size = new Size(w, h);
            b.Outline = outline;
            b.BaseColor = baseColor;
            return b;
        }

        private void CenterCard()
        {
            if (host == null || card == null) return;
            int x = Math.Max(0, (host.ClientSize.Width - card.Width) / 2);
            int y = Math.Max(8, (host.ClientSize.Height - card.Height) / 2);
            card.Location = new Point(x, y);
        }

        // ==================================================================
        //  LIVE FEEDBACK  (password strength, profile strength, chip counter)
        // ==================================================================
        private void OnFieldChanged(object? sender, EventArgs e)
        {
            if (building) return;
            UpdateLiveState();
        }

        private void UpdateLiveState()
        {
            lblError.Text = "";

            // ---- password strength ----
            string pw = txtPassword.Text;
            int score = PasswordScore(pw);
            if (pw.Length == 0)
            {
                mbStrength.Value = 0;
                lblStrength.Text = "";
            }
            else if (score <= 2)
            {
                mbStrength.Value = 30; mbStrength.BarColor = Theme.Red;
                lblStrength.Text = "Weak"; lblStrength.ForeColor = Theme.Red;
            }
            else if (score == 3)
            {
                mbStrength.Value = 55; mbStrength.BarColor = Theme.Amber;
                lblStrength.Text = "Fair"; lblStrength.ForeColor = Theme.Amber;
            }
            else if (score == 4)
            {
                mbStrength.Value = 80; mbStrength.BarColor = Theme.Blue;
                lblStrength.Text = "Good"; lblStrength.ForeColor = Theme.Blue;
            }
            else
            {
                mbStrength.Value = 100; mbStrength.BarColor = Theme.Green;
                lblStrength.Text = "Strong"; lblStrength.ForeColor = Theme.Green;
            }

            // ---- confirm match ----
            string confirm = txtConfirmPassword.Text;
            if (confirm.Length == 0)
            {
                lblMatch.Text = "";
            }
            else if (confirm == pw)
            {
                lblMatch.Text = "\u2713  Passwords match";
                lblMatch.ForeColor = Theme.Green;
            }
            else
            {
                lblMatch.Text = "Passwords do not match";
                lblMatch.ForeColor = Theme.Red;
            }

            // ---- specialisation counter ----
            int picked = chips.Count(c => c.Checked);
            lblSpecCaption.Text = picked == 0
                ? "SPECIALISATIONS  -  choose at least one"
                : "SPECIALISATIONS  -  " + picked + " selected";
            lblSpecCaption.ForeColor = picked == 0 ? Theme.Muted : Theme.Orange;

            // ---- profile strength ----
            string phone = txtPhoneNumber.Text.Trim();
            List<KeyValuePair<bool, string>> steps = new List<KeyValuePair<bool, string>>
            {
                new KeyValuePair<bool, string>(txtFirstName.Text.Trim().Length > 0, "add your first name"),
                new KeyValuePair<bool, string>(txtLastName.Text.Trim().Length > 0, "add your last name"),
                new KeyValuePair<bool, string>(ValidEmail(txtEmail.Text.Trim()), "add a valid email address"),
                new KeyValuePair<bool, string>(phone.Length == 10 && phone.All(char.IsDigit), "add your 10-digit phone number"),
                new KeyValuePair<bool, string>(picked > 0, "choose at least one specialisation"),
                new KeyValuePair<bool, string>(txtServiceArea.Text.Trim().Length > 0, "tell us where you work"),
                new KeyValuePair<bool, string>(pw.Length >= 8 && pw == confirm, "create a matching password")
            };
            int done = steps.Count(s => s.Key);
            int pct = done * 100 / steps.Count;
            lblProfilePct.Text = pct + "%";
            mbProfile.Value = pct;
            mbProfile.BarColor = pct == 100 ? Theme.Green : Theme.Orange;
            string? next = null;
            foreach (KeyValuePair<bool, string> step in steps)
            {
                if (!step.Key) { next = step.Value; break; }
            }
            lblProfileHint.Text = next == null
                ? "All set - you are ready to join HomeHero!"
                : "Next: " + next;
        }

        private static int PasswordScore(string p)
        {
            if (string.IsNullOrEmpty(p)) return 0;
            if (p.Length < 8) return Math.Min(2, 1 + (p.Any(char.IsDigit) ? 1 : 0));

            int s = 1;
            if (p.Length >= 12) s++;
            if (p.Any(char.IsUpper) && p.Any(char.IsLower)) s++;
            if (p.Any(char.IsDigit)) s++;
            if (p.Any(ch => !char.IsLetterOrDigit(ch))) s++;
            return Math.Min(5, s);
        }

        private static bool ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                int at = email.IndexOf('@');
                return addr.Address == email && at > 0 && email.Substring(at).Contains('.') && !email.EndsWith(".");
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // ==================================================================
        //  ACTIONS
        // ==================================================================
        private void btnBack_Click(object? sender, EventArgs e)
        {
            GoToLogin();
        }

        private void GoToLogin(string email = "")
        {
            frmHomeHeroLogin login = new frmHomeHeroLogin(email);
            login.Show();
            this.Hide();
        }

        private void btnSignUpAsHomeowner_Click(object? sender, EventArgs e)
        {
            frmHomeHeroRegistration registration = new frmHomeHeroRegistration();
            registration.Show();
            this.Hide();
        }

        private void btnShowPassword_Click(object? sender, EventArgs e)
        {
            bool reveal = txtPassword.UseSystemPasswordChar;   // currently hidden -> show
            txtPassword.UseSystemPasswordChar = !reveal;
            txtConfirmPassword.UseSystemPasswordChar = !reveal;
            lblShowPasswords.Text = reveal ? "Hide" : "Show";
        }

        private void ShowError(string message, Control? focus)
        {
            lblError.Text = "\u26A0  " + message;
            if (focus != null) focus.Focus();
        }

        private bool registering;

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (registering) return;   // Enter key + button click must never register twice
            registering = true;
            try { RegisterProvider(); }
            finally { registering = false; }
        }

        private void RegisterProvider()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string area = txtServiceArea.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (firstName.Length == 0) { ShowError("Please enter your first name.", txtFirstName); return; }
            if (lastName.Length == 0) { ShowError("Please enter your last name.", txtLastName); return; }
            if (email.Length == 0) { ShowError("Please enter your email address.", txtEmail); return; }
            if (!ValidEmail(email)) { ShowError("That email address does not look valid.", txtEmail); return; }
            if (phone.Length != 10 || !phone.All(char.IsDigit)) { ShowError("Phone number must be exactly 10 digits.", txtPhoneNumber); return; }
            if (!chips.Any(c => c.Checked)) { ShowError("Select at least one specialisation.", null); return; }
            if (area.Length == 0) { ShowError("Please tell us which area you serve.", txtServiceArea); return; }
            if (password.Length < 8) { ShowError("Your password must be at least 8 characters.", txtPassword); return; }
            if (confirm.Length == 0) { ShowError("Please confirm your password.", txtConfirmPassword); return; }
            if (password != confirm) { ShowError("The two passwords do not match.", txtConfirmPassword); return; }

            List<string> specialisations = chips.Where(c => c.Checked).Select(c => c.Text).ToList();

            ServiceProvider provider = new ServiceProvider(firstName, lastName, email, password, phone, area, specialisations);
            if (!AccountDirectory.TryRegisterProvider(provider, out AccountKinds duplicateKinds, out string saveError))
            {
                ShowError(duplicateKinds != AccountKinds.None
                    ? "This email is already registered. Please log in or use another email address."
                    : saveError, txtEmail);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Welcome to HomeHero, " + AdminUi.TitleCase(firstName) + "!\n\nYour service provider account has been created.\nWould you like to log in now?",
                "Account created",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            ClearFields();
            if (result == DialogResult.Yes)
            {
                GoToLogin(email);
            }
        }

        private void ClearFields()
        {
            building = true;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtServiceArea.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            foreach (ChipToggle chip in chips) chip.Checked = false;
            building = false;
            UpdateLiveState();
            txtFirstName.Focus();
        }
    }
}
