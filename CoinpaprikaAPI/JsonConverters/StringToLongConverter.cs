using Newtonsoft.Json;
using System;

namespace CoinpaprikaAPI.JsonConverters
{
    public class StringToLongConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (string.IsNullOrWhiteSpace(value))
                return default(long);
            else
            {
                if (long.TryParse(value, out long l))
                {
                    return l;
                }
            }
            throw new System.Exception("Cannot unmarshal type long");
        }

 