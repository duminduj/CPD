using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using RACGP_AutomationFramework.Config;
using RACGP_AutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RACGP_AutomationFramework.Base
{
    public class TestInitializeHooks:Steps 
    {

        public readonly ParallelConfig _parallelConfig;
        private readonly IObjectContainer _objectContainer;

        public TestInitializeHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public TestInitializeHooks(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public readonly BrowserType Browser;

        public TestInitializeHooks(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            //set all settings
            ConfigReader.SetFrameworkSettings();

            //set log
            //LogHelpers.CreateLogFile();


            //*********
            //open browser
            //OpenBrowser(GetBrowserOption(Settings.BrowserType));
            //************

            //Working code
            OpenBrowser(Browser);
            //working code
            //LogHelpers.Write("Initialize the Browser");
        }

        private void OpenBrowser(BrowserType browserType)
        {

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    //comment or uncomment below 4 lines of code for headlless automation run
                    //option.AddArgument("--window-size=1920,1080");
                    //option.AddArgument("--start-maximized");
                    //option.AddArgument("--headless");
                    //option.AddArgument("--no-sandbox");

                    //option.AddArgument("--disable-gpu");
                    //option.AddArgument("--disable-dev-shm-usage");

                    //option.AddArgument("--ignore-certificate-errors");
                    //option.AddArgument("--disable-gpu");
                    //option.AddArgument("--allow-insecure-localhost");
                    //option.AddArgument("--allow-running-insecure-content");
                    //option.AddArgument("--user-agent=Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
                    //option.AddArgument("--headless");
                    //option.AddArgument("--no-sandbox");
                    //option.AcceptInsecureCertificates = true;
                    //option.AddArgument("--ignore-ssl-errors=true");
                    //option.AddArgument("--ssl-protocol=any");
                    //option.AddArgument("--remote-debugging-port=9222");
                    //option.AddArgument("window-size=1400,600");


                    //_parallelConfig.CurrentDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                    
                    _parallelConfig.CurrentDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),option);

                    //_objectContainer.RegisterFactoryAs<RemoteWebDriver>(_parallelConfig.CurrentDriver);

                    //_parallelConfig.CurrentDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));


                    //using (var _parallelConfig.CurrentDriver= new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                    //DriverContext.Browser = new Browser(_parallelConfig.CurrentDriver);
                    break;
                case BrowserType.Firefox:
                    _parallelConfig.CurrentDriver = new FirefoxDriver();

                    break;
                case BrowserType.Edge:
                    break;
                default:
                    _parallelConfig.CurrentDriver = new ChromeDriver();
                    //DriverContext.Browser = new Browser(DriverContext.CurrentDriver);
                    break;
            }
        }

        ////******** Update failed
        //private void OpenBrowser(DriverOptions driverOptions)
        //{

        //    switch (driverOptions)
        //    {
        //        case ChromeOptions chromeOptions:
        //            chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);

        //            //chromeOptions.AddAdditionalCapability(CapabilityType.BrowserName, "chrome");                    
        //            //chromeOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
        //            ////chromeOptions.Br =

        //            break;
        //        //case FirefoxOptions firefoxOptions:
        //        //    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");


        //        //    break;

        //        //case EdgeOptions edgeOptions:
        //        //    edgeOptions.AddAdditionalCapability(CapabilityType.BrowserName, "edge");

        //        //    break;
        //        //default:
        //            //_parallelConfig.CurrentDriver = new ChromeDriver();
        //            ////DriverContext.Browser = new Browser(DriverContext.CurrentDriver);
        //            //break;
        //    }

        //    _parallelConfig.CurrentDriver = new RemoteWebDriver(new Uri("http://192.168.1.10:4444/wd/hub"), driverOptions.ToCapabilities());
        //}
        ////******* upto here

        public virtual void NavigateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            //LogHelpers.Write("Opened the Browser");
        }

        //public DriverOptions GetBrowserOption(BrowserType browserType)
        //{
        //    switch (browserType)
        //    {
        //        case BrowserType.Edge:
        //            return new EdgeOptions();
        //        case BrowserType.Firefox:
        //            return new FirefoxOptions();
        //        case BrowserType.Chrome:
        //            return new ChromeOptions();
        //        default:
        //            return new ChromeOptions();
        //    }
        //}

    }
}
