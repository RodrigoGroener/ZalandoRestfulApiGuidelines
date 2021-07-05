using System;
using System.ComponentModel.DataAnnotations;

namespace ZalandoRestfulApiGuidelinesWebApi
{
    public class WeatherForecast
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TemperatureCelsius { get; set; }

        public int TemperatureFahrenheit => 32 + (int)(TemperatureCelsius / 0.5556);

        public string Summary { get; set; }
    }
}
