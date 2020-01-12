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
    internal sealed class BikeApplicationService : IBikeApplicationService
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IBorrowRepository _borrowRepository;
        private readonly IPriceRepository _priceRepository;

        private const int numberOfMeters = 10000;

        public BikeApplicationService(IBikeRepository bikeRepository, IBorrowRepository borrowRepository, IPriceRepository priceRepository)
        {
            EnsureArg.IsNotNull(bikeRepository);
            EnsureArg.IsNotNull(borrowRepository);
            EnsureArg.IsNotNull(priceRepository);

            _bikeRepository = bikeRepository;
            _borrowRepository = borrowRepository;
            _priceRepository = priceRepository;
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

        async Task<ICollection<Entities.Bike.Bike>> IBikeApplicationService.GetAllBikesByPosition(double latitude, double longitude)
        {
            return await _bikeRepository.GetAllByPosition(latitude, longitude, numberOfMeters);
        }

        async Task IBikeApplicationService.UpdateBikePosition(Guid bikeId, BikePositionDto bikePositionDto)
        {
            var bike = await _bikeRepository.GetBikeBy(bikeId);
            bike.UpdateBikePosition(bikePositionDto);

            await _bikeRepository.UpdateBike(bike);
        }

        async Task<BorrowResponseModel> IBikeApplicationService.Borrow(Guid bikeId, Guid userId)
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

                    var price = _priceRepository.GetLastPrice();

                    await _borrowRepository.AddBorrow(Borrow.Create(bikeId, userId, price.Id));
                    await _bikeRepository.UpdateBike(bike);
                }
            }

            return responseModel;
        }

        async Task<ReturnBikeResponseModel> IBikeApplicationService.Return(Guid bikeId)
        {
            var price = await _priceRepository.GetValue();
            var borrowHours = await _borrowRepository.GetBorrowHours(bikeId);

            if (price == -1 || borrowHours == -1)
            {
                return null;
            }

            var returnBikeResponseModel = new ReturnBikeResponseModel(borrowHours, price);

            await _bikeRepository.SetActive(bikeId);

            return returnBikeResponseModel;
        }
    }
}
