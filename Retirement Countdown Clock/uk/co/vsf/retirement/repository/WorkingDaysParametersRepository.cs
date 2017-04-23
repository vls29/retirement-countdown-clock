﻿using Retirement_Countdown_Clock.uk.co.vsf.retirement.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retirement_Countdown_Clock.uk.co.vsf.retirement.repository
{
    interface WorkingDaysParametersRepository
    {
        /// <summary>
        /// Retrieves the working days parameters from the repository.
        /// </summary>
        /// <returns>Working Days from the store</returns>
        WorkingDaysParameters retrieveWorkingDaysParameters();

        /// <summary>
        /// Saves the working days parameters to the repository.
        /// </summary>
        /// <param name="toSave">working days parameters to save to store</param>
        void saveWorkingDaysParameters(WorkingDaysParameters toSave);

        void clearData();
    }
}
