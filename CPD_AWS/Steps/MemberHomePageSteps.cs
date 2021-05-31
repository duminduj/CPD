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
    class MemberHomePageSteps:BaseSteps
    {
        private readonly ParallelConfig _parallelConfig;
        public MemberHomePageSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [When(@"navigate to MyCPD Portal")]
        public void WhenNavigateToMyCPDPortal()
        {
            _parallelConfig.CurrentPage = new MemberHomePage(_parallelConfig);
            _parallelConfig.CurrentPage.As<MemberHomePage>().NavigateToCPD();
        }

        //commment out
        [Given(@"Navigate to MyCPD page")]
        public void GivenNavigateToMyCPDPage()
        {
            _parallelConfig.CurrentPage = new MemberHomePage(_parallelConfig);
            _parallelConfig.CurrentPage.As<MemberHomePage>().NavigateToCPD();

        }

    }
}
