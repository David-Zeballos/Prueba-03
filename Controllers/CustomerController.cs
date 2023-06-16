using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        return await _context.Customers
            .Select(c => new
            {
                c.Name,
                c.Rut,
                TotalSumLastMonth = c.Orders
                    .Where(o => o.Date >= DateTime.Now.AddMonths(-1))
                    .Sum(o => o.Dish.Price),
                Dishes = c.Orders.Select(o => new
                {
                    o.Dish.Id,
                    o.Dish.Name,
                    o.Dish.Price,
                    CreatedAt = o.Date,
                    UpdatedAt = o.Date
                })
            })
            .ToListAsync();
    }
}