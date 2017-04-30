using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.presentation
{
    public abstract class RetirementDateDescription
    {
        public RetirementDateDescription Description { set; get; }

        public abstract String GetText(RetirementDate retirementDate);
    }
}
