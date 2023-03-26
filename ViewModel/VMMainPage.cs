using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Context;
using MyStore_MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    public class VMMainPage : BaseViewModel
    {
        Application_Context _dbCcontext = new Application_Context();
        ObservableCollection<Naruto> _List_personajes;
        public VMMainPage(INavigation navigation)
        {
            Navigation = navigation;
            LoadPersonaje();
        }

        public ObservableCollection<Naruto> Personajes
        {
            get { return _List_personajes; }
            set
            {
                _List_personajes = value;
                OnPropertyChanged();
            }
        }


        public async Task LoadPersonaje()
        {
            var personajes = await _dbCcontext.Personajes.ToListAsync();

            Personajes = new ObservableCollection<Naruto>(personajes);
        }

        public async Task Create()
        {
            var createPersonaje = new Naruto
            {
                Name = "Naruto",
                Clan = "Uzumaki",
                Age = 12,
            };

            _dbCcontext.Add(createPersonaje);
            await _dbCcontext.SaveChangesAsync();
            await LoadPersonaje();
            await DisplayAlert("Personaje", "Personaje creado", "Ok");
        }

        public ICommand btnSaveClient => new Command(async() => await Create());
    }

}
