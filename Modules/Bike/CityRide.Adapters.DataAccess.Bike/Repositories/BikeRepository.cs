using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;

namespace CityRide.Adapters.DataAccess.Bike.Repositories
{
    internal sealed class BikeRepository : IBikeRepository
    {
        private readonly IMongoCollection<Entities.Bike.Bike> _bikes;

        public BikeRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _bikes = databaseContext.Bikes;
        }

        public async Task<Entities.Bike.Bike> GetBikeBy(Guid id)
        {
            var bike = await _bikes.FindAsync(x => x.Id == id);

            return bike.FirstOrDefault();
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

        public async Task UpdateBike(Entities.Bike.Bike bike)
        {
            await _bikes.FindOneAndReplaceAsync(x => x.Id == bike.Id, bike);
        }
    }
}
