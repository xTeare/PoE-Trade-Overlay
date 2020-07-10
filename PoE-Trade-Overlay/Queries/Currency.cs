using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace PoE_Trade_Overlay.Queries
{
    public partial class Currency
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public CurrencyResult Result { get; set; }
    }

    public partial class CurrencyResult
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyElement> Currency { get; set; }

        [JsonProperty("fragments", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyElement> Fragments { get; set; }

        [JsonProperty("resonators", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyElement> Resonators { get; set; }

        [JsonProperty("fossils", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyElement> Fossils { get; set; }

        [JsonProperty("vials", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Vials { get; set; }

        [JsonProperty("nets", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Nets { get; set; }

        [JsonProperty("leaguestones", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Leaguestones { get; set; }

        [JsonProperty("essences", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyElement> Essences { get; set; }

        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyCard> Cards { get; set; }

        [JsonProperty("maps", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyCard> Maps { get; set; }

        [JsonProperty("shaped_maps", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyCard> ShapedMaps { get; set; }

        [JsonProperty("elder_maps", NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrencyCard> ElderMaps { get; set; }

        [JsonProperty("misc", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Misc { get; set; }
    }

    public partial class CurrencyCard
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

    public partial class CurrencyElement
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }
    }

    public partial class Currency
    {
        public static Currency FromJson(string json) => JsonConvert.DeserializeObject<Currency>(json, PoE_Trade_Overlay.Queries.CurrencyConverter.Settings);
    }

    public static class CurrencySerialize
    {
        public static string ToJson(this Currency self) => JsonConvert.SerializeObject(self, PoE_Trade_Overlay.Queries.CurrencyConverter.Settings);
    }

    internal static class CurrencyConverter
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