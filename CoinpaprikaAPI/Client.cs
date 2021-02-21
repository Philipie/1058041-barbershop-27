using CoinpaprikaAPI.Base;
using CoinpaprikaAPI.Entity;
using CoinpaprikaAPI.JsonConverters;
using CoinpaprikaAPI.Models;
using CoinpaprikaAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinpaprikaAPI
{
    /// <summary>
    /// CoinPaprika API Client
    /// </summary>
    public class Client
    {
        private readonly string _apiBaseUrl;

        public Client(string version = "v1")
        {
            _apiBaseUrl = $"https://api.coinpaprika.com/{version}";
        }

        #region global

        /// <summary>
        /// Get global information
        /// </summary>
        public async Task<CoinPaprikaEntity<Global>> GetClobalsAsync()
        {
            var client = BaseClient.GetClient();
            
            var requestUrl = $"{_apiBaseUrl}/global";
            
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<Global>(response, false, !response.IsSuccessStatusCode, null);
        }

        #endregion

        #region coins
        /// <summary>
        /// Get all coins listed on coinpaprika
        /// </summary>
        public async Task<CoinPaprikaEntity<List<CoinInfo>>> GetCoinsAsync()
        {
            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<CoinInfo>>(response, false, !response.IsSuccessStatusCode, null);
        }

        /// <summary>
        /// Get coin by ID
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <returns></returns>
        public async Task<CoinPaprikaEntity<ExtendedCoinInfo>> GetCoinByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins/{id}";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<ExtendedCoinInfo>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Get twitter timeline for coin Id
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <returns></returns>
        public async Task<CoinPaprikaEntity<List<CoinTweetInfo>>> GetTwitterTimelineForCoinAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl