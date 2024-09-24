using AutoMapper;
using tracer_backend.Models.DTOs;
using tracer_backend.Models.Request;
using tracer_backend.Repositories;
namespace tracer_backend.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    // use to auto map to TaskDTO
    private readonly IMapper _mapper;
    
    public TaskService(ITaskRepository taskRepository,IMapper mapper)
    {
        _taskRepository=taskRepository;
        _mapper=mapper;
    }

    public TaskDTO CreateTask(TaskCreateRequest taskRequest)
    {
       TaskDTO taskDTO = _mapper.Map<TaskDTO>(taskRequest);
       int taskId= _taskRepository.CreateTask(taskDTO);
       return _taskRepository.GetSingleTask(taskId)!;
    }

    public IEnumerable<TaskDTO> GetTasks()
    {   
        // create filter 
        return _taskRepository.GetTasks();
    }

    public TaskDTO? UpdateTask(TaskUpdateRequest taskUpdateRequest, int id)
    {
        TaskDTO taskDTO = _mapper.Map<TaskDTO>(taskUpdateRequest);
        taskDTO.TaskId=id;
        if(!_taskRepository.UpdateTask(taskDTO,id)){
            return null;
        }
        return taskDTO;
    }
    public bool DeleteTask(int id){
        return _taskRepository.DeleteTask(id);
    }

    public TaskDTO? GetTask(int id)
    {
        return _taskRepository.GetSingleTask(id);
    }
}