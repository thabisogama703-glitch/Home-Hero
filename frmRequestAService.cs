using HomeHero;
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
    public partial class frmRequestAService : Form
    {
        public frmRequestAService()
        {
            InitializeComponent();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            frmHomeHeroHomepage homePage = new frmHomeHeroHomepage();
            this.Close();
            homePage.Show();


        }

        private void btnCustomerDashboard_Click(object sender, EventArgs e)
        {
            frmCustomerDashboard Customerdashboard = new frmCustomerDashboard();
            this.Hide();
            Customerdashboard.Show();
        }

        private void frmRequestAService_Load(object sender, EventArgs e)
        {

        }

        private void pnlServiceRequest_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
