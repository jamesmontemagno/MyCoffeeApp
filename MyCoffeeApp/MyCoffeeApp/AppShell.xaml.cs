using MyCoffeeApp.Views;

namespace MyCoffeeApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AddMyCoffeePage),
typeof(AddMyCoffeePage));

        Routing.RegisterRoute(nameof(MyCoffeeDetailsPage),
            typeof(MyCoffeeDetailsPage));

        Routing.RegisterRoute(nameof(RegistrationPage),
            typeof(RegistrationPage));
    }
}