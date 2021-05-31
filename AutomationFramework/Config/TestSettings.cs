using Newtonsoft.Json;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Config
{
    [JsonObject("testsettings")]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("browserType")]
        public BrowserType Browser { get; set; }

        //[JsonProperty("testType")]
        //public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        //[JsonProperty("isReport")]
        //public string IsReport { get; set; }

        //[JsonProperty("autConnectionString")]
        //public string AUTDBConnectionString { get; set; }



    }
}
