using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Home_Hero
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnViewRequests_Click(object sender, EventArgs e)
        {
            AdminDashboard adminPage = new AdminDashboard();
            adminPage.ShowDialog();
            this.Show();
        }

        private void btnManageProviders_Click(object sender, EventArgs e)
        {
            RequestManagement requestManagementPage = new RequestManagement();
            requestManagementPage.ShowDialog();
            this.Show();
        }

        private void btnManageServices(object sender, EventArgs e)
        {
            
        }

        private void btnManageAppointments(object sender, EventArgs e)
        {
           
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports reportsPage = new frmReports();
            reportsPage.ShowDialog();
            this.Show();
        }

        private void btnProviders_Click(object sender, EventArgs e)
        {
            ProviderManagement providerManagementPage = new ProviderManagement();
            providerManagementPage.ShowDialog();
            this.Show();
        }
    }
}
