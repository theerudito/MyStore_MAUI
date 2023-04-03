using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_DetailsCart : ContentPage
{
	public Desktop_DetailsCart()
	{
		InitializeComponent();
        BindingContext = new DetailsCartViewModel(Navigation);
    }
}