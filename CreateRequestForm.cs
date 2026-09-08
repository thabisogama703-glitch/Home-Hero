using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class CreateRequestForm : Form
    {
        public CreateRequestForm()
        {
            InitializeComponent();
            SetupDefaults();
        }

        private void SetupDefaults()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Plumbing");
            cmbCategory.Items.Add("Electrical");
            cmbCategory.Items.Add("Painting");
            cmbCategory.Items.Add("Appliance Repair");
            cmbCategory.Items.Add("General Maintenance");

            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.Items.Add("08:00 AM - 10:00 AM");
            cmbTimeSlot.Items.Add("10:00 AM - 12:00 PM");
            cmbTimeSlot.Items.Add("12:00 PM - 02:00 PM");
            cmbTimeSlot.Items.Add("02:00 PM - 04:00 PM");

            cmbCategory.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;

            dtpDatePreferred.MinDate = DateTime.Today;

            lblEstimatedCost.Text = "Estimated Cost: R0.00";

        }


        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a service category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtProblemDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a detailed description of the problem.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Please enter the property address.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (dtpDatePreferred.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Please select a date that is today or later.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (cmbTimeSlot.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a preferred time slot.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string CurrentCustomerId = "11";
            MaintenanceRequest newRequest = new MaintenanceRequest(
                CurrentCustomerId,
                cmbCategory.SelectedItem.ToString(),
                txtProblemDescription.Text.Trim(),
                txtAddress.Text.Trim(),
                dtpDatePreferred.Value.Date,
                cmbTimeSlot.SelectedItem.ToString()
                );
            DataManager.AddRequest(newRequest);

            MessageBox.Show(
            "Request submitted successfully!\n\n" +
            "Request Number: " + newRequest.RequestNumber + "\n" +
            "Estimated Cost: R" +
            newRequest.EstimatedCost.ToString("F2") + "\n" +
            "Status: " + newRequest.Status,
            "Request Submitted",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            ClearForm();
        }
        private void ClearForm()
        {
            cmbCategory.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;
            txtAddress.Clear();
            txtProblemDescription.Clear();
            dtpDatePreferred.Value = DateTime.Today;
            lblEstimatedCost.Text = "Estimated Cost: R0.00";
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                lblEstimatedCost.Text =
                    "Estimated Cost: R0.00";
                return;
            }

            string category = cmbCategory.SelectedItem.ToString();
            MaintenanceRequest temp = new MaintenanceRequest();
            decimal estimate = temp.CalculateEstimatedCost(category);
            lblEstimatedCost.Text = $"Estimated Cost: R{estimate:F2}";
        }

        private void CreateRequestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
