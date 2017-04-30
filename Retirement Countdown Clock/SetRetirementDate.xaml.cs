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
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.domain;
using Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.ui;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Retirement_Countdown_Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetRetirementDate : Page
    {
        private RetirementDateRepository retirementDateRepository = RetirementDateRepositoryImpl.Instance();
        private WorkingDaysParametersRepository workingDaysParametersRepository = WorkingDaysParametersRepositoryImpl.Instance();

        public SetRetirementDate()
        {
            this.InitializeComponent();
            CustomTitleBar.CustomiseStatusBar();

            SetUIDatePicker();
            SetUIWorkingDaysComboBoxes();

            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

            if (!DeviceType.IsMobile())
            {
                this.Container.Children.Remove(this.MobileTitle);
            }
        }

        private void SetUIDatePicker()
        {
            this.datePicker.Date = retirementDateRepository.RetrieveRetirementDate().SelectedRetirementDate;
        }

        private void SetUIWorkingDaysComboBoxes()
        {
            WorkingDaysParameters workingDaysParameters = workingDaysParametersRepository.RetrieveWorkingDaysParameters();
            this.wdbh.SelectedIndex = workingDaysParameters.BankHolidays;
            this.wddh.SelectedIndex = workingDaysParameters.Holidays;
            this.wdwd.SelectedIndex = workingDaysParameters.WorkingDays -1;
        }

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Debug.WriteLine("BackRequested");
            if (rootFrame.CanGoBack)
            {
                SaveParametersOnNavigate();

                rootFrame.GoBack();
                e.Handled = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SaveParametersOnNavigate();
            Frame.Navigate(typeof(MainPage));
        }

        private void SaveParametersOnNavigate()
        {
            // ignore if the user selected a date in the past...
            RetirementDate selectedDate = new RetirementDate(this.datePicker.Date);
            retirementDateRepository.SaveRetirementDate(selectedDate);

            int workingDays = this.wdwd.SelectedIndex + 1;
            int holidays = this.wddh.SelectedIndex;
            int bankHolidays = this.wdbh.SelectedIndex;
            WorkingDaysParameters workingDaysParameters = new WorkingDaysParameters(workingDays, holidays, bankHolidays);
            workingDaysParametersRepository.SaveWorkingDaysParameters(workingDaysParameters);
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            this.retirementDateRepository.ClearData();
            this.workingDaysParametersRepository.ClearData();
            TileManager.Instance().RemoveLiveTileUpdates();

            SetUIDatePicker();
            SetUIWorkingDaysComboBoxes();
        }
    }
}
