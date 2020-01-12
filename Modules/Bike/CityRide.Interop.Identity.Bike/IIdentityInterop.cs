using CityRide.Entities.Bike.Dtos;
using System;
using System.Threading.Tasks;

namespace CityRide.Interop.Identity.Bike
{
    public interface IIdentityInterop
    {
        Task<CardDto> GetCardEndNumbers(Guid userId);

        Task<UserDto> GetUserInfo(Guid userId);
    }
}
