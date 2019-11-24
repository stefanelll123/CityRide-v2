using CityRide.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CityRide.Data.Context
{
    public class DatabaseContext
    {
        public IMongoCollection<Bike> Bikes { get; private set; }

        public DatabaseContext(IConfiguration config)
        {
            var connectionString = config.GetSection("ConnectionStrings").Value;
            var databaseName = config.GetSection("DatabaseName").Value;

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            Bikes = database.GetCollection<Bike>("Bike");
        }
    }
}
