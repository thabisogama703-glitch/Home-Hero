using Home_Hero;
using HomeHero;
using MessageBox = System.Windows.Forms.MessageBox;

namespace HomeHero_2
{
    public partial class frmHomeHeroLogin : FitForm
    {
        private readonly string prefillEmail;
        private readonly System.Windows.Forms.Timer hintTimer = new System.Windows.Forms.Timer { Interval = 250 };

        private static readonly Color HintGray = Color.Gray;
        private static readonly Color HintGreen = Color.FromArgb(22, 163, 74);
        private static readonly Color HintBlue = Color.FromArgb(37, 99, 235);
        private static readonly Color HintOrange = Color.FromArgb(255, 128, 0);

        public frmHomeHeroLogin() : this("")
        {
        }

        /// <summary>Opens the login screen with the e-mail already filled in (used right after sign-up).</summary>
        public frmHomeHeroLogin(string prefillEmail)
        {
            this.prefillEmail = (prefillEmail ?? "").Trim();
            InitializeComponent();
            AcceptButton = btnLogin;

            hintTimer.Tick += delegate
            {
                hintTimer.Stop();
                UpdateRoleHint();
            };
        }

        // ==================================================================
        //  LOGIN - no "login as" box: the account type is worked out from the credentials
        // ==================================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            bool hasEmptyFields = false;

            if (email.Length == 0)
            {
                ValidationError.SetError(txtEmail, "Email is required");
                hasEmptyFields = true;
            }
            else
            {
                ValidationError.SetError(txtEmail, "");
            }

            if (password.Length == 0)
            {
                ValidationError.SetError(txtPassword, "Password is required");
                hasEmptyFields = true;
            }
            else
            {
                ValidationError.SetError(txtPassword, "");
            }

            if (hasEmptyFields)
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            // 1) administrator?
            string? adminName = AccountDirectory.CheckAdministrator(email, password);
            if (adminName != null)
            {
                RememberLogin(email, password);
                MessageBox.Show($"Welcome back Mr {adminName}", "Admin succesfully logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                frmAdminDashboard adminDashboard = new frmAdminDashboard();
                this.Hide();
                adminDashboard.Show();
                return;
            }

            // 2) which other accounts accept these credentials?
            ServiceProvider? provider;
            bool isCustomer;
            try
            {
                provider = AccountDirectory.CheckProvider(email, password);
                isCustomer = AccountDirectory.CheckCustomer(email, password);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(
                    "HomeHero could not use the saved account data, so sign-in was stopped. Please restore or repair the account file before trying again.\n\n" + ex.Message,
                    "Sign-in unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    "HomeHero could not read the saved account data, so sign-in was stopped. Please check that the account files are accessible.\n\n" + ex.Message,
                    "Sign-in unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    "HomeHero does not have permission to read the saved account data, so sign-in was stopped.\n\n" + ex.Message,
                    "Sign-in unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (provider == null && !isCustomer)
            {
                MessageBox.Show("Invalid email or password",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // 3) the same e-mail + password exist as BOTH a customer and a provider (rare, old data):
            //    this is the only time we ever ask.
            bool goProvider = provider != null;
            if (provider != null && isCustomer)
            {
                DialogResult choice = MessageBox.Show(
                    "This account is both a Service Provider and a Customer.\n\n" +
                    "Yes  =  open my Service Provider dashboard\n" +
                    "No   =  open my Customer dashboard",
                    "Which dashboard would you like?",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (choice == DialogResult.Cancel) return;
                goProvider = choice == DialogResult.Yes;
            }

            RememberLogin(email, password);

            if (goProvider)
            {
                string first = AdminUi.TitleCase(provider!.FirstName);
                MessageBox.Show(first.Length > 0 ? $"Welcome back, {first}!" : "Login successful!",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                frmServiceProviderDashboard dashboard = new frmServiceProviderDashboard(provider);
                this.Hide();
                dashboard.Show();
            }
            else
            {
                CustomerSession.SignIn(email);
                MessageBox.Show(CustomerSession.Name.Length > 0 ? $"Welcome back, {CustomerSession.Name}!" : "Login successful !",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                frmCustomerDashboard customerForm = new frmCustomerDashboard();
                this.Hide();
                customerForm.Show();
            }
        }

        /// <summary>"Remember me": only saved after a successful login, and cleared when the box is unticked.</summary>
        private void RememberLogin(string email, string password)
        {
            string rememberFile = AppPaths.DataFile("Remember.txt");
            try
            {
                if (chkRemember.Checked)
                    File.WriteAllText(rememberFile, $"{email}|{password}");
                else if (File.Exists(rememberFile))
                    File.Delete(rememberFile);
            }
            catch (IOException)
            {
                // not being able to remember the login must never block the login itself
            }
        }

        private void ClearFields()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }

        // ==================================================================
        //  SMART HINT - shows what we found for the e-mail while the person types
        // ==================================================================
        private void txtEmail_TextChanged(object? sender, EventArgs e)
        {
            hintTimer.Stop();
            hintTimer.Start();
        }

        private void UpdateRoleHint()
        {
            string email = txtEmail.Text.Trim();

            if (email.Length == 0 || !email.Contains('@'))
            {
                SetHint("We'll take you to the right dashboard automatically.", HintGray);
                return;
            }

            AccountKinds kinds = AccountKinds.None;
            try { kinds = AccountDirectory.Detect(email); }
            catch (Exception) { /* a hint must never get in the way of logging in */ }

            bool customer = (kinds & AccountKinds.Customer) != 0;
            bool provider = (kinds & AccountKinds.Provider) != 0;

            if (customer && provider)
                SetHint("✨  Two profiles found - you'll choose which one to open.", HintBlue);
            else if (provider)
                SetHint("\U0001F6E0  Service Provider account found.", HintGreen);
            else if (customer)
                SetHint("\U0001F3E0  Customer account found.", HintGreen);
            else if ((kinds & AccountKinds.Administrator) != 0)
                SetHint("We'll take you to the right dashboard automatically.", HintGray);
            else if (email.Contains('.'))
                SetHint("No account for this email yet - create one below, it takes a minute.", HintOrange);
            else
                SetHint("We'll take you to the right dashboard automatically.", HintGray);
        }

        private void SetHint(string text, Color color)
        {
            lblRoleHint.Text = text;
            lblRoleHint.ForeColor = color;
        }

        // ==================================================================
        //  OTHER BUTTONS
        // ==================================================================
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void frmHomeHeroLogin_Load(object sender, EventArgs e)
        {
            string rememberME = AppPaths.DataFile("Remember.txt");

            if (File.Exists(rememberME))
            {
                string[] dataPaths = File.ReadAllText(rememberME).Split('|');

                if (dataPaths.Length >= 2)
                {
                    txtEmail.Text = dataPaths[0];
                    txtPassword.Text = dataPaths[1];
                    chkRemember.Checked = true;
                }
            }

            // coming straight from sign-up: their new e-mail wins over a remembered one
            if (prefillEmail.Length > 0)
            {
                txtEmail.Text = prefillEmail;
                txtPassword.Clear();
                txtPassword.Focus();
            }

            UpdateRoleHint();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHomeHeroHomepage backtoHome = new frmHomeHeroHomepage();
            this.Hide();
            backtoHome.Show();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
        }

        /// <summary>Sign up as a customer.</summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearFields();
            frmHomeHeroRegistration registerForm = new frmHomeHeroRegistration();
            this.Hide();
            registerForm.Show();
        }

        /// <summary>Sign up as a service provider straight from the login screen.</summary>
        private void btnJoinProvider_Click(object sender, EventArgs e)
        {
            ClearFields();
            frmCreateServiceProvider providerForm = new frmCreateServiceProvider();
            this.Hide();
            providerForm.Show();
        }

    }
}
