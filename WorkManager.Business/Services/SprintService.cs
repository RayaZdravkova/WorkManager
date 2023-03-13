using AutoMapper;
using WorkManager.Business.Services.Interfaces;
using WorkManager.Business.ViewModels.Sprint;
using WorkManager.Data.Entities;
using WorkManager.Data.Repositories;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Business.Services
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;
        public SprintService(ISprintRepository sprintRepository, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _mapper = mapper;
        }

        public async Task<SprintCreateViewModel> CreateAsync(SprintCreateViewModel model)
        {
            if (model.StartDate > model.EndDate)
            {
                throw new ArgumentException("Start date can not be after end date!");
            }

            Sprint entity = _mapper.Map<Sprint>(model);

            Sprint createdSprint = await _sprintRepository.CreateAsync(entity);

            return _mapper.Map<SprintCreateViewModel>(createdSprint);
        }

        public async Task<SprintViewModel> UpdateAsync(SprintViewModel model)
        {
            if (model.StartDate > model.EndDate)
            {
                throw new ArgumentException("Start date can not be after end date!");
            }

            Sprint entity = _mapper.Map<Sprint>(model);

            Sprint updatedSprint = await _sprintRepository.UpdateAsync(entity);

            return _mapper.Map<SprintViewModel>(updatedSprint);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            await _sprintRepository.DeleteAsync(id);
        }

        public async Task<SprintViewModel?> GetByIdAsync(int id)
        {
            Sprint? sprint = await _sprintRepository.GetByIdAsync(id);

            return _mapper.Map<SprintViewModel?>(sprint);
        }

        public async Task<List<SprintViewModel>> GetAllAsync()
        {
            List<Sprint> sprints = await _sprintRepository.GetAllAsync();

            return _mapper.Map<List<SprintViewModel>>(sprints);
        }

    }
}
