using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class KindViewModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public DataViewModel Data { get; set; }
    }
}
