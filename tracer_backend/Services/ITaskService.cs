using tracer_backend.Models.DTOs;
using tracer_backend.Models.Request;

namespace tracer_backend.Services;
public interface ITaskService{
    TaskDTO CreateTask(TaskCreateRequest taskRequest);
    IEnumerable<TaskDTO> GetTasks();
    bool DeleteTask(int id);
    TaskDTO? GetTask(int id);
    TaskDTO? UpdateTask(TaskUpdateRequest taskUpdateRequest,int id);
}