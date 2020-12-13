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

    