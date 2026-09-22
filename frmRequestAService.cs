using HomeHero;
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
    public partial class frmRequestAService : Form
    {
        public frmRequestAService()
        {
            InitializeComponent();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            frmHomeHeroHomepage homePage = new frmHomeHeroHomepage();
            this.Close();
            homePage.Show();


        }

        private void btnCustomerDashboard_Click(object sender, EventArgs e)
        {
            frmCustomerDashboard Customerdashboard = new frmCustomerDashboard();
            this.Hide();
            Customerdashboard.Show();
        }

        private void frmRequestAService_Load(object sender, EventArgs e)
        {
            string selectedService = cbxServices.Text;
            string problemDescription = txtProblemDEscription.Text;
            int remainingCharacters = 20;
            int descriptionChars = problemDescription.Count();

            if (descriptionChars! > 20)
            {
                remainingCharacters = remainingCharacters - descriptionChars;
            }
            else
            {

            }
            lblMinimumCharacters.Text = $"{descriptionChars} chars ({remainingCharacters} more needed)";
        }

        private void pnlServiceRequest_Paint(object sender, PaintEventArgs e)
        {

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtPropertyAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            //Validating the service choice and priority level

            string selectedService = cbxServices.Text;
            if (string.IsNullOrEmpty(selectedService))
            {
                ValidationError.SetError(cbxServices, "Select atleast one service you need");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(cbxServices, "");
            }

            if (!RdbxNormalPriorityLevel.Checked && !RdbtnUrgent.Checked)
            {
                ValidationError.SetError(lblPriorityLevel, "Select atleast one priority level for your service request.");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(lblPriorityLevel, "");
            }
            bool isChecked = false;
            if (RdbtnUrgent.Checked)
            {
                isChecked = true;
            }
            else
            {
                isChecked = false;
            }

            //Validating section 2 (Problem description)
            int problemDescription = txtProblemDEscription.Text.Length;

            if (problemDescription < 20)
            {
                ValidationError.SetError(txtProblemDEscription, "Please provide with a clear description of the problem with atleast 20 characters in your description");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtProblemDEscription, "");
            }

            //Validating section 3 (Preferred Date and Time)
            string preferredTime = cbxPreferredTime.Text;

            if (string.IsNullOrEmpty(preferredTime))
            {
                ValidationError.SetError(cbxPreferredTime, "Kindly select your preferred time to continue");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(cbxPreferredTime, "");
            }

            //Validating the last section (4. Your information)

            string firstName = txtFirstName.Text.Trim().ToLower();
            string lastName = txtLastName.Text.Trim().ToLower();
            string emailAddress = txtEmailAddress.Text.Trim().ToLower();
            string cellphoneNumber = txtPhoneNumber.Text.Trim();

            //First name validation
            if (string.IsNullOrEmpty(firstName))
            {
                ValidationError.SetError(txtFirstName, "Kindly provide with your first name to proceed");
                isValid = false;
            }
            else if (firstName.Length <= 3)
            {
                ValidationError.SetError(txtFirstName, "Invalid, First name should be atleast 3 characters long");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtFirstName, "");
            }

            //Last name validation
            if (string.IsNullOrEmpty(lastName))
            {
                ValidationError.SetError(txtLastName, "Kindly provide with your last name to proceed");
                isValid = false;
            }
            else if (lastName.Length <= 3)
            {
                ValidationError.SetError(txtLastName, "Invalid, Last name should be atleast 3 characters long");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtLastName, "");
            }

            //Email address validation
            if (string.IsNullOrEmpty(emailAddress))
            {
                ValidationError.SetError(txtEmailAddress, "Kindly provide with your email address to proceed");
                isValid = false;
            }
            else if (!emailAddress.Contains("@"))
            {
                ValidationError.SetError(txtEmailAddress, "Email address is not valid");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtEmailAddress, "");
            }

            //Phone number validation
            if (string.IsNullOrEmpty(cellphoneNumber))
            {
                ValidationError.SetError(txtPhoneNumber, "Please provide with your cellphone number");
                isValid = false;
            }
            else
            {
                foreach (char cellNumChar in cellphoneNumber)
                {
                    if (!char.IsDigit(cellNumChar))
                    {
                        ValidationError.SetError(txtPhoneNumber, "Enter only digits/numbers for a phone number");
                        isValid = false;
                    }
                    else if (cellphoneNumber.Length != 10)
                    {
                        ValidationError.SetError(txtPhoneNumber, "Phone number should be exactly 10 digits");
                        isValid = false;
                    }
                    else
                    {
                        ValidationError.SetError(txtPhoneNumber, "");
                    }
                }
            }

            //Validating the property address
            string physicalAddress = txtPropertyAddress.Text;
            if (string.IsNullOrEmpty(physicalAddress))
            {
                ValidationError.SetError(txtPropertyAddress, "Please provide with the property address");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtPropertyAddress, "");
            }

            /*After all validations we then show the process was succesfully submitted*/
            if (isValid == true)
            {
                QuickRequest newQuickRequest = new QuickRequest(selectedService, isChecked, txtProblemDEscription.Text, dateTimePicker1, preferredTime, firstName, lastName, emailAddress, cellphoneNumber, physicalAddress);
                newQuickRequest.WriteToFile();
                MessageBox.Show("Maintenance Request succesfully submitted ");
                ClearAllFields();
            }
            else
            {
                return;
            }


        }

        public void ClearAllFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            txtProblemDEscription.Clear();
            txtPropertyAddress.Clear();
            txtEmailAddress.Clear();
            cbxServices.Text = null;
            RdbtnUrgent.Checked = false;
            RdbxNormalPriorityLevel.Checked = false;
            cbxPreferredTime.SelectedItem = null;

        }


        private void btnCancelReuest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                frmHomeHeroHomepage frm = new frmHomeHeroHomepage();
                this.Hide();
                frm.Show();
            }
        }
    }
}
