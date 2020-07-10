using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PoE_Trade_Overlay.Queries
{
    public partial class CurrencyRates
    {
        [JsonProperty("lines", NullValueHandling = NullValueHandling.Ignore)]
        public List<Line> Lines { get; set; }

        [JsonProperty("currencyDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyDetail> CurrencyDetails { get; set; }
    }

    public partial class CurrencyDetail
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Icon { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("poeTradeId", NullValueHandling = NullValueHandling.Ignore)]
        public long? PoeTradeId { get; set; }
    }

    public partial class Line
    {
        [JsonProperty("currencyTypeName", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyTypeName { get; set; }

        [JsonProperty("pay")]
        public Receive Pay { get; set; }

        [JsonProperty("receive", NullValueHandling = NullValueHandling.Ignore)]
        public Receive Receive { get; set; }

        [JsonProperty("paySparkLine", NullValueHandling = NullValueHandling.Ignore)]
        public SparkLine PaySparkLine { get; set; }

        [JsonProperty("receiveSparkLine", NullValueHandling = NullValueHandling.Ignore)]
        public SparkLine ReceiveSparkLine { get; set; }

        [JsonProperty("chaosEquivalent", NullValueHandling = NullValueHandling.Ignore)]
        public double? ChaosEquivalent { get; set; }

        [JsonProperty("lowConfidencePaySparkLine", NullValueHandling = NullValueHandling.Ignore)]
        public SparkLine LowConfidencePaySparkLine { get; set; }

        [JsonProperty("lowConfidenceReceiveSparkLine", NullValueHandling = NullValueHandling.Ignore)]
        public LowConfidenceReceiveSparkLine LowConfidenceReceiveSparkLine { get; set; }
    }

    public partial class SparkLine
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalChange { get; set; }
    }

    public partial class LowConfidenceReceiveSparkLine
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Data { get; set; }

        [JsonProperty("totalChange", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalChange { get; set; }
    }

    public partial class Receive
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("league_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LeagueId { get; set; }

        [JsonProperty("pay_currency_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PayCurrencyId { get; set; }

        [JsonProperty("get_currency_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? GetCurrencyId { get; set; }

        [JsonProperty("sample_time_utc", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? SampleTimeUtc { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public double? Value { get; set; }

        [JsonProperty("data_point_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? DataPointCount { get; set; }

        [JsonProperty("includes_secondary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludesSecondary { get; set; }
    }

    public partial class CurrencyRates
    {
        public static CurrencyRates FromJson(string json) => JsonConvert.DeserializeObject<CurrencyRates>(json, poe_Ninja_Converter.Settings);
    }

    public static class poe_Ninja_Serialize
    {
        public static string ToJson(this CurrencyRates self) => JsonConvert.SerializeObject(self, poe_Ninja_Converter.Settings);
    }

    internal static class poe_Ninja_Converter
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