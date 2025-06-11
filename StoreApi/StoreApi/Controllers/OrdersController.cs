using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Service;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Repositories.Interfaces;


namespace StoreApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController(IOrderRepository orderRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrders() => await orderRepository.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null) { return NotFound(); }
            return order;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            await orderRepository.AddAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.Id) { return BadRequest(); }
            await orderRepository.UpdateAsync(id, order);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null) { return NotFound(); }
            await orderRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
