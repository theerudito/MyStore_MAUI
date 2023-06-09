﻿using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    public class ReportViewModel : BaseViewModel
    {
        private Application_Context _dbContext = new Application_Context();
        public Command LoadData { get; }

        #region CONSTRUCTOR

        public ReportViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Get_All_Report();

            LoadData = new Command(async () => await Get_All_Report());
        }

        #endregion CONSTRUCTOR

        #region VARIABLES

        private ObservableCollection<MDetailsCart> _list_report;

        #endregion VARIABLES

        #region OBJECTS

        public ObservableCollection<MDetailsCart> List_Report
        {
            get { return _list_report; }
            set
            {
                SetValue(ref _list_report, value);
                OnPropertyChanged();
            }
        }

        #endregion OBJECTS

        #region METHODS

        public async Task Get_All_Report()
        {
            IsBusy = true;

            try
            {
                var result = await _dbContext.DetailsCart.ToListAsync();
                List_Report = new ObservableCollection<MDetailsCart>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = !IsBusy;
            }
        }

        public async Task pickerDocumentReport()
        {
            await DisplayAlert("info", "search docu", "ok");
        }

        public async Task seachDocumentReport()
        {
            await DisplayAlert("info", "compartir", "ok");
        }

        public async Task leftReport()
        {
            await DisplayAlert("info", "left", "ok");
        }

        public async Task rightReport()
        {
            await DisplayAlert("info", "right", "ok");
        }

        public async Task seeReport(MDetailsCart report)
        {
#if ANDROID || IOS
            await Navigation.PushAsync(new Mobile_DetailsCart());
#else
            await Navigation.PushAsync(new Desktop_DetailsCart());
#endif
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnLeftReportCommand => new Command(async () => await leftReport());
        public ICommand btnRightReportCommand => new Command(async () => await rightReport());
        public ICommand btnSearchDocumentCommand => new Command(async () => await seachDocumentReport());
        public ICommand btnShowReportCommand => new Command<MDetailsCart>(async (r) => await seeReport(r));

        #endregion COMMANDS
    }
}