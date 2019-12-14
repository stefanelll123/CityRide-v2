using System;

namespace CityRide.Ports.Web.Bike.Models
{
    public sealed class BikeModel
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool IsActive { get; set; }
    }
}
