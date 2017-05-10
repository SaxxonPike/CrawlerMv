using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class CodeListItem
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("indent")]
        public int? Indent { get; set; }

        [JsonProperty("parameters")]
        public List<object> Parameters { get; set; }
    }
}