using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RACGP_AutomationFramework.Base
{
    public class Base
    {

        public readonly ParallelConfig _parallelConfig; 
        public Base(ParallelConfig parallelConfig )
        {
            _parallelConfig = parallelConfig;
        }

        
        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {

            return (TPage)Activator.CreateInstance(typeof(TPage));
            
        }

        public TPage As<TPage>() where TPage :BasePage
        {
            return (TPage)this;
        }
    }
}
