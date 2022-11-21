namespace WhatsAppNative.Models.WhatsAppEntities
{
    public class OutgoingText
    {
        public long Id { get; set; }
        public string Text { get; set; } 
        public string To { get; set; } 
        public string From { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
