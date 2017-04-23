using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class TwoYearRetirementDateDescription : RetirementDateDescription
    {
        public override String getText(RetirementDate retirementDate)
        {
            if (retirementDate.getDaysToRetirement() < 730)
            {
                return "Time to start planning for retirement";
            }

            else { return retirementDateDescription.getText(retirementDate); }
        }
    }
}
