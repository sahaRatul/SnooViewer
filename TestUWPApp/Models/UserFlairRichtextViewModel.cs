using Newtonsoft.Json;

namespace TestUWPApp.Models
{
    public class UserFlairRichtextViewModel
    {
        [JsonProperty("e")]
        public string E { get; set; }

        [JsonProperty("t")]
        public string T { get; set; }
    }
}
