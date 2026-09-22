using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceProviderDashboard;

namespace ServiceProviderDashboard
{
    public partial class frmServiceProviderDashboard : Form
    {
        private ServiceProvider currentProvider;
        public frmServiceProviderDashboard(ServiceProvider provider)
        {
            InitializeComponent();
            currentProvider = provider;

        }
        private void frmProviderDashboard_Load(object sender, EventArgs e)
        {
            LoadAssignedJobs();
            LoadUpcomingJobs();
            LoadCompletedJobs();
        }
        private void LoadAssignedJobs()
        {

            dgvAssignedJobs.Rows.Clear();

            foreach (Job job in currentProvider.Assignedjobs)
            {
                MaintenanceRequests request = job.Appointment.Request;

                string customerName =
                    request.Customer.FirstName + " " +
                    request.Customer.LastName;

                int rowIndex = dgvAssignedJobs.Rows.Add();

                dgvAssignedJobs.Rows[rowIndex].Cells[0].Value =
                    request.RequestId.ToString();

                dgvAssignedJobs.Rows[rowIndex].Cells[1].Value =
                    customerName;

                dgvAssignedJobs.Rows[rowIndex].Cells[2].Value =
                    request.ServiceRequest.ServiceName;

                dgvAssignedJobs.Rows[rowIndex].Cells[3].Value =
                    job.Appointment.DateTime;


                dgvAssignedJobs.Rows[rowIndex].Cells[4].Value =
                  job.Appointment.DateTime.Date;
                dgvAssignedJobs.Rows[rowIndex].Cells[5].Value =
               job.Status;

            }
        }

        private void LoadUpcomingJobs()
        {

            dgvUpcomingJobs.Rows.Clear();

            foreach (Job job in currentProvider.Assignedjobs)
            {
                if (job.Appointment.DateTime > DateTime.Now)
                {
                    MaintenanceRequests request = job.Appointment.Request;

                    string customerName =
                        request.Customer.FirstName + " " +
                        request.Customer.LastName;

                    int rowIndex = dgvUpcomingJobs.Rows.Add();

                    dgvUpcomingJobs.Rows[rowIndex].Cells[0].Value =
                        request.RequestId.ToString();

                    dgvUpcomingJobs.Rows[rowIndex].Cells[1].Value =
                        customerName;

                    dgvUpcomingJobs.Rows[rowIndex].Cells[2].Value =
                        request.ServiceRequest.ServiceName;

                    dgvUpcomingJobs.Rows[rowIndex].Cells[3].Value =
                        job.Appointment.DateTime.ToString("dd/MM/yyyy");

                    dgvUpcomingJobs.Rows[rowIndex].Cells[4].Value =
                        job.Appointment.DateTime.ToString("HH:mm");

                    dgvUpcomingJobs.Rows[rowIndex].Cells[5].Value =
                        job.Status;
                }
            }
        }
        private void LoadCompletedJobs()
        {

            dgvCompletedJobs.Rows.Clear();

            foreach (Job job in currentProvider.Assignedjobs)
            {
                if (job.Status == JobStatuses.Completed)
                {
                    MaintenanceRequests request = job.Appointment.Request;

                    string customerName =
                        request.Customer.FirstName + " " +
                        request.Customer.LastName;

                    int rowIndex = dgvCompletedJobs.Rows.Add();

                    dgvCompletedJobs.Rows[rowIndex].Cells[0].Value =
                        request.RequestId.ToString();

                    dgvCompletedJobs.Rows[rowIndex].Cells[1].Value =
                        customerName;

                    dgvCompletedJobs.Rows[rowIndex].Cells[2].Value =
                        request.ServiceRequest.ServiceName;

                    dgvCompletedJobs.Rows[rowIndex].Cells[3].Value =
                        job.Appointment.DateTime.ToString("dd/MM/yyyy");

                    dgvCompletedJobs.Rows[rowIndex].Cells[4].Value =
                        job.Invoice != null ? job.Invoice.CostAmount.ToString("C") : "Not recorded";

                    dgvCompletedJobs.Rows[rowIndex].Cells[5].Value =
                        job.Status;
                }

            }
        }

        private void btnViewAssignedJobs_Click(object sender, EventArgs e)
        {
            if (dgvAssignedJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            int index = dgvAssignedJobs.SelectedRows[0].Index;
            Job selectedJob = currentProvider.Assignedjobs[index];


            frmJobDetails jobDetails = new frmJobDetails(selectedJob);
            jobDetails.ShowDialog();

            if (selectedJob == null)
            {
                MessageBox.Show("Could not find the selected job.");
                return;
            }
            if (selectedJob.Appointment == null)
            {
                MessageBox.Show("This job has no appointment.");
                return;
            }
            if (selectedJob.Appointment.Request == null)
            {
                MessageBox.Show("This job has no maintenance request.");
                return;
            }

            MaintenanceRequests request =
              selectedJob.Appointment.Request;

            string customerName = "Unknown";
            //string customerName =
            //  request.Customer.FirstName + " " +
            //  request.Customer.LastName;
            if (request.Customer != null)
            {
                customerName = request.Customer.FirstName + " " +
                    request.Customer.LastName;
            }
            LoadAssignedJobs();

            MessageBox.Show(
              "Job ID: " + selectedJob.JobId +
              "\nCustomer: " + customerName +
              "\nDescription: " + request.RequestDescription +
              "\nStatus: " + selectedJob.Status +
              "\nAppointment Date: " +
              selectedJob.Appointment.DateTime
          );

        }

        private void dgvAssignedJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

