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

        private static JsonSerializerSettings _jsonSerializerSettings = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// gets the current assembly name
        /// </summary>
        public static string GetAssemblyName()
      