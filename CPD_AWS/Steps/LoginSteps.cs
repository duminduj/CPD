//using CPD.Pages;
using CPD_AWS.Pages;
using RACGP_AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CPD.Steps
{
    [Binding]
    public class LoginSteps:BaseSteps
    {
        private readonly ParallelConfig _parallelConfig;
        public LoginSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }        


        [Given(@"Verify invalid (.*) message")]
        public void GivenVerifyInvalidMessage(string validation)
        {
            _parallelConfig.CurrentPage.As<LoginPage>().VerifyInvalidLogin(validation);
        }

       


    }
}
