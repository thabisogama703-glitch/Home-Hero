using HomeHero_2;
//using ServiceProviderDashboard;
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
    public partial class frmServiceProviderDashboard : Form
    {
        private ServiceProvider currentProvider;

        private List<Job> allJobs = new List<Job>();
        public frmServiceProviderDashboard(ServiceProvider provider)
        {
            InitializeComponent();
            currentProvider = provider;

            LoadJobs();
        }

        private void LoadJobs()
        {
            dgvAssignedJobs.Rows.Clear();
            dgvUpcomingJobs.Rows.Clear();
            dgvCompletedJobs.Rows.Clear();

            allJobs = currentProvider.Assignedjobs;

            foreach (Job job in allJobs)
            {
                if (job.Appointment == null ||
                    job.Appointment.Request == null)
                {
                    continue;
                }

                MaintenanceRequest request =
                    job.Appointment.Request;

                string customer = request.CustomerId;
                string service = request.ServiceCategory;

                string date =
                    job.Appointment.DateTime.ToString("yyyy-MM-dd");

                string time =
                    job.Appointment.DateTime.ToString("HH:mm");

                string status = request.Status.ToString();

                if (request.Status == RequestStatus.Completed)
                {
                    int row = dgvCompletedJobs.Rows.Add(
                        request.RequestNumber,
                        customer,
                        service,
                        date,
                        time,
                        status);

                    dgvCompletedJobs.Rows[row].Tag = job;
                }
                else if (job.Appointment.DateTime >= DateTime.Now)
                {
                    int row = dgvUpcomingJobs.Rows.Add(
                        request.RequestNumber,
                        customer,
                        service,
                        date,
                        time,
                        status);

                    dgvUpcomingJobs.Rows[row].Tag = job;
                }
                else
                {
                    int row = dgvAssignedJobs.Rows.Add(
                        request.RequestNumber,
                        customer,
                        service,
                        date,
                        time,
                        status);

                    dgvAssignedJobs.Rows[row].Tag = job;
                }
            }
        }
        
        private Job GetSelectedJob()
        {
            if (dgvAssignedJobs.SelectedRows.Count > 0)
                return dgvAssignedJobs.SelectedRows[0].Tag as Job;

            if (dgvUpcomingJobs.SelectedRows.Count > 0)
                return dgvUpcomingJobs.SelectedRows[0].Tag as Job;

            if (dgvCompletedJobs.SelectedRows.Count > 0)
                return dgvCompletedJobs.SelectedRows[0].Tag as Job;

            return null;
        }


        private void btnViewJob_Click(object sender, EventArgs e)
        {
            Job selectedJob = GetSelectedJob();

            if (selectedJob == null)
            {
                MessageBox.Show(
                    "Please select a job first.",
                    "No Job Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            frmJobDetails details =
            new frmJobDetails(selectedJob, currentProvider);

            details.ShowDialog();

            LoadJobs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                ("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void frmServiceProviderDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
