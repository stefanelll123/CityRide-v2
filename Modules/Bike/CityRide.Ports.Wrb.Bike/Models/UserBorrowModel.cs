namespace CityRide.Ports.Web.Bike.Models
{
    public class UserBorrowModel
    {
        public string BikeModel { get; set; }

        public double TimeBorrowed { get; set; }

        public double PricePerHour { get; set; }
    }
}
