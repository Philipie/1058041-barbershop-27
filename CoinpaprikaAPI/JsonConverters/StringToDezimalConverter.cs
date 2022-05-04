using Newtonsoft.Json;
using System;

namespace CoinpaprikaAPI.JsonConverters
{
    public class StringToDezimalConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(decimal) || t == typeof(decimal?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == 