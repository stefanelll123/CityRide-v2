using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CityRide.Entities.Bike
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public Guid Id { get; private set; }
    }
}
