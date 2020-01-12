using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IBikeRepository
    {
        Task<Entities.Bike.Bike> GetBikeBy(Guid id);

        Task AddAsync(Entities.Bike.Bike bike);

        Task<ICollection<Entities.Bike.Bike>> GetAllAsync();

        Task<ICollection<Entities.Bike.Bike>> GetAllByPosition(double latitude, double longitude, int distance);

        Task UpdateBike(Entities.Bike.Bike bike);

        Task SetActive(Guid id);
    }
}
