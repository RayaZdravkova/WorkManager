using WorkManager.Data.Entities;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Data.Repositories
{
    public class SprintRepository :BaseRepository<Sprint>, ISprintRepository
    {
        public SprintRepository(WorkManagerDBContext context) : base(context)
        {
        }
    }
}
