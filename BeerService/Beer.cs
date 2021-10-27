using System;
using System.IO;
using BeerService.Interface;

namespace BeerService
{
    public class Beer : IBeverage
    {
        public string Ounces { get; set; }
        public bool Status { get; set; }

        public Beer()
        {
            this.Ounces = "12";
            this.Status = false;
        }

        public void TriggerEvent(){
            Console.WriteLine("IM HERE");
            Console.WriteLine($"Ounces: {this.Ounces}");
            Console.WriteLine($"Status: {this.Status}");
            String currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Directory: {currentDirectory}");
        }
    }
}
                
