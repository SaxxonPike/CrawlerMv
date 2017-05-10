using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class EventItem
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("pages")]
        public List<PageItem> Pages { get; set; }

        [JsonProperty("x")]
        public int? X { get; set; }

        [JsonProperty("y")]
        public int? Y { get; set; }
    }
}
