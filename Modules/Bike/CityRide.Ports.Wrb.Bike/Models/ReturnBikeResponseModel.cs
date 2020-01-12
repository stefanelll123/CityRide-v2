using System;

namespace CityRide.Ports.Web.Bike.Models
{
    public class ReturnBikeResponseModel
    {
        public ReturnBikeResponseModel(double hours, double price, string cardNumber)
        {
            Price = price;
            Hours = hours;
            CardNumber = cardNumber;
        }

        public string CardNumber { get; private set; }

        public double Price { get; private set; }

        public double Hours { get; private set; }
    }
}
