using Home_Hero;
using HomeHero;
using System.ComponentModel.DataAnnotations;

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
            string rememberME = "Remember.txt";
            string emilAddress = txtEmail.Text;
            string password1 = txtPassword.Text;

            if (chkRemember.Checked)
            {
                File.WriteAllText(rememberME, $"{emilAddress}|{password1}");
            }
            else
            {

            }
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

            bool adminLoggedIn = false;

            foreach (Administrator administrator in administrators)
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
                string serviceProvider = "Service.txt";

                if (File.Exists(serviceProvider))
                {
                    string[] lines = File.ReadAllLines(serviceProvider);

                    foreach (string line in lines)
                    {
                        string[] data = line.Split('|');

                        if (data.Length >= 6)
                        {
                            string name = data[0];
                            string emailAddress1 = data[1];
                            string passWord1 = data[2];
                            string number = data[3];
                            string serviceArea = data[4];

                            List<string> specialisation = new List<string>();
                            specialisation.Add(data[5]);

                            ServiceProvider loggedinServiceProvider =
                                new ServiceProvider(
                                    name,
                                    "",
                                    emailAddress1,
                                    passWord1,
                                    number,
                                    serviceArea,
                                    specialisation);

                            if (emailAddress1 == email &&
                                passWord1 == password)
                            {
                                MessageBox.Show("Login successful!",
                                    "Login Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                frmServiceProviderDashboard frmService =
                                    new frmServiceProviderDashboard(loggedinServiceProvider);

                                this.Hide();
                                frmService.Show();

                                return; // Stop checking once found
                            }
                        }
                    }

                    MessageBox.Show("Invalid credentials",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
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
            string rememberME = "Remember.txt";
            string emilAddress = txtEmail.Text;
            string password = txtPassword.Text;

            //if (chkRemember.Checked)
            //{
            //    File.WriteAllText(rememberME, $"{emilAddress}|{password}");
            //}
            //else
            //{

            //}
            if (File.Exists(rememberME))
            {
                string data = File.ReadAllText(rememberME);

                string[] dataPaths = data.Split("|");

                foreach (string file in dataPaths)
                {
                    txtEmail.Text = dataPaths[0];
                    txtPassword.Text = dataPaths[1];
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
            string users =cmbLoginAs.SelectedIndex.ToString();
            users = "";
            

            frmHomeHeroRegistration registerForm = new frmHomeHeroRegistration();
            this.Hide();
            registerForm.Show();
        }
    }
}
