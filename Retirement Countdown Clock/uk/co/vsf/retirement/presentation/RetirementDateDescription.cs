using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    internal abstract class RetirementDateDescription
    {
        public RetirementDateDescription Description { set; get; }

        public abstract String GetText(RetirementDate retirementDate);
    }
}
