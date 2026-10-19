using HomeHero_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class frmProvidersOverview : Form
    {
        public frmProvidersOverview()
        {
            InitializeComponent();
            label3.Text = GetStartingPriceText("Windows and Doors");
            label5.Text = GetStartingPriceText("Plumbing");
            label9.Text = GetStartingPriceText("Electrical");
            label12.Text = GetStartingPriceText("HVAC");
            label15.Text = GetStartingPriceText("Roofing");
            label18.Text = GetStartingPriceText("Landscaping");
            label21.Text = GetStartingPriceText("Painting");
            label24.Text = GetStartingPriceText("Deep Cleaning");
        }

        private static string GetStartingPriceText(string serviceName) =>
            $"From R{HomeServiceCatalog.GetStartingPrice(serviceName):0}";

        private void lnklblHowItWorks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHowItWorksOverview howItWorksOverview = new frmHowItWorksOverview();
            howItWorksOverview.Show();
            this.Hide();
        }

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmServicesOverview servicesOverview = new frmServicesOverview();
            servicesOverview.Show();
            this.Hide();
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

        private void lnklblHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHomeHeroHomepage frmHomeHeroHomepage = new frmHomeHeroHomepage();
            frmHomeHeroHomepage.Show();
            this.Hide();
        }
    }
}
