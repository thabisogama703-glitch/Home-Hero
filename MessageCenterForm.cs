using HomeHero_2;
using Krypton.Toolkit;

namespace Home_Hero
{
    public sealed class MessageCenterForm : Form
    {
        private readonly string currentEmail;
        private readonly bool isProvider;
        private readonly string providerDisplayName;
        private List<MaintenanceRequest> requests;
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
            MinimumSize = new Size(0, 0);
            Size = new Size(1100, 720);
            BackColor = HomeHeroTheme.Canvas;

            Panel header = new()
            {
                BackColor = HomeHeroTheme.Navy,
                Dock = DockStyle.Fill,
                Padding = new Padding(24, 0, 24, 0)
            };
            header.Controls.Add(new Label
            {
                Text = isProvider ? "Customer messages" : "Message your service provider",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            });

            TableLayoutPanel root = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            TableLayoutPanel selectorLayout = new()
            {
                BackColor = Color.White,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 8, 20, 8),
                RowCount = 1
            };
            selectorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            selectorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            selectorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            selectorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Control requestField = CreateSelectorField(isProvider ? "Conversation" : "Service request", cmbRequest);
            Control providerField = CreateSelectorField("Service provider", cmbProvider);
            providerField.Visible = !isProvider;
            if (isProvider)
            {
                selectorLayout.SetColumnSpan(requestField, 2);
            }
            selectorLayout.Controls.Add(requestField, 0, 0);
            selectorLayout.Controls.Add(providerField, 1, 0);
            selectorLayout.Controls.Add(btnRefresh, 2, 0);

            cmbRequest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequest.Dock = DockStyle.Fill;
            cmbRequest.Font = new Font("Segoe UI", 10F);
            cmbRequest.SelectedIndexChanged += (_, _) => RefreshConversation();
            cmbProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProvider.Dock = DockStyle.Fill;
            cmbProvider.Font = new Font("Segoe UI", 10F);
            cmbProvider.SelectedIndexChanged += (_, _) => RefreshConversation();
            lblProvider.Visible = true;

            txtConversation.ReadOnly = true;
            txtConversation.BackColor = Color.White;
            txtConversation.BorderStyle = BorderStyle.None;
            txtConversation.Font = new Font("Segoe UI", 10F);
            txtConversation.Dock = DockStyle.Fill;
            Panel conversationCard = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Margin = new Padding(20, 14, 20, 14),
                Padding = new Padding(18)
            };
            conversationCard.Controls.Add(txtConversation);

            lblEmpty.Text = "Choose a request and provider to start a conversation.";
            lblEmpty.ForeColor = HomeHeroTheme.Muted;
            lblEmpty.Font = new Font("Segoe UI", 10F);
            lblEmpty.AutoSize = false;
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.Visible = false;
            conversationCard.Controls.Add(lblEmpty);
            lblEmpty.BringToFront();

            txtMessage.Multiline = true;
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Margin = new Padding(0, 0, 12, 0);
            txtMessage.StateCommon.Border.Rounding = 8;

            btnSend.Text = "Send message";
            btnSend.Dock = DockStyle.Fill;
            btnSend.StateCommon.Back.Color1 = HomeHeroTheme.Orange;
            btnSend.StateCommon.Back.Color2 = HomeHeroTheme.Orange;
            btnSend.StateCommon.Content.ShortText.Color1 = Color.White;
            btnSend.StateCommon.Border.Rounding = 8;
            btnSend.Click += BtnSend_Click;
            btnRefresh.Text = "Refresh";
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.Margin = new Padding(8, 16, 0, 0);
            btnRefresh.StateCommon.Back.Color1 = HomeHeroTheme.Navy;
            btnRefresh.StateCommon.Back.Color2 = HomeHeroTheme.Navy;
            btnRefresh.StateCommon.Content.ShortText.Color1 = Color.White;
            btnRefresh.StateCommon.Border.Rounding = 6;
            btnRefresh.Click += (_, _) =>
            {
                btnSend.Enabled = true;
                LoadConversationOptions();
            };

            TableLayoutPanel composer = new()
            {
                BackColor = HomeHeroTheme.Canvas,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 8, 20, 12),
                RowCount = 1
            };
            composer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            composer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            composer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            composer.Controls.Add(txtMessage, 0, 0);
            composer.Controls.Add(btnSend, 1, 0);

            root.Controls.Add(header, 0, 0);
            root.Controls.Add(selectorLayout, 0, 1);
            root.Controls.Add(conversationCard, 0, 2);
            root.Controls.Add(composer, 0, 3);
            Controls.Add(root);
        }

        private static Control CreateSelectorField(string title, Control selector)
        {
            TableLayoutPanel field = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 12, 0),
                RowCount = 2
            };
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            field.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            field.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = HomeHeroTheme.Navy,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);
            selector.Margin = new Padding(0, 2, 0, 0);
            field.Controls.Add(selector, 0, 1);
            return field;
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

        public void RefreshRequests(IEnumerable<MaintenanceRequest> updatedRequests)
        {
            requests = updatedRequests.ToList();
            LoadConversationOptions();
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
