using Newtonsoft.Json;

namespace SnooViewer.Models
{
    public class ChildViewModel
    {

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public SubredditViewModel Data { get; set; }
    }
}
