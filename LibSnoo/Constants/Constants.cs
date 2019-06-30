using System.Collections.Generic;

namespace LibSnoo.Constants
{
    public class Constants
    { 
        public static readonly string redditBaseUrl = "https://reddit.com/";
        public static readonly string redditApiBaseUrl = "https://ssl.reddit.com/api/v1/";
        public static readonly string redditOauthApiBaseUrl = "https://oauth.reddit.com/";

        public static List<string> scopeList = new List<string>
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
    }
}
