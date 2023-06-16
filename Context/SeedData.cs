using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(RestaurantContext context)
    {
        // Verificar si ya existen registros en la base de datos
        if (context.Customers.Any() || context.Dishes.Any() || context.Orders.Any())
        {
            return; // La base de datos ya ha sido inicializada
        }

        // Crear objetos Customer
        var customers = new[]
        {
            new Customer { Name = "John Doe", Rut = "12345678-9", Faculty = "Computer Science" },
            new Customer { Name = "Jane Smith", Rut = "98765432-1", Faculty = "Engineering" },
            new Customer { Name = "Michael Johnson", Rut = "45678901-2", Faculty = "Business Administration" },
            new Customer { Name = "Emily Davis", Rut = "21098765-4", Faculty = "Psychology" },
            new Customer { Name = "David Wilson", Rut = "56789012-3", Faculty = "Education" },
            new Customer { Name = "Sophia Thompson", Rut = "10293847-5", Faculty = "Art" },
            new Customer { Name = "James Garcia", Rut = "87654321-0", Faculty = "Medicine" },
            new Customer { Name = "Olivia Martinez", Rut = "13579246-8", Faculty = "Law" },
            new Customer { Name = "Benjamin Robinson", Rut = "24681357-9", Faculty = "Science" },
            new Customer { Name = "Emma Lewis", Rut = "98765432-1", Faculty = "Architecture" }
        };
        context.Customers.AddRange(customers);
        context.SaveChanges();

        // Crear objetos Dish
        var dishes = new[]
        {
            new Dish { Name = "Spaghetti Bolognese", Price = 15.99m },
            new Dish { Name = "Grilled Salmon", Price = 22.50m },
            new Dish { Name = "Chicken Alfredo", Price = 18.75m },
            new Dish { Name = "Beef Steak", Price = 24.99m },
            new Dish { Name = "Margherita Pizza", Price = 12.99m },
            new Dish { Name = "Caesar Salad", Price = 10.50m },
            new Dish { Name = "Sushi Combo", Price = 28.50m },
            new Dish { Name = "Vegetable Stir-Fry", Price = 15.99m },
            new Dish { Name = "Cheeseburger", Price = 13.75m },
            new Dish { Name = "Chocolate Brownie", Price = 8.99m }
        };
        context.Dishes.AddRange(dishes);
        context.SaveChanges();

        // Crear objetos Order
        var random = new Random();
        var orders = new Order[10];
        for (int i = 0; i < 10; i++)
        {
            orders[i] = new Order
            {
                Date = DateTime.Now.AddDays(-i),
                CustomerId = customers[random.Next(customers.Length)].Id,
                DishId = dishes[random.Next(dishes.Length)].Id
            };
        }
        context.Orders.AddRange(orders);
        context.SaveChanges();
    }
}