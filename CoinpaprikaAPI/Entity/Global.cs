using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class Global
    {
        [JsonProperty("market_cap_usd")]
        public long MarketCapUsd { get; set; }

        [JsonProperty("volume_24h_usd")]
        public long V