using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class UserFlairRichtextViewModel
    {
        [JsonProperty("e")]
        public string E { get; set; }

        [JsonProperty("t")]
        public string T { get; set; }
    }
}
