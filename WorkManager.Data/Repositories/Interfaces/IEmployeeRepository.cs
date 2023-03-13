using WorkManager.Data.Entities;

namespace WorkManager.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<List<Employee>> GetTopFiveMostProductiveForMonthAsync();
        Task<List<Employee>> GetTopThreeEmployeesWithMostUnfinishedTasksAsync();
    }
}
