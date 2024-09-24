using tracer_backend.Models.DTOs;

namespace tracer_backend.Repositories;
public interface ITaskRepository{
    // create update, delete, get
    int CreateTask(TaskDTO taskDTO);
    bool UpdateTask(TaskDTO taskDTO, int id);
    IEnumerable<TaskDTO> GetTasks();
    TaskDTO? GetSingleTask(int taskId);
    bool DeleteTask(int taskId);
}