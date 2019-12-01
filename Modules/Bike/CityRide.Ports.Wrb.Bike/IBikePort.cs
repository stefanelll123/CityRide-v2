using System.Collections.Generic;
using System.Threading.Tasks;
using CityRide.Ports.Web.Bike.Models;

namespace CityRide.Ports.Web.Bike
{
    public interface IBikePort
    {
        Task AddBike(BikeModel bikeModel);

        Task<ICollection<BikeModel>> GetAllBikesAsync();
    }
}
