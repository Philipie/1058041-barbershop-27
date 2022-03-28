using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class PersonalSocialLinks
    {
        [JsonProperty("github")]
        public List<PersonalSocialLinkInfo> Github { get; set; }

        [JsonProperty("linkedin")]
        public List<PersonalSocialLinkInfo> Linkedin { get; set; 