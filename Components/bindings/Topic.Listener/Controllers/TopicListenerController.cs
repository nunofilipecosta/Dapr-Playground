using Microsoft.AspNetCore.Mvc;
using Dapr;
using System.Text;
using System.Text.Json;
using CloudNative.CloudEvents;

namespace Topic.Listener.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicListenerController : ControllerBase
{
    private readonly ILogger<TopicListenerController> _logger;

    public TopicListenerController(ILogger<TopicListenerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        _logger.LogCritical("TopicListenerController executed");
        return Ok("endpoint ping");
    }

    [HttpPost("/receiver")]
    [Topic("topicpubsub", "listenerweatherforecast")]
    public async Task<IActionResult> Receiver([FromBody] CloudEvent cloudEvent)
    {
        try
        {
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(cloudEvent.Data.ToString());

            if (weatherForecast != null)
            {
                _logger.LogInformation($"The weather is {weatherForecast.Summary} its {weatherForecast.TemperatureC} !");
            }


            await Task.CompletedTask;
            return Ok("message received");
        }
        catch (Exception exception)
        {
            _logger.LogCritical(exception.Message, exception);
            return NotFound();
        }

    }
}
