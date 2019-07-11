using SnooViewer.Models;
using System.Collections.Generic;
using RedditSharp.Things;

namespace SnooViewer.Constants
{
    internal class Constants
    {
        public static readonly string redditBaseUrl = "https://reddit.com/";
        public static readonly string redditApiBaseUrl = "https://ssl.reddit.com/api/v1/";
        public static readonly string redditOauthApiBaseUrl = "https://oauth.reddit.com/";

        public readonly static List<string> scopeList = new List<string>
        {
            "creddits",
            "modcontributors",
            "modmail",
            "modconfig",
            "subscribe",
            "structuredstyles",
            "vote",
            "wikiedit",
            "mysubreddits",
            "submit",
            "modlog",
            "modposts",
            "modflair",
            "save",
            "modothers",
            "read",
            "privatemessages",
            "report",
            "identity",
            "livemanage",
            "account",
            "modtraffic",
            "wikiread",
            "edit",
            "modwiki",
            "modself",
            "history",
            "flair",
        };

        public readonly static List<SortCategory> postSortList = new List<SortCategory>
        {
            new SortCategory
            {
                SortName = "New",
                SortValue = Subreddit.Sort.New
            },
            new SortCategory
            {
                SortName = "Rising",
                SortValue = Subreddit.Sort.Rising
            },
            new SortCategory
            {
                SortName = "Hot",
                SortValue = Subreddit.Sort.Hot
            },
            new SortCategory
            {
                SortName = "Top",
                SortValue = Subreddit.Sort.Top
            },
            new SortCategory
            {
                SortName = "Controversial",
                SortValue = Subreddit.Sort.Controversial
            }
        };
    }
}
