
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class Links
    {
        [JsonProperty("explorer")]
        public List<Uri> Explorer { get; set; }

        [JsonProperty("facebook")]
        public List<Uri> Facebook { get; set; }

        [JsonProperty("reddit")]
        public List<Uri> Reddit { get; set; }

        [JsonProperty("source_code")]