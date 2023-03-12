using AutoMapper;

namespace WorkManager.Business.ViewModels.Task
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskCreateViewModel, Data.Entities.Task>()
                .ForMember(t => t.Assignee, member => member.MapFrom(tvm => new Data.Entities.Employee { Id = tvm.AssigneeId }));

            CreateMap<Data.Entities.Task, TaskCreateViewModel>()
                .ForMember(tvm => tvm.AssigneeId, member => member.MapFrom(t => t.Assignee.Id));

            CreateMap<TaskViewModel, Data.Entities.Task>()
                .ForMember(t => t.Assignee, member => member.MapFrom(tvm => new Data.Entities.Employee { Id = tvm.AssigneeId }));

            CreateMap<Data.Entities.Task, TaskViewModel>()
                .ForMember(tvm => tvm.AssigneeId, member => member.MapFrom(t => t.Assignee.Id));
        }
    }
}
