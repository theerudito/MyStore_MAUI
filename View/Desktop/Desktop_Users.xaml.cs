using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Users : ContentPage
{
	public Desktop_Users()
	{
		InitializeComponent();
        BindingContext = new UsersViewModel(Navigation);
    }
}