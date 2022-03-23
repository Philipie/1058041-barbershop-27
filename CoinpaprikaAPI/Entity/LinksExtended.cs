using System;
using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class LinksExtended
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("type")]
        