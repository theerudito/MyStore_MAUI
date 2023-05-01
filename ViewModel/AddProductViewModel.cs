using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    public class AddProductViewModel : BaseViewModel
    {
        private Application_Context _dbContext = new Application_Context();

        #region VARIABLES

        public MProduct _product { get; set; }
        public bool _Editing;
        private string _Save;
        private string _textName;
        private string _textCode;
        private string _textBrand;
        private string _textDescription;
        private float _textPrice;
        private string _textQuantity;
        private string _refImage;
        private string _urlImage = "https://raw.githubusercontent.com/theerudito/Strore-APP-Xamarin-SQLite/master/product.png";
        private ImageSource _image;
        private string _imageByte;

        #endregion VARIABLES

        #region CONSTRUCTOR

        public AddProductViewModel(INavigation navigation, MProduct product, bool _goEditingProduct)
        {
            Navigation = navigation;

            if (product != null)
            {
                _product = product;
                _Editing = _goEditingProduct;
                Save = "EDIT PRODUCT";
            }
            else
            {
                _product = new MProduct();
                _Editing = false;
                Save = "SAVE PRODUCT";
                ImageProduct = ImageSource.FromFile("image.png");
            }
            getData();
        }

        #endregion CONSTRUCTOR

        #region OBJECTS

        public string Save
        {
            get { return _Save; }
            set
            {
                SetValue(ref _Save, value);
            }
        }

        public string TextName
        {
            get { return _textName; }
            set
            {
                SetValue(ref _textName, value);
            }
        }

        public string TextCode
        {
            get { return _textCode; }
            set
            {
                SetValue(ref _textCode, value);
            }
        }

        public string TextBrand
        {
            get { return _textBrand; }
            set
            {
                SetValue(ref _textBrand, value);
            }
        }

        public string TextDescription
        {
            get { return _textDescription; }
            set
            {
                SetValue(ref _textDescription, value);
            }
        }

        public float TextPrice
        {
            get { return _textPrice; }
            set
            {
                SetValue(ref _textPrice, value);
            }
        }

        public string TextQuantity
        {
            get { return _textQuantity; }
            set
            {
                SetValue(ref _textQuantity, value);
            }
        }

        public ImageSource ImageProduct
        {
            get { return _image; }
            set
            {
                SetValue(ref _image, value);
            }
        }

        public string RefImagen
        {
            get { return _refImage; }
            set
            {
                SetValue(ref _refImage, value);
            }
        }

        public string ImagenByte
        {
            get { return _imageByte; }
            set
            {
                SetValue(ref _imageByte, value);
            }
        }

        #endregion OBJECTS

        #region METHODS

        public void getData()
        {
            TextName = _product.NameProduct;
            TextCode = _product.CodeProduct;
            TextBrand = _product.Brand;
            TextDescription = _product.Description;
            TextPrice = _product.P_Unitary;
            TextQuantity = Convert.ToString(_product.Quantity);
            ImageProduct = _product.Image_Product == null ? _product.Image_Product : ImageProduct;
        }

        public async Task openGalery()
        {
            var result = await FilePicker.PickAsync();
            if (result != null)
            {
                ImageProduct = result.FullPath;
                var stream = await result.OpenReadAsync();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string base64 = Convert.ToBase64String(bytes);
                ImagenByte = base64;
            }
        }

        public async Task<MProduct> Insert_Product()
        {
            var newProducto = await _dbContext.Product.FirstOrDefaultAsync(pro => pro.CodeProduct == TextCode);

            if (newProducto == null)
            {
                var product = new MProduct
                {
                    NameProduct = TextName,
                    CodeProduct = TextCode,
                    Brand = TextBrand,
                    Description = TextDescription,
                    P_Unitary = TextPrice,
                    Quantity = Convert.ToInt32(TextQuantity),
                    Image_Product = _urlImage == null ? _urlImage : ImagenByte,
                    RefImagen = RefImagen + TextCode,
                };
                await _dbContext.Product.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                ResetField();

#if ANDROID || IOS
                await Navigation.PushAsync(new Mobile_Product());
#else
                await Navigation.PushAsync(new Desktop_Product());
#endif

                return product;
            }
            else
            {
                await DisplayAlert("Alert", "Product already exists", "OK");
                _Editing = true;
                Save = "EDIT PRODUCT";
                TextCode = newProducto.CodeProduct;
                TextName = newProducto.NameProduct;
                TextBrand = newProducto.Brand;
                TextDescription = newProducto.Description;
                TextPrice = newProducto.P_Unitary;
                TextQuantity = Convert.ToString(newProducto.Quantity);
                ImageProduct = newProducto.Image_Product;
            }
            return null;
        }

        public async Task<MProduct> Update_Product()
        {
            _product.NameProduct = TextName;
            _product.CodeProduct = TextCode;
            _product.Brand = TextBrand;
            _product.Description = TextDescription;
            _product.P_Unitary = TextPrice;
            _product.Quantity = Convert.ToInt32(TextQuantity);
            _product.Image_Product = _urlImage == null ? _urlImage : ImagenByte;
            _product.RefImagen = RefImagen;
            _dbContext.Product.Update(_product);
            await _dbContext.SaveChangesAsync();
            ResetField();

#if ANDROID || IOS
            await Navigation.PushAsync(new Mobile_Product());
#else
            await Navigation.PushAsync(new Desktop_Product());
#endif

            return _product;
        }

        public async Task<MProduct> createOrEditProductAsync()
        {
            if (_Editing)
            {
                return await Update_Product();
            }
            else
            {
                return await Insert_Product();
            };
        }

        public void ResetField()
        {
            TextName = "";
            TextCode = "";
            TextBrand = "";
            TextDescription = "";
            TextPrice = 0;
            TextQuantity = "";
            ImageProduct = ImageSource.FromFile("image.png");
            RefImagen = "";
            ImagenByte = "";
        }

        #endregion METHODS

        #region COMMAND

        public ICommand btnCreateProduct => new Command<MProduct>(async (prod) => await createOrEditProductAsync());
        public ICommand btnOpenGalery => new Command(async () => await openGalery());

        #endregion COMMAND
    }
}