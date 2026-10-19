using System.Text.Json;

namespace Home_Hero
{
    public static class MessageRepository
    {
        private static readonly string MessagesFile =
            AppSettings.GetBaseDirectoryFilePath(AppSettings.MessagesFileName);

        public static List<MessageRecord> LoadMessages()
        {
            if (!File.Exists(MessagesFile))
            {
                return new List<MessageRecord>();
            }

            string json = File.ReadAllText(MessagesFile);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<MessageRecord>();
            }

            return JsonSerializer.Deserialize<List<MessageRecord>>(json)
                ?? new List<MessageRecord>();
        }

        public static List<MessageRecord> LoadConversation(
            string requestNumber,
            string customerEmail,
            string providerEmail)
        {
            return LoadMessages()
                .Where(message =>
                    message.RequestNumber == requestNumber &&
                    string.Equals(message.CustomerEmail, customerEmail, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(message.ProviderEmail, providerEmail, StringComparison.OrdinalIgnoreCase))
                .OrderBy(message => message.SentAt)
                .ToList();
        }

        public static void SendMessage(
            string requestNumber,
            string customerEmail,
            string providerEmail,
            string senderEmail,
            string body)
        {
            if (string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentException("Message text cannot be empty.", nameof(body));
            }

            List<MessageRecord> messages = LoadMessages();
            messages.Add(new MessageRecord
            {
                RequestNumber = requestNumber,
                CustomerEmail = customerEmail,
                ProviderEmail = providerEmail,
                SenderEmail = senderEmail,
                Body = body.Trim(),
                SentAt = DateTime.Now
            });

            string json = JsonSerializer.Serialize(messages, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(MessagesFile, json);
        }
    }
}
