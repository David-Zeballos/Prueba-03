// Context/SeedData.cs
using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(RestaurantContext context)
    {
        // Look for any customers, dishes or orders
        if (context.Customers.Any() || context.Dishes.Any() || context.Orders.Any())
        {
            return;   // DB has been seeded
        }

        // Create customers
        var customers = new[]
        {
            new Customer { Name = "Patience Dibbert", Rut = "111-222-333" },
            new Customer { Name = "Dr. Deja Larson PhD", Rut = "444-555-666" },
            new Customer { Name = "Dr. Orval Cassin", Rut = "777-888-999" },
            new Customer { Name = "John Doe", Rut = "123-456-789" },
            new Customer { Name = "Jane Doe", Rut = "987-654-321" },
            // Add more customers as needed
        };
        context.Customers.AddRange(customers);

        // Create dishes
        var dishes = new[]
        {
            new Dish { Name = "Dagmar Runolfsson", Price = 84 },
            new Dish { Name = "Daniella Feest", Price = 68 },
            new Dish { Name = "Boris Simonis", Price = 56 },
            new Dish { Name = "Spaghetti", Price = 12 },
            new Dish { Name = "Pizza", Price = 15 },
            // Add more dishes as needed
        };
        context.Dishes.AddRange(dishes);

        // Create orders
        var orders = new[]
        {
            new Order { Customer = customers[0], Dish = dishes[0], Date = DateTime.Now.AddMonths(-1) },
            new Order { Customer = customers[0], Dish = dishes[1], Date = DateTime.Now.AddMonths(-1) },
            new Order { Customer = customers[1], Dish = dishes[0], Date = DateTime.Now.AddMonths(-2) },
            new Order { Customer = customers[1], Dish = dishes[2], Date = DateTime.Now.AddMonths(-2) },
            new Order { Customer = customers[2], Dish = dishes[1], Date = DateTime.Now.AddMonths(-3) },
            new Order { Customer = customers[2], Dish = dishes[2], Date = DateTime.Now.AddMonths(-3) },
            // Add more orders as needed
        };
        context.Orders.AddRange(orders);

        context.SaveChanges();
    }
}
