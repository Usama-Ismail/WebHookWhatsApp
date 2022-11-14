using System.Security.Permissions;

namespace WhatsAppNative.Models.WhatsAppEntities
{
    public class IncomingText
    {
        public long Id { get; set; }
        public string From { get; set; } =String.Empty;
        public string To { get; set; } = String.Empty;
        public string FromName { get; set; } = String.Empty;
        public DateTime TimeStamp { get; set; }
        public string MessageId { get; set; } = String.Empty;
        public string Message { get; set; } = String.Empty;

    }
}
