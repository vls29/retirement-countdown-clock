﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement
{
    public class DeviceType
    {
        public static bool IsMobile()
        {
            return ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");
        }
    }
}
