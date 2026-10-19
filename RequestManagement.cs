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
            Width = 230,
            Height = 36
        };
        private HomeHeroDashboardLayout? dashboardLayout;
        private Control? workspaceContent;

        public event EventHandler? WorkspaceDataChanged;

        public RequestManagement()
        {
            InitializeComponent();
            BuildUnifiedWorkspace();
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

        private void BuildUnifiedWorkspace()
        {
            Controls.Clear();
            Text = "HomeHero | Request management";
            BackColor = Color.FromArgb(246, 248, 251);
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;

            dashboardLayout = new HomeHeroDashboardLayout();
            dashboardLayout.SetIdentity("ADMINISTRATOR PORTAL");
            dashboardLayout.SetHero("Service request management", "Review requests, filter the queue, approve work, and assign providers.");
            dashboardLayout.SetNavigation(
                new[] { "Overview", "Requests", "Providers", "Services", "Reports" },
                "Requests");
            dashboardLayout.NavigationRequested += (_, section) => NavigateAdmin(section);

            Button logout = CreateActionButton("Log out", Color.FromArgb(33, 43, 74));
            logout.Size = new Size(106, 34);
            logout.Click += btnExitAdmin_Click;
            dashboardLayout.HeaderPanel.Controls.Add(logout);
            dashboardLayout.HeaderPanel.Resize += (_, _) => logout.Location =
                new Point(dashboardLayout.HeaderPanel.ClientSize.Width - logout.Width - 28, 15);

            TableLayoutPanel workspace = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            workspace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            workspace.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            workspace.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            workspace.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            workspace.Controls.Add(CreateFiltersBar(), 0, 0);

            Panel gridCard = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            HomeHeroDashboardLayout.StyleTable(dgvRequests);
            dgvRequests.Dock = DockStyle.Fill;
            gridCard.Controls.Add(dgvRequests);
            workspace.Controls.Add(gridCard, 0, 1);
            workspace.Controls.Add(CreateActionsBar(), 0, 2);
            workspaceContent = workspace;
            dashboardLayout.ShowContent(workspace);
            Controls.Add(dashboardLayout);
        }

        public Control DetachWorkspaceContent()
        {
            if (workspaceContent?.Parent is Control parent)
            {
                parent.Controls.Remove(workspaceContent);
            }

            return workspaceContent ?? new Panel { BackColor = Color.FromArgb(246, 248, 251), Dock = DockStyle.Fill };
        }

        public void DisposeWorkspace()
        {
            workspaceContent?.Dispose();
            workspaceContent = null;
            Dispose();
        }

        public void RefreshWorkspace() => RefreshGrid(true);

        private Control CreateFiltersBar()
        {
            FlowLayoutPanel filters = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 5, 0, 5),
                WrapContents = false
            };
            txtSearchRequests.PlaceholderText = "Search request ID or customer";
            txtSearchRequests.Font = new Font("Segoe UI", 9.5F);
            txtSearchRequests.Width = 300;
            txtSearchRequests.Margin = new Padding(0, 0, 10, 0);
            btnSearch.Text = "Search";
            btnSearch.Size = new Size(90, 34);
            btnSearch.Margin = new Padding(0, 0, 10, 0);
            cbxStatus.Width = 145;
            cbxStatus.Height = 34;
            cbxStatus.Margin = new Padding(0, 0, 10, 0);
            cbxCategory.Width = 190;
            cbxCategory.Height = 34;
            filters.Controls.Add(txtSearchRequests);
            filters.Controls.Add(btnSearch);
            filters.Controls.Add(cbxStatus);
            filters.Controls.Add(cbxCategory);
            return filters;
        }

        private Control CreateActionsBar()
        {
            FlowLayoutPanel actions = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 7, 0, 0),
                WrapContents = false
            };
            btnApproveRequests.Text = "Approve request";
            btnApproveRequests.Size = new Size(160, 38);
            btnApproveRequests.BackColor = Color.FromArgb(46, 204, 113);
            btnApproveRequests.ForeColor = Color.White;
            btnCancelRequests.Text = "Cancel request";
            btnCancelRequests.Size = new Size(150, 38);
            btnCancelRequests.BackColor = Color.FromArgb(231, 76, 60);
            btnCancelRequests.ForeColor = Color.White;
            btnReassign.Text = "Assign provider";
            btnReassign.Size = new Size(150, 38);
            providerAssignment.Width = 245;
            providerAssignment.Margin = new Padding(8, 2, 10, 0);
            actions.Controls.Add(btnApproveRequests);
            actions.Controls.Add(btnCancelRequests);
            actions.Controls.Add(providerAssignment);
            actions.Controls.Add(btnReassign);
            return actions;
        }

        private static Button CreateActionButton(string text, Color color)
        {
            Button button = new()
            {
                BackColor = color,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = text,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void NavigateAdmin(string section)
        {
            switch (section)
            {
                case "Overview":
                    Close();
                    break;
                case "Providers":
                    OpenAdminPage(new frmProviderManagement());
                    break;
                case "Services":
                    OpenAdminPage(new frmAdminDashboard());
                    break;
                case "Reports":
                    OpenAdminPage(new frmReports());
                    break;
                default:
                    dashboardLayout?.SetNavigation(
                        new[] { "Overview", "Requests", "Providers", "Services", "Reports" },
                        "Requests");
                    RefreshGrid();
                    break;
            }
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
                        RefreshGrid(true);
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
        private void RefreshGrid(bool notifyParent = false)
        {
            ApplyFilters();
            if (notifyParent)
            {
                WorkspaceDataChanged?.Invoke(this, EventArgs.Empty);
            }
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

            List<MaintenanceRequest> allRequests = DataManager.LoadRequests();
            IEnumerable<MaintenanceRequest> filtered = allRequests;
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
            List<MaintenanceRequest> visibleRequests = filtered.ToList();
            dgvRequests.DataSource = visibleRequests;
            dashboardLayout?.SetMetrics(new[]
            {
                new DashboardMetric("Total requests", allRequests.Count.ToString(), "All submitted jobs"),
                new DashboardMetric("Awaiting approval", allRequests.Count(request => request.Status == RequestStatus.Requested).ToString(), "Need review"),
                new DashboardMetric("Filtered results", visibleRequests.Count.ToString(), "Matching current filters"),
                new DashboardMetric("Assigned providers", CustomerRepository.LoadRegisteredServiceProviders().Count.ToString(), "Available to assign")
            });
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
                    RefreshGrid(true);
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

            RefreshGrid(true);
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
