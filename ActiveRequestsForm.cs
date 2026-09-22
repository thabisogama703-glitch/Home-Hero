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
        public frmActiveRequest(List<MaintenanceRequest> requests)
        {
            //List<MaintenanceRequest> serviceRequests = new List<MaintenanceRequest>();
            InitializeComponent();

            dgvActiveRequests.Rows.Add("REQ001",
                "Plumbing", "Leaking kitchen tap",
                "22/09/2026", "R450", "In Progress");

            dgvActiveRequests.Rows.Add("REQ003",
                "General Maintanance", "Lawn & tree trimming",
                 "26/09/2026", "R500", "Assigned");

            dgvActiveRequests.Rows.Add("REQ023",
                "Electrical", "Faulty wall socket",
                "24/10/2026", "R680", "Pending");

            //dgvActiveRequests.AutoGenerateColumns = false;
            //dgvActiveRequests.DataSource = requests; 


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
