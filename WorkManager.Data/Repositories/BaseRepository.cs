using Microsoft.EntityFrameworkCore;
using WorkManager.Data.Entities;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly WorkManagerDBContext context;
        public BaseRepository(WorkManagerDBContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var entityEntry = context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            T? foundEntity = await GetByIdAsync(entity.Id);

            if (foundEntity == null)
            {
                throw new ArgumentException("Item was not found!");
            }

            context.Entry(foundEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            T? entityForDeletion = await GetByIdAsync(id);

            if (entityForDeletion == null)
            {
                throw new ArgumentException("Item was not found!");
            }

            context.Set<T>().Remove(entityForDeletion);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}
