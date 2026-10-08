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
    public partial class frmServicesOverview : Form
    {
        public frmServicesOverview()
        {
            InitializeComponent();
        }

        private void flpAboutTheApplication_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmServicesOverview_Load(object sender, EventArgs e)
        {

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

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
