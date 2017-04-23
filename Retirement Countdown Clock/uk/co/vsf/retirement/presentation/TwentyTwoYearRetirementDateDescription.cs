using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class TwentyTwoYearRetirementDateDescription : RetirementDateDescription
    {
        public override String getText(RetirementDate retirementDate)
        {
            if (retirementDate.getDaysToRetirement() > 8030)
            {
                return "Unfortunately retirement is so far away, you ought to stop wishing your life away!";
            }

            else { return retirementDateDescription.getText(retirementDate); }
        }
    }
}
