using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Cart : ContentPage
{
	public Desktop_Cart()
	{
		InitializeComponent();
        BindingContext = new CartViewModel(Navigation);
    }
}