using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock
{
    interface RetirementDateRepository
    {
        /// <summary>
        /// Retrieves the retirement date from the repository.
        /// </summary>
        /// <returns>Retirement date from the store</returns>
        RetirementDate retrieveRetirementDate();

        /// <summary>
        /// Saves the retirement date to the repository.
        /// </summary>
        /// <param name="toSave">date to save to store</param>
        void saveRetirementDate(RetirementDate toSave);

        void clearData();
    }
}
