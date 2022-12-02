namespace MyCoffeeApp.Views;
public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //var loggedin = true;
        //if(loggedin)
            await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(CoffeeEquipmentPage)}");
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");

    }
}