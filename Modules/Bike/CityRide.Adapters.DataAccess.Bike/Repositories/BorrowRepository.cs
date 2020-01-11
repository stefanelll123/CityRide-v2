using System.Threading.Tasks;
using System.Linq;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;
using System;
using CityRide.Entities.Bike;

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

        public async Task AddBorrow(Borrow borrow)
        {
            await _borrows.InsertOneAsync(borrow);
        }

        public async Task<Borrow> GetBorrowByBikeId(Guid id)
        {
            var bike = await _borrows.FindAsync(x => x.BikeId == id && x.EndDate == null);

            return bike.FirstOrDefault();
        }

        public async Task UpdateBorrow(Borrow borrow)
        {
            await _borrows.FindOneAndReplaceAsync(x => x.Id == borrow.Id, borrow);
        }

        public async Task<double> GetBorrowHours(Guid bikeId)
        {
            var borrow = await GetBorrowByBikeId(bikeId);
            double borrowHours = -1;

            if (borrow != null)
            {
                var startDate = borrow.StartDate;
                var endDate = DateTime.Now;

                borrowHours = (endDate - startDate).TotalHours;
                borrow.SetEndDate(endDate);

                await UpdateBorrow(borrow);
            }

            return borrowHours;
        }

        public Borrow GetBorrowBy(Guid userId)
        {
            return _borrows.Find(x => x.UserId == userId).ToList().FirstOrDefault();
        }
    }
}
