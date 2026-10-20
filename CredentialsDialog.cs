using System.Diagnostics;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    // =====================================================================
    //  PROVIDER LOGIN DETAILS
    //  Shown after the admin adds a provider (or resets their password).
    //  Instead of a plain message box the admin can copy the password,
    //  copy email + password together, or open a ready-written e-mail to
    //  the provider with the login details already filled in.
    // =====================================================================
    internal class CredentialsDialog : FitForm
    {
        private readonly string providerName;
        private readonly string email;
        private readonly string password;
        private readonly string accountType;

        public CredentialsDialog(string providerName, string email, string password, bool isReset, string accountType = "service provider")
        {
            this.providerName = providerName;
            this.email = email;
            this.password = password;
            this.accountType = accountType;

            Text = accountType + " login details";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.White;
            ClientSize = new Size(540, 410);

            Label title = Theme.MakeLabel(isReset ? "New password created" : accountType == "customer" ? "Request submitted successfully" : "Provider added successfully", 16F, FontStyle.Bold, Theme.Navy);
            title.Location = new Point(28, 24);

            Label sub = Theme.MakeLabel(providerName + " can sign in with the details below.", 10F, FontStyle.Regular, Theme.Muted);
            sub.Location = new Point(30, 62);

            // ---- email ----
            Label emailCap = Theme.MakeLabel("EMAIL  (USERNAME)", 8F, FontStyle.Bold, Theme.Muted);
            emailCap.Location = new Point(30, 108);

            Label emailVal = Theme.MakeLabel(email, 12F, FontStyle.Bold, Theme.Text);
            emailVal.AutoSize = false;
            emailVal.AutoEllipsis = true;
            emailVal.Size = new Size(480, 28);
            emailVal.Location = new Point(30, 128);

            // ---- temporary password ----
            Label pwCap = Theme.MakeLabel("TEMPORARY PASSWORD", 8F, FontStyle.Bold, Theme.Muted);
            pwCap.Location = new Point(30, 176);

            SoftBox pwBox = new SoftBox();
            pwBox.FillColor = Theme.OrangeSoft;
            pwBox.BorderColor = Theme.OrangeSoft;
            pwBox.Radius = 12;
            pwBox.Size = new Size(482, 68);
            pwBox.Location = new Point(28, 198);

            TextBox pwText = new TextBox();
            pwText.Text = password;
            pwText.ReadOnly = true;
            pwText.BorderStyle = BorderStyle.None;
            pwText.BackColor = Theme.OrangeSoft;
            pwText.ForeColor = Theme.Orange;
            pwText.Font = new Font("Consolas", 20F, FontStyle.Bold);
            pwText.Width = 320;
            pwText.Location = new Point(20, (pwBox.Height - pwText.Height) / 2);
            pwText.GotFocus += delegate { pwText.SelectAll(); };

            ModernButton copyPw = new ModernButton();
            copyPw.Text = "Copy";
            copyPw.Size = new Size(110, 42);
            copyPw.Location = new Point(pwBox.Width - 110 - 14, (pwBox.Height - 42) / 2);
            copyPw.Click += delegate { CopyText(password, copyPw, "Copy"); };

            pwBox.Controls.Add(pwText);
            pwBox.Controls.Add(copyPw);

            Label info = Theme.MakeLabel(
                accountType == "customer"
                    ? "A customer account has been created for this request. Share these login details with the customer; use Email to customer to prepare an email."
                    : "The provider signs in from the HomeHero login screen with this email and password, and will then see the jobs assigned to them.",
                9.5F, FontStyle.Regular, Theme.Muted);
            info.AutoSize = false;
            info.Size = new Size(482, 44);
            info.Location = new Point(30, 282);

            // ---- actions ----
            ModernButton copyAll = new ModernButton();
            copyAll.Text = "Copy details";
            copyAll.Outline = true;
            copyAll.BaseColor = Theme.Navy;
            copyAll.Size = new Size(140, 48);
            copyAll.Location = new Point(28, 340);
            copyAll.Click += delegate { CopyText("Email: " + email + Environment.NewLine + "Temporary password: " + password, copyAll, "Copy details"); };

            ModernButton mail = new ModernButton();
            mail.Text = "Email to " + accountType;
            mail.Size = new Size(190, 48);
            mail.Location = new Point(180, 340);
            mail.Click += delegate { OpenEmail(); };

            ModernButton done = new ModernButton();
            done.Text = "Done";
            done.Outline = true;
            done.BaseColor = Theme.Navy;
            done.Size = new Size(110, 48);
            done.Location = new Point(382, 340);
            done.Click += delegate { DialogResult = DialogResult.OK; Close(); };

            Controls.Add(title);
            Controls.Add(sub);
            Controls.Add(emailCap);
            Controls.Add(emailVal);
            Controls.Add(pwCap);
            Controls.Add(pwBox);
            Controls.Add(info);
            Controls.Add(copyAll);
            Controls.Add(mail);
            Controls.Add(done);
            AcceptButton = done;
            CancelButton = done;
        }

        private void CopyText(string text, ModernButton button, string normalText)
        {
            try
            {
                Clipboard.SetText(text);
                button.Text = "Copied \u2713";
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Interval = 1600;
                t.Tick += delegate { t.Stop(); t.Dispose(); button.Text = normalText; };
                t.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not access the clipboard. Please write the details down:\n\n" + text,
                    "Copy failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenEmail()
        {
            string first = providerName.Split(' ')[0];
            string subject = "Your HomeHero " + accountType + " login details";
            string body =
                "Hi " + first + "," + "\r\n\r\n" +
                "Your HomeHero " + accountType + " account is ready." + "\r\n\r\n" +
                "Email: " + email + "\r\n" +
                "Temporary password: " + password + "\r\n\r\n" +
                "Open HomeHero and enter these details on the login screen." + "\r\n\r\n" +
                "Regards," + "\r\n" + "HomeHero Admin";

            string link = "mailto:" + email + "?subject=" + Uri.EscapeDataString(subject) + "&body=" + Uri.EscapeDataString(body);
            try
            {
                Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
            }
            catch (Exception)
            {
                try { Clipboard.SetText(body); } catch (Exception) { }
                MessageBox.Show("No mail app was found, so the message was copied to your clipboard instead.\nPaste it into an email to " + email + ".",
                    "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
