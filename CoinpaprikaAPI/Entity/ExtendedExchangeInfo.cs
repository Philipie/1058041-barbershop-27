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

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("links")]
        public Excha