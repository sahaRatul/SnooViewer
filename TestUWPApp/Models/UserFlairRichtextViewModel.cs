using Newtonsoft.Json;

namespace SnooViewer.Models
{
    public class UserFlairRichtextViewModel
    {
        [JsonProperty("e")]
        public string E { get; set; }

        [JsonProperty("t")]
        public string T { get; set; }
    }
}
