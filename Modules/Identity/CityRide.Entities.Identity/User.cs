using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CityRide.Entities.Identity
{
    public class User : BaseEntity
    {
        private User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public string FullName { get; private set; }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public string Email { get; private set; }

        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public string Password { get; private set; }

        public static User Create(string fullName, string email, string password)
        {
            return new User(fullName, email, password);
        }
    }
}
