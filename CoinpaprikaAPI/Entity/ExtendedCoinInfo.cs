using CoinpaprikaAPI.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExtendedCoinInfo
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("development_status")]
        pub