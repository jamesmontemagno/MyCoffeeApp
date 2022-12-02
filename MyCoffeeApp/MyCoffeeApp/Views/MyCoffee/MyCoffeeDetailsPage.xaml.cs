using MyCoffeeApp.Services;

namespace MyCoffeeApp.Views;

[QueryProperty(nameof(CoffeeId), nameof(CoffeeId))]
public partial class MyCoffeeDetailsPage : ContentPage
{
    public string CoffeeId { get; set; }
    ICoffeeService coffeeService;
    public MyCoffeeDetailsPage(ICoffeeService coffeeService)
    {
        InitializeComponent();
        this.coffeeService = coffeeService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int.TryParse(CoffeeId, out var result);

        BindingContext = await coffeeService.GetCoffee(result);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}