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

            string filePath = "active_requests.json";

            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);

                    var requests = JsonSerializer.Deserialize<List<MaintenanceRequest>>(jsonString);

                    dgvActiveRequests.DataSource = requests;
                }
                else
                {
                    MessageBox.Show("No saved request file found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error loading active requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
