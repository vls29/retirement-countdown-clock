using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class RetirementDateRepositoryImpl : RetirementDateRepository
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
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            long? ticks = (long?)localSettings.Values[TICKS];

            RetirementDate retirementDate = new RetirementDate(ticks);
            return retirementDate;
        }

        public void SaveRetirementDate(RetirementDate toSave)
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            localSettings.Values[TICKS] = toSave.GetTicks();
        }

        private Windows.Storage.ApplicationDataContainer GetLocalSettings()
        {
            return Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        public void ClearData()
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            localSettings.Values[TICKS] = null;
        }
    }
}
