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
            LoadRequestsToGrid();

        }
        private void LoadRequestsToGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Request Number");
            dt.Columns.Add("Customer ID");
            dt.Columns.Add("Service Category");
            dt.Columns.Add("Problem Description");
            dt.Columns.Add("Property Address");
            dt.Columns.Add("Preferred Date");
            dt.Columns.Add("Preferred Time");
            dt.Columns.Add("Status");

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "requests.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');
                    if (parts.Length >= 8)
                    {
                        dt.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]);
                    }
                }
            }

            dgvRequests.DataSource = dt;
        }



        private void btnCancelRequests_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to cancel.");
                return;
            }
            string reqNo = dgvRequests.SelectedRows[0].Cells[0].Value.ToString();
            UpdateStatus(reqNo, "CANCELLED");
        }

        private void btnApproveRequests_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a request to approve.");
                return;
            }

            string reqNo = dgvRequests.SelectedRows[0].Cells[0].Value.ToString();
            UpdateStatus(reqNo, "APPROVED");
        }
        private void UpdateStatus(string requestNo, string newStatus)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "requests.txt");
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(requestNo + "|"))
                {
                    string[] parts = lines[i].Split('|');
                    parts[7] = newStatus; 
                    lines[i] = string.Join("|", parts);
                    break;
                }
            }

            File.WriteAllLines(filePath, lines);
            LoadRequestsToGrid(); 
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }
    }
}
