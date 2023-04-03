using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_ViewAuth : ContentPage
{
	public Desktop_ViewAuth()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = new AuthViewModel(Navigation, showRegister, showLogin);
    }
}