using HomeHero;
using HomeHero_2;

namespace Home_Hero
{
    public partial class frmHomeHeroHomepage : Form
    {
        public frmHomeHeroHomepage()
        {
            InitializeComponent();
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
            AdminDashboard adminPage = new AdminDashboard();
            this.Hide();
            adminPage.FormClosed += (s, args) => this.Close();
            adminPage.Show();
        }

        private void frmHomeHeroHomepage_Load(object sender, EventArgs e)
        {

        }

        private void lnklblServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
