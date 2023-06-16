using Microsoft.EntityFrameworkCore;

public class RestaurantContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }

    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relaciones entre entidades
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Dish>()
            .HasMany(d => d.Orders)
            .WithOne(o => o.Dish)
            .HasForeignKey(o => o.DishId);
    }
}
