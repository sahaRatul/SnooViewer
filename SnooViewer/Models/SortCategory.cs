using RedditSharp.Things;

namespace SnooViewer.Models
{
    internal class SortCategory
    {
        public string SortName { get; set; }
        public Subreddit.Sort SortValue { get; set; }
    }
}
