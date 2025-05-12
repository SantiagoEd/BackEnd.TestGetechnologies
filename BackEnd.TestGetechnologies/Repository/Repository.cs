using BackEnd.TestGetechnologies.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.TestGetechnologies.Repository
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class
    {
        protected readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task<IEnumerable<TEntity?>> GetAllAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudieron recuperar las entidades: {ex.Message}");
            }
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id)
        {
            try
            {
                return await _context.FindAsync<TEntity>(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo recuperar la entidad con id {id}: {ex.Message}");
            }
        }

        public virtual async Task<TEntity?> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "La entidad no debe ser null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al guardar la entidad: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteListAsync(IEnumerable<TEntity> entitys)
        {
            _context.RemoveRange(entitys);
            await _context.SaveChangesAsync();
        }
    }
}
