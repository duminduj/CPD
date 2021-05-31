using AutomationFramework.Config;
using Microsoft.Extensions.Configuration;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace RACGP_AutomationFramework.Config
{
    public  class ConfigReader
    {      

        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();


            Settings.AUT = configurationRoot.GetSection("testsettings").Get<TestSettings>().AUT;
            Settings.IsLog = configurationRoot.GetSection("testsettings").Get<TestSettings>().IsLog;
            Settings.LogPath = configurationRoot.GetSection("testsettings").Get<TestSettings>().LogPath;            
            Settings.BrowserType = configurationRoot.GetSection("testsettings").Get<TestSettings>().Browser;

            ////Settings.BuildName = buildname.Value.ToString();
            ////Settings.TestType = testtype.Value.ToString();
            //Settings.IsLog = RACGP_TestConfigurations.RACGPSettings.TestSettings["dev"].IsLog;
            //Settings.LogPath = RACGP_TestConfigurations.RACGPSettings.TestSettings["dev"].LogPath;
            ////Settings.AppConnectionString = RACGP_TestConfigurations.RACGPSettings.TestSettings["dev"].AUTDBConnectionString;
            ////Settings.IsReport = RACGP_TestConfigurations.RACGPSettings.TestSettings["dev"].IsReport;
            //Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), RACGP_TestConfigurations.RACGPSettings.TestSettings["dev"].Browser);
        }
    }
}
