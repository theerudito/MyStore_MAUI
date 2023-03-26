using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Context;

namespace MyStore_MAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        var _dbCcontext = new Application_Context();
        _dbCcontext.Database.Migrate();
    }
}
