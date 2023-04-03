using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Config : ContentPage
{
	public Desktop_Config()
	{
        var buttonChange = buttonUpdate;
        InitializeComponent();
        BindingContext = new CompanyViewModel(Navigation);
    }
}