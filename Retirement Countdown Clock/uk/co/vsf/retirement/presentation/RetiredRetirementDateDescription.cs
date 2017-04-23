using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class RetiredRetirementDateDescription : RetirementDateDescription
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
