namespace WhatsAppNative.Models.WhatsAppEntities
{
    public class OutgoingText
    {
        public long Id { get; set; }
        public string Text { get; set; } = String.Empty;
        public string To { get; set; } = String.Empty;
        public string From { get; set; } = String.Empty;
        public DateTime TimeStamp { get; set; }

    }
}
