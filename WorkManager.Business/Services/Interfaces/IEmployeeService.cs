using WorkManager.Business.ViewModels.Employee;

namespace WorkManager.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeCreateViewModel> CreateAsync(EmployeeCreateViewModel model);
        Task DeleteAsync(int id);
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel?> GetByIdAsync(int id);
        Task<EmployeeViewModel> UpdateAsync(EmployeeViewModel model);
    }
}