
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
//CPD.Pages
{
    class MyCPDHomePage:BasePage
    {
        public MyCPDHomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        
        IWebElement MyCPDButton => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/header//div/a/span[contains(text(),'myCPD')]");
        IWebElement MyHistoryTitle => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/button/span[text()='My history']");
        IWebElement LogButton => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/header//div/a/span[contains(text(),'Log')]");
        IWebElement BrowsePage => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/header//div/a/span[contains(text(),'Browse')]");
        IWebElement CPDPointsLabel => _parallelConfig.CurrentDriver.FindByXpath("//div/img[@alt='Trophy']/following::div[2]/p[1]");
        IWebElement MyQuickLogHistoryButton => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/button/span[text()='My Quick log history']");
        IWebElement FirstQuickLogID => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/table/tbody/tr[1]/td/div/p[@class='MuiTypography-root MuiTypography-body1'][1]");
        IWebElement EditQuickLogButton => _parallelConfig.CurrentDriver.FindByXpath("//*[@id='root']//div/table/tbody/tr[1]/td/div/a");

        private static int InitialPoints ;
        int UpdatedPoints;
        

        public void MyHistoryTitleExists()
        {
            WebDriverExtentions.WaitForPageToLoad(_parallelConfig.CurrentDriver);
            //Thread.Sleep(5000);
            var _myHistory = MyHistoryTitle.Text;
            Assert.IsNotNull(_myHistory);

            //MyHistoryTitle.AssertElementPresent();
            

        }

        public void NavigateToQuickLogPage()
        {
            LogButton.Click();
        }

        public void NavigateToMyCPDPage()
        {
            MyCPDButton.Click();
            
        }

        public void NavigateToBrowsePage()
        {
            BrowsePage.Click();
        }

        public void  GetPoints()
        {
            var _points = CPDPointsLabel.Text;
            InitialPoints = Convert.ToInt32(_points);
            
            //return InitialPoints;

            //var t = new QuickLogPage(new ParallelConfig());
            //var points = t.CPDPoints();

            //if (InitialPoints==null)
            //{
            //    var _points = CPDPoints.Text;
            //    int InitialPoints = Convert.ToInt32(_points);
            //    return InitialPoints;
            //}
            //else
            //{
            //    //var getPoints = new QuickLogPage(new _parallelConfig.CurrentDriver);
            //    QuickLogPage getPoints = new QuickLogPage(_parallelConfig);
            //    int _getP = getPoints.CPDPoints();

            //    UpdatedPoints = CPDPoints.Text;
            //    var newpoints = InitialPoints + _getP;
            //    Assert.AreEqual(newpoints, UpdatedPoints);
            //    return UpdatedPoints;

            //}

            
        }

        public void GetUpdatedPoints()
        {
            QuickLogPage getPoints = new QuickLogPage(_parallelConfig);
            int _getP = getPoints.CPDPoints;
            

            _parallelConfig.CurrentPage = new MyCPDHomePage(_parallelConfig);
            WebDriverExtentions.WaitForPageToLoad(_parallelConfig.CurrentDriver);            
            _parallelConfig.CurrentDriver.Navigate().Refresh();
            Thread.Sleep(4000);
            _parallelConfig.CurrentDriver.Navigate().Refresh();
            var _updatedPoints = CPDPointsLabel.Text;
            UpdatedPoints = Convert.ToInt32(_updatedPoints);
            var newpoints = InitialPoints + _getP;
            Assert.AreEqual(newpoints, UpdatedPoints);
            //return UpdatedPoints;

        }

        public void SelectMyQuickLogHistory()
        {
            MyQuickLogHistoryButton.Click();
        }

        public void EditQuickLog()
        {
            var quicklogID = FirstQuickLogID.Text;
            EditQuickLogButton.Click();

        }
    }
}
