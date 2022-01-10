using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExchangeMarketInfo
    {
        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("base_currency_id")]
        public string BaseCurrencyId { get; set; }

        [JsonProperty("base_currency_name")]
        public string BaseCurrencyName { get; set; }

        [JsonProperty("quote_currency_id")]
        public string QuoteCur