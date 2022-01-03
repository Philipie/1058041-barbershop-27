using System;
using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class ContractDetailInfo
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set;