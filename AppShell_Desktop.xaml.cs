using MyStore_MAUI.View;

namespace MyStore_MAUI;

public partial class AppShell_Desktop : Shell
{
    public AppShell_Desktop()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Desktop_ViewAuth), typeof(Desktop_ViewAuth));
        Routing.RegisterRoute(nameof(Desktop_Client), typeof(Desktop_Client));
        Routing.RegisterRoute(nameof(Desktop_Shopping), typeof(Desktop_Shopping));
        Routing.RegisterRoute(nameof(Desktop_Cart), typeof(Desktop_Cart));
        Routing.RegisterRoute(nameof(Desktop_Client), typeof(Desktop_Client));
        Routing.RegisterRoute(nameof(Desktop_Product), typeof(Desktop_Product));
        Routing.RegisterRoute(nameof(Desktop_Reports), typeof(Desktop_Reports));
        Routing.RegisterRoute(nameof(Desktop_Config), typeof(Desktop_Config));
        Routing.RegisterRoute(nameof(Desktop_Users), typeof(Desktop_Users));
        Routing.RegisterRoute(nameof(Desktop_DetailsCart), typeof(Desktop_DetailsCart));

        Image myImage = new Image { Source = ImageSource.FromResource("CRUD_SQLITE.Images.store.png") };


        this.Items.Add(new ShellContent
        {
            Title = "Home",
            Icon = "store.png",
            Content = new Desktop_Home()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Shopping",
            Icon = "cart.png",
            Content = new Desktop_Shopping()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Clients",
            Icon = "avatar.png",
            Content = new Desktop_Client()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Products",
            Icon = "product.png",
            Content = new Desktop_Product()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Reports",
            Icon = "store.png",
            Content = new Desktop_Reports()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Details",
            Icon = "lupa.png",
            Content = new Desktop_DetailsCart()
        });
        this.Items.Add(new ShellContent
        {
            Title = "Users",
            Icon = "avatar.png",
            Content = new Desktop_Users()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Config",
            Icon = "config.png",
            Content = new Desktop_Config()
        });
    }
}
