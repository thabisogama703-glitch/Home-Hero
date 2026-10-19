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
            BuildWorkspaceLayout();
        }

        private void BuildWorkspaceLayout()
        {
            dgvServiceHistory.Parent?.Controls.Remove(dgvServiceHistory);
            btnBack.Parent?.Controls.Remove(btnBack);
            lblServicesHistory.Parent?.Controls.Remove(lblServicesHistory);
            Controls.Clear();
            BackColor = HomeHeroTheme.Canvas;
            MinimumSize = new Size(900, 600);
            WindowState = FormWindowState.Maximized;
            Text = "HomeHero | Service history";

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
                Text = "Your completed services",
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            HomeHeroTheme.StyleButton(btnBack, true);
            btnBack.Dock = DockStyle.Fill;
            btnBack.Text = "Back to dashboard";
            btnBack.Margin = new Padding(8, 12, 0, 12);
            headerLayout.Controls.Add(btnBack, 1, 0);
            header.Controls.Add(headerLayout);

            HomeHeroDataGridCard tableCard = new("Service history", dgvServiceHistory)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(22)
            };
            lblServicesHistory.Dock = DockStyle.Fill;
            lblServicesHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblServicesHistory.ForeColor = HomeHeroTheme.Muted;
            tableCard.AddActionControl(lblServicesHistory);
            TableLayoutPanel root = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(tableCard, 0, 1);
            Controls.Add(root);
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
