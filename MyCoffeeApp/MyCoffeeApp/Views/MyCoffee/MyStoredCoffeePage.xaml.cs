using MyCoffeeApp.ViewModels;

namespace MyCoffeeApp.Views;
public partial class MyStoredCoffeePage : ContentPage
{
    public MyStoredCoffeePage(MyCoffeeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (MyCoffeeViewModel)BindingContext;
        if (vm.Coffee.Count == 0)
            await vm.RefreshCommand.ExecuteAsync(null);
    }
}