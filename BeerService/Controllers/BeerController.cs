using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeerService.Interface;

//https://www.mindstick.com/articles/628/process-start-in-c-sharp-with-examples

namespace BeerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {

        private readonly ILogger<BeerController> _logger;
        
        event Action PourBeer;

        private IBeer beer;

        public BeerController(ILogger<BeerController> logger)
        {
            _logger = logger;
            this.beer = new Beer();
        }

        [HttpGet]
        public string[] Get()
        {
            Console.WriteLine("Inside Get()");

            if (String.IsNullOrEmpty(beer.Ounces))
            {
                Console.WriteLine("Inside Get Initial Ounces");
                beer.Ounces = "12";
                beer.Status = false;
            }

            string[] result = { beer.Status.ToString(), beer.Ounces };

            Console.WriteLine("Beer.Pour: " + beer.Status);
            Console.WriteLine("Beer.Ounces: " + beer.Ounces);
            return result;
        }

        [HttpPost]
        public void Set([FromForm] String pourStatus, [FromForm] String newOunces)
        {
            Console.WriteLine("Inside Set()");
            Console.WriteLine("newPour: " + pourStatus);
            Console.WriteLine("newOunces: " + newOunces);

            try{
                beer.Status = bool.Parse(pourStatus);
                beer.Ounces = newOunces;
                beer.TriggerEvent();

                
            }catch (Exception e){
                beer.Status = false;
                beer.Ounces = "12";
                Console.WriteLine($"Could not update properties. Message: {e.Message}");
            }
        }
    }
}
