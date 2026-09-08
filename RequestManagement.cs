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
    public partial class RequestManagement : Form
    {
        public RequestManagement()
        {
            InitializeComponent();
        }

        private void btnCancelRequests_Click(object sender, EventArgs e)
        {

        }

        private void btnApproveRequests_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }

        private void RequestManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
