using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository
{
    public class RetirementDateRepositoryImpl : ApplicationDataContainerRepository, RetirementDateRepository
    {
        private static RetirementDateRepository _repositoryInstance;
        private static String TICKS = "TICKS";

        public static RetirementDateRepository Instance()
        {
            if (_repositoryInstance == null)
            {
                _repositoryInstance = new RetirementDateRepositoryImpl();
            }

            return _repositoryInstance;
        }

        private RetirementDateRepositoryImpl()
        {

        }

        public RetirementDate RetrieveRetirementDate()
        {
            RetirementDate retirementDate = new RetirementDate(GetRetirementDate());
            return retirementDate;
        }

        public void SaveRetirementDate(RetirementDate toSave)
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            localSettings.Values[TICKS] = toSave.GetTicks();
        }

        public bool IsRetirementDateStored()
        {
            return GetRetirementDate().HasValue;
        }

        private long? GetRetirementDate()
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            return (long?)localSettings.Values[TICKS];
        }

        public void ClearData()
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            localSettings.Values[TICKS] = null;
        }
    }
}
