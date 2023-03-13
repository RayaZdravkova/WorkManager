using Microsoft.EntityFrameworkCore;
using WorkManager.Data.Entities;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Data.Repositories
{
    public class TaskRepository : BaseRepository<Entities.Task>, ITaskRepository
    {
        public TaskRepository(WorkManagerDBContext context) : base(context)
        {
        }

        public override async Task<Entities.Task?> GetByIdAsync(int id)
        {
            return await context.Tasks
                .Include(t => t.Assignee)
                .FirstOrDefaultAsync(t => t.Id == id);
        
        }

        public override async Task<Entities.Task> UpdateAsync(Entities.Task entity)
        {
            Entities.Task? foundEntity = await GetByIdAsync(entity.Id);

            if (foundEntity == null)
            {
                throw new ArgumentException("Entity was not found!");
            }

            Employee? assignee = context.Employees.Find(entity.Assignee.Id);

            if (assignee == null)
            {
                throw new ArgumentException("Invalid assignee!");
            }

            foundEntity.Assignee = assignee;

            if (foundEntity.DateOfCompletion is null && entity.Status == Enums.TaskStatus.Done)
            {
                entity.DateOfCompletion = DateTime.Now;
            }

            context.Entry(foundEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
