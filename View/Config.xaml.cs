using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Config : ContentPage
{
	public Config()
	{
        var buttonChange = buttonUpdate;
        InitializeComponent();
        BindingContext = new CompanyViewModel(Navigation);
    }
}