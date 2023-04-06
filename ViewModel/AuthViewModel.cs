using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace MyStore_MAUI.ViewModel
{
    class AuthViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context();
        App app = (App)Application.Current;

        #region  VARIABLES
        private string _email;
        private string _password;
        private string _user;
        ObservableCollection<MAuth> _List_Users;
        private StackLayout showRegister;
        private StackLayout showLogin;
        private readonly string LocalStorageUser = "user";
        private readonly string LocalStorageToken = "token";
        #endregion

        #region  OBJECTS
        public ObservableCollection<MAuth> List_Users
        {
            get { return _List_Users; }
            set
            {
                SetValue(ref _List_Users, value);
                OnpropertyChanged();
            }
        }
        public string User
        {
            get { return _user; }
            set { SetValue(ref _user, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        #endregion

        #region CONSTRUCTOR
        public AuthViewModel(INavigation navigation, StackLayout showRegister, StackLayout showLogin)
        {
            showRegister.IsVisible = false;
            Navigation = navigation;
            this.showRegister = showRegister;
            this.showLogin = showLogin;
        }

        #endregion

        #region METHODS
        public async Task Login()
        {

            if (ValitationsLogin() == true)
            {
               
                var query = await _dbContext.Auth.FirstOrDefaultAsync(user => user.Email == Email);

                if (query != null)
                {
                    
                   // check the password
                    if (BCrypt.Net.BCrypt.Verify(Password, query.Password))
                    {
                        await DisplayAlert("Login", "Welcome " + query.User, "Ok");

                        Preferences.Set(LocalStorageToken, Password);

                        Preferences.Set(LocalStorageUser, query.User);

                        
                        app.ShowAppShell();                        
                        
                        User = "";
                        Email = "";
                        Password = "";
                    }
                    else
                    {
                        await DisplayAlert("Login", "Password or Email is Wrong", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Login", "User not found", "Ok");
                }
            }
        }
        public async Task Register()
        {
           
            if (ValitationsRegister() == true)
            {
               
                var query = await _dbContext.Auth.FirstOrDefaultAsync(user => user.Email == Email);

                if (query == null)
                {
                    
                    var user = new MAuth()
                    {
                        User = User,
                        Email = Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(Password)
                    };
                     
                    _dbContext.Auth.Add(user);
                    await _dbContext.SaveChangesAsync();


                    await DisplayAlert("Register", "Register Success", "Ok");

                    Preferences.Set(LocalStorageToken, Password);

                    Preferences.Set(LocalStorageUser, User);

                    app.ShowAppShell();
                    
                    User = "";
                    Email = "";
                    Password = "";
                }
                else
                {
                    await DisplayAlert("Error", "Email already exists", "Ok");
                }
            }
        }
        public void show_Login()
        {
            showRegister.IsVisible = false;
            showLogin.IsVisible = true;
        }
        public void show_Register()
        {
            showRegister.IsVisible = true;
            showLogin.IsVisible = false;
        }
        public bool  ValitationsLogin()
        {
            if (string.IsNullOrEmpty(Email))
            {
               DisplayAlert("Error", "Email is required", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                DisplayAlert("Error", "Password is required", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValitationsRegister()
        {
            if (string.IsNullOrEmpty(User))
            {
                DisplayAlert("Error", "User is required", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(Email))
            {
                DisplayAlert("Error", "Email is required", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                DisplayAlert("Error", "Password is required", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region COMMANDS
        public ICommand btnLoginCommand => new Command(async () => await Login());
        public ICommand btnShowRegisterCommand => new Command(show_Login);
        public ICommand btnRegisterCommand => new Command(async () => await Register());
        public ICommand btnShowLoginCommand => new Command(show_Register);
        #endregion 
    }
}