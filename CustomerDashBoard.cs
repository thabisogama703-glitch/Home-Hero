using Home_Hero;
using HomeHero_2;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using MessageBox = System.Windows.Forms.MessageBox;

namespace HomeHero
{
    public partial class frmCustomerDashboard : FitForm
    {
        List<MaintenanceRequest> serviceRequests = new List<MaintenanceRequest>();

        public frmCustomerDashboard()
        {
            InitializeComponent();
            ScrollWholeForm = false;   // this page scrolls its own body under a fixed header
            BuildModernUi();

        }


        // Working Part
        private void btnNewServiceRequest_Click_1(object sender, EventArgs e)
        {
            frmCreateRequest requestForm = new frmCreateRequest();
            requestForm.Show();
            this.Hide();
        }

        public void btnTrackRequest_Click_1(object sender, EventArgs e)
        {
            frmRequestTracking requestTracking = new frmRequestTracking();
            requestTracking.Show();
            this.Hide();
        }



        private void BtnActiceRequests_Click(object sender, EventArgs e)
        {
            // Only this customer's own requests
            string customerId = CustomerSession.CustomerId;
            List<MaintenanceRequest> requests = DataManager.LoadRequests()
                .Where(r => r.CustomerId == customerId)
                .ToList();
            frmActiveRequest activeRequest = new frmActiveRequest(requests);
            activeRequest.ShowDialog();
        }

        private void btnServiceHistory_Click(object sender, EventArgs e)
        {
            ServiceHistoryForm serviceHistory = new ServiceHistoryForm();
            serviceHistory.ShowDialog();
        }

        private void frmCustomerDashboard_Load(object sender, EventArgs e)
        {
            // greeting, live numbers, recent activity and the entrance animation
            StartAnimations();
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logging Out", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Home_Hero.AdminUi.SignOutAndGoHome(this);
            }
            else
            {

            }


        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void lblJobsDoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerDashboardTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            frmHomeHeroHomepage backtoHome = new frmHomeHeroHomepage();
            this.Hide();
            backtoHome.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
