using Newtonsoft.Json;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class ImageItem
    {
        [JsonProperty("characterIndex")]
        public int? CharacterIndex { get; set; }

        [JsonProperty("characterName")]
        public string CharacterName { get; set; }

        [JsonProperty("direction")]
        public int? Direction { get; set; }

        [JsonProperty("pattern")]
        public int? Pattern { get; set; }

        [JsonProperty("tileId")]
        public int? TileId { get; set; }
    }
}