using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace PoE_Trade_Overlay.Queries
{
    public partial class QueryResult
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

    public partial class QueryResult
    {
        public static QueryResult FromJson(string json) => JsonConvert.DeserializeObject<QueryResult>(json, QueryResultConverter.Settings);
    }

    public static class SearchQueryResultSerialize
    {
        public static string ToJson(this QueryResult self) => JsonConvert.SerializeObject(self, QueryResultConverter.Settings);
    }

    internal static class QueryResultConverter
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