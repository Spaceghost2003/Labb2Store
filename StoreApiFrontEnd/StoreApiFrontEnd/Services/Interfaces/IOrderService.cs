using StoreApi.Models;

namespace StoreApiFrontEnd.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
