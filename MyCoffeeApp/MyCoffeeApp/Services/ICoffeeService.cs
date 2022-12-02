using MyCoffeeApp.Shared.Models;

namespace MyCoffeeApp.Services;

public interface ICoffeeService
{
    Task AddCoffee(string name, string roaster);
    Task<IEnumerable<Coffee>> GetCoffee();
    Task<Coffee> GetCoffee(int id);
    Task RemoveCoffee(int id);
}