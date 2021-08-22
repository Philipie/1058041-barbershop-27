﻿using CoinpaprikaAPI.Base;
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

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/twitter";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<CoinTweetInfo>>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Get coin events by coin Id
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <returns></returns>
        public async Task<CoinPaprikaEntity<List<CoinEventInfo>>> GetEventsForCoinAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/events";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<CoinEventInfo>>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Get exchanges by coin Id
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <returns></returns>
        public async Task<CoinPaprikaEntity<List<ExchangeInfo>>> GetExchangesForCoinAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/exchanges";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<ExchangeInfo>>(response, false, !response.IsSuccessStatusCode);

        }

        /// <summary>
        /// Get markets by coin Id
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <param name="quotes">Comma separated list of quotes to return. Currently allowed values: USD, BTC, ETH, PLN</param>
        public async Task<CoinPaprikaEntity<List<MarketInfo>>> GetMarketsForCoinAsync(string id, string[] quotes = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var quotesString = quotes?.ToArrayString() ?? "USD";

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/markets".AddParameterToUrl("quotes", quotesString);

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<MarketInfo>>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Latest Open/High/Low/Close values with volume and market_cap by coin Id
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <param name="quote">returned data quote (available values: usd btc)</param>
        public async Task<CoinPaprikaEntity<List<OhlcValue>>> GetLatestOhlcForCoinAsync(string id, string quote = "USD")
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/ohlcv/latest".AddParameterToUrl("quote", quote);

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<OhlcValue>>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Historical Open/High/Low/Close values with volume and market_cap by coin Id
        /// </summary>
        /// <param name="id">id of the coin</param>
        /// <param name="startTime">start point for historical data</param>
        /// <param name="endTime">end point for historical data</param>
        /// <param name="limit">limit of result rows (max 5000)</param>
        /// <param name="quote">returned data quote (available values: usd, btc)</param>
        public async Task<CoinPaprikaEntity<List<OhlcValue>>> GetHistoricalOhlcForCoinAsync(string id, DateTimeOffset startTime, DateTimeOffset endTime = default, int limit = 1000, string quote = "USD")
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            if (limit < 1 || limit > 366)
                throw new ArgumentOutOfRangeException(nameof(limit), "limit must be between 1 and 250");


            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/ohlcv/historical".
                AddParameterToUrl("start", startTime.ToUnixTimeSeconds()).
                AddParameterToUrl("end", endTime == default ? DateTimeOffset.Now.ToUnixTimeSeconds() : endTime.ToUnixTimeSeconds()).
                AddParameterToUrl("limit", limit).
                AddParameterToUrl("quote", quote);

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<OhlcValue>>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Latest Open/High/Low/Close values with volume and market_cap by coin Id
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <param name="quote">returned data quote (available values: usd btc)</param>
        public async Task<CoinPaprikaEntity<List<OhlcValue>>> GetTodayOhlcForCoinAsync(string id, string quote = "USD")
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins/{id}/ohlcv/today".AddParameterToUrl("quote", quote);

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<OhlcValue>>(response, false, !response.IsSuccessStatusCode);
        }


        #endregion

        #region tickers
        /// <summary>
        /// Get ticker information for all coins
        /// </summary>
        public async Task<CoinPaprikaEntity<List<TickerWithQuotesInfo>>> GetTickersAsync(string[] quotes = null)
        {
            var client = BaseClient.GetClient();

            if (quotes?.Any(q => !q.IsSupportedQuoteSymbol()) ?? false)
                throw new ArgumentOutOfRangeException(nameof(quotes), "The passed quotes contains invalid symbols.");

            var quotesString = quotes?.ToArrayString() ?? "USD";

            var requestUrl = $"{_apiBaseUrl}/tickers".AddParameterToUrl("quotes", quotesString);

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            return new CoinPaprikaEntity<List<TickerWithQuotesInfo>>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Get ticker information for specific coin
        /// </summary>
        /// <param name="id">Id of coin to return e.g. btc-bitcoin, eth-ethereum</param>
        /// <param name="quotes">Comma separated list of quotes to return. Currently allowed values: USD, BTC, ETH</param>
        public async Task<CoinPaprikaEntity<TickerInfo>> GetTickerForIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/ticker/{id}";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            return new CoinPaprikaEntity<TickerInfo>(response, false, !response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Get historical tickers for specific coin
        /// </summary>
        /// <param name="id">id of the coin</param>
        /// <param name="startTime">start point for historical data</param>
        /// <param name="endTime">end point for historical data</param>
        /// <param name="limit">limit of result rows (max 5000)</param>
        /// <param name="quote">returned data quote (available values: usd, btc)</param>
        /// <param name="interval">returned points interval</param>
        /// <returns></returns>
        public async Task<CoinPaprikaEntity<List<HistoricalTickerInfo>>> GetHistoricalTickerForIdAsync(string id, DateTimeOffset startTime, DateTimeOffset endTime = default, int limit = 1000, string quote = "USD", TickerInterval interval = TickerInterval.FifteenMinutes)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            if (limit < 1 || limit > 5000)
                throw new ArgumentOutOfRangeException(nameof(limit), "limit must be between 1 and 250");

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/tickers/{id}/historical".
                AddParameterToUrl("start", startTime.ToUnixTimeSeconds()).
                AddParameterToUrl("end", endTime == default ? DateTimeOffset.Now.ToUnixTimeSeconds() : endTime.ToUnixTimeSeconds()).
                AddParameterToUrl("limit", limit).
                AddParameterToUrl("quote", quote).
                AddParameterToUrl("interval", interval.ToIntervalString());

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            //var json = await response.Content.ReadAsStringAsync();

            return new CoinPaprikaEntity<List<HistoricalTickerInfo>>(response, false, !response.IsSuccessStatusCode);
        }

        #endregion

        #region exchanges
        /// <summary>
        /// List exchanges
        /// </summary>
        /// <param name="quotes">list of quotes to return. Currently allowed values: USD, BTC, ETH, PLN</param>
        public async Task<CoinPaprikaEntity<List<ExtendedExchangeInfo>>> GetExchangesAsync(string[] quotes = null)
        {
            if (quotes?.Any(q => !q.IsSupportedQuoteSymbol()) ?? false)
                throw new ArgumentOutOfRangeException(nameof(quotes), "The passed quotes contains invalid symbols.");

            var client = BaseClient.GetClient();

            var quotesString = quotes?.ToArrayString() ?? "USD";

            var requestUrl = $"{_apiBaseUrl}/exchanges".AddParameterToUrl("quotes", quotesString);

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            return new CoinPaprikaEntity<List<ExtendedExchangeInfo>>(response, false, !response.IsSuccessStatusCode, null);
        }

        /// <summary>
        /// Get Exchange by Id
        /// </summary>
        /// <param name="id">if of the exchange to fetch</param>
        /// <param name="quotes">list of quo