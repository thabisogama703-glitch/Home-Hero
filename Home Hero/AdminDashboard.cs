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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnViewRequests_Click(object sender, EventArgs e)
        {
            RequestManagement requestManagement = new RequestManagement();
            requestManagement.ShowDialog();
        }

        private void btnManageProviders_Click(object sender, EventArgs e)
        {
            ProviderManagement providerManagement = new ProviderManagement();
            providerManagement.ShowDialog();
        }

        private void btnManageServices(object sender, EventArgs e)
        {

        }

        private void btnManageAppointments(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
=======
>>>>>>> 0a21678 (Fix issues in Home Hero)
    }
}
