using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Service;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController(IProductRepository productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts() => await productRepository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null) { return NotFound(); }
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id) { return BadRequest(); }
            await productRepository.UpdateAsync(id, product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null) { return NotFound(); }
            await productRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
