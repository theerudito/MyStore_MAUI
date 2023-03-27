

using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Product : ContentPage
{
	public Product()
	{
		InitializeComponent();
        BindingContext = new ProductViewModel(Navigation);
    }
}