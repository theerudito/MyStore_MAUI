using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Reports : ContentPage
{
	public Reports()
	{
		InitializeComponent();
        BindingContext = new ReportViewModel(Navigation);
    }
}