using System.Collections.Generic;
using CrawlerMv.Models;
using Newtonsoft.Json;

namespace CrawlerMv
{
    [JsonObject]
    public class PageItem
    {
        [JsonProperty("conditions")]
        public ConditionItem Conditions { get; set; }

        [JsonProperty("directionFix")]
        public bool? DirectionFix { get; set; }

        [JsonProperty("image")]
        public ImageItem Image { get; set; }

        [JsonProperty("list")]
        public List<CodeListItem> List { get; set; }

        [JsonProperty("moveFrequency")]
        public int? MoveFrequency { get; set; }

        [JsonProperty("moveRoute")]
        public MoveRouteItem MoveRoute { get; set; }

        [JsonProperty("moveSpeed")]
        public int? MoveSpeed { get; set; }

        [JsonProperty("moveType")]
        public int? MoveType { get; set; }

        [JsonProperty("priorityType")]
        public int? PriorityType { get; set; }

        [JsonProperty("stepAnime")]
        public bool? StepAnime { get; set; }

        [JsonProperty("through")]
        public bool? Through { get; set; }

        [JsonProperty("trigger")]
        public int? Trigger { get; set; }

        [JsonProperty("walkAnime")]
        public bool? WalkAnime { get; set; }
    }
}