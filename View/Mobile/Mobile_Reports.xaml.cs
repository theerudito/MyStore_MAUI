using MyStore_MAUI.ViewModel;

namespace MyStore_MAUI.View;

public partial class Mobile_Reports : ContentPage
{
	public Mobile_Reports()
	{
		InitializeComponent();
        BindingContext = new ReportViewModel(Navigation);
    }
}