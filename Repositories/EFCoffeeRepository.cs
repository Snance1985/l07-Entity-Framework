using l07_ef.Migrations;
using l07_ef.Models;

namespace l07_ef.Repositories;

public class EFCoffeeRepository : ICoffeeRepository
{
    private readonly CoffeeDbContext _context;

    public EFCoffeeRepository(CoffeeDbContext context)
    {
        _context = context;
    }

    Coffee ICoffeeRepository.CreateCoffee(Coffee newCoffee)
    {
        _context.Coffee.Add(newCoffee);
        _context.SaveChanges();
        return newCoffee;
    }

    void ICoffeeRepository.DeleteCoffeeById(int coffeeId)
    {
        var coffee = _context.Coffee.Find(coffeeId);
        if (coffee != null)
        {
            _context.Coffee.Remove(coffee);
            _context.SaveChanges();
        }
    }

    IEnumerable<Coffee> ICoffeeRepository.GetAllCoffee()
    {
        return _context.Coffee.ToList();
    }

    Coffee ICoffeeRepository.GetCoffeeById(int coffeeId)
    {
        return _context.Coffee.SingleOrDefault(c => c.CoffeeId == coffeeId);
    }

    Coffee ICoffeeRepository.UpdateCoffee(Coffee newCoffee)
    {
        var originalCoffee = _context.Coffee.Find(newCoffee.CoffeeId);
        if (originalCoffee != null)
        {
            originalCoffee.Name = newCoffee.Name;
            originalCoffee.Description = newCoffee.Description;
            originalCoffee.Price = newCoffee.Price;
            _context.SaveChanges();
        }
        return originalCoffee;
    }
}
