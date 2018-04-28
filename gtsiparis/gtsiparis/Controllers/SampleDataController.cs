using System;
using System.Collections.Generic;
using System.Linq;
using gtsiparis.Data;
using Microsoft.AspNetCore.Mvc;

namespace gtsiparis.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly TdtDbContext _dbContext;

        public SampleDataController(TdtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            try
            {
                var kategoriList = _dbContext.Kategori.ToArray();
                
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = kategoriList[index].Ad
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
