using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Desktop_Reports : ContentPage
{
	public Desktop_Reports()
	{
		InitializeComponent();
        BindingContext = new ReportViewModel(Navigation);
    }
}