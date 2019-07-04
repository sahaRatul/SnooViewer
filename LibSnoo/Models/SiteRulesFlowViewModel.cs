using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibSnoo.Models
{
    public class SiteRulesFlowViewModel
    {
        [JsonProperty("reasonTextToShow")]
        public string ReasonTextToShow { get; set; }

        [JsonProperty("reasonText")]
        public string ReasonText { get; set; }

        [JsonProperty("nextStepHeader")]
        public string NextStepHeader { get; set; }

        [JsonProperty("nextStepReasons")]
        public IList<NextStepReasonHeaderViewModel> NextStepReasons { get; set; }
    }
}
