using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;


namespace HomeHero
{
    public partial class frmHomeHeroRegistration : Form
    {
        public frmHomeHeroRegistration()
        {
            InitializeComponent();
        }

        
 

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            string name = txtName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            

            if (string.IsNullOrEmpty(name))
            {
                ValidationError.SetError(txtName, "Name is required");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtName, "");
            }

            if (string.IsNullOrEmpty(email))
            {
                ValidationError.SetError(txtEmail, "Email is required ");
                isValid = false;

            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                ValidationError.SetError(txtEmail, "Please enter a valid email");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtEmail, "");

            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                ValidationError.SetError(txtPhoneNumber, "Phone number is required.");
                isValid = false;
            }
            else if (phoneNumber.Length != 10)
            {
                ValidationError.SetError(txtPhoneNumber, "Phone number must exactly be 10 digits");
                isValid = false;
            }
            else if (!phoneNumber.All(char.IsDigit))
            {
                ValidationError.SetError(txtPhoneNumber, "Phone number must contain dogits only.");
                isValid = false;
            }
             
            else
            {
                ValidationError.SetError(txtPhoneNumber, "");
            }

            if (string.IsNullOrEmpty(password))
            {
                ValidationError.SetError(txtPassword, "Password is required.");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtPassword, "");
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                ValidationError.SetError(txtConfirmPassword, "Please confirm your password.");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                ValidationError.SetError(txtConfirmPassword, "");
            }
            else if (password != confirmPassword)
            {
                ValidationError.SetError(txtConfirmPassword, "Passwords do not match.");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtConfirmPassword, "");
            }

            if (!isValid)
            {
                return;
            }

            Customer customer = new Customer
            {
                // It takes the information the customer entered and creats a customer object
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password
            };
            CustomerRepository.Customers.Add(customer); // we are putting a new customer to the list we created

            
            MessageBox.Show("Registration successful !");
        }
    }
}
