using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Data.Repositories
{
    public class TaskRepository : BaseRepository<Entities.Task>, ITaskRepository
    {
        public TaskRepository(WorkManagerDBContext context) : base(context)
        {
        }
    }
}
