using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CityRide.Entities.Bike
{
    public class Borrow: BaseEntity
    {
        private Borrow(Guid bikeId)
        {
            BikeId = bikeId;
            StartDate = DateTime.Now;
            EndDate = null;
        }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public Guid BikeId { get; private set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? EndDate { get; private set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonRequired]
        public DateTime StartDate { get; private set; }

        public static Borrow Create(Guid bikeId)
        {
            return new Borrow(bikeId);
        }

        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}
