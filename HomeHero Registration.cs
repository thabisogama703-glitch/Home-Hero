using Home_Hero;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace HomeHero_2
{
    public partial class frmHomeHeroRegistration : FitForm
    {
        private Label lblError = null!;
        private Label lblStrength = null!;
        private Label lblMatch = null!;
        private Label lblShowPasswords = null!;
        private Label lblProfilePct = null!;
        private Label lblProfileHint = null!;
        private MeterBar mbStrength = null!;
        private MeterBar mbProfile = null!;
        private Panel host = null!;
        private CardPanel card = null!;
        private ModernButton btnCreate = null!;
        private bool building = true;
        private bool registering;

        public frmHomeHeroRegistration()
        {
            InitializeComponent();
            ScrollWholeForm = false;
            BuildUi();
        }

        private void BuildUi()
        {
            SuspendLayout();
            AdminUi.UseDpiScaling(this);
            Controls.Clear();

            Text = "HomeHero | Create a Customer Account";
            BackColor = Theme.Bg;
            Font = Theme.MakeFont(9F);
            MinimumSize = new Size(900, 700);
            WindowState = FormWindowState.Maximized;

            Controls.Add(BuildFormSide());
            Controls.Add(BuildBrandSide());
            AcceptButton = btnCreate;
            ActiveControl = txtName;

            building = false;
            ResumeLayout(true);
            CenterCard();
            UpdateLiveState();
            Load += delegate { CenterCard(); };
            Resize += delegate { CenterCard(); };
        }

        private Control BuildBrandSide()
        {
            GradientPanel panel = new GradientPanel();
            panel.Dock = DockStyle.Left;
            panel.Width = 480;

            FlowLayoutPanel brand = new FlowLayoutPanel();
            brand.BackColor = Color.Transparent;
            brand.AutoSize = true;
            brand.WrapContents = false;
            brand.FlowDirection = FlowDirection.LeftToRight;
            brand.Location = new Point(42, 34);

            PictureBox logo = new PictureBox();
            logo.Image = Home_Hero.Properties.Resources.Screenshot_2026_09_05_180629;
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
            panel.Controls.Add(brand);

            Label kicker = Theme.MakeLabel("FOR HOMEOWNERS", 9F, FontStyle.Bold, Theme.Orange);
            kicker.Location = new Point(44, 142);
            panel.Controls.Add(kicker);

            Label headline = Theme.MakeLabel("Home care,\ndone right.", 29F, FontStyle.Bold, Color.White);
            headline.AutoSize = false;
            headline.Size = new Size(400, 104);
            headline.Location = new Point(42, 168);
            panel.Controls.Add(headline);

            Label sub = Theme.MakeLabel(
                "Create one account to request trusted home maintenance and follow every job from start to finish.",
                11F, FontStyle.Regular, Color.FromArgb(218, 226, 240));
            sub.AutoSize = false;
            sub.Size = new Size(390, 66);
            sub.Location = new Point(44, 278);
            panel.Controls.Add(sub);

            panel.Controls.Add(Benefit("One simple account", "Keep your contact details and requests together.", 376));
            panel.Controls.Add(Benefit("Trusted professionals", "Connect with verified service providers.", 434));
            panel.Controls.Add(Benefit("Stay in the loop", "Track approvals, appointments and completed jobs.", 492));

            SoftBox profile = new SoftBox();
            profile.FillColor = Color.FromArgb(34, 255, 255, 255);
            profile.BorderColor = Color.FromArgb(70, 255, 255, 255);
            profile.Radius = 14;
            profile.Size = new Size(392, 126);
            profile.Location = new Point(42, 600);

            Label cap = Theme.MakeLabel("ACCOUNT COMPLETION", 8.5F, FontStyle.Bold, Color.FromArgb(205, 216, 236));
            cap.Location = new Point(18, 12);
            lblProfilePct = Theme.MakeLabel("0%", 20F, FontStyle.Bold, Color.White);
            lblProfilePct.Location = new Point(16, 30);
            mbProfile = new MeterBar();
            mbProfile.Size = new Size(352, 9);
            mbProfile.Location = new Point(18, 76);
            mbProfile.BarColor = Theme.Orange;
            lblProfileHint = Theme.MakeLabel("Next: add your name", 9F, FontStyle.Regular, Color.FromArgb(205, 216, 236));
            lblProfileHint.Location = new Point(18, 95);
            profile.Controls.Add(cap);
            profile.Controls.Add(lblProfilePct);
            profile.Controls.Add(mbProfile);
            profile.Controls.Add(lblProfileHint);
            panel.Controls.Add(profile);

            panel.Resize += delegate
            {
                profile.Top = Math.Max(panel.ClientSize.Height - profile.Height - 34, 0);
            };
            return panel;
        }

        private Control Benefit(string title, string description, int y)
        {
            Panel row = new Panel();
            row.BackColor = Color.Transparent;
            row.Size = new Size(400, 48);
            row.Location = new Point(42, y);

            Label check = Theme.MakeLabel("\u2713", 12F, FontStyle.Bold, Theme.Orange);
            check.Size = new Size(28, 28);
            check.Location = new Point(0, 0);
            Label heading = Theme.MakeLabel(title, 10.5F, FontStyle.Bold, Color.White);
            heading.Location = new Point(38, 0);
            Label body = Theme.MakeLabel(description, 9F, FontStyle.Regular, Color.FromArgb(205, 216, 236));
            body.Location = new Point(38, 22);
            row.Controls.Add(check);
            row.Controls.Add(heading);
            row.Controls.Add(body);
            return row;
        }

        private Control BuildFormSide()
        {
            Panel side = new Panel();
            side.Dock = DockStyle.Fill;
            side.BackColor = Theme.Bg;

            Panel bar = new Panel();
            bar.Dock = DockStyle.Top;
            bar.Height = 76;
            bar.BackColor = Theme.Bg;

            ModernButton back = MakeButton("\u2190  Back to login", 170, 42, true, Theme.Navy);
            back.Location = new Point(30, 17);
            back.Click += btnBack_Click;

            FlowLayoutPanel right = new FlowLayoutPanel();
            right.Dock = DockStyle.Right;
            right.AutoSize = true;
            right.WrapContents = false;
            right.FlowDirection = FlowDirection.LeftToRight;
            right.BackColor = Color.Transparent;
            right.Padding = new Padding(0, 17, 30, 0);
            Label ask = Theme.MakeLabel("Want to work with us?", 9.5F, FontStyle.Regular, Theme.Muted);
            ask.Margin = new Padding(0, 11, 12, 0);
            ModernButton provider = MakeButton("Become a Home Hero", 190, 42, true, Theme.Orange);
            provider.Click += btnCreateasAServiceProvider_Click;
            right.Controls.Add(ask);
            right.Controls.Add(provider);
            bar.Controls.Add(back);
            bar.Controls.Add(right);

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
            CardPanel content = new CardPanel();
            content.FillColor = Color.White;
            content.Padding = new Padding(34, 24, 34, 24);
            content.Size = new Size(650, 690);

            const int left = 34;
            const int width = 582;
            const int column = 278;
            const int rightColumn = left + column + 26;

            Label title = Theme.MakeLabel("Create your account", 22F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(left - 2, 24);
            Label subtitle = Theme.MakeLabel("A few details are all you need to get started.", 10F, FontStyle.Regular, Theme.Muted);
            subtitle.Location = new Point(left, 66);
            content.Controls.Add(title);
            content.Controls.Add(subtitle);

            Section(content, "Personal details", left, 104, width);
            Field(content, "Full name", txtName, "e.g. Sandra Mokoena", left, 142, width);
            Field(content, "Email address", txtEmail, "you@email.com", left, 222, width);
            Field(content, "Phone number", txtPhoneNumber, "10 digits, e.g. 0821234567", left, 302, width);
            txtPhoneNumber.MaxLength = 10;
            txtPhoneNumber.KeyPress += delegate (object? sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            Section(content, "Security", left, 386, width);
            Field(content, "Password", txtPassword, "At least 8 characters", left, 424, column);
            Field(content, "Confirm password", txtConfirmPassword, "Repeat your password", rightColumn, 424, column);
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            lblShowPasswords = Theme.MakeLabel("Show", 9F, FontStyle.Bold, Theme.Orange);
            lblShowPasswords.Cursor = Cursors.Hand;
            lblShowPasswords.Location = new Point(left + column - 38, 424);
            lblShowPasswords.Click += btnShowPassword_Click;
            content.Controls.Add(lblShowPasswords);

            mbStrength = new MeterBar();
            mbStrength.Size = new Size(164, 8);
            mbStrength.Location = new Point(left + 2, 506);
            mbStrength.BarColor = Theme.Border;
            content.Controls.Add(mbStrength);
            lblStrength = Theme.MakeLabel("", 8.5F, FontStyle.Bold, Theme.Muted);
            lblStrength.Location = new Point(left + 176, 499);
            content.Controls.Add(lblStrength);
            lblMatch = Theme.MakeLabel("", 8.5F, FontStyle.Bold, Theme.Muted);
            lblMatch.Location = new Point(rightColumn + 2, 499);
            content.Controls.Add(lblMatch);

            lblError = Theme.MakeLabel("", 9.5F, FontStyle.Bold, Theme.Red);
            lblError.AutoSize = false;
            lblError.AutoEllipsis = true;
            lblError.Size = new Size(width, 28);
            lblError.Location = new Point(left, 538);
            content.Controls.Add(lblError);

            btnCreate = new ModernButton();
            btnCreate.Text = "Create Customer Account";
            btnCreate.Font = Theme.MakeSemibold(11F);
            btnCreate.Size = new Size(width, 50);
            btnCreate.Location = new Point(left, 572);
            btnCreate.Click += btnRegister_Click;
            content.Controls.Add(btnCreate);

            LinkLabel signIn = new LinkLabel();
            signIn.Text = "Already have an account?  Log in";
            signIn.AutoSize = false;
            signIn.Size = new Size(width, 24);
            signIn.Location = new Point(left, 634);
            signIn.TextAlign = ContentAlignment.MiddleCenter;
            signIn.Font = Theme.MakeFont(9.5F);
            signIn.ForeColor = Theme.Muted;
            signIn.LinkColor = Theme.Orange;
            signIn.ActiveLinkColor = Theme.OrangeHover;
            signIn.VisitedLinkColor = Theme.Orange;
            signIn.LinkBehavior = LinkBehavior.HoverUnderline;
            signIn.BackColor = Color.Transparent;
            signIn.LinkArea = new LinkArea(signIn.Text.IndexOf("Log in", StringComparison.Ordinal), 6);
            signIn.LinkClicked += delegate { GoToLogin(); };
            content.Controls.Add(signIn);
            return content;
        }

        private void Section(Control parent, string text, int x, int y, int width)
        {
            Label caption = Theme.MakeLabel(text.ToUpperInvariant(), 9F, FontStyle.Bold, Theme.Orange);
            caption.Location = new Point(x + 2, y);
            Panel line = new Panel();
            line.BackColor = Theme.Border;
            line.Size = new Size(width, 1);
            line.Location = new Point(x, y + 24);
            parent.Controls.Add(caption);
            parent.Controls.Add(line);
        }

        private void Field(Control parent, string caption, TextBox input, string placeholder, int x, int y, int width)
        {
            Label label = Theme.MakeLabel(caption.ToUpperInvariant(), 8.5F, FontStyle.Bold, Theme.Muted);
            label.Location = new Point(x + 2, y);
            input.PlaceholderText = placeholder;
            InputFrame frame = AdminUi.Frame(input, width, 46);
            frame.Location = new Point(x, y + 22);
            input.TextChanged += OnFieldChanged;
            parent.Controls.Add(label);
            parent.Controls.Add(frame);
        }

        private static ModernButton MakeButton(string text, int width, int height, bool outline, Color color)
        {
            ModernButton button = new ModernButton();
            button.Text = text;
            button.Size = new Size(width, height);
            button.Outline = outline;
            button.BaseColor = color;
            return button;
        }

        private void CenterCard()
        {
            if (host == null || card == null) return;
            int x = Math.Max(0, (host.ClientSize.Width - card.Width) / 2);
            int y = Math.Max(8, (host.ClientSize.Height - card.Height) / 2);
            card.Location = new Point(x, y);
        }

        private void OnFieldChanged(object? sender, EventArgs e)
        {
            if (!building) UpdateLiveState();
        }

        private void UpdateLiveState()
        {
            lblError.Text = "";

            string password = txtPassword.Text;
            int score = PasswordScore(password);
            if (password.Length == 0)
            {
                mbStrength.Value = 0;
                lblStrength.Text = "";
            }
            else if (score <= 2)
            {
                mbStrength.Value = 30;
                mbStrength.BarColor = Theme.Red;
                lblStrength.Text = "Weak";
                lblStrength.ForeColor = Theme.Red;
            }
            else if (score == 3)
            {
                mbStrength.Value = 55;
                mbStrength.BarColor = Theme.Amber;
                lblStrength.Text = "Fair";
                lblStrength.ForeColor = Theme.Amber;
            }
            else if (score == 4)
            {
                mbStrength.Value = 80;
                mbStrength.BarColor = Theme.Blue;
                lblStrength.Text = "Good";
                lblStrength.ForeColor = Theme.Blue;
            }
            else
            {
                mbStrength.Value = 100;
                mbStrength.BarColor = Theme.Green;
                lblStrength.Text = "Strong";
                lblStrength.ForeColor = Theme.Green;
            }

            string confirm = txtConfirmPassword.Text;
            if (confirm.Length == 0) lblMatch.Text = "";
            else if (confirm == password)
            {
                lblMatch.Text = "\u2713  Passwords match";
                lblMatch.ForeColor = Theme.Green;
            }
            else
            {
                lblMatch.Text = "Passwords do not match";
                lblMatch.ForeColor = Theme.Red;
            }

            string phone = txtPhoneNumber.Text.Trim();
            bool[] checks =
            {
                txtName.Text.Trim().Length > 0,
                ValidEmail(txtEmail.Text.Trim()),
                phone.Length == 10 && phone.All(char.IsDigit),
                password.Length >= 8 && password == confirm
            };
            int done = checks.Count(valid => valid);
            int percentage = done * 100 / checks.Length;
            lblProfilePct.Text = percentage + "%";
            mbProfile.Value = percentage;
            mbProfile.BarColor = percentage == 100 ? Theme.Green : Theme.Orange;
            string[] nextSteps = { "add your name", "add a valid email address", "add your 10-digit phone number", "create a matching password" };
            int next = Array.FindIndex(checks, valid => !valid);
            lblProfileHint.Text = next < 0 ? "All set - you are ready to join HomeHero!" : "Next: " + nextSteps[next];
        }

        private static int PasswordScore(string password)
        {
            if (string.IsNullOrEmpty(password)) return 0;
            if (password.Length < 8) return Math.Min(2, 1 + (password.Any(char.IsDigit) ? 1 : 0));
            int score = 1;
            if (password.Length >= 12) score++;
            if (password.Any(char.IsUpper) && password.Any(char.IsLower)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) score++;
            return Math.Min(5, score);
        }

        private static bool ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                MailAddress address = new MailAddress(email);
                int at = email.IndexOf('@');
                return address.Address == email && at > 0 && email.Substring(at).Contains('.') && !email.EndsWith(".");
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void ShowError(string message, Control? focus)
        {
            lblError.Text = "\u26A0  " + message;
            if (focus != null) focus.Focus();
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (registering) return;
            registering = true;
            btnCreate.Enabled = false;
            try
            {
                RegisterCustomer();
            }
            finally
            {
                registering = false;
                if (!IsDisposed) btnCreate.Enabled = true;
            }
        }

        private void RegisterCustomer()
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (name.Length == 0) { ShowError("Please enter your full name.", txtName); return; }
            if (email.Length == 0) { ShowError("Please enter your email address.", txtEmail); return; }
            if (!ValidEmail(email)) { ShowError("That email address does not look valid.", txtEmail); return; }
            if (phone.Length != 10 || !phone.All(char.IsDigit)) { ShowError("Phone number must be exactly 10 digits.", txtPhoneNumber); return; }
            if (password.Length < 8) { ShowError("Your password must be at least 8 characters.", txtPassword); return; }
            if (confirm.Length == 0) { ShowError("Please confirm your password.", txtConfirmPassword); return; }
            if (password != confirm) { ShowError("The two passwords do not match.", txtConfirmPassword); return; }

            Customer customer = new Customer(name, "", email, phone, password);
            bool saved;
            AccountKinds duplicateKinds;
            string saveError;
            try
            {
                saved = AccountDirectory.TryRegisterCustomer(customer, out duplicateKinds, out saveError);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is InvalidDataException)
            {
                ShowError("The account could not be checked or saved. " + ex.Message, txtEmail);
                return;
            }

            if (!saved)
            {
                ShowError(duplicateKinds != AccountKinds.None
                    ? "This email is already registered. Please log in or use another email address."
                    : saveError, txtEmail);
                return;
            }

            DialogResult result = MessageBox.Show(
                this,
                "Welcome to HomeHero, " + name + "!\r\n\r\nYour customer account has been created. Would you like to log in now?",
                "Account created",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            ClearFields();
            if (result == DialogResult.Yes) GoToLogin(email);
        }

        private void ClearFields()
        {
            building = true;
            txtName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            ValidationError.Clear();
            building = false;
            UpdateLiveState();
            txtName.Focus();
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            GoToLogin();
        }

        private void GoToLogin(string email = "")
        {
            frmHomeHeroLogin login = new frmHomeHeroLogin(email);
            login.Show();
            Hide();
        }

        private void btnShowPassword_Click(object? sender, EventArgs e)
        {
            bool reveal = txtPassword.UseSystemPasswordChar;
            txtPassword.UseSystemPasswordChar = !reveal;
            txtConfirmPassword.UseSystemPasswordChar = !reveal;
            lblShowPasswords.Text = reveal ? "Hide" : "Show";
        }

        private void btnShowConfirmPassword_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
        }

        private void frmHomeHeroRegistration_Load(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void btnCreateasAServiceProvider_Click(object? sender, EventArgs e)
        {
            frmCreateServiceProvider providerRegistration = new frmCreateServiceProvider();
            providerRegistration.Show();
            Hide();
        }
    }
}
