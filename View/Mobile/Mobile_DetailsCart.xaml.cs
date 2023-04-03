using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_DetailsCart : ContentPage
{
	public Mobile_DetailsCart()
	{
		InitializeComponent();
        BindingContext = new DetailsCartViewModel(Navigation);
    }
}