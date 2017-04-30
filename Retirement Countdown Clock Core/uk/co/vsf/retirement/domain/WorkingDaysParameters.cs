using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain
{
    public class WorkingDaysParameters
    {
        public int BankHolidays { get; private set; } = 0;
        public int Holidays { get; private set; } = 0;
        public int WorkingDays { get; private set; } = 1;

        public WorkingDaysParameters(int? workingDays, int? holidays, int? bankHolidays)
        {
            this.WorkingDays = FieldValue(this.WorkingDays, workingDays);
            this.BankHolidays = FieldValue(this.BankHolidays, bankHolidays);
            this.Holidays = FieldValue(this.Holidays, holidays);
        }

        private int FieldValue(int field, int? inputValue)
        {
            if (inputValue.HasValue && inputValue.Value > 0)
            {
                return inputValue.Value;
            }

            return field;
        }
    }
}
