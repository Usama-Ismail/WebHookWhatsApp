namespace WhatsAppNative.DTOS
{
    public class DataDTO
    {
        public string messaging_product { get; set; } = String.Empty;
        public string to { get; set; } = String.Empty;

        public Textt text { get; set; }         
    }

    public class Textt
    {
        public string body { get; set; } = String.Empty;
    }
}
