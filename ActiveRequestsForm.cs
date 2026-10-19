using Home_Hero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeHero
{
    public partial class frmActiveRequest : Form
    {
        public frmActiveRequest(IEnumerable<MaintenanceRequest> requests)
        {
            InitializeComponent();
            StyleRequestGrid();

            foreach (MaintenanceRequest request in requests.Where(request =>
                         request.Status != RequestStatus.Completed &&
                         request.Status != RequestStatus.Cancelled))
            {
                dgvActiveRequests.Rows.Add(
                    request.RequestNumber,
                    request.ServiceCategory,
                    request.ProblemDescription,
                    request.PreferredDate.ToString("dd/MM/yyyy"),
                    $"R{request.EstimatedCost:F2}",
                    request.Status.ToString(),
                    $"{request.ProgressPercentage}%");
            }
            if (dgvActiveRequests.Rows.Count == 0)
            {
                lblActiveRequests.Text = "No active requests yet";
            }
        }

        private void StyleRequestGrid()
        {
            dgvActiveRequests.EnableHeadersVisualStyles = false;
            dgvActiveRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dgvActiveRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvActiveRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvActiveRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 251);
            dgvActiveRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActiveRequests.MultiSelect = false;
            dgvActiveRequests.RowTemplate.Height = 34;
        }

        private void dgvActiveRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvActiveRequests.Rows.Add("REQ001",
            //    "Plumbing", "Leaking kitchen tap",
            //    "22/09/2026", "R450", "In Progress");

            //dgvActiveRequests.Rows.Add("REQ003",
            //    "General Maintanance", "Lawn & tree trimming",
            //    "R500","26/09/2026", "Assigned" );

            //dgvActiveRequests.Rows.Add("REQ023",
            //    "Electrical", "Faulty wall socket",
            //    "R680", "24/10/2026");
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
