using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}
