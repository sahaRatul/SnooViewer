using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class NextStepReasonLineViewModel
    {
        [JsonProperty("reasonTextToShow")]
        public string ReasonTextToShow { get; set; }

        [JsonProperty("reasonText")]
        public string ReasonText { get; set; }
    }
}
