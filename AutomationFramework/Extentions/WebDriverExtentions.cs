using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Extentions
{
    public static class WebDriverExtentions
    {
        
        public static void WaitForPageToLoad(this RemoteWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return.document.readyState").ToString();
                return state == "complete";
            },
            10000  );
        }

        public static void WaitForCondition<T>(this T obj,Func <T,bool>condition, int timeout)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds<timeout)
            {
                if(execute(obj))
                {
                    break;
                }
            }

        }

        public static IWebElement FindById(this RemoteWebDriver remoteWebDriver,string element)
        {
            WebDriverWait wait = new WebDriverWait(remoteWebDriver, TimeSpan.FromSeconds(20));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(element)));
            try
            {
                 //remoteWebDriver.WaitForPageToLoad();
                // var suffix = DateTime.Now.ToLongTimeString();
                // remoteWebDriver.GetScreenshot().SaveAsFile($"s_{suffix}.png");
                if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(element))).IsElementPresent())
                //if (remoteWebDriver.FindElementById(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementById(element);
                }
            }
            catch(Exception e)
            {
                throw e;
                throw new ElementNotVisibleException($"Element not Found:{element}");
            }
            return null;
        }

        public static IWebElement FindByXpath(this RemoteWebDriver remoteWebDriver, string element)
        {
            WebDriverWait wait = new WebDriverWait(remoteWebDriver, TimeSpan.FromSeconds(120));
            try
            {

                // remoteWebDriver.WaitForPageToLoad();
                // var suffix = DateTime.Now.ToLongTimeString();
                // remoteWebDriver.GetScreenshot().SaveAsFile($"s_{suffix}.png");
                
                if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(element))).IsElementPresent())
                //if (remoteWebDriver.FindElementByXPath(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementByXPath(element);
                }
            }
            catch (Exception e)
            {
                throw e;
                throw new ElementNotVisibleException($"Element not Found:{element}");
            }
            return null;
        }

        public static IWebElement FindByCSS(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {

                if (remoteWebDriver.FindElementByCssSelector(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementByCssSelector(element);
                }
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"Element not Found:{element}");
            }
            return null;
        }

        public static void HighlightText(this IWebElement element, RemoteWebDriver remoteWebDriver )
        {
            Actions action = new Actions(remoteWebDriver);
            element.Click();
            action.SendKeys(Keys.Home).Build().Perform();
            string textpresent = element.GetAttribute("value");
            int length = textpresent.Length;

            action.KeyDown(Keys.LeftShift);
            for (int i = 0; i < length; i++)
            {
                action.SendKeys(Keys.ArrowRight);
            }
            action.KeyUp(Keys.LeftShift);
            action.Build().Perform();

        }

        public static void BackSpaceDelete(this IWebElement element, RemoteWebDriver remoteWebDriver)
        {
            Actions action = new Actions(remoteWebDriver);
            element.Click();
            string textpresent = element.GetAttribute("value");
            int length = textpresent.Length;

            for (int i = 0; i < length; i++)
            {
                action.SendKeys(Keys.Backspace);
            }
            action.Build().Perform();
        }

        

    }
}
