//using CPD.Pages;
using CPD_AWS.Pages;
using RACGP_AutomationFramework.Base;
using RACGP_AutomationFramework.Config;
using RACGP_AutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CPD.Steps
{
    [Binding]
    public  class ExtendedSteps:BaseSteps
    {
        private readonly ParallelConfig _parallelConfig;
        public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void NavigateSite()
        {
            _parallelConfig.CurrentDriver.Navigate().GoToUrl(Settings.AUT);
            //_parallelConfig.CurrentDriver.Navigate().GoToUrl(Settings.AUT);
            //var environment = Environment.GetEnvironmentVariable("MAIN_WEBSITE_LOGIN_URL");
            //_parallelConfig.CurrentDriver.Navigate().GoToUrl(environment);
            //_parallelConfig.CurrentDriver.Navigate().GoToUrl("https://test.racgp.org.au/login");
            LogHelpers.Write("Opened the Browser");  
            _parallelConfig.CurrentDriver.Manage().Window.Maximize();
        }

        [Given(@"I go to Login page")]
        public void GivenIGoToLoginPage()
        {
            NavigateSite();
            //_parallelConfig.CurrentPage = new LoginPage(_parallelConfig);
           
        }

        [When(@"I enter (.*) and (.*)")]
        public void WhenIEnterAndTrIning(string username, string password)
        {
            _parallelConfig.CurrentPage = new LoginPage(_parallelConfig);
            _parallelConfig.CurrentPage.As<LoginPage>().EnterUserCredentials(username, password);
        }

        [When(@"I enter sign in button")]
        public void WhenIEnterSignInButton()
        {
            _parallelConfig.CurrentPage.As<LoginPage>().ClickSignin();
        }


        //[Given(@"I enter (.*) and (.*)")]
        //public void GivenIEnterAnd(string username, string password)
        //{
        //    _parallelConfig.CurrentPage = new LoginPage(_parallelConfig);
        //    _parallelConfig.CurrentPage.As<LoginPage>().EnterUserCredentials(username, password);
        //}

        //[Given(@"I enter sign in button")]
        //public void GivenIEnterSignInButton()
        //{
        //    _parallelConfig.CurrentPage.As<LoginPage>().ClickSignin();
        //}

        [Then(@"navigate to MyCPD portal")]
        public void ThenNavigateToMyCPDPortal()
        {
            _parallelConfig.CurrentPage = new MyCPDHomePage(_parallelConfig);
            //_parallelConfig.CurrentPage.As<MyCPDHomePage>().EnterLogName();
        }

        [Then(@"navigate to (.*) page")]
        public void ThenNavigateToPage(string page)
        {
            if(page=="Log")
            {
                _parallelConfig.CurrentPage.As<MyCPDHomePage>().NavigateToQuickLogPage();
            }

            else if(page== "MyCPD")
            {
                _parallelConfig.CurrentPage = new MyCPDHomePage(_parallelConfig);
                _parallelConfig.CurrentPage.As<MyCPDHomePage>().NavigateToMyCPDPage();

            }

            else if(page=="Browse")
            {
                _parallelConfig.CurrentPage.As<MyCPDHomePage>().NavigateToBrowsePage();
            }
            
        }


    }
}
