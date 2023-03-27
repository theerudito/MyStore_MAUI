using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Shopping : ContentPage
{
	public Shopping()
	{
		InitializeComponent();
        BindingContext = new ShoppingViewModel(Navigation);
    }
}