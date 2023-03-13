using WorkManager.Business.ViewModels.Sprint;

namespace WorkManager.Business.Services.Interfaces
{
    public interface ISprintService
    {
        Task<SprintCreateViewModel> CreateAsync(SprintCreateViewModel model);
        Task DeleteAsync(int id);
        Task<List<SprintViewModel>> GetAllAsync();
        Task<SprintViewModel?> GetByIdAsync(int id);
        Task<SprintViewModel> UpdateAsync(SprintViewModel model);
    }
}