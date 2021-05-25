using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {

        private readonly ILogger<BeerController> _logger;

        public BeerController(ILogger<BeerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string[] Get()
        {
            Console.WriteLine("Inside Get()");

            if (String.IsNullOrEmpty(Beer.Status))
            {
                Console.WriteLine("Inside Get Initial Pour");
                Beer.Status = "False";
            }


            if (String.IsNullOrEmpty(Beer.Ounces))
            {
                Console.WriteLine("Inside Get Initial Ounces");
                Beer.Ounces = "12";
            }

            string[] result = { Beer.Status, Beer.Ounces };


            Console.WriteLine("Beer.Pour: " + Beer.Status);
            Console.WriteLine("Beer.Ounces: " + Beer.Ounces);
            return result;
        }

        [HttpPost]
        public void Set([FromForm] String pourStatus, [FromForm] String newOunces)
        {
            Console.WriteLine("Inside Set()");
            Console.WriteLine("newPour: " + pourStatus);
            Console.WriteLine("newOunces: " + newOunces);
            Beer.Status = pourStatus;
            Beer.Ounces = newOunces;

        }
    }
}
