using MvvmHelpers;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.Views;

namespace MyCoffeeApp.ViewModels;

public partial class CoffeeEquipmentViewModel : ViewModelBase
{
    public ObservableRangeCollection<Coffee> Coffee { get; set; }
    public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }


    public CoffeeEquipmentViewModel()
    {

        Title = "Coffee Equipment";

        Coffee = new ObservableRangeCollection<Coffee>();
        CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
        

        LoadMore(); 
    }

    [RelayCommand]
    async Task Favorite(Coffee coffee)
    {
        if (coffee == null)
            return;

        await Application.Current.MainPage.DisplayAlert("Favorite", coffee.Name, "OK");

    }

    [ObservableProperty]
    Coffee previouslySelected;
    [ObservableProperty]
    Coffee selectedCoffee;


    [RelayCommand]
    async Task Selected(object args)
    {
        var coffee = args as Coffee;
        if (coffee == null)
            return;

        SelectedCoffee = null;


        await AppShell.Current.GoToAsync(nameof(AddMyCoffeePage));
        //await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "OK");

    }

    [RelayCommand]
    async Task Refresh()
    {
        IsBusy = true;

        await Task.Delay(2000);

        Coffee.Clear();
        LoadMore();

        IsBusy = false;
    }

    [RelayCommand]
    void LoadMore()
    {
        if (Coffee.Count >= 20)
            return;

        var image = "coffeebag.png";
        Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
        Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
        Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
        Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
        Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });

        CoffeeGroups.Clear();

        CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
        CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster == "Yes Plz")));
    }

    [RelayCommand]
    void DelayLoadMore()
    {
        if (Coffee.Count <= 10)
            return;

        LoadMore();
     }


    [RelayCommand]
    void Clear()
    {
        Coffee.Clear();
        CoffeeGroups.Clear();
    }

}
