using Retirement_Countdown_Clock.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class RetirementDate
    {
        private DateTimeOffset selectedRetirementDate;

        public RetirementDate(DateTimeOffset selectedDate)
        {
            this.selectedRetirementDate = selectedDate;
        }

        public RetirementDate(long? ticks)
        {
            if (ticks.HasValue)
            {
                TimeSpan timeSpan = new System.TimeSpan();
                DateTimeOffset dto = new DateTimeOffset(ticks.Value, timeSpan);

                this.selectedRetirementDate = dto;
            }
            else {
                this.selectedRetirementDate = new DateTimeOffset(System.DateTime.Now);
            }
        }

        internal object getTicks()
        {
            return this.selectedRetirementDate.Ticks;
        }

        public int getDaysToRetirement()
        {
            if (isRetired())
            {
                return 0;
            }

            double totalDays = Math.Round((selectedRetirementDate - System.DateTime.Now).TotalDays, 0, MidpointRounding.AwayFromZero);
            return (int)totalDays;
        }

        public int getWorkingDaysToRetirement(WorkingDaysParameters workingDaysParameters)
        {
            int daysToRetirement = getDaysToRetirement();
            if (daysToRetirement == 0)
            {
                return daysToRetirement;
            }

            decimal years = ((decimal)daysToRetirement / 365.25m);

            int holidays = (int)(years * (decimal)workingDaysParameters.getHolidays());
            int bankHolidays = (int)(years * (decimal)workingDaysParameters.getBankHolidays());
            int workingDays = (int)((decimal)daysToRetirement * ((decimal)workingDaysParameters.getWorkingDays() / (decimal)7));

            return workingDays - bankHolidays - holidays;
        }

        public DateTimeOffset getDateTimeOffset()
        {
            return selectedRetirementDate;
        }

        public bool isRetired()
        {
            return (selectedRetirementDate.CompareTo(new DateTimeOffset(System.DateTime.Now)) < 0);
        }
    }
}
