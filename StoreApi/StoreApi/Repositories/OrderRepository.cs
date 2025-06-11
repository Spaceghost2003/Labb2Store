using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Service;

namespace StoreApi.Repositories
{
    public class OrderRepository(AppDbContext _context) : GenericRepository<Order>(_context), IOrderRepository
    {
       public async Task AddItemAsync(OrderItem orderItem, int userId)
        {
                        
        }
    }
}
