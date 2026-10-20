using HomeHero_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Hero
{
    public partial class AddProvider : FitForm
    {
        private Label lblFormError = null!;
        private Label lblSpecCaption = null!;
        private readonly List<ChipToggle> chips = new List<ChipToggle>();
        private Point dragStart;
        private bool dragging;

        public AddProvider()
        {
            InitializeComponent();
            BuildUi();
        }

        // ==================================================================
        //  UI CONSTRUCTION  (re-uses the designer's text boxes and buttons)
        // ==================================================================
        private void BuildUi()
        {
            SuspendLayout();
            AdminUi.UseDpiScaling(this);

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            BackColor = Color.White;
            ClientSize = new Size(820, 720);

            // keep the real specialisation list (used by validation) but hide it - the chips drive it
            if (!chkSpecialization.Items.Contains("Appliance Repair"))
                chkSpecialization.Items.Insert(3, "Appliance Repair");
            Controls.Add(chkSpecialization);
            chkSpecialization.Visible = false;

            // ---------- header ----------
            GradientPanel header = new GradientPanel();
            header.Photo = UiAssets.GetImage("715579828291516585");
            header.Dock = DockStyle.Top;
            header.Height = 104;

            Label title = Theme.MakeLabel("Add Service Provider", 19F, FontStyle.Bold, Color.White);
            title.Location = new Point(34, 18);
            Label subtitle = Theme.MakeLabel("Register a new provider and choose the services they offer", 10.5F, FontStyle.Regular, Color.FromArgb(190, 205, 230));
            subtitle.Location = new Point(37, 62);

            Label close = Theme.MakeLabel("✕", 14F, FontStyle.Bold, Color.White);
            close.Cursor = Cursors.Hand;
            close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            close.Location = new Point(ClientSize.Width - 56, 22);
            close.Click += delegate { btnCancel.PerformClick(); };
            close.MouseEnter += delegate { close.ForeColor = Theme.Orange; };
            close.MouseLeave += delegate { close.ForeColor = Color.White; };

            header.Controls.Add(title);
            header.Controls.Add(subtitle);
            header.Controls.Add(close);

            // drag the borderless window by its header
            MouseEventHandler down = delegate (object? s, MouseEventArgs e) { dragging = true; dragStart = e.Location; };
            MouseEventHandler move = delegate (object? s, MouseEventArgs e)
            {
                if (!dragging) return;
                Control c = (Control)s!;
                Point screen = c.PointToScreen(e.Location);
                Location = new Point(screen.X - dragStart.X - (c == header ? 0 : c.Left), screen.Y - dragStart.Y - (c == header ? 0 : c.Top));
            };
            MouseEventHandler up = delegate { dragging = false; };
            foreach (Control c in new Control[] { header, title, subtitle })
            {
                c.MouseDown += down;
                c.MouseMove += move;
                c.MouseUp += up;
            }

            // ---------- body ----------
            Panel body = new Panel();
            body.Dock = DockStyle.Fill;
            body.BackColor = Color.White;
            body.Padding = new Padding(34, 24, 34, 22);

            TableLayoutPanel grid = new TableLayoutPanel();
            grid.Dock = DockStyle.Fill;
            grid.BackColor = Color.White;
            grid.ColumnCount = 2;
            grid.RowCount = 7;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));    // names
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));    // email + phone
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));    // service area
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));    // specialisation caption
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));    // chips
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));    // error
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));    // buttons

            txtFirstName.PlaceholderText = "e.g. Thabo";
            txtLastName.PlaceholderText = "e.g. Mokoena";
            txtEmail.PlaceholderText = "name@example.com";
            txtPhone.PlaceholderText = "10 digits, e.g. 0821234567";
            txtPhone.MaxLength = 10;
            txtPhone.KeyPress += delegate (object? s, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
            txtSeaviceArea.PlaceholderText = "Suburb or city this provider covers, e.g. Sandton";

            grid.Controls.Add(Field("First name", txtFirstName, true), 0, 0);
            grid.Controls.Add(Field("Last name", txtLastName, false), 1, 0);
            grid.Controls.Add(Field("Email address", txtEmail, true), 0, 1);
            grid.Controls.Add(Field("Phone number", txtPhone, false), 1, 1);
            Control area = Field("Service area", txtSeaviceArea, false);
            grid.Controls.Add(area, 0, 2);
            grid.SetColumnSpan(area, 2);

            lblSpecCaption = Theme.MakeLabel("SPECIALISATIONS  -  choose at least one", 8.5F, FontStyle.Bold, Theme.Muted);
            lblSpecCaption.AutoSize = false;
            lblSpecCaption.Dock = DockStyle.Fill;
            lblSpecCaption.TextAlign = ContentAlignment.BottomLeft;
            grid.Controls.Add(lblSpecCaption, 0, 3);
            grid.SetColumnSpan(lblSpecCaption, 2);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.BackColor = Color.White;
            flow.Padding = new Padding(0, 10, 0, 0);
            for (int i = 0; i < chkSpecialization.Items.Count; i++)
            {
                int index = i;
                ChipToggle chip = new ChipToggle(chkSpecialization.Items[i].ToString()!);
                chip.CheckedChanged += delegate
                {
                    chkSpecialization.SetItemChecked(index, chip.Checked);
                    UpdateSpecCaption();
                    ClearError();
                };
                chips.Add(chip);
                flow.Controls.Add(chip);
            }
            grid.Controls.Add(flow, 0, 4);
            grid.SetColumnSpan(flow, 2);

            lblFormError = Theme.MakeLabel("", 10F, FontStyle.Bold, Theme.Red);
            lblFormError.AutoSize = false;
            lblFormError.Dock = DockStyle.Fill;
            lblFormError.TextAlign = ContentAlignment.MiddleLeft;
            lblFormError.AutoEllipsis = true;
            grid.Controls.Add(lblFormError, 0, 5);
            grid.SetColumnSpan(lblFormError, 2);

            // buttons (original buttons, new look)
            btnAddProvider.Text = "Add Provider";
            btnAddProvider.BackColor = Color.Transparent;
            btnAddProvider.Size = new Size(240, 52);
            btnAddProvider.Margin = new Padding(14, 8, 0, 0);

            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Outline = true;
            btnCancel.BaseColor = Theme.Navy;
            btnCancel.Size = new Size(160, 52);
            btnCancel.Margin = new Padding(0, 8, 0, 0);

            FlowLayoutPanel buttons = new FlowLayoutPanel();
            buttons.Dock = DockStyle.Fill;
            buttons.FlowDirection = FlowDirection.RightToLeft;
            buttons.WrapContents = false;
            buttons.BackColor = Color.White;
            buttons.Controls.Add(btnAddProvider);
            buttons.Controls.Add(btnCancel);
            grid.Controls.Add(buttons, 0, 6);
            grid.SetColumnSpan(buttons, 2);

            body.Controls.Add(grid);

            // old hand-placed panel + header are replaced by the layout above
            pnlAddProvider.Dispose();
            pnlNavigationAdminPanl.Dispose();

            Controls.Add(body);
            Controls.Add(header);
            body.BringToFront();
            header.SendToBack();

            AcceptButton = btnAddProvider;
            CancelButton = btnCancel;

            // thin navy outline so the borderless window reads as a dialog
            Paint += delegate (object? s, PaintEventArgs e)
            {
                using (Pen p = new Pen(Theme.Navy, 2f))
                    e.Graphics.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
            };

            UpdateSpecCaption();
            ResumeLayout(true);
            ActiveControl = txtFirstName;
        }

        private Control Field(string caption, TextBox input, bool leftColumn)
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Fill;
            p.BackColor = Color.White;
            p.Padding = leftColumn ? new Padding(0, 0, 12, 0) : new Padding(12, 0, 0, 0);

            Label cap = Theme.MakeLabel(caption.ToUpperInvariant(), 8.5F, FontStyle.Bold, Theme.Muted);
            cap.AutoSize = false;
            cap.Dock = DockStyle.Top;
            cap.Height = 28;
            cap.TextAlign = ContentAlignment.BottomLeft;

            InputFrame frame = AdminUi.Frame(input, 200, 54);
            frame.Dock = DockStyle.Top;
            frame.Margin = new Padding(0);
            input.TextChanged += delegate { ClearError(); };

            p.Controls.Add(frame);
            p.Controls.Add(cap);
            return p;
        }

        private void UpdateSpecCaption()
        {
            int n = chkSpecialization.CheckedItems.Count;
            lblSpecCaption.Text = n == 0
                ? "SPECIALISATIONS  -  choose at least one"
                : "SPECIALISATIONS  -  " + n + " selected";
            lblSpecCaption.ForeColor = n == 0 ? Theme.Muted : Theme.Orange;
        }

        private void ShowError(string message, Control? focus)
        {
            lblFormError.Text = "⚠  " + message;
            if (focus != null) focus.Focus();
        }

        private void ClearError()
        {
            if (lblFormError != null) lblFormError.Text = "";
        }

        private static bool ValidEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                int at = email.IndexOf('@');
                return addr.Address == email && at > 0 && email.Substring(at).Contains('.') && !email.EndsWith(".");
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // ==================================================================
        //  ACTIONS  (original handler names)
        // ==================================================================
        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            ClearError();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string location = txtSeaviceArea.Text.Trim();

            if (firstName.Length == 0) { ShowError("Please enter the provider's first name.", txtFirstName); return; }
            if (lastName.Length == 0) { ShowError("Please enter the provider's last name.", txtLastName); return; }
            if (email.Length == 0) { ShowError("Please enter an email address.", txtEmail); return; }
            if (!ValidEmail(email)) { ShowError("That email address does not look valid.", txtEmail); return; }
            if (phone.Length != 10 || !long.TryParse(phone, out _)) { ShowError("Enter a valid 10-digit phone number.", txtPhone); return; }
            if (location.Length == 0) { ShowError("Please enter the area this provider serves.", txtSeaviceArea); return; }
            if (chkSpecialization.CheckedItems.Count == 0) { ShowError("Select at least one specialisation.", null); return; }

            if (AccountDirectory.Detect(email) != AccountKinds.None)
            {
                ShowError("This email address is already in use by an existing HomeHero account.", txtEmail);
                return;
            }

            List<string> specialisations = new List<string>();
            foreach (object item in chkSpecialization.CheckedItems)
            {
                specialisations.Add(item.ToString()!);
            }
            string temporaryPassword = Guid.NewGuid().ToString("N").Substring(0, 8);

            ServiceProvider provider = new ServiceProvider(firstName, lastName, email, temporaryPassword, phone, location, specialisations);

            if (!AccountDirectory.TryRegisterProvider(provider, out AccountKinds duplicateKinds, out string saveError))
            {
                ShowError(duplicateKinds != AccountKinds.None
                    ? "This email address is already in use by an existing HomeHero account."
                    : saveError, txtEmail);
                return;
            }
            using (CredentialsDialog creds = new CredentialsDialog(AdminUi.TitleCase(firstName + " " + lastName), email, temporaryPassword, false))
                creds.ShowDialog(this);
            DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // the Provider Management page is still open behind this dialog - just close it
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        public void ClearFiled()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtSeaviceArea.Clear();

            foreach (ChipToggle chip in chips) chip.Checked = false;
            chkSpecialization.ClearSelected();
        }
    }
}
