using System.Threading.Tasks;
using System.Linq;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;
using System;
using CityRide.Entities.Bike;
using System.Collections.Generic;

namespace CityRide.Adapters.DataAccess.Bike.Repositories
{
    public sealed class BorrowRepository : IBorrowRepository
    {
        private readonly IMongoCollection<Borrow> _borrows;

        public BorrowRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _borrows = databaseContext.Borrow;
        }

        async Task IBorrowRepository.AddBorrow(Borrow borrow)
        {
            await _borrows.InsertOneAsync(borrow);
        }

        async Task<Borrow> IBorrowRepository.GetBorrowByBikeId(Guid id)
        {
            var bike = await _borrows.FindAsync(x => x.BikeId == id && x.EndDate == null);

            return bike.FirstOrDefault();
        }

        async Task IBorrowRepository.UpdateBorrow(Borrow borrow)
        {
            await _borrows.FindOneAndReplaceAsync(x => x.Id == borrow.Id, borrow);
        }

        async Task<double> IBorrowRepository.GetBorrowHours(Guid bikeId)
        {
            var borrow = await (this as IBorrowRepository).GetBorrowByBikeId(bikeId);
            double borrowHours = -1;

            if (borrow != null)
            {
                var startDate = borrow.StartDate;
                var endDate = DateTime.Now;

                borrowHours = (endDate - startDate).TotalHours;
                borrow.SetEndDate(endDate);

                await (this as IBorrowRepository).UpdateBorrow(borrow);
            }

            return borrowHours;
        }

        Borrow IBorrowRepository.GetBorrowBy(Guid userId)
        {
            return _borrows.Find(x => x.UserId == userId && x.EndDate == null).ToList().FirstOrDefault();
        }

        async Task<ICollection<Borrow>> IBorrowRepository.GetHistoryBorrowHistory(Guid userId)
        {
            return (await _borrows.FindAsync(x => x.UserId == userId &&
                                                  x.EndDate != null))
                .ToList();
        }
    }
}
