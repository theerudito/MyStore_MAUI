using MyStore_MAUI.Models;
using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Add_Product : ContentPage
{
	public Add_Product(MProduct product, bool _goEditingProduct)
	{
		InitializeComponent();
        BindingContext = new AddProductViewModel(Navigation, product, _goEditingProduct);
    }
}