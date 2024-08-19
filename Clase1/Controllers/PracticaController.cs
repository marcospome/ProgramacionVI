using Microsoft.AspNetCore.Mvc;

namespace MenuExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Congelado", "Muy fr�o", "Fr�o", "Fresco", "Neutro", "C�lido", "Pesado", "Caluroso", "Sofocante", "Abrasador"
        };

        private readonly ILogger<PracticaController> _logger;

        public PracticaController(ILogger<PracticaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<ModelPractica> Get()
        {
            return Enumerable.Range(1, 5).Select(index => { 
                var temperatureC = Random.Shared.Next(-20, 55);
                return new ModelPractica
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
                > 0 and <= 10 => "Muy fr�o",
                > 10 and <= 15 => "Fr�o",
                > 15 and <= 20 => "Fresco",
                > 20 and <= 25 => "Neutro",
                > 25 and <= 30 => "C�lido",
                > 30 and <= 35 => "Pesado",
                > 35 and <= 40 => "Caluroso",
                > 40 and <= 45 => "Sofocante",
                > 45 => "Abrasador"
            };
        }
    }
}
