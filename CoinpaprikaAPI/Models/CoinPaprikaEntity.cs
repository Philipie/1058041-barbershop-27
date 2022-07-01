﻿using CoinpaprikaAPI.Entity;
using CoinpaprikaAPI.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace CoinpaprikaAPI.Models
{
    /// <summary>
    /// Wrapper around the CoinPaprika API response
    /// </summary>
    /// <typeparam name="TPaprikaEntity">type of the response data</typeparam>
    public class CoinPaprikaEntity<TPaprikaEntity>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private 