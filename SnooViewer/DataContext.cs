using RedditSharp;

namespace SnooViewer
{
    public static class DataContext
    {
        public static Reddit Reddit { get; set; }
        public static string Token { get; set; }
        public static string RefreshToken { get; set; }
    }
}
