using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastCoreController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Dying"
    };

    private readonly ILogger<WeatherForecastCoreController> _logger;

    public WeatherForecastCoreController(ILogger<WeatherForecastCoreController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherCoreForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5)
            .Select(
                index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToArray();
    }
}
