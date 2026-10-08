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
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmHomeHeroRegistration registrationForm = new frmHomeHeroRegistration(); 
            this.Hide();
            registrationForm.Show();

        }

        private void btnSpecialist_Click(object sender, EventArgs e)
        {
            frmServiceProviderLogin specialistLogin = new frmServiceProviderLogin();
            specialistLogin.Show();
        }
    }
}
