﻿using Newtonsoft.Json;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class MapInfosItem
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("expanded")]
        public bool? Expanded { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("parentId")]
        public int? ParentId { get; set; }

        [JsonProperty("scrollX")]
        public float? ScrollX { get; set; }

        [JsonProperty("scrollY")]
        public float? ScrollY { get; set; }
    }
}
