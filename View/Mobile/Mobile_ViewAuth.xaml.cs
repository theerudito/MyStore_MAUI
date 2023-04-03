using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_ViewAuth : ContentPage
{
	public Mobile_ViewAuth()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = new AuthViewModel(Navigation, showRegister, showLogin);
    }
}