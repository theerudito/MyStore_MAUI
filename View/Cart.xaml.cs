using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Cart : ContentPage
{
	public Cart()
	{
		InitializeComponent();
        BindingContext = new CartViewModel(Navigation);
    }
}