using MvvmHelpers;
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.Views;

namespace MyCoffeeApp.ViewModels;

public partial class MyCoffeeViewModel : ViewModelBase
{
    public ObservableRangeCollection<Coffee> Coffee { get; set; }

    ICoffeeService coffeeService;
    IToast toaster;

    public MyCoffeeViewModel(ICoffeeService coffeeService, IToast toaster)
    {

        Title = "My Coffee";

        Coffee = new ObservableRangeCollection<Coffee>();
        this.toaster = toaster;
        this.coffeeService = coffeeService;
    }

    [RelayCommand]
    async Task Add()
    {
        /*var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
        var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster of coffee");
        await CoffeeService.AddCoffee(name, roaster);
        await Refresh();*/

        var route = $"{nameof(AddMyCoffeePage)}?Name=Motz";
        await Shell.Current.GoToAsync(route);

    }

    [RelayCommand]
    async Task Selected(Coffee coffee)
    {
        if (coffee == null)
            return;

        var route = $"{nameof(MyCoffeeDetailsPage)}?CoffeeId={coffee.Id}";
        await Shell.Current.GoToAsync(route);
    }

    [RelayCommand]
    async Task Remove(Coffee coffee)
    {
        await coffeeService.RemoveCoffee(coffee.Id);
        await Refresh();
    }

    [RelayCommand]
    async Task Refresh()
    {
        IsBusy = true;

#if DEBUG
        await Task.Delay(500);
#endif

        Coffee.Clear();

        var coffees = await coffeeService.GetCoffee();

        Coffee.AddRange(coffees);

        IsBusy = false;

        toaster?.MakeToast("Refreshed!");
    }
}
