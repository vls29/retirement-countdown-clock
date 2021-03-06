﻿using System;
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
        public double WorkingDays { get; private set; } = 1.0d;

        public WorkingDaysParameters(double? workingDays, int? holidays, int? bankHolidays)
        {
            this.WorkingDays = FieldValue(this.WorkingDays, workingDays);
            ValidateWorkingDaysInput();

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

        private double FieldValue(double field, double? inputValue)
        {
            if (inputValue.HasValue && inputValue.Value >= 0.5d)
            {
                return inputValue.Value;
            }

            return field;
        }
        private void ValidateWorkingDaysInput()
        {
            if (WorkingDays < 0.5d || WorkingDays > 7d)
            {
                throw new ArgumentException("Invalid input for working days.  Minimum working days 0.5, maximum working days 7.0, actual value found: '" + WorkingDays + "'");
            }
        }
    }
}
