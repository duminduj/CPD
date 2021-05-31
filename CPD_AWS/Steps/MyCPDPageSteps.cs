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
    class MyCPDPageSteps: BaseSteps
    {

        private readonly ParallelConfig _parallelConfig;
        public MyCPDPageSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        [When(@"Verify Successfully loged in")]
        public void WhenVerifySuccessfullyLogedIn()
        {
            _parallelConfig.CurrentPage = new MyCPDHomePage(_parallelConfig);

            _parallelConfig.CurrentPage.As<MyCPDHomePage>().MyHistoryTitleExists();
            _parallelConfig.CurrentPage.As<MyCPDHomePage>().GetPoints();


        }

        [Then(@"Verify the points being update")]
        public void ThenVerifyThePointsBeingUpdate()
        {
            //_parallelConfig.CurrentPage = new MyCPDHomePage(_parallelConfig);
            _parallelConfig.CurrentPage.As<MyCPDHomePage>().GetUpdatedPoints();
        }

        [Then(@"Select My Quick Log history")]
        public void ThenSelectMyQuickLogHistpry()
        {
            _parallelConfig.CurrentPage.As<MyCPDHomePage>().SelectMyQuickLogHistory();
        }

        [Then(@"Edit the first record")]
        public void ThenSelectTheFirstRecord()
        {
            _parallelConfig.CurrentPage.As<MyCPDHomePage>().EditQuickLog();
        }


    }
}
