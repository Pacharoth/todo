using Microsoft.AspNetCore.Mvc;

namespace tracer_backend.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController:ControllerBase
{
    private readonly string[] _summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    [HttpGet("/weatherforecast",Name ="GetWeatherForecast")]
    public IEnumerable<WeatherForecast> GetFiveDayForecasts(){
           var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            _summaries[Random.Shared.Next(_summaries.Length)]
        ))
        .ToArray();
        return forecast;
    }

}
