using Home_Hero;
using HomeHero;
using System.Net.Mail;

namespace HomeHero_2
{
    public partial class frmHomeHeroLogin : Form
    {
        public frmHomeHeroLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            bool hasEmptyFields = false;

            if (string.IsNullOrWhiteSpace(email))
            {
                ValidationError.SetError(txtEmail, "Email is required");
                hasEmptyFields = true;
            }
            else
            {
                ValidationError.SetError(txtEmail, "");
            }

            if (string.IsNullOrWhiteSpace(password))
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

            try
            {
                if (!string.Equals(new MailAddress(email).Address, email, StringComparison.OrdinalIgnoreCase))
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                ValidationError.SetError(txtEmail, "Enter a valid email address.");
                MessageBox.Show("Enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Administrator administrator in AppSettings.DefaultAdministrators)
            {
                if (string.Equals(email, administrator.EmailAdress, StringComparison.OrdinalIgnoreCase) &&
                    password == administrator.Password)
                {
                    MessageBox.Show($"Welcome back Mr {administrator.AdminName}", "Admin successfully logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveRememberedEmail(email);
                    frmAdminDashboard adminDashboard = new frmAdminDashboard();
                    this.Hide();
                    adminDashboard.Show();
                    return;
                }
            }

            Customer loggedInCustomer = new Customer("", "", email, "", password);
            if (loggedInCustomer.ReadFromFile(email, password) == "Succesful login")
            {
                MessageBox.Show("Login successful!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveRememberedEmail(email);
                ClearFields();
                frmCustomerDashboard customerForm = new frmCustomerDashboard(email);
                this.Hide();
                customerForm.Show();
                return;
            }

            ServiceProvider? loggedInServiceProvider = CustomerRepository.FindServiceProvider(email, password);
            if (loggedInServiceProvider != null)
            {
                MessageBox.Show("Login successful!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveRememberedEmail(email);
                ClearFields();
                frmServiceProviderDashboard frmService = new frmServiceProviderDashboard(loggedInServiceProvider);
                this.Hide();
                frmService.Show();
                return;
            }

            MessageBox.Show("Invalid email or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearFields();
        }

        private void ClearFields()
        {
            txtEmail.Clear();
            txtPassword.Clear();

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "Hide password";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "Show password";
            }
        }

        private void frmHomeHeroLogin_Load(object sender, EventArgs e)
        {
            string rememberME = AppSettings.GetBaseDirectoryFilePath(AppSettings.RememberMeFileName);
            if (File.Exists(rememberME))
            {
                string data = File.ReadAllText(rememberME);
                string rememberedEmail = data.Split('|')[0].Trim();
                if (!string.IsNullOrWhiteSpace(rememberedEmail))
                {
                    txtEmail.Text = rememberedEmail;
                    chkRemember.Checked = true;
                }

                if (data.Contains('|'))
                {
                    File.WriteAllText(rememberME, rememberedEmail);
                }
            }
        }

        private void SaveRememberedEmail(string email)
        {
            string rememberMeFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.RememberMeFileName);
            if (chkRemember.Checked)
            {
                File.WriteAllText(rememberMeFile, email);
            }
            else if (File.Exists(rememberMeFile))
            {
                File.Delete(rememberMeFile);
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();

            frmHomeHeroRegistration registerForm = new frmHomeHeroRegistration();
            this.Hide();
            registerForm.Show();
        }
    }
}
