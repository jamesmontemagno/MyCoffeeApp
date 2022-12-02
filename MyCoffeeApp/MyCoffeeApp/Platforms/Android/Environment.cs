using Android.OS;
using AndroidX.Core.View;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using MyCoffeeApp.Helpers;

namespace MyCoffeeApp.Platforms;

public class Environment : IEnvironment
{
    public async void SetStatusBarColor(Microsoft.Maui.Graphics.Color color, bool darkStatusBarTint)
    {
        if (Build.VERSION.SdkInt < global::Android.OS.BuildVersionCodes.Lollipop)
            return;

        var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
        var window = activity.Window;

        //this may not be necessary(but may be fore older than M)
        window.AddFlags(global::Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
        window.ClearFlags(global::Android.Views.WindowManagerFlags.TranslucentStatus);


        if (Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.M)
        {
            await Task.Delay(50);
            WindowCompat.GetInsetsController(window, window.DecorView).AppearanceLightStatusBars = darkStatusBarTint;
        }


        window.SetStatusBarColor(color.ToAndroid());
    }
}
