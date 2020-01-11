using System;
using System.Threading.Tasks;

using CityRide.Entities.Bike;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IBorrowRepository
    {
        Task AddBorrow(Entities.Bike.Borrow borrow);

        Task<double> GetBorrowHours(Guid bikeId);

        Task<Entities.Bike.Borrow> GetBorrowByBikeId(Guid bikeId);

        Task UpdateBorrow(Entities.Bike.Borrow borrow);

        Borrow GetBorrowBy(Guid userId);
    }
}
