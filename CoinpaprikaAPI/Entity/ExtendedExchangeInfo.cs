using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExtendedExchangeInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonPro