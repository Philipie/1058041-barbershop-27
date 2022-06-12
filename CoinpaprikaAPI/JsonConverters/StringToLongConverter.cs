using Newtonsoft.Json;
using System;

namespace CoinpaprikaAPI.JsonConverters
{
    public class StringToLongConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public overrid