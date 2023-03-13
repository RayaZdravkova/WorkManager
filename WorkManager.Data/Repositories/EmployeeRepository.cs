using Microsoft.EntityFrameworkCore;
using WorkManager.Data.Entities;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(WorkManagerDBContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetTopFiveMostProductiveForMonthAsync()
        {
            List<int> employeeIds = await context.Tasks
                .Where(t => t.Status == Enums.TaskStatus.Done && t.DateOfCompletion.HasValue 
                && t.DateOfCompletion <= DateTime.Now && t.DateOfCompletion > DateTime.Today.AddMonths(-1))
                .GroupBy(t => t.Assignee.Id).OrderBy(t => t.Count())
                .Take(5).Select(g => g.Key)
                .ToListAsync();

            return await context.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();
        }

        public async Task<List<Employee>> GetTopThreeEmployeesWithMostUnfinishedTasksAsync()
        {
            List<int> employeeIds = await context.Tasks
                .Where(t => t.Status != Enums.TaskStatus.Done)
                .GroupBy(t => t.Assignee.Id).OrderBy(t => t.Count())
                .Take(3).Select(g => g.Key)
                .ToListAsync();

            return await context.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();
        }
    }
}
