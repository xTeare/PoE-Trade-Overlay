using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace PoE_Trade_Overlay.Queries
{
    public partial class Items
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public List<ItemResult> Result { get; set; }
    }

    public partial class ItemResult
    {
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("entries", NullValueHandling = NullValueHandling.Ignore)]
        public List<ItemEntry> Entries { get; set; }
    }

    public partial class ItemEntry
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
        public ItemFlags Flags { get; set; }

        [JsonProperty("disc", NullValueHandling = NullValueHandling.Ignore)]
        public string Disc { get; set; }
    }

    public partial class ItemFlags
    {
        [JsonProperty("unique", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Unique { get; set; }

        [JsonProperty("prophecy", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Prophecy { get; set; }
    }

    public partial class Items
    {
        public static Items FromJson(string json) => JsonConvert.DeserializeObject<Items>(json, PoE_Trade_Overlay.Queries.ParseItemsConverter.Settings);
    }

    public static class ParseItemsSerialize
    {
        public static string ToJson(this Items self) => JsonConvert.SerializeObject(self, PoE_Trade_Overlay.Queries.ParseItemsConverter.Settings);
    }

    internal static class ParseItemsConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}