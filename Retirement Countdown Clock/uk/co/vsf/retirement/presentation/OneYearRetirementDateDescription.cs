using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class OneYearRetirementDateDescription : RetirementDateDescription
    {
        public override String getText(RetirementDate retirementDate)
        {
            if (retirementDate.getDaysToRetirement() < 365)
            {
                return "Lucky you! Not long to go now";
            }

            else { return retirementDateDescription.getText(retirementDate); }
        }
    }
}
