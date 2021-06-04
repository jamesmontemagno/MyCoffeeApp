using MonkeyCache.FileStore;
using MyCoffeeApp.Helpers;
using MyCoffeeApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyCoffeeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //TheTheme.SetTheme();

            Barrel.ApplicationId = AppInfo.PackageName;

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
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
}
