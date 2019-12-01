using CityRide.Entities.Bike;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CityRide.Infrastructure
{
    public class DatabaseContext
    {
        public IMongoCollection<Bike> Bikes { get; private set; }

        public DatabaseContext(IConfiguration config)
        {
            var connectionString = config.GetSection("ConnectionStrings").Value;
            var bikeDatabaseName = config.GetSection("BikeModuleName").Value;

            var client = new MongoClient(connectionString);
            var bikeDatabase = client.GetDatabase(bikeDatabaseName);

            Bikes = bikeDatabase.GetCollection<Bike>("Bike");
        }
    }
}
