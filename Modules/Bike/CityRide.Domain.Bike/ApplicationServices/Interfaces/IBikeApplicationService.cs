﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Entities.Bike.Dtos;
using CityRide.Ports.Web.Bike.Models;

namespace CityRide.Domain.Bike.ApplicationServices.Interfaces
{
    public interface IBikeApplicationService
    {
        Task AddBikeAsync(Entities.Bike.Bike bike);

        Task<ICollection<Entities.Bike.Bike>> GetAllBikesAsync();

        Task<ICollection<Entities.Bike.Bike>> GetAllBikesByPosition(double latitude, double longitude);

        Task UpdateBikePosition(Guid bikeId, BikePositionDto bikePositionDto);

        Task<BorrowResponseModel> Borrow(Guid bikeId, Guid userId);

        Task<ReturnBikeResponseModel> Return(Guid bikeId, Guid userId);
    }
}
