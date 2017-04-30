using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository
{
    public interface WorkingDaysParametersRepository
    {
        /// <summary>
        /// Retrieves the working days parameters from the repository.
        /// </summary>
        /// <returns>Working Days from the store</returns>
        WorkingDaysParameters RetrieveWorkingDaysParameters();

        /// <summary>
        /// Saves the working days parameters to the repository.
        /// </summary>
        /// <param name="toSave">working days parameters to save to store</param>
        void SaveWorkingDaysParameters(WorkingDaysParameters toSave);

        void ClearData();
    }
}
