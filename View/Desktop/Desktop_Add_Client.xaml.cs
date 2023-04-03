using MyStore_MAUI.Models;
using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Add_Client : ContentPage
{
	public Desktop_Add_Client(MClient client, bool _goEditing)
	{
		InitializeComponent();
        BindingContext = new AddClientViewModel(Navigation, client, _goEditing);
    }
}
