using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityRide.Domain.Bike.ApplicationServices.Interfaces
{
    public interface IBikeApplicationService
    {
        Task AddBikeAsync(Entities.Bike.Bike bike);

        Task<ICollection<Entities.Bike.Bike>> GetAllBikesAsync();
    }
}
