using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Entities.Bike.Dtos;

namespace CityRide.Domain.Bike.ApplicationServices.Interfaces
{
    public interface IBorrowApplicationService
    {
        Task<UserBorrowDto> GetBikeBorrowedByUser(Guid userId);

        Task<ICollection<UserBorrowDto>> GetUserBorrowHistory(Guid userId);
    }
}
