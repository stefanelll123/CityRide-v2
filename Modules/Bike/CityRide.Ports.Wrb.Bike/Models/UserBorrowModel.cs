using System;

namespace CityRide.Ports.Web.Bike.Models
{
    public class UserBorrowModel
    {
        public Guid BikeId { get; set; }

        public string BikeModel { get; set; }

        public double TimeBorrowed { get; set; }

        public double PricePerHour { get; set; }
    }
}
