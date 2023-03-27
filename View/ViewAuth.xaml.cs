using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class ViewAuth : ContentPage
{
	public ViewAuth()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = new AuthViewModel(Navigation, showRegister, showLogin);
    }
}