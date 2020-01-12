using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CityRide.Entities.Bike;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IBorrowRepository
    {
        Task AddBorrow(Borrow borrow);

        Task<double> GetBorrowHours(Guid bikeId);

        Task<Borrow> GetBorrowByBikeId(Guid bikeId);

        Task UpdateBorrow(Borrow borrow);

        Borrow GetBorrowBy(Guid userId);

        Task<ICollection<Borrow>> GetHistoryBorrowHistory(Guid userId);
    }
}
