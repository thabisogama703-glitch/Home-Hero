using Home_Hero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HomeHero
{
    public partial class ServiceHistoryForm : FitForm
    {
        private readonly CustomerListPage page;

        public ServiceHistoryForm()
        {
            InitializeComponent();
            Text = "Service History";

            page = CustomerListPage.Build(
                this, dgvServiceHistory, btnBack,
                "Service History",
                "Every job that has been completed or cancelled on your account.",
                new[] { "COMPLETED JOBS", "TOTAL SPENT", "LAST SERVICE" },
                new[] { Theme.Green, Theme.Blue, Theme.Purple },
                "Your past services",
                "No service history yet",
                "Completed and cancelled jobs will be listed here.");

            CustomerListPage.AddColumn(dgvServiceHistory, "colRequestId", "Request ID", 120, false, true);
            CustomerListPage.AddColumn(dgvServiceHistory, "colService", "Service", 90);
            CustomerListPage.AddColumn(dgvServiceHistory, "colDescription", "What Was Done", 150);
            CustomerListPage.AddColumn(dgvServiceHistory, "colDate", "Service Date", 100);
            CustomerListPage.AddColumn(dgvServiceHistory, "colProvider", "Provider", 100);
            CustomerListPage.AddColumn(dgvServiceHistory, "colCost", "Total Cost", 80, true);
            CustomerListPage.AddColumn(dgvServiceHistory, "colStatus", "Status", 100);
            CustomerListPage.AttachStatusPills(dgvServiceHistory, "colStatus");

            Load += delegate { LoadData(); };
        }

        /// <summary>Reads this customer's completed and cancelled requests from the saved request file.</summary>
        private void LoadData()
        {
            string customerId = CustomerSession.CustomerId;

            List<MaintenanceRequest> history = DataManager.LoadRequests()
                .Where(r => r.CustomerId == customerId)
                .Where(r => r.Status == RequestStatus.Completed || r.Status == RequestStatus.Cancelled)
                .OrderByDescending(r => r.PreferredDate)
                .ToList();

            Dictionary<string, string> providers = CustomerListPage.ProviderNameLookup();

            dgvServiceHistory.Rows.Clear();
            foreach (MaintenanceRequest request in history)
            {
                string cost = request.Status == RequestStatus.Completed
                    ? AdminUi.Money(CostOf(request))
                    : "-";

                int row = dgvServiceHistory.Rows.Add(
                    request.RequestNumber,
                    request.ServiceCategory,
                    request.ProblemDescription,
                    request.PreferredDate.ToString("dd MMM yyyy"),
                    CustomerListPage.ProviderName(request.AssignedProviderId, providers),
                    cost,
                    AdminUi.StatusText(request.Status));

                dgvServiceHistory.Rows[row].Tag = request;
                dgvServiceHistory.Rows[row].Cells["colDescription"].ToolTipText = request.ProblemDescription;
            }

            List<MaintenanceRequest> completed = history
                .Where(r => r.Status == RequestStatus.Completed)
                .ToList();

            page.TileValues[0].Text = completed.Count.ToString();
            page.TileValues[1].Text = AdminUi.Money(completed.Sum(r => CostOf(r)));
            page.TileValues[2].Text = completed.Count == 0
                ? "None yet"
                : completed.Max(r => r.PreferredDate).ToString("dd MMM yyyy");
            page.CountLabel.Text = history.Count == 1 ? "1 record" : history.Count + " records";

            page.SetEmpty(history.Count == 0);
            dgvServiceHistory.ClearSelection();
        }

        // The final cost is used once the job is billed; until then the estimate is shown.
        private static decimal CostOf(MaintenanceRequest request)
        {
            return request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
