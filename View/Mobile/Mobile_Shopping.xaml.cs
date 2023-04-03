using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_Shopping : ContentPage
{
	public Mobile_Shopping()
	{
		InitializeComponent();
        BindingContext = new ShoppingViewModel(Navigation);
    }
}