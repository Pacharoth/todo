using AutoMapper;
using tracer_backend.Models.DTOs;
using tracer_backend.Models.Request;

namespace tracer_backend.AutoMapper;
public class TaskCreateMappingProfile:Profile{
    public TaskCreateMappingProfile(){
        CreateMap<TaskCreateRequest,TaskDTO>()
        .ForMember(task=>task.PriorityStatus,taskCreate=>taskCreate.MapFrom(sr=>sr.PriorityStatus.ToString()))
        .ForMember(task=>task.TaskStatus,taskCreate=>taskCreate.MapFrom(sr=>sr.TaskStatus.ToString()));
    }
}