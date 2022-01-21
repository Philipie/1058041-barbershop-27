﻿using CoinpaprikaAPI.JsonConverters;
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
        public string DevelopmentStatus { get; set; }

        [JsonProperty("first_data_at")]
        public DateTimeOffset FirstDataAt { get; set; }

        [JsonProperty("hardware_wallet")]
        public bool HardwareWallet { get; set; }

        [JsonProperty("hash_algorithm")]
        publi