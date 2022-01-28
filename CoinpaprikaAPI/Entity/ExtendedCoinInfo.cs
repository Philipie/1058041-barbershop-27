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
        public string DevelopmentStatus { get; set; }

        [JsonProperty("first_data_at")]
        public DateTimeOffset FirstDataAt { get; set; }

        [JsonProperty("hardware_wallet")]
        public bool HardwareWallet { get; set; }

        [JsonProperty("hash_algorithm")]
        public string HashAlgorithm { get; set; }

        [JsonProperty("contract")]
        public string Contract { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("contracts")]
        public List<Contract> Contracts { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

        [JsonProperty("last_data_at")]
        public DateTimeOffset LastDataAt { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("links_extended")]
        public List<Link