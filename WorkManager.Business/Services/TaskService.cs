using AutoMapper;
using WorkManager.Business.Services.Interfaces;
using WorkManager.Business.ViewModels.Task;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskCreateViewModel> CreateAsync(TaskCreateViewModel model)
        {
            Data.Entities.Task entity = _mapper.Map<Data.Entities.Task>(model);

            Data.Entities.Task createdTask = await _taskRepository.CreateAsync(entity);

            return _mapper.Map<TaskCreateViewModel>(createdTask);
        }

        public async Task<TaskViewModel> UpdateAsync(TaskViewModel model)
        {
            Data.Entities.Task entity = _mapper.Map<Data.Entities.Task>(model);

            Data.Entities.Task updatedTask = await _taskRepository.UpdateAsync(entity);

            return _mapper.Map<TaskViewModel>(updatedTask);
        }

        public async Task DeleteAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<TaskViewModel?> GetByIdAsync(int id)
        {
            Data.Entities.Task? task = await _taskRepository.GetByIdAsync(id);

            return _mapper.Map<TaskViewModel?>(task);
        }

        public async Task<List<TaskViewModel>> GetAllAsync()
        {
            List<Data.Entities.Task> tasks = await _taskRepository.GetAllAsync();

            return _mapper.Map<List<TaskViewModel>>(tasks);
        }
    }
}
