using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Base
{
    public class Browser
    {
        private readonly DriverContext drivercontext;
        
        public Browser(DriverContext driver)
        {
            drivercontext = driver;
        }

        public BrowserType Type { get; set; }

        
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge,
    }
}
