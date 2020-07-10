using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace PoE_Trade_Overlay.Queries
{
    public partial class Stats
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public List<StatResult> Result { get; set; }
    }

    public partial class StatResult
    {
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("entries", NullValueHandling = NullValueHandling.Ignore)]
        public List<StatEntry> Entries { get; set; }
    }

    public partial class StatEntry
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public partial class Stats
    {
        public static Stats FromJson(string json) => JsonConvert.DeserializeObject<Stats>(json, PoE_Trade_Overlay.Queries.StatsConverter.Settings);
    }

    public static class StatsSerialize
    {
        public static string ToJson(this Stats self) => JsonConvert.SerializeObject(self, PoE_Trade_Overlay.Queries.StatsConverter.Settings);
    }

    internal static class StatsConverter
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