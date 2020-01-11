using System;
using System.Threading.Tasks;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IPriceRepository
    {
        Task<double> GetValue();
    }
}
