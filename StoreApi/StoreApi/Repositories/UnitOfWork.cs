using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Service;

namespace StoreApi.Repositories
{
    public class UnitOfWork
    {
        private AppDbContext _context;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Order> _orderRepository;
        private GenericRepository<Product> _productRepository;
        public UnitOfWork(DbContextOptions<AppDbContext> options)
        {
            _context = new AppDbContext(options);
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }
        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                {
                    this._orderRepository = new GenericRepository<Order>(_context);
                }
                return _orderRepository;
            }
        }
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_context);
                }
                return _productRepository;
            }
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
    }
}
