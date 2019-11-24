using CityRide.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityRide.Business.Repositories
{
    public interface IBikeRepository
    {
        Task AddAsync(Bike bike);

        Task<ICollection<Bike>> GetAllAsync();
    }
}
