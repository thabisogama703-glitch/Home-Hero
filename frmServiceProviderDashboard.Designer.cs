namespace Home_Hero
{
    partial class frmServiceProviderDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// The dashboard is built in code (see BuildUi in frmServiceProviderDashboard.cs),
        /// the same way the Administrator screens are, so the designer only holds the shell.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SuspendLayout();
            // 
            // frmServiceProviderDashboard
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1400, 860);
            Name = "frmServiceProviderDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeHero | Service Provider Dashboard";
            ResumeLayout(false);
        }

        #endregion
    }
}
