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
        List<Administrator1> administrators = new List<Administrator1>();
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
            Administrator1 Thabiso = new Administrator1();
            Thabiso.AdminName = "Thabiso";
            Thabiso.EmailAdress = "Thabisogama703@gmail.com".ToLower();
            Thabiso.Password = "@Thandolwami07";
            administrators.Add(Thabiso);

            Administrator1 Sibusiso = new Administrator1();
            Sibusiso.AdminName = "Sibusiso";
            Sibusiso.EmailAdress = "shadowsilver308@gmail.com".ToLower();
            Sibusiso.Password = "@Thandolwami07";
            administrators.Add(Sibusiso);

            bool adminLoggedIn = false;

            foreach (Administrator1 administrator in administrators)
            {
                if (email.Trim().ToLower() == administrator.EmailAdress)
                {
                    if (password.Trim() == administrator.Password)
                    {
                        adminLoggedIn = true;
                        MessageBox.Show($"Welcome back Mr {administrator.AdminName}", "Admin succesfully logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmAdminDashboard adminDashboard = new frmAdminDashboard();
                        this.Hide();
                        adminDashboard.Show();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect credentials", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (string.IsNullOrEmpty(selectedUserType) && adminLoggedIn == false)
            {
                MessageBox.Show("Please select a user type.");
                return;
            }

            if (selectedUserType == "Customer")
            {

                Customer loggedInCustomer = new Customer("","",email,"",password); // We create a variable to hold the customer if we find one.
                string message = loggedInCustomer.ReadFromFile(email, password);

                if (message == "Unsuccesful login")
                {
                    MessageBox.Show("Invalid email or password");
                    ClearFields();
                    return;
                }
                else
                {
                    MessageBox.Show("Login successful !", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    frmCustomerDashboard customerForm = new frmCustomerDashboard();
                    this.Hide();
                    customerForm.Show();
                }

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
