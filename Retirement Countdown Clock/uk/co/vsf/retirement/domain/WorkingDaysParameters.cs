using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock.uk.co.vsf.retirement.domain
{
    class WorkingDaysParameters
    {
        private int bankHolidays = 0;
        private int holidays = 0;
        private int workingDays = 1;

        public WorkingDaysParameters(int? workingDays, int? holidays, int? bankHolidays)
        {
            this.workingDays = fieldValue(this.workingDays, workingDays);
            this.bankHolidays = fieldValue(this.bankHolidays, bankHolidays);
            this.holidays = fieldValue(this.holidays, holidays);
        }

        private int fieldValue(int field, int? inputValue)
        {
            if (inputValue.HasValue && inputValue.Value > 0)
            {
                return inputValue.Value;
            }

            return field;
        }

        internal int getHolidays()
        {
            return holidays;
        }

        internal int getBankHolidays()
        {
            return bankHolidays;
        }

        internal int getWorkingDays()
        {
            return workingDays;
        }
    }
}
