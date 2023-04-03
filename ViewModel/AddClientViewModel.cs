using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    internal class AddClientViewModel : BaseViewModel
    {
        Application_Context _dbContext = new Application_Context(); 

        #region VARIABLES
        public MClient _client { get; set; }
        public bool _Editing;
        public string _Save;
        public string _textDNI;
        public string _textFirstName;
        public string _textLastName;
        public string _textDirection;
        public string _textPhone;
        public string _textEmail;
        public string _textCity;
        #endregion

        #region CONSTUCTOR
        public AddClientViewModel(INavigation navigation, MClient client, bool _goEditing)
        {
            if (client != null)
            {
                _client = client;
                _Editing = _goEditing;
                Save = "EDIT CLIENT";
            }
            else
            {
                _client = new MClient();
                _Editing = false;
                Save = "SAVE CLIENT";
            }

            Navigation = navigation;
            obtenerData();
        }
        #endregion

        #region OBJECTS
        public string Save
        {
            get { return _Save; }
            set
            {
                SetValue(ref _Save, value);
            }
        }
        public string TextDNI
        {
            get { return _textDNI; }
            set
            {
                SetValue(ref _textDNI, value);
            }
        }
        public string TextFirstName
        {
            get { return _textFirstName; }
            set
            {
                SetValue(ref _textFirstName, value);
                //OnPropertyChanged();
            }
        }
        public string TextLastName
        {
            get { return _textLastName; }
            set
            {
                SetValue(ref _textLastName, value);
                //OnPropertyChanged();
            }
        }
        public string TextDirection
        {
            get { return _textDirection; }
            set
            {
                SetValue(ref _textDirection, value);
                //OnPropertyChanged();
            }
        }
        public string TextPhone
        {
            get { return _textPhone; }
            set
            {
                SetValue(ref _textPhone, value);
                //OnPropertyChanged();
            }
        }
        public string TextEmail
        {
            get { return _textEmail; }
            set
            {
                SetValue(ref _textEmail, value);
                //OnPropertyChanged();
            }
        }
        public string TextCity
        {
            get { return _textCity; }
            set
            {
                SetValue(ref _textCity, value);
                //OnPropertyChanged();
            }
        }
        #endregion

        #region METHODS
        public void obtenerData()
        {
            TextDNI = Convert.ToString(_client.DNI);
            TextFirstName = _client.FirstName;
            TextLastName = _client.LastName;
            TextDirection = _client.Direction;
            TextPhone = Convert.ToString(_client.Phone);
            TextEmail = _client.Email;
            TextCity = _client.City;
        }
        public async Task<MClient> createClientAsync()
        {
            var newClient = await _dbContext.Client.FirstOrDefaultAsync(cli => cli.DNI == TextDNI);
            if (newClient == null)
            {
                var client = new MClient
                {
                    DNI = TextDNI,
                    FirstName = TextFirstName,
                    LastName = TextLastName,
                    Direction = TextDirection,
                    Phone = TextPhone,
                    Email = TextEmail,
                    City = TextCity
                };

                _dbContext.Client.Add(client);
                await _dbContext.SaveChangesAsync();
                ResetField();
                

                #if ANDROID || IOS
                await Navigation.PushAsync(new Mobile_Client());
#else
                await Navigation.PushAsync(new Desktop_Client());
#endif

                return client;

            }
            else
            {
                await DisplayAlert("Error", "The client already exists", "OK");
                _Editing = true;
                Save = "EDIT CLIENT";
                TextDNI = newClient.DNI;
                TextFirstName = newClient.FirstName;
                TextLastName = newClient.LastName;
                TextDirection = newClient.Direction;
                TextPhone = newClient.Phone;
                TextEmail = newClient.Email;
                TextCity = newClient.City;
                return null;
            }

        }
        public async Task<MClient> editClientAsync()
        {
            _client.DNI = TextDNI;
            _client.FirstName = TextFirstName;
            _client.LastName = TextLastName;
            _client.Direction = TextDirection;
            _client.Phone = TextPhone;
            _client.Email = TextEmail;
            _client.City = TextCity;

            _dbContext.Client.Update(_client);
            await _dbContext.SaveChangesAsync();
            ResetField();

            #if ANDROID || IOS
               await Navigation.PushAsync(new Mobile_Client());
#else
               await Navigation.PushAsync(new Desktop_Client());
#endif

            return _client;
        }
        public async Task<MClient> createOrEditClientAsync()
        {
            if (_Editing)
            {
                return await editClientAsync();
            }
            else
            {
                return await createClientAsync();
            }
        }
        public void ResetField()
        {
            TextDNI = "";
            TextFirstName = "";
            TextLastName = "";
            TextDirection = "";
            TextPhone = "";
            TextEmail = "";
            TextCity = "";
        }
#endregion

        #region COMMANDS
        public ICommand btnSaveClient => new Command<MClient>(async (cli) => await createOrEditClientAsync());
        #endregion

    }
}
