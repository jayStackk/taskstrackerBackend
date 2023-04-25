using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasktrackerBackend.Services
{
    public class UserService
    {
        public UserService(){

        }

        public IEnumerable<WeatherForecast> Get(string[] Summaries)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    }
}