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
            BuildWorkspaceLayout();
        }

        private void BuildWorkspaceLayout()
        {
            dgvActiveRequests.Parent?.Controls.Remove(dgvActiveRequests);
            btnBack.Parent?.Controls.Remove(btnBack);
            lblActiveRequests.Parent?.Controls.Remove(lblActiveRequests);
            Controls.Clear();
            BackColor = HomeHeroTheme.Canvas;
            MinimumSize = new Size(900, 600);
            WindowState = FormWindowState.Maximized;
            Text = "HomeHero | Active requests";

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
                Text = "Your active service requests",
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            HomeHeroTheme.StyleButton(btnBack, true);
            btnBack.Dock = DockStyle.Fill;
            btnBack.Text = "Back to dashboard";
            btnBack.Margin = new Padding(8, 12, 0, 12);
            headerLayout.Controls.Add(btnBack, 1, 0);
            header.Controls.Add(headerLayout);

            HomeHeroDataGridCard tableCard = new("Active requests", dgvActiveRequests)
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(22)
            };
            lblActiveRequests.Dock = DockStyle.Fill;
            lblActiveRequests.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActiveRequests.ForeColor = HomeHeroTheme.Muted;
            tableCard.AddActionControl(lblActiveRequests);

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
