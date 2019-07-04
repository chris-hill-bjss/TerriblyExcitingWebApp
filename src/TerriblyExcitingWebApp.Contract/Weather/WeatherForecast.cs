using System;

namespace TerriblyExcitingWebApp.Contract.Weather
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF => 32 + (TemperatureC / 0.5556);

        public string Summary
        {
            get
            {
                if (TemperatureC < 0)
                    return "Freezing";

                if (TemperatureC < 2)
                    return "Bracing";

                if (TemperatureC < 5)
                    return "Chilly";

                if (TemperatureC < 8)
                    return "Cool";

                if (TemperatureC < 10)
                    return "Bracing";

                if (TemperatureC > 10)
                    return "Mild";

                if (TemperatureC > 20)
                    return "Balmy";

                if (TemperatureC > 25)
                    return "Hot";

                if (TemperatureC > 30)
                    return "Sweltering";

                return "Scorching";
            }
        }
    }
}
