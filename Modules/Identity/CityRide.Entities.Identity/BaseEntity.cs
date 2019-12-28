using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CityRide.Entities.Identity
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public Guid Id { get; private set; }
    }
}
