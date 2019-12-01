using System.Collections.Generic;
using System.Threading.Tasks;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;

namespace CityRide.Adapters.DataAccess.Bike.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly IMongoCollection<Entities.Bike.Bike> _bikes;
        
        public BikeRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _bikes = databaseContext.Bikes;
        }

        async Task IBikeRepository.AddAsync(Entities.Bike.Bike bike)
        {
            await _bikes.InsertOneAsync(bike);
        }

        async Task<ICollection<Entities.Bike.Bike>> IBikeRepository.GetAllAsync()
        {
            var bikes = await _bikes.FindAsync(x => true);

            return bikes.ToList();
        }
    }
}
