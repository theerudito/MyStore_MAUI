using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Users : ContentPage
{
	public Users()
	{
		InitializeComponent();
        BindingContext = new UsersViewModel(Navigation);
    }
}