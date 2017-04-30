using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.presentation
{
    public class RetiredRetirementDateDescription : RetirementDateDescription
    {
        public override String GetText(RetirementDate retirementDate)
        {
            if (retirementDate.IsRetired())
            {
                return "You've retired lucky thing!";
            }

            else { return Description.GetText(retirementDate); }
        }
    }
}
