using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.presentation
{
    public class TwentyTwoYearRetirementDateDescription : RetirementDateDescription
    {
        public override String GetText(RetirementDate retirementDate)
        {
            if (retirementDate.GetDaysToRetirement() > 8030)
            {
                return "Unfortunately retirement is so far away, you ought to stop wishing your life away!";
            }

            else { return Description.GetText(retirementDate); }
        }
    }
}
