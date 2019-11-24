using CityRide.Business.Repositories;
using CityRide.Data.Context;
using CityRide.Domain.Entities;
using EnsureThat;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityRide.Data.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private IMongoCollection<Bike> _bikes;
        
        public BikeRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _bikes = databaseContext.Bikes;
        }

        async Task IBikeRepository.AddAsync(Bike bike)
        {
            await _bikes.InsertOneAsync(bike);
        }

        async Task<ICollection<Bike>> IBikeRepository.GetAllAsync()
        {
            var bikes = await _bikes.FindAsync(x => true);

            return bikes.ToList();
        }
    }
}
