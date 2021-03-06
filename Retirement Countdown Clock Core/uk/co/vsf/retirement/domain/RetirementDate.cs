﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain
{
    public class RetirementDate
    {
        public DateTimeOffset SelectedRetirementDate { get; private set; }

        public RetirementDate(DateTimeOffset selectedDate)
        {
            this.SelectedRetirementDate = selectedDate;
        }

        public RetirementDate(long? ticks)
        {
            if (ticks.HasValue)
            {
                TimeSpan timeSpan = new System.TimeSpan();
                this.SelectedRetirementDate = new DateTimeOffset(ticks.Value, timeSpan);
            }
            else {
                this.SelectedRetirementDate = new DateTimeOffset(System.DateTime.Now);
            }
        }

        internal object GetTicks()
        {
            return this.SelectedRetirementDate.Ticks;
        }

        public int GetDaysToRetirement()
        {
            if (IsRetired())
            {
                return 0;
            }

            double totalDays = Math.Round((SelectedRetirementDate - System.DateTime.Now).TotalDays, 0, MidpointRounding.AwayFromZero);
            return (int)totalDays;
        }

        public int GetWorkingDaysToRetirement(WorkingDaysParameters workingDaysParameters)
        {
            int daysToRetirement = GetDaysToRetirement();
            if (daysToRetirement == 0)
            {
                return daysToRetirement;
            }

            decimal years = ((decimal)daysToRetirement / 365.25m);

            int holidays = (int)(years * (decimal)workingDaysParameters.Holidays);
            int bankHolidays = (int)(years * (decimal)workingDaysParameters.BankHolidays);
            int workingDays = (int)(Math.Round((decimal)daysToRetirement * ((decimal)workingDaysParameters.WorkingDays / (decimal)7), 0, MidpointRounding.AwayFromZero));

            return workingDays - bankHolidays - holidays;
        }

        public bool IsRetired()
        {
            return (SelectedRetirementDate.CompareTo(new DateTimeOffset(System.DateTime.Now)) < 0);
        }
    }
}
