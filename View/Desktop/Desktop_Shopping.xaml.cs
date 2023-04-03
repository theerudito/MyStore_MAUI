using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Shopping : ContentPage
{
	public Desktop_Shopping()
	{
		InitializeComponent();
        BindingContext = new ShoppingViewModel(Navigation);
    }
}