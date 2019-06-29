using Newtonsoft.Json;

namespace TestUWPApp.Models
{
    public class ChildViewModel
    {

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public SubredditViewModel Data { get; set; }
    }
}
