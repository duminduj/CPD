using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RACGP_AutomationFramework.Base;
using RACGP_AutomationFramework.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPD_AWS.Pages
{
    class MemberHomePage: BasePage
    {
        public MemberHomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        IWebElement MyAccountbtn => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='top-menu-account']/button");

        IWebElement MyCPDbtn => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='top-menu-account-flyout']/a[normalize-space(text())='myCPD']");



        public void NavigateToCPD()
        {
            WebDriverExtentions.WaitForPageToLoad(_parallelConfig.CurrentDriver);
            Thread.Sleep(5000);
            MyAccountbtn.Click();
            Thread.Sleep(3000);
            MyCPDbtn.Click();

            

        }

    }
}
