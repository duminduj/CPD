using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Base
{
    public class DriverContext
    {

        public readonly ParallelConfig _parallelConfig;
        public DriverContext(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        public void GoToUrl(string url)
        {
            _parallelConfig.CurrentDriver.Url = url;
        }

        public static Browser Browser { get; set; }
        


    }
}
