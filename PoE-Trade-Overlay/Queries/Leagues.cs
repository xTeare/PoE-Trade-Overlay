// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using PoE_Trade_Overlay;
//
//    var leagues = Leagues.FromJson(jsonString);

namespace PoE_Trade_Overlay.Queries
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Globalization;

    public partial class Leagues
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public LeagueResult[] Result { get; set; }
    }

    public partial class LeagueResult
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

    public partial class Leagues
    {
        public static Leagues FromJson(string json) => JsonConvert.DeserializeObject<Leagues>(json, PoE_Trade_Overlay.Queries.LeaguesConverter.Settings);
    }

    public static class LeaguesSerialize
    {
        public static string ToJson(this Leagues self) => JsonConvert.SerializeObject(self, PoE_Trade_Overlay.Queries.LeaguesConverter.Settings);
    }

    internal static class LeaguesConverter
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