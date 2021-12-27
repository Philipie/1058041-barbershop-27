using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class CoinEventInfo
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [Js