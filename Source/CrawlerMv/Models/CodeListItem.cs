using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class CodeListItem
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("parameters")]
        public List<JObject> Parameters { get; set; }
    }
}