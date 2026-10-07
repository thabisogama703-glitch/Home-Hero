using HomeHero_2;
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
            LoadProvidersToGrid(DataManager.LoadServiceProviders());
        }
        private void LoadProvidersToGrid(IEnumerable<ServiceProvider> providers)
        {
            var providers_ = DataManager.LoadServiceProviders();

            DataTable table = new DataTable();

            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Columns.Add("Phone");
            table.Columns.Add("Service Area");
            table.Columns.Add("Specialisation");
            table.Columns.Add("Jobs");

            foreach (var p in providers)
            {
                string name = p.FirstName + " " + p.LastName;

                string specialisation = p.Specialisation == null ||
                                        p.Specialisation.Count == 0
                    ? "None"
                    : string.Join(", ", p.Specialisation);

                int jobs = p.Assignedjobs == null
                    ? 0
                    : p.Assignedjobs.Count;

                table.Rows.Add(
                    name,
                    p.Email,
                    p.PhoneNumber,
                    p.Location,
                    specialisation,
                    jobs
                );
            }

            dgvProviders.DataSource = null;
            dgvProviders.DataSource = table;
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

            var providers = DataManager.LoadServiceProviders();

            if (!string.IsNullOrEmpty(searchText))
            {
                var filtered = providers
                    .Where(p =>
                        (p.FirstName + " " + p.LastName)
                        .Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                LoadProvidersToGrid(filtered);

                if (filtered.Count == 0)
                {
                    MessageBox.Show("No matching providers found.","Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                LoadProvidersToGrid(providers);
            }
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            if (dgvProviders.CurrentRow == null)
            {
                MessageBox.Show("Please select a provider first.");
                return;
            }

            string providerName =dgvProviders.CurrentRow.Cells["Name"].Value?.ToString();

            if (string.IsNullOrEmpty(providerName))
                return;
            var providers = DataManager.LoadServiceProviders();

            ServiceProvider provider = providers.FirstOrDefault(p =>(p.FirstName + " " + p.LastName).Equals(providerName, StringComparison.OrdinalIgnoreCase));

            if (provider == null)
            {
                MessageBox.Show("Provider could not be found.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to remove " + providerName + "?","Remove Provider",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DataManager.DeleteServiceProvider(provider.UserId);

                LoadProvidersToGrid(DataManager.LoadServiceProviders());

                MessageBox.Show("Provider removed successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnAddProvider__Click(object sender, EventArgs e)
        {
            AddProvider addProviderForm = new AddProvider();
            addProviderForm.Show();
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
