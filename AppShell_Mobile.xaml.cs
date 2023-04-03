using MyStore_MAUI.View;

namespace MyStore_MAUI;

public partial class AppShell_Mobile : Shell
{
	public AppShell_Mobile()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Mobile_ViewAuth), typeof(Mobile_ViewAuth));
        Routing.RegisterRoute(nameof(Mobile_Client), typeof(Mobile_Client));
        Routing.RegisterRoute(nameof(Mobile_Shopping), typeof(Mobile_Shopping));
        Routing.RegisterRoute(nameof(Mobile_Cart), typeof(Mobile_Cart));
        Routing.RegisterRoute(nameof(Mobile_Client), typeof(Mobile_Client));
        Routing.RegisterRoute(nameof(Mobile_Product), typeof(Mobile_Product));
        Routing.RegisterRoute(nameof(Mobile_Reports), typeof(Mobile_Reports));
        Routing.RegisterRoute(nameof(Mobile_Config), typeof(Mobile_Config));
        Routing.RegisterRoute(nameof(Mobile_Users), typeof(Mobile_Users));
        Routing.RegisterRoute(nameof(Mobile_DetailsCart), typeof(Mobile_DetailsCart));

        Image myImage = new Image { Source = ImageSource.FromResource("CRUD_SQLITE.Images.store.png") };


        this.Items.Add(new ShellContent
        {
            Title = "Home",
            Icon = "store.png",
            Content = new Mobile_Home()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Shopping",
            Icon = "tienda",
            Content = new Mobile_Shopping()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Clients",
            Icon = "avatar.png",
            Content = new Mobile_Client()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Products",
            Icon = "product.png",
            Content = new Mobile_Product()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Reports",
            Icon = "store.png",
            Content = new Mobile_Reports()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Details",
            Icon = "lupa.png",
            Content = new Mobile_DetailsCart()
        });
        this.Items.Add(new ShellContent
        {
            Title = "Users",
            Icon = "avatar.png",
            Content = new Mobile_Users()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Config",
            Icon = "config.png",
            Content = new Mobile_Config()
        });
        this.Items.Add(new ShellContent
        {
            Title = "Config",
            Icon = "config.png",
            Content = new Mobile_ViewAuth()
        });
    }
}
