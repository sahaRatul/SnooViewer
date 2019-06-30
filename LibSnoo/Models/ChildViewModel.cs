using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class ChildViewModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public SubredditViewModel Subreddit { get; set; }

        [JsonProperty("data")]
        public PostViewModel Post { get; set; }
    }
}
