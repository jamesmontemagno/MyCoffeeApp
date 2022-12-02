using Android.Widget;
using MyCoffeeApp.Services;

namespace MyCoffeeApp.Platforms;

public class Toaster : IToast
{
    public void MakeToast(string message)
    {
        Toast.MakeText(Microsoft.Maui.ApplicationModel.Platform.AppContext, message, ToastLength.Long).Show();
    }
}
