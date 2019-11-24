using CityRide.Business.Bikes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityRide.Business.Bikes.ApplicationSerivces.Interfaces
{
    public interface IBikeApplicationService
    {
        Task AddBikeAsync(BikeModel bikeModel);

        Task<ICollection<BikeModel>> GetAllBikesAsync();
    }
}
