using System;
using Windows.UI.Xaml;

namespace LibSnoo.Utils
{
    public class Utils
    {
        public static string UnixTimeStampToLocalTime(double unixTimeStamp, string format = "")
        {
            return DateTimeOffset.FromUnixTimeSeconds((long)unixTimeStamp).DateTime.ToString(format == null || format == string.Empty ? "dddd, dd MMMM yyyy HH:mm:ss" : format);
        }

        public static Visibility IsImageVisible(string url)
        {
            return (url != null || url != "") ? Visibility.Visible : Visibility.Collapsed;
        }

        public static GridLength GetColWidth(int originalWidth, string imgUrl)
        {
            if (imgUrl == "self" || imgUrl == "default" || imgUrl == "nsfw" || imgUrl == "spoiler" || imgUrl == null || imgUrl == "")
            {
                return new GridLength(0);
            }
            return new GridLength(originalWidth);
        }
    }
}
