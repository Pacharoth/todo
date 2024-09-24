using AutoMapper;
namespace tracer_backend.AutoMapper;
using tracer_backend.Models.DTOs;
using tracer_backend.Models.Request;

public class TaskUpdateMappingProfile:Profile
{
    public TaskUpdateMappingProfile(){
        CreateMap<TaskUpdateRequest,TaskDTO>().ForMember(
                Task=>Task.UpdatedAt,TaskUpdate=>TaskUpdate.MapFrom(sr=>DateTime.Now)
        )        
        .ForMember(task=>task.PriorityStatus,taskCreate=>taskCreate.MapFrom(sr=>sr.PriorityStatus.ToString()))
        .ForMember(task=>task.TaskStatus,taskCreate=>taskCreate.MapFrom(sr=>sr.TaskStatus.ToString()));

    }
}