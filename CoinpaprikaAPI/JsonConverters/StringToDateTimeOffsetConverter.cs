﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.JsonConverters
{
    public class StringToDateTimeOffsetConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset) || t == typeof(DateTimeOffset?);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (string.IsNullOrWhiteSpace(value))
                return default(DateTimeOffset);
        