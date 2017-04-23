using Retirement_Countdown_Clock.uk.co.vsf.retirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace Retirement_Countdown_Clock
{
    class CustomTitleBar
    {
        private static Color COLOUR_BACKGROUND = Colors.Purple;
        private static Color COLOUR_TEXT = Colors.White;
        private static int OPACITY = 1;

        public static void customiseStatusBar()
        {
            //PC customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = COLOUR_BACKGROUND;
                    titleBar.ButtonForegroundColor = COLOUR_TEXT;
                    titleBar.BackgroundColor = COLOUR_BACKGROUND;
                    titleBar.ForegroundColor = COLOUR_TEXT;
                }
            }

            //Mobile customization
            if (DeviceType.isMobile())
            {
                var statusBar = StatusBar.GetForCurrentView();

                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = OPACITY;
                    statusBar.BackgroundColor = COLOUR_BACKGROUND;
                    statusBar.ForegroundColor = COLOUR_TEXT;
                    
                }
            }
        }
    }
}
