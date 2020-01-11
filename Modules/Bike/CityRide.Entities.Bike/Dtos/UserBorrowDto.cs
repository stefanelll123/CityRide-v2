namespace CityRide.Entities.Bike.Dtos
{
    public class UserBorrowDto
    {
        public string BikeModel { get; set; }

        public double TimeBorrowed { get; set; }

        public double PricePerHour { get; set; }

        public static UserBorrowDto Create(Bike bike, Borrow borrow, Price.Price price)
        {
            return new UserBorrowDto
            {
                BikeModel = bike.Model,
                PricePerHour = price.Value,
                TimeBorrowed = 10
            };
        }
    }
}
