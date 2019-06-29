using Newtonsoft.Json;

namespace SnooViewer.Models
{
    public class KindViewModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public DataViewModel Data { get; set; }
    }
}
