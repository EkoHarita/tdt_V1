using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtsiparis.Data;
using Microsoft.AspNetCore.Mvc;

namespace gtsiparis.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly TdtDbContext _dbContext;

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public SampleDataController(TdtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {

            try
            {
                var list = _dbContext.Grup.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
