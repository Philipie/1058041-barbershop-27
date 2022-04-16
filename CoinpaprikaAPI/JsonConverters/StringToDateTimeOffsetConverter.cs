using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.JsonConverters
{
    public class StringToDateTimeOffsetConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DateT