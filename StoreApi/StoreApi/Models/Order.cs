namespace StoreApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId {  get; set; }

        public User user { get; set; }

        public List<OrderItem>? OrderItems { get; set; }

       
    }
}
