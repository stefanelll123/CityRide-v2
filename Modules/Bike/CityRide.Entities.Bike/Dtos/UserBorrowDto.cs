using System;

namespace CityRide.Entities.Bike.Dtos
{
    public class UserBorrowDto
    {
        public Guid BikeId { get; set; }

        public string BikeModel { get; set; }

        public double TimeBorrowed { get; set; }

        public double PricePerHour { get; set; }

        public static UserBorrowDto Create(Bike bike, Borrow borrow, Price.Price price)
        {
            return new UserBorrowDto
            {
                BikeId = bike.Id,
                BikeModel = bike.Model,
                PricePerHour = price.Value,
                TimeBorrowed = 10
            };
        }
    }
}
