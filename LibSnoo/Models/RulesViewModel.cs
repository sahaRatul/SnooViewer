using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibSnoo.Models
{
    public class RulesViewModel
    {
        [JsonProperty("rules")]
        public IList<SubredditRuleViewModel> Rules { get; set; }

        [JsonProperty("site_rules")]
        public IList<string> SiteRules { get; set; }

        [JsonProperty("site_rules_flow")]
        public IList<SiteRulesFlowViewModel> SiteRulesFlow { get; set; }
    }
}
