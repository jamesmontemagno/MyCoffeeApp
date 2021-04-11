using MyCoffeeApp.Views;
using Xamarin.Forms;

namespace MyCoffeeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
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
}
