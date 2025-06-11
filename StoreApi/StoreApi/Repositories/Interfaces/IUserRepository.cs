using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByEmail(string email);
    }
}
