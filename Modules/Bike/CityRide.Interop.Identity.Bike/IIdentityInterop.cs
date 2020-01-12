using CityRide.Entities.Identity.Dtos;
using System;
using System.Threading.Tasks;

namespace CityRide.Interop.Identity.Bike
{
    public interface IIdentityInterop
    {
        Task<CardDto> GetCardEndNumbers(Guid userId);
    }
}
