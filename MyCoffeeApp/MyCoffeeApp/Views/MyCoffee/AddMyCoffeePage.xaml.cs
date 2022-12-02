using MyCoffeeApp.ViewModels;

namespace MyCoffeeApp.Views;
public partial class AddMyCoffeePage : ContentPage
{
    public AddMyCoffeePage(AddMyCoffeeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}