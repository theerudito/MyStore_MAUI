using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class DetailsCart : ContentPage
{
	public DetailsCart()
	{
		InitializeComponent();
        BindingContext = new DetailsCartViewModel(Navigation);
    }
}