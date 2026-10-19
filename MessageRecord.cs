namespace Home_Hero
{
    public sealed class MessageRecord
    {
        public string RequestNumber { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string ProviderEmail { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
