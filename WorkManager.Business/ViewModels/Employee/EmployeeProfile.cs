using AutoMapper;
using WorkManager.Data.Entities;

namespace WorkManager.Business.ViewModels.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeCreateViewModel, Data.Entities.Employee>().ReverseMap();
            CreateMap<EmployeeViewModel, Data.Entities.Employee>().ReverseMap();
        }
    }
}
