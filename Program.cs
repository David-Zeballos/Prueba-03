using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Build Configuration
var Configuration = builder.Configuration;

// Set up services
builder.Services.AddControllers();
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RestaurantContext>();
        SeedData.Initialize(context); // Agregar datos de prueba
    }
    catch (Exception ex)
    {
        // Manejo de errores
        Console.WriteLine("Error al aplicar migraciones o agregar datos de prueba: " + ex.Message);
    }
}

app.Run();
