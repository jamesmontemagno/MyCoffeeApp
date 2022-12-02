namespace MyCoffeeApp.Views;
public partial class ImageCachePage : ContentPage
{
    public ImageCachePage(ImageCacheViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}