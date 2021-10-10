using MonkeyCache.FileStore;
using MyCoffeeApp.Shared.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyCoffeeApp.Services
{
    public static class InternetCoffeeService
    {
        //static string Baseurl = DeviceInfo.Platform == DevicePlatform.Android ?
        //                                    "http://10.0.2.2:5000" : "http://localhost:5000";

        static string BaseUrl = "YOUR URL";

        static HttpClient client;

        static InternetCoffeeService()
        {
            try
            {
                client = new HttpClient
                {
                    BaseAddress = new Uri(BaseUrl)
                };
            }
            catch
            {

            }
        }

        public static Task<IEnumerable<Coffee>> GetCoffee() =>
            GetAsync<IEnumerable<Coffee>>("api/Coffee", "getcoffee");

        static async Task<T> GetAsync<T>(string url, string key, int mins = 1, bool forceRefresh = false)
        {
            var json = string.Empty;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                json = Barrel.Current.Get<string>(key);
            else if (!forceRefresh && !Barrel.Current.IsExpired(key))
                json = Barrel.Current.Get<string>(key);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await client.GetStringAsync(url);

                    Barrel.Current.Add(key, json, TimeSpan.FromMinutes(mins));
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get information from server {ex}");
                throw ex;
            }
        }

        static Random random = new Random();
        public static async Task AddCoffee(string name, string roaster)
        {
            var image = "coffeebag.png";
            var coffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image,
                Id = random.Next(0, 10000)
            };

            var json = JsonConvert.SerializeObject(coffee);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Coffee", content);

            if(!response.IsSuccessStatusCode)
            {

            }
        }

        public static async Task RemoveCoffee(int id)
        {
            var response = await client.DeleteAsync($"api/Coffee/{id}");
            if (!response.IsSuccessStatusCode)
            {

            }
        }

        
    }
}
