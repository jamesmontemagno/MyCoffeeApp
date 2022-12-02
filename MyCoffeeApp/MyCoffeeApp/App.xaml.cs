using MonkeyCache.FileStore;
using MyCoffeeApp.Helpers;

namespace MyCoffeeApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Barrel.ApplicationId = AppInfo.PackageName;
        MainPage = new AppShell();
    }

    protected override void OnSleep()
    {
        TheTheme.SetTheme();
        RequestedThemeChanged -= App_RequestedThemeChanged;
    }

    protected override void OnResume()
    {
        TheTheme.SetTheme();
        RequestedThemeChanged += App_RequestedThemeChanged;
    }

    private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            TheTheme.SetTheme();
        });
    }
}