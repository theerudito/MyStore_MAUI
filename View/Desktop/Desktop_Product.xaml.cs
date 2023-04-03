

using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Product : ContentPage
{
	public Desktop_Product()
	{
		InitializeComponent();
        BindingContext = new ProductViewModel(Navigation);
    }
}