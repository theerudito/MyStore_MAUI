using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;

namespace MyStore_MAUI.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context(); 
        public Command LoadData { get; }

        #region VARIABLES
        ObservableCollection<MProduct> _List_product;
        public bool _goEditingProduct = true;
        #endregion

        #region OBJECTS
        public ObservableCollection<MProduct> List_Product
        {
            get { return _List_product; }
            set
            {
                _List_product = value;
                OnPropertyChanged(nameof(List_Product));
            }
        }
        #endregion

        #region CONSTRUCTOR
        public ProductViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GET_ALL_Products();

            LoadData = new Command(async () => await GET_ALL_Products());
        }
        #endregion

        #region METHODS
        public async Task Delete_Product(MProduct product)
        {
            var result = await _dbContext.Product.FirstOrDefaultAsync(pro => pro.IdProduct == product.IdProduct);
            if (result != null)
            {
                if (await DisplayAlert("Delete Client", "Are you sure you want to delete this product?", "Yes", "No"))
                {
                    _dbContext.Product.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    await GET_ALL_Products();
                }
            }
        }
        public async Task GET_ALL_Products()
        {
            IsBusy = true;

            try
            {
                var result = await _dbContext.Product.ToListAsync();
                List_Product = new ObservableCollection<MProduct>(result);
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
        public async Task goUpdate_Product(MProduct product)
        {
            #if ANDROID || IOS
                await Navigation.PushAsync(new Mobile_Add_Product(product, _goEditingProduct));
            #else
                await Navigation.PushAsync(new Desktop_Add_Product(product, _goEditingProduct));
            #endif
        }
        public async Task goNew_Product(MProduct product)
        {
            #if ANDROID || IOS
                await Navigation.PushAsync(new Mobile_Add_Product(product, _goEditingProduct));
            #else
                await Navigation.PushAsync(new Desktop_Add_Product(product, _goEditingProduct));
            #endif
        }
        #endregion

        #region COMMANDS   
        public ICommand btnDeleteProduct => new Command<MProduct>(async (prod) => await Delete_Product(prod));
        public ICommand btnGoNewProduct => new Command<MProduct>(async (prod) => await goNew_Product(prod));
        public ICommand btnGoUpdateProduct => new Command<MProduct>(async (prod) => await goUpdate_Product(prod));
        public ICommand btnLeftProduct => new Command(async () => await DisplayAlert("info", "left", "ok"));
        public ICommand btnRightProduct => new Command(async () => await DisplayAlert("info", "right", "ok"));
        #endregion
    }
}
