using Home_Hero;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace HomeHero
{
    public partial class frmCustomerDashboard : Form
    {
        List<MaintenanceRequest> serviceRequests = new List<MaintenanceRequest>();

        public frmCustomerDashboard()
        {
            InitializeComponent();

            dgvActiveRequests.DataSource = serviceRequests;

        }


        // Working Part
        private void btnNewServiceRequest_Click_1(object sender, EventArgs e)
        {
            CreateRequestForm requestForm = new CreateRequestForm();
            requestForm.ShowDialog();
        }

        public void btnTrackRequest_Click_1(object sender, EventArgs e)
        {
            RequestTrackingForm requestTracking = new RequestTrackingForm();
            requestTracking.Show();
        }


        private void BtnActiceRequests_Click(object sender, EventArgs e)
        {

        }

        private void btnServiceHistory_Click(object sender, EventArgs e)
        {

        }

        private void frmCustomerDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
