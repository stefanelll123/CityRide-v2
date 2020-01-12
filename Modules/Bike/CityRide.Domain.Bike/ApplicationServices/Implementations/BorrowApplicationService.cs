using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Domain.Bike.ApplicationServices.Interfaces;
using CityRide.Entities.Bike;
using CityRide.Entities.Bike.Dtos;
using CityRide.Interop.DataAccess.Bike.Repositories;

namespace CityRide.Domain.Bike.ApplicationServices.Implementations
{
    internal sealed class BorrowApplicationService : IBorrowApplicationService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IBikeRepository _bikeRepository;

        public BorrowApplicationService(IBorrowRepository borrowRepository, IPriceRepository priceRepository, IBikeRepository bikeRepository)
        {
            _borrowRepository = borrowRepository;
            _priceRepository = priceRepository;
            _bikeRepository = bikeRepository;
        }

        async Task<UserBorrowDto> IBorrowApplicationService.GetBikeBorrowedByUser(Guid userId)
        {
            var borrow = _borrowRepository.GetBorrowBy(userId);
            if (borrow == null)
            {
                return null;
            }

            return await CreateUserBorrowHistory(borrow);
        }

        async Task<ICollection<UserBorrowDto>> IBorrowApplicationService.GetUserBorrowHistory(Guid userId)
        {
            var borrows = await _borrowRepository.GetHistoryBorrowHistory(userId);

            var userBorrowDtoList = new List<UserBorrowDto>();
            foreach (var borrow in borrows)
            {
                userBorrowDtoList.Add(await CreateUserBorrowHistory(borrow));
            }

            return userBorrowDtoList;
        }

        private async Task<UserBorrowDto> CreateUserBorrowHistory(Borrow borrow)
        {
            var price = _priceRepository.GetPriceBy(borrow.PriceId);
            var bike = await _bikeRepository.GetBikeBy(borrow.BikeId);

            return UserBorrowDto.Create(bike, borrow, price);
        }
    }
}
