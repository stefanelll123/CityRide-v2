using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Entities.Bike.Dtos;

namespace CityRide.Domain.Bike.ApplicationServices.Interfaces
{
    public interface IBikeApplicationService
    {
        Task AddBikeAsync(Entities.Bike.Bike bike);

        Task<ICollection<Entities.Bike.Bike>> GetAllBikesAsync();

        Task UpdateBikePosition(Guid bikeId, BikePositionDto bikePositionDto);
    }
}
