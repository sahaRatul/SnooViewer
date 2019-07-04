using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class SubredditRuleViewModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("violation_reason")]
        public string ViolationReason { get; set; }

        [JsonProperty("created_utc")]
        public double CreatedUtc { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("description_html")]
        public string DescriptionHtml { get; set; }
    }
}
