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


    public IEnumerable<string> Test()

    {
        logger.LogInfo("Here is info message from the controller.");
        logger.LogDebug("Here is debug message from the controller.");
        logger.LogWarn("Here is warn message from the controller.");
        logger.LogError("Here is error message from the controller.");
        return new string[] { "value1", "value2" };

    }
}