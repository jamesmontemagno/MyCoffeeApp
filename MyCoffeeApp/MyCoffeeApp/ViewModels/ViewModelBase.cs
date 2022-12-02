namespace MyCoffeeApp.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;


    public bool IsNotBusy => !IsBusy;
}
