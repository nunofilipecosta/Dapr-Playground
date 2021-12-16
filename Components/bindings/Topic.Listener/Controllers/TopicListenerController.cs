using Microsoft.AspNetCore.Mvc;
using Dapr;
using System.Text;
using System.Text.Json;

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

    [HttpPost("/receiver")]
    [Topic("TopicPubSub", "TopicName")]
    public async Task<IActionResult> Receiver([FromBody] byte[] cloudEvent)
    {
        try
        {
            _logger.LogInformation(Encoding.UTF8.GetString(cloudEvent));

            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(cloudEvent);

            _logger.LogInformation($"The weather is {weatherForecast.Summary} !");

            await Task.CompletedTask;
            return Ok();
        }
        catch (Exception exception)
        {
            _logger.LogCritical(exception.Message, exception);
            return NotFound();
        }

    }
}
