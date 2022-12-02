using MvvmHelpers;
using MyCoffeeApp.Shared.Models;

namespace MyCoffeeApp.ViewModels;

public partial class InternetCoffeeViewModel : ViewModelBase
{
    public ObservableRangeCollection<Coffee> Coffee { get; set; }

    public InternetCoffeeViewModel()
    {

        Title = "Internet Coffee";

        Coffee = new ObservableRangeCollection<Coffee>();
    }

    [RelayCommand]
    async Task Add()
    {
        var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
        var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster of coffee");
        await InternetCoffeeService.AddCoffee(name, roaster);
        await Refresh();
    }

    [RelayCommand]
    async Task Remove(Coffee coffee)
    {
        await InternetCoffeeService.RemoveCoffee(coffee.Id);
        await Refresh();
    }

    [RelayCommand]
    async Task Refresh()
    {
        IsBusy = true;

        await Task.Delay(2000);

        Coffee.Clear();

        var coffees = await InternetCoffeeService.GetCoffee();

        Coffee.AddRange(coffees);

        IsBusy = false;
    }
}
