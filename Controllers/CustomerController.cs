using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly RestaurantContext _context;

    public CustomersController(RestaurantContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetCustomers()
    {
        var customers = await _context.Customers
            .Select(c => new
            {
                c.Name,
                c.Rut,
                Dishes = c.Orders.Select(o => new
                {
                    o.Dish.Id,
                    o.Dish.Name,
                    o.Dish.Price,
                    CreatedAt = o.Date,
                    UpdatedAt = o.Date
                }).ToList()
            })
            .ToListAsync();

        var customersWithSum = customers.Select(c => new
        {
            c.Name,
            c.Rut,
            TotalSumLastMonth = c.Dishes
                .Where(d => d.CreatedAt >= DateTime.Now.AddMonths(-1))
                .Sum(d => d.Price),
            Dishes = c.Dishes
        });

        return Ok(customersWithSum);
    }
}
