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
                MessageBox.Show("Please select a user type.");
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

                MessageBox.Show("Login successful !");
                ClearFields();


            }
            else if (selectedUserType == "Service Provider")
            {
                
            }
            else if (selectedUserType == "Administrator")
            {
                
            }

             

            //MessageBox.Show("Number of customers : " + CustomerRepository.Customers.Count);
 
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
    }
}
