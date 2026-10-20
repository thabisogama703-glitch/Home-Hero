using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Home_Hero
{
    internal sealed class AvailableRequestsDialog : FitForm
    {
        private readonly DataGridView requestsGrid = new DataGridView();
        private readonly ModernButton claimButton = new ModernButton();
        public string? SelectedRequestNumber { get; private set; }

        public AvailableRequestsDialog(IReadOnlyList<MaintenanceRequest> requests)
        {
            Text = "Available service requests";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(760, 460);
            ClientSize = new Size(920, 560);
            BackColor = Theme.Bg;

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.Padding = new Padding(20);
            layout.ColumnCount = 1;
            layout.RowCount = 3;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

            Label intro = Theme.MakeLabel(
                "Choose an approved, unassigned request to add to your jobs.",
                10F, FontStyle.Regular, Theme.Muted);
            intro.Dock = DockStyle.Fill;
            intro.TextAlign = ContentAlignment.MiddleLeft;

            requestsGrid.Dock = DockStyle.Fill;
            requestsGrid.AllowUserToAddRows = false;
            requestsGrid.AllowUserToDeleteRows = false;
            requestsGrid.AllowUserToResizeRows = false;
            requestsGrid.ReadOnly = true;
            requestsGrid.MultiSelect = false;
            requestsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            requestsGrid.RowHeadersVisible = false;
            requestsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            requestsGrid.BackgroundColor = Color.White;
            requestsGrid.BorderStyle = BorderStyle.None;
            requestsGrid.EnableHeadersVisualStyles = false;
            requestsGrid.ColumnHeadersHeight = 40;
            requestsGrid.RowTemplate.Height = 48;
            requestsGrid.Columns.Add(Column("Request", 16));
            requestsGrid.Columns.Add(Column("Service", 18));
            requestsGrid.Columns.Add(Column("Customer", 22));
            requestsGrid.Columns.Add(Column("Date", 18));
            requestsGrid.Columns.Add(Column("Problem", 34));
            requestsGrid.SelectionChanged += delegate { claimButton.Enabled = requestsGrid.SelectedRows.Count > 0; };
            requestsGrid.CellDoubleClick += delegate { ClaimSelected(); };

            foreach (MaintenanceRequest request in requests)
            {
                int row = requestsGrid.Rows.Add(
                    request.RequestNumber,
                    request.ServiceCategory,
                    request.CustomerId,
                    request.PreferredDate.ToString("dd MMM yyyy"),
                    request.ProblemDescription);
                requestsGrid.Rows[row].Tag = request.RequestNumber;
            }

            FlowLayoutPanel buttons = new FlowLayoutPanel();
            buttons.Dock = DockStyle.Fill;
            buttons.FlowDirection = FlowDirection.RightToLeft;
            buttons.WrapContents = false;

            ModernButton cancel = new ModernButton();
            cancel.Text = "Close";
            cancel.Outline = true;
            cancel.BaseColor = Theme.Navy;
            cancel.Size = new Size(120, 42);
            cancel.DialogResult = DialogResult.Cancel;
            cancel.Margin = new Padding(10, 6, 0, 0);

            claimButton.Text = "Claim request";
            claimButton.Size = new Size(150, 42);
            claimButton.Margin = new Padding(0, 6, 0, 0);
            claimButton.Enabled = false;
            claimButton.Click += delegate { ClaimSelected(); };

            buttons.Controls.Add(cancel);
            buttons.Controls.Add(claimButton);
            layout.Controls.Add(intro, 0, 0);
            layout.Controls.Add(requestsGrid, 0, 1);
            layout.Controls.Add(buttons, 0, 2);
            Controls.Add(layout);
            AcceptButton = claimButton;
            CancelButton = cancel;

            if (requestsGrid.Rows.Count > 0)
            {
                requestsGrid.Rows[0].Selected = true;
                claimButton.Enabled = true;
            }
        }

        private static DataGridViewTextBoxColumn Column(string name, float weight)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = name.ToUpperInvariant(),
                FillWeight = weight,
                MinimumWidth = 80,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        private void ClaimSelected()
        {
            if (requestsGrid.SelectedRows.Count == 0) return;
            SelectedRequestNumber = Convert.ToString(requestsGrid.SelectedRows[0].Tag);
            if (string.IsNullOrWhiteSpace(SelectedRequestNumber)) return;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
