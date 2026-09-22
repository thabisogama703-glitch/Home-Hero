using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Home_Hero
{
    public partial class RequestManagement : Form
    {
        public RequestManagement()
        {
            InitializeComponent();
            var requests = DataManager.LoadRequests();
            dgvRequests.DataSource = requests;
        }

        private void btnCancelRequests_Click(object sender, EventArgs e)
        {

            if (dgvRequests.SelectedRows.Count > 0)
            {
                var request = (MaintenanceRequest1)dgvRequests.SelectedRows[0].DataBoundItem;


                var result = MessageBox.Show(
                    "Do you really want to cancel this request?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string errorMessage;
                    if (request.TryUpdateStatus(RequestStatus.Cancelled, out errorMessage))
                    {
                        var requests = DataManager.LoadRequests();
                        var existing = requests.FirstOrDefault(r => r.RequestNumber == request.RequestNumber);
                        if (existing != null)
                        {
                            existing.Status = request.Status;
                            DataManager.SaveRequests(requests);
                        }

                        MessageBox.Show("Request cancelled!");
                        RefreshGrid();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select a request first.");
            }
        }
        private void RefreshGrid()
        {
            var requests = DataManager.LoadRequests();
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = requests;
        }

        private void btnApproveRequests_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                var request = (MaintenanceRequest1)dgvRequests.SelectedRows[0].DataBoundItem;

                string errorMessage;
                if (request.TryUpdateStatus(RequestStatus.Approved, out errorMessage))
                {
                    var requests = DataManager.LoadRequests();
                    var existing = requests.FirstOrDefault(r => r.RequestNumber == request.RequestNumber);
                    if (existing != null)
                    {
                        existing.Status = request.Status;
                        DataManager.SaveRequests(requests);
                    }

                    MessageBox.Show("Request approved!");
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Please select a request first.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdminDashboard adminDashboard = new frmAdminDashboard();
            adminDashboard.Show();
        }

        private void RequestManagement_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchRequests_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReassign_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearchRequests.Focus();
            string searchText = txtSearchRequests.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                var requests = DataManager.LoadRequests();


                var filtered = requests
                    .Where(r => r.CustomerId.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                dgvRequests.DataSource = null;
                dgvRequests.DataSource = filtered;

                if (filtered.Count == 0)
                {
                    MessageBox.Show("No matching customers found.");
                }
            }
            else
            {
                dgvRequests.DataSource = null;
                dgvRequests.DataSource = DataManager.LoadRequests();
            }
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStatus.SelectedIndex >= 0)
            {
                string selectedStatus = cbxStatus.SelectedItem.ToString();
                var requests = DataManager.LoadRequests();
                if (selectedStatus == "All")
                {
                    dgvRequests.DataSource = requests;
                }
                else
                {
                    RequestStatus statusFilter;
                    if (Enum.TryParse(selectedStatus, out statusFilter))
                    {
                        var filtered = requests.Where(r => r.Status == statusFilter).ToList();
                        dgvRequests.DataSource = filtered;
                    }
                }
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminDashboard frmAdminDashboard = new frmAdminDashboard();
            this.Hide();
            frmAdminDashboard.Show();
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProviderManagement management = new frmProviderManagement();
            this.Hide();
            management.Show();
        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReports reports = new frmReports();
            this.Hide();
            reports.Show();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestManagement management = new RequestManagement();
            this.Hide();
            management.Show();
        }

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want ot logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmHomeHeroHomepage homepage = new frmHomeHeroHomepage();
                this.Hide();
                homepage.Show();
            }
        }
    }
}
