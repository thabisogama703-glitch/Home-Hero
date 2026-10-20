using HomeHero;
using HomeHero_2;
using System.Globalization;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmHomeHeroHomepage : FitForm
    {
        private readonly StatisticsService statisticsService = new StatisticsService();
        private readonly System.Windows.Forms.Timer statisticsRefreshTimer = new System.Windows.Forms.Timer();

        public frmHomeHeroHomepage()
        {
            InitializeComponent();
            statisticsRefreshTimer.Interval = 15000;
            statisticsRefreshTimer.Tick += delegate
            {
                if (Visible) UpdateStatistics();
            };
            Activated += delegate { UpdateStatistics(); };
            FormClosed += delegate { statisticsRefreshTimer.Dispose(); };
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
            lblAverageRating.Text = "Active Service Categories";
            lblAvgResponseTime.Text = "Total Customers Served";
            UpdateStatistics();
            statisticsRefreshTimer.Start();
        }

        private void UpdateStatistics()
        {
            HomePageStatistics statistics = statisticsService.GetHomePageStatistics();
            lblJobsCompletedValue.Text = statistics.CompletedJobs.ToString("N0", CultureInfo.CurrentCulture);
            lblVerifiedprosValue.Text = statistics.VerifiedProviders.ToString("N0", CultureInfo.CurrentCulture);
            lblAvgRatingValue.Text = statistics.ActiveServiceCategories.ToString("N0", CultureInfo.CurrentCulture);
            lblAverageResponseTimeValue.Text = statistics.TotalCustomersServed.ToString("N0", CultureInfo.CurrentCulture);
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
            frmProvidersOverview providersOverview = new frmProvidersOverview();
            providersOverview.Show();
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
