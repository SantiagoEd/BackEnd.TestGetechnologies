using BackEnd.TestGetechnologies.Data;

namespace BackEnd.TestGetechnologies.Repository
{
    public interface IRepository<TId, TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task<TEntity?> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteListAsync(IEnumerable<TEntity> entitys);
    }
}
