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
    public class WorkingDaysParametersTest
    {
        [TestMethod]
        public void AllDefaults()
        {
            WorkingDaysParameters wdp = new WorkingDaysParameters(null, null, null);
            Assert.AreEqual(0, wdp.BankHolidays);
            Assert.AreEqual(0, wdp.Holidays);
            Assert.AreEqual(1, wdp.WorkingDays);
        }

        [TestMethod]
        public void BankHolidaySet_RestDefaults()
        {
            int bankHolidays = 7;
            WorkingDaysParameters wdp = new WorkingDaysParameters(null, null, bankHolidays);
            Assert.AreEqual(bankHolidays, wdp.BankHolidays);
            Assert.AreEqual(0, wdp.Holidays);
            Assert.AreEqual(1, wdp.WorkingDays);
        }

        [TestMethod]
        public void HolidaySet_RestDefaults()
        {
            int holidays = 7;
            WorkingDaysParameters wdp = new WorkingDaysParameters(null, holidays, null);
            Assert.AreEqual(0, wdp.BankHolidays);
            Assert.AreEqual(holidays, wdp.Holidays);
            Assert.AreEqual(1, wdp.WorkingDays);
        }

        [TestMethod]
        public void WorkingDaysSet_RestDefaults()
        {
            int workingDays = 7;
            WorkingDaysParameters wdp = new WorkingDaysParameters(workingDays, null, null);
            Assert.AreEqual(0, wdp.BankHolidays);
            Assert.AreEqual(0, wdp.Holidays);
            Assert.AreEqual(workingDays, wdp.WorkingDays);
        }

        [TestMethod]
        public void WorkingDaysSet_Double_RestDefaults()
        {
            double workingDays = 3.5d;
            WorkingDaysParameters wdp = new WorkingDaysParameters(workingDays, null, null);
            Assert.AreEqual(0, wdp.BankHolidays);
            Assert.AreEqual(0, wdp.Holidays);
            Assert.AreEqual(workingDays, wdp.WorkingDays);
        }

        [TestMethod]
        public void WorkingDaysSet_InvalidWorkingDays_SevenPointFive_ThrowsArgumentException()
        {
            try
            {
                new WorkingDaysParameters(7.5, null, null);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

            }
        }

        [TestMethod]
        public void WorkingDaysSet_InvalidWorkingDays_Zero_SetsDefault()
        {
            WorkingDaysParameters wdp = new WorkingDaysParameters(0, null, null);
            Assert.AreEqual(1d, wdp.WorkingDays);
        }

        [TestMethod]
        public void WorkingDaysSet_ValidWorkingDays()
        {
            double[] validWorkingDays = new double[] { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7 };
            for (int i = 0; i < validWorkingDays.Length; i++)
            {
                WorkingDaysParameters wdp = new WorkingDaysParameters(validWorkingDays[i], null, null);
                Assert.AreEqual(validWorkingDays[i], wdp.WorkingDays);
            }
        }
    }
}
