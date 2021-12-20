using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CloudNative.CloudEvents;

namespace Subject.Binding.Controllers;

[ApiController]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/subject-binding")]
    public ActionResult<string> getCheckout([FromBody] CloudEvent cloudEvent)
    {
        _logger.LogCritical("POST endpoint executed");
        try
        {
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(cloudEvent.Data.ToString());

            if (weatherForecast != null)
            {
                _logger.LogInformation($"The weather is {weatherForecast.Summary} its {weatherForecast.TemperatureC} !");
            }

            return Ok("message received");
        }
        catch (Exception exception)
        {
            _logger.LogCritical(exception.Message, exception);
            return NotFound();
        }
    }

    [HttpOptions("/subject-binding")]
    public ActionResult Options() 
    {
        _logger.LogCritical("OPTIONS endpoint executed");
        return Ok();
    }

    [HttpGet("/subject-binding")]
    public ActionResult Get()
    {
        _logger.LogCritical("GET endpoint executed");
        return Ok("endpoint ping");
    }
}
