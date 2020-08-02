using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // public class WeatherForecastController : ControllerBase
    // {
    //     private static readonly string[] Summaries = new[]
    //     {
    //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     };

    //     private readonly ILogger<WeatherForecastController> _logger;

    //     public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //     {
    //         _logger = logger;
    //     }

    //     [HttpGet]
    //     public IEnumerable<WeatherForecast> Get()
    //     {
    //         var rng = new Random();
    //         //throw new Exception("Hello");
    //         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateTime.Now.AddDays(index),
    //             TemperatureC = rng.Next(-20, 55),
    //             Summary = Summaries[rng.Next(Summaries.Length)]
    //         })
    //         .ToArray();
    //     }
    // }

    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context; // _ is only our preference

        public ValuesController(DataContext context)
        {
            _context = context;

        }

        //https://localhost/5000/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);  // Ok returns also http 200 code 
        }

        //https://localhost/5000/values/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value); 
        }

    }
}
