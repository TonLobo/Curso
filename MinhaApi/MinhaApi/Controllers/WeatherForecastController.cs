using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
	[ApiController]
	[Route("[controller]")]//weatherforecast
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

        [HttpPost("/MeuPost")]
        public string MeuPost()
		{
			return "Algo";
		}

        [HttpPut("/MeuPut")]
		public string MeuPut()
		{
			return "Algo";
		}

		[HttpDelete("/MeuDelete")]
		public string MeuDelete()
		{
			return "Algo";
		}
	}
}
