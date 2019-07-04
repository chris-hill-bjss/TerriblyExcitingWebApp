using System;

namespace TerriblyExcitingWebApp.Data.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TemperatureC { get; set; }
    }
}
