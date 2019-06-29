using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class AuthRequestModel
    {

        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
