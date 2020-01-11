using System;

namespace CityRide.Ports.Web.Bike.Models
{
    public class ReturnBikeResponseModel
    {
        public ReturnBikeResponseModel(double hours, double price)
        {
            Price = price;
            Hours = hours;
            CardNumber = "5314";
        }

        public string CardNumber { get; private set; }

        public double Price { get; private set; }

        public double Hours { get; private set; }
    }
}
