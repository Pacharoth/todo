using tracer_backend.Enums;

namespace tracer_backend.Models.DTOs;

public class TaskDTO
{
    public int TaskId { get; set; }
    public required string Title { get; set; }
    public  string? Description { get; set; }
    public DateTime CreatedAt {get;set;}
    public DateTime UpdatedAt {get;set;}
    public string TaskStatus{get;set;}=Enums.TaskStatus.UNCOMPLETE.ToString();
    public string PriorityStatus{get;set;}=Enums.PriorityStatus.LOW.ToString();
    public DateTime? DueTo{get;set;}
}