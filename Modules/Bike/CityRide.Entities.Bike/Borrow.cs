using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CityRide.Entities.Bike
{
    public sealed class Borrow : BaseEntity
    {
        private Borrow(Guid bikeId, Guid userId, Guid priceId)
        {
            BikeId = bikeId;
            StartDate = DateTime.Now;
            EndDate = null;
            UserId = userId;
            PriceId = priceId;
        }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public Guid BikeId { get; private set; }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public Guid UserId { get; private set; }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public Guid PriceId { get; private set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? EndDate { get; private set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonRequired]
        public DateTime StartDate { get; private set; }

        public static Borrow Create(Guid bikeId, Guid userId, Guid priceId)
        {
            return new Borrow(bikeId, userId, priceId);
        }

        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }

        public double ComputeBorrowHours()
        {
            var endDate = DateTime.Now.ToUniversalTime();
            var startDate = StartDate.ToUniversalTime();
            var diff = endDate.Subtract(startDate);

            return diff.TotalHours;
        }
    }
}
