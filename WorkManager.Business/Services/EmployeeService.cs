using AutoMapper;
using System.ComponentModel;
using WorkManager.Business.Services.Interfaces;
using WorkManager.Business.ViewModels.Employee;
using WorkManager.Data.Entities;
using WorkManager.Data.Repositories.Interfaces;

namespace WorkManager.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeCreateViewModel> CreateAsync(EmployeeCreateViewModel model)
        {
            Employee entity = _mapper.Map<Employee>(model);

            Employee createdEmployee = await _employeeRepository.CreateAsync(entity);

            return _mapper.Map<EmployeeCreateViewModel>(createdEmployee);
        }

        public async Task<EmployeeViewModel> UpdateAsync(EmployeeViewModel model)
        {
            Employee entity = _mapper.Map<Employee>(model);

            Employee updatedEmployee = await _employeeRepository.UpdateAsync(entity);

            return _mapper.Map<EmployeeViewModel>(updatedEmployee);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<EmployeeViewModel?> GetByIdAsync(int id)
        {
            Employee? employee = await _employeeRepository.GetByIdAsync(id);

            return _mapper.Map<EmployeeViewModel?>(employee);
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();

            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }

        public async Task<List<EmployeeViewModel>> GetTopFiveMostProductiveForMonthAsync()
        {
            var employees = await _employeeRepository.GetTopFiveMostProductiveForMonthAsync();

            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }

        public async Task<List<EmployeeViewModel>> GetTopThreeEmployeesWithMostUnfinishedTasksAsync()
        {
            var employees = await _employeeRepository.GetTopThreeEmployeesWithMostUnfinishedTasksAsync();

            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }

    }
}
