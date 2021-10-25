using System;
namespace BeerService.Interface
{
    public interface IBeverage
    {
        /// <summary>
        /// Amount of ounces to pour
        /// </summary>
        public string Ounces { get; set; }

        /// <summary>
        /// Boolean status if to pour or not.
        /// </summary>
        public bool Status { get; set; }
        
        /// <summary>
        /// Control the servo motors.
        ///
        public void TriggerEvent();
    }
}   
