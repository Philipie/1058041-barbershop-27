
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
