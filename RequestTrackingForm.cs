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
            : this(string.Empty)
        {
        }

        public frmRequestTracking(string customerId)
        {
            InitializeComponent();

            currentCustomerId = customerId;
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 251);
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = false;

            BuildTrackingWorkspace();
            Load += RequestTrackingForm_Load;
            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
        }

        private void BuildTrackingWorkspace()
        {
            Control[] retained =
            {
                dgvRequests, lblRequestNum, lblCategory, lblStatus, lblAssignedProvider,
                lblAppointment, lblEstimatedCost, lblFinalCost, btnRefresh, button1
            };
            foreach (Control control in retained)
            {
                control.Parent?.Controls.Remove(control);
            }
            Controls.Clear();
            BackColor = HomeHeroTheme.Canvas;
            MinimumSize = new Size(1000, 700);
            WindowState = FormWindowState.Maximized;
            Text = "HomeHero | Request tracking";

            Panel header = new()
            {
                BackColor = HomeHeroTheme.Navy,
                Dock = DockStyle.Fill,
                Padding = new Padding(28, 0, 28, 0)
            };
            TableLayoutPanel headerLayout = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                RowCount = 1
            };
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headerLayout.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "Track your service request",
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            HomeHeroTheme.StyleButton(button1, true);
            button1.Dock = DockStyle.Fill;
            button1.Text = "Close";
            button1.Margin = new Padding(8, 12, 0, 12);
            headerLayout.Controls.Add(button1, 1, 0);
            header.Controls.Add(headerLayout);

            HomeHeroCard detailsCard = new()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(22, 16, 22, 8),
                Padding = new Padding(18)
            };
            TableLayoutPanel details = new()
            {
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            for (int column = 0; column < 3; column++)
            {
                details.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333F));
            }
            for (int row = 0; row < 3; row++)
            {
                details.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));
            }
            Label[] detailLabels =
            {
                lblRequestNum, lblCategory, lblStatus, lblAssignedProvider,
                lblAppointment, lblEstimatedCost, lblFinalCost
            };
            foreach (Label label in detailLabels)
            {
                label.Dock = DockStyle.Fill;
                label.Margin = new Padding(6);
                label.Padding = new Padding(12);
                label.BackColor = HomeHeroTheme.Canvas;
                label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                label.ForeColor = HomeHeroTheme.Navy;
                label.AutoEllipsis = true;
                label.TextAlign = ContentAlignment.MiddleLeft;
            }
            for (int index = 0; index < detailLabels.Length; index++)
            {
                details.Controls.Add(detailLabels[index], index % 3, index / 3);
            }
            detailsCard.Controls.Add(details);

            HomeHeroDataGridCard requestsCard = new("All requests", dgvRequests)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(22, 8, 22, 20)
            };
            HomeHeroTheme.StyleButton(btnRefresh, true);
            btnRefresh.Text = "Refresh requests";
            btnRefresh.Width = 180;
            btnRefresh.Height = 38;
            requestsCard.AddActionControl(btnRefresh);

            TableLayoutPanel root = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(detailsCard, 0, 1);
            root.Controls.Add(requestsCard, 0, 2);
            Controls.Add(root);
        }


        private void RequestTrackingForm_Load(object sender, EventArgs e)
        {
            List<MaintenanceRequest> allRequests = DataManager.LoadRequests();

            customerRequests = allRequests
                .Where(request => string.Equals(
                    request.CustomerId,
                    currentCustomerId,
                    StringComparison.OrdinalIgnoreCase))
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

            if (dgvRequests.Columns["ProgressPercentage"] != null)
            {
                dgvRequests.Columns["ProgressPercentage"].HeaderText = "Progress";
                dgvRequests.Columns["ProgressPercentage"].DefaultCellStyle.Format = "0'%'";
            }

            if (dgvRequests.Columns["ServiceRequest"] != null)
                dgvRequests.Columns["ServiceRequest"].Visible = false;
        }

        private void ShowSelectedRequest(MaintenanceRequest selected)
        {
            lblRequestNum.Text = "Request Number: " + selected.RequestNumber;

            lblCategory.Text = "Service: " + selected.ServiceCategory;

            lblStatus.Text = $"Status: {GetStatusText(selected.Status)} · {selected.ProgressPercentage}%";

            lblAssignedProvider.Text =
                "Assigned Provider: " + selected.AssignedProviderId;

            lblEstimatedCost.Text =
                $"Starting estimate: R{selected.EstimatedCost:F2}";

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
                .Where(request => string.Equals(
                    request.CustomerId,
                    currentCustomerId,
                    StringComparison.OrdinalIgnoreCase))
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
            Close();
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

        private void gbxServiceDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
