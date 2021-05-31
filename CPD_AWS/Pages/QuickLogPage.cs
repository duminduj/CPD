
using NUnit.Framework;
using OpenQA.Selenium;
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
    class QuickLogPage:BasePage
    {
        string _cpdType;
        int _hours;
        public static  int _points;
        string _expectedPoints;
        public QuickLogPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        IWebElement LogName => _parallelConfig.CurrentDriver.FindByXpath("//div/input[@class='MuiInputBase-input MuiOutlinedInput-input MuiAutocomplete-input MuiAutocomplete-inputFocused MuiInputBase-inputAdornedEnd MuiOutlinedInput-inputAdornedEnd']");
        IWebElement LogDate => _parallelConfig.CurrentDriver.FindByXpath("//div[@class='MuiInputBase-root MuiOutlinedInput-root MuiInputBase-formControl MuiInputBase-adornedEnd MuiOutlinedInput-adornedEnd']/input");
        IWebElement HoursLogged => _parallelConfig.CurrentDriver.FindByXpath("//div[@class='MuiInputBase-root MuiOutlinedInput-root MuiInputBase-formControl']/input");
        IWebElement Points => _parallelConfig.CurrentDriver.FindByXpath("//div[@class='MuiGrid-root MuiGrid-item MuiGrid-grid-xs-6 MuiGrid-grid-md-8']/div");
        IWebElement TypeOfCpd => _parallelConfig.CurrentDriver.FindByXpath("//div[@role='radiogroup']/label/span/span/input[@name='typeOfCpd' and @value='" + _cpdType + "']");
        IWebElement Notes => _parallelConfig.CurrentDriver.FindByXpath("//div[@class='MuiInputBase-root MuiOutlinedInput-root MuiInputBase-formControl MuiInputBase-multiline MuiOutlinedInput-multiline']/textarea");
        IWebElement btnSubmit => _parallelConfig.CurrentDriver.FindByXpath("//span[contains(text(),'Submit')]");
        IWebElement SuccessMessage => _parallelConfig.CurrentDriver.FindByXpath("//div[@class='MuiAlert-message']");
        IWebElement btnUpdate => _parallelConfig.CurrentDriver.FindByXpath("//span[contains(text(),'Update')]");

        public void EnterQuickLogDetails(string logName, string date, string hours, string cpdType, string notes)
        {
            var logDate = LogDate;
            var hoursLogged = HoursLogged;
            _cpdType = cpdType;

            LogName.Clear();
            LogName.SendKeys(logName);            

            logDate.SendKeys(Keys.Control + "a");
            ///Thread.Sleep(1000);
            //logDate.Clear();
            logDate.SendKeys(date);            

            hoursLogged.SendKeys(Keys.Control + "a");

            //WebDriverExtentions.HighlightText(HoursLogged,_parallelConfig.CurrentDriver);
            //WebDriverExtentions.BackSpaceDelete(HoursLogged, _parallelConfig.CurrentDriver);
            Thread.Sleep(2000);

            hoursLogged.SendKeys(hours + Keys.Tab);
            _hours = Convert.ToInt32(hours);

            cpdPoints();

            Thread.Sleep(1000);
            
            TypeOfCpd.Click();

        }

        public void EnterLogName(string logName)
        {
            //Thread.Sleep(2000);

            LogName.SendKeys(logName);
        }

        public void EnterLogDate(string date)
        {
            var logDate = LogDate;
            logDate.SendKeys(Keys.Control + "a");
            ///Thread.Sleep(1000);
            //logDate.Clear();
            logDate.SendKeys(date);
        }


        public void EnterHours(string hours)
        {
            var hoursLogged = HoursLogged;

            hoursLogged.SendKeys(Keys.Control + "a");
            
            //WebDriverExtentions.HighlightText(HoursLogged,_parallelConfig.CurrentDriver);
            //WebDriverExtentions.BackSpaceDelete(HoursLogged, _parallelConfig.CurrentDriver);
            Thread.Sleep(2000);

            hoursLogged.SendKeys(hours+Keys.Tab);
            _hours = Convert.ToInt32(hours);
            
            cpdPoints();            
            
        }

        public void cpdPoints()
        {            
                     
            _points = _hours * 2;

            if (_hours == 0.5)
            {
                _expectedPoints = _points + " point";
            }

            else
            {
                _expectedPoints = _points + " points";
            }

            var points = Points.Text;
            Assert.AreEqual(_expectedPoints, points);
            
        }
        

        public void SelectCpdType(string cpdType)
        {
            Thread.Sleep(1000);
            _cpdType = cpdType;
            TypeOfCpd.Click();

        }

        public void EnterNotes(string notes)
        {
            //Thread.Sleep(1000);
            Notes.SendKeys(notes);
        }

        public void Submit()
        {
            btnSubmit.Click();
            var expectedMessage = "Your Quick log entry has been submitted and will appear on your CPD statement soon";
            //Thread.Sleep(3000);
            var _successMessage = SuccessMessage.Text;
            Assert.AreEqual(expectedMessage, _successMessage);
        }

        public int CPDPoints
        {            
            get { return _points; }
            //set {  }
            set
            {
                _points = value;
            }
        }

        public void Update()
        {
            btnUpdate.Click();
            var expectedMessage = "Your Quick log activity has been updated.";
            Thread.Sleep(3000);
            var _successMessage = SuccessMessage.Text;
            Assert.AreEqual(expectedMessage, _successMessage);
        }
    }
}
