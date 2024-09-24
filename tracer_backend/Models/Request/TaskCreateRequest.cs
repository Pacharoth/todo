using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using tracer_backend.Enums;
namespace tracer_backend.Models.Request;
public class TaskCreateRequest
{
    [Required(ErrorMessage ="Title is required")]
    [StringLength(100,ErrorMessage ="Title maximum 100")]
    public required string Title{get; set;}
    [StringLength(200,ErrorMessage ="Description maximum 200")]
    public string? Description {get; set;}
    public Enums.TaskStatus? TaskStatus {get; set;}
    public Enums.PriorityStatus? PriorityStatus {get; set;}
    public DateTime CreatedAt=DateTime.Now;
    
    public DateTime? UpdatedAt; 
    public DateTime? DueTo{get;set;}
    public TaskCreateRequest(){
        if(TaskStatus==null){
            TaskStatus=Enums.TaskStatus.UNCOMPLETE;
        }
        if(PriorityStatus==null){
            PriorityStatus=Enums.PriorityStatus.LOW;
        }
    }
}