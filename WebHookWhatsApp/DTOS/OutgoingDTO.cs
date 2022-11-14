namespace WhatsAppNative.DTOS
{
    public class OutgoingDTO
    {
            public string? messaging_product { get; set; }
            public string? to { get; set; }
            public string? type { get; set; }
            public Texttt? text { get; set; }
        

        public class Texttt
        {
    
            public bool? preview_url { get; set; }
            public string? body { get; set; }
        }
    }
}
