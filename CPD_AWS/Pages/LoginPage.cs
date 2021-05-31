
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
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
    class LoginPage : BasePage
    {
        //private readonly RemoteWebDriver CurrentDriver;
        //WebDriverWait wait = null;

        public LoginPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        //IWebElement Username => _parallelConfig.CurrentDriver.FindById("okta-signin-username");
        //IWebElement Password => _parallelConfig.CurrentDriver.FindById("okta-signin-password");
        //IWebElement Signin => _parallelConfig.CurrentDriver.FindById("okta-signin-submit");
        //IWebElement InvalidErrorMessage => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='form1']//div/p");

        IWebElement Username => _parallelConfig.CurrentDriver.FindById("p_lt_ctl03_pageplaceholder_p_lt_WebPartZone2_zonePageBody_RACGPLogonForm_Login1_UserName");
        IWebElement Password => _parallelConfig.CurrentDriver.FindById("p_lt_ctl03_pageplaceholder_p_lt_WebPartZone2_zonePageBody_RACGPLogonForm_Login1_Password");
        IWebElement Signin => _parallelConfig.CurrentDriver.FindById("p_lt_ctl03_pageplaceholder_p_lt_WebPartZone2_zonePageBody_RACGPLogonForm_Login1_LoginButton");
        IWebElement InvalidErrorMessage => _parallelConfig.CurrentDriver.FindById("p_lt_ctl03_pageplaceholder_p_lt_WebPartZone2_zonePageBody_RACGPLogonForm_Login1_lbGeneralLoginErrorText");

        public void EnterUserCredentials(string username, string password)
        {
            //Thread.Sleep(5000);
            //Username.Click();
            Username.SendKeys(username);
            //Password.Click();
            Password.SendKeys(password);
            
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Username)).SendKeys(username);

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Password)).SendKeys(password);
            

        }

        public void ClickSignin()
        {
            Signin.Click();
        }

        public void VerifyInvalidLogin(string validation)
        {

            Thread.Sleep(2500);
            var message = InvalidErrorMessage.Text;
            validation = "The details you have entered are either incorrect or are no longer compliant with our increased system security requirements.";
            Assert.IsTrue(message.Contains(validation), validation + "doesnt contains message" );
            Thread.Sleep(2000);

        }

        public MyCPDHomePage LoginSucess()
        {
            //return new MyCPDHomePage();
            return new MyCPDHomePage(_parallelConfig);
            
        }

    }

}
