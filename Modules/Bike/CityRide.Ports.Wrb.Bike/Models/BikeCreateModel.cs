namespace CityRide.Ports.Web.Bike.Models
{
    public sealed class BikeCreateModel
    {
        public string Model { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool IsActive { get; set; }
    }
}
