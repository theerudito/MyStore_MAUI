
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;
using Microsoft.Maui.Storage;

namespace MyStore_MAUI;

public partial class App : Application
{
    private readonly string _localStorageToken = "token";
    public void ShowAppShell()
    {

        if (Preferences.ContainsKey(_localStorageToken) == false)
        {
            #if ANDROID || IOS
                        MainPage = new NavigationPage(new Mobile_ViewAuth());
            #else
                        MainPage = new NavigationPage(new Desktop_ViewAuth());
            #endif
        }
        else
        {
            //MainPage = new AppShell_Desktop();
            
            #if ANDROID || IOS
                        MainPage = new AppShell_Mobile();
            #else
                        MainPage = new AppShell_Desktop();
            #endif
        }
    }
    public void CreateData(Application_Context _dbCcontext)
    {
        int id = 1;
        string conde = "250787";

        var codeAdmin = new MCodeApp
        {
            CodeAdmin = BCrypt.Net.BCrypt.HashPassword(conde)
        };

        var searchCodeId = _dbCcontext.CodeApp.Find(1);
        if (searchCodeId == null)
        {
            _dbCcontext.CodeApp.Add(codeAdmin);
            _dbCcontext.SaveChanges();
        }

        var myCompany = new MCompany
        {
            NameCompany = "Heaven",
            NameOwner = "Jorge Loor",
            Direction = "Libertad del Toachi Km 8",
            Email = "erudito.tv@gmail.com",
            RUC = "123456789",
            Phone = "0960806054",
            NumDocument = 1234567890,
            Serie1 = "001",
            Serie2 = "002",
            Document = "Factura",
            DB = "Firebase",
            Iva = "0.12",
            Coin = "USD",
        };

        var company = _dbCcontext.Company.Find(id);

        if (company == null)
        {
            _dbCcontext.Add(myCompany);
            _dbCcontext.SaveChanges();
        }

        var client = new MClient
        {
            IdClient = 1,
            DNI = "0999999999",
            FirstName = "Consumidor",
            LastName = "Final",
            Email = "consumidorfinal@gmail.com",
            Phone = "0999999999",
            Direction = "SN",
            City = "SN",
        };
        var myClient = _dbCcontext.Client.Find(id);

        if (myClient == null)
        {
            _dbCcontext.Add(client);
            _dbCcontext.SaveChanges();
        }

        var product = new MProduct
        {
            IdProduct = 1,
            NameProduct = "Coca Cola",
            CodeProduct = "0001",
            Brand = "Coca Cola",
            Description = "Bebida Gaseosa",
            P_Unitary = 1.50f,
            Quantity = 10,
            Image_Product = "https://raw.githubusercontent.com/theerudito/Strore-APP-Xamarin-SQLite/master/product.png"
        };
        var myProduct = _dbCcontext.Product.Find(id);

        if (myProduct == null)
        {
            _dbCcontext.Add(product);
            _dbCcontext.SaveChanges();
        }
    }
    public App()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        InitializeComponent();


        var _dbCcontext = new Application_Context();

        //_dbCcontext.Database.Migrate();

        CreateData(_dbCcontext);

        ShowAppShell();
    }
}
