using Microsoft.Extensions.Configuration;
using CityRide.Entities.Bike;
using CityRide.Entities.Price;
using MongoDB.Driver;
using CityRide.Entities.Identity;

namespace CityRide.Infrastructure
{
    public class DatabaseContext
    {
        public IMongoCollection<Bike> Bikes { get; private set; }

        public IMongoCollection<Borrow> Borrow { get; private set; }

        public IMongoCollection<User> Users { get; private set; }

        public IMongoCollection<Price> Price { get; private set; }

        public DatabaseContext(IConfiguration config)
        {
            var connectionString = config.GetSection("ConnectionStrings").Value;
            var client = new MongoClient(connectionString);

            var bikeDatabaseName = config.GetSection("BikeModuleName").Value;
            var bikeDatabase = client.GetDatabase(bikeDatabaseName);

            Bikes = bikeDatabase.GetCollection<Bike>("Bike");
            Borrow = bikeDatabase.GetCollection<Borrow>("Borrow");

            var identityDatabaseName = config.GetSection("IdentityModuleName").Value;
            var identityDatabase = client.GetDatabase(identityDatabaseName);

            Users = identityDatabase.GetCollection<User>("User");
            Price = bikeDatabase.GetCollection<Price>("Price");
        }
    }
}
