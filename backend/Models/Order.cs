using System.Collections.Generic;

namespace backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItem>? Items { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
