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

namespace Home_Hero
{
    public partial class frmCreateServiceProvider : Form
    {
        public frmCreateServiceProvider()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHomeHeroLogin frmHomeHero = new frmHomeHeroLogin();
            frmHomeHero.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHomeHeroRegistration homeHeroRegistration = new frmHomeHeroRegistration();
            homeHeroRegistration.Show();
            this.Hide();
        }

        private void pnlDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkbxLandscaping_CheckedChanged(object sender, EventArgs e)
        {

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
            string serviceArea = txtServiceArea.Text;

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
            List<string> Specialisation = new List<string>();
            bool isChecked = false;
            if (chkbxPlumbing.Checked)
            {
                Specialisation.Add("Plumbing");
                isChecked = true;
            }
            else if (chkbxRoofing.Checked)
            {
                Specialisation.Add("Roofing");
                isChecked = true;
            }
            else if (chkbxWindowsDoors.Checked)
            {
                Specialisation.Add("WindowsDoors");
                isChecked = true;
            }
            else if (chkbxPainting.Checked)
            {
                Specialisation.Add("Painting");
                isChecked = true;
            }
            else if (chkbxLandscaping.Checked)
            {
                Specialisation.Add("Landscaping");
                isChecked = true;
            }
            else if (chkbxHVAC.Checked)
            {
                Specialisation.Add("HVAC");
                isChecked = true;
            }
            else if (chkBxElectrical.Checked)
            {
                Specialisation.Add("Electrical");
                isChecked = true;
            }
            else if (chkbxDeepCleaning.Checked)
            {
                Specialisation.Add("Deep Cleaning");
                isChecked = true;
            }
            if (string.IsNullOrEmpty(serviceArea))
            {
                ValidationError.SetError(txtServiceArea, "Please enter your service area");
                isValid = false;
            }
            else
            {
                ValidationError.SetError(txtServiceArea, "");
            }
            if(isChecked == false)
            {
                ValidationError.SetError(lblSpecialisation,"Kindly select atleast one work you specialize on");
                isValid = false;
            }
            if (!isValid)
            {
                if (hasEmptyFields)
                {
                    MessageBox.Show("Please fill in all required fields.", "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Registration unsuccessful. Please try again. ", "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                return;
            }
            else
            {
                ValidationError.Clear();
                string serviceProvider = "Service.txt";
                ServiceProvider newServiceProvider = new ServiceProvider(name, "", email, password, phoneNumber, serviceArea,Specialisation);
                File.AppendAllText(serviceProvider, $"{name}|{email}|{password}|{phoneNumber}|{serviceArea}|{Specialisation}");
                DialogResult result = MessageBox.Show("Registration successful ! \n Would you like to login right now?", "Account succesfully created", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ClearFields();
                if (result == DialogResult.Yes)
                {
                    frmHomeHeroLogin frmHomeHeroLogin = new frmHomeHeroLogin();
                    this.Hide();
                    frmHomeHeroLogin.Show();
                }
                else
                {

                }
            }
        }
        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtServiceArea.Clear();
            chkbxDeepCleaning.Checked = false;
            chkBxElectrical.Checked = false;
            chkbxHVAC.Checked = false;
            chkbxLandscaping.Checked = false;
            chkbxPainting.Checked = false;
            chkbxPlumbing.Checked = false;
            chkbxRoofing.Checked = false;
            chkbxWindowsDoors.Checked = false;
        }
    }
}
