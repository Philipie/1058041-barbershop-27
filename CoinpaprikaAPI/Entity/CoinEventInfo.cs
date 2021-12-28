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

        [JsonProperty("date_to")]
        public string DateTo { get; set; }

        [JsonProperty("name")]
        p