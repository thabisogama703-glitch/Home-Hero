using Home_Hero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeHero
{
    public partial class ServiceHistoryForm : Form
    {
        public ServiceHistoryForm(IEnumerable<MaintenanceRequest> requests)
        {
            InitializeComponent();
            StyleHistoryGrid();

            foreach (MaintenanceRequest request in requests
                         .Where(request => request.Status == RequestStatus.Completed)
                         .OrderByDescending(request => request.PreferredDate))
            {
                decimal cost = request.FinalCost > 0 ? request.FinalCost : request.EstimatedCost;
                dgvServiceHistory.Rows.Add(
                    request.RequestNumber,
                    request.ServiceCategory,
                    request.PreferredDate.ToString("dd MMM yyyy"),
                    $"R{cost:F2}",
                    request.Status.ToString());
            }

            if (dgvServiceHistory.Rows.Count == 0)
            {
                lblServicesHistory.Text = "No completed services yet";
            }
        }

        private void StyleHistoryGrid()
        {
            dgvServiceHistory.EnableHeadersVisualStyles = false;
            dgvServiceHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dgvServiceHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvServiceHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvServiceHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 251);
            dgvServiceHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServiceHistory.MultiSelect = false;
            dgvServiceHistory.RowTemplate.Height = 34;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}
