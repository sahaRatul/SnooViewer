using Newtonsoft.Json;

namespace TestUWPApp.Models
{
    public class KindViewModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public DataViewModel Data { get; set; }
    }
}
