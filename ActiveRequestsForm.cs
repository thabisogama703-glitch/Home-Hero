using Home_Hero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeHero
{
    public partial class frmActiveRequest : FitForm
    {
        private readonly List<MaintenanceRequest> sourceRequests;
        private readonly CustomerListPage page;

        public frmActiveRequest(List<MaintenanceRequest> requests)
        {
            InitializeComponent();

            sourceRequests = requests ?? new List<MaintenanceRequest>();
            Text = "Active Requests";

            page = CustomerListPage.Build(
                this, dgvActiveRequests, btnBack,
                "Active Requests",
                "Jobs that are waiting for approval, being arranged or currently in progress.",
                new[] { "ACTIVE REQUESTS", "AWAITING APPROVAL", "ESTIMATED COST" },
                new[] { Theme.Orange, Theme.Amber, Theme.Blue },
                "Your open requests",
                "You have no active requests",
                "When you submit a new service request it will appear here.");

            CustomerListPage.AddColumn(dgvActiveRequests, "colRequestId", "Request ID", 120, false, true);
            CustomerListPage.AddColumn(dgvActiveRequests, "colService", "Service", 90);
            CustomerListPage.AddColumn(dgvActiveRequests, "colDescription", "Problem", 150);
            CustomerListPage.AddColumn(dgvActiveRequests, "colDate", "Preferred Date", 110);
            CustomerListPage.AddColumn(dgvActiveRequests, "colProvider", "Provider", 100);
            CustomerListPage.AddColumn(dgvActiveRequests, "colCost", "Est. Cost", 80, true);
            CustomerListPage.AddColumn(dgvActiveRequests, "colStatus", "Status", 100);
            CustomerListPage.AttachStatusPills(dgvActiveRequests, "colStatus");

            Load += delegate { LoadData(); };
        }

        /// <summary>Shows only this customer's requests that are not yet completed or cancelled.</summary>
        private void LoadData()
        {
            List<MaintenanceRequest> active = sourceRequests
                .Where(r => r.Status != RequestStatus.Completed && r.Status != RequestStatus.Cancelled)
                .OrderBy(r => r.PreferredDate)
                .ToList();

            Dictionary<string, string> providers = CustomerListPage.ProviderNameLookup();

            dgvActiveRequests.Rows.Clear();
            foreach (MaintenanceRequest request in active)
            {
                string when = request.PreferredDate.ToString("dd MMM yyyy");
                if (!string.IsNullOrWhiteSpace(request.PreferredTime))
                    when += ", " + request.PreferredTime;

                int row = dgvActiveRequests.Rows.Add(
                    request.RequestNumber,
                    request.ServiceCategory,
                    request.ProblemDescription,
                    when,
                    CustomerListPage.ProviderName(request.AssignedProviderId, providers),
                    AdminUi.Money(request.EstimatedCost),
                    AdminUi.StatusText(request.Status));

                dgvActiveRequests.Rows[row].Tag = request;
                dgvActiveRequests.Rows[row].Cells["colDescription"].ToolTipText = request.ProblemDescription;
            }

            page.TileValues[0].Text = active.Count.ToString();
            page.TileValues[1].Text = active.Count(r => r.Status == RequestStatus.Requested).ToString();
            page.TileValues[2].Text = AdminUi.Money(active.Sum(r => r.EstimatedCost));
            page.CountLabel.Text = active.Count == 1 ? "1 request" : active.Count + " requests";

            page.SetEmpty(active.Count == 0);
            dgvActiveRequests.ClearSelection();
        }

        private void dgvActiveRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
        }
    }
}
