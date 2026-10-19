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
using System.Net.Mail;

namespace Home_Hero
{
    public partial class AddProvider : Form
    {
        private readonly ServiceProvider? providerToEdit;

        public AddProvider()
        {
            InitializeComponent();
            StyleForm();
        }

        public AddProvider(ServiceProvider provider)
            : this()
        {
            providerToEdit = provider;
            label8.Text = "Edit Provider";
            label1.Text = "Update service provider details";
            btnAddProvider.Text = "Save Changes";
            txtFirstName.Text = provider.FirstName;
            txtLastName.Text = provider.LastName;
            txtEmail.Text = provider.Email;
            txtEmail.ReadOnly = true;
            txtEmail.BackColor = Color.FromArgb(240, 242, 246);
            txtPhone.Text = provider.PhoneNumber;
            txtSeaviceArea.Text = provider.Location;
            for (int index = 0; index < chkSpecialization.Items.Count; index++)
            {
                string item = chkSpecialization.Items[index]?.ToString() ?? string.Empty;
                if (provider.Specialisation.Any(specialization =>
                    string.Equals(specialization, item, StringComparison.OrdinalIgnoreCase) ||
                    (specialization == "WindowsDoors" && item == "Windows and Doors")))
                {
                    chkSpecialization.SetItemChecked(index, true);
                }
            }
        }

        private void StyleForm()
        {
            BackgroundImage = Properties.Resources.Home_Hero_background_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(1040, 760);
            pnlAddProvider.Location = new Point((ClientSize.Width - pnlAddProvider.Width) / 2, 128);
            pnlAddProvider.BackColor = Color.White;
            pnlAddProvider.BorderStyle = BorderStyle.FixedSingle;
            pnlNavigationAdminPanl.Size = new Size(ClientSize.Width, pnlNavigationAdminPanl.Height);
            btnExitAdmin.Location = new Point(ClientSize.Width - btnExitAdmin.Width - 24, 20);
            btnExitAdmin.Click += (_, _) => Close();
            AcceptButton = btnAddProvider;
            CancelButton = btnCancel;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnAddProvider.BackColor = Color.FromArgb(255, 128, 0);
            btnAddProvider.ForeColor = Color.White;
            btnAddProvider.FlatStyle = FlatStyle.Flat;
            btnAddProvider.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
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
            try
            {
                if (!string.Equals(new MailAddress(email).Address, email, StringComparison.OrdinalIgnoreCase))
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
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
                specialisations.Add(item?.ToString() ?? string.Empty);
            }
            if (providerToEdit == null && CustomerRepository.EmailExists(email))
            {
                MessageBox.Show("An account with this email already exists.", "Email Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string temporaryPassword = providerToEdit?.Password ?? Guid.NewGuid().ToString("N")[..12];
            ServiceProvider provider = new ServiceProvider(firstName, lastName, email, temporaryPassword, phone, location, specialisations);
            if (!CustomerRepository.SaveServiceProvider(provider))
            {
                MessageBox.Show("The service provider could not be saved.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (providerToEdit == null)
            {
                MessageBox.Show(
                    $"Provider added successfully.\n\nTemporary login password: {temporaryPassword}\nShare this password securely with the provider.",
                    "Provider Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Provider details updated successfully.", "Provider Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        public void ClearFiled()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtSeaviceArea.Clear();

            chkSpecialization.ClearSelected();
           }   }   
}
