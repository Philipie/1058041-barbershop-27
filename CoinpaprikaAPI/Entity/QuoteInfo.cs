
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class QuoteInfo
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public decimal Volume24H { get; set; }

        [JsonProperty("volume_24h_change_24h")]
        public decimal Volume24HChange24H { get; set; }

        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public decimal MarketCapChange24H { get; set; }

        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1H { get; set; }

        [JsonProperty("percent_change_12h")]
        public decimal PercentChange12H { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")]