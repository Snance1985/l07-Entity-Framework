using l07_ef.Models;

namespace l07_ef.Repositories;

public interface ICoffeeRepository
{
    IEnumerable<Coffee> GetAllCoffee();
    Coffee GetCoffeeById(int coffeeId);
    Coffee CreateCoffee(Coffee newCoffee);
    Coffee UpdateCoffee(Coffee newCoffee);
    void DeleteCoffeeById(int coffeeId);
}