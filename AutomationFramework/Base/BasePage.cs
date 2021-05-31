using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Base
{
    public abstract class BasePage : Base
    {
       
        public BasePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
    }
}
