using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace MyStore_MAUI.ViewModel
{
   
    public class CartViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context();

        Calculates calculos = new Calculates();

        public INavigation Navigation { get; set; }

        public MProduct _product { get; set; }

        List<MProduct> _myCart = new List<MProduct>();
        


        #region CONSTRUCTORS
        public CartViewModel(INavigation navigation)
        {
            
            Navigation = navigation;
            Get_Data_Company();
            Obtener();
            Total_Cart();
            Task.Run(async () => await getClientFinal());

        }
        #endregion

        #region VARIABLES
        private string _Date = DateTime.Now.ToString("HH:mm");
        private string _Hour = DateTime.Now.ToString("dd/MM/yyyy");


        private float _subtotal;
        private float _subtotal0;
        private float _subtotal12;
        private float _ivaCart;
        private float _descuent;
        private float _Total;

        private string _Document;
        private int _numDocument;
        private string _Serie1;
        private string _Serie2;
        private float _ivaCompany;

        private string _DNI;
        private string _Phone;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Direction;
        public string _City;

        private int _cant;
        private float _p_total;
        private int _IdClient;
        private int _IdProduct;
        private int cliFinal = 1;

        private int _quantityIncrement = 1;

        ObservableCollection<MProduct> _list_Product;
        #endregion

        #region OBJETOS
        public ObservableCollection<MProduct> List_Products
        {
            get { return _list_Product; }
            set
            {
                SetValue(ref _list_Product, value);
                OnPropertyChanged();
            }
        }
        

        // DATA CART VALUES
        public float SubTotal
        {
            get { return _subtotal; }
            set { SetValue(ref _subtotal, value); }
        }
        public float SubTotal12
        {
            get { return _subtotal12; }
            set { SetValue(ref _subtotal12, value); }
        }
        public float SubTotal0
        {
            get { return _subtotal0; }
            set { SetValue(ref _subtotal0, value); }
        }
        public float IvaCart
        {
            get { return _ivaCart; }
            set { SetValue(ref _ivaCart, value); }
        }
        public float IvaCompany
        {
            get { return _ivaCompany; }
            set { SetValue(ref _ivaCompany, value); }
        }
        public float Total
        {
            get { return _Total; }
            set { SetValue(ref _Total, value); }
        }
        public float Descuent
        {
            get { return _descuent; }
            set { SetValue(ref _descuent, value); }
        }


        // DATOS DE LA EMPRESA
        public string Date_Now
        {
            get { return _Date; }
            set { SetValue(ref _Date, value); }
        }
        public string Hour_Now
        {
            get { return _Hour; }
            set { SetValue(ref _Hour, value); }
        }
        public string Document
        {
            get { return _Document; }
            set { SetValue(ref _Document, value); }
        }
        public int NumDocument
        {
            get { return _numDocument; }
            set { SetValue(ref _numDocument, value); }
        }
        public string Serie1
        {
            get { return _Serie1; }
            set { SetValue(ref _Serie1, value); }
        }
        public string Serie2
        {
            get { return _Serie2; }
            set { SetValue(ref _Serie2, value); }
        }


        // DATA CLIENT
        public int IdClient
        {
            get { return _IdClient; }
            set { SetValue(ref _IdClient, value); }
        }
        public string DNI
        {
            get { return _DNI; }
            set { SetValue(ref _DNI, value); }
        }
        public string Phone
        {
            get { return _Phone; }
            set { SetValue(ref _Phone, value); }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { SetValue(ref _FirstName, value); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { SetValue(ref _LastName, value); }
        }
        public string Email
        {
            get { return _Email; }
            set { SetValue(ref _Email, value); }
        }
        public string Direction
        {
            get { return _Direction; }
            set { SetValue(ref _Direction, value); }
        }
        public string City
        {
            get { return _City; }
            set { SetValue(ref _City, value); }
        }


        public int IdProduct
        {
            get { return _IdProduct; }
            set { SetValue(ref _IdProduct, value);
                OnpropertyChanged();
            }
        }
        public int Cant
        {
            get { return _cant; }
            set { SetValue(ref _cant, value);
                OnpropertyChanged();
            }
            
        }
        public float P_TOTAL
        {
            get { return _p_total; }
            set { SetValue(ref _p_total, value);
                OnpropertyChanged();
            }
        }
       


        #endregion

        #region METODOS ASYNC
        public void Get_Data_Product(MProduct product)
        {
            

           
        }

        public void Obtener ()
        {
            _myCart.Add(new MProduct
            {
                IdProduct = 1,
                NameProduct = "Coca Cola",
                CodeProduct = "0001",
                Brand = "Coca Cola",
                Description = "Bebida Gaseosa",
                P_Unitary = 1.55f,
                Quantity = Cant,
                P_Total = Quantity() * Price_Total(),
                Image_Product = "https://raw.githubusercontent.com/theerudito/Strore-APP-Xamarin-SQLite/master/product.png"
            }
                       );
            _myCart.Add(new MProduct
            {
                IdProduct = 2,
                NameProduct = "Dorito",
                CodeProduct = "0001",
                Brand = "Confiteca",
                Description = "250 GR",
                P_Unitary = 0.25f,
                Quantity = Cant,
                P_Total = Price_Total() * Price_Total(),
                Image_Product = "https://raw.githubusercontent.com/theerudito/Strore-APP-Xamarin-SQLite/master/product.png"
            });

            List_Products = new ObservableCollection<MProduct>(_myCart);
        }

        public int QuantityOnCart()
        {
            return _myCart.Count;
        }

        public async Task getClientFinal()
        {
            
            var seachClientFinal = await _dbContext.Client.Where(cli => cli.IdClient == cliFinal).FirstOrDefaultAsync();

            if (seachClientFinal != null)
            {
                DNI = seachClientFinal.DNI;
                IdClient = seachClientFinal.IdClient;
                FirstName = seachClientFinal.FirstName;
                LastName = seachClientFinal.LastName;
                Phone = seachClientFinal.Phone;
                Email = seachClientFinal.Email;
                Direction = seachClientFinal.Direction;
                City = seachClientFinal.City;
            }
            else
            {
                await DisplayAlert("Error", "El cliente no existe", "OK");
            }
        }

        public async Task Get_Data_Company()
        {
            var id = 1;
            var getCompany = await _dbContext.Company.Where(c => c.IdCompany == id).FirstOrDefaultAsync();
            if (getCompany != null)
            {
                Serie1 = getCompany.Serie1;
                Serie2 = getCompany.Serie2;
                NumDocument = Convert.ToInt32(getCompany.NumDocument);
                Document = getCompany.Document;
                IvaCompany = Convert.ToSingle(getCompany.Iva);
            }
        }

        public async Task Save_Buy()
        {
            await DisplayAlert("Compra", "Compra realizada con exito", "OK");
        }

        public async Task Delete_ProductCart(MProduct product)
        {
            if (await DisplayAlert("info", "Are you sure you want to delete this product?", "Yes", "No"))
            {
              var query = _myCart.Where(p => p.IdProduct == product.IdProduct);
              _myCart.Remove(product);

            }
        }
        
        public void Res_Quantity(MProduct pro)
        {
            foreach (MProduct product in _myCart)
            {
                if (product.IdProduct == pro.IdProduct)
                {
                    product.Quantity = _quantityIncrement--;
                }
            }
        }
       
        public void Sum_Quantity(MProduct pro)
        {
           
            foreach (MProduct product in _myCart)
            {
                if (product.IdProduct == pro.IdProduct)
                {
                    product.Quantity = _quantityIncrement++;
                }
            }
        }

        public float Price_Total()
        {
            
            foreach (MProduct product in _myCart)
            {
                P_TOTAL = calculos.Result_Cant_P_Unitary(Quantity(), product.P_Unitary);
            }
            return P_TOTAL;
        }

        public int Quantity() => _quantityIncrement;
        
        public void Total_Cart()
        {
            float des = 2.25f;
            foreach (MProduct product in _myCart)
            {
                SubTotal = calculos.Result_Subtotal(product.P_Total);
            }
            SubTotal12 = calculos.Result_Subtotal12(SubTotal);
            SubTotal0 = calculos.Result_Subtotal0(SubTotal0);
            Descuent = calculos.Result_Descuent(des);
            IvaCart = calculos.Result_Iva(SubTotal);
            Total = calculos.Result_Total_Final(SubTotal);
        }

        public async Task getClient()
        {
            var seachClient = await _dbContext.Client.Where(cli => cli.DNI == DNI).FirstOrDefaultAsync();
            if (seachClient != null)
            {
                DNI = seachClient.DNI;
                IdClient = seachClient.IdClient;
                FirstName = seachClient.FirstName;
                LastName = seachClient.LastName;
                Phone = seachClient.Phone;
                Email = seachClient.Email;
                Direction = seachClient.Direction;
            }
            else
            {
                await DisplayAlert("Error", "El cliente no existe", "OK");
                await getClientFinal();
            }
        }
        #endregion

        #region COMANDOS
        public ICommand btnSaveCartCommand => new Command(async () => await Save_Buy());
        public ICommand btnSearchDNICommand => new Command(async () => await getClient());
        public ICommand btnDeleteProductCart => new Command<MProduct>(async (pro) => await Delete_ProductCart(pro));
        public ICommand btnSumQuantityCommand => new Command<MProduct>((pro) => Sum_Quantity(pro));
        public ICommand btnRestQuantityCommand => new Command<MProduct>((pro) => Res_Quantity(pro));
        #endregion
    }
}
