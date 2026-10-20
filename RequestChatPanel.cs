using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace Home_Hero
{
    internal sealed class RequestChatMessage
    {
        public string RequestNumber { get; set; } = "";
        public string SenderId { get; set; } = "";
        public string SenderName { get; set; } = "";
        public string SenderRole { get; set; } = "";
        public string Text { get; set; } = "";
        public DateTime SentAt { get; set; }
    }

    internal static class RequestChatStore
    {
        private static readonly string filePath = AppPaths.DataFile("request-chats.json");
        private static readonly Mutex fileMutex = new Mutex(false, @"Local\HomeHero.RequestChat.Messages");

        public static List<RequestChatMessage> Load(string requestNumber)
        {
            if (!File.Exists(filePath)) return new List<RequestChatMessage>();

            try
            {
                List<RequestChatMessage>? messages = JsonSerializer.Deserialize<List<RequestChatMessage>>(File.ReadAllText(filePath));
                return (messages ?? new List<RequestChatMessage>())
                    .Where(m => string.Equals(m.RequestNumber, requestNumber, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(m => m.SentAt)
                    .ToList();
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException("The saved request conversation is damaged and could not be read.", ex);
            }
        }

        public static void Add(RequestChatMessage message)
        {
            bool acquired = false;
            string temporaryPath = filePath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                try
                {
                    acquired = fileMutex.WaitOne(TimeSpan.FromSeconds(5));
                }
                catch (AbandonedMutexException)
                {
                    acquired = true;
                }

                if (!acquired)
                    throw new IOException("The conversation is busy in another Home Hero window. Please try again.");

                List<RequestChatMessage> messages;
                if (File.Exists(filePath))
                {
                    try
                    {
                        messages = JsonSerializer.Deserialize<List<RequestChatMessage>>(File.ReadAllText(filePath))
                            ?? new List<RequestChatMessage>();
                    }
                    catch (JsonException ex)
                    {
                        throw new InvalidDataException("The saved request conversation is damaged and could not be updated.", ex);
                    }
                }
                else
                {
                    messages = new List<RequestChatMessage>();
                }

                messages.Add(message);
                File.WriteAllText(temporaryPath, JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true }));
                File.Move(temporaryPath, filePath, true);
            }
            finally
            {
                if (File.Exists(temporaryPath)) File.Delete(temporaryPath);
                if (acquired) fileMutex.ReleaseMutex();
            }
        }
    }

    internal sealed class RequestChatPanel : CardPanel
    {
        private readonly bool isProvider;
        private readonly string userId;
        private readonly string displayName;
        private readonly System.Windows.Forms.Timer refreshTimer;
        private readonly Label requestLabel;
        private readonly RichTextBox transcript;
        private readonly TextBox messageBox;
        private readonly ModernButton sendButton;
        private MaintenanceRequest? selectedRequest;
        private string renderedSignature = "";

        public RequestChatPanel(bool provider, string currentUserId, string currentDisplayName)
        {
            isProvider = provider;
            userId = currentUserId;
            displayName = currentDisplayName;
            Padding = new Padding(20, 14, 20, 16);
            FillColor = Color.White;
            BorderColor = Theme.Border;
            AccentColor = Theme.Blue;

            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.BackColor = Color.Transparent;
            layout.ColumnCount = 1;
            layout.RowCount = 3;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));

            TableLayoutPanel header = new TableLayoutPanel();
            header.Dock = DockStyle.Fill;
            header.BackColor = Color.Transparent;
            header.ColumnCount = 2;
            header.RowCount = 1;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));

            Label title = Theme.MakeLabel("REQUEST CONVERSATION", 9F, FontStyle.Bold, Theme.Navy);
            title.Dock = DockStyle.Fill;
            title.TextAlign = ContentAlignment.MiddleLeft;
            requestLabel = Theme.MakeLabel("Select an assigned request", 9F, FontStyle.Regular, Theme.Muted);
            requestLabel.Dock = DockStyle.Fill;
            requestLabel.TextAlign = ContentAlignment.MiddleRight;
            header.Controls.Add(title, 0, 0);
            header.Controls.Add(requestLabel, 1, 0);

            transcript = new RichTextBox();
            transcript.Dock = DockStyle.Fill;
            transcript.ReadOnly = true;
            transcript.BorderStyle = BorderStyle.FixedSingle;
            transcript.BackColor = Color.FromArgb(248, 250, 252);
            transcript.Font = Theme.MakeFont(9.5F);
            transcript.WordWrap = true;
            transcript.ScrollBars = RichTextBoxScrollBars.Vertical;

            TableLayoutPanel composer = new TableLayoutPanel();
            composer.Dock = DockStyle.Fill;
            composer.BackColor = Color.Transparent;
            composer.ColumnCount = 2;
            composer.RowCount = 1;
            composer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            composer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));

            messageBox = new TextBox();
            messageBox.Dock = DockStyle.Fill;
            messageBox.MaxLength = 1000;
            messageBox.Font = Theme.MakeFont(9.5F);
            messageBox.Margin = new Padding(0, 7, 10, 0);
            messageBox.PlaceholderText = "Write a message...";
            messageBox.KeyDown += MessageBox_KeyDown;

            sendButton = new ModernButton();
            sendButton.Dock = DockStyle.Fill;
            sendButton.Text = "Send";
            sendButton.Font = Theme.MakeSemibold(9.5F);
            sendButton.Margin = new Padding(0, 4, 0, 0);
            sendButton.Click += SendButton_Click;
            composer.Controls.Add(messageBox, 0, 0);
            composer.Controls.Add(sendButton, 1, 0);

            layout.Controls.Add(header, 0, 0);
            layout.Controls.Add(transcript, 0, 1);
            layout.Controls.Add(composer, 0, 2);
            Controls.Add(layout);

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += delegate { RefreshConversation(false); };
            refreshTimer.Start();
            Disposed += delegate { refreshTimer.Dispose(); };
        }

        public void SetRequest(MaintenanceRequest? request)
        {
            selectedRequest = request;
            RefreshConversation(true);
        }

        private void RefreshConversation(bool force)
        {
            if (IsDisposed || !IsHandleCreated) return;

            MaintenanceRequest? latest = selectedRequest;
            try
            {
                if (selectedRequest != null)
                {
                    latest = DataManager.LoadRequests().FirstOrDefault(r =>
                        string.Equals(r.RequestNumber, selectedRequest.RequestNumber, StringComparison.OrdinalIgnoreCase));
                }

                bool allowed = latest != null && IsParticipant(latest);
                bool assigned = latest != null && !string.IsNullOrWhiteSpace(latest.AssignedProviderId)
                    && !string.Equals(latest.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase);
                selectedRequest = latest;
                requestLabel.Text = latest == null ? "Select an assigned request" : latest.RequestNumber;
                bool canChat = allowed && assigned;
                messageBox.Enabled = canChat;
                sendButton.Enabled = canChat;

                if (!canChat)
                {
                    string empty = latest == null
                        ? "Select a request to view its conversation."
                        : !assigned
                            ? "Chat will open once a provider has been assigned."
                            : "This request is not assigned to your account.";
                    SetTranscript(empty, "empty:" + (latest?.RequestNumber ?? ""));
                    requestLabel.ForeColor = Theme.Muted;
                    return;
                }

                List<RequestChatMessage> messages = RequestChatStore.Load(latest!.RequestNumber);
                string signature = string.Join("|", messages.Select(m => m.SentAt.Ticks + ":" + m.SenderId + ":" + m.Text));
                if (force || signature != renderedSignature)
                {
                    renderedSignature = signature;
                    RenderMessages(messages);
                }
                requestLabel.ForeColor = Theme.Muted;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is InvalidDataException)
            {
                messageBox.Enabled = false;
                sendButton.Enabled = false;
                requestLabel.Text = "Conversation unavailable";
                requestLabel.ForeColor = Theme.Red;
                SetTranscript(ex.Message, "error:" + ex.Message);
            }
        }

        private bool IsParticipant(MaintenanceRequest request)
        {
            if (isProvider)
            {
                string assigned = (request.AssignedProviderId ?? "").Trim();
                return string.Equals(assigned, userId, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(assigned, displayName, StringComparison.OrdinalIgnoreCase);
            }
            return string.Equals(request.CustomerId, userId, StringComparison.OrdinalIgnoreCase);
        }

        private void RenderMessages(List<RequestChatMessage> messages)
        {
            transcript.Clear();
            if (messages.Count == 0)
            {
                transcript.SelectionColor = Theme.Muted;
                transcript.AppendText(isProvider
                    ? "No messages yet. Start the conversation with your customer."
                    : "No messages yet. Start the conversation with your service provider.");
                return;
            }

            foreach (RequestChatMessage message in messages)
            {
                transcript.SelectionColor = string.Equals(message.SenderId, userId, StringComparison.OrdinalIgnoreCase)
                    ? Theme.Blue
                    : Theme.Navy;
                transcript.SelectionFont = Theme.MakeSemibold(9F);
                transcript.AppendText(message.SenderName + "  ·  " + message.SentAt.ToString("dd MMM, HH:mm") + "\r\n");
                transcript.SelectionFont = Theme.MakeFont(9.5F);
                transcript.SelectionColor = Theme.Text;
                transcript.AppendText(message.Text + "\r\n\r\n");
            }
            transcript.SelectionStart = transcript.TextLength;
            transcript.ScrollToCaret();
        }

        private void SetTranscript(string text, string signature)
        {
            if (renderedSignature == signature) return;
            renderedSignature = signature;
            transcript.Clear();
            transcript.SelectionColor = Theme.Muted;
            transcript.AppendText(text);
        }

        private void MessageBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void SendButton_Click(object? sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            string text = messageBox.Text.Trim();
            if (text.Length == 0 || selectedRequest == null) return;

            try
            {
                MaintenanceRequest? request = DataManager.LoadRequests().FirstOrDefault(r =>
                    string.Equals(r.RequestNumber, selectedRequest.RequestNumber, StringComparison.OrdinalIgnoreCase));
                if (request == null || !IsParticipant(request)
                    || string.IsNullOrWhiteSpace(request.AssignedProviderId)
                    || string.Equals(request.AssignedProviderId, "Unassigned", StringComparison.OrdinalIgnoreCase))
                {
                    RefreshConversation(true);
                    return;
                }

                selectedRequest = request;
                RequestChatStore.Add(new RequestChatMessage
                {
                    RequestNumber = request.RequestNumber,
                    SenderId = userId,
                    SenderName = displayName,
                    SenderRole = isProvider ? "Provider" : "Customer",
                    Text = text,
                    SentAt = DateTime.Now
                });
                messageBox.Clear();
                renderedSignature = "";
                RefreshConversation(true);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is InvalidDataException)
            {
                MessageBox.Show(this, "Your message could not be sent.\r\n\r\n" + ex.Message,
                    "Request conversation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
