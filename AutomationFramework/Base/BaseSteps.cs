using RACGP_AutomationFramework.Config;
using RACGP_AutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Base
{
    public abstract class BaseSteps : Base
    {
        public BaseSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
    }
}
