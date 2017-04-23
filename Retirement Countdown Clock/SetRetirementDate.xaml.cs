using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using System.Diagnostics;
using Retirement_Countdown_Clock.uk.co.vsf.retirement.repository;
using Retirement_Countdown_Clock.uk.co.vsf.retirement.domain;
using Retirement_Countdown_Clock.uk.co.vsf.retirement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Retirement_Countdown_Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetRetirementDate : Page
    {
        private RetirementDateRepository retirementDateRepository = RetirementDateRepositoryImpl.instance();
        private WorkingDaysParametersRepository workingDaysParametersRepository = WorkingDaysParametersRepositoryImpl.instance();

        public SetRetirementDate()
        {
            this.InitializeComponent();
            CustomTitleBar.customiseStatusBar();

            setUIDatePicker();
            setUIWorkingDaysComboBoxes();

            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

            if (!DeviceType.isMobile())
            {
                this.Container.Children.Remove(this.MobileTitle);
            }
        }

        private void setUIDatePicker()
        {
            this.datePicker.Date = retirementDateRepository.retrieveRetirementDate().getDateTimeOffset();
        }

        private void setUIWorkingDaysComboBoxes()
        {
            WorkingDaysParameters workingDaysParameters = workingDaysParametersRepository.retrieveWorkingDaysParameters();
            this.wdbh.SelectedIndex = workingDaysParameters.getBankHolidays();
            this.wddh.SelectedIndex = workingDaysParameters.getHolidays();
            this.wdwd.SelectedIndex = workingDaysParameters.getWorkingDays() -1;
        }

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Debug.WriteLine("BackRequested");
            if (rootFrame.CanGoBack)
            {
                saveParametersOnNavigate();

                rootFrame.GoBack();
                e.Handled = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            saveParametersOnNavigate();
            Frame.Navigate(typeof(MainPage));
        }

        private void saveParametersOnNavigate()
        {
            // ignore if the user selected a date in the past...
            RetirementDate selectedDate = new RetirementDate(this.datePicker.Date);
            retirementDateRepository.saveRetirementDate(selectedDate);

            int workingDays = this.wdwd.SelectedIndex + 1;
            int holidays = this.wddh.SelectedIndex;
            int bankHolidays = this.wdbh.SelectedIndex;
            WorkingDaysParameters workingDaysParameters = new WorkingDaysParameters(workingDays, holidays, bankHolidays);
            workingDaysParametersRepository.saveWorkingDaysParameters(workingDaysParameters);
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            this.retirementDateRepository.clearData();
            this.workingDaysParametersRepository.clearData();

            setUIDatePicker();
            setUIWorkingDaysComboBoxes();
        }
    }
}
