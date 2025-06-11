using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Service;

namespace StoreApi.Repositories
{
    public class UserRepository(AppDbContext _context) : GenericRepository<User>(_context), IUserRepository
    {
      
        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
       
    

