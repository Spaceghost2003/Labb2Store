using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Service;

namespace StoreApi.Repositories
{
    public class ProductRepository(AppDbContext _context) : GenericRepository<Product>(_context), IProductRepository
    {

    }
}
