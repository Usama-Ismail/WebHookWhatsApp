using System.Security.Permissions;

namespace WhatsAppNative.Models.WhatsAppEntities
{
    public class IncomingText
    {
        public long Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string FromName { get; set; } 
        public DateTime TimeStamp { get; set; }
        public string MessageId { get; set; } 
        public string Message { get; set; }

    }
}
