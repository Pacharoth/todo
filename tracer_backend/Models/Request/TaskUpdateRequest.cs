using System.ComponentModel.DataAnnotations;
using tracer_backend.Enums;
namespace tracer_backend.Models.Request;
public class TaskUpdateRequest
{
    [StringLength(100,ErrorMessage ="Title maximum 100")]
    public required string Title{get; set;}
    [StringLength(200,ErrorMessage ="Description maximum 200")]
    public string? Description {get; set;}
    public Enums.TaskStatus? TaskStatus {get; set;}=Enums.TaskStatus.UNCOMPLETE;
    public Enums.PriorityStatus? PriorityStatus {get; set;}=Enums.PriorityStatus.LOW;
    public DateTime CreatedAt=DateTime.Now;
    
    public DateTime? UpdatedAt; 
    public DateTime? DueTo {set;get;}
}