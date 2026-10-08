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
    public partial class frmHowItWorksOverview : Form
    {
        public frmHowItWorksOverview()
        {
            InitializeComponent();
        }

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmServicesOverview frmServices = new frmServicesOverview();
            frmServices.Show();
            this.Hide();
        }

        private void lnklblProviders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProvidersOverview providersOverview = new frmProvidersOverview();
            providersOverview.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
