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
        }

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
            frmHomeHeroRegistration createAccountPage = new frmHomeHeroRegistration();
            this.Hide();
            createAccountPage.Show();
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
