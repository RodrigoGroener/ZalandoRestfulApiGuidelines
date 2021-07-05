using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ZalandoRestfulApiGuidelinesWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiConventionType(typeof(ApiConventions))]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Search([FromQuery(Name = "q")] string query,
            //MUST use snake_case (never camelCase) for query parameters https://opensource.zalando.com/restful-api-guidelines/#130
            [FromQuery(Name = "created_before")] string createdBefore)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureCelsius = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet("{id}")]
        public WeatherForecast GetById([Required] int id)
        {
            var rng = new Random();

            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(id),
                TemperatureCelsius = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        [HttpPost]
        public IActionResult Create([FromBody] WeatherForecast forecast)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, forecast);
        }
    }
}
