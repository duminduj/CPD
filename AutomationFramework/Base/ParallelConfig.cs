using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Base
{
    public class ParallelConfig
    {
        public RemoteWebDriver CurrentDriver {get;set;}

        public BasePage CurrentPage { get; set; }

        public MediaEntityModelProvider CaptureScreenshot(string Name)
        {
            var screenshot = ((ITakesScreenshot)CurrentDriver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,Name).Build();
        }


    }
}
