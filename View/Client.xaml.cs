using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;
public partial class Client : ContentPage
{
	public Client()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel(Navigation);
    }
}