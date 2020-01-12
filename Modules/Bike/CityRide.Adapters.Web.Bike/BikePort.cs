using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CityRide.Domain.Bike.ApplicationServices.Interfaces;
using CityRide.Entities.Bike.Dtos;
using CityRide.Ports.Web.Bike;
using CityRide.Ports.Web.Bike.Models;
using EnsureThat;

namespace CityRide.Adapters.Web.Bike
{
    internal sealed class BikePort : IBikePort
    {
        private readonly IBikeApplicationService _bikeApplicationService;
        private readonly IBorrowApplicationService _borrowApplicationService;
        private readonly IMapper _mapper;

        public BikePort(IBikeApplicationService bikeApplicationService, IBorrowApplicationService borrowApplicationService, IMapper mapper)
        {
            EnsureArg.IsNotNull(bikeApplicationService);
            EnsureArg.IsNotNull(mapper);

            _bikeApplicationService = bikeApplicationService;
            _borrowApplicationService = borrowApplicationService;
            _mapper = mapper;
        }

        async Task<BorrowResponseModel> IBikePort.Borrow(Guid bikeId, Guid userId)
        {
            return await _bikeApplicationService.Borrow(bikeId, userId);
        }

        async Task IBikePort.AddBike(BikeCreateModel bikeModel)
        {
            var bike = _mapper.Map<Entities.Bike.Bike>(bikeModel);
            await _bikeApplicationService.AddBikeAsync(bike);
        }

        async Task<ICollection<BikeModel>> IBikePort.GetBikesByPosition(double latitude, double longitude)
        {
            var bikes = await _bikeApplicationService.GetAllBikesByPosition(latitude, longitude);

            return _mapper.Map<ICollection<BikeModel>>(bikes);
        }

        async Task<ICollection<BikeModel>> IBikePort.GetAllBikesAsync()
        {
            var bikes = await _bikeApplicationService.GetAllBikesAsync();

            return _mapper.Map<ICollection<BikeModel>>(bikes);
        }

        async Task IBikePort.UpdateBikePosition(Guid id, BikePositionModel bikePositionModel)
        {
            var bikePositionDto = _mapper.Map<BikePositionDto>(bikePositionModel);

            await _bikeApplicationService.UpdateBikePosition(id, bikePositionDto);
        }

        async Task<ReturnBikeResponseModel> IBikePort.Return(Guid bikeId)
        {
            return await _bikeApplicationService.Return(bikeId);
        }

        async Task<UserBorrowModel> IBikePort.GetBikeBorrowedByUser(Guid userId)
        {
            var userBorrow = await _borrowApplicationService.GetBikeBorrowedByUser(userId);

            return _mapper.Map<UserBorrowModel>(userBorrow);
        }
    }
}
