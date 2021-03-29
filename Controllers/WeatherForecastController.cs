using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //Return a string
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if(id >= 10)
            {
                return "WeatherForecast only have 10 element, please specify an id from 0 to 9";
            } else if (id < 0)
            {
                return " please specify an id from 0 to 9";
            }
            return Summaries[id];
        }


        // Return a list of header names and their values.
        [HttpGet("header")]
        public IActionResult GetHeader()
        {
            var headers = base.Request.Headers;

            return base.Ok(headers);
        }

        // Return a list of query names and their values.
        [HttpGet("query")]
        public IActionResult GetQuery()
        {
            //The varaible query will contains the query value passed. Weare using here just to differetiate from the Get without parameters.

            var query_from_URL = base.Request.Query;

            return base.Ok(query_from_URL);
        }
    }
}
