namespace StoreApi.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(int id,TEntity entity);
        Task DeleteAsync(int id);
    }
 
}
