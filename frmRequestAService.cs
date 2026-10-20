using HomeHero;
using HomeHero_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    public partial class frmRequestAService : FitForm
    {
        public frmRequestAService()
        {
            InitializeComponent();
            ApplyModernStyle();
            AcceptButton = btnSubmitRequest;
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
            UpdateDescriptionHelper();
        }

        private void pnlServiceRequest_Paint(object sender, PaintEventArgs e)
        {
            // navy gradient header with a soft glow and an orange accent line
            Rectangle all = pnlServiceRequest.ClientRectangle;
            if (all.Width < 10 || all.Height < 10) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var back = new System.Drawing.Drawing2D.LinearGradientBrush(all, Theme.NavyDeep, Theme.NavyLight, 0f))
                g.FillRectangle(back, all);
            using (var back = new System.Drawing.Drawing2D.LinearGradientBrush(all, Color.FromArgb(170, Theme.NavyDeep), Color.FromArgb(110, Theme.NavyLight), 0f))
                g.FillRectangle(back, all);
            using (var glow = new SolidBrush(Color.FromArgb(18, 255, 255, 255)))
            {
                g.FillEllipse(glow, all.Width - 420, -190, 520, 520);
                g.FillEllipse(glow, all.Width - 220, 60, 300, 300);
            }
            Rectangle line = new Rectangle(0, all.Height - 5, all.Width, 5);
            using (var accent = new System.Drawing.Drawing2D.LinearGradientBrush(line, Theme.Orange, Color.FromArgb(255, 176, 96), 0f))
                g.FillRectangle(accent, line);
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

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string emailAddress = txtEmailAddress.Text.Trim().ToLowerInvariant();
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
            else if (!IsValidEmail(emailAddress))
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

            if (!isValid) return;

            string temporaryPassword = CreateTemporaryPassword();
            Customer customer = new Customer(firstName, lastName, emailAddress, cellphoneNumber, temporaryPassword);
            if (!AccountDirectory.TryRegisterCustomer(customer, out AccountKinds duplicateKinds, out string accountError))
            {
                if (duplicateKinds != AccountKinds.None)
                {
                    ValidationError.SetError(txtEmailAddress, "This email address is already registered");
                    MessageBox.Show("This email address is already linked to a HomeHero account. Please log in to submit your request.",
                        "Email already registered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(accountError, "Customer account could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            MaintenanceRequest request = new MaintenanceRequest(
                emailAddress,
                selectedService,
                txtProblemDEscription.Text.Trim(),
                physicalAddress.Trim(),
                dateTimePicker1.Value.Date,
                preferredTime);

            if (!DataManager.AddRequest(request))
            {
                bool rolledBack = AccountDirectory.TryRemoveCustomer(customer, out string rollbackError);
                string message = rolledBack
                    ? "Your request could not be saved, so no customer account was created. Please try again."
                    : "Your request could not be saved. Your customer account may still be active; please contact HomeHero support and quote " + request.RequestNumber + ".\n\n" + rollbackError;
                MessageBox.Show(message, "Request could not be saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!rolledBack)
                {
                    using (CredentialsDialog credentials = new CredentialsDialog(
                        (firstName + " " + lastName).Trim(), emailAddress, temporaryPassword, false, "customer"))
                        credentials.ShowDialog(this);
                }
                return;
            }

            try
            {
                QuickRequest newQuickRequest = new QuickRequest(selectedService, isChecked, txtProblemDEscription.Text,
                    dateTimePicker1, preferredTime, firstName, lastName, emailAddress, cellphoneNumber, physicalAddress);
                newQuickRequest.WriteToFile();
            }
            catch (IOException ex)
            {
                MessageBox.Show("The request is saved, but its legacy quick-request record could not be written.\n\n" + ex.Message,
                    "Request saved with a warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("The request is saved, but HomeHero does not have permission to write its legacy quick-request record.\n\n" + ex.Message,
                    "Request saved with a warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            using (CredentialsDialog credentials = new CredentialsDialog(
                (firstName + " " + lastName).Trim(), emailAddress, temporaryPassword, false, "customer"))
            {
                credentials.ShowDialog(this);
            }
            ClearAllFields();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress address = new System.Net.Mail.MailAddress(email);
                return string.Equals(address.Address, email, StringComparison.OrdinalIgnoreCase)
                    && address.Address.Contains('@')
                    && address.Address.Substring(address.Address.IndexOf('@')).Contains('.');
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static string CreateTemporaryPassword()
        {
            const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789";
            char[] password = new char[12];
            for (int i = 0; i < password.Length; i++)
                password[i] = alphabet[System.Security.Cryptography.RandomNumberGenerator.GetInt32(alphabet.Length)];
            return "HH-" + new string(password);
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
