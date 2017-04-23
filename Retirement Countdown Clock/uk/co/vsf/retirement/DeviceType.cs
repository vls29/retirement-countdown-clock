using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace Retirement_Countdown_Clock.uk.co.vsf.retirement
{
    class DeviceType
    {
        public static bool isMobile()
        {
            return ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");
        }
    }
}
