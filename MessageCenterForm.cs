using HomeHero_2;
using Krypton.Toolkit;

namespace Home_Hero
{
    public sealed class MessageCenterForm : Form
    {
        private readonly string currentEmail;
        private readonly bool isProvider;
        private readonly string providerDisplayName;
        private readonly List<MaintenanceRequest> requests;
        private readonly ComboBox cmbRequest = new();
        private readonly ComboBox cmbProvider = new();
        private readonly Label lblProvider = new();
        private readonly RichTextBox txtConversation = new();
        private readonly KryptonTextBox txtMessage = new();
        private readonly KryptonButton btnSend = new();
        private readonly KryptonButton btnRefresh = new();
        private readonly Label lblEmpty = new();

        public MessageCenterForm(
            string currentEmail,
            bool isProvider,
            IEnumerable<MaintenanceRequest> requests,
            string providerDisplayName = "")
        {
            this.currentEmail = currentEmail;
            this.isProvider = isProvider;
            this.providerDisplayName = providerDisplayName;
            this.requests = requests.ToList();

            InitializeComponent();
            LoadConversationOptions();
        }

        private void InitializeComponent()
        {
            Text = "HomeHero Messages";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(1100, 600);
            Size = new Size(1100, 720);
            BackColor = Color.FromArgb(245, 247, 251);

            Panel header = new()
            {
                BackColor = Color.FromArgb(0, 0, 64),
                Dock = DockStyle.Top,
                Height = 76
            };
            header.Controls.Add(new Label
            {
                Text = isProvider ? "Customer messages" : "Message your service provider",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(24, 20)
            });

            Panel selectors = new()
            {
                Dock = DockStyle.Top,
                Height = 78,
                Padding = new Padding(20, 12, 20, 8),
                BackColor = Color.White
            };
            selectors.Controls.Add(new Label
            {
                Text = isProvider ? "Conversation" : "Request",
                AutoSize = true,
                Location = new Point(20, 8)
            });
            cmbRequest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequest.Location = new Point(20, 32);
            cmbRequest.Size = new Size(400, 30);
            cmbRequest.SelectedIndexChanged += (_, _) => RefreshConversation();
            selectors.Controls.Add(cmbRequest);

            lblProvider.Text = "Service provider";
            lblProvider.AutoSize = true;
            lblProvider.Location = new Point(450, 8);
            selectors.Controls.Add(lblProvider);

            cmbProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProvider.Location = new Point(450, 32);
            cmbProvider.Size = new Size(400, 30);
            cmbProvider.SelectedIndexChanged += (_, _) => RefreshConversation();
            selectors.Controls.Add(cmbProvider);

            txtConversation.ReadOnly = true;
            txtConversation.BackColor = Color.White;
            txtConversation.BorderStyle = BorderStyle.FixedSingle;
            txtConversation.Font = new Font("Segoe UI", 10F);
            txtConversation.Location = new Point(20, 174);
            txtConversation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtConversation.Size = new Size(1040, 425);

            lblEmpty.Text = "Choose a request and provider to start a conversation.";
            lblEmpty.ForeColor = Color.DimGray;
            lblEmpty.AutoSize = true;
            lblEmpty.Location = new Point(32, 186);
            lblEmpty.Visible = false;

            txtMessage.Multiline = true;
            txtMessage.Location = new Point(20, 620);
            txtMessage.Size = new Size(850, 62);
            txtMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.StateCommon.Border.Rounding = 8;

            btnSend.Text = "Send message";
            btnSend.Location = new Point(885, 620);
            btnSend.Size = new Size(175, 62);
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 0);
            btnSend.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 0);
            btnSend.StateCommon.Content.ShortText.Color1 = Color.White;
            btnSend.StateCommon.Border.Rounding = 8;
            btnSend.Click += BtnSend_Click;

            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(880, 32);
            btnRefresh.Size = new Size(160, 30);
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.StateCommon.Back.Color1 = Color.FromArgb(0, 0, 64);
            btnRefresh.StateCommon.Back.Color2 = Color.FromArgb(0, 0, 64);
            btnRefresh.StateCommon.Content.ShortText.Color1 = Color.White;
            btnRefresh.StateCommon.Border.Rounding = 6;
            btnRefresh.Click += (_, _) =>
            {
                btnSend.Enabled = true;
                LoadConversationOptions();
            };

            Controls.Add(header);
            Controls.Add(selectors);
            Controls.Add(txtConversation);
            Controls.Add(lblEmpty);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            selectors.Controls.Add(btnRefresh);
        }

        private void LoadConversationOptions()
        {
            cmbRequest.Items.Clear();
            cmbProvider.Items.Clear();
            lblEmpty.Visible = false;

            try
            {
                if (isProvider)
                {
                    lblProvider.Visible = false;
                    cmbProvider.Visible = false;
                    cmbRequest.Items.AddRange(GetProviderThreads().Cast<object>().ToArray());
                    cmbRequest.DisplayMember = nameof(MessageThreadOption.DisplayText);
                    if (cmbRequest.Items.Count > 0)
                    {
                        cmbRequest.SelectedIndex = 0;
                    }
                    else
                    {
                        lblEmpty.Text = "No conversations or assigned requests are available yet.";
                        lblEmpty.Visible = true;
                    }

                    return;
                }

                lblProvider.Visible = true;
                cmbProvider.Visible = true;
                cmbRequest.DisplayMember = nameof(MaintenanceRequest.RequestNumber);
                cmbRequest.Items.AddRange(requests.ToArray());
                cmbProvider.DisplayMember = nameof(ServiceProvider.FirstName);
                cmbProvider.Items.AddRange(CustomerRepository.LoadRegisteredServiceProviders().Cast<object>().ToArray());
                if (cmbRequest.Items.Count > 0)
                {
                    cmbRequest.SelectedIndex = 0;
                }

                if (cmbProvider.Items.Count > 0)
                {
                    cmbProvider.SelectedIndex = 0;
                }
                else
                {
                    lblEmpty.Text = "No registered service providers are available yet.";
                    lblEmpty.Visible = true;
                }

                if (cmbRequest.Items.Count == 0)
                {
                    lblEmpty.Text = "Create a service request before starting a conversation.";
                    lblEmpty.Visible = true;
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Text.Json.JsonException)
            {
                lblEmpty.Text = "Conversation data could not be loaded.";
                lblEmpty.Visible = true;
                btnSend.Enabled = false;
                MessageBox.Show(
                    $"Conversation data could not be loaded: {ex.Message}",
                    "Message Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private List<MessageThreadOption> GetProviderThreads()
        {
            List<MessageThreadOption> threads = MessageRepository.LoadMessages()
                .Where(message => string.Equals(
                    message.ProviderEmail,
                    currentEmail,
                    StringComparison.OrdinalIgnoreCase))
                .Select(message => new MessageThreadOption(
                    message.RequestNumber,
                    message.CustomerEmail,
                    currentEmail))
                .ToList();

            foreach (MaintenanceRequest request in requests)
            {
                bool isAssignedToProvider =
                    string.Equals(request.AssignedProviderId, currentEmail, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(request.AssignedProviderId, providerDisplayName, StringComparison.OrdinalIgnoreCase);

                if (isAssignedToProvider &&
                    !threads.Any(thread =>
                        thread.RequestNumber == request.RequestNumber &&
                        string.Equals(thread.CustomerEmail, request.CustomerId, StringComparison.OrdinalIgnoreCase)))
                {
                    threads.Add(new MessageThreadOption(
                        request.RequestNumber,
                        request.CustomerId,
                        currentEmail));
                }
            }

            return threads
                .GroupBy(thread => $"{thread.RequestNumber}|{thread.CustomerEmail}", StringComparer.OrdinalIgnoreCase)
                .Select(group => group.First())
                .OrderBy(thread => thread.RequestNumber)
                .ToList();
        }

        private void RefreshConversation()
        {
            txtConversation.Clear();
            MessageThreadOption? thread = GetSelectedThread();
            if (thread == null)
            {
                return;
            }

            try
            {
                foreach (MessageRecord message in MessageRepository.LoadConversation(
                    thread.RequestNumber,
                    thread.CustomerEmail,
                    thread.ProviderEmail))
                {
                    string sender = string.Equals(message.SenderEmail, currentEmail, StringComparison.OrdinalIgnoreCase)
                        ? "You"
                        : message.SenderEmail;
                    txtConversation.AppendText(
                        $"{sender}  ·  {message.SentAt:g}{Environment.NewLine}{message.Body}{Environment.NewLine}{Environment.NewLine}");
                }

                txtConversation.SelectionStart = txtConversation.TextLength;
                txtConversation.ScrollToCaret();
                lblEmpty.Visible = txtConversation.TextLength == 0;
                if (lblEmpty.Visible)
                {
                    lblEmpty.Text = "Start the conversation with a message.";
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Text.Json.JsonException)
            {
                MessageBox.Show(
                    $"Messages could not be loaded: {ex.Message}",
                    "Message Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnSend_Click(object? sender, EventArgs e)
        {
            MessageThreadOption? thread = GetSelectedThread();
            string body = txtMessage.Text.Trim();
            if (thread == null || string.IsNullOrWhiteSpace(body))
            {
                MessageBox.Show(
                    "Choose a conversation and enter a message before sending.",
                    "Message Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MessageRepository.SendMessage(
                    thread.RequestNumber,
                    thread.CustomerEmail,
                    thread.ProviderEmail,
                    currentEmail,
                    body);
                txtMessage.Clear();
                RefreshConversation();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Text.Json.JsonException)
            {
                MessageBox.Show(
                    $"Your message could not be saved: {ex.Message}",
                    "Message Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private MessageThreadOption? GetSelectedThread()
        {
            if (isProvider)
            {
                return cmbRequest.SelectedItem as MessageThreadOption;
            }

            if (cmbRequest.SelectedItem is not MaintenanceRequest request ||
                cmbProvider.SelectedItem is not ServiceProvider provider)
            {
                return null;
            }

            return new MessageThreadOption(request.RequestNumber, currentEmail, provider.Email);
        }

        private sealed class MessageThreadOption
        {
            public MessageThreadOption(string requestNumber, string customerEmail, string providerEmail)
            {
                RequestNumber = requestNumber;
                CustomerEmail = customerEmail;
                ProviderEmail = providerEmail;
            }

            public string RequestNumber { get; }
            public string CustomerEmail { get; }
            public string ProviderEmail { get; }
            public string DisplayText => $"{RequestNumber} — {CustomerEmail}";
        }
    }
}
