using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace MyCoffeeApp.ViewModels
{
    public  class ImageCacheViewModel : ViewModelBase
    {
        public UriImageSource Image { get; set; } =
            new UriImageSource
            {
                Uri = new Uri("https://images.wsdot.wa.gov/sw/005vc00032.jpg"),
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromMinutes(1)
            };

        public Command RefreshCommand { get; }

        public ImageCacheViewModel()
        {
            RefreshCommand = new Command(() =>
            {
                Image = new UriImageSource
                {
                    Uri = new Uri("https://images.wsdot.wa.gov/sw/005vc00032.jpg"),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromMinutes(1)
                };
                OnPropertyChanged(nameof(Image));
            });

            RefreshLongCommand = new AsyncCommand(async () =>
            {
                IsBusy = true;
                await Task.Delay(5000);
                IsBusy = false;
            });

        }

        public AsyncCommand RefreshLongCommand { get; }

    }
}
