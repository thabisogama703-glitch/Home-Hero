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
    public partial class frmRequestTracking : Form
    {
        private List<MaintenanceRequest> customerRequests = new List<MaintenanceRequest>();
        private string currentCustomerId;

        public frmRequestTracking()
            : this("11")
        {
        }

        public frmRequestTracking(string customerId)
        {
            InitializeComponent();

            currentCustomerId = customerId;

            Load += RequestTrackingForm_Load;
            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
        }



        private void RequestTrackingForm_Load(object sender, EventArgs e)
        {
            List<MaintenanceRequest> allRequests = DataManager.LoadRequests();

            customerRequests = allRequests
                .Where(request => request.CustomerId == currentCustomerId)
                .ToList();

            RefreshGrid();
        }


        private void RefreshGrid()
        {
            dgvRequests.DataSource = null;

            dgvRequests.AutoGenerateColumns = true;
            dgvRequests.DataSource = customerRequests;

            if (dgvRequests.Columns["RequestNumber"] != null)
                dgvRequests.Columns["RequestNumber"].HeaderText = "Request Number";

            if (dgvRequests.Columns["CustomerId"] != null)
                dgvRequests.Columns["CustomerId"].Visible = false;

            if (dgvRequests.Columns["ProblemDescription"] != null)
                dgvRequests.Columns["ProblemDescription"].HeaderText = "Problem Description";

            if (dgvRequests.Columns["PropertyAddress"] != null)
                dgvRequests.Columns["PropertyAddress"].HeaderText = "Property Address";

            if (dgvRequests.Columns["PreferredDate"] != null)
                dgvRequests.Columns["PreferredDate"].HeaderText = "Appointment Date";

            if (dgvRequests.Columns["PreferredTime"] != null)
                dgvRequests.Columns["PreferredTime"].HeaderText = "Appointment Time";

            if (dgvRequests.Columns["ServiceCategory"] != null)
                dgvRequests.Columns["ServiceCategory"].HeaderText = "Service";

            if (dgvRequests.Columns["AssignedProviderId"] != null)
                dgvRequests.Columns["AssignedProviderId"].HeaderText = "Assigned Provider";

            if (dgvRequests.Columns["EstimatedCost"] != null)
                dgvRequests.Columns["EstimatedCost"].HeaderText = "Estimated Cost";

            if (dgvRequests.Columns["FinalCost"] != null)
                dgvRequests.Columns["FinalCost"].HeaderText = "Final Cost";

            if (dgvRequests.Columns["Status"] != null)
                dgvRequests.Columns["Status"].HeaderText = "Status";

            if (dgvRequests.Columns["ServiceRequest"] != null)
                dgvRequests.Columns["ServiceRequest"].Visible = false;
        }

        private void ShowSelectedRequest(MaintenanceRequest selected)
        {
            lblRequestNum.Text = "Request Number: " + selected.RequestNumber;

            lblCategory.Text = "Service: " + selected.ServiceCategory;

            lblStatus.Text = "Status: " + GetStatusText(selected.Status);

            lblAssignedProvider.Text =
                "Assigned Provider: " + selected.AssignedProviderId;

            lblEstimatedCost.Text =
                $"Estimated Cost: R{selected.EstimatedCost:F2}";

            lblFinalCost.Text =
                selected.FinalCost > 0
                ? $"Final Cost: R{selected.FinalCost:F2}"
                : "Final Cost: Pending Completion";

            lblAppointment.Text =
                "Appointment: " +
                selected.PreferredDate.ToString("dd MMMM yyyy") +
                " - " +
                selected.PreferredTime;
        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow != null &&
                dgvRequests.CurrentRow.DataBoundItem is MaintenanceRequest selected)
            {
                ShowSelectedRequest(selected);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<MaintenanceRequest> allRequests = DataManager.LoadRequests();

            customerRequests = allRequests
                .Where(request => request.CustomerId == currentCustomerId)
                .ToList();

            RefreshGrid();

            MessageBox.Show(
                "Requests refreshed successfully.",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }



        private void lblRequest_Click(object sender, EventArgs e)
        {

        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCustomerDashboard backtoHome = new frmCustomerDashboard();
            this.Hide();
            backtoHome.Show();
            
        }
        private string GetStatusText(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Requested:
                    return "Requested";

                case RequestStatus.Approved:
                    return "Approved";

                case RequestStatus.ProviderAssigned:
                    return "Provider Assigned";

                case RequestStatus.Scheduled:
                    return "Scheduled";

                case RequestStatus.InProgress:
                    return "In Progress";

                case RequestStatus.Completed:
                    return "Completed";

                case RequestStatus.Cancelled:
                    return "Cancelled";

                default:
                    return "Unknown";
            }
        }

    }
}

