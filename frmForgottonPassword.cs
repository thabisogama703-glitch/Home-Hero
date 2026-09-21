using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeHero_2
{
    public partial class frmForgottonPassword : Form
    {
        public frmForgottonPassword()
        {
            InitializeComponent();
        }

        private void btnCreateNewPassword_Click(object sender, EventArgs e)
        {
            string email = txtForgotEmail.Text;
            string selectedUserType = cmbFogotLoginAs.Text;
            string newPassword = txtNewPssword.Text;
            string confirmPassword = txtConfirmNewPassword.Text;
             

            if (string.IsNullOrEmpty(email))
            {
                ValidationError.SetError(txtForgotEmail, "Email is required ");
                 

            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                ValidationError.SetError(txtForgotEmail, "Please enter a valid email");
                 
            }
            else
            {
                ValidationError.SetError(txtForgotEmail, "");

            }

            if (string.IsNullOrEmpty(selectedUserType))
            {
                ValidationError.SetError(cmbFogotLoginAs, "Select account type.");
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                ValidationError.SetError(txtNewPssword , "New password is required.");
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                ValidationError.SetError(txtConfirmNewPassword , "Please confirm your new password.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                ValidationError.SetError(txtConfirmNewPassword , "Passwords do not match.");
                return;
            }

            if (selectedUserType == "Customer")
            {
                CustomerDatabase database = new CustomerDatabase();

                bool passwordUpdated = database.UpdateCustomerPassword(email, newPassword);

                if (passwordUpdated)
                {
                    MessageBox.Show("Password changed successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No customer account was found with that email.");
                }
            }
            else if (selectedUserType == "Service Provider")
            {
                CustomerDatabase database = new CustomerDatabase();

                bool passwordUpdated = database.UpdateServiceProviderPassword(email, newPassword);

                if (passwordUpdated)
                {
                    MessageBox.Show("Password changed successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No service provider account was found with that email.");
                }
            }
            else if (selectedUserType == "Administrator")
            {
                CustomerDatabase database = new CustomerDatabase();

                bool passwordUpdated = database.UpdateAdministratorPassword(email, newPassword);

                if (passwordUpdated)
                {
                    MessageBox.Show("Password changed successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No administrator account was found with that email.");
                }
            }
        }
    }
}
