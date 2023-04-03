using CRUD_SQLITE.ViewModels;

namespace MyStore_MAUI.View;

public partial class Desktop_Home : ContentPage
{
	public Desktop_Home()
	{
		InitializeComponent();
        BindingContext = new HomeViewModel(Navigation);
    }
}