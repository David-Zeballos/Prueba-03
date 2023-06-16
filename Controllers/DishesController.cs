using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class DishesController : ControllerBase
{
    private readonly RestaurantContext _context;

    public DishesController(RestaurantContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetDishes()
    {
        return await _context.Dishes
            .Select(d => new
            {
                d.Name,
                d.Price,
                Clients = d.Orders.Select(o => new
                {
                    o.Customer.Id,
                    o.Customer.Name,
                    o.Customer.Faculty,
                    CreatedAt = o.Date,
                    UpdatedAt = o.Date
                })
            })
            .ToListAsync();
    }
}