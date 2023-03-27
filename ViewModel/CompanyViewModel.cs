using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;

namespace MyStore_MAUI.ViewModel
{
    public class CompanyViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context();
       
  
        #region CONTRUCTOR
        public CompanyViewModel(INavigation navigation)
        {
            Navigation = navigation;
            getCompanyAsync();
            showBtnSave = false;
        }
        #endregion


        #region VARIABLES
        private string _TextNameCompany;
        private string _TextNameOwner;
        private string _TextDirection;
        private string _TextEmail;
        private string _TextRUC;
        private string _TextPhone;
        private string _TextNumDocument;
        private string _TextSerie1;
        private string _TextSerie2;
        private string _TextTypeDocument;
        private string _TextCODE;
        private bool _showBtnSave;
        private string _TextDB;
        private string _TextIVA;
        private string _TextCoin;
        private readonly string LocalStorageUser = "user";
        private readonly string LocalStorageToken = "token";

        #endregion


        #region OBJETOS
        public bool showBtnSave
        {
            get { return _showBtnSave; }
            set { SetValue(ref _showBtnSave, value); }
        }
        public string Name
        {
            get { return _TextNameCompany; }
            set { SetValue(ref _TextNameCompany, value); }
        }
        public string Owner
        {
            get { return _TextNameOwner; }
            set { SetValue(ref _TextNameOwner, value); }
        }
        public string Direction
        {
            get { return _TextDirection; }
            set { SetValue(ref _TextDirection, value); }
        }
        public string Email
        {
            get { return _TextEmail; }
            set { SetValue(ref _TextEmail, value); }
        }
        public string RUC
        {
            get { return _TextRUC; }
            set { SetValue(ref _TextRUC, value); }
        }
        public string Phone
        {
            get { return _TextPhone; }
            set { SetValue(ref _TextPhone, value); }
        }
        public string NumDocument
        {
            get { return _TextNumDocument; }
            set { SetValue(ref _TextNumDocument, value); }
        }
        public string Serie1
        {
            get { return _TextSerie1; }
            set { SetValue(ref _TextSerie1, value); }
        }
        public string Serie2
        {
            get { return _TextSerie2; }
            set { SetValue(ref _TextSerie2, value); }
        }
        public string Document
        {
            get { return _TextTypeDocument; }
            set { SetValue(ref _TextTypeDocument, value); }
        }
        public string CODE
        {
            get { return _TextCODE; }
            set { SetValue(ref _TextCODE, value); }
        }
        public string DB
        {
            get { return _TextDB; }
            set { SetValue(ref _TextDB, value); }
        }
        public string Iva
        {
            get { return _TextIVA; }
            set { SetValue(ref _TextIVA, value); }
        }
        public string Coin
        {
            get { return _TextCoin; }
            set { SetValue(ref _TextCoin, value); }
        }
        public string SelectDB
        {
            get { return _TextDB; }
            set
            {
                SetProperty(ref _TextDB, value);
                DB = _TextDB;

            }
        }
        public string SelectIva
        {
            get { return _TextIVA; }
            set
            {
                SetProperty(ref _TextIVA, value);
                Iva = _TextIVA;

            }
        }
        public string SelectCoin
        {
            get { return _TextCoin; }
            set
            {
                SetProperty(ref _TextCoin, value);
                Coin = _TextCoin;

            }
        }

        #endregion


        #region METHODS
        public async Task<MCompany> getCompanyAsync()
        {
            var id = 1;
            var company = await _dbContext.Company.FindAsync(id);

            if (company != null)
            {
                Name = company.NameCompany;
                Owner = company.NameOwner;
                Direction = company.Direction;
                Email = company.Email;
                RUC = company.RUC;
                Phone = company.Phone;
                NumDocument = Convert.ToString(company.NumDocument);
                Serie1 = company.Serie1;
                Serie2 = company.Serie2;
                DB = company.DB;
                Document = company.Document;
                Iva = company.Iva.ToString();
                Coin = company.Coin;
            }
            return company;
        }
        public async Task<MCompany> updateCompanyAsync()
        {
            var id = 1;
            var company = await _dbContext.Company.FindAsync(id);

            if (company != null)
            {
                company.NameCompany = Name;
                company.NameOwner = Owner;
                company.Direction = Direction;
                company.Email = Email;
                company.RUC = RUC;
                company.Phone = Phone;
                company.NumDocument = Convert.ToInt32(NumDocument);
                company.Serie1 = Serie1;
                company.Serie2 = Serie2;
                company.DB = DB;
                company.Document = Document;
                company.Iva = Iva;
                company.Coin = Coin;
                await _dbContext.SaveChangesAsync();
            }
            CODE = "";
            showBtnSave = false;
            Console.WriteLine("Hola");
            return company;
        }
        public async Task Activate()
        {
            var company = await _dbContext.CodeApp.FirstOrDefaultAsync();

            if (BCrypt.Net.BCrypt.Verify(CODE, company.CodeAdmin))
            {
                await DisplayAlert("infor", "the code is correct", "ok");
                showBtnSave = true;
            }
            else
            {
                await DisplayAlert("infor", "the code is incorrect", "ok");
            }
        }

        public async void Logout()
        {
            App app = new App();
            app.MainPage = new NavigationPage(new ViewAuth());
            if (await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No"))

            {
               //Xamarin.Essentials.SecureStorage.Remove(LocalStorageUser);
               SecureStorage.Remove(LocalStorageToken);
                app.ShowAppShell();

                app.MainPage = new NavigationPage(new ViewAuth());
            }
        }
        #endregion


        #region COMMANDS
        public ICommand btnUpdateCompany => new Command(async () => await updateCompanyAsync());
        public ICommand btnLogOut => new Command(Logout);
        public ICommand btnAdmin => new Command(async () => await Activate());
        #endregion
    }
}
