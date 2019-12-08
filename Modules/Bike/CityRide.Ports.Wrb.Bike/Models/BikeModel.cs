namespace CityRide.Ports.Web.Bike.Models
{
    public class BikeModel
    {
        public string Model { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsActive { get; set; }
    }
}
