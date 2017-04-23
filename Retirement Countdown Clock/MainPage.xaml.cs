using Retirement_Countdown_Clock.uk.co.vsf.retirement;
using Retirement_Countdown_Clock.uk.co.vsf.retirement.domain;
using Retirement_Countdown_Clock.uk.co.vsf.retirement.repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Retirement_Countdown_Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private RetirementDateRepository retirementDateRepository = RetirementDateRepositoryImpl.instance();
        private WorkingDaysParametersRepository workingDaysParametersRepository = WorkingDaysParametersRepositoryImpl.instance();

        private RetirementDateDescription description;

        public MainPage()
        {
            this.InitializeComponent();
            CustomTitleBar.customiseStatusBar();

            Window.Current.CoreWindow.VisibilityChanged += coreWindowVisibilityChanged;

            setCalendarDaysToRetirement();
            setWorkingDaysToRetirement();

            if (!DeviceType.isMobile())
            {
                this.Container.Children.Remove(this.MobileTitle);
            }
        }

        private void coreWindowVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
        {
            if (args.Visible)
            {
                setCalendarDaysToRetirement();
                setWorkingDaysToRetirement();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            setCalendarDaysToRetirement();
            setWorkingDaysToRetirement();
        }

        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetRetirementDate));
        }

        private void GoToAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void setWorkingDaysToRetirement()
        {
            WorkingDaysParameters workingDaysParameters = workingDaysParametersRepository.retrieveWorkingDaysParameters();
            RetirementDate retirementDate = retirementDateRepository.retrieveRetirementDate();
            int workingDays = retirementDate.getWorkingDaysToRetirement(workingDaysParameters);
            displayDays(workingDays, this.wd1, this.wd2, this.wd3, this.wd4, this.wd5);
        }

        private void setCalendarDaysToRetirement()
        {
            RetirementDate retirementDate = retirementDateRepository.retrieveRetirementDate();
            displayDays(retirementDate.getDaysToRetirement(), this.cd1, this.cd2, this.cd3, this.cd4, this.cd5);
            this.information.Text = getRetirementDateDescription().getText(retirementDate);
        }

        private void displayDays(int retirementDays, Image i1, Image i2, Image i3, Image i4, Image i5)
        {
            String days = retirementDays.ToString();
            days = days.PadLeft(5, ' ');
            for (int i = 0; i < days.Length; i++)
            {
                String imageNumber = days[i].ToString();
                if (i == 0)
                {
                    i1.Source = createImageSource(imageNumber);
                }
                else if (i == 1)
                {
                    i2.Source = createImageSource(imageNumber);
                }
                else if (i == 2)
                {
                    i3.Source = createImageSource(imageNumber);
                }
                else if (i == 3)
                {
                    i4.Source = createImageSource(imageNumber);
                }
                else if (i == 4)
                {
                    i5.Source = createImageSource(imageNumber);
                }
            }
        }

        private ImageSource createImageSource(string imageNumber)
        {
            if (" ".Equals(imageNumber, StringComparison.CurrentCultureIgnoreCase))
            {
                imageNumber = "";
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(this.BaseUri, "Assets/numbers/rc" + imageNumber + ".png");
            return bitmapImage;
        }

        private RetirementDateDescription getRetirementDateDescription()
        {
            if (description == null)
            {
                description = new RetiredRetirementDateDescription();
                TwoMonthRetirementDateDescription twoMonth = new TwoMonthRetirementDateDescription();
                OneYearRetirementDateDescription oneYear = new OneYearRetirementDateDescription();
                TwoYearRetirementDateDescription twoYear = new TwoYearRetirementDateDescription();
                TwentyTwoYearRetirementDateDescription twentyTwoYear = new TwentyTwoYearRetirementDateDescription();
                DefaultRetirementDateDescription defaultDescription = new DefaultRetirementDateDescription();

                description.setRetirementDateDescription(twoMonth);
                twoMonth.setRetirementDateDescription(oneYear);
                oneYear.setRetirementDateDescription(twoYear);
                twoYear.setRetirementDateDescription(twentyTwoYear);
                twentyTwoYear.setRetirementDateDescription(defaultDescription);
            }

            return description;
        }
    }
}
