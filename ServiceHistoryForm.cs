using Home_Hero;
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

            foreach (object[] row in AppSettings.DefaultServiceHistory)
            {
                dgvServiceHistory.Rows.Add(row);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}
