namespace MyCoffeeApp.Views;

public partial class CoffeeEquipmentPage : ContentPage
{
    public CoffeeEquipmentPage(CoffeeEquipmentViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var random = new Random();
        var random1 = (int)random.Next(0, 255);
        var random2 = (int)random.Next(0, 255);
        var random3 = (int)random.Next(0, 255);
        App.Current.Resources["WindowBackgroundColor"] = Color.FromRgb(random1, random2, random3);
    }
}