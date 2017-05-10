using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class MoveRouteItem
    {
        [JsonProperty("list")]
        public List<CodeListItem> List { get; set; }

        [JsonProperty("repeat")]
        public bool? Repeat { get; set; }

        [JsonProperty("skippable")]
        public bool? Skippable { get; set; }

        [JsonProperty("wait")]
        public bool? Wait { get; set; }
    }
}