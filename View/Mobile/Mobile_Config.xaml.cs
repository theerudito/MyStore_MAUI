using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_Config : ContentPage
{
	public Mobile_Config()
	{
        var buttonChange = buttonUpdate;
        InitializeComponent();
        BindingContext = new CompanyViewModel(Navigation);
    }
}