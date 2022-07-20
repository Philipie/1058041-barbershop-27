using CoinpaprikaAPI.Entity;
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

        private readonly JsonSerializer _jsonSerializer;

        private CoinPaprikaEntity(bool throwSerializationExceptions)
        {
            _jsonSerializerSettings = Helpers.GetConfiguredJsonSerializerSettings();
            _jsonSerializer = Helpers.GetConfiguredJsonSerializer();

            if (!throwSerializationExceptions)
            {
                _jsonSerializerSettings.Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                {
                    this.Error = new CoinPaprikaError()
                    {
                        ErrorMessage = args.ErrorContext.Error.Message
                    };

                    this.RawError = ToRawError(this.Error);

                    this.Value = default;                    
                    this.Raw = null;

                    args.ErrorContext.Handled = true;
                };

            }
        }
        

        public CoinPaprikaEntity(HttpResponseMessage response, bool throwSerializationExceptions = false, bool isError = false, List<JsonConverter> converters = null) : this (throwSerializationExceptions)
        {
            if (converters?.Any() ?? false)
                foreach (var converter in converters)
                    _jsonSerializer.Converters.Add(converter);


            using (var stream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult())
            {
                using (var reader = new StreamReader(stream))
                {
                    if (!isError)
                    {
                        using (var jsonReader = new JsonTextReader(reader))
                        {
                            //never forget this if you are reading the stream twice!
                            jsonReader.CloseInput = false;

                            this.Value = _jsonSerializer.Deserialize<TPaprikaEntity>(jsonReader);

                            if (this.Value != null)
                            {
                                this.Raw = ToRaw(this.Value);

                                this.Error = null;
                                this.RawError = null;
               