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

        private User(string fullName, string email, string password, Card card)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Card = card;
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

        public Card Card { get; private set; }

        public void AddCard(Card card)
        {
            Card = card;
        }

        public static User Create(string fullName, string email, string password)
        {
            return new User(fullName, email, password);
        }

        public static User Create(string fullName, string email, string password, Card card)
        {
            return new User(fullName, email, password, card);
        }
    }
}
