using MyCoffeeApp.ViewModels;

namespace MyCoffeeApp.Views;
public partial class CoffeeEquipmentCVPage : ContentPage
{
    public CoffeeEquipmentCVPage(CoffeeEquipmentViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}