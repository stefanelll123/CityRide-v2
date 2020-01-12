using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityRide.Ports.Web.Bike.Models;

namespace CityRide.Ports.Web.Bike
{
    public interface IBikePort
    {
        Task AddBike(BikeCreateModel bikeModel);

        Task<ICollection<BikeModel>> GetBikesByPosition(double latitude, double longitude);

        Task<ICollection<BikeModel>> GetAllBikesAsync();

        Task UpdateBikePosition(Guid id, BikePositionModel bikePositionModel);

        Task<BorrowResponseModel> Borrow(Guid bikeId, Guid userId);

        Task<ReturnBikeResponseModel> Return(Guid bikeId);

        Task<UserBorrowModel> GetBikeBorrowedByUser(Guid userId);
    }
}
