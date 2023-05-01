using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Base;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    internal class UsersViewModel : BaseViewModel
    {
        private Application_Context _dbContext = new Application_Context();

        private ObservableCollection<MAuth> _List_Users;
        private readonly string LocalStorageUser = "user";

        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetAllUsersAsync();
        }

        public ObservableCollection<MAuth> List_Users
        {
            get { return _List_Users; }
            set
            {
                _List_Users = value;
                OnPropertyChanged();
            }
        }

        public async Task<IEnumerable<MAuth>> GetAllUsersAsync()
        {
            var result = await _dbContext.Auth.ToListAsync();

            List_Users = new ObservableCollection<MAuth>(result);

            return result;
        }

        public async Task DeleteUser(MAuth auth)
        {
            var result = await _dbContext.Auth.FirstOrDefaultAsync(user => user.IdAuth == auth.IdAuth);
            if (result != null)
            {
                if (await DisplayAlert("Delete User", "Are you sure you want to delete this user?", "Yes", "No"))
                {
                    _dbContext.Auth.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    SecureStorage.Remove(LocalStorageUser);
                    await GetAllUsersAsync();
                    Preferences.Clear();
                }
            }
        }

        public async Task UpdateUser()
        {
            await DisplayAlert("infor", "Deleted", "Ok");
        }

        public async Task goUpdateUser()
        {
            await DisplayAlert("infor", "goUpdate", "Ok");
        }

        public ICommand btnGoUpdateCommand => new Command(async () => await goUpdateUser());
        public ICommand btnDeleteCommand => new Command<MAuth>(async (auth) => await DeleteUser(auth));
        public ICommand btnUpdateCommand => new Command(async () => await goUpdateUser());
    }
}