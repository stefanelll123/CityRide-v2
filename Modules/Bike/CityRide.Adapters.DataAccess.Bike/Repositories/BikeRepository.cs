using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;
using System.Linq;

namespace CityRide.Adapters.DataAccess.Bike.Repositories
{
    internal sealed class BikeRepository : IBikeRepository
    {
        private readonly IMongoCollection<Entities.Bike.Bike> _bikes;

        private const double earthRange = 6378137;

        public BikeRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _bikes = databaseContext.Bikes;
        }

        async Task<Entities.Bike.Bike> IBikeRepository.GetBikeBy(Guid id)
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

        async Task<ICollection<Entities.Bike.Bike>> IBikeRepository.GetAllByPosition(double latitude, double longitude, int meters)
        {
            var latitudeMaxDifference = meters / earthRange * (180 / Math.PI);
            var longitudeMaxDifference = meters / (earthRange * Math.Cos(Math.PI / latitude * 180)) * (180 / Math.PI);

            return (await _bikes.FindAsync(x => true)).ToList().Where(
                x => x.Latitude != null && x.Longitude != null &&
                     x.Latitude >= latitude - latitudeMaxDifference &&
                     x.Latitude <= latitude + latitudeMaxDifference &&
                     x.Longitude >= longitude - longitudeMaxDifference &&
                     x.Longitude <= longitude + longitudeMaxDifference).ToList();
        }

        async Task IBikeRepository.UpdateBike(Entities.Bike.Bike bike)
        {
            await _bikes.FindOneAndReplaceAsync(x => x.Id == bike.Id, bike);
        }

        async Task IBikeRepository.SetActive(Guid id)
        {
            var filter = Builders<Entities.Bike.Bike>.Filter.Eq("_id", id);
            var update = Builders<Entities.Bike.Bike>.Update.Set("IsActive", true);

            await _bikes.UpdateOneAsync(filter, update);
        }
    }
}
