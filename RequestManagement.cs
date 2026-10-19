using System;
using HomeHero_2;
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
        private readonly ComboBox providerAssignment = new()
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Location = new Point(510, 987),
            Size = new Size(270, 43)
        };

        public RequestManagement()
        {
            InitializeComponent();
            btnReassign.Text = "Assign provider";
            btnReassign.Location = new Point(324, 987);
            btnReassign.Size = new Size(175, 43);
            Controls.Add(providerAssignment);
            txtSearchRequests.Enter += (_, _) =>
            {
                if (txtSearchRequests.Text == "Search by ID, Customer ...")
                {
                    txtSearchRequests.Clear();
                }
            };
            txtSearchRequests.Leave += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchRequests.Text))
                {
                    txtSearchRequests.Text = "Search by ID, Customer ...";
                }
            };
            LoadProviderChoices();
            cbxStatus.SelectedIndex = 0;
            cbxCategory.SelectedIndex = 0;
            RefreshGrid();
        }

        private void LoadProviderChoices()
        {
            providerAssignment.DisplayMember = nameof(ProviderChoice.DisplayText);
            providerAssignment.DataSource = CustomerRepository.LoadRegisteredServiceProviders()
                .Select(provider => new ProviderChoice(provider.Email, $"{provider.FirstName} {provider.LastName}".Trim()))
                .ToList();
        }

        private void btnCancelRequests_Click(object sender, EventArgs e)
        {

            if (dgvRequests.SelectedRows.Count > 0)
            {
                var request = (MaintenanceRequest)dgvRequests.SelectedRows[0].DataBoundItem;


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
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchText = txtSearchRequests.Text.Trim();
            if (string.Equals(searchText, "Search by ID, Customer ...", StringComparison.OrdinalIgnoreCase))
            {
                searchText = string.Empty;
            }

            string selectedStatus = cbxStatus.SelectedItem?.ToString() ?? "Status : All";
            string statusText = selectedStatus.StartsWith("Status : ", StringComparison.OrdinalIgnoreCase)
                ? selectedStatus["Status : ".Length..].Trim()
                : selectedStatus.Trim();
            string selectedCategory = cbxCategory.SelectedItem?.ToString() ?? "Category : All";
            string categoryText = selectedCategory.StartsWith("Category : ", StringComparison.OrdinalIgnoreCase)
                ? selectedCategory["Category : ".Length..].Trim()
                : selectedCategory.Trim();

            IEnumerable<MaintenanceRequest> filtered = DataManager.LoadRequests();
            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(request =>
                    (request.RequestNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (request.CustomerId?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            if (!string.IsNullOrEmpty(statusText) && !string.Equals(statusText, "All", StringComparison.OrdinalIgnoreCase))
            {
                RequestStatus? requestedStatus = statusText.ToLowerInvariant() switch
                {
                    "submitted" => RequestStatus.Requested,
                    "assigned" => RequestStatus.ProviderAssigned,
                    "in progress" => RequestStatus.InProgress,
                    _ when Enum.TryParse(statusText, true, out RequestStatus parsedStatus) => parsedStatus,
                    _ => null
                };

                if (requestedStatus.HasValue)
                {
                    filtered = filtered.Where(request => request.Status == requestedStatus.Value);
                }
            }

            if (!string.IsNullOrEmpty(categoryText) && !string.Equals(categoryText, "All", StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(request => string.Equals(
                    HomeServiceCatalog.NormalizeCategory(request.ServiceCategory),
                    HomeServiceCatalog.NormalizeCategory(categoryText),
                    StringComparison.OrdinalIgnoreCase));
            }

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = filtered.ToList();
        }

        private void btnApproveRequests_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                var request = (MaintenanceRequest)dgvRequests.SelectedRows[0].DataBoundItem;

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
            Close();
        }

        private void RequestManagement_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchRequests_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnReassign_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow?.DataBoundItem is not MaintenanceRequest selected)
            {
                MessageBox.Show("Select a request to assign.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (providerAssignment.SelectedItem is not ProviderChoice provider)
            {
                MessageBox.Show("Register a service provider before assigning this request.", "No Provider Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<MaintenanceRequest> requests = DataManager.LoadRequests();
            MaintenanceRequest? request = requests.FirstOrDefault(item =>
                string.Equals(item.RequestNumber, selected.RequestNumber, StringComparison.Ordinal));
            if (request == null)
            {
                MessageBox.Show("The selected request could not be found. Refresh the list and try again.", "Request Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshGrid();
                return;
            }

            if (request.Status == RequestStatus.Requested)
            {
                if (!request.TryUpdateStatus(RequestStatus.Approved, out string approvalError))
                {
                    MessageBox.Show(approvalError, "Assignment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (request.Status != RequestStatus.Approved &&
                     request.Status != RequestStatus.ProviderAssigned)
            {
                MessageBox.Show(
                    $"A request in {request.Status} status cannot be assigned or reassigned.",
                    "Assignment Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (request.Status == RequestStatus.Approved &&
                !request.TryUpdateStatus(RequestStatus.ProviderAssigned, out string assignmentError))
            {
                MessageBox.Show(assignmentError, "Assignment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            request.AssignedProviderId = provider.Email;
            if (!DataManager.SaveRequests(requests))
            {
                return;
            }

            RefreshGrid();
            MessageBox.Show(
                $"Request assigned to {provider.DisplayText}.",
                "Provider Assigned",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearchRequests.Focus();
            ApplyFilters();
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new frmProviderManagement());
        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new frmReports());
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAdminPage(new RequestManagement());
        }

        private void OpenAdminPage(Form page)
        {
            page.FormClosed += (_, _) =>
            {
                Show();
                RefreshGrid();
            };
            Hide();
            page.Show();
        }

        private sealed record ProviderChoice(string Email, string DisplayText);

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
