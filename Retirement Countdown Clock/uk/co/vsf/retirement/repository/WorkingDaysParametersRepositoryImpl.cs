using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retirement_Countdown_Clock.uk.co.vsf.retirement.domain;

namespace Retirement_Countdown_Clock.uk.co.vsf.retirement.repository
{
    class WorkingDaysParametersRepositoryImpl : WorkingDaysParametersRepository
    {
        private static WorkingDaysParametersRepository repositoryInstance;
        
        private static String WD = "WorkingDays";
        private static String BH = "BankHolidays";
        private static String H = "Holidays";

        public static WorkingDaysParametersRepository instance()
        {
            if (repositoryInstance == null)
            {
                repositoryInstance = new WorkingDaysParametersRepositoryImpl();
            }

            return repositoryInstance;
        }

        private WorkingDaysParametersRepositoryImpl()
        {

        }
        
        public WorkingDaysParameters retrieveWorkingDaysParameters()
        {
            Windows.Storage.ApplicationDataContainer localSettings = getLocalSettings();
            int? workingDays = (int?)localSettings.Values[WD];
            int? holidays = (int?)localSettings.Values[H];
            int? bankHolidays = (int?)localSettings.Values[BH];

            WorkingDaysParameters workingDaysParameter = new WorkingDaysParameters(workingDays, holidays, bankHolidays);
            return workingDaysParameter;
        }

        public void saveWorkingDaysParameters(WorkingDaysParameters toSave)
        {
            Windows.Storage.ApplicationDataContainer localSettings = getLocalSettings();
            localSettings.Values[H] = toSave.getHolidays();
            localSettings.Values[BH] = toSave.getBankHolidays();
            localSettings.Values[WD] = toSave.getWorkingDays();
        }

        private Windows.Storage.ApplicationDataContainer getLocalSettings()
        {
            return Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        public void clearData()
        {
            Windows.Storage.ApplicationDataContainer localSettings = getLocalSettings();
            localSettings.Values[H] = null;
            localSettings.Values[BH] = null;
            localSettings.Values[WD] = null;
        }
    }
}
