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
    }
}
