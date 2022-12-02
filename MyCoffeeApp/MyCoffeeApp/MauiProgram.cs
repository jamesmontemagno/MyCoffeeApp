using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MyCoffeeApp.Services;
using Microsoft.Extensions.DependencyInjection;
using MyCoffeeApp.Views;

namespace MyCoffeeApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("fa-brands-400.ttf", "FAB");
                fonts.AddFont("fa-regular-400.ttf", "FAR");
                fonts.AddFont("fa-solid-900.ttf", "FAS");
            })
            .UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
        builder.Services.AddSingleton<IEnvironment, MyCoffeeApp.Platforms.Environment>();
        builder.Services.AddSingleton<IToast, MyCoffeeApp.Platforms.Toaster>();

        builder.Services.AddTransient<InternetCoffeeViewModel>();
        builder.Services.AddTransient<AddMyCoffeeViewModel>();
        builder.Services.AddTransient<MyCoffeeViewModel>();
        builder.Services.AddTransient<CoffeeEquipmentViewModel>();
        builder.Services.AddTransient<ImageCacheViewModel>();


        builder.Services.AddTransient<InternetCoffeePage>();
        builder.Services.AddTransient<AddMyCoffeePage>();
        builder.Services.AddTransient<MyCoffeeDetailsPage>();
        builder.Services.AddTransient<MyStoredCoffeePage>();
        builder.Services.AddTransient<AnimationPage>();
        builder.Services.AddTransient<CoffeeEquipmentPage>();
        builder.Services.AddTransient<CoffeeEquipmentCVPage>();
        builder.Services.AddTransient<ImageCachePage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<SettingsPage>();

        return builder.Build();
    }
}