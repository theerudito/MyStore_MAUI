using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;
public partial class Mobile_Client : ContentPage
{
	public Mobile_Client()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel(Navigation);
    }
}