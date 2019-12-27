using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Domain.Bike.ApplicationServices.Interfaces;
using CityRide.Entities.Bike;
using CityRide.Entities.Bike.Dtos;
using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Ports.Web.Bike.Models;

using EnsureThat;

namespace CityRide.Domain.Bike.ApplicationServices.Implementations
{
    public class BikeApplicationService : IBikeApplicationService
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IBorrowRepository _borrowRepository;

        public BikeApplicationService(IBikeRepository bikeRepository, IBorrowRepository borrowRepository)
        {
            EnsureArg.IsNotNull(bikeRepository);
            EnsureArg.IsNotNull(borrowRepository);

            _bikeRepository = bikeRepository;
            _borrowRepository = borrowRepository;
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

        async Task<BorrowResponseModel> IBikeApplicationService.Borrow(Guid bikeId)
        {
            var bike = await _bikeRepository.GetBikeBy(bikeId);
            var responseModel = new BorrowResponseModel();

            if (bike != null)
            {
                responseModel.MarkAsFound();

                if (bike.IsActive)
                {
                    responseModel.MarkAsBorrowable();
                    bike.BorrowBike();

                    await _borrowRepository.AddBorrow(Borrow.Create(bikeId));
                    await _bikeRepository.UpdateBike(bike);
                }
            }

            return responseModel;
        }
    }
}
