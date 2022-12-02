namespace MyCoffeeApp.ViewModels;

public partial class ImageCacheViewModel : ViewModelBase
{
    [ObservableProperty]
    UriImageSource image;

    public ImageCacheViewModel()
    {
        Image = new UriImageSource
        {
            Uri = new Uri("https://images.wsdot.wa.gov/sw/005vc00032.jpg"),
            CachingEnabled = true,
            CacheValidity = TimeSpan.FromMinutes(1)
        };

    }

    [RelayCommand]
    void Refresh()
    {
        Image = new UriImageSource
        {
            Uri = new Uri("https://images.wsdot.wa.gov/sw/005vc00032.jpg"),
            CachingEnabled = true,
            CacheValidity = TimeSpan.FromMinutes(1)
        };
        OnPropertyChanged(nameof(Image));
    }

    [RelayCommand]
    async Task RefreshLong()
    {

        IsBusy = true;
        await Task.Delay(5000);
        IsBusy = false;
    }
}
