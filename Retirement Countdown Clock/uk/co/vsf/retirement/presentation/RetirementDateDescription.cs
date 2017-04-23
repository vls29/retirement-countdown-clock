using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    abstract class RetirementDateDescription
    {
        protected RetirementDateDescription retirementDateDescription;

        public void setRetirementDateDescription(RetirementDateDescription retirementDateDescription)
        {
            this.retirementDateDescription = retirementDateDescription;
        }

        public abstract String getText(RetirementDate retirementDate);
    }
}
