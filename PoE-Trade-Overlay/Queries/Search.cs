namespace PoE_Trade_Overlay.Queries
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    public partial class Search
    {
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Query Query { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Sort Sort { get; set; }
    }

    public partial class Query
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Status Status { get; set; }

        [JsonProperty("stats", NullValueHandling = NullValueHandling.Ignore)]
        public List<Stat> Stats { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public object Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public object Type { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public QueryFilters Filters { get; set; }
    }

    public partial class TypeClass
    {
        [JsonProperty("option", NullValueHandling = NullValueHandling.Ignore)]
        public string Option { get; set; }

        [JsonProperty("discriminator", NullValueHandling = NullValueHandling.Ignore)]
        public string Discriminator { get; set; }
    }

    public partial class QueryFilters
    {
        [JsonProperty("weapon_filters", NullValueHandling = NullValueHandling.Ignore)]
        public WeaponFilters WeaponFilters { get; set; }

        [JsonProperty("armour_filters", NullValueHandling = NullValueHandling.Ignore)]
        public ArmourFilters ArmourFilters { get; set; }

        [JsonProperty("socket_filters", NullValueHandling = NullValueHandling.Ignore)]
        public SocketFilters SocketFilters { get; set; }

        [JsonProperty("req_filters", NullValueHandling = NullValueHandling.Ignore)]
        public ReqFilters ReqFilters { get; set; }

        [JsonProperty("mod_filters", NullValueHandling = NullValueHandling.Ignore)]
        public ModFilters ModFilters { get; set; }

        [JsonProperty("map_filters", NullValueHandling = NullValueHandling.Ignore)]
        public MapFilters MapFilters { get; set; }

        [JsonProperty("misc_filters", NullValueHandling = NullValueHandling.Ignore)]
        public MiscFilters MiscFilters { get; set; }

        [JsonProperty("trade_filters", NullValueHandling = NullValueHandling.Ignore)]
        public TradeFilters TradeFilters { get; set; }

        [JsonProperty("type_filters", NullValueHandling = NullValueHandling.Ignore)]
        public TypeFilters TypeFilters { get; set; }
    }

    public partial class ArmourFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public ArmourFiltersFilters Filters { get; set; }
    }

    public partial class ArmourFiltersFilters
    {
        [JsonProperty("ar", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Ar { get; set; }

        [JsonProperty("es", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Es { get; set; }

        [JsonProperty("block", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Block { get; set; }

        [JsonProperty("ev", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Ev { get; set; }
    }

    public partial class PuneHedgehog
    {
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public long? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }
    }

    public partial class MapFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public MapFiltersFilters Filters { get; set; }
    }

    public partial class MapFiltersFilters
    {
        [JsonProperty("map_packsize", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog MapPacksize { get; set; }

        [JsonProperty("map_iir", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog MapIir { get; set; }

        [JsonProperty("map_tier", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog MapTier { get; set; }

        [JsonProperty("map_iiq", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog MapIiq { get; set; }

        [JsonProperty("map_elder", NullValueHandling = NullValueHandling.Ignore)]
        public Status MapElder { get; set; }

        [JsonProperty("map_shaped", NullValueHandling = NullValueHandling.Ignore)]
        public Status MapShaped { get; set; }

        [JsonProperty("map_series", NullValueHandling = NullValueHandling.Ignore)]
        public Status MapSeries { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("option", NullValueHandling = NullValueHandling.Ignore)]
        public string Option { get; set; }
    }

    public partial class MiscFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public MiscFiltersFilters Filters { get; set; }
    }

    public partial class MiscFiltersFilters
    {
        [JsonProperty("ilvl", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Ilvl { get; set; }

        [JsonProperty("gem_level_progress", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog GemLevelProgress { get; set; }

        [JsonProperty("elder_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status ElderItem { get; set; }

        [JsonProperty("identified", NullValueHandling = NullValueHandling.Ignore)]
        public Status Identified { get; set; }

        [JsonProperty("crafted", NullValueHandling = NullValueHandling.Ignore)]
        public Status Crafted { get; set; }

        [JsonProperty("talisman_tier", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog TalismanTier { get; set; }

        [JsonProperty("enchanted", NullValueHandling = NullValueHandling.Ignore)]
        public Status Enchanted { get; set; }

        [JsonProperty("alternate_art", NullValueHandling = NullValueHandling.Ignore)]
        public Status AlternateArt { get; set; }

        [JsonProperty("corrupted", NullValueHandling = NullValueHandling.Ignore)]
        public Status Corrupted { get; set; }

        [JsonProperty("mirrored", NullValueHandling = NullValueHandling.Ignore)]
        public Status Mirrored { get; set; }

        [JsonProperty("veiled", NullValueHandling = NullValueHandling.Ignore)]
        public Status Veiled { get; set; }

        [JsonProperty("fractured_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status Fractured { get; set; }

        [JsonProperty("synthesised_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status Synthesised { get; set; }

        [JsonProperty("shaper_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status ShaperItem { get; set; }

        [JsonProperty("hunter_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status HunterItem { get; set; }

        [JsonProperty("crusader_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status CrusaderItem { get; set; }

        [JsonProperty("redeemer_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status RedeemerItem { get; set; }

        [JsonProperty("warlord_item", NullValueHandling = NullValueHandling.Ignore)]
        public Status WarlordItem { get; set; }

        [JsonProperty("gem_level", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog GemLevel { get; set; }

        [JsonProperty("quality", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Quality { get; set; }
    }

    public partial class ModFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public ModFiltersFilters Filters { get; set; }
    }

    public partial class ModFiltersFilters
    {
        [JsonProperty("empty_suffix", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog EmptySuffix { get; set; }

        [JsonProperty("empty_prefix", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog EmptyPrefix { get; set; }
    }

    public partial class ReqFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public ReqFiltersFilters Filters { get; set; }
    }

    public partial class ReqFiltersFilters
    {
        [JsonProperty("str", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Str { get; set; }

        [JsonProperty("int", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Int { get; set; }

        [JsonProperty("dex", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Dex { get; set; }

        [JsonProperty("lvl", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Lvl { get; set; }
    }

    public partial class SocketFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public SocketFiltersFilters Filters { get; set; }
    }

    public partial class SocketFiltersFilters
    {
        [JsonProperty("sockets", NullValueHandling = NullValueHandling.Ignore)]
        public Links Sockets { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public Links Links { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public long? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }

        [JsonProperty("r", NullValueHandling = NullValueHandling.Ignore)]
        public long? R { get; set; }

        [JsonProperty("g", NullValueHandling = NullValueHandling.Ignore)]
        public long? G { get; set; }

        [JsonProperty("b", NullValueHandling = NullValueHandling.Ignore)]
        public long? B { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public long? W { get; set; }
    }

    public partial class TradeFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public TradeFiltersFilters Filters { get; set; }
    }

    public partial class TradeFiltersFilters
    {
        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public Account Account { get; set; }

        [JsonProperty("indexed", NullValueHandling = NullValueHandling.Ignore)]
        public Status Indexed { get; set; }

        [JsonProperty("sale_type", NullValueHandling = NullValueHandling.Ignore)]
        public Status SaleType { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public SPrice Price { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public string Input { get; set; }
    }

    public partial class SPrice
    {
        [JsonProperty("option", NullValueHandling = NullValueHandling.Ignore)]
        public object Option { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public object Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public object Max { get; set; }
    }

    public partial class TypeFilters
    {
        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public TypeFiltersFilters Filters { get; set; }
    }

    public partial class TypeFiltersFilters
    {
        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public Status Category { get; set; }

        [JsonProperty("rarity", NullValueHandling = NullValueHandling.Ignore)]
        public Status Rarity { get; set; }
    }

    public partial class WeaponFilters
    {
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public WeaponFiltersFilters Filters { get; set; }
    }

    public partial class WeaponFiltersFilters
    {
        [JsonProperty("damage", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Damage { get; set; }

        [JsonProperty("crit", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Crit { get; set; }

        [JsonProperty("pdps", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Pdps { get; set; }

        [JsonProperty("edps", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Edps { get; set; }

        [JsonProperty("dps", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Dps { get; set; }

        [JsonProperty("aps", NullValueHandling = NullValueHandling.Ignore)]
        public PuneHedgehog Aps { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Filter> Filters { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public StatValue Value { get; set; }
    }

    public partial class StatValue
    {
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public long? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }
    }

    public partial class Filter
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public ModValue Value { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        public Filter(string id)
        {
            Id = id;
        }
    }

    public partial class ModValue
    {
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public long? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public long? Weight { get; set; }
    }

    public partial class Sort
    {
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("stat", NullValueHandling = NullValueHandling.Ignore)]
        public string stat { get; set; }
    }

    public class PropertyRenameAndIgnoreSerializerContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, HashSet<string>> _ignores;
        private readonly Dictionary<Type, Dictionary<string, string>> _renames;

        public PropertyRenameAndIgnoreSerializerContractResolver()
        {
            _ignores = new Dictionary<Type, HashSet<string>>();
            _renames = new Dictionary<Type, Dictionary<string, string>>();
        }

        public void IgnoreProperty(Type type, params string[] jsonPropertyNames)
        {
            if (!_ignores.ContainsKey(type))
                _ignores[type] = new HashSet<string>();

            foreach (var prop in jsonPropertyNames)
                _ignores[type].Add(prop);
        }

        public void RenameProperty(Type type, string propertyName, string newJsonPropertyName)
        {
            if (!_renames.ContainsKey(type))
                _renames[type] = new Dictionary<string, string>();

            _renames[type][propertyName] = newJsonPropertyName;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (IsIgnored(property.DeclaringType, property.PropertyName))
            {
                property.ShouldSerialize = i => false;
                property.Ignored = true;
            }

            if (IsRenamed(property.DeclaringType, property.PropertyName, out var newJsonPropertyName))
                property.PropertyName = newJsonPropertyName;

            return property;
        }

        private bool IsIgnored(Type type, string jsonPropertyName)
        {
            if (!_ignores.ContainsKey(type))
                return false;

            return _ignores[type].Contains(jsonPropertyName);
        }

        private bool IsRenamed(Type type, string jsonPropertyName, out string newJsonPropertyName)
        {
            Dictionary<string, string> renames;

            if (!_renames.TryGetValue(type, out renames) || !renames.TryGetValue(jsonPropertyName, out newJsonPropertyName))
            {
                newJsonPropertyName = null;
                return false;
            }

            return true;
        }
    }

    public partial class Search
    {
        public static Search FromJson(string json) => JsonConvert.DeserializeObject<Search>(json, Converter_Search.Settings);
    }

    public static class Serialize_Search
    {
        public static string ToJson(this Search self) => JsonConvert.SerializeObject(self, Converter_Search.Settings);
    }

    internal static class Converter_Search
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