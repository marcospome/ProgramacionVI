using Microsoft.AspNetCore.Mvc;

namespace Clase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Congelado", "Muy frío", "Frío", "Fresco", "Neutro", "Cálido", "Pesado", "Caluroso", "Sofocante", "Abrasador"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => { 
                var temperatureC = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temperatureC,
                    Summary = GetSummaryForTemperature(temperatureC)
                };
                })
                .ToArray();
        }
        private string GetSummaryForTemperature(int temperatureC)
        {
            return temperatureC switch
            {
                <= 0 => "Congelado",
                > 0 and <= 10 => "Muy frío",
                > 10 and <= 15 => "Frío",
                > 15 and <= 20 => "Fresco",
                > 20 and <= 25 => "Neutro",
                > 25 and <= 30 => "Cálido",
                > 30 and <= 35 => "Pesado",
                > 35 and <= 40 => "Caluroso",
                > 40 and <= 45 => "Sofocante",
                > 45 => "Abrasador"
            };
        }
    }
}
