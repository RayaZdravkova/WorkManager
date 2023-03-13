using AutoMapper;

namespace WorkManager.Business.ViewModels.Sprint
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<SprintCreateViewModel, Data.Entities.Sprint>().ReverseMap();
            CreateMap<SprintViewModel, Data.Entities.Sprint>().ReverseMap();
        }
    }
}
