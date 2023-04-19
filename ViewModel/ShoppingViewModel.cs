using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyStore_MAUI.View;
using System.Diagnostics;

namespace MyStore_MAUI.ViewModel
{
    class ShoppingViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context();
        public Command LoadData { get; }
        #region VARIABLES
        int _prewProduct = 10;
        int _nextProduct = -10;
        int _quantityProduct = 0;

        ObservableCollection<MProduct> _List_Product;
        #endregion


        #region CONSTRUCTOR
        public ShoppingViewModel(INavigation navigation)
        {
            QuantityProduct = 0;
            Navigation = navigation;
            Task.Run(async () => await getAllProducts());

            LoadData = new Command(async () => await getAllProducts());
        }
        #endregion

        #region OBJETOS
        public ObservableCollection<MProduct> List_Product
        {
            get { return _List_Product; }
            set
            {
                SetValue(ref _List_Product, value);
                OnpropertyChanged();
            }
        }
        public int PrewProduct
        {
            get { return _prewProduct; }
            set
            {
                SetValue(ref _prewProduct, value);
                OnpropertyChanged();
            }
        }
        public int NextProduct
        {
            get { return _nextProduct; }
            set
            {
                SetValue(ref _nextProduct, value);
                OnpropertyChanged();
            }
        }
        public int QuantityProduct
        {
            get { return _quantityProduct; }
            set
            {
                SetValue(ref _quantityProduct, value);
                OnpropertyChanged();
            }
        }
        #endregion


        #region METODOS ASYNC
        public async Task getAllProducts()
        {
            IsBusy = true;

            try
            {
                var result = await _dbContext.Product.ToListAsync();

                if (result.Count > 0)
                {
                    List_Product = new ObservableCollection<MProduct>(result);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
           
        }
        public async Task goPageCart()
        {
            #if ANDROID || IOS
                await Navigation.PushAsync(new Mobile_Cart());
            #else
               await Navigation.PushAsync(new Desktop_Cart());
            #endif
        }
        public async Task add_To_Cart(MProduct product)
        {
            CartViewModel _cart = new CartViewModel(Navigation);
           _cart.Get_Data_Product(product);
           var quantityOnCart =  _cart.QuantityOnCart();
           QuantityProduct = quantityOnCart;
        }
        public async Task prew_Product()
        {
            await DisplayAlert("infor", "Anterior Lista -10 Products", "Ok");
        }
        public async Task next_Product()
        {
            await DisplayAlert("infor", "Siguientes Lista 10 Products", "Ok");
        }
    #endregion

        #region COMANDOS
        public ICommand goCart => new Command(async () => await goPageCart());
        public ICommand btnAddToCart => new Command<MProduct>(async (prod) => await add_To_Cart(prod));
        public ICommand btnPrewPorduct => new Command(async () => await prew_Product());
        public ICommand nextProduct => new Command(async () => await next_Product());
        #endregion
    }
}
