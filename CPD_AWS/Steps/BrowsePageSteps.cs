using CPD_AWS.Pages;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CPD_AWS.Steps
{
    [Binding]
    public sealed class BrowsePageSteps: BaseSteps
    {
        private readonly ParallelConfig _parallelConfig;
        string _keyword;
        string _specificReq;
        string _activityCriteria;
        public BrowsePageSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Then(@"Enter search (.*)")]
        public void ThenEnterSearch(string keyword)
        {
            _parallelConfig.CurrentPage = new BrowsePage(_parallelConfig);
            _keyword = _parallelConfig.CurrentPage.As<BrowsePage>().EnterKeyword(keyword);
        }

        //[Given(@"Verify results(.*)")]
        //public void GivenVerifyResults(string keyword)
        //{
        //    _parallelConfig.CurrentPage.As<BrowsePage>().VerifyResults(keyword);
        //}

        [Then(@"Verify (.*) results")]
        public void ThenVerifyResults(string results)
        {
            if(results=="Keyword")
            {
                _parallelConfig.CurrentPage.As<BrowsePage>().VerifyKeywordResults(_keyword);
            }            

            else if(results== "SpecificRequirement")
            {
                _parallelConfig.CurrentPage.As<BrowsePage>().VerifySpecificRequirements(_specificReq);
            }
            
            else if(results== "ActivityCriteria")
            {
                _parallelConfig.CurrentPage.As<BrowsePage>().VerifyActivityCriteria(_activityCriteria);
            }
        }

        //[Then(@"Select specific requirement (.*)")]
        //public void ThenSelectSpecificRequirement(string specificRequirement)
        //{
        //    _parallelConfig.CurrentPage = new BrowsePage(_parallelConfig);
        //    _specificReq = _parallelConfig.CurrentPage.As<BrowsePage>().SelectSpecificRequirements(specificRequirement);
        //}

        [Then(@"Select specific requirement (.*)")]
        public void ThenSelectSpecificRequirement(string specificRequirement)
        {
            _parallelConfig.CurrentPage = new BrowsePage(_parallelConfig);
            _specificReq = _parallelConfig.CurrentPage.As<BrowsePage>().SelectSpecificRequirements(specificRequirement);
        }


        [Then(@"Select ActivityCriteria (.*)")]
        public void ThenSelectActivityCriteria(string activityCriteria)
        {
            _parallelConfig.CurrentPage = new BrowsePage(_parallelConfig);
            _activityCriteria =_parallelConfig.CurrentPage.As<BrowsePage>().SelectActivityCriteria(activityCriteria);           
        }


    }
}
