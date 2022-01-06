
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExchangeInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("adjusted_volume_24h_share")]
        public double AdjustedVolume24HShare { get; set; }

        [JsonProperty("fiats")]
        public List<FiatInfo> Fiats { get; set; }
    }
}