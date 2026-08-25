using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeHero
{
    public partial class frmHomeHeroLogin : Form
    {
        public frmHomeHeroLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmHomeHeroRegistration registerForm = new frmHomeHeroRegistration();
            registerForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool hasEmptyFields = false;

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email))
            {
                validationError.SetError(txtEmail, "Email is required");
                hasEmptyFields = true;
            }
            else
            {
                validationError.SetError(txtEmail, "");
            }

            if (string.IsNullOrEmpty(password))
            {
                validationError.SetError(txtPassword, "Password is required");
                hasEmptyFields = true;
            }
            else
            {
                validationError.SetError(txtPassword, "");
            }

            if (hasEmptyFields)
            {
                MessageBox.Show("Please fill in all required fields");
                ClearFields();
                return;
            }

             Customer loggedInCustomer = null; // We create a variable to hold the customer if we find one.


            //MessageBox.Show("Number of customers : " + CustomerRepository.Customers.Count);

            foreach (Customer customer in CustomerRepository.Customers) // Go through each customer in our customer list.
            {
                if (customer.Email == email && customer.Password == password) // Does this customer's email match what was entered AND does their password match?
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
