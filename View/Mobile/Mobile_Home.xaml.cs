using CRUD_SQLITE.ViewModels;

namespace MyStore_MAUI.View;

public partial class Mobile_Home : ContentPage
{
	public Mobile_Home()
	{
		InitializeComponent();
        BindingContext = new HomeViewModel(Navigation);
    }
}