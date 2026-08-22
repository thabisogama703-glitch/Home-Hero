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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email))
            {
                validationError.SetError(txtEmail, "Email is required");
            }
            else
            {
                validationError.SetError(txtEmail, "");
            }

            if (string.IsNullOrEmpty(password))
            {
                validationError.SetError(txtPassword, password);
            }
            else
            {
                validationError.SetError(txtPassword, "");
            }

             Customer loggedInCustomer = null; // We create a variable to hold the customer if we find one.


            MessageBox.Show("Number of customers : " + CustomerRepository.Customers.Count);
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
                return;
            }

            MessageBox.Show("Login successful !");
        }
    }
}
