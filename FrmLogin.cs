namespace HomeHero_2
{
    public partial class frmHomeHeroLogin : Form
    {
        public frmHomeHeroLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHomeHeroRegistration registerForm = new frmHomeHeroRegistration();
            registerForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string selectedUserType = cmbLoginAs.Text;

            if (string.IsNullOrEmpty(selectedUserType))
            {
                ValidationError.SetError(cmbLoginAs , "Please select a user type.");
                return;
            }

            bool hasEmptyFields = false;

            string email = txtEmail.Text;
            string password = txtPassword.Text;




            if (string.IsNullOrEmpty(email))
            {
                ValidationError.SetError(txtEmail, "Email is required");
                hasEmptyFields = true;
            }
            else
            {
                ValidationError.SetError(txtEmail, "");
            }

            if (string.IsNullOrEmpty(password))
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
                ClearFields();
                return;
            }

            if (selectedUserType == "Customer")
            {
                CustomerDatabase database = new CustomerDatabase();

                Customer loggedInCustomer = database.LoginCustomer(email, password);

                if (loggedInCustomer == null)
                {
                    MessageBox.Show("Invalid email or password");
                    ClearFields();
                    return;
                }

                MessageBox.Show("Login successful !");
                ClearFields();
            }
            else if (selectedUserType == "Service Provider")
            {
                CustomerDatabase database = new CustomerDatabase();

                ServiceProvider loggedInProvider =
                    database.LoginServiceProvider(email, password);

                if (loggedInProvider == null)
                {
                    MessageBox.Show("Invalid email or password");
                    ClearFields();
                    return;
                }

                MessageBox.Show("Login successful !");
                ClearFields();
            }
            else if (selectedUserType == "Administrator")
            {
                CustomerDatabase database = new CustomerDatabase();

                Administrator loggedInAdministrator =
                    database.LoginAdministrator(email, password);

                if (loggedInAdministrator == null)
                {
                    MessageBox.Show("Invalid email or password");
                    ClearFields();
                    return;
                }

                MessageBox.Show("Login successful !");
                ClearFields();
            }

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

        private void btnForgottenPassword_Click(object sender, EventArgs e)
        {
            frmForgottonPassword forgotPasswordForm = new frmForgottonPassword();
            forgotPasswordForm.ShowDialog();
        }
    }
}
