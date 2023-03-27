using MyStore_MAUI.View;

namespace MyStore_MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ViewAuth), typeof(ViewAuth));
        Routing.RegisterRoute(nameof(Client), typeof(Client));
        Routing.RegisterRoute(nameof(Shopping), typeof(Shopping));
        Routing.RegisterRoute(nameof(Cart), typeof(Cart));
        Routing.RegisterRoute(nameof(Client), typeof(Client));
        Routing.RegisterRoute(nameof(Product), typeof(Product));
        Routing.RegisterRoute(nameof(Reports), typeof(Reports));
        Routing.RegisterRoute(nameof(Config), typeof(Config));
        Routing.RegisterRoute(nameof(Users), typeof(Users));
        Routing.RegisterRoute(nameof(DetailsCart), typeof(DetailsCart));

        Image myImage = new Image { Source = ImageSource.FromResource("CRUD_SQLITE.Images.store.png") };


        this.Items.Add(new ShellContent
        {
            Title = "Home",
            Icon = "store.png",
            Content = new Home()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Shopping",
            Icon = "tienda",
            Content = new Shopping()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Clients",
            Icon = "avatar.png",
            Content = new Client()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Products",
            Icon = "product.png",
            Content = new Product()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Reports",
            Icon = "store.png",
            Content = new Reports()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Details",
            Icon = "lupa.png",
            Content = new DetailsCart()
        });
        this.Items.Add(new ShellContent
        {
            Title = "Users",
            Icon = "avatar.png",
            Content = new Users()
        });

        this.Items.Add(new ShellContent
        {
            Title = "Config",
            Icon = "config.png",
            Content = new Config()
        });
    }
}
