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
    public partial class frmJobDetails : Form
    {
        private Job currentJob;
        private ServiceProvider currentProvider;

        public frmJobDetails(Job job, ServiceProvider provider)

        {
            InitializeComponent();

        }
        private void LoadJobDetails()
        {
            if (currentJob == null ||
                currentJob.Appointment == null ||
                currentJob.Appointment.Request == null)
            {
                MessageBox.Show(
                    "Job information is not available.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            MaintenanceRequest request =
      currentJob.Appointment.Request;

            lblCustomerValue.Text =
                request.CustomerId;

            lblServiceValue.Text =
                request.ServiceCategory;

            lblRequestNumberValue.Text =
                request.RequestNumber;

            lblAppointmentValue.Text =
                currentJob.Appointment.DateTime
                .ToString("yyyy-MM-dd HH:mm");

            lblProblemValue.Text =
                request.ProblemDescription;
            if (currentJob.Status == JobStatuses.NotStarted)
            {
                cmbJobStatus.SelectedItem = "Not Started";
            }
            else if (currentJob.Status == JobStatuses.InProgress)
            {
                cmbJobStatus.SelectedItem = "In Progress";
            }
            else if (currentJob.Status == JobStatuses.Completed)
            {
                cmbJobStatus.SelectedItem = "Completed";
            }

            nudFinalCost.Value = request.FinalCost;
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {


            if (currentJob == null)
                return;

            string selectedStatus =
                cmbJobStatus.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedStatus))
            {
                MessageBox.Show(
                    "Please select a job status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (selectedStatus == "Not Started")
            {
                currentJob.StatusUpdate(JobStatuses.NotStarted);
            }
            else if (selectedStatus == "In Progress")
            {
                currentJob.StatusUpdate(JobStatuses.InProgress);
            }
            else if (selectedStatus == "Completed")
            {
                currentJob.StatusUpdate(JobStatuses.Completed);
                currentJob.Appointment.CompletedJob();
            }

            MessageBox.Show(
                "Job status updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void btnRecordWork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWorkPerformed.Text))
            {
                MessageBox.Show(
                    "Please enter the work performed.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MaintenanceRequest request =
                currentJob.Appointment.Request;

            request.FinalCost = nudFinalCost.Value;

            if (currentJob.Status != JobStatuses.Completed)
            {
                currentJob.StatusUpdate(JobStatuses.Completed);

                request.Status = RequestStatus.Completed;

                currentJob.Appointment.CompletedJob();
            }

            MessageBox.Show(
                "Work and final cost recorded successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
