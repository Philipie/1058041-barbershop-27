using CoinpaprikaAPI.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CoinpaprikaAPI.Utils
{
    public class Helpers
    {
        #region Private Fields

        private static JsonSerializer _jsonSerializer = null;

        private sta