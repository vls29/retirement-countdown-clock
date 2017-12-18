using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core_Tests.uk.co.vsf.retirement.domain
{
    [TestClass]
    public class RetirementDateTest
    {
        [TestMethod]
        public void ConstructWithNull_ZeroDaysToRetirement()
        {
            RetirementDate date = new RetirementDate(null);
            Assert.AreEqual(0, date.GetDaysToRetirement());
        }

        [TestMethod]
        public void ConstructWithRetirementYesterday_ZeroDaysToRetirement()
        {
            RetirementDate date = GetRetirementDateYesterday();
            Assert.AreEqual(0, date.GetDaysToRetirement());
        }

        [TestMethod]
        public void ConstructWithRetirement15YearsFromNow_LotsOfDaysToRetirement()
        {
            RetirementDate date = GetRetirementDateFifteenYearsFromNow();
            Assert.AreNotEqual(0, date.GetDaysToRetirement());
            Assert.IsTrue(date.GetDaysToRetirement() > 1000);
        }

        [TestMethod]
        public void ConstructWithNull_IsRetiredTrue()
        {
            RetirementDate date = new RetirementDate(null);
            Assert.AreEqual(0, date.GetDaysToRetirement());
        }

        [TestMethod]
        public void ConstructWithRetirementYesterday_IsRetiredTrue()
        {
            RetirementDate date = GetRetirementDateYesterday();
            Assert.AreEqual(0, date.GetDaysToRetirement());
        }

        [TestMethod]
        public void ConstructWithRetirement15YearsFromNow_IsRetiredFalse()
        {
            Assert.IsFalse(GetRetirementDateFifteenYearsFromNow().IsRetired());
        }

        [TestMethod]
        public void ConstructWithRetirementYesterday_WorkingDaysToRetirementZero()
        {
            RetirementDate date = GetRetirementDateYesterday();
            WorkingDaysParameters workingDaysParameters = new WorkingDaysParameters(7, 0, 0);
            Assert.AreEqual(0, date.GetWorkingDaysToRetirement(workingDaysParameters));
        }

        [TestMethod]
        public void ConstructWithRetirement15YearsFromNow_WorkingDaysToRetirementMany()
        {
            RetirementDate date = GetRetirementDateFifteenYearsFromNow();
            WorkingDaysParameters workingDaysParameters = new WorkingDaysParameters(7, 0, 0);
            Assert.AreNotEqual(0, date.GetWorkingDaysToRetirement(workingDaysParameters));
            Assert.IsTrue(date.GetWorkingDaysToRetirement(workingDaysParameters) > 1000);
        }

        [TestMethod]
        public void ConstructWithNull_WorkingDaysToRetirementZero()
        {
            RetirementDate date = new RetirementDate(null);
            WorkingDaysParameters workingDaysParameters = new WorkingDaysParameters(7, 0, 0);
            Assert.AreEqual(0, date.GetWorkingDaysToRetirement(workingDaysParameters));
        }

        [TestMethod]
        public void CalculateWorkingDays()
        {
            RetirementDate date = GetRetirementDateFifteenYearsFromNow();
            WorkingDaysParameters workingDaysParameters = new WorkingDaysParameters(7, 0, 0);
            Assert.AreEqual(date.GetDaysToRetirement(), date.GetWorkingDaysToRetirement(workingDaysParameters));

            int daysToRetirement = date.GetDaysToRetirement();

            workingDaysParameters = new WorkingDaysParameters(6, 0, 0);
            Assert.AreNotEqual(daysToRetirement, date.GetWorkingDaysToRetirement(workingDaysParameters));

            workingDaysParameters = new WorkingDaysParameters(3.5, 0, 0);
            Assert.AreEqual(daysToRetirement / 2d, (double)date.GetWorkingDaysToRetirement(workingDaysParameters), 1d, "3.5wd - Expected " + (daysToRetirement / 2) + " Found " + date.GetWorkingDaysToRetirement(workingDaysParameters));

            workingDaysParameters = new WorkingDaysParameters(1, 0, 0);
            Assert.AreEqual(daysToRetirement / 7d, date.GetWorkingDaysToRetirement(workingDaysParameters), 1d, "Expected " + (daysToRetirement / 7) + "1wd - Found " + date.GetWorkingDaysToRetirement(workingDaysParameters));
        }

        private RetirementDate GetRetirementDateFifteenYearsFromNow()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 15; i++)
            {
                dt = dt.AddDays(365);
            }
            RetirementDate date = new RetirementDate(dt.Ticks);
            return date;
        }

        private RetirementDate GetRetirementDateYesterday()
        {
            DateTime dt = DateTime.Now;
            dt.Subtract(TimeSpan.FromDays(1));
            RetirementDate date = new RetirementDate(dt.Ticks);
            return date;
        }
    }
}
