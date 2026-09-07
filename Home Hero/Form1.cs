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
            frmLogin LoginPage = new frmLogin();
            this.Hide();
            LoginPage.Show();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount createAccountPage = new frmCreateAccount();
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
            adminPage.Show();
        }

        private void frmHomeHeroHomepage_Load(object sender, EventArgs e)
        {

        }
    }
}
