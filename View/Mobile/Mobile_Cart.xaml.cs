using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_Cart : ContentPage
{
	public Mobile_Cart()
	{
		InitializeComponent();
        BindingContext = new CartViewModel(Navigation);
    }
}