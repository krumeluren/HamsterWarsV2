using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILoggerManager logger;

    public WeatherForecastController(ILoggerManager logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {

            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }
    public IEnumerable<string> Test()

    {
        logger.LogInfo("Here is info message from the controller.");
        logger.LogDebug("Here is debug message from the controller.");
        logger.LogWarn("Here is warn message from the controller.");
        logger.LogError("Here is error message from the controller.");
        return new string[] { "value1", "value2" };

    }
}