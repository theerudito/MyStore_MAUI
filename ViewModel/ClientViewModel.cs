using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using MyStore_MAUI.View;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    public class ClientViewModel : BaseViewModel
    {
        private Application_Context _dbContext = new Application_Context();
        public Command LoadData { get; }

        #region VARIABLES

        private ObservableCollection<MClient> _List_client;
        public bool _goEditing = true;

        #endregion VARIABLES

        #region CONSTRUCTOR

        public ClientViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetAllClientAsync();

            LoadData = new Command(async () => await GetAllClientAsync());
        }

        #endregion CONSTRUCTOR

        #region OBJECTS

        public ObservableCollection<MClient> List_Clients
        {
            get { return _List_client; }
            set
            {
                _List_client = value;
                OnpropertyChanged(nameof(List_Clients));
            }
        }

        #endregion OBJECTS

        #region METHODS

        public async Task GetAllClientAsync()
        {
            IsBusy = true;

            try
            {
                var result = await _dbContext.Client.ToListAsync();
                List_Clients = new ObservableCollection<MClient>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task go_Update_Client(MClient client)
        {
#if ANDROID || IOS
            await Navigation.PushAsync(new Mobile_Add_Client(client, _goEditing));
#else
            await Navigation.PushAsync(new Desktop_Add_Client(client, _goEditing));
#endif
        }

        public async Task go_New_Client(MClient client)
        {
#if ANDROID || IOS
            await Navigation.PushAsync(new Mobile_Add_Client(client, _goEditing));
#else
            await Navigation.PushAsync(new Desktop_Add_Client(client, _goEditing));
#endif
        }

        public async Task deleteClientAsync(MClient client)
        {
            var result = await _dbContext.Client.FirstOrDefaultAsync(cli => cli.IdClient == client.IdClient);
            if (result != null)
            {
                // hacer una alerta de confirmacion
                if (await DisplayAlert("Delete Client", "Are you sure you want to delete this client?", "Yes", "No"))
                {
                    _dbContext.Client.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    await GetAllClientAsync();
                }
            }
        }

        #endregion METHODS

        #region COMMANDS

        public ICommand btnDeleteClient => new Command<MClient>(async (cli) => await deleteClientAsync(cli));
        public ICommand btnGoNewClient => new Command<MClient>(async (cli) => await go_New_Client(cli));
        public ICommand btnGoUpdateClient => new Command<MClient>(async (cli) => await go_Update_Client(cli));
        public ICommand btnLeftClient => new Command(async () => await DisplayAlert("info", "prew", "ok"));
        public ICommand btnRightClient => new Command(async () => await DisplayAlert("info", "next", "ok"));

        #endregion COMMANDS
    }
}