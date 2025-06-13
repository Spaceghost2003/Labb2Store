using StoreApi.Models;
using StoreApiFrontEnd.Services.Interfaces;
using System.Net.Http;

namespace StoreApiFrontEnd.Services
{
    public class OrderService:IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
          
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7020/api/orders", order);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Order>();
            }
            return null;
        }
    }
}
