using WorkManager.Business.ViewModels.Task;

namespace WorkManager.Business.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskCreateViewModel> CreateAsync(TaskCreateViewModel model);
        Task DeleteAsync(int id);
        Task<List<TaskViewModel>> GetAllAsync();
        Task<TaskViewModel?> GetByIdAsync(int id);
        Task<TaskViewModel> UpdateAsync(TaskViewModel model);
    }
}