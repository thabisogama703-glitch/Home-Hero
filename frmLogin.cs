using Home_Hero;
using HomeHero;
using Krypton.Toolkit;

namespace HomeHero_2
{
    public partial class frmHomeHeroLogin : Form
    {
        public frmHomeHeroLogin()
        {
            InitializeComponent();
            StyleButton(btnLogin, Color.FromArgb(255, 128, 0), Color.White);
            StyleButton(btnShowPassword, Color.FromArgb(240, 240, 240), Color.FromArgb(17, 17, 17));
            StyleButton(btnBack, Color.FromArgb(0, 0, 64), Color.White);
            StyleButton(button1, Color.WhiteSmoke, Color.FromArgb(255, 128, 0));
            StyleTextBox(txtEmail);
            StyleTextBox(txtPassword);
        }

        private static void StyleButton(KryptonButton button, Color backgroundColor, Color foregroundColor)
        {
            button.StateCommon.Back.Color1 = backgroundColor;
            button.StateCommon.Back.Color2 = backgroundColor;
            button.StateCommon.Content.ShortText.Color1 = foregroundColor;
            button.StateCommon.Border.Rounding = 8;
        }

        private static void StyleTextBox(KryptonTextBox textBox)
        {
            textBox.StateCommon.Back.Color1 = Color.White;
            textBox.StateCommon.Border.Color1 = Color.FromArgb(206, 212, 218);
            textBox.StateCommon.Border.Rounding = 10;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
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

            if (chkRemember.Checked)
            {
                string rememberMe = AppSettings.GetBaseDirectoryFilePath(AppSettings.RememberMeFileName);
                File.WriteAllText(rememberMe, $"{email}|{password}");
            }

            foreach (Administrator administrator in AppSettings.DefaultAdministrators)
            {
                if (string.Equals(email, administrator.EmailAdress, StringComparison.OrdinalIgnoreCase) &&
                    password == administrator.Password)
                {
                    MessageBox.Show($"Welcome back Mr {administrator.AdminName}", "Admin successfully logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void frmHomeHeroLogin_Load(object sender, EventArgs e)
        {
            string rememberME = AppSettings.GetBaseDirectoryFilePath(AppSettings.RememberMeFileName);
            if (File.Exists(rememberME))
            {
                string data = File.ReadAllText(rememberME);
                string[] dataPaths = data.Split("|");
                if (dataPaths.Length >= 2)
                {
                    txtEmail.Text = dataPaths[0];
                    txtPassword.Text = dataPaths[1];
                    chkRemember.Checked = true;
                }
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
