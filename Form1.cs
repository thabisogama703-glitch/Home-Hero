using HomeHero;
using HomeHero_2;

namespace Home_Hero
{
    public partial class frmHomeHeroHomepage : Form
    {
        public frmHomeHeroHomepage()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmHomeHeroLogin LoginPage = new frmHomeHeroLogin();
            this.Hide();
            LoginPage.Show();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmHomeHeroRegistration createAccountPage = new frmHomeHeroRegistration();
            this.Hide();
            createAccountPage.Show();
        }

        private void btnRequestAService_Click(object sender, EventArgs e)
        {
            frmRequestAService requestAServicePage = new frmRequestAService();
            this.Hide();
            requestAServicePage.Show();
        }

        private void btnAdministration_Click(object sender, EventArgs e)
        {
            frmAdminDashboard adminPage = new frmAdminDashboard();
            this.Hide();
            adminPage.FormClosed += (s, args) => this.Close();
            adminPage.Show();
        }

        private void frmHomeHeroHomepage_Load(object sender, EventArgs e)
        {

        }

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmServicesOverview servicesOverview = new frmServicesOverview();
            servicesOverview.Show();
            this.Hide();
        }

        private void btnFindAPro_Click(object sender, EventArgs e)
        {
            string searchedService = txtSearchForService.Text.Trim().ToLower();

            if (searchedService == "")
            {
                ValidationError.SetError(txtSearchForService, "Please enter the service name you need help on.");

            }
            else
            {
                if (searchedService.Length < 4)
                {
                    ValidationError.SetError(txtSearchForService, "The search service should not contain less than 4 charcters");
                }
                else
                {
                    ValidationError.SetError(txtSearchForService, "");
                    frmRequestAService requestAServicePage = new frmRequestAService();
                    this.Hide();
                    requestAServicePage.Show();
                }
            }
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ServiceProvider provider = new ServiceProvider(
                                           "Thabiso",
                                           "Gama",
                                           "thabisogama703@gamil.com",
                                           "@Thandolwami07",
                                           "0123456789",
                                           "22 Jan Hofmeyer Street",
                                           new List<string>()
                                       );

            frmServiceProviderDashboard providerdashboard =
                new frmServiceProviderDashboard(provider);

            providerdashboard.Show();

            this.Hide();
        }

        private void lnklblHowItWorks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHowItWorksOverview howItWorksOverview = new frmHowItWorksOverview();
            howItWorksOverview.Show();
            this.Hide();
        }
    }
}
