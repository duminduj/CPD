//using CPD.Pages;
using CPD_AWS.Pages;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CPD.Steps
{
    [Binding]
    class QuickLogSteps:BaseSteps
    {
        private readonly ParallelConfig _parallelConfig;
        public QuickLogSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"Navigate to QuickLog Page")]
        public void GivenNavigateToQuickLogPage()
        {
            _parallelConfig.CurrentPage.As<MyCPDHomePage>().NavigateToQuickLogPage();
        }

        [Then(@"Enter Quicklog details (.*),(.*),(.*), (.*), (.*)")]
        public void ThenEnterQuicklogDetails(string logName, string date, string hours, string typeOfCpd, string notes)
        {
            _parallelConfig.CurrentPage = new QuickLogPage(_parallelConfig);
            _parallelConfig.CurrentPage.As<QuickLogPage>().EnterQuickLogDetails(logName, date, hours, typeOfCpd, notes);
        }


        //[Then(@"Enter Log Name (.*)")]
        //public void ThenEnterLogName(string logName)
        //{
        //    _parallelConfig.CurrentPage = new QuickLogPage(_parallelConfig);
        //    _parallelConfig.CurrentPage.As<QuickLogPage>().EnterLogName(logName);
        //}

        //[Then(@"Select a Date (.*)")]
        //public void ThenSelectADate(string date)
        //{
        //    _parallelConfig.CurrentPage.As<QuickLogPage>().EnterLogDate(date);
        //}

        //[Then(@"Enter Hours (.*)")]
        //public void GivenEnterHours(string hours)
        //{
        //    _parallelConfig.CurrentPage.As<QuickLogPage>().EnterHours(hours);
        //}

        //[Given(@"Enter Type of CPD (.*)")]
        //public void GivenEnterTypeOfCPD(string typeOfCpd)
        //{
        //    _parallelConfig.CurrentPage.As<QuickLogPage>().SelectCpdType(typeOfCpd);
        //}

        //[Given(@"Enter Notes (.*)")]
        //public void GivenEnterNotes(string notes)
        //{
        //    _parallelConfig.CurrentPage.As<QuickLogPage>().EnterNotes(notes);
        //}


        [Then(@"Submit")]
        public void ThenSubmit()
        {
            _parallelConfig.CurrentPage.As<QuickLogPage>().Submit();
        }


        [Then(@"Update")]
        public void ThenUpdate()
        {
            _parallelConfig.CurrentPage.As<QuickLogPage>().Update();
        }


    }

}
