﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibSnoo.Models
{
    public class DataViewModel
    {

        [JsonProperty("modhash")]
        public string Modhash { get; set; }

        [JsonProperty("dist")]
        public int? Dist { get; set; }

        [JsonProperty("children")]
        public IList<ChildViewModel> Children { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
}
