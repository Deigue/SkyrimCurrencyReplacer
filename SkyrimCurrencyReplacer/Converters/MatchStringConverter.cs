using System;
using Newtonsoft.Json;
using SkyrimCurrencyReplacer.Config;

namespace SkyrimCurrencyReplacer.Converters
{
    public class MatchStringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<MatchString>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IMatchField);
        }
    }
}