using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CityRide.Domain.Entities
{
    public class Bike : BaseEntity
    {
        private Bike(string model, long latitude, long longitude)
            : base()
        {
            Model = model;
            Latitude = latitude;
            Longitude = longitude;
        }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public string Model { get; private set; }

        [BsonRepresentation(BsonType.Double)]
        [BsonRequired]
        public double Latitude { get; private set; }

        [BsonRepresentation(BsonType.Double)]
        [BsonRequired]
        public double Longitude { get; private set; }

        [BsonRepresentation(BsonType.Boolean)]
        [BsonRequired]
        public bool IsActive { get; private set; }

        public static Bike Create(string model, long latitude, long longitude)
        {
            return new Bike(model, latitude, longitude);
        }
    }
}
