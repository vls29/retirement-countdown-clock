using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
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
using Retirement_Countdown_Clock;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.presentation;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.ui;

namespace Retirement_Countdown_Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private RetirementDateRepository _retirementDateRepository = RetirementDateRepositoryImpl.Instance();
        private WorkingDaysParametersRepository _workingDaysParametersRepository = WorkingDaysParametersRepositoryImpl.Instance();

        private RetirementDateDescription _description;

        public MainPage()
        {
            this.InitializeComponent();
            CustomTitleBar.CustomiseStatusBar();

            Window.Current.CoreWindow.VisibilityChanged += CoreWindowVisibilityChanged;

            SetCalendarDaysToRetirement();
            SetWorkingDaysToRetirement();

            if (!DeviceType.IsMobile())
            {
                this.Container.Children.Remove(this.MobileTitle);
            }
        }

        private void CoreWindowVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
        {
            if (args.Visible)
            {
                SetCalendarDaysToRetirement();
                SetWorkingDaysToRetirement();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetCalendarDaysToRetirement();
            SetWorkingDaysToRetirement();
            TileManager.Instance().RegisterLiveTileUpdates();
        }

        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetRetirementDate));
        }

        private void GoToAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void SetWorkingDaysToRetirement()
        {
            WorkingDaysParameters workingDaysParameters = _workingDaysParametersRepository.RetrieveWorkingDaysParameters();
            RetirementDate retirementDate = _retirementDateRepository.RetrieveRetirementDate();
            int workingDays = retirementDate.GetWorkingDaysToRetirement(workingDaysParameters);
            DisplayDays(workingDays, this.wd1, this.wd2, this.wd3, this.wd4, this.wd5);
        }

        private void SetCalendarDaysToRetirement()
        {
            RetirementDate retirementDate = _retirementDateRepository.RetrieveRetirementDate();
            DisplayDays(retirementDate.GetDaysToRetirement(), this.cd1, this.cd2, this.cd3, this.cd4, this.cd5);
            this.information.Text = GetRetirementDateDescription().GetText(retirementDate);
        }

        private void DisplayDays(int retirementDays, Image i1, Image i2, Image i3, Image i4, Image i5)
        {
            String days = retirementDays.ToString();
            days = days.PadLeft(5, ' ');
            for (int i = 0; i < days.Length; i++)
            {
                String imageNumber = days[i].ToString();
                if (i == 0)
                {
                    i1.Source = CreateImageSource(imageNumber);
                }
                else if (i == 1)
                {
                    i2.Source = CreateImageSource(imageNumber);
                }
                else if (i == 2)
                {
                    i3.Source = CreateImageSource(imageNumber);
                }
                else if (i == 3)
                {
                    i4.Source = CreateImageSource(imageNumber);
                }
                else if (i == 4)
                {
                    i5.Source = CreateImageSource(imageNumber);
                }
            }
        }

        private ImageSource CreateImageSource(string imageNumber)
        {
            if (" ".Equals(imageNumber, StringComparison.CurrentCultureIgnoreCase))
            {
                imageNumber = "";
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(this.BaseUri, $"Assets/numbers/rc{imageNumber}.png");
            return bitmapImage;
        }

        private RetirementDateDescription GetRetirementDateDescription()
        {
            if (_description == null)
            {
                _description = new RetiredRetirementDateDescription();
                TwoMonthRetirementDateDescription twoMonth = new TwoMonthRetirementDateDescription();
                OneYearRetirementDateDescription oneYear = new OneYearRetirementDateDescription();
                TwoYearRetirementDateDescription twoYear = new TwoYearRetirementDateDescription();
                TwentyTwoYearRetirementDateDescription twentyTwoYear = new TwentyTwoYearRetirementDateDescription();
                DefaultRetirementDateDescription defaultDescription = new DefaultRetirementDateDescription();

                _description.Description = twoMonth;
                twoMonth.Description = oneYear;
                oneYear.Description = twoYear;
                twoYear.Description = twentyTwoYear;
                twentyTwoYear.Description = defaultDescription;
            }

            return _description;
        }
    }
}
