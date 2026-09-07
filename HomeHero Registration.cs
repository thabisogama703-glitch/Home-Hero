using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeHero_2
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
            bool hasEmptyFields = false;

            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();


            if (string.IsNullOrEmpty(name))
            {
                ValidationError.SetError(txtName, "Name is required");
                isValid = false;
                hasEmptyFields = true;
            }
            else
            {
                ValidationError.SetError(txtName, "");
            }

            if (string.IsNullOrEmpty(email))
            {
                ValidationError.SetError(txtEmail, "Email is required ");
                isValid = false;
                hasEmptyFields = true;

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
                hasEmptyFields = true;
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
                hasEmptyFields = true;
            }
            else
            {
                ValidationError.SetError(txtPassword, "");
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                ValidationError.SetError(txtConfirmPassword, "Please confirm your password.");
                isValid = false;
                hasEmptyFields = true;
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
                if (hasEmptyFields)
                {
                    MessageBox.Show("Please fill in all required fields.");

                }
                else
                {
                    MessageBox.Show("Registration unsuccessful. Please try again. ");

                }

                return;
            }

            Customer customer = new Customer(
             name,
             "",
             phoneNumber,
             email,
             password);

           CustomerRepository.Customers.Add(customer); // we are putting a new customer to the list we created


            MessageBox.Show("Registration successful !");
            ClearFields();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
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

        private void btnShowConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.UseSystemPasswordChar)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
