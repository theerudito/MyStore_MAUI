using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_Users : ContentPage
{
	public Mobile_Users()
	{
		InitializeComponent();
        BindingContext = new UsersViewModel(Navigation);
    }
}