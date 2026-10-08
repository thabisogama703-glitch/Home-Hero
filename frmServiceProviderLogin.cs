using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmServiceProviderLogin : Form
    {
        public frmServiceProviderLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Clear previous errors
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Please enter your name.");
                isValid = false;
            }

            // Surname
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                errorProvider1.SetError(txtSurname, "Please enter your surname.");
                isValid = false;
            }

            // Email
            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
            {
                errorProvider1.SetError(txtEmailAddress, "Please enter your email address.");
                isValid = false;
            }
            else if (!txtEmailAddress.Text.Contains("@"))
            {
                errorProvider1.SetError(txtEmailAddress, "Please enter a valid email address.");
                isValid = false;
            }
            // Phone Number
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errorProvider1.SetError(txtPhoneNumber, "Please enter your phone number.");
                isValid = false;
            }
            // Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Please enter a password.");
                isValid = false;
            }
            // Confirm Password
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Please confirm your password.");
                isValid = false;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
                isValid = false;
            }
            // Business Name
            if (string.IsNullOrWhiteSpace(txtBusinessName.Text))
            {
                errorProvider1.SetError(txtBusinessName, "Please enter your business name.");
                isValid = false;
            }
            // Service Category
            if (string.IsNullOrWhiteSpace(txtServiceCategory.Text))
            {
                errorProvider1.SetError(txtServiceCategory, "Please enter a service category.");
                isValid = false;
            }
            // Service Offered
            if (string.IsNullOrWhiteSpace(txtServiceOffered.Text))
            {
                errorProvider1.SetError(txtServiceOffered, "Please enter the service offered.");
                isValid = false;
            }
            // Years of Experience
            if (nudYearsOfEXperience.Value < 1)
            {
                errorProvider1.SetError(nudYearsOfEXperience, "Years of experience must be at least 1.");
                isValid = false;
            }

            // Service Area
            if (string.IsNullOrWhiteSpace(txtServiceArea.Text))
            {
                errorProvider1.SetError(txtServiceArea, "Please enter your service area.");
                isValid = false;
            }
            // Description
            if (string.IsNullOrWhiteSpace(rtxtDescription.Text))
            {
                errorProvider1.SetError(rtxtDescription, "Please enter a description.");
                isValid = false;
            }

            // Stop if there are errors
            if (!isValid)
            {
                return;
            }
        }
    }
}
