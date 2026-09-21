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

            if (string.IsNullOrEmpty(selectedUserType))
            {
                Administrator Thabiso = new Administrator();
                Thabiso.AdminName = "Thabiso";
                Thabiso.EmailAdress = "Thabisogama703@gmail.com".ToLower();
                Thabiso.Password = "@Thandolwami07";
                administrators.Add(Thabiso);

                Administrator Sibusiso = new Administrator();
                Sibusiso.AdminName = "Sibusiso";
                Sibusiso.EmailAdress = "shadowsilver308@gmail.com".ToLower();
                Sibusiso.Password = "@Thandolwami07";
                administrators.Add(Sibusiso);


                foreach (Administrator administrator in administrators)
                {
                    if (email.Trim().ToLower() == administrator.EmailAdress)
                    {
                        if (password.Trim() == administrator.Password)
                        {
                            MessageBox.Show($"Welcome back Mr {administrator.AdminName}", "Admin succesfully logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmAdminDashboard adminDashboard = new frmAdminDashboard();
                            this.Hide();
                            adminDashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect credentials", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                MessageBox.Show("Please select a user type.");
                return;
            }

            if (selectedUserType == "Customer")
            {
                Customer loggedInCustomer = null; // We create a variable to hold the customer if we find one.

                foreach (Customer customer in CustomerRepository.Customers) // Go through each customer in our customer list.
                {
                    if (customer.Email.Trim() == email.Trim() && customer.VerifyPassword(password)) // Does this customer's email match what was entered AND does their password match?
                    {
                        loggedInCustomer = customer;
                        break;
                    }
                }

                if (loggedInCustomer == null)
                {
                    MessageBox.Show("Invalid email or password");
                    ClearFields();
                    return;
                }

                MessageBox.Show("Login successful !","Login Successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ClearFields();
                frmCustomerDashboard customerForm = new frmCustomerDashboard();
                this.Hide();
                customerForm.Show();


            }
            else if (selectedUserType == "Service Provider")
            {
                
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
