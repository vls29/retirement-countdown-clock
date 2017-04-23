using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class TwoMonthRetirementDateDescription : RetirementDateDescription
    {
        public override String GetText(RetirementDate retirementDate)
        {
            if (retirementDate.GetDaysToRetirement() < 60)
            {
                return "Woo! The finish line is in sight";
            }

            else { return Description.GetText(retirementDate); }
        }
    }
}
