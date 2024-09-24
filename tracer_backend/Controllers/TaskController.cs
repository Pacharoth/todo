using System.ComponentModel.DataAnnotations;
using System.Net;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using tracer_backend.Models.Request;
using tracer_backend.Services;

namespace tracer_backend.Controllers;
[ApiController]
[Route("[controller]")]
public class TaskController:ControllerBase
{
  private readonly ITaskService _taskService;

  public TaskController(ITaskService taskService){
      _taskService = taskService;
  }
  [HttpGet("",Name ="GetTasks")]
  public IActionResult GetTasks(){
    return Ok(new {data=_taskService.GetTasks()});
  }
  [HttpGet("{id}",Name ="GetTask")]
  public IActionResult GetTask(int id){
    return Ok(new {data = _taskService.GetTask(id)});
  }
  [HttpPost("",Name ="CreateTask")]
  public IActionResult CreateTask(TaskCreateRequest taskCreateRequest){
    // check validate for the model state
    if(!ModelState.IsValid) return BadRequest(ModelState);
    return CreatedAtAction(nameof(CreateTask),new {data=_taskService.CreateTask(taskCreateRequest)});
  }
  [HttpPut("{id}",Name ="UpdateTask")]
  public IActionResult UpdateTask(int id,TaskUpdateRequest taskUpdateRequest){
    if(!ModelState.IsValid) return BadRequest(ModelState);
    var data = _taskService.UpdateTask(taskUpdateRequest,id);
    if(data==null){
        throw new Exception("Failed to Update Task");
    }
    return Ok(new{data});
  }
  [HttpDelete("{id}",Name ="DeleteTask")]
  public IActionResult DeleteTask(int id){
    bool status=_taskService.DeleteTask(id);
    return Ok(new {status,data=status? "Delete Task successfully":"Delete Task failed"});
  }
}