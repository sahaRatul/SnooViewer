using System;

namespace LibSnoo.Utils
{
    public class Utils
    {
        public static string UnixTimeStampToLocalTime(double unixTimeStamp, string format = "")
        {
            return DateTimeOffset.FromUnixTimeSeconds((long)unixTimeStamp).DateTime.ToString(format == null || format == string.Empty ? "dddd, dd MMMM yyyy HH:mm:ss" : format);
        }
    }
}
