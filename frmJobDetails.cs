using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServiceProviderDashboard
{
    public partial class frmJobDetails : Form
    {
        private Job selectedJob;

        public frmJobDetails(Job job)
        {
            InitializeComponent();
            selectedJob = job;

            DisplayJobDetails();
        }
        private void DisplayJobDetails()
        {
            MaintenanceRequest request = selectedJob.Appointment.Request;

            lblCustomerName.Text =
                request.Customer.FirstName + " " +
                request.Customer.LastName;

            lblService.Text =
                request.ServiceRequest.ServiceName;

            lblRequestNumber.Text =
                request.RequestId.ToString();

            lblAppointment.Text =
                selectedJob.Appointment.DateTime.ToString("dd/MM/yyyy HH:mm");

            lblProblem.Text =
                request.RequestDescription;

            cmbStatus.Text =
                selectedJob.Status;
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            selectedJob.StatusUpdate(cmbStatus.Text);

            MessageBox.Show("Job status updated successfully.");

            this.Close();
        }

        private void btnRecordWork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbWorkPerformed.Text))
            {
                MessageBox.Show("Please enter the work performed.");
                return;
            }

            MessageBox.Show("Work recorded successfully.");
           
            if (!decimal.TryParse(txtFinalCost.Text, out decimal finalCost))
            {
                MessageBox.Show("Enter a valid final cost.");
                return;
            }
            string finalCostText = txtFinalCost.Text;

            foreach (char i in finalCostText)
            {
                if (!char.IsDigit(i) && i != '.')
                {
                    MessageBox.Show("Final cost must contain numbers only.");
                    return;
                }
            }
          
            if (finalCost < 0)
            {
                MessageBox.Show("Final cost cannot be negative.");
                return;
            }

            MessageBox.Show("Work and final cost recorded successfully.");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

