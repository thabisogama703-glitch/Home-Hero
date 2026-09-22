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

        public frmRequestTracking()
        {
            InitializeComponent();

            Load += RequestTrackingForm_Load;

            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
        }

        private void RequestTrackingForm_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void LoadRequests()
        {
            customerRequests = DataManager.LoadRequests();

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = customerRequests;

            ClearRequestDetails();
        }

        private void ClearRequestDetails()
        {
            lblRequestNum.Text = "Request Number: -";
            lblCategory.Text = "Service: -";
            lblStatus.Text = "Status: -";
            lblAssignedProvider.Text = "Assigned Provider: -";
            lblEstimatedCost.Text = "Estimated Cost: R0.00";
            lblFinalCost.Text = "Final Cost: -";
            lblAppointment.Text = "Preferred Date: -";
        }

        private void ShowSelectedRequest(MaintenanceRequest selected)
        {
            if (selected == null)
            {
                ClearRequestDetails();
                return;
            }

            lblRequestNum.Text =
                "Request Number: " + selected.RequestNumber;

            lblCategory.Text =
                "Service: " + selected.ServiceCategory;

            lblStatus.Text =
                "Status: " + selected.Status;

            lblAssignedProvider.Text =
                "Assigned Provider: " +
                (string.IsNullOrWhiteSpace(selected.AssignedProviderId)
                    ? "Unassigned"
                    : selected.AssignedProviderId);

            lblEstimatedCost.Text =
                $"Estimated Cost: R{selected.EstimatedCost:F2}";

            lblFinalCost.Text =
                selected.FinalCost > 0
                    ? $"Final Cost: R{selected.FinalCost:F2}"
                    : "Final Cost: Pending Completion";
            lblAppointment.Text = "Preferred Date: " + selected.PreferredDate.ToShortDateString() + " from " + selected.PreferredTime;
        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow != null &&
                dgvRequests.CurrentRow.DataBoundItem is MaintenanceRequest selected)
            {
                ShowSelectedRequest(selected);
            }
            else
            {
                ClearRequestDetails();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();

            MessageBox.Show(
                "Requests refreshed successfully.",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCustomerDashboard backToHome = new frmCustomerDashboard();

            this.Hide();
            backToHome.Show();
        }

        private void lblRequest_Click(object sender, EventArgs e)
        {
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

