using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrawlerMv.Models
{
    [JsonObject]
    public class MapItem
    {
        [JsonProperty("autoplayBgm")]
        public bool? AutoplayBgm { get; set; }

        [JsonProperty("autoplayBgs")]
        public bool? AutoplayBgs { get; set; }

        [JsonProperty("battleBack1Name")]
        public string BattleBack1Name { get; set; }

        [JsonProperty("battleBack2Name")]
        public string BattleBack2Name { get; set; }

        [JsonProperty("bgm")]
        public SoundItem Bgm { get; set; }

        [JsonProperty("bgs")]
        public SoundItem Bgs { get; set; }

        [JsonProperty("disableDashing")]
        public bool? DisableDashing { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("encounterList")]
        public List<object> EncounterList { get; set; }

        [JsonProperty("encounterStep")]
        public int? EncounterStep { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("parallaxLoopX")]
        public bool? ParallaxLoopX { get; set; }

        [JsonProperty("parallaxLoopY")]
        public bool? ParallaxLoopY { get; set; }

        [JsonProperty("parallaxName")]
        public string ParallaxName { get; set; }

        [JsonProperty("parallaxShow")]
        public bool? ParallaxShow { get; set; }

        [JsonProperty("parallaxSx")]
        public int? ParallaxSx { get; set; }

        [JsonProperty("parallaxSy")]
        public int? ParallaxSy { get; set; }

        [JsonProperty("scrollType")]
        public int? ScrollType { get; set; }

        [JsonProperty("specifyBattleback")]
        public bool? SpecifyBattleBack { get; set; }

        [JsonProperty("tilesetId")]
        public int? TilesetId { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("data")]
        public List<int> Data { get; set; }

        [JsonProperty("events")]
        public List<EventItem> Events { get; set; }
    }
}
