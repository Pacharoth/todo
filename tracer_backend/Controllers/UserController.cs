using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace tracer_backend;
[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration configuration){
        // Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));
        _dapper = new DataContextDapper(configuration);
    }
    [HttpGet("/testconnection",Name ="TestConnection")]
    public DateTime TestConnection(){
        return _dapper.LoadDataSingle<DateTime>("Select GETDATE()");
    }
    [HttpGet("GetUsers/{testValue}")]
    public string[] GetUser(string testValue){
        // testValue can be a request query or parameter 
        string[] responseArray = new string[]{
            "test1",
            "test2",
            testValue,
        };
        return responseArray;
    }
    [HttpPost("/register",Name ="RegisterUser")]
    public IActionResult RegisterUser(){
        return Ok();
    }

}