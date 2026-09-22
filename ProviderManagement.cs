using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmProviderManagement : Form
    {
        public frmProviderManagement()
        {
            InitializeComponent();
            LoadProvidersToGrid();
        }
        private void LoadProvidersToGrid()
        {
            var providers = DataManager.LoadServiceProviders();

            var table = new System.Data.DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Specialisation");
            table.Columns.Add("Phone");
            table.Columns.Add("Jobs");

            foreach (var p in providers)
            {
                string spec = p.Specialisation != null ? string.Join(", ", p.Specialisation) : "None";
                table.Rows.Add(p.FirstName + " " + p.LastName, spec, p.PhoneNumber, p.Assignedjobs.Count);
            }

            dgvProviders.DataSource = table;
            dgvProviders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProviderManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchText = txtSearchProvider.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                var providers = DataManager.LoadServiceProviders();

                var filtered = providers
                    .Where(p => (p.FirstName + " " + p.LastName).Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                dgvProviders.DataSource = null;
                dgvProviders.DataSource = filtered;

                if (filtered.Count == 0)
                {
                    MessageBox.Show("No matching providers found.");
                }
            }
            else
            {
                dgvProviders.DataSource = null;
                dgvProviders.DataSource = DataManager.LoadServiceProviders();
            }
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProvider__Click(object sender, EventArgs e)
        {

        }

        private void lnklblReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReports reports = new frmReports();
            this.Hide();
            reports.Show();
        }

        private void lnklblOverView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminDashboard adminDashboard = new frmAdminDashboard();
            this.Hide();
            adminDashboard.Show();
        }

        private void lnklblRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestManagement requestManagement = new RequestManagement();
            this.Hide();
            requestManagement.Show();
        }
    }
}
