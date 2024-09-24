using tracer_backend.Models.DTOs;

namespace tracer_backend.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly DataContextDapper _dapper;
    //create, update, delete, get
    public TaskRepository(DataContextDapper dapper){
        _dapper = dapper;
    }
    public int CreateTask(TaskDTO taskDTO)
    {
        string sql =@"INSERT INTO TracerAppSchema.Tasks 
        ([Title],[Description],
        [TaskStatus],
        [PriorityStatus],
        [DueTo])
        OUTPUT inserted.TaskId
        VALUES (@Title,
        @Description,
        @TaskStatus,
        @PriorityStatus,
        @DueTo);";
        int taskId =_dapper.LoadDataSingleWithParameter<int>(sql,taskDTO);
        return taskId;
    }

    public bool DeleteTask(int taskId)
    {
       string sql = $"DELETE from TracerAppSchema.Tasks WHERE TaskId = {taskId}";
       return _dapper.ExecuteQuery(sql);
    }

    public TaskDTO GetSingleTask(int taskId)
    {
        string  sql = $"SELECT * FROM TracerAppSchema.Tasks WHERE TaskId = {taskId}";
        TaskDTO taskDTO = _dapper.LoadDataSingle<TaskDTO>(sql);
        return taskDTO;
    }

    public IEnumerable<TaskDTO> GetTasks()
    {
        string sql =@"SELECT * FROM TracerAppSchema.Tasks ORDER BY [CreatedAt] DESC";
        IEnumerable<TaskDTO> taskDTOs = _dapper.LoadData<TaskDTO>(sql);
        return taskDTOs;
    }

    public bool UpdateTask(TaskDTO taskDTO, int id)
    {
        taskDTO.TaskId=id;
        string sql = @"UPDATE TracerAppSchema.Tasks
        SET [Title] = @Title,
            [Description] = @Description,
            [DueTo] = @DueTo,
            [PriorityStatus] = @PriorityStatus,
            [UpdatedAt] = @UpdatedAt,
            [TaskStatus] = @TaskStatus
        WHERE TaskId = @TaskId";
        return _dapper.ExecuteQueryWithParameter(sql,taskDTO);
    }

}