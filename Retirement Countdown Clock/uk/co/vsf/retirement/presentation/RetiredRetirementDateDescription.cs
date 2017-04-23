using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class RetiredRetirementDateDescription : RetirementDateDescription
    {
        public override String getText(RetirementDate retirementDate)
        {
            if (retirementDate.isRetired())
            {
                return "You've retired lucky thing!";
            }

            else { return retirementDateDescription.getText(retirementDate); }
        }
    }
}
