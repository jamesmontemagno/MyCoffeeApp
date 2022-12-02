using MyCoffeeApp.ViewModels;

namespace MyCoffeeApp.Views;
public partial class InternetCoffeePage : ContentPage
{
    public InternetCoffeePage(InternetCoffeeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}