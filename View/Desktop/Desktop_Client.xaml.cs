using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;
public partial class Desktop_Client : ContentPage
{
	public Desktop_Client()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel(Navigation);
    }
}