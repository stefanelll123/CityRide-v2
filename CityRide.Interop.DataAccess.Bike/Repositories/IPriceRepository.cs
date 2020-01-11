using CityRide.Entities.Price;
using System;
using System.Threading.Tasks;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IPriceRepository
    {
        Task<double> GetValue();

        Price GetPriceBy(Guid id);

        Price GetLastPrice();
    }
}
