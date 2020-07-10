// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using PoE_Trade_Overlay.Queries;
//
//    var Listing = Listing.FromJson(jsonString);

namespace PoE_Trade_Overlay.Queries
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class Listing
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public List<Result> Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("listing", NullValueHandling = NullValueHandling.Ignore)]
        public Listing Listing { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("verified", NullValueHandling = NullValueHandling.Ignore)]
        public bool Verified { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public long W { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public long H { get; set; }

        [JsonProperty("ilvl", NullValueHandling = NullValueHandling.Ignore)]
        public long Ilvl { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("league", NullValueHandling = NullValueHandling.Ignore)]
        public string League { get; set; }

        [JsonProperty("shaper", NullValueHandling = NullValueHandling.Ignore)]
        public bool Shaper { get; set; }

        [JsonProperty("sockets", NullValueHandling = NullValueHandling.Ignore)]
        public List<Socket> Sockets { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("typeLine", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeLine { get; set; }

        [JsonProperty("identified", NullValueHandling = NullValueHandling.Ignore)]
        public bool Identified { get; set; }

        [JsonProperty("duplicated", NullValueHandling = NullValueHandling.Ignore)]
        public bool Duplicated { get; set; }

        [JsonProperty("corrupted", NullValueHandling = NullValueHandling.Ignore)]
        public bool Corrupted { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }

        [JsonProperty("additionalProperties", NullValueHandling = NullValueHandling.Ignore)]
        public List<AdditionalProperty> AdditionalProperties { get; set; }

        [JsonProperty("requirements", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Requirements { get; set; }

        [JsonProperty("frameType", NullValueHandling = NullValueHandling.Ignore)]
        public long FrameType { get; set; }

        [JsonProperty("stackSize", NullValueHandling = NullValueHandling.Ignore)]
        public long StackSize { get; set; }

        [JsonProperty("maxStackSize", NullValueHandling = NullValueHandling.Ignore)]
        public long MaxStackSize { get; set; }

        [JsonProperty("artFilename", NullValueHandling = NullValueHandling.Ignore)]
        public string ArtFilename { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public Category Category { get; set; }

        [JsonProperty("extended", NullValueHandling = NullValueHandling.Ignore)]
        public Extended Extended { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }

        [JsonProperty("explicitMods", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExplicitMods { get; set; }

        [JsonProperty("veiledMods", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> VeiledMods { get; set; }

        [JsonProperty("enchantMods", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> EnchantMods { get; set; }

        [JsonProperty("craftedMods", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CraftMods { get; set; }

        [JsonProperty("descrText", NullValueHandling = NullValueHandling.Ignore)]
        public string DescrText { get; set; }

        [JsonProperty("flavourText", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FlavourText { get; set; }

        [JsonProperty("prophecyText", NullValueHandling = NullValueHandling.Ignore)]
        public string ProphecyText { get; set; }

        [JsonProperty("implicitMods", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ImplicitMods { get; set; }

        [JsonProperty("pseudoMods", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PseudoMods { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("armour", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Armour { get; set; }

        [JsonProperty("jewels", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Jewels { get; set; }

        [JsonProperty("weapons", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Weapons { get; set; }
    }

    public partial class Extended
    {
        [JsonProperty("es", NullValueHandling = NullValueHandling.Ignore)]
        public long? Es { get; set; }

        [JsonProperty("es_aug", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EsAug { get; set; }

        [JsonProperty("mods", NullValueHandling = NullValueHandling.Ignore)]
        public Mods Mods { get; set; }

        //[JsonProperty("hashes", NullValueHandling = NullValueHandling.Ignore)]
        //public Hashes Hashes { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("dps", NullValueHandling = NullValueHandling.Ignore)]
        public double? Dps { get; set; }

        [JsonProperty("pdps", NullValueHandling = NullValueHandling.Ignore)]
        public double? Pdps { get; set; }

        [JsonProperty("edps", NullValueHandling = NullValueHandling.Ignore)]
        public double? Edps { get; set; }

        [JsonProperty("dps_aug", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DpsAug { get; set; }

        [JsonProperty("pdps_aug", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PdpsAug { get; set; }

        [JsonProperty("ev", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ev { get; set; }

        [JsonProperty("ev_aug", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EvAug { get; set; }

        [JsonProperty("ar", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ar { get; set; }

        [JsonProperty("ar_aug", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ArAug { get; set; }
    }

    public partial class Hashes
    {
        [JsonProperty("explicit", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<ExplicitUnion>> Explicit { get; set; }

        [JsonProperty("implicit", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<ExplicitUnion>> Implicit { get; set; }

        [JsonProperty("pseudo", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<string>> Pseudo { get; set; }
    }

    public partial class Mods
    {
        [JsonProperty("implicit", NullValueHandling = NullValueHandling.Ignore)]
        public List<ExplicitClass> Implicit { get; set; }

        [JsonProperty("explicit", NullValueHandling = NullValueHandling.Ignore)]
        public List<ExplicitClass> Explicit { get; set; }
    }

    public partial class ExplicitClass
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("tier", NullValueHandling = NullValueHandling.Ignore)]
        public string Tier { get; set; }

        [JsonProperty("magnitudes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Magnitude> Magnitudes { get; set; }
    }

    public partial class Magnitude
    {
        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public double Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long Max { get; set; }
    }

    public partial class Property
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<Value>> Values { get; set; }

        [JsonProperty("displayMode", NullValueHandling = NullValueHandling.Ignore)]
        public long DisplayMode { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public long? Type { get; set; }
    }

    public partial class AdditionalProperty
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<Value>> Values { get; set; }

        [JsonProperty("displayMode", NullValueHandling = NullValueHandling.Ignore)]
        public long? DisplayMode { get; set; }

        [JsonProperty("progress", NullValueHandling = NullValueHandling.Ignore)]
        public double? Progress { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public long? Type { get; set; }
    }

    public partial class Socket
    {
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public long Group { get; set; }

        [JsonProperty("attr", NullValueHandling = NullValueHandling.Ignore)]
        public string Attr { get; set; }

        [JsonProperty("sColour", NullValueHandling = NullValueHandling.Ignore)]
        public string SColour { get; set; }
    }

    public partial class Listing
    {
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("indexed", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset Indexed { get; set; }

        [JsonProperty("stash", NullValueHandling = NullValueHandling.Ignore)]
        public Stash Stash { get; set; }

        [JsonProperty("whisper", NullValueHandling = NullValueHandling.Ignore)]
        public string Whisper { get; set; }

        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public Account Account { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public Price Price { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("lastCharacterName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastCharacterName { get; set; }

        [JsonProperty("online", NullValueHandling = NullValueHandling.Ignore)]
        public Online Online { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }
    }

    public partial class Online
    {
        [JsonProperty("league", NullValueHandling = NullValueHandling.Ignore)]
        public string League { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

    public partial class Price
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public float Amount { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("exchange", NullValueHandling = NullValueHandling.Ignore)]
        public ResultExchange Exchange { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public PriceItem Item { get; set; }
    }

    public partial class PriceItem
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? Amount { get; set; }

        [JsonProperty("stock", NullValueHandling = NullValueHandling.Ignore)]
        public long? Stock { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public partial class ResultExchange
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? Amount { get; set; }
    }

    public partial class Stash
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public long X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public long Y { get; set; }
    }

    public partial struct ExplicitUnion
    {
        public List<long> IntegerArray;
        public string String;

        public bool IsNull => IntegerArray == null && String == null;
    }

    public partial struct Value
    {
        public long? Integer;
        public string String;

        public bool IsNull => Integer == null && String == null;
    }

    public partial class Listing
    {
        public static Listing FromJson(string json) => JsonConvert.DeserializeObject<Listing>(json, ListingConverter.Settings);
    }

    public static class ListingSerialize
    {
        public static string ToJson(this Listing self) => JsonConvert.SerializeObject(self, ListingConverter.Settings);
    }

    internal static class ListingConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                ExplicitUnionConverter.Singleton,
                ValueConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ExplicitUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExplicitUnion) || t == typeof(ExplicitUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new ExplicitUnion { String = stringValue };

                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<long>>(reader);
                    return new ExplicitUnion { IntegerArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type ExplicitUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ExplicitUnion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.IntegerArray != null)
            {
                serializer.Serialize(writer, value.IntegerArray);
                return;
            }
            throw new Exception("Cannot marshal type ExplicitUnion");
        }

        public static readonly ExplicitUnionConverter Singleton = new ExplicitUnionConverter();
    }

    internal class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Value) || t == typeof(Value?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Value { Integer = integerValue };

                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Value { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type Value");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Value)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type Value");
        }

        public static readonly ValueConverter Singleton = new ValueConverter();
    }
}