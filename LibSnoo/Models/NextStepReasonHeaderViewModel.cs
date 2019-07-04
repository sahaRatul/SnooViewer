using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibSnoo.Models
{
    public class NextStepReasonHeaderViewModel
    {
        [JsonProperty("nextStepHeader")]
        public string NextStepHeader { get; set; }

        [JsonProperty("reasonTextToShow")]
        public string ReasonTextToShow { get; set; }

        [JsonProperty("nextStepReasons")]
        public IList<NextStepReasonLineViewModel> NextStepReasons { get; set; }

        [JsonProperty("reasonText")]
        public string ReasonText { get; set; }

        [JsonProperty("complaintButtonText")]
        public string ComplaintButtonText { get; set; }

        [JsonProperty("complaintUrl")]
        public string ComplaintUrl { get; set; }

        [JsonProperty("complaintPageTitle")]
        public string ComplaintPageTitle { get; set; }

        [JsonProperty("fileComplaint")]
        public bool? FileComplaint { get; set; }

        [JsonProperty("complaintPrompt")]
        public string ComplaintPrompt { get; set; }
    }
}
