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
    public partial class AddProvider : Form
    {
        public AddProvider()
        {
            InitializeComponent();
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string location = txtSeaviceArea.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (email.Contains("@") == false || email.Contains(".") == false)
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (phone.Length != 10 || !long.TryParse(phone, out _))
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkSpecialization.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one specialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            List<string> specialisations = new List<string>();
            foreach (object item in chkSpecialization.CheckedItems)
            {
                specialisations.Add(item.ToString());
            }
            string temporaryPassword = Guid.NewGuid().ToString("N").Substring(0, 8);


            ServiceProvider provider = new ServiceProvider(firstName, lastName, email, temporaryPassword, phone, location, specialisations);
                       
            DataManager.AddServiceProvider(provider);
                        
            MessageBox.Show("Provider added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtFirstName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmProviderManagement providerManagementForm = new frmProviderManagement();
            providerManagementForm.Show();
            this.Close();
        }
    }

}
