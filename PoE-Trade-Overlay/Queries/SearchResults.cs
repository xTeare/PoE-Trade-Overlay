using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace PoE_Trade_Overlay.Queries
{
    public partial class SearchResults
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Result { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long Total { get; set; }

        [JsonProperty("inexact", NullValueHandling = NullValueHandling.Ignore)]
        public bool Inexact { get; set; }
    }

    public partial class SearchResults
    {
        public static SearchResults FromJson(string json) => JsonConvert.DeserializeObject<SearchResults>(json, SearchResultsConverter.Settings);
    }

    public static class SearchResultsSerialize
    {
        public static string ToJson(this SearchResults self) => JsonConvert.SerializeObject(self, SearchResultsConverter.Settings);
    }

    internal static class SearchResultsConverter
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