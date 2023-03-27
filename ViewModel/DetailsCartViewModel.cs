using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyStore_MAUI.View;


namespace MyStore_MAUI.ViewModel
{
    public class DetailsCartViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context();
        private MDetailsCart myReport { get; set; }
        ObservableCollection<MCart> _list_Product;

        public ObservableCollection<MCart> List_Products
        {
            get { return _list_Product; }
            set
            {
                SetValue(ref _list_Product, value);
                OnpropertyChanged();
            }
        }
        public DetailsCartViewModel(INavigation navigation)
        {
            Navigation = navigation;

        }


        #region METHODS
        public async Task generatePDF()
        {
            await DisplayAlert("info", "generando pdf", "ok");
        }
        public async Task sharedDocument()
        {
            await DisplayAlert("info", "compartir", "ok");
        }
        #endregion


        #region COMMANDS
        public ICommand btnSharedCommand => new Command(async () => await sharedDocument());
        public ICommand btnGeneratePDFCommand => new Command(async () => await generatePDF());
        #endregion
    }
}
