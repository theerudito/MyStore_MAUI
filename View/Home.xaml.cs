using CRUD_SQLITE.ViewModels;

namespace MyStore_MAUI.View;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        BindingContext = new HomeViewModel(Navigation);
    }
}