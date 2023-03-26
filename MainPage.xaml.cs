using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new VMMainPage(Navigation);
	}
}

