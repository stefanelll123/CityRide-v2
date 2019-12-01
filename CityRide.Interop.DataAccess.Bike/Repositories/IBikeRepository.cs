using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IBikeRepository
    {
        Task AddAsync(Entities.Bike.Bike bike);

        Task<ICollection<Entities.Bike.Bike>> GetAllAsync();
    }
}
