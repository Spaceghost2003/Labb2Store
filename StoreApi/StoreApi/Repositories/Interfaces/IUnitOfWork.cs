using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        GenericRepository<User> UserRepository { get; }
        Task SaveAsync();
    }
}
