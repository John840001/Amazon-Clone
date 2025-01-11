using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders;
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (existingOrder == null)
                return NotFound();
            existingOrder.TotalPrice = order.TotalPrice;
            _context.SaveChanges();
            return Ok(existingOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}/items")]
        public IActionResult GetOrderItems(int id)
        {
            var orderItems = _context.OrderItems.Where(o => o.Id == id);
            return Ok(orderItems);
        }

        [HttpGet("{id}/user")]
        public IActionResult GetOrderUser(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();
            var user = _context.Users.FirstOrDefault(u => u.Id == order.UserId);
            return Ok(user);
        }

        [HttpPost("{id}/items")]
        public IActionResult AddOrderItem(int id, OrderItem orderItem)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
            return Ok(orderItem);
        }

        
    }
}
