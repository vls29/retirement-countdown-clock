using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    class RetirementDateRepositoryImpl : RetirementDateRepository
    {
        private static RetirementDateRepository repositoryInstance;
        private static String TICKS = "TICKS";

        public static RetirementDateRepository instance()
        {
            if (repositoryInstance == null)
            {
                repositoryInstance = new RetirementDateRepositoryImpl();
            }

            return repositoryInstance;
        }

        private RetirementDateRepositoryImpl()
        {

        }

        public RetirementDate retrieveRetirementDate()
        {
            Windows.Storage.ApplicationDataContainer localSettings = getLocalSettings();
            long? ticks = (long?)localSettings.Values[TICKS];

            RetirementDate retirementDate = new RetirementDate(ticks);
            return retirementDate;
        }

        public void saveRetirementDate(RetirementDate toSave)
        {
            Windows.Storage.ApplicationDataContainer localSettings = getLocalSettings();
            localSettings.Values[TICKS] = toSave.getTicks();
        }

        private Windows.Storage.ApplicationDataContainer getLocalSettings()
        {
            return Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        public void clearData()
        {
            Windows.Storage.ApplicationDataContainer localSettings = getLocalSettings();
            localSettings.Values[TICKS] = null;
        }
    }
}
