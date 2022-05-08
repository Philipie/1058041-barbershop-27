using Newtonsoft.Json;
using System;

namespace CoinpaprikaAPI.JsonConverters
{
    public class StringToDezimalConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(decimal) || t == typeof(decimal?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (string.IsNullOrWhiteSpace(value))
                return default(decimal);
            else
            {
                if (decimal.TryParse(value, out decimal d))
                {