using Home_Hero;
using HomeHero;

namespace HomeHero_2
{
    public partial class frmHomeHeroLogin : Form
    {
        public frmHomeHeroLogin()
        {
            InitializeComponent();
        }
        List<Administrator> administrators = new List<Administrator>();
        //Administrator Thabiso = new Administrator();
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string selectedUserType = cmbLoginAs.Text;

           
            bool hasEmptyFields = false;

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

            CustomerDatabase adminDatabase = new CustomerDatabase(); ;

            Administrator loggedInAdministrator =
            adminDatabase.LoginAdministrator(email, password);

            if (loggedInAdministrator != null)
            {
                MessageBox.Show("Login successful!", "Administrator Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();

                frmAdminDashboard adminDashboard = new frmAdminDashboard();
                this.Hide();
                adminDashboard.Show();

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
                else
                {
                    MessageBox.Show("Login successful!", "Login Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFields();

                    frmCustomerDashboard customerForm = new frmCustomerDashboard();
                    this.Hide();
                    customerForm.Show();
                }



            }
            else if (selectedUserType == "Service Provider")
            {
                CustomerDatabase database = new CustomerDatabase();

                ServiceProvider loggedInServiceProvider =
                    database.LoginServiceProvider(email, password);

                if (loggedInServiceProvider == null)
                {
                    MessageBox.Show("Invalid email or password");
                    ClearFields();
                    return;
                }
                else
                {
                    MessageBox.Show("Login successful!", "Login Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFields();

                    // Add your Service Provider dashboard here later
                }
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

        private void frmHomeHeroLogin_Load(object sender, EventArgs e)
        {

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
            string users =cmbLoginAs.SelectedIndex.ToString();
            users = "";
            

            frmHomeHeroRegistration registerForm = new frmHomeHeroRegistration();
            this.Hide();
            registerForm.Show();
        }
    }
}
