using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository
{
    public class WorkingDaysParametersRepositoryImpl : WorkingDaysParametersRepository
    {
        private static WorkingDaysParametersRepository _repositoryInstance;
        
        private static String WD = "WorkingDays";
        private static String BH = "BankHolidays";
        private static String H = "Holidays";

        public static WorkingDaysParametersRepository Instance()
        {
            if (_repositoryInstance == null)
            {
                _repositoryInstance = new WorkingDaysParametersRepositoryImpl();
            }

            return _repositoryInstance;
        }

        private WorkingDaysParametersRepositoryImpl()
        {

        }
        
        public WorkingDaysParameters RetrieveWorkingDaysParameters()
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            int? workingDays = (int?)localSettings.Values[WD];
            int? holidays = (int?)localSettings.Values[H];
            int? bankHolidays = (int?)localSettings.Values[BH];

            WorkingDaysParameters workingDaysParameter = new WorkingDaysParameters(workingDays, holidays, bankHolidays);
            return workingDaysParameter;
        }

        public void SaveWorkingDaysParameters(WorkingDaysParameters toSave)
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            localSettings.Values[H] = toSave.Holidays;
            localSettings.Values[BH] = toSave.BankHolidays;
            localSettings.Values[WD] = toSave.WorkingDays;
        }

        private Windows.Storage.ApplicationDataContainer GetLocalSettings()
        {
            return Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        public void ClearData()
        {
            Windows.Storage.ApplicationDataContainer localSettings = GetLocalSettings();
            localSettings.Values[H] = null;
            localSettings.Values[BH] = null;
            localSettings.Values[WD] = null;
        }
    }
}
