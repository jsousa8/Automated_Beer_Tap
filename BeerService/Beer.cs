using System;
using BeerService.Interface;

namespace BeerService
{
    public class Beer : IBeer
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
        }
    }
}
                
