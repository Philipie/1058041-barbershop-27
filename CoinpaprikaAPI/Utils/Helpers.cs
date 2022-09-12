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
        {
            return typeof(Helpers).Assembly.GetName().Name;
        }

        /// <summary>
        /// gets the current assembly version
        /// </summary>
        public static string GetAssemblyVersion()
        {
            var assembly = typeof(Helpers).Assembly.GetName();
            Version version = assembly.Version;

            return version.ToString();
        }

        /// <summary>
        /// gets a pre-configured JsonSerializer instance
        /// </summary>
        public static JsonSerializer GetConfiguredJsonSerializer()
        {
            if (_jsonSerializer == null)
            {
                _jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
            }

            return _jsonSerializer;
        }

        /// <summary>
        /// gets a pre-configured JsonSerializerSettings instance
        /// </summary>
        public static JsonSerializerSettings GetConfiguredJsonSerializerSettings()
        {
            if (_jsonSerializerSettings == null)
            {
                _jsonSerializerSettings = new JsonSerializerSettings()
                {
