using Home_Hero;
using HomeHero_2;
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
            frmCreateRequest requestForm = new frmCreateRequest();
            requestForm.ShowDialog();
        }

        public void btnTrackRequest_Click_1(object sender, EventArgs e)
        {
            frmRequestTracking requestTracking = new frmRequestTracking();
            requestTracking.ShowDialog();
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

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?","Logging Out",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                frmHomeHeroHomepage frmHomeHeroHomepage = new frmHomeHeroHomepage();
                this.Hide();
                frmHomeHeroHomepage.Show();
            }
            else
            {

            }


        }
    }
}
