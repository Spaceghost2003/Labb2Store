using StoreApi.Models;

namespace StoreApiFrontEnd.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User user { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
