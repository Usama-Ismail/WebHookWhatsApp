using WhatsAppNative.Service;

namespace WhatsAppNative.Helper
{
    public class Utility
    {
        
        public static void saveMessage(string msg, string path)
        {
            File.WriteAllText(path, msg);
        }

        public static DateTime convertUnixToDt(double unixTime)
        {
            System.DateTime date_Time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0,DateTimeKind.Utc);
            date_Time = date_Time.AddSeconds(unixTime).ToLocalTime();
            return date_Time;
        }
    }
}
