using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzz : ControllerBase
    {
        

        private readonly ILogger<FizzBuzz> _logger;

        public FizzBuzz(ILogger<FizzBuzz> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get([FromQuery(Name = "vals")] string vals)
        {
            var values = vals.Split(',').ToArray();
            var json = new List<string>();
            
            foreach (var v in values)
            {
                bool isNum = Int32.TryParse(v, out int numericValue); //assuming only 32bit ints

                if (!isNum)
                {
                    json.Add("Invalid Item");
                    continue;
                }

                if (numericValue % 3 == 0 && numericValue % 5 == 0)
                {
                    json.Add("FizzBuzz");
                    continue;
                }
                    
                if (numericValue % 3 == 0)
                {
                    json.Add("Fizz");
                    continue;
                }
                else
                {
                    json.Add($"Divided {numericValue} by 3");
                }

                if (numericValue % 5 == 0)
                {
                    json.Add("Buzz");
                    continue;
                }
                else
                {
                    json.Add($"Divided {numericValue} by 5");
                }
            }

            return Ok(json);
        }
    }
}
