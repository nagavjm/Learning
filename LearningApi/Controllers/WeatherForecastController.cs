using Microsoft.AspNetCore.Mvc;

namespace LearningApi.Controllers
{
    // ---------- API LAYER: Weather endpoints (Controller style) ----------
    [ApiController]
    [Route("weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracin1g1", "Chilly", "Cool11", "Mild12", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult GetWeatherForecast()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .ToArray();

            return Ok(forecast);
        }
    }

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
