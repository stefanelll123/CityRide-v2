using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Domain.Bike.ApplicationServices.Interfaces;
using CityRide.Entities.Bike.Dtos;
using CityRide.Interop.DataAccess.Bike.Repositories;

using EnsureThat;

namespace CityRide.Domain.Bike.ApplicationServices.Implementations
{
    public class BikeApplicationService : IBikeApplicationService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeApplicationService(IBikeRepository bikeRepository)
        {
            EnsureArg.IsNotNull(bikeRepository);

            _bikeRepository = bikeRepository;
        }

        async Task IBikeApplicationService.AddBikeAsync(Entities.Bike.Bike bike)
        {
            await _bikeRepository.AddAsync(bike);
        }

        async Task<ICollection<Entities.Bike.Bike>> IBikeApplicationService.GetAllBikesAsync()
        {
            var bikes = await _bikeRepository.GetAllAsync();

            return bikes;
        }

        async Task IBikeApplicationService.UpdateBikePosition(Guid bikeId, BikePositionDto bikePositionDto)
        {
            var bike = await _bikeRepository.GetBikeBy(bikeId);
            bike.UpdateBikePosition(bikePositionDto);

            await _bikeRepository.UpdateBike(bike);
        }
    }
}
