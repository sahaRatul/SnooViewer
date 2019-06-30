﻿using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class ChildViewModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public PostOrSubRedditDataViewModel Data { get; set; }
    }
}
