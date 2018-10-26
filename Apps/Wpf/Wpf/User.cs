using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wpf
{
    /// <summary>
    /// Drupal user on OpenRFA.org
    /// </summary>
    public partial class User
    {
        [JsonProperty("uid")]
        public long Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("signature_format")]
        public string SignatureFormat { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("access")]
        public long Access { get; set; }

        [JsonProperty("login")]
        public long Login { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("init")]
        public string Init { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("roles")]
        public Dictionary<string, string> Roles { get; set; }

        [JsonProperty("field_title")]
        public Field FieldTitle { get; set; }

        [JsonProperty("field_company")]
        public Field FieldCompany { get; set; }

        [JsonProperty("field_first_name")]
        public Field FieldFirstName { get; set; }

        [JsonProperty("field_last_name")]
        public Field FieldLastName { get; set; }

        [JsonProperty("field_subscribe_to_new_forum_top")]
        public FieldSubscribeToNewForumTop FieldSubscribeToNewForumTop { get; set; }

        [JsonProperty("metatags")]
        public Metatags Metatags { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("contact")]
        public long Contact { get; set; }
    }

    public partial class Field
    {
        [JsonProperty("und")]
        public FieldCompanyUnd[] Und { get; set; }
    }

    public partial class FieldCompanyUnd
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("format")]
        public object Format { get; set; }

        [JsonProperty("safe_value")]
        public string SafeValue { get; set; }
    }

    public partial class FieldSubscribeToNewForumTop
    {
        [JsonProperty("und")]
        public FieldSubscribeToNewForumTopUnd[] Und { get; set; }
    }

    public partial class FieldSubscribeToNewForumTopUnd
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class Metatags
    {
        [JsonProperty("und")]
        public MetatagsUnd Und { get; set; }
    }

    public partial class MetatagsUnd
    {
        [JsonProperty("robots")]
        public Robots Robots { get; set; }
    }

    public partial class Robots
    {
        [JsonProperty("value")]
        public Dictionary<string, long> Value { get; set; }
    }

    public partial class Picture
    {
        [JsonProperty("fid")]
        public long Fid { get; set; }

        [JsonProperty("uid")]
        public long Uid { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("filemime")]
        public string Filemime { get; set; }

        [JsonProperty("filesize")]
        public long Filesize { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this Wpf self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    //}

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters = {
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}

    //internal class ParseStringConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        long l;
    //        if (Int64.TryParse(value, out l))
    //        {
    //            return l;
    //        }
    //        throw new Exception("Cannot unmarshal type long");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (long)untypedValue;
    //        serializer.Serialize(writer, value.ToString());
    //        return;
    //    }

    //    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    //}

}
