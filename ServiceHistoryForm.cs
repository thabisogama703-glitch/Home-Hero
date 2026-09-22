using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeHero
{
    public partial class ServiceHistoryForm : Form
    {
        public ServiceHistoryForm()
        {
            InitializeComponent();

            dgvServiceHistory.Rows.Add("REQ101",
                "Painting", "08/09/2026",
                "R1500", "Completed");

            dgvServiceHistory.Rows.Add("REQ107",
                "Appliance Repair", "26/08/2026",
                "R700", "Completed");

            dgvServiceHistory.Rows.Add("REQ704",
                "Plumbing", "18/08/2026",
                "R450", "Completed");

            dgvServiceHistory.Rows.Add("REQ105",
                "General Maintance", "15/07/2026",
                "R390", "Completed");

            dgvServiceHistory.Rows.Add("REQ112",
                "Electrical", "07/07/2026",
                "R400", "Completed");

            dgvServiceHistory.Rows.Add("REQ641",
                "Plumbing", "27/06/2026",
                "R520", "Completed");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
