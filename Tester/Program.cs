
﻿using CoinpaprikaAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await TestGlobalsAsync();
            //await TestCoinsAsync();
            //await TestCoinByIdAsync();
            //await TestTickerAllAsync();
            //await TestHistoricalTickerAsync();
            //await TestTickerAsync();
            //await TestSearchAsync();
            //await TestPeopleInfoAsync();
            //await TestTagsAsync();
            //await TestExchangesAsync();
            //await TestConversionAsync();

            await TestContractsAsync();
        }



        private static CoinpaprikaAPI.Client _client = new CoinpaprikaAPI.Client();

        static async Task TestGlobalsAsync()
        {
            Console.WriteLine("fetching globals...");

            var globals = await _client.GetClobalsAsync();

            if (globals.Error == null)
            {
                Console.WriteLine($"{nameof(globals.Value.MarketCapUsd)}: {globals.Value.MarketCapUsd}");
                Console.WriteLine($"{nameof(globals.Value.Volume24HUsd)}: {globals.Value.Volume24HUsd}");
                Console.WriteLine($"{nameof(globals.Value.BitcoinDominancePercentage)}: {globals.Value.BitcoinDominancePercentage}");
                Console.WriteLine($"{nameof(globals.Value.CryptocurrenciesNumber)}: {globals.Value.CryptocurrenciesNumber}");
                Console.WriteLine($"{nameof(globals.Value.LastUpdated)}: {globals.Value.LastUpdated}");
                Console.WriteLine("Press any key to finish test...");
                Console.ReadLine();
                Console.WriteLine("Bye!");
            }
        }

        static async Task TestCoinsAsync()
        {
            Console.WriteLine("fetching available coins...");

            var coins = await _client.GetCoinsAsync();

            if (coins.Error == null)
            {
                Console.WriteLine("coins available on CoinPaprika: ");
                foreach (var c in coins.Value.OrderBy(c => c.Rank))
                {
                    Console.WriteLine($"{c.Name}({c.Id}({c.Symbol})) - {c.Rank} - {nameof(c.IsActive)}:{c.IsActive}/{nameof(c.IsNew)}:{c.IsNew}");
                }

                Console.WriteLine("Press any key to finish test...");
                Console.ReadLine();
                Console.WriteLine("Bye!");
            }
        }

        static async Task TestCoinByIdAsync()
        {
            Console.WriteLine("Testing Coin by Id:");

            Console.WriteLine("enter coin id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching extended CoinInfo for id '{id}' ...");

            var extCoinInfo = await _client.GetCoinByIdAsync(id);

            if (extCoinInfo.Error == null)
            {
                Console.WriteLine($"Extended CoinInfo for {extCoinInfo.Value.Name}:");
                Console.WriteLine($"{extCoinInfo.Value.Description}");
                Console.WriteLine($"WhitePaper-Link: {extCoinInfo.Value.Whitepaper.Link}");
                Console.WriteLine("Explorers:");
                extCoinInfo.Value.Links.Explorer.ForEach(e => Console.WriteLine(e.OriginalString));
                Console.WriteLine("Website/Source Links:");
                extCoinInfo.Value.Links.Website?.ForEach(e => Console.WriteLine(e.OriginalString));
                extCoinInfo.Value.Links.SourceCode?.ForEach(e => Console.WriteLine(e.OriginalString));
                Console.WriteLine("Social Media Links:");
                extCoinInfo.Value.Links.Facebook?.ForEach(e => Console.WriteLine(e?.OriginalString));
                extCoinInfo.Value.Links.Medium?.ForEach(e => Console.WriteLine(e?.OriginalString));
                extCoinInfo.Value.Links.Reddit?.ForEach(e => Console.WriteLine(e?.OriginalString));
                extCoinInfo.Value.Links.Youtube?.ForEach(e => Console.WriteLine(e?.OriginalString));
            }
            else
            {
               Console.WriteLine($"{id} not found, please enter a valid id next time");
            }

            Console.WriteLine("Tweets:");
            var timeline = await _client.GetTwitterTimelineForCoinAsync(id);
            timeline.Value.ForEach(t => Console.WriteLine($"{t.Date}: {t.Status})"));

            Console.WriteLine("Events:");
            var events = await _client.GetEventsForCoinAsync(id);
            events.Value.ForEach(e => Console.WriteLine($"{e.Date} - {e.DateTo} : {e.Name}"));

            Console.WriteLine("Exchanges:");
            var exchanges = await _client.GetExchangesForCoinAsync(id);
            exchanges.Value.ForEach(e => Console.WriteLine($"{e.Name} - {e.AdjustedVolume24HShare}%"));

            Console.WriteLine("Markets:");
            var markets = await _client.GetMarketsForCoinAsync(id, new[] {"USD", "BTC" });
            markets.Value.ForEach(m => Console.WriteLine($"{m.BaseCurrencyName} on {m.ExchangeName}"));

            Console.WriteLine("OHLC Latest:");
            var ohlcvLatest = await _client.GetLatestOhlcForCoinAsync(id);
            ohlcvLatest.Value.ForEach(v => Console.WriteLine($"{id}: Open: {v.Open}({v.TimeOpen}), Close: {v.Close}({v.TimeClose}), High: {v.High}, Low: {v.Low}"));


            Console.WriteLine("OHLC Historical:");

            var firstOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var end = DateTime.Now.Subtract(TimeSpan.FromDays(1));

            var ohlcvHistorical = await _client.GetHistoricalOhlcForCoinAsync(id, new DateTimeOffset(firstOfMonth), end, 200);
            ohlcvHistorical.Value.ForEach(v => Console.WriteLine($"{id}: Open: {v.Open}({v.TimeOpen}), Close: {v.Close}({v.TimeClose}), High: {v.High}, Low: {v.Low}"));

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestTickerAllAsync()
        {
            Console.WriteLine("fetching ticker...");

            var ticker = await _client.GetTickersAsync(new[] { "USD", "BTC" });

            if (ticker.Error == null)
            {
                Console.WriteLine("CoinPaprika Tickers: ");
                foreach (var t in ticker.Value.OrderBy(c => c.Rank))
                {
                    Console.WriteLine($"{t.Name}({t.Id}({t.Symbol})) - {t.Rank} - BTC:{t.Quotes["BTC"].Price}/USD:{t.Quotes["USD"].Price} - PercentChange24h:{t.Quotes["BTC"].PercentChange24H}%(BTC)/{t.Quotes["USD"].PercentChange24H}%(USD)");
                }

                Console.WriteLine("Press any key to finish test...");
                Console.ReadLine();
                Console.WriteLine("Bye!");
            }
        }

        static async Task TestTickerAsync()
        {
            Console.WriteLine("Testing coin Ticker info:");

            Console.WriteLine("enter coin id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching ticker for id {id} ...");

            var ticker = await _client.GetTickerForIdAsync(id);

            if (ticker.Error == null)
            {
                Console.WriteLine($"{ticker.Value.Name}({ticker.Value.Id}({ticker.Value.Symbol})) - {ticker.Value.Rank} - BTC:{ticker.Value.PriceBtc}/USD:{ticker.Value.PriceUsd} - PercentChange24h:{ticker.Value.PercentChange24H}");
                Console.WriteLine("Press any key to finish test...");
            }
            else
            {
                Console.WriteLine($"CoinPaprika returned an error: {ticker.Error.ErrorMessage}");
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }


        static async Task TestHistoricalTickerAsync()
        {
            Console.WriteLine("Testing historical Ticker info:");

            Console.WriteLine("enter coin id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching ticker for id {id} ...");

            var ticker = await _client.GetHistoricalTickerForIdAsync(id, new DateTimeOffset(DateTime.Now.Subtract(TimeSpan.FromDays(1))), DateTimeOffset.Now, 1000, "USD", TickerInterval.OneHour);

            if (ticker.Error == null)
            {
                foreach (var historic in ticker.Value)
                {
                    Console.WriteLine($"(Ticker ({id}) : {historic.Timestamp}: ({historic.Price})) - {historic.Volume24H}");

                }
                Console.WriteLine("Press any key to finish test...");
            }
            else
            {
                Console.WriteLine($"CoinPaprika returned an error: {ticker.Error.ErrorMessage}");
            }

            Console.ReadLine();
            Console.WriteLine("Bye!");
        }

        static async Task TestPeopleInfoAsync()
        {
            Console.WriteLine("Testing Personinfo:");

            Console.WriteLine("enter person-id:");

            var id = Console.ReadLine();

            Console.WriteLine($"fetching person with id {id} ...");

            var person = await _client.GetPeopleByIdAsync(id);

            if (person.Error == null)