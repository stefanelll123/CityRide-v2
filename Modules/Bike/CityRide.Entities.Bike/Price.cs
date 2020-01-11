using CityRide.Entities.Bike;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CityRide.Entities.Price
{
    public sealed class Price : BaseEntity
    {
        private Price(double value)
        {
            StartDate = DateTime.Now;
            Value = value;
        }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonRequired]
        public DateTime StartDate { get; private set; }

        [BsonRepresentation(BsonType.Double)]
        [BsonRequired]
        public double Value { get; private set; }

        public static Price Create(double value)
        {
            return new Price(value);
        }
    }
}
