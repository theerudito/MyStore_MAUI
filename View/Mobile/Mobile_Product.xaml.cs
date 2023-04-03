

using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_Product : ContentPage
{
	public Mobile_Product()
	{
		InitializeComponent();
        BindingContext = new ProductViewModel(Navigation);
    }
}