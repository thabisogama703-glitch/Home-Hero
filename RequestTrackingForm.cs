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
    public partial class RequestTrackingForm : Form
    {
        private List<MaintenanceRequest> customerRequests = new List<MaintenanceRequest>();
        public RequestTrackingForm()
        {
            InitializeComponent();
            Load += RequestTrackingForm_Load;
            btnRefresh.Click += btnRefresh_Click;
            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
        }

        private void RequestTrackingForm_Load(object sender, EventArgs e)
        {
            customerRequests = DataManager.LoadRequests();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = customerRequests;
        }
        private void ShowSelectedRequest(MaintenanceRequest selected)
        {
            lblRequestNum.Text = "Request Number: " + selected.RequestNumber;

            lblCategory.Text = "Service: " + selected.ServiceCategory;

            lblStatus.Text = "Status: " + selected.Status.ToString();

            lblAssignedProvider.Text =
                "Assigned Provider: " + selected.AssignedProviderId;

            lblEstimatedCost.Text =
                $"Estimated Cost: R{selected.EstimatedCost:F2}";

            lblFinalCost.Text =
                selected.FinalCost > 0
                ? $"Final Cost: R{selected.FinalCost:F2}"
                : "Final Cost: Pending Completion";
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
            RefreshGrid();
            MessageBox.Show(
                "Requests refreshed successfully.",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


    }
}

